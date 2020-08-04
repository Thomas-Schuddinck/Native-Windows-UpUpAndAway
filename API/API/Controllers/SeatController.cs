using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<ICollection<Seat>> GetAll()
        {
            return new OkObjectResult(service.GetAll());
        }

    }
}
