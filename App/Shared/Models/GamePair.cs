
using Shared.Enums;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class GamePair
    {
        public int GamePairId { get; set; }
        public Game Game1 { get; set; }
        public Game Game2 { get; set; }
        public Passenger Winner { get; set; }
        public GameType GameType { get; set; }
        public bool IsDraw { get; set; }
        [NotMapped]
        public IWinnerCalculator WinnerCalculator { get; set; }
        [NotMapped]
        public GameFactory GameFactory { get; set; }
        [NotMapped]
        public bool GamesFinished => Game1.GameStatus == Enums.GameStatus.Finished && Game2.GameStatus == Enums.GameStatus.Finished;

        public GamePair()
        {
        }

        public GamePair(GameType gameType, IWinnerCalculator winnerCalculator, Passenger passenger1, Passenger passenger2)
        {
            GameType = gameType;
            WinnerCalculator = winnerCalculator;
            DetermineGameFactory();
            var games = GameFactory.CreateGamePair(passenger1, passenger2);
            Game1 = games[0];
            Game2 = games[1];
        }

        public void DetermineWinner()
        {
            if (GamesFinished)
            {
                Winner = WinnerCalculator.DetermineWinner(Game1, Game2);
                if (Winner == null)
                    IsDraw = true;
            }  
        }
        public void DetermineGameFactory()
        {
            if (GameType == GameType.HangMan)
                GameFactory = new HangmanGameFactory();
        }
    }
}
