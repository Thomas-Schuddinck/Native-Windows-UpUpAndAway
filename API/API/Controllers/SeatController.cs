using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {

        private readonly ISeatService service;

        public SeatController(ISeatService ser)
        {
            service = ser;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ICollection<Seat>> GetAll()
        {
            return new OkObjectResult(service.GetAll());
        }

        [HttpGet("{passengerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> GetByPassenger(int passengerid)
        {
            return new OkObjectResult(new SeatDTO(service.GetByPassenger(passengerid)));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Seat>> SwapSeats([FromBody] SeatSwapDTO dto)
        {
            if (service.SwapSeats(dto.First, dto.Second))
                return Ok(service.GetAll());
            return NotFound();
        }

    }
}
