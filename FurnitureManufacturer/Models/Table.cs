using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;

namespace FurnitureManufacturer
{
    public class Table : Furniture , ITable
    {
        private decimal length;
        private decimal width;

        public Table(string initialModel, string initialMaterialType, decimal initialPrice, decimal initialHeight,decimal initialLenght, decimal initialWidth)
            :base (initialModel, initialMaterialType, initialPrice, initialHeight)
        {
            this.Length = initialLenght;
            this.Width = initialWidth;
        }

        public decimal Length
        {
            get { return this.length; }
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Length is a positive number bigger than 0");
                }
                this.length = value;
            }
        }

        public decimal Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width is a positive number bigger than 0");
                }
                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.Width * this.Length; }
        }

        public override string ToString()
        {
            var table = new StringBuilder();

            table.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area));

            return table.ToString();
        }
    }
}
