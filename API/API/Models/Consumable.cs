using System;

namespace API.Models
{
    public class Consumable
    {
        #region Fields
        private double _price;
        private string _name;
        private int _reduction = 0;
        #endregion

        #region Properties
        public int ConsumableId { get; set; }
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("the price cannot be negative!");
                _price = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The name cannot be empty or only containing whitespace!");
                _name = value;

            }
        }
        public string Description { get; set; }
        public string ProductPicture { get; set; }
        public int Reduction
        {
            get
            {
                return _reduction;
            }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentException("Price reduction cannot be lower than 0 and not be higher than 1!");
                _reduction = value;

            }
        }

        public double SellingPrice => _price * (1 - _reduction);
        #endregion

        public Consumable(double price, string name, string description, int reduction, string productPicture)
        {
            Price = price;
            Name = name;
            Description = description;
            Reduction = reduction;
            ProductPicture = productPicture;
        }
        public Consumable()
        {

        }
    }
}
