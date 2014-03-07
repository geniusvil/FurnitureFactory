using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;

namespace FurnitureManufacturer.Models
{
    public class Chair:Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string initialModel, string initialMaterialType, decimal initialPrice, decimal initialHeight, int initialNumberOfLegs)
            :base (initialModel, initialMaterialType, initialPrice, initialHeight)
        {
            this.NumberOfLegs = initialNumberOfLegs;
        }

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Chair has more than zero legs");
                }
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var chair = new StringBuilder();

            char[] materialArray = this.Material.ToCharArray();
            materialArray[0] = char.ToUpper(materialArray[0]);

            string materialCapitalLetter = new string (materialArray);
            chair.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, this.Model, materialCapitalLetter, this.Price, this.Height, this.NumberOfLegs));
           
            return chair.ToString();
        }
    }
}
