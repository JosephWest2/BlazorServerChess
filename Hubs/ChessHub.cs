using BlazorServerChess.Data;
using BlazorServerChess.Data.ChessGame;
using BlazorServerChess.Data.Services;
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
        public async Task AddToGroup (string groupGuid, string userId, string username)
        {
            
            await Groups.AddToGroupAsync(Context.ConnectionId, groupGuid);
            ServerGames.TryAdd(groupGuid, new ServerGame(groupGuid));
            ServerGame groupGame = ServerGames[groupGuid];
            

            if (groupGame.ContainsNoPlayers())
            {
                groupGame.TryAddPlayer(userId, Context.ConnectionId, username);
                await Clients.Group(groupGuid).SendAsync("ReceiveErrorMessage", "waiting for player to join");
            }
            else if (groupGame.ContainsOnePlayer())
            {
                groupGame.TryAddPlayer(userId, Context.ConnectionId, username);
                if (groupGuid.Length >= 2)
                {
                    int i = groupGuid.LastIndexOf('*');
                    string? t = null;
                    int n = 5;
                    if (i < groupGuid.Length - 1)
                    {
                        Console.WriteLine(i);
                        t = groupGuid.Substring(i + 1);
                        n = Int32.Parse(t);
                    }
                    groupGame.game = new Game(n);
                }
                else
                {
                    groupGame.game = new Game();
                }
                string groupGameJson = JsonSerializer.Serialize<ServerGame>(groupGame);
                await Clients.Group(groupGuid).SendAsync("ReceiveInitializeGame", groupGameJson, "Game Started");
            }
            else if (groupGame.PlayerIsInGame(userId))
            {
                string groupGameJson = JsonSerializer.Serialize<ServerGame>(groupGame);
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveInitializeGame", groupGameJson, "Game Rejoined");
            }
            else
            {
                string groupGameJson = JsonSerializer.Serialize<ServerGame>(groupGame);
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveAddSpectator", groupGameJson);
            }
        }
        public async Task HandleMove (string groupGuid, Move move)
        {
            ServerGame groupGame = ServerGames[groupGuid];
            groupGame.game.HandleMove(move);
            string gameJson = JsonSerializer.Serialize<Game>(groupGame.game);
            await Clients.Group(groupGuid).SendAsync("ReceiveUpdateGame", gameJson);
        }
        public async Task HandlePromotion (string groupGuid, Promotion promotion)
        {
            ServerGame groupGame = ServerGames[groupGuid];
            groupGame.game.HandlePromotion(promotion);
            string gameJson = JsonSerializer.Serialize<Game>(groupGame.game);
            await Clients.Group(groupGuid).SendAsync("ReceiveUpdateGame", gameJson);
        }
    }
}
