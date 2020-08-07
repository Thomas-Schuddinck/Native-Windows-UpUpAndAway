using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {

        private readonly ISongService songService;

        public SongController(ISongService oserv)
        {
            songService = oserv;
        }

        // GET api/values
        //[HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            return Ok(songService.GetAll().Select(s => new SongDTO(s)).ToList());
        }
    }
}