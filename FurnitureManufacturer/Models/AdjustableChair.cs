using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair : Chair, IAdjustableChair 
    {
        public AdjustableChair(string initialModel, string initialMaterialType, decimal initialPrice, decimal initialHeight, int initialNumberOfLegs)
            :base (initialModel, initialMaterialType, initialPrice, initialHeight, initialNumberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height>=0) // check
            {
                this.Height = height;
            }
        }
    }
}
