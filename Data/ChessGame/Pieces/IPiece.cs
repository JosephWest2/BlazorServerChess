namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public interface IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		public HashSet<int> GetMoves();
		public HashSet<int> GetControlledSquares();
		public HashSet<int> GetSafeMoves();
		public void MoveToSquare(int tileIndex);
		public bool HasMoved { get; set; }
		public PieceEnum PieceType { get; }
	}
}
