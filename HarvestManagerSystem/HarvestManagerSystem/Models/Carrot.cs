using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.Models
{
    class Carrot:Products
    {
        private int harvestType;
        public int HarvestType { get => harvestType; set => harvestType = value; }

    }
}
