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
        public GameStatus GameStatus { get; private set; }
        public PlayerStatus PlayerStatus { get; private set; }
        public GamePairDTO GamePairDTO { get; private set; }
        public Passenger Opponent { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public DisplayGame(GameDTO gameDTO)
        {
            GameStatus = gameDTO.GameStatus;
            PlayerStatus = gameDTO.PlayerStatus;
            GamePairDTO = gameDTO.GamePair;
            Opponent = new Passenger(gameDTO.Opponent);
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
                DisplayMessage = "Waiting for one player";
            else if (GamePairDTO.IsFinished)
            {
                if (GamePairDTO.Winner == null)
                    DisplayMessage = "Draw";
                else
                    DisplayMessage = String.Format("{0} Won!", new Passenger(GamePairDTO.Winner).FullName);
            }
        }

    }
}
