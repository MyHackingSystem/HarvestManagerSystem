using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Preferences
    {

        private double penaltyGeneral = 0.0;
        private double damageGeneral = 0.0;
        private double hourPrice = 1.0;
        private double transportPrice = 0.0;

        public double PenaltyGeneral { get => penaltyGeneral; set => penaltyGeneral = value; }
        public double DamageGeneral { get => damageGeneral; set => damageGeneral = value; }
        public double HourPrice { get => hourPrice; set => hourPrice = value; }
        public double TransportPrice { get => transportPrice; set => transportPrice = value; }
    }
}
