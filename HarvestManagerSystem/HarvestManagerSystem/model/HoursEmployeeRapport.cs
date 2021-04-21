using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class HoursEmployeeRapport
    {
        
        private DateTime harvestDate;
        private DateTime startMorning;
        private DateTime endMorning;
        private DateTime startNoon;
        private DateTime endNoon;
        private int employeeType;
        private double hourPrice;
        private Employee mEmployee = new Employee();
        private Transport mTransport = new Transport();
        private Credit mCredit = new Credit();
        private Production mProduction = new Production();

        public DateTime HarvestDate { get => harvestDate.Date; set => harvestDate = value; }
        public DateTime StartMorning { set => startMorning = value; }
        public DateTime EndMorning { set => endMorning = value; }
        public DateTime StartNoon { set => startNoon = value; }
        public DateTime EndNoon { set => endNoon = value; }
        public double TotalMinutes { get => (double)System.Math.Round(endMorning.Subtract(startMorning).Add(endNoon.Subtract(startNoon)).TotalMinutes, 2); }
        public int EmployeeType { get => employeeType; set => employeeType = value; }
        public double HourPrice { get => hourPrice; set => hourPrice = value; }

        public double Payment
        {
            get => System.Math.Round((TotalMinutes * (HourPrice / 60)) - (Transport.TransportAmount + Credit.CreditAmount), 2);
        }


        public Employee Employee { get => mEmployee; }
        internal Transport Transport { get => mTransport; }
        internal Credit Credit { get => mCredit; }
        internal Production Production { get => mProduction; }



        public double CreditAmount { get => Credit.CreditAmount; set => Credit.CreditAmount = value; }

        public string EmployeeName { get => Employee.FullName; }

        public double TransportAmount { get => Transport.TransportAmount; set => Transport.TransportAmount = value; }




        public enum EmployeeCategory
        {
            RECOLTEUR, CONTROLEUR, UNKNOWN
        };

        public EmployeeCategory EmpCat
        {
            get => (EmployeeType == 1) ? EmployeeCategory.RECOLTEUR : EmployeeCategory.CONTROLEUR;
        }

        public EmployeeCategory getEmployeeCategory()
        {
            if (EmployeeType == 1)
            {
                return EmployeeCategory.RECOLTEUR;
            }
            else if (EmployeeType == 2)
            {
                return EmployeeCategory.CONTROLEUR;
            }
            else
            {
                return EmployeeCategory.UNKNOWN;
            }
        }
    }
}
