namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Pawn : Piece
	{
		public Pawn(Game game, ColorEnum color, int tileIndex) : base(game, color, tileIndex)
		{
			PieceType = PieceEnum.Pawn;
		}

		public override List<int> GetMoves()
		{
			List<int> result = new List<int>();
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
				if (TileId % 8 > 0 && _game.Board[TileId - 9].Color != Color && _game.Board[TileId - 9] != null)
				{
					result.Add(TileId - 9);
				}
				if (TileId % 8 < 7 && _game.Board[TileId - 7].Color != Color && _game.Board[TileId - 7] != null)
				{
					result.Add(TileId - 7);
				}
			}
			else
			{
				if (TileId + 8 >= 0 && _game.Board[TileId + 8] == null)
				{
					result.Add(TileId + 8);
					if (TileId + 16 >= 0 && HasMoved == false && _game.Board[TileId + 16] == null)
					{
						result.Add(TileId + 16);
					}
				}
				if (TileId % 8 > 0 && _game.Board[TileId + 9].Color != Color && _game.Board[TileId + 9] != null)
				{
					result.Add(TileId + 9);
				}
				if (TileId % 8 < 7 && _game.Board[TileId + 7].Color != Color && _game.Board[TileId + 7] != null)
				{
					result.Add(TileId + 7);
				}
			}
			return result;
		}

		public override List<int> GetControlledSquares()
		{
			List<int> result = new List<int>();
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
	}
}
