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
		public virtual HashSet<int> GetMoves()
		{
			return new HashSet<int>();
		}
		public virtual HashSet<int> GetControlledSquares()
		{
			return new HashSet<int>();
		}
		public HashSet<int> GetSafeMoves()
		{
			HashSet<int> result = new HashSet<int>();
			foreach (int endingPosition in GetMoves())
			{
				Move move = new Move()
				{
					StartingTileId = TileId,
					EndingTileId = endingPosition
				};
				if (_game.MoveIsSafe(move))
				{
					result.Add(endingPosition);
				}
			}
			return result;
		}
		
	}
}
