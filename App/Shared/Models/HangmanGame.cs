﻿using Shared.DTOs;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Models
{
    public class HangmanGame : Game
    {

        public List<Guess> Guesses { get; set; }
        public string Word { get; set; }

        public HangmanGame()
        {
            Guesses = new List<Guess>();
            Word = "";
        }

        public HangmanGame(Passenger player, GamePair gamePair) : base(player, gamePair)
        {
            Guesses = new List<Guess>();
            Word = "";
        }


        //word word pas achteraf ingesteld
        public void SetWord(string word)
        {
            HangmanGame game = (HangmanGame)(GamePair.FirstGame.GameId == GameId ? GamePair.SecondGame : GamePair.FirstGame);
            game.Word = word;
            UpdateWaitingStatus();
        }

        public override GameDTO CreateDTO()
        {
            return new HangmanGameDTO(this);
        }

        private bool CheckIfGuessed()
        {
            return CorrectCharGuess() || CorrectWordGuess();
        }

        private bool CorrectWordGuess()
        {
            return Guesses.Any(g => g is WordGuess && ((WordGuess)g).IsGoodGuess);
        }

        private bool CorrectCharGuess()
        {
            return Guesses.Count(g => g is CharGuess && ((CharGuess)g).IsGoodGuess) == Word.Distinct().Count();
        }


        public override void Evaluate()
        {
            if (CheckIfGuessed() && !IsReady)
                if(this.GameStatus != GameStatus.Finished)
                    UpdateWaitingStatus();
        }

        public void UpdateGuesses(List<Guess> list)
        {
            foreach (Guess g in list)
                if (!CheckAlreadyInside(g))
                    Guesses.Add(g);
        }

        private bool CheckAlreadyInside(Guess g)
        {
            foreach(Guess guess in Guesses)
            {
                if (g is WordGuess && guess is WordGuess)
                {
                    if ((g as WordGuess).Word == (guess as WordGuess).Word)
                        return true;
                }
                else
                {
                    if (g is CharGuess && guess is CharGuess)
                        if ((g as CharGuess).Letter == (guess as CharGuess).Letter)
                            return true;
                }

            }
            return false;

        }
    }
}
