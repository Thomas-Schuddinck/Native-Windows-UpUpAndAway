using Shared.Enums;

namespace Shared.DTOs
{
    public class OrderLineDTO
    {
        public int OrderLineId { get; set; }
        public int Amount { get; set; }
        public ConsumableDTO ConsumableDTO { get; set; }
        public OrderStatus OrderStatus { get; private set; }
    }
}