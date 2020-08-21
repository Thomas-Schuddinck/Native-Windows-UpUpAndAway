using Shared.DTOs;
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
        public bool IsReady { get; set; }

        protected Game()
        {
        }

        protected Game(Passenger player, GamePair gamePair)
        {
            Player = player;
            GameStatus = GameStatus.Created;
            IsReady = false;
            PlayerStatus = PlayerStatus.Unfinished;
            GamePair = gamePair;
        }

        public void UpdateGameStatus()
        {
            if(GameStatus != GameStatus.Finished)
            {
                ChangeIsReady();
                GameStatus += 1;
                if (GameStatus == GameStatus.Finished)
                    IsReady = false;
                    GamePair.UpdateWaitingStatus();
            }
        }
        public void UpdateWaitingStatus() 
        {
            ChangeIsReady();
            GamePair.UpdateWaitingStatus();
        }

        public void ChangeIsReady()
        {
            IsReady = !IsReady;
        }

        public abstract GameDTO CreateDTO();

        public abstract void Evaluate();

    }
}
