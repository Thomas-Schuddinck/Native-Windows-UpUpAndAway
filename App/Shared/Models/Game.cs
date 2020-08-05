using Shared.Enums;
using System;

namespace Shared.Models
{
    public abstract class Game
    {
        public int GameId { get; set; }
        public Passenger Player { get; private set; }
        public GameStatus GameStatus { get; private set; }
        public PlayerStatus PlayerStatus { get; set; }

        protected Game()
        {
        }

        protected Game(Passenger player)
        {
            Player = player;
            GameStatus = GameStatus.Created;
            PlayerStatus = PlayerStatus.Unfinished;
        }

        protected void UpdateStatus()
        {
            if(GameStatus != GameStatus.Finished)
                GameStatus += 1;
            throw new InvalidOperationException("Game is already finished");
        }

    }
}
