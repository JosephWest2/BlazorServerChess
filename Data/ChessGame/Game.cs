using BlazorServerChess.Components;
using BlazorServerChess.Data.ChessGame.Pieces;

namespace BlazorServerChess.Data.ChessGame
{
	public class Game
	{
		public List<IPiece?> Board { get; set; }
		public HashSet<IPiece> Pieces { get; set; }
		public bool PlayerIsWhite { get; set; }
		public bool IsWhiteTurn { get; set; }
		public Game()
		{
			InitializeBoard();
			IsWhiteTurn = true;
		}

		private void InitializeBoard()
		{
			Board = new List<IPiece>();
			Board.Add(new Rook(this, ColorEnum.White, 0));
			Board.Add(new Knight(this, ColorEnum.White, 1));
			Board.Add(new Bishop(this, ColorEnum.White, 2));
			Board.Add(new Queen(this, ColorEnum.White, 3));
			Board.Add(new King(this, ColorEnum.White, 4));
			Board.Add(new Bishop(this, ColorEnum.White, 5));
			Board.Add(new Knight(this, ColorEnum.White, 6));
			Board.Add(new Rook(this, ColorEnum.White, 7));
			for (int i = 8; i < 16; i++)
			{
				Board.Add(new Pawn(this, ColorEnum.White, i));
			}
			for (int i = 16; i < 48; i++)
			{
				Board.Add(null);
			}
			for (int i = 48; i < 56; i++)
			{
				Board.Add(new Pawn(this, ColorEnum.Black, i));
			}
			Board.Add(new Rook(this, ColorEnum.Black, 56));
			Board.Add(new Knight(this, ColorEnum.Black, 57));
			Board.Add(new Bishop(this, ColorEnum.Black, 58));
			Board.Add(new Queen(this, ColorEnum.Black, 59));
			Board.Add(new King(this, ColorEnum.Black, 60));
			Board.Add(new Bishop(this, ColorEnum.Black, 61));
			Board.Add(new Knight(this, ColorEnum.Black, 62));
			Board.Add(new Rook(this, ColorEnum.Black, 63));

			Pieces = new HashSet<IPiece>();
			foreach (var piece in Board)
			{
				if (piece is not null)
				{
					Pieces.Add(piece);
				}
			}
		}
		public HashSet<int> GetControlledSquares(ColorEnum color)
		{
			HashSet<int> result = new HashSet<int>();
			foreach (var piece in Pieces)
			{
				if (piece.Color == color)
				{
					result.UnionWith(piece.GetControlledSquares());
				}
			}
			return result;

		}
		public bool CheckKingDanger(ColorEnum color)
		{
			ColorEnum opposingColor = color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White;
			HashSet<int> opponentsControlledSquares = GetControlledSquares(opposingColor);
			return true;
			
		}
		public int GetKingIndex(ColorEnum color)
		{
			foreach (var piece in Pieces)
			{
				if (piece.GetType() == typeof(King) && piece.Color == color)
				{
					return piece.TileId;
				}
			}
			return -1;
		}

		public void HandleMove(Move move)
		{
			IPiece? movingPiece = Board[move.StartingTileId];
			if (movingPiece is null)
			{
				return;
			}
			movingPiece.MoveToSquare(move.EndingTileId);
		}
	}
}
