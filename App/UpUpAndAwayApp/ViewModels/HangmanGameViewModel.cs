﻿using Namotion.Reflection;
using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace UpUpAndAwayApp.ViewModels
{
    public class HangmanGameViewModel : INotifyPropertyChanged
    {
        private DisplayHangmanGame _hangmanGame;
        private ImageSource _hangmanImage;
        private List<Char> _availableLetters;

        public List<Char> AvailableChars
        {
            get
            {
                return _availableLetters;
            }
            set
            {
                _availableLetters = value;
                RaisePropertyChanged(nameof(AvailableChars));

            }
        }
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
        public ImageSource HangmanImage
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
            var game = JsonConvert.DeserializeObject<SimpleHangmanDTO>(json);
            HangmanGame = new DisplayHangmanGame(game);
            DetermineImageSrc();
            ConfigAvailableChars();
        }


        public void AddWordGuess(string word)
        {
            HangmanGame.GuessWord(word);
            DetermineImageSrc();
        }

        public void AddCharGuess(char letter)
        {
            AvailableChars.Remove(letter);
            HangmanGame.GuessLetter(letter);
            DetermineImageSrc();
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void DetermineImageSrc()
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(string.Format("ms-appx:///Assets/Hangman/Galgje_{0}.png", CalculateTurn().ToString("00")));
            HangmanImage = bitmapImage;

        }
        private int CalculateTurn()
        {
            return HangmanGame.AllGuesses.Count(g => !g.IsGoodGuess);
        }

        private void ConfigAvailableChars()
        {
            AvailableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
            foreach (CharGuess g in HangmanGame.BadGuesses)
                AvailableChars.Remove(g.Letter);
            foreach (CharGuess g in HangmanGame.GoodGuesses)
                AvailableChars.Remove(g.Letter);

        }
    }
}
