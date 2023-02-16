namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class King : IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		public bool HasMoved { get; set; }
		private readonly Game _game;
		public King(Game game)
		{
			_game = game;
			HasMoved = false;
		}

		public List<int> GetControlledSquares()
		{
			List<int> moves = new List<int>();

			// Define the possible moves for a King
			int[] rowOffsets = { -1, -1, -1, 0, 0, 1, 1, 1 };
			int[] colOffsets = { -1, 0, 1, -1, 1, -1, 0, 1 };

			// Calculate the row and column of the King's current position
			int row = TileId / 8;
			int col = TileId % 8;

			// Iterate through the possible moves and add them to the list if they are valid
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
			ColorEnum opposingColor = Color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White;
			HashSet<int> controlledSquares = _game.GetControlledSquares(opposingColor);

			// Define the possible moves for a King
			int[] rowOffsets = { -1, -1, -1, 0, 0, 1, 1, 1 };
			int[] colOffsets = { -1, 0, 1, -1, 1, -1, 0, 1 };

			// Calculate the row and column of the King's current position
			int row = TileId / 8;
			int col = TileId % 8;

			// Iterate through the possible moves and add them to the list if they are valid
			for (int i = 0; i < 8; i++)
			{
				int newRow = row + rowOffsets[i];
				int newCol = col + colOffsets[i];

				if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
				{
					int newPosition = newRow * 8 + newCol;
					if (controlledSquares.Contains(newPosition))
					{
						continue;
					}
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
