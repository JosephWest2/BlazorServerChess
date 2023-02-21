using System.Xml.Linq;

namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public abstract class Piece : IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		public bool HasMoved { get; set; }
		public PieceEnum PieceType { get; set; }
		protected readonly Game _game;
		protected Piece(Game game, ColorEnum color, int tileIndex)
		{
			TileId = tileIndex;
			Color = color;
			_game = game;
			HasMoved = false;
		}
		public virtual void MoveToSquare(int tileIndex)
		{
			_game.Board[TileId] = null;
			TileId = tileIndex;
			HasMoved = true;
			if (_game.Board[tileIndex] != null)
			{
				IPiece capturedPiece = _game.Board[tileIndex];
				_game.Pieces.Remove(capturedPiece);
			}
			_game.Board[tileIndex] = this;
			
		}
		public virtual List<int> GetMoves()
		{
			return new List<int>();
		}
		public virtual List<int> GetControlledSquares()
		{
			return new List<int>();
		}
	}
}
