using System;
using System.Collections.Generic;
using System.Text;
using Shared.Models;

namespace Shared.DTOs
{
    public class SimpleHangmanDTO
    {
        public int GameId { get; set; }

        public string Word { get; set; }

        public ICollection<Guess> Guesses { get; set; }

        public bool IsReady { get; set; }

        public SimpleHangmanDTO(HangmanGame hangmanGame)
        {
            GameId = hangmanGame.GameId;
            Word = hangmanGame.Word;
            Guesses = hangmanGame.Guesses;
            IsReady = hangmanGame.IsReady;
        }
    }
}
