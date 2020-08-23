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
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;

        public OrderController(IOrderService oserv)
        {
            orderService = oserv;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(orderService.GetAll().Select(o => new OrderDTO(o)).ToList());
        }

        //GET api/values/5
        [HttpGet("{passengerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Order>> GetByUser(int passengerId)
        {
            return Ok(orderService.GetByUser(passengerId).Select(o => new OrderDTO(o)).ToList());
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int> Post([FromBody] OrderDTO dto)
        {
            return Ok(orderService.PlaceOrder(new Order(dto)));
        }

        // PUT api/values/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> CloseOrder([FromBody] int id)
        {
            return Ok(orderService.FinishOrder(id));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
