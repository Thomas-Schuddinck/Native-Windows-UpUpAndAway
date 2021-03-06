﻿using Shared.DisplayModels;
using Shared.Enums;
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
        public OrderStatus OrderStatus { get; set; }
        public DateTime DateTimePlaced { get; set; }

        public OrderDTO()
        {
            OrderLines = new List<OrderLineDTO>();
            OrderStatus = OrderStatus.Processing;
        }

        public OrderDTO(DisplayOrder cart, Passenger passenger)
        {
            OrderLines = cart.OrderLines.Select(ol => new OrderLineDTO(ol)).ToList();
            Passenger = new PassengerDTO(passenger);
            OrderStatus = cart.OrderStatus;
        }

        public OrderDTO(Order order)
        {
            OrderID = order.OrderId;
            OrderStatus = order.OrderStatus;
            OrderLines = order.OrderLines.Select(ol => new OrderLineDTO(ol)).ToList();
            Passenger = new PassengerDTO(order.Passenger);
            DateTimePlaced = order.DateTimePlaced;
        }


    }
}
