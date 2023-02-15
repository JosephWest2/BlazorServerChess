using BlazorServerChess.Data.ChessGame.Pieces;

namespace BlazorServerChess.Data.ChessGame
{
	public class Game
	{
		public List<PieceEnum> Board { get; set; }
		public List<IPiece> Pieces { get; set; }
		public Game()
		{
			InitializeBoard();
			InitializePieces();
		}

		private void InitializeBoard()
		{
			Board = new List<PieceEnum>();
			Board.Add(PieceEnum.WhiteRook);
			Board.Add(PieceEnum.WhiteKnight);
			Board.Add(PieceEnum.WhiteBishop);
			Board.Add(PieceEnum.WhiteQueen);
			Board.Add(PieceEnum.WhiteKing);
			Board.Add(PieceEnum.WhiteBishop);
			Board.Add(PieceEnum.WhiteKnight);
			Board.Add(PieceEnum.WhiteKnight);
			for (int i = 0; i < 8; i++)
			{
				Board.Add(PieceEnum.WhitePawn);
			}
			for (int i = 0; i < 32; i++)
			{
				Board.Add(PieceEnum.None);
			}
			for (int i = 0; i < 8; i++)
			{
				Board.Add(PieceEnum.BlackPawn);
			}
			Board.Add(PieceEnum.BlackRook);
			Board.Add(PieceEnum.BlackKnight);
			Board.Add(PieceEnum.BlackBishop);
			Board.Add(PieceEnum.BlackQueen);
			Board.Add(PieceEnum.BlackKing);
			Board.Add(PieceEnum.BlackBishop);
			Board.Add(PieceEnum.BlackKnight);
			Board.Add(PieceEnum.BlackRook);
		}
		private void InitializePieces()
		{
			Pieces = new List<IPiece>();
			for (int i=0; i<8; i++)
			{
				Pieces.Add(new Pawn(this)
				{
					Color = ColorEnum.White,
					TileId = i + 8
				});
				Pieces.Add(new Pawn(this)
				{
					Color = ColorEnum.Black,
					TileId = 56 - i
				});
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
	}
}
