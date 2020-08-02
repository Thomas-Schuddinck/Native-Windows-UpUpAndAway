﻿using API.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

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
            return Ok(orderService.GetAll().Select(o => new OrderDTO(o)).ToList());
        }

        //GET api/values/5
        [HttpGet("{passengerId}")]
        public ActionResult<Order> GetByUser(int passengerId)
        {
            return Ok(orderService.GetByUser(passengerId));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<int> Post([FromBody] OrderDTO dto)
        {
            return Ok(orderService.PlaceOrder(new Order(dto)));
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
