using Shared.Enums;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class HangmanWinnerCalculator : IWinnerCalculator
    {
        public Passenger DetermineWinner(Game game1, Game game2)
        {
            var game11 = (HangmanGame)game1;
            var game21 = (HangmanGame)game2;
            if (game11.Guesses.Count > game21.Guesses.Count)
            {
                game1.PlayerStatus = PlayerStatus.Lost;
                game2.PlayerStatus = PlayerStatus.Won;
                return game21.Player;            }
                
            if (game11.Guesses.Count < game21.Guesses.Count)
            {
                game1.PlayerStatus = PlayerStatus.Won;
                game2.PlayerStatus = PlayerStatus.Lost;
                return game11.Player;
            }
            game1.PlayerStatus = PlayerStatus.Draw;
            game2.PlayerStatus = PlayerStatus.Draw;
            return null;
        }
    }
}
