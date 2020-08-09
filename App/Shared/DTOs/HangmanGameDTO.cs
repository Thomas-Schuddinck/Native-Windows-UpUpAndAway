using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.Enums;
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

        public HangmanGameDTO() : base()
        {
            Guesses = new List<Guess>();
        }

        public HangmanGameDTO(HangmanGame hangmanGame) : base(hangmanGame)
        {
            Guesses = hangmanGame.Guesses;
            Word = hangmanGame.Word;
        }
        /*
        [JsonConstructor]
        public HangmanGameDTO(int gameId, PassengerDTO player, PassengerDTO opponent, GameStatus gameStatus, PlayerStatus playerStatus, GamePairDTO gamePair, GameType gameType)
        {
            Guesses = new List<Guess>();
        }
        */

        public override DisplayGame ToDisplayGame()
        {
            return new DisplayGame(this);
        }
    }
}
