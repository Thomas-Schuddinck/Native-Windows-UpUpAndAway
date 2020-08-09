using Shared.Enums;
using System;

namespace Shared.Models
{
    public abstract class Game
    {
        public int GameId { get; set; }
        public Passenger Player { get;set; }
        public GameStatus GameStatus { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
        public GamePair GamePair { get; set; }

        protected Game()
        {
        }

        protected Game(Passenger player, GamePair gamePair)
        {
            Player = player;
            GameStatus = GameStatus.Created;
            PlayerStatus = PlayerStatus.Unfinished;
            GamePair = gamePair;
        }

        public void UpdateStatus()
        {
            if(GameStatus != GameStatus.Finished)
            {
                GameStatus += 1;
                if (GameStatus == GameStatus.Finished)
                    GamePair.UpdateWaitingStatus();
            }                
            else
                throw new InvalidOperationException("Game is already finished");
        }

    }
}
