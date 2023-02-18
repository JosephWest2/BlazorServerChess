using BlazorServerChess.Data;
using BlazorServerChess.Data.ChessGame;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace BlazorServerChess.Hubs
{
    public class ChessHub : Hub
    {
        internal static ConcurrentDictionary<string, HashSet<string>> GroupConnectionState = new ConcurrentDictionary<string, HashSet<string>>();
        public async Task SendMessage(string username, string message, string groupGuid)
        {
            await Clients.Group(groupGuid).SendAsync("ReceiveMessage", username, message);
        }
        public async Task SendErrorMessage(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveErrorMessage", message);
        }
        public async Task AddToGroup (string groupGuid)
        {
            if (GroupConnectionState.ContainsKey(groupGuid) && GroupConnectionState[groupGuid].Count >= 2)
            {
				await SendErrorMessage(Context.ConnectionId, "Group full");
				return;
			}
            await Groups.AddToGroupAsync(Context.ConnectionId, groupGuid);
            if (!GroupConnectionState.TryAdd(groupGuid, new HashSet<string> {Context.ConnectionId}))
            {
                GroupConnectionState[groupGuid].Add(Context.ConnectionId);
            }

            if (GroupConnectionState[groupGuid].Count == 2)
            {
                List<string> options = new List<string>();
                foreach (string connId in GroupConnectionState[groupGuid])
                {
                    options.Add(connId);
                }
                string whitePlayerConnectionId;
                var rand = new Random(); 
                whitePlayerConnectionId = rand.NextDouble() < 0.5 ? options[0] : options[1];
				Clients.Group(groupGuid).SendAsync("InitializeGame", whitePlayerConnectionId);
            }
        }
        public async Task HandleMove (string groupGuid, Move move)
        {
            await Clients.Group(groupGuid).SendAsync("ReceiveMove", move);
        }
		public override async Task OnDisconnectedAsync(Exception? exception)
		{
            foreach (KeyValuePair<string,HashSet<string>> entry in GroupConnectionState)
            {
                entry.Value.Remove(Context.ConnectionId);
                if (entry.Value.Count == 0)
                {
                    HashSet<string> b;
                    GroupConnectionState.TryRemove(entry.Key, out b);
                }
			}
			await base.OnDisconnectedAsync(exception);
		}
	}
}
