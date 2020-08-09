using Shared.DTOs;
using System.Collections.Generic;

namespace Shared.Models
{
    public class HangmanGame : Game
    {

        public List<Guess> Guesses { get; set; }
        public string Word { get; set; }

        public HangmanGame()
        {
            Guesses = new List<Guess>();
            Word = "";
        }

        public HangmanGame(Passenger player, GamePair gamePair) : base(player, gamePair)
        {
            Guesses = new List<Guess>();
            Word = "";
        }


        //word word pas achteraf ingesteld
        public void SetWord(string word)
        {
            Word = word;
            UpdateStatus();
        }

        public override GameDTO CreateDTO()
        {
            return new HangmanGameDTO(this);
        }
    }
}
