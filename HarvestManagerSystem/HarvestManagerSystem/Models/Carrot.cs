using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.Models
{
    class Carrot:Vegetables
    {
        private int harvestType;
        public int HarvestType { get => harvestType; set => harvestType = value; }

    }
}
