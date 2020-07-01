using System;

namespace API.Models
{
    public class Consumable
    {
        #region Properties
        public int ConsumableId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Reduction { get; set; }

        public double SellingPrice => Price * (1 - Reduction); 
        #endregion

        public Consumable(double price, string name, string description, int reduction)
        {
            Price = price;
            Name = name;
            Description = description;
            Reduction = reduction;
        }
    }
}
