﻿using BlazorServerChess.Components;
using BlazorServerChess.Data.ChessGame;
using BlazorServerChess.Data.ChessGame.Pieces;
using Newtonsoft.Json.Linq;

namespace BlazorServerChess.Data
{
	public static class JsonHandler
	{
		public static ServerGame ServerGameFromJson(string json)
		{
			JObject jObject = JObject.Parse(json);

			ServerGame serverGame = new ServerGame();

			string playerOneJson = jObject["PlayerOne"].ToString();
			serverGame.PlayerOne = PlayerFromJson(playerOneJson);

			string playerTwoJson = jObject["PlayerTwo"].ToString();
			serverGame.PlayerTwo = PlayerFromJson(playerTwoJson);

			serverGame.GroupGuid = (string)jObject["GroupGuid"];

			string gameJson = jObject["game"].ToString();
			serverGame.game = GameFromJson(gameJson);
			return serverGame;
		}

		public static Player PlayerFromJson(string json)
		{
			Player player = new Player();
			JObject jObject = JObject.Parse(json);

			player.Id = (string)jObject["Id"];
			player.ConnectionId = (string)jObject["ConnectionId"];
			player.Username = (string)jObject["Username"];
			player.Color = (int)jObject["Color"] == 0 ? ColorEnum.White : ColorEnum.Black;

			return player;
		}

		public static Game GameFromJson(string json)
		{
			Game game = new Game();

			JObject jObject = JObject.Parse(json);
			game.CurrentTurnColor = (int)jObject["CurrentTurnColor"] == 0 ? ColorEnum.White : ColorEnum.Black;
			game.KingInCheck = (bool)jObject["KingInCheck"];
			game.CheckMate = (bool)jObject["CheckMate"];
			game.VictoryColor = (int)jObject["VictoryColor"] == 0 ? ColorEnum.White : ColorEnum.Black;
			game.WhiteSeconds = (int)jObject["WhiteSeconds"];
			game.BlackSeconds = (int)jObject["BlackSeconds"];
			game.TimeOut = (bool)jObject["TimeOut"];

			JToken moveJson = jObject["LastMove"];
			if (moveJson.HasValues)
			{
                Move move = new Move();
                move.StartingTileId = (int)moveJson["StartingTileId"];
                move.EndingTileId = (int)moveJson["EndingTileId"];
				game.LastMove = move;
            }
			

			var boardArrayJson = jObject["Board"];
			game.Board = new List<IPiece?>();
			game.Pieces = new HashSet<IPiece>();
			foreach (var piece in boardArrayJson)
			{
				if (piece.GetType() == typeof(JValue))
				{
					game.Board.Add(null);
				}
				else
				{
					string pieceJson = piece.ToString();
					IPiece newPiece = PieceFromJson(game, pieceJson);
					game.Board.Add(newPiece);
					game.Pieces.Add(newPiece);
				}
			}

			return game;
		}

		public static IPiece PieceFromJson(Game game, string json)
		{
			JObject jObject = JObject.Parse(json);
			int val = (int)jObject["PieceType"];
			ColorEnum pieceColor = (int)jObject["Color"] == 0 ? ColorEnum.White : ColorEnum.Black;
			int tileId = (int)jObject["TileId"];

			IPiece result = null;
			switch (val)
			{
				case 1:
					result = new King(game, pieceColor, tileId);
					break;
				case 2:
					result = new Queen(game, pieceColor, tileId);
					break;
				case 3:
					result = new Rook(game, pieceColor, tileId);
					break;
				case 4:
					result = new Bishop(game, pieceColor, tileId);
					break;
				case 5:
					result = new Knight(game, pieceColor, tileId);
					break;
				case 6:
					result = new Pawn(game, pieceColor, tileId);
					break;
			}
			result.HasMoved = (bool)jObject["HasMoved"];

			return result;
		}
	}
}
