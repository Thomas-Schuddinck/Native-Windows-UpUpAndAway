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
    }
}