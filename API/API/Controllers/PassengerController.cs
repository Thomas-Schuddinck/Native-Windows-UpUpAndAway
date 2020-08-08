using API.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

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

        //GET api/values/5
        [HttpGet("party/{passengerId}")]
        public ActionResult<int> GetParty(int passengerId)
        {
            PassengerParty p = passengerService.GetParty(passengerId);
            if (p == null)
                return null;
            return passengerService.GetParty(passengerId).PassengerPartyId;
        }
        //GET api/values/5
        [HttpGet("partymembers/{passengerId}")]
        public ActionResult<IEnumerable<Passenger>> GetPartyMembers(int passengerId)
        {
            PassengerParty p = passengerService.GetParty(passengerId);
            if (p == null)
                return null;
            return Ok(passengerService.GetPartyMembers(p.PassengerPartyId, passengerId).Select(p => new PassengerDTO(p)).ToList());
        }
    }
}