using BlazorServerChess.Components;
using BlazorServerChess.Data.ChessGame.Pieces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazorServerChess.Data.ChessGame
{
	public class Game
	{
		public List<IPiece?> Board { get; set; }
		public HashSet<IPiece> Pieces { get; set; }
		public ColorEnum CurrentTurnColor { get; set; }
		public bool KingInCheck { get; set; }
		public bool CheckMate { get; set; }
		public bool TimeOut { get; set; }
		public Move LastMove { get; set; }
		public ColorEnum VictoryColor { get; set; }
		public int WhiteSeconds { get; set; }
		public int BlackSeconds { get; set; }

		public Game()
		{
			InitializeBoard();
			WhiteSeconds = 1 * 10;
			BlackSeconds = 1 * 10;
			CurrentTurnColor = ColorEnum.White;
		}


		private void InitializeBoard()
		{
			Board = new List<IPiece>();
			Board.Add(new Rook(this, ColorEnum.White, 0));
			Board.Add(new Knight(this, ColorEnum.White, 1));
			Board.Add(new Bishop(this, ColorEnum.White, 2));
			Board.Add(new King(this, ColorEnum.White, 3));
			Board.Add(new Queen(this, ColorEnum.White, 4));
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
			Board.Add(new King(this, ColorEnum.Black, 59));
			Board.Add(new Queen(this, ColorEnum.Black, 60));
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
		public bool KingIsInDanger(ColorEnum color)
		{
			ColorEnum opposingColor = color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White;
			HashSet<int> opponentsControlledSquares = GetControlledSquares(opposingColor);

			IPiece? king = null;
			foreach (var piece in Pieces)
			{
				if (piece.Color == color && piece.PieceType == PieceEnum.King)
				{
					king = piece;
				}
			}
			
			if (opponentsControlledSquares.Contains(king.TileId))
			{
				return true;
			}
			return false;
		}
		public bool KingIsCheckmated(ColorEnum color)
		{
			ColorEnum opposingColor = color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White;
			IPiece[] pieceArray = new IPiece[Pieces.Count];
			Pieces.CopyTo(pieceArray);
			foreach (var piece in pieceArray)
			{
				if (piece.Color == color && piece.GetSafeMoves().Count != 0)
				{
					return false;
				}
			}
			return true;
		}
		public bool MoveIsSafe(Move move)
		{
			IPiece movingPiece = Board[move.StartingTileId];
			IPiece? capturedPiece = Board[move.EndingTileId];
			Board[move.StartingTileId] = null;
			Board[move.EndingTileId] = movingPiece;

			movingPiece.TileId = move.EndingTileId;
			Pieces.Remove(capturedPiece);


			bool result = true;
			if (KingIsInDanger(movingPiece.Color))
			{
				result = false;
			}

			if (capturedPiece != null)
			{
				Pieces.Add(capturedPiece);
			}
			movingPiece.TileId = move.StartingTileId;

			Board[move.StartingTileId] = movingPiece;
			Board[move.EndingTileId] = capturedPiece;

			return result;

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

			if (PieceIsCastling(move, movingPiece))
			{
				King castlingKing = (King)movingPiece;
				castlingKing.Castle(move);
			}
			else
			{
				movingPiece.MoveToSquare(move.EndingTileId);
			}

			CurrentTurnColor = movingPiece.Color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White;
			if (KingIsInDanger(CurrentTurnColor))
			{
				KingInCheck = true;
				if (KingIsCheckmated(CurrentTurnColor))
				{
					CheckMate = true;
					VictoryColor = movingPiece.Color;
				}
			}
			else
			{
				KingInCheck = false;
			}
			LastMove = move;
		}

		private bool PieceIsCastling(Move move, IPiece movingPiece)
		{
			if (movingPiece.PieceType == PieceEnum.King && move.EndingTileId == movingPiece.TileId -2 || move.EndingTileId == movingPiece.TileId + 2)
			{
				return true;
			}
			return false;
		}

		public void CopyGame(Game game)
		{
			Board = new List<IPiece?>();
			foreach (var piece in game.Board)
			{
				Board.Add(piece);
			}
			Pieces = new HashSet<IPiece>();
			foreach (var piece in game.Pieces)
			{
				Pieces.Add(piece);
			}
			CurrentTurnColor = game.CurrentTurnColor;
			KingInCheck = game.KingInCheck;
			CheckMate = game.CheckMate;
			LastMove = game.LastMove;
			VictoryColor = game.VictoryColor;
		}
	}
}
