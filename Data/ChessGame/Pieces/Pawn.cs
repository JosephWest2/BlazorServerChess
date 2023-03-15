namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Pawn : Piece
	{
		public Pawn(Game game, ColorEnum color, int tileIndex) : base(game, color, tileIndex)
		{
			PieceType = PieceEnum.Pawn;
		}
		public Pawn(string pieceJson) : base(pieceJson)
		{

		}

		public override HashSet<int> GetMoves()
		{
			HashSet<int> result = new HashSet<int>();
			if (Color == ColorEnum.Black)
			{
				if (TileId - 8 >= 0 && _game.Board[TileId - 8] == null)
				{
					result.Add(TileId - 8);
					if (TileId-16 >= 0 && HasMoved == false && _game.Board[TileId - 16] == null)
					{
						result.Add(TileId - 16);
					}
				}
				if (TileId % 8 > 0 && _game.Board[TileId - 9]?.Color != Color && _game.Board[TileId - 9] != null)
				{
					result.Add(TileId - 9);
				}
				if (TileId % 8 < 7 && _game.Board[TileId - 7]?.Color != Color && _game.Board[TileId - 7] != null)
				{
					result.Add(TileId - 7);
				}

				// enpassant
				if (TileId > 23 && TileId < 32)
				{
					if (_game.Board[TileId - 1]?.PieceType == PieceEnum.Pawn && _game.LastMove.EndingTileId == TileId - 1 && _game.Board[TileId - 1]?.Color != Color)
					{
						result.Add(TileId - 9);
					}
					else if (_game.Board[TileId + 1]?.PieceType == PieceEnum.Pawn && _game.LastMove.EndingTileId == TileId + 1 && _game.Board[TileId - 1]?.Color != Color)
					{
						result.Add(TileId - 7);
					}
				}
			}
			else
			{
				if (TileId + 8 < 64 && _game.Board[TileId + 8] == null)
				{
					result.Add(TileId + 8);
					if (TileId + 16 < 64 && HasMoved == false && _game.Board[TileId + 16] == null)
					{
						result.Add(TileId + 16);
					}
				}
				if (TileId % 8 > 0 && _game.Board[TileId + 7]?.Color != Color && _game.Board[TileId + 7] != null)
				{
					result.Add(TileId + 7);
				}
				if (TileId % 8 < 7 && _game.Board[TileId + 9]?.Color != Color && _game.Board[TileId + 9] != null)
				{
					result.Add(TileId + 9);
				}

				// enpassant

				if (TileId > 31 && TileId < 40)
				{
					if (_game.Board[TileId - 1]?.PieceType == PieceEnum.Pawn && _game.LastMove.EndingTileId == TileId - 1 && _game.Board[TileId - 1]?.Color != Color)
					{
						result.Add(TileId + 7);
					}
					else if (_game.Board[TileId + 1]?.PieceType == PieceEnum.Pawn && _game.LastMove.EndingTileId == TileId + 1 && _game.Board[TileId - 1]?.Color != Color)
					{
						result.Add(TileId + 9);
					}
				}
			}
			return result;
		}

		public override HashSet<int> GetControlledSquares()
		{
			HashSet<int> result = new HashSet<int>();
			if (Color == ColorEnum.Black)
			{
				if (TileId % 8 > 0)
				{
					result.Add(TileId - 9);
				}
				if (TileId % 8 < 7)
				{
					result.Add(TileId - 7);
				}
			}
			else
			{
				if (TileId % 8 > 0)
				{
					result.Add(TileId + 9);
				}
				if (TileId % 8 < 7)
				{
					result.Add(TileId + 7);
				}
			}
			return result;
		}

		public static bool IsEnpassanting(Move move, Game game)
		{
			if (game.Board[move.EndingTileId] == null && move.EndingTileId != move.EndingTileId + 8 || game.Board[move.EndingTileId] == null && move.EndingTileId != move.EndingTileId - 8)
			{
				return true;
			}
			return false;
		}
	}
}
