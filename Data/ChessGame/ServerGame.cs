namespace BlazorServerChess.Data.ChessGame
{
	public class ServerGame
	{
		public string PlayerOneId { get; set; }
        public string PlayerOneConnectionId { get; set; }
		public ColorEnum PlayerOneColor { get; }
		public string PlayerTwoId { get; set; }
        public string PlayertwoConnectionId { get; set; }
		public ColorEnum PlayerTwoColor { get; }
		public Game game { get; set; }

		public ServerGame()
		{
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
        public bool TryAddPlayer(string userId, string ConnectionId)
        {
            if (PlayerOneId is null)
            {
                PlayerOneId = userId;
                PlayerOneConnectionId = ConnectionId;
            }
            else if (PlayerTwoId is null)
            {
                PlayerTwoId = userId;
                PlayertwoConnectionId = ConnectionId;
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool GameisFull()
        {
            return PlayerOneId is not null && PlayerTwoId is not null ? true : false;
        }
        public bool PlayerIsInGame(string userId)
        {
            return PlayerOneId == userId || PlayerTwoId == userId ? true : false;
        }
        public void UpdateConnectionId(string userId, string ConnectionId)
        {
            if (PlayerOneId == userId)
            {
                PlayerOneConnectionId = ConnectionId;
            }
            else if (PlayerTwoId == userId)
            {
                PlayertwoConnectionId = ConnectionId;
            }
        }
	}
}
