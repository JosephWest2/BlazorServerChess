namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Queen : Piece
	{
		public Queen(Game game, ColorEnum color, int tileIndex) : base(game, color, tileIndex)
		{
			PieceType = PieceEnum.Queen;
		}
		public Queen(string pieceJson) : base(pieceJson)
		{

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
			while (i <= 64)
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
			while (x >= 0 && y <= 7)
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
			while (i <= 64)
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
			while (x >= 0 && y <= 7)
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
