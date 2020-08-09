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

        public ObservableCollection<CharGuess> GoodGuesses { get; set; }
        public ObservableCollection<CharGuess> BadGuesses { get; set; }
        public ObservableCollection<WordGuess> FailedAttempts { get; set; }
        public ObservableCollection<Char> Alfabet { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public DisplayHangmanGame(HangmanGameDTO hangmanGameDTO)
        {
            Word = hangmanGameDTO.Word;

        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Public Methods
        public void FinishGame()
        {
            ShowWord();
        }

        public void GuessWord(string word)
        {
            if (EvaluateWord(word))
            {
                AddWordGuess(word, true);
                FinishGame();
            }                
            else
                AddWordGuess(word, false);
        }

        public void GuessLetter(char letter)
        {
            Alfabet.Remove(letter);
            AddCharGuess(new CharGuess(Array.IndexOf(Word.ToCharArray(), letter) == -1, letter));
        } 
        #endregion

        #region Private Methods
        private void AddWordGuess(string word, bool isGoodGuess)
        {
            AllGuesses.Add(new WordGuess(isGoodGuess, word));
            if(!isGoodGuess)
                FailedAttempts.Add(new WordGuess(isGoodGuess, word));
        }

        private void AddCharGuess(CharGuess guess)
        {
            AllGuesses.Add(guess);
            if (guess.IsGoodGuess)
            {
                var letterArr = Word.ToCharArray();
                GoodGuesses.Add(guess);
                for (int i = 0; i < letterArr.Length; i++)
                {
                    if (letterArr[i] == guess.Letter)
                        InsertLetter(guess.Letter, i);
                }
                if (EvaluateWord(EncodedWord))
                    FinishGame();
            }
            else
            {
                BadGuesses.Add(guess);
            }
        }

        private void InsertLetter(char letter, int index)
        {
            StringBuilder sb = new StringBuilder(EncodedWord);
            sb[index] = letter;
            EncodedWord = sb.ToString();
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
