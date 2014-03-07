using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture:IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        public Furniture(string initialModel, string initialMaterialType, decimal initialPrice, decimal initialHeight)
        {
            this.Model = initialModel;
            this.Material = initialMaterialType;
            this.Price = initialPrice;
            this.Height = initialHeight;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cannot be null or empty");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Model has to be with more than 3 letters");
                }
                this.model = value;
            }
        }

        public string Material { get; private set; }

        public decimal Price
        {
            get { return this.price; }
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price is a positive number");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            protected set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Height is a positive number");
                }
                this.height = value;
            }
        }
    }
}
