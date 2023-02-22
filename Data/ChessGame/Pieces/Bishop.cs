namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Bishop : Piece
	{
		public Bishop(Game game, ColorEnum color, int tileIndex) : base(game, color, tileIndex)
		{
			PieceType = PieceEnum.Bishop;
		}

		public override HashSet<int> GetControlledSquares()
		{
			HashSet<int> result = new HashSet<int>();
			int x = TileId % 8 - 1;
			int y = TileId / 8 - 1;
			int current = TileId - 9;
			while (x >= 0 && y >= 0)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					result.Add(current);
					break;
				}
				current -= 9;
				x--;
				y--;
			}
			x = TileId % 8 + 1;
			y = TileId / 8 - 1;
			current = TileId - 7;
			while (x <= 7 && y >= 0)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					result.Add(current);
					break;
				}
				current -= 7;
				x++;
				y--;
			}
			x = TileId % 8 + 1;
			y = TileId / 8 + 1;
			current = TileId + 9;
			while (x <= 7 && y <= 7)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					result.Add(current);
					break;
				}
				current += 9;
				x++;
				y++;
			}
			x = TileId % 8 - 1;
			y = TileId / 8 + 1;
			current = TileId + 7;
			while (x <= 7 && y <= 7)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					result.Add(current);
					break;
				}
				current += 7;
				x--;
				y++;
			}
			return result;
		}

		public override HashSet<int> GetMoves()
		{
			HashSet<int> result = new HashSet<int>();
			int x = TileId % 8 - 1;
			int y = TileId / 8 - 1;
			int current = TileId - 9;
			while (x >= 0 && y >= 0)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					if (_game.Board[current].Color != Color)
					{
						result.Add(current);
					}
					break;
				}
				current -= 9;
				x--;
				y--;
			}
			x = TileId % 8 + 1;
			y = TileId / 8 - 1;
			current = TileId - 7;
			while (x <= 7 && y >= 0)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					if (_game.Board[current].Color != Color)
					{
						result.Add(current);
					}
					break;
				}
				current -= 7;
				x++;
				y--;
			}
			x = TileId % 8 + 1;
			y = TileId / 8 + 1;
			current = TileId + 9;
			while (x <= 7 && y <= 7)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					if (_game.Board[current].Color != Color)
					{
						result.Add(current);
					}
					break;
				}
				current += 9;
				x++;
				y++;
			}
			x = TileId % 8 - 1;
			y = TileId / 8 + 1;
			current = TileId + 7;
			while (x <= 7 && y <= 7)
			{
				if (_game.Board[current] == null)
				{
					result.Add(current);
				}
				else
				{
					if (_game.Board[current].Color != Color)
					{
						result.Add(current);
					}
					break;
				}
				current += 7;
				x--;
				y++;
			}
			return result;
			
		}
	}
}
