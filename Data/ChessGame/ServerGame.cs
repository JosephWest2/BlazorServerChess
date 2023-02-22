namespace BlazorServerChess.Data.ChessGame
{
	public class ServerGame
	{
		public string PlayerOneId { get; }
		public ColorEnum PlayerOneColor { get; }
		public string PlayerTwoId { get; }
		public ColorEnum PlayerTwoColor { get; }

		public ServerGame(string playerOneId, string playerTwoId)
		{
			PlayerOneId = playerOneId;
			PlayerTwoId = playerTwoId;
			var rand = new Random();
			if (rand.NextDouble() < 0.5)
			{
				PlayerOneColor = ColorEnum.White;
				PlayerTwoColor = ColorEnum.Black;
			}
			else
			{
				PlayerOneColor = ColorEnum.Black;
				PlayerTwoColor = ColorEnum.White;
			}
		}
	}
}
