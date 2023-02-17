namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Knight : IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		public bool HasMoved { get; set; }
		public PieceEnum PieceEnumValue { get; }
		private readonly Game _game;
		public Knight(Game game, ColorEnum color)
		{
			Color = color;
			PieceEnumValue = color == ColorEnum.White ? PieceEnum.WhiteKnight : PieceEnum.BlackKnight;
			_game = game;
			HasMoved= false;
		}

		public List<int> GetControlledSquares()
		{
			List<int> moves = new List<int>();

			int[] rowOffsets = { -2, -1, 1, 2, 2, 1, -1, -2 };
			int[] colOffsets = { 1, 2, 2, 1, -1, -2, -2, -1 };

			int row = TileId / 8;
			int col = TileId % 8;

			for (int i = 0; i < 8; i++)
			{
				int newRow = row + rowOffsets[i];
				int newCol = col + colOffsets[i];

				if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
				{
					int newPosition = newRow * 8 + newCol;
					moves.Add(newPosition);
				}
			}

			return moves;
		}

		public List<int> GetMoves()
		{
			List<int> moves = new List<int>();

			int[] rowOffsets = { -2, -1, 1, 2, 2, 1, -1, -2 };
			int[] colOffsets = { 1, 2, 2, 1, -1, -2, -2, -1 };

			int row = TileId / 8;
			int col = TileId % 8;

			for (int i = 0; i < 8; i++)
			{
				int newRow = row + rowOffsets[i];
				int newCol = col + colOffsets[i];

				if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
				{
					int newPosition = newRow * 8 + newCol;
					if (_game.Board[newPosition] == PieceEnum.None)
					{
						moves.Add(newPosition);
					}
					else if ((int)_game.Board[newPosition] >= 7 && Color == ColorEnum.White)
					{
						moves.Add(newPosition);
					}
					else if ((int)_game.Board[newPosition] <= 6 && Color == ColorEnum.Black)
					{
						moves.Add(newPosition);
					}
				}
			}

			return moves;

		}
	}
}
