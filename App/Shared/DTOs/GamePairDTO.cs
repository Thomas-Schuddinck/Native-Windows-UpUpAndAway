using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class GamePairDTO
    {
        public PassengerDTO Winner { get; set; }
        public GameType GameType { get; set; }
        public WaitingStatus WaitingStatus { get; set; }
        public bool IsDraw { get; set; }
        public bool IsFinished { get; set; }
        
        public GamePairDTO()
        {

        }

        public GamePairDTO(GamePair gamePair)
        {
            Winner = gamePair.Winner == null ? null : new PassengerDTO(gamePair.Winner);
            GameType = gamePair.GameType;
            WaitingStatus = gamePair.WaitingStatus;
            IsDraw = gamePair.IsDraw;
            IsFinished = gamePair.GamesFinished;
        }

    }
}
