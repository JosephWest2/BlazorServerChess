namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Rook : Piece
	{
		public Rook(Game game, ColorEnum color, int tileIndex) : base(game, color, tileIndex)
		{
			PieceType = PieceEnum.Rook;
		}

		public override HashSet<int> GetControlledSquares()
		{
			HashSet<int> result = new HashSet<int>();
			int i = TileId - 8;
			while (i >= 0)
			{
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					result.Add(i);
					break;
				}
				i -= 8;
			}
			i = TileId + 8;
			while (i < 64)
			{
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					result.Add(i);
					break;
				}
				i += 8;
			}
			int di = 1;
			while (TileId % 8 - di >= 0)
			{
				i = TileId - di;
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					result.Add(i);
					break;
				}
				di += 1;
			}
			di = 1;
			while (TileId % 8 + di <= 7)
			{
				i = TileId + di;
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					result.Add(i);
					break;
				}
				di += 1;
			}
			return result;
		}

		public override HashSet<int> GetMoves()
		{
			HashSet<int> result = new HashSet<int>();
			int i = TileId - 8;
			while (i >= 0)
			{
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					if (_game.Board[i].Color != Color)
					{
						result.Add(i);
					}
					break;
				}
				i -= 8;
			}
			i = TileId + 8;
			while (i < 64)
			{
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					if (_game.Board[i].Color != Color)
					{
						result.Add(i);
					}
					break;
				}
				i += 8;
			}
			int di = 1;
			while (TileId % 8 - di >= 0)
			{
				i = TileId - di;
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					if (_game.Board[i].Color != Color)
					{
						result.Add(i);
					}
					break;
				}
				di += 1;
			}
			di = 1;
			while (TileId % 8 + di <= 7)
			{
				i = TileId + di;
				if (_game.Board[i] == null)
				{
					result.Add(i);
				}
				else
				{
					if (_game.Board[i].Color != Color)
					{
						result.Add(i);
					}
					break;
				}
				di += 1;
			}

			return result;
		}
	}
}
