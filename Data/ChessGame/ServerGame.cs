namespace BlazorServerChess.Data.ChessGame
{
	public class ServerGame
	{
		public string PlayerOneId { get; set; }
        public string PlayerOneConnectionId { get; set; }
        public string PlayerOneUsername { get; set; }
		public ColorEnum PlayerOneColor { get; }
		public string PlayerTwoId { get; set; }
        public string PlayertwoConnectionId { get; set; }
        public string PlayerTwoUsername { get; set; }
		public ColorEnum PlayerTwoColor { get; }
		public Game game { get; set; }
        public string GroupGuid { get; set; }
        System.Timers.Timer _timer;

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
            StartTimer();
        }
        public ServerGame(bool playerOneIsWhite)
        {
            if (playerOneIsWhite)
            {
				PlayerOneColor = ColorEnum.White;
				PlayerTwoColor = ColorEnum.Black;
			}
            else
            {
				PlayerOneColor = ColorEnum.Black;
				PlayerTwoColor = ColorEnum.White;
			}
            StartTimer();
        }
        public ServerGame(string groupGuid)
        {
            GroupGuid = groupGuid;
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
            StartTimer();
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

        public bool ContainsOnePlayer()
        {
            if (PlayerOneId is not null && PlayerTwoId is null)
            {
                return true;
            }
            else if (PlayerTwoId is not null && PlayerOneId is null)
            {
                return true;
            }
            return false;
        }
        public bool ContainsNoPlayers()
        {
            if (PlayerOneId is null && PlayerTwoId is null)
            {
                return true;
            }
            return false;
        }
        public void StartTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {

            if (game is null || game.LastMove is null)
            {
                return;
            }
            if (game.CurrentTurnColor == ColorEnum.White)
            {
                game.WhiteSeconds -= 1;
            }
            else
            {
                game.BlackSeconds -= 1;
            }
            if (game.WhiteSeconds == 0)
            {
                game.TimeOut = true;
                game.VictoryColor = ColorEnum.Black;
                _timer.Dispose();
            }
            if (game.BlackSeconds == 0)
            {
                game.TimeOut = true;
                game.VictoryColor = ColorEnum.White;
                _timer.Dispose();
            }
        }
    }
}
