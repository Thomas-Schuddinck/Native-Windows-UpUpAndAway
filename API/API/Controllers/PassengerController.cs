using API.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Passenger>> Get()
        {
            return Ok(passengerService.GetAll());
        }

        //GET api/values/5
        [HttpGet("{passengerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Passenger> GetByUser(int passengerId)
        {
            var pass = passengerService.GetPassenger(passengerId);
            var party = passengerService.GetPartyOfPassenger(passengerId);
            return Ok(new PassengerDTO(passengerService.GetPassenger(passengerId)) { PartyID = party.PassengerPartyId });
        }

        [HttpGet("login/{seatnr}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Passenger> LoginUser(int seatnr)
        {
            Seat s = passengerService.GetPassengerBySeatnumber(seatnr);
            return Ok(new PassengerDTO(s == null ? null : passengerService.GetPassengerBySeatnumber(seatnr).Passenger));
        }

        

        //GET api/values/5
        [HttpGet("party/{passengerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> GetParty(int passengerId)
        {
            PassengerParty p = passengerService.GetParty(passengerId);
            if (p == null)
                return null;
            return passengerService.GetParty(passengerId).PassengerPartyId;
        }
        //GET api/values/5
        [HttpGet("partymembers/{passengerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Passenger>> GetPartyMembers(int passengerId)
        {
            PassengerParty p = passengerService.GetParty(passengerId);
            if (p == null)
                return null;
            return Ok(passengerService.GetPartyMembers(p.PassengerPartyId, passengerId).Select(p => new PassengerDTO(p)).ToList());
        }
    }
}