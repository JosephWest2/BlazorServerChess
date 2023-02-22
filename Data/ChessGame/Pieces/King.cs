namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class King : Piece
	{
		public King(Game game, ColorEnum color, int tileIndex) : base(game, color, tileIndex)
		{
			PieceType = PieceEnum.King;
		}

		public override HashSet<int> GetControlledSquares()
		{
			HashSet<int> moves = new HashSet<int>();

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

		public override HashSet<int> GetMoves()
		{
			HashSet<int> moves = new HashSet<int>();
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

			if (CanCastleKingSide())
			{
				moves.Add(TileId - 2);
			}
			if (CanCastleQueenSide())
			{
				moves.Add(TileId + 2);
			}

			return moves;
		}

		private bool CanCastleKingSide()
		{
			if (HasMoved)
			{
				return false;
			}
			int[] kingSideDifference = { 1, 2 };
			IPiece? kingSideRook = _game.Board[TileId - 3];

			foreach (int i in kingSideDifference)
			{
				if (_game.Board[TileId - i] is not null)
				{
					return false;
				}
			}
			if (kingSideRook is not null && kingSideRook.PieceType == PieceEnum.Rook && !kingSideRook.HasMoved)
			{
				return true;
			}
			return false;
			
		}
		private bool CanCastleQueenSide()
		{
			if (HasMoved)
			{
				return false;
			}
			int[] queenSideDifference = { 1, 2, 3 };
			IPiece? queenSideRook = _game.Board[TileId + 4];

			foreach (int i in queenSideDifference)
			{
				if (_game.Board[TileId + i] is not null)
				{
					return false;
				}
			}
			if (queenSideRook is not null && queenSideRook.PieceType == PieceEnum.Rook && !queenSideRook.HasMoved)
			{
				return true;
			}
			return false;

		}
		public void Castle(Move move)
		{
			if (move.EndingTileId == TileId - 2)
			{
				IPiece rook = _game.Board[TileId - 3];
				rook.MoveToSquare(TileId - 1);
				MoveToSquare(TileId - 2);
			}
			else
			{
				IPiece rook = _game.Board[TileId + 4];
				rook.MoveToSquare(TileId + 1);
				MoveToSquare(TileId + 2);
			}
		}
	}
}
