using Shared.DTOs;
using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shared.DisplayModels
{
    public class DisplayGame : INotifyPropertyChanged
    {
        private string _displayMessage;
        private GameType _gameType;
        private Passenger _opponent;
        private bool _isWaiting;

        public int GameId { get; set; }
        public bool IsReady
        {
            get
            {
                return _isWaiting;
            }
            set
            {
                _isWaiting = value;
                NotifyPropertyChanged(nameof(IsReady));
                NotifyPropertyChanged(nameof(DisplayMessage));
                NotifyPropertyChanged(nameof(ButtonVisible));
            }
        }
        public string DisplayMessage
        {
            get
            {
                return _displayMessage;
            }
            private set
            {
                _displayMessage = value;
                NotifyPropertyChanged(nameof(DisplayMessage));
            }
        }
        public GameStatus GameStatus { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
        public GamePairDTO GamePairDTO { get; set; }
        public Passenger Opponent 
        {
            get
            {
                return _opponent;
            }
            set
            {
                _opponent = value;
                NotifyPropertyChanged(nameof(Opponent));
                NotifyPropertyChanged(nameof(DisplayOpponent));
                EvaluateDisplayMessage();
            }
        }
        public GameType GameType 
        {
            get
            {
                return _gameType;
            }
            set
            {
                _gameType = value;
                NotifyPropertyChanged(nameof(GameType));
                NotifyPropertyChanged(nameof(DisplayGameType));
                EvaluateDisplayMessage();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string DisplayGameType => GameType.ToString().ToUpper();
        public string DisplayOpponent => Opponent.FullName;
        public bool ButtonVisible => !IsReady;

        public DisplayGame(GameDTO gameDTO)
        {
            GameId = gameDTO.GameId;
            GameStatus = gameDTO.GameStatus;
            PlayerStatus = gameDTO.PlayerStatus;
            GamePairDTO = gameDTO.GamePair;
            Opponent = new Passenger(gameDTO.Opponent);
            IsReady = gameDTO.IsReady;
            EvaluateDisplayMessage();
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EvaluateDisplayMessage()
        {
            if (GamePairDTO.WaitingStatus == WaitingStatus.NoPlayersReady)
                DisplayMessage = "Waiting for both players";
            else if (GamePairDTO.WaitingStatus == WaitingStatus.OnePlayerReady)
                if(IsReady)
                    DisplayMessage = String.Format("Waiting for {0}", Opponent.FirstName);
                else
                    DisplayMessage = "Opponent is waiting for you";
            if (GamePairDTO.IsFinished)
            {
                if (GamePairDTO.Winner == null)
                    DisplayMessage = "Draw";
                else
                    DisplayMessage = String.Format("{0} Won!", new Passenger(GamePairDTO.Winner).FullName);
            }
        }

    }
}
