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
        }

        public WordGuess(bool isGoodGuess, string word) : base(isGoodGuess)
        {
            Word = word;
        }
    }
}
