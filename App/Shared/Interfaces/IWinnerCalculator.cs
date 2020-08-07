using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interfaces
{
    public interface IWinnerCalculator
    {
        Passenger DetermineWinner(Game game1, Game game2);
    }
}
