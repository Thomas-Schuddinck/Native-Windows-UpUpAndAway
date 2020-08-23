using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class HangmanWordDTO
    {

        public int GameId { get; set; }

        public string Word { get; set; }

        public HangmanWordDTO()
        {

        }

        public HangmanWordDTO(int gameId, string word)
        {
            GameId = gameId;
            Word = word;
        }
    }
}
