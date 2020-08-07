using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public abstract class Guess
    {
        public int GuessId { get; set; }
        public bool IsGoodGuess { get; private set; }

        protected Guess()
        {
        }

        protected Guess(bool isGoodGuess)
        {
            IsGoodGuess = isGoodGuess;
        }
    }
}
