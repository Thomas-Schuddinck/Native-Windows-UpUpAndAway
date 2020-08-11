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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            set
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
            set
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
            set
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
            RefreshGames();
            
        }

        #region API Methods
        private async void GetPartyMembersFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(String.Format("http://localhost:5000/api/Passenger/partymembers/{0}", LoginSingleton.passenger.PassengerId)));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<PassengerDTO>>(json);
            lst.ToList().ForEach(i => PartyMembers.Add(new Passenger(i)));
        }

        private async void GetGamesFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(String.Format("http://localhost:5000/api/Game/{0}", LoginSingleton.passenger.PassengerId)));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<GameDTO>>(json);
            lst.ToList().ForEach(i => AddGame(i.ToDisplayGame()));
        }

        private async void SendNewGameToAPI(NewGameDTO newGameDTO)
        {
            var game = JsonConvert.SerializeObject(newGameDTO);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:5000/api/Game", new StringContent(game, System.Text.Encoding.UTF8, "application/json"));
            RefreshGames();
        }

        private async void SendHangmanWordToAPI(HangmanWordDTO wordDTO)
        {
            var game = JsonConvert.SerializeObject(wordDTO);
            HttpClient client = new HttpClient();
            var res = await client.PutAsync("http://localhost:5000/api/Game/word", new StringContent(game, System.Text.Encoding.UTF8, "application/json"));
            RefreshGames();
        }
        #endregion

        #region Support Data Methods
        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void RefreshGames()
        {
            CreatedGames = new ObservableCollection<DisplayGame>();
            StartedGames = new ObservableCollection<DisplayGame>();
            FinishedGames = new ObservableCollection<DisplayGame>();
            GetGamesFromAPI();
        }

        private void AddGame(DisplayGame displayGame)
        {
            if (displayGame.GameStatus == GameStatus.Created)
                CreatedGames.Add(displayGame);
            else if (displayGame.GameStatus == GameStatus.Started)
                StartedGames.Add(displayGame);
            else
                FinishedGames.Add(displayGame);
        }
        #endregion

        #region DTO Creators
        private NewGameDTO CreateGameDTO(GameType gameType, Passenger opponent)
        {
            return new NewGameDTO(LoginSingleton.passenger.PassengerId, opponent.PassengerId, gameType);
        }

        private HangmanWordDTO CreateWordDTO(int gameId, string word)
        {
            return new HangmanWordDTO(gameId, word);
        } 
        #endregion

        public void SetWordForGame(int gameId, string word)
        {
            SendHangmanWordToAPI(CreateWordDTO(gameId, word));
        }

        public void CreateGame(GameType gameType, Passenger opponent)
        {
            SendNewGameToAPI(CreateGameDTO(gameType, opponent));
        }

    }
}
