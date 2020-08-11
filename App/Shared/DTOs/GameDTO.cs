using Newtonsoft.Json;
using Shared.Converters;
using Shared.DisplayModels;
using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    [JsonConverter(typeof(GameConverter))]
    public abstract class GameDTO
    {
        public int GameId { get; set; }
        public PassengerDTO Player { get; set; }
        public PassengerDTO Opponent { get; set; }
        public GameStatus GameStatus { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
        public GamePairDTO GamePair { get; set; }
        public GameType GameType { get; set; }
        public bool IsReady { get; set; }

        protected GameDTO()
        {

        }

        protected GameDTO(Game game)
        {
            GameId = game.GameId;
            Player = new PassengerDTO(game.Player);
            GameStatus = game.GameStatus;
            PlayerStatus = game.PlayerStatus;
            GamePair = new GamePairDTO(game.GamePair);
            Opponent = new PassengerDTO(game.GamePair.FirstGame.GameId == GameId ? game.GamePair.SecondGame.Player : game.GamePair.FirstGame.Player);
            GameType = game.GamePair.GameType;
            IsReady = game.IsReady;
        }

        public abstract DisplayGame ToDisplayGame();
    }
}
