using Shared.Enums;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Models
{
    public class HangmanWinnerCalculator : IWinnerCalculator
    {
        public Passenger DetermineWinner(Game game1, Game game2)
        {
            HangmanGame game11 = (HangmanGame)game1;
            HangmanGame game21 = (HangmanGame)game2;
            List<Guess> badGuesses1 = game11.Guesses.Where(g => g.IsGoodGuess == false).ToList();
            List<Guess> badGuesses2 = game21.Guesses.Where(g => g.IsGoodGuess == false).ToList();
            if (badGuesses1.Count > badGuesses2.Count)
            {
                game1.PlayerStatus = PlayerStatus.Lost;
                game2.PlayerStatus = PlayerStatus.Won;
                return game21.Player;            }
                
            if (badGuesses1.Count < badGuesses2.Count)
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
