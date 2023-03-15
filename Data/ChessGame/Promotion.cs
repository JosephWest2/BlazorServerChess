namespace BlazorServerChess.Data.ChessGame
{
    public class Promotion
    {
        public int StartingTileId { get; set; }
        public int EndingTileId { get; set; }
        public PieceEnum promotionResult { get; set; }

    }
}
