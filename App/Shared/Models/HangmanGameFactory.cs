using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class HangmanGameFactory : GameFactory
    {
        public override List<Game> CreateGamePair(Passenger passenger1, Passenger passenger2)
        {
            return new List<Game>() { new HangmanGame(passenger1), new HangmanGame(passenger2) };
        }
    }
}
