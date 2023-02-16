namespace BlazorServerChess.Data.ChessGame
{
    public class Move
    {
        public int StartingTileId { get; set; }
        public int EndingTileId { get; set; }
        public PieceEnum Piece { get; set; }
    }
}
