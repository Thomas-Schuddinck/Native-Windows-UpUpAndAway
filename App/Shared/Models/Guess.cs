using Newtonsoft.Json;
using Shared.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    [JsonConverter(typeof(GuessConverter))]
    public abstract class Guess
    {
        public int GuessId { get; set; }
        public bool IsGoodGuess { get; set; }
        public bool IsLetter { get; set; }

        public Guess()
        {
        }

        protected Guess(bool isGoodGuess)
        {
            IsGoodGuess = isGoodGuess;
        }
    }
}
