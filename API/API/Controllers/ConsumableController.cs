using API.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumableController : ControllerBase
    {

        private readonly IConsumableService consumableService;

        public ConsumableController(IConsumableService oserv)
        {
            consumableService = oserv;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Consumable>> Get()
        {
            return Ok(consumableService.GetAll().Select(c => new ConsumableDTO(c)).ToList());
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateReductions([FromBody] ReductionChangeDTO dto)
        {
            Debug.WriteLine($"Timestamp is {dto.Timestamp}");
            if (consumableService.UpdateReductions(dto.Items))
                return Ok();
            return BadRequest();
        }
    }
}