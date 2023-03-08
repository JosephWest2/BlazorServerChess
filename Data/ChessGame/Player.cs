namespace BlazorServerChess.Data.ChessGame
{
    public class Player
    {
        public string? Id { get; set; }
        public string? ConnectionId { get; set; }
        public string? Username { get; set; }
        public ColorEnum? Color { get; set; }
    }
}
