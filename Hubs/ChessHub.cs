using BlazorServerChess.Data;
using BlazorServerChess.Data.ChessGame;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Text.Json;

namespace BlazorServerChess.Hubs
{
    public class ChessHub : Hub
    {
        internal static ConcurrentDictionary<string, ServerGame> ServerGames = new ConcurrentDictionary<string, ServerGame>();

        public async Task SendMessage(string username, string message, string groupGuid)
        {
            await Clients.Group(groupGuid).SendAsync("ReceiveMessage", username, message);
        }
        public async Task SendErrorMessage(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveErrorMessage", message);
        }
        public async Task AddToGroup (string groupGuid, string userId)
        {
            
            await Groups.AddToGroupAsync(Context.ConnectionId, groupGuid);
            ServerGames.TryAdd(groupGuid, new ServerGame());
            ServerGame groupGame = ServerGames[groupGuid];
            groupGame.TryAddPlayer(userId, Context.ConnectionId);
            if (!groupGame.GameisFull())
            {
                await Clients.Group(groupGuid).SendAsync("ReceiveErrorMessage", "waiting for player to join");
            }
            else
            {
                await Clients.Group(groupGuid).SendAsync("ReceiveErrorMessage", "Game Started");
                groupGame.game = new Game();
                string groupGameJson = JsonSerializer.Serialize<ServerGame>(groupGame);
                await Clients.Group(groupGuid).SendAsync("ReceiveInitializeGame", groupGameJson);
            }
        }
        public async Task HandleMove (string groupGuid, Move move)
        {
            ServerGame groupGame = ServerGames[groupGuid];
            groupGame.game.HandleMove(move);
            string gameJson = JsonSerializer.Serialize<Game>(groupGame.game);
            await Clients.Group(groupGuid).SendAsync("ReceiveUpdateGame", gameJson);
        }
	}
}
