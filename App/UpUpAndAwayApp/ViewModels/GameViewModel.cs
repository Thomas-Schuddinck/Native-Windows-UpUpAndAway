using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.DisplayModels.Singleton;
using Shared.DTOs;
using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
        private List<Passenger> _partyMembers;

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
        public List<Passenger> PartyMembers
        {
            get
            {
                return _partyMembers;
            }
            set
            {
                _partyMembers = value;
                RaisePropertyChanged(nameof(PartyMembers));
            }
        }
        public List<GameType> GameTypes { get; } = Enum.GetValues(typeof(GameType)).Cast<GameType>().ToList();

        public GameViewModel()
        {
            PartyMembers = new List<Passenger>();
            GetPartyMembersFromAPI();
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void GetPartyMembersFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(String.Format("http://localhost:5000/api/Passenger/partymembers/{0}", LoginSingleton.passenger.PassengerId)));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<PassengerDTO>>(json);
            lst.ToList().ForEach(i => PartyMembers.Add(new Passenger(i)));
        }
    }
}
