using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public abstract class GameDTO
    {
        public int GameId { get; set; }
        public PassengerDTO Player { get; private set; }
        public PassengerDTO Opponent { get; private set; }
        public GameStatus GameStatus { get; private set; }
        public PlayerStatus PlayerStatus { get; set; }
        public GamePairDTO GamePair { get; private set; }

        protected GameDTO(Game game)
        {
            GameId = game.GameId;
            Player = new PassengerDTO(game.Player);
            GameStatus = game.GameStatus;
            PlayerStatus = game.PlayerStatus;
            GamePair = new GamePairDTO(game.GamePair);
            Opponent = new PassengerDTO(game.GamePair.Game1.GameId == GameId ? game.GamePair.Game2.Player : game.GamePair.Game1.Player); 
        }
    }
}
