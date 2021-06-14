using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Harvest
    {
        private int harvestId;
        private DateTime harvestDate;
        private double harvestQuantity;
        private double lostQuantity;

        public int HarvestId { get => harvestId; set => harvestId = value; }
        public DateTime HarvestDate { get => harvestDate; set => harvestDate = value; }
        public double HarvestQuantity { get => harvestQuantity; set => harvestQuantity = value; }
        public double LostQuantity { get => lostQuantity; set => lostQuantity = value; }
        public double RecoverQuantity { get => (double)System.Math.Round(HarvestQuantity - LostQuantity, 2); }
    }
}
