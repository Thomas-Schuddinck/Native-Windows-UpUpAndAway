using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public abstract class GameFactory
    {
        public abstract List<Game> CreateGamePair(Passenger passenger1, Passenger passenger2, GamePair gamePair);
    }
}
