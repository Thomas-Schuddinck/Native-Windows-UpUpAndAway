using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.DTO;
using API.Data.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;

        public OrderController(IOrderService oserv)
        {
            orderService = oserv;
        }

        // GET api/values
        //[HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(orderService.GetAll());
        }

        //GET api/values/5
        [HttpGet("{passengerId}")]
        public ActionResult<Order> GetByUser(int passengerId)
        {
            return Ok(orderService.GetByUser(passengerId));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] OrderDTO dto)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
