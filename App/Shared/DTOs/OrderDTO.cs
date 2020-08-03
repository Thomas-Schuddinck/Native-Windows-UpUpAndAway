using Shared.DisplayModels;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public List<OrderLineDTO> OrderLines { get; set; }
        public PassengerDTO Passenger { get; set; }

        public OrderDTO()
        {
            OrderLines = new List<OrderLineDTO>();
        }

        public OrderDTO(DisplayReduction cart, Passenger passenger)
        {
            OrderLines = cart.OrderLines.Select(ol => new OrderLineDTO(ol)).ToList();
            Passenger = new PassengerDTO(passenger);
        }

        public OrderDTO(Order order)
        {
            OrderID = order.OrderId;
            OrderLines = order.OrderLines.Select(ol => new OrderLineDTO(ol)).ToList();
            Passenger = new PassengerDTO(order.Passenger);
        }


    }
}
