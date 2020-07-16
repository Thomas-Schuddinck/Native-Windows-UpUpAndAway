using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;

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
        //[HttpGet]
        public ActionResult<IEnumerable<Consumable>> Get()
        {
            return Ok(consumableService.GetAll());
        }
    }
}