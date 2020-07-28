using API.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        private readonly IPassengerService passengerService;

        public PassengerController(IPassengerService pserv)
        {
            passengerService = pserv;
        }

        // GET api/values
        //[HttpGet]
        public ActionResult<IEnumerable<Passenger>> Get()
        {
            return Ok(passengerService.GetAll());
        }

        //GET api/values/5
        [HttpGet("{passengerId}")]
        public ActionResult<Passenger> GetByUser(int passengerId)
        {
            return Ok(new PassengerDTO(passengerService.GetPassenger(passengerId)));
        }
    }
}