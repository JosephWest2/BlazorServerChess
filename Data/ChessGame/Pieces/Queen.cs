namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Queen : IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		private readonly Game _game;
		public Queen(Game game)
		{
			_game = game;
		}

		public List<int> GetControlledSquares()
		{
			List<int> result = new List<int>();
			if (Color == ColorEnum.White)
			{
				int i = TileId - 8;
				while (i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
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
					if (_game.Board[i] == PieceEnum.None)
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
				i = TileId % 8 - 1;
				while (TileId % 8 - i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId - i);
					}
					else
					{
						result.Add(i);
						break;
					}
					i -= 1;
				}
				i = TileId % 8 + 1;
				while (TileId % 8 + i <= 7)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId + i);
					}
					else
					{
						result.Add(i);
						break;
					}
				}
			}
			else if (Color == ColorEnum.Black)
			{
				int i = TileId - 8;
				while (i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
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
					if (_game.Board[i] == PieceEnum.None)
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
				i = TileId % 8 - 1;
				while (TileId % 8 - i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId - i);
					}
					else
					{
						result.Add(i);
						break;
					}
					i -= 1;
				}
				i = TileId % 8 + 1;
				while (TileId % 8 + i <= 7)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId + i);
					}
					else
					{
						result.Add(i);
						break;
					}
				}
			}
			if (Color == ColorEnum.White)
			{
				int x = TileId % 8 - 1;
				int y = TileId / 8 - 1;
				int current = TileId - 9;
				while (x >= 0 && y >= 0)
				{
					if (_game.Board[current] == PieceEnum.None)
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
					if (_game.Board[current] == PieceEnum.None)
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
					if (_game.Board[current] == PieceEnum.None)
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
					if (_game.Board[current] == PieceEnum.None)
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
			}
			else if (Color == ColorEnum.Black)
			{
				int x = TileId % 8 - 1;
				int y = TileId / 8 - 1;
				int current = TileId - 9;
				while (x >= 0 && y >= 0)
				{
					if (_game.Board[current] == PieceEnum.None)
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
					if (_game.Board[current] == PieceEnum.None)
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
					if (_game.Board[current] == PieceEnum.None)
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
					if (_game.Board[current] == PieceEnum.None)
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

			}
			return result;
		}

		public List<int> GetMoves()
		{
			List<int> result = new List<int>();
			if (Color == ColorEnum.White)
			{
				int i = TileId - 8;
				while (i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(i);
					}
					else
					{
						if ((int)_game.Board[i] >= 7)
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
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(i);
					}
					else
					{
						if ((int)_game.Board[i] >= 7)
						{
							result.Add(i);
						}
						break;
					}
					i += 8;
				}
				i = TileId % 8 - 1;
				while (TileId % 8 - i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId - i);
					}
					else
					{
						if ((int)_game.Board[TileId - i] >= 7)
						{
							result.Add(i);
						}
						break;
					}
					i -= 1;
				}
				i = TileId % 8 + 1;
				while (TileId % 8 + i <= 7)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId + i);
					}
					else
					{
						if ((int)_game.Board[TileId + i] >= 7)
						{
							result.Add(i);
						}
						break;
					}
				}
			}
			else if (Color == ColorEnum.Black)
			{
				int i = TileId - 8;
				while (i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(i);
					}
					else
					{
						if ((int)_game.Board[i] <= 6)
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
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(i);
					}
					else
					{
						if ((int)_game.Board[i] <= 6)
						{
							result.Add(i);
						}
						break;
					}
					i += 8;
				}
				i = TileId % 8 - 1;
				while (TileId % 8 - i >= 0)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId - i);
					}
					else
					{
						if ((int)_game.Board[TileId - i] <= 6)
						{
							result.Add(i);
						}
						break;
					}
					i -= 1;
				}
				i = TileId % 8 + 1;
				while (TileId % 8 + i <= 7)
				{
					if (_game.Board[i] == PieceEnum.None)
					{
						result.Add(TileId + i);
					}
					else
					{
						if ((int)_game.Board[TileId + i] <= 6)
						{
							result.Add(i);
						}
						break;
					}
				}
			}
			if (Color == ColorEnum.White)
			{
				int x = TileId % 8 - 1;
				int y = TileId / 8 - 1;
				int current = TileId - 9;
				while (x >= 0 && y >= 0)
				{
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] >= 7)
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
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] >= 7)
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
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] >= 7)
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
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] >= 7)
						{
							result.Add(current);
						}
						break;
					}
					current += 7;
					x--;
					y++;
				}
			}
			else if (Color == ColorEnum.Black)
			{
				int x = TileId % 8 - 1;
				int y = TileId / 8 - 1;
				int current = TileId - 9;
				while (x >= 0 && y >= 0)
				{
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] < 7)
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
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] < 7)
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
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] < 7)
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
					if (_game.Board[current] == PieceEnum.None)
					{
						result.Add(current);
					}
					else
					{
						if ((int)_game.Board[current] < 7)
						{
							result.Add(current);
						}
						break;
					}
					current += 7;
					x--;
					y++;
				}
			}
			return result;
		}
	}
}
