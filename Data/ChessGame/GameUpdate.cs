namespace BlazorServerChess.Data.ChessGame
{
	public class GameUpdate
	{
		public bool IsWhiteTurn { get; set; }
		public List<PieceEnum> Board { get; set; }
	}
}
