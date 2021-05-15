using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class HarvestQuantity
    {
        private int harvestQuantityId;
        private DateTime harvestDate;
        private double allQuantity;
        private double badQuantity;
        private double goodQuantity;
        private double productPrice;
        private double penaltyGeneral;
        private double damageGeneral;
        private int harvestType;
        private bool transportStatus;
        private double payment;
        private string remarque;
        private Employee employee = new Employee();
        private Transport transport = new Transport();
        private Credit credit = new Credit();
        private Production production = new Production();

        public int HarvestQuantityId { get => harvestQuantityId; set => harvestQuantityId = value; }
        public DateTime HarvestDate { get => harvestDate; set => harvestDate = value; }
        public double AllQuantity { get => (double)System.Math.Round(allQuantity, 2); set => allQuantity = value; }
        public double BadQuantity { get => (double)System.Math.Round(badQuantity, 2); set => badQuantity = value; }
        public double GoodQuantity { get => (double)System.Math.Round( AllQuantity - BadQuantity, 2); set => goodQuantity = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }
        public double PenaltyGeneral { get => penaltyGeneral; set => penaltyGeneral = value; }
        public double DamageGeneral { get => damageGeneral; set => damageGeneral = value; }
        public int HarvestType { get => harvestType; set => harvestType = value; }
        public bool TransportStatus { get => transportStatus; set => transportStatus = value; }
        public double Payment { get => (double)System.Math.Round(getPayment(), 2) ; set => payment = value; }
        public string Remarque { get => remarque; set => remarque = value; }
        public Employee Employee { get => employee; set => employee = value; }
        internal Transport Transport { get => transport; set => transport = value; }
        internal Credit Credit { get => credit; set => credit = value; }
        internal Production Production { get => production; set => production = value; }

        public double getPayment()
        {
            double pay = 0;
            try
            {
                pay = ((AllQuantity - BadQuantity - PenaltyGeneral- DamageGeneral) * ProductPrice) - Transport.TransportAmount - Credit.CreditAmount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Payment = pay;
            return pay;
        }

        public string EmployeeName { get => Employee.FullName; }

        public double TransportAmount
        {
            get =>  Transport.TransportAmount; set => Transport.TransportAmount = value;
        }

        public bool TransportStatusByAmount
        {
            get => TransportAmount > 0;
        }

        public double CreditAmount
        {
            get => Credit.CreditAmount; set => Credit.CreditAmount = value;
        }

        public enum HarvestCategory
        {
            GROUPE, INDIVIDUAL, UNKNOWN
        };

        public HarvestCategory HarvestCat
        {
            get => (HarvestType == 1) ? HarvestCategory.INDIVIDUAL : HarvestCategory.GROUPE;
        }

    }
}
