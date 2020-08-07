using Shared.DisplayModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<DisplayGame> _createdGames;
        private ObservableCollection<DisplayGame> _startedGames;
        private ObservableCollection<DisplayGame> _finishedGames;

        public ObservableCollection<DisplayGame> CreatedGames
        {
            get
            {
                return _createdGames;
            }
            private set
            {
                _createdGames = value;
                RaisePropertyChanged(nameof(CreatedGames));
            }
        }
        public ObservableCollection<DisplayGame> StartedGames
        {
            get
            {
                return _startedGames;
            }
            private set
            {
                _startedGames = value;
                RaisePropertyChanged(nameof(StartedGames));
            }
        }
        public ObservableCollection<DisplayGame> FinishedGames
        {
            get
            {
                return _finishedGames;
            }
            private set
            {
                _finishedGames = value;
                RaisePropertyChanged(nameof(FinishedGames));
            }
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
