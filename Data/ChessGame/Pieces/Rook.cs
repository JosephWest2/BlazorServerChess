namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Rook : IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		public bool HasMoved { get; set; }
		public PieceEnum PieceEnumValue { get; }
		private readonly Game _game;
		public Rook(Game game, ColorEnum color)
		{
			Color = color;
			PieceEnumValue = color == ColorEnum.White ? PieceEnum.WhiteRook : PieceEnum.BlackRook;
			_game = game;
			HasMoved= false;
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
			
			return result;
		}
	}
}
