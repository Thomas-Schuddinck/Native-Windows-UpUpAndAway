using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class CharGuess : Guess
    {
        public char Letter { get; set; }

        public CharGuess()
        {
        }

        public CharGuess(bool isGoodGuess, char letter) : base(isGoodGuess)
        {
            Letter = letter;
        }
    }
}
