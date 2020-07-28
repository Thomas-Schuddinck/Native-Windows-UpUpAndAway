using Shared.Models;

namespace Shared.DTOs
{
    public class ConsumableDTO
    {
        public int ConsumableId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductPicture { get; set; }
        public int Reduction { get; set; }

        public ConsumableDTO() { }

        public ConsumableDTO(Consumable consumable)
        {
            ConsumableId = consumable.ConsumableId;
            Price = consumable.Price;
            Name = consumable.Name;
            Description = consumable.Description;
            Reduction = consumable.Reduction;
            ProductPicture = consumable.ProductPicture;
        }
    }
}