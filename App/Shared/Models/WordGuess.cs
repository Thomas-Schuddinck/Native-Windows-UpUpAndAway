using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class WordGuess : Guess
    {
        public string Word { get; set; }

        public WordGuess()
        {
            IsLetter = false;
        }

        public WordGuess(bool isGoodGuess, string word) : base(isGoodGuess)
        {
            Word = word;
            IsLetter = false;
        }
    }
}
