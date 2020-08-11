
using Shared.Enums;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class GamePair
    {
        public int GamePairId { get; set; }
        public Game FirstGame { get; set; }
        public Game SecondGame { get; set; }
        public int FirstGameId { get; set; }
        public int SecondGameId { get; set; }
        public Passenger Winner { get; set; }
        public GameType GameType { get; set; }
        public WaitingStatus WaitingStatus { get; set; }
        public bool IsDraw { get; set; }
        [NotMapped]
        public IWinnerCalculator WinnerCalculator { get; set; }
        [NotMapped]
        public GameFactory GameFactory { get; set; }
        [NotMapped]
        public bool GamesFinished =>  (FirstGame.GameStatus == Enums.GameStatus.Finished && SecondGame.GameStatus == Enums.GameStatus.Finished);

        public GamePair()
        {
        }

        public GamePair(GameType gameType, Passenger passenger1, Passenger passenger2)
        {
            GameType = gameType;
            DetermineGameFactory();
            DetermineWinnerCalculator();
            var games = GameFactory.CreateGamePair(passenger1, passenger2, this);
            FirstGame = games[0];
            FirstGameId = FirstGame.GameId;
            SecondGame = games[1];
            SecondGameId = SecondGame.GameId;
            ResetWaitingStatus();
        }

        public void SetGamePairForGames()
        {
            FirstGame.GamePair = this;
            SecondGame.GamePair = this;
        }

        public void DetermineWinner()
        {
            if (GamesFinished)
            {
                Winner = WinnerCalculator.DetermineWinner(FirstGame, SecondGame);
                if (Winner == null)
                    IsDraw = true;
            }  
        }
        public void UpdateWaitingStatus()
        {
            WaitingStatus++;
            if(WaitingStatus == WaitingStatus.BothPlayersReady)
            {
                UpdateBothGameStatus();
            }
        }

        private void ResetWaitingStatus()
        {
            WaitingStatus = WaitingStatus.NoPlayersReady;
        }

        public void UpdateBothGameStatus()
        {
            FirstGame.UpdateGameStatus();
            SecondGame.UpdateGameStatus();
        }
        public void DetermineGameFactory()
        {
            if (GameType == GameType.HangMan)
                GameFactory = new HangmanGameFactory();
        }
        public void DetermineWinnerCalculator()
        {
            if (GameType == GameType.HangMan)
                WinnerCalculator = new HangmanWinnerCalculator();
        }
    }
}
