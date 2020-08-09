using System;
using System.Collections.Generic;
using System.Text;
using Shared.Models;

namespace Shared.DTOs
{
    public class SimpleHangmanDTO
    {
        public int GameId { get; set; }

        public ICollection<Guess> Guesses { get; set; }
    }
}
