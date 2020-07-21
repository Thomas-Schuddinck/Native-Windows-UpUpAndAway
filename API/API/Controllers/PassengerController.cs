using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IServices;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            if (passengerService.GetPassenger(passengerId) == null)
                return new Passenger("test","test");
            return Ok(passengerService.GetPassenger(passengerId));
        }
    }
}