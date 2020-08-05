using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Guess
    {
        public int GuessId { get; set; }
        public char Letter { get; private set; }

        public Guess()
        {
        }

        public Guess(char letter)
        {
            Letter = letter;
        }
    }
}
