using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class HangmanGameDTO : GameDTO
    {
        public List<Guess> Guesses { get; set; }
        public string Word { get; private set; }

        public HangmanGameDTO(HangmanGame hangmanGame) : base(hangmanGame)
        {
            Guesses = hangmanGame.Guesses;
            Word = hangmanGame.Word;
        } 
    }
}
