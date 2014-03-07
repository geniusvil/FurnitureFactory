using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair 
    {
        private bool isConverted;
        private decimal inputHeight;

        public ConvertibleChair(string initialModel, string initialMaterialType, decimal initialPrice, decimal initialHeight, int initialNumberOfLegs)
            : base(initialModel, initialMaterialType, initialPrice, initialHeight, initialNumberOfLegs)
        {
            this.inputHeight = initialHeight;
        }

        public bool IsConverted
        {
            get { return this.isConverted; }
        }

        public void Convert()
        {
           if (this.IsConverted)
           {
               this.Height = 0.10m;
           }
           else
           {
               this.Height = inputHeight;
           }

           this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            var convChair = new StringBuilder(base.ToString());

            convChair.Append(string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));

            return convChair.ToString();
        }
    }
}
