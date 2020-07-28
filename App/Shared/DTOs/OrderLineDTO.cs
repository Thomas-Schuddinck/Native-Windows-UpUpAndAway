using Shared.DisplayModels;
using Shared.Enums;
using Shared.Models;

namespace Shared.DTOs
{
    public class OrderLineDTO
    {
        public int OrderLineId { get; set; }
        public int Amount { get; set; }
        public ConsumableDTO ConsumableDTO { get; set; }

        public OrderLineDTO(DisplayOrderLine displayOrderLine)
        {
            Amount = displayOrderLine.Amount;
            ConsumableDTO = new ConsumableDTO(displayOrderLine.Consumable);
        }

        public OrderLineDTO(OrderLine orderLine)
        {
            OrderLineId = orderLine.OrderLineId;
            Amount = orderLine.Amount;
            ConsumableDTO = new ConsumableDTO(orderLine.Consumable);
        }

        public OrderLineDTO()
        {
        }
    }
}