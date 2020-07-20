using System;

namespace UpUpAndAwayApp.Models
{
    public class Consumable
    {
        #region Properties
        
        public int ConsumableId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductPicture { get; set; }
        public int Reduction { get; set; }
        public double SellingPrice { get; set; }
        public string PriceAdapter => "€ " + SellingPrice;
        #endregion

        public Consumable(double price, string name, string description, int reduction, double sellingPrice)
        {
            Price = price;
            Name = name;
            Description = description;
            Reduction = reduction;
            SellingPrice = sellingPrice;
        }
    }
}
