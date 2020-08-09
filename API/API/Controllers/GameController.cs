using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IServices;
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
        public ActionResult<IEnumerable<GameDTO>> GetByUser(int passengerId)
        {
            return Ok(GameService.GetByUser(passengerId).Select(g => g.CreateDTO()).ToList());
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] NewGameDTO dto)
        {
            return Ok(GameService.CreateGame(dto));
        }
    }
}