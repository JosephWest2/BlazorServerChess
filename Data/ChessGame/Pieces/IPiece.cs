namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public interface IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		public List<int> GetMoves();
		public List<int> GetControlledSquares();
		public bool HasMoved { get; set; }
		public PieceEnum PieceEnumValue { get; }
	}
}
