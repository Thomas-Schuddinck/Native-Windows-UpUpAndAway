using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.IServices
{
    public interface IGameService
    {
        /// <summary>
        /// Create a new gamepair and 2 new games.
        /// </summary>
        /// <param name="newGameDTO">DTO with info for new gamepair and games</param>
        /// <returns>True if successful</returns>
        bool CreateGame(NewGameDTO newGameDTO);

        /// <summary>
        /// Set word for HangmanGame.
        /// </summary>
        /// <param name="hangmanWord">DTO with info for the word of the game</param>
        /// <returns>True if successful</returns>
        bool SetWordForGame(HangmanWordDTO hangmanWordDTO);

        /// <summary>
        /// Update a game
        /// </summary>
        /// <param name="game">The game to be updated</param>
        /// <returns>True if successful</returns>
        bool UpdateGame(Game game);

        /// <summary>
        /// Returns game for given id
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <returns>The requested game. returns null if not found</returns>
        Game GetById(int gameId);

        /// <summary>
        /// Updates a Hangman game
        /// </summary>
        /// <param name="dto">new Data</param>
        /// <returns>True if successful</returns>
        bool UpdateHangman(SimpleHangmanDTO dto);

        /// <summary>
        /// Returns all the Games of a single Passanger
        /// </summary>
        /// <param name="passengerId">ID of the Passenger</param>
        /// <returns>List of Games for the given Passenger. Empty List of none found.</returns>
        ICollection<Game> GetByUser(int passengerId);

    }
}
