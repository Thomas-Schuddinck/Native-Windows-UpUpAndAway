using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Shared.DisplayModels
{
    public class DisplayHangmanGame : INotifyPropertyChanged
    {
        private string _encodedWord;

        public int GameId { get; set; }
        public ObservableCollection<CharGuess> GoodGuesses { get; set; }
        public ObservableCollection<CharGuess> BadGuesses { get; set; }
        public ObservableCollection<WordGuess> FailedAttempts { get; set; }
        public List<Guess> AllGuesses { get; set; }
        public string Word { get; set; }
        public string EncodedWord
        {
            get
            {
                return _encodedWord;
            }
            set
            {
                _encodedWord = value;
                NotifyPropertyChanged(nameof(EncodedWord));
            }
        }

        public string GoodGuessesConverter => GoodGuesses.Count == 0 ? "No correct letters yet" : string.Join(" - ", GoodGuesses.Select(g => g.Letter));
        public string BadGuessesConverter => BadGuesses.Count == 0 ? "No incorrect letters yet" : string.Join(" - ", BadGuesses.Select(g => g.Letter));
        public string FailedAttemptsConverter => FailedAttempts.Count == 0 ? "No failed attempts yet" : string.Join(" - ", FailedAttempts.Select(g => g.Word));
        public string LettersRemainingConverter => string.Format("{0} letters remaining", EncodedWord.Count(c => c == '_'));

        public bool IsFinished { get; set; }
        public bool WasWordGuessed { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public DisplayHangmanGame(SimpleHangmanDTO hangmanGameDTO)
        {
            GameId = hangmanGameDTO.GameId;
            Word = hangmanGameDTO.Word.ToUpper();
            SetupGuesses(hangmanGameDTO.Guesses.ToList());
            CreateEncodeWord();
        }

        private void CreateEncodeWord()
        {
            EncodedWord = Word;
            List<char> goodLetters = GoodGuesses.Select(g => g.Letter).ToList();
            foreach (char c in Word.Distinct())
                if (!goodLetters.Contains(c))
                    EncodedWord = EncodedWord.Replace(c, '_');
        }
        private void UpdateReadOnlyProperties()
        {
            NotifyPropertyChanged(nameof(GoodGuessesConverter));
            NotifyPropertyChanged(nameof(BadGuessesConverter));
            NotifyPropertyChanged(nameof(LettersRemainingConverter));
        }

        private void SetupGuesses(List<Guess> guesses)
        {
            AllGuesses = new List<Guess>();
            GoodGuesses = new ObservableCollection<CharGuess>();
            BadGuesses = new ObservableCollection<CharGuess>();
            FailedAttempts = new ObservableCollection<WordGuess>();
            foreach (Guess guess in guesses)
            {
                AllGuesses.Add(guess);
                if(guess is WordGuess)
                    FailedAttempts.Add((WordGuess)guess);
                else
                {
                    if (guess.IsGoodGuess)
                        GoodGuesses.Add((CharGuess)guess);
                    else
                        BadGuesses.Add((CharGuess)guess);
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Public Methods
        public void FinishGame(bool won)
        {
            IsFinished = true;
            WasWordGuessed = won;
            ShowWord();
        }

        private void EndGameIfLost()
        {
            if (AllGuesses.Count(g => !g.IsGoodGuess) >= 11)
                FinishGame(false);
        }

        public void GuessWord(string word)
        {
            if (EvaluateWord(word))
            {
                AddWordGuess(word, true);
                FinishGame(true);
            }                
            else
                AddWordGuess(word, false);
            NotifyPropertyChanged(nameof(FailedAttemptsConverter));
        }

        public void GuessLetter(char letter)
        {
            AddCharGuess(new CharGuess(Array.IndexOf(Word.ToCharArray(), letter) != -1, letter));
        } 
        #endregion

        #region Private Methods
        private void AddWordGuess(string word, bool isGoodGuess)
        {
            AllGuesses.Add(new WordGuess(isGoodGuess, word));
            if (!isGoodGuess)
            {
                FailedAttempts.Add(new WordGuess(isGoodGuess, word));
                EndGameIfLost();
            }
        }

        private void AddCharGuess(CharGuess guess)
        {
            AllGuesses.Add(guess);
            if (guess.IsGoodGuess)
            {
                GoodGuesses.Add(guess);
                CreateEncodeWord();
                if (EvaluateWord(EncodedWord))
                    FinishGame(true);
            }
            else
            {
                BadGuesses.Add(guess);
                EndGameIfLost();
            }
            UpdateReadOnlyProperties();
        }

        private void ShowWord()
        {
            EncodedWord = Word;
        }

        private bool EvaluateWord(string word)
        {
            return word.ToUpper().Equals(Word.ToUpper());
        }
        #endregion
    }
}
