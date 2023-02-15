using Microsoft.AspNetCore.SignalR;

namespace BlazorServerChess.Hubs
{
    public class ChessHub : Hub
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
        public async Task AddToGroup (string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }
    }
}
