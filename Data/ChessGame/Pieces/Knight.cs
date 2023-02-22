namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Knight : Piece
	{
		public Knight(Game game, ColorEnum color, int tileIndex) : base(game, color, tileIndex)
		{
			PieceType = PieceEnum.Knight;
		}

		public override HashSet<int> GetControlledSquares()
		{
			HashSet<int> moves = new HashSet<int>();

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

		public override HashSet<int> GetMoves()
		{
			HashSet<int> moves = new HashSet<int>();

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
					if (_game.Board[newPosition] == null)
					{
						moves.Add(newPosition);
					}
					else if (_game.Board[newPosition].Color != Color)
					{
						moves.Add(newPosition);
					}
				}
			}

			return moves;

		}
	}
}
