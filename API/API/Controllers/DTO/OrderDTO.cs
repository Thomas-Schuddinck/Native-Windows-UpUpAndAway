using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.DTO
{
    public class OrderDTO
    {
        public ICollection<OrderLineDTO> orderlines { get; set; }
        public int PassengerID { get; set; }
    }

    public class OrderLineDTO
    {
        public int ConsumableID { get; set; }
        public int Amount { get; set; }

    }
}
