using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    public class HangmanGameViewModel : INotifyPropertyChanged
    {
        private DisplayHangmanGame _hangmanGame;
        private string _hangmanImage;

        public DisplayHangmanGame HangmanGame
        {
            get
            {
                return _hangmanGame;
            }
            set
            {
                _hangmanGame = value;
                RaisePropertyChanged(nameof(HangmanGame));

            }
        }
        public string HangmanImage
        {
            get
            {
                return _hangmanImage;
            }
            set
            {
                _hangmanImage = value;
                RaisePropertyChanged(nameof(HangmanImage));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public HangmanGameViewModel(DisplayGame displayGame)
        {
            GetHangmanGameFromAPI(displayGame.GameId);
        }

        private async void GetHangmanGameFromAPI(int id)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(String.Format("http://localhost:5000/api/Game/hangman/{0}", id)));
            var game = JsonConvert.DeserializeObject<HangmanGameDTO>(json);
            HangmanGame = new DisplayHangmanGame(game);
        }


        public void AddWordGuess(string word)
        {
            HangmanGame.GuessWord(word);
            DetermineImageSrc();
        }

        public void AddCharGuess(char letter)
        {
            HangmanGame.GuessLetter(letter);
            DetermineImageSrc();
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void DetermineImageSrc()
        {
            HangmanImage = string.Format("ms-appx:///Assets/Hangman/Galgje_{0}.png", CalculateTurn().ToString("00"));
        }
        private int CalculateTurn()
        {
            return HangmanGame.AllGuesses.Count(g => !g.IsGoodGuess);
        }
    }
}
