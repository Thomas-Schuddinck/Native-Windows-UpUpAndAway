using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public List<OrderLineDTO> OrderLines { get; set; }
        public int PassengerID { get; set; }

        public OrderDTO()
        {
            OrderLines = new List<OrderLineDTO>();

        }
    }
}
