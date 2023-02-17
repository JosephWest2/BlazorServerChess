namespace BlazorServerChess.Data.ChessGame.Pieces
{
	public class Pawn : IPiece
	{
		public ColorEnum Color { get; set; }
		public int TileId { get; set; }
		public bool HasMoved { get; set; }
		public PieceEnum PieceEnumValue { get; }
		private readonly Game _game;
		public Pawn(Game game, ColorEnum color)
		{
			Color = color;
			PieceEnumValue = color == ColorEnum.White ? PieceEnum.WhitePawn : PieceEnum.BlackPawn;
			_game = game;
			HasMoved= false;
		}

		public List<int> GetMoves()
		{
			List<int> result = new List<int>();
			if (Color == ColorEnum.Black)
			{
				if (TileId - 8 >= 0 && _game.Board[TileId - 8] == PieceEnum.None)
				{
					result.Add(TileId - 8);
					if (TileId-16 >= 0 && HasMoved == false && _game.Board[TileId - 16] == PieceEnum.None)
					{
						result.Add(TileId - 16);
					}
				}
				if (TileId % 8 > 0 && (int)_game.Board[TileId - 9] <=6 && _game.Board[TileId - 9] != PieceEnum.None)
				{
					result.Add(TileId - 9);
				}
				if (TileId % 8 < 7 && (int)_game.Board[TileId - 7] <= 6 && _game.Board[TileId - 7] != PieceEnum.None)
				{
					result.Add(TileId - 7);
				}
			}
			else
			{
				if (TileId + 8 >= 0 && _game.Board[TileId + 8] == PieceEnum.None)
				{
					result.Add(TileId + 8);
					if (TileId + 16 >= 0 && HasMoved == false && _game.Board[TileId + 16] == PieceEnum.None)
					{
						result.Add(TileId + 16);
					}
				}
				if (TileId % 8 > 0 && (int)_game.Board[TileId + 9] <= 6 && _game.Board[TileId + 9] != PieceEnum.None)
				{
					result.Add(TileId + 9);
				}
				if (TileId % 8 < 7 && (int)_game.Board[TileId + 7] <= 6 && _game.Board[TileId + 7] != PieceEnum.None)
				{
					result.Add(TileId + 7);
				}
			}
			return result;
		}

		public List<int> GetControlledSquares()
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
