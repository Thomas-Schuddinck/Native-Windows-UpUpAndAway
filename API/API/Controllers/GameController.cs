﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService GameService;

        public GameController(IGameService gameService)
        {
            GameService = gameService;
        }

        [HttpGet("{passengerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GameDTO>> GetByUser(int passengerId)
        {
            return Ok(GameService.GetByUser(passengerId).Select(g => g.CreateDTO()).ToList());
        }

        [HttpGet("hangman/{gameId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<HangmanGameDTO> GetHangmanById(int gameId)
        {
            return Ok(new SimpleHangmanDTO(GameService.GetHangmanById(gameId)));

        }


        /// <summary>
        /// Updates a Hangman game.
        /// </summary>
        /// <param name="dto">DTO containing the new data</param>
        /// <returns>ActionResult</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateHangmanGame([FromBody] SimpleHangmanDTO dto)
        {

            return Ok(GameService.UpdateHangman(dto));

        }
        /// <summary>
        /// Sets the word for a hangmangame.
        /// </summary>
        /// <param name="dto">DTO containing the new data</param>
        /// <returns>ActionResult</returns>
        [HttpPut("word/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult SetWordForHangmanGame([FromBody] HangmanWordDTO dto)
        {
            try
            {
                return Ok(GameService.SetWordForGame(dto));
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> Post([FromBody] NewGameDTO dto)
        {
            return Ok(GameService.CreateGame(dto));
        }
    }
}