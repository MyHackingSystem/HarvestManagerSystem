using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Season
    {
        private int seasonId;
        private DateTime seasonPlantingDate;
        private DateTime seasonHarvestDate;
        private Farm farm = new Farm();

        public int SeasonId { get => seasonId; set => seasonId = value; }
        public DateTime SeasonPlantingDate { get => seasonPlantingDate.Date; set => seasonPlantingDate = value; }
        public DateTime SeasonHarvestDate { get => seasonHarvestDate.Date; set => seasonHarvestDate = value; }
        internal Farm Farm { get => farm; set => farm = value; }
    }
}
