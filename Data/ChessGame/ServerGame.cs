namespace BlazorServerChess.Data.ChessGame
{
	public class ServerGame
	{
		public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
		public Game game { get; set; }
        public string GroupGuid { get; set; }
        System.Timers.Timer _timer;

		public ServerGame()
		{
            PlayerOne = new Player();
            PlayerTwo = new Player();
            var rand = new Random();
            if (rand.NextDouble() < 0.5)
            {
                PlayerOne.Color = ColorEnum.White;
                PlayerTwo.Color = ColorEnum.Black;
            }
            else
            {
                PlayerOne.Color = ColorEnum.Black;
                PlayerTwo.Color = ColorEnum.White;
            }
            StartTimer();
        }
        public ServerGame(bool playerOneIsWhite)
        {
            PlayerOne = new Player();
            PlayerTwo = new Player();
            if (playerOneIsWhite)
            {
				PlayerOne.Color = ColorEnum.White;
				PlayerTwo.Color = ColorEnum.Black;
			}
            else
            {
				PlayerOne.Color = ColorEnum.Black;
				PlayerTwo.Color = ColorEnum.White;
			}
            StartTimer();
        }
        public ServerGame(string groupGuid)
        {
            PlayerOne = new Player();
            PlayerTwo = new Player();
            GroupGuid = groupGuid;
            var rand = new Random();
            if (rand.NextDouble() < 0.5)
            {
                PlayerOne.Color = ColorEnum.White;
                PlayerTwo.Color = ColorEnum.Black;
            }
            else
            {
                PlayerOne.Color = ColorEnum.Black;
                PlayerTwo.Color = ColorEnum.White;
            }
            StartTimer();
        }
        public bool TryAddPlayer(string userId, string ConnectionId, string username)
        {
            if (PlayerOne.Id is null)
            {
                PlayerOne.Id = userId;
                PlayerOne.ConnectionId = ConnectionId;
                PlayerOne.Username = username;

            }
            else if (PlayerTwo.Id is null)
            {
                PlayerTwo.Id = userId;
                PlayerTwo.ConnectionId = ConnectionId;
                PlayerTwo.Username = username;
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool GameisFull()
        {
            return PlayerOne.Id is not null && PlayerTwo.Id is not null ? true : false;
        }
        public bool PlayerIsInGame(string userId)
        {
            return PlayerOne.Id == userId || PlayerTwo.Id == userId ? true : false;
        }
        public void UpdateConnectionId(string userId, string ConnectionId)
        {
            if (PlayerOne.Id == userId)
            {
                PlayerOne.ConnectionId = ConnectionId;
            }
            else if (PlayerTwo.Id == userId)
            {
                PlayerTwo.ConnectionId = ConnectionId;
            }
        }

        public bool ContainsOnePlayer()
        {
            if (PlayerOne.Id is not null && PlayerTwo.Id is null)
            {
                return true;
            }
            else if (PlayerTwo.Id is not null && PlayerOne.Id is null)
            {
                return true;
            }
            return false;
        }
        public bool ContainsNoPlayers()
        {
            if (PlayerOne.Id is null && PlayerTwo.Id is null)
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
