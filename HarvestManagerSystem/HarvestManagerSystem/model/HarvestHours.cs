using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;


namespace HarvestManagerSystem.model
{
    class HarvestHours
    {
        private int harvestHoursID;
        private DateTime harvestDate;
        private DateTime startMorning;
        private DateTime endMorning;
        private DateTime startNoon;
        private DateTime endNoon;
        private double totalMinutes;
        private int employeeType;
        private double hourPrice;
        private bool transportStatus;
        private double payment;
        private string remarque;
        private Employee mEmployee = new Employee();
        private Transport mTransport = new Transport();
        private Credit mCredit = new Credit();
        private Production mProduction = new Production();

        public string Remarque { get => remarque; set => remarque = value; }
        public Employee Employee { get => mEmployee; }
        internal Transport Transport { get => mTransport; }
        internal Credit Credit { get => mCredit; }
        internal Production Production { get => mProduction; }

        public int HarvestHoursID { get => harvestHoursID; set => harvestHoursID = value; }
        public DateTime HarvestDate { get => harvestDate.Date; set => harvestDate = value; }
        public DateTime StartMorning { get => startMorning; set => startMorning = value; }
        public DateTime EndMorning { get => endMorning; set => endMorning = value; }
        public DateTime StartNoon { get => startNoon; set => startNoon = value; }
        public DateTime EndNoon { get => endNoon; set => endNoon = value; }
        public double TotalMinutes { get => EndMorning.Subtract(StartMorning).Add(EndNoon.Subtract(StartNoon)).TotalMinutes; }
        public int EmployeeType { get => employeeType; set => employeeType = value; }
        public double HourPrice { get => hourPrice; set => hourPrice = value; }
        public bool TransportStatus { get => transportStatus; set => transportStatus = value; }
        public double Payment
        {

            get => (TotalMinutes * (HourPrice / 60)) - (Transport.TransportAmount + Credit.CreditAmount);
            set => payment = value;
        }

        public double CreditAmount { get => Credit.CreditAmount; set => Credit.CreditAmount = value; }

        public string EmployeeName { get => Employee.FullName; }

        public double TransportAmount { get => Transport.TransportAmount; set => Transport.TransportAmount = value; }


        public string TimeStartMorning
        {
            get =>  StartMorning.ToShortTimeString();
        }
        public string TimeEndMorning
        {
            get => EndMorning.ToShortTimeString();
        }
        public string TimeStartNoon
        {
            get => (StartNoon != null) ? StartNoon.ToShortTimeString(): "";
        }
        public string TimeEndNoon
        {
            get => EndNoon.ToShortTimeString();
        }

        public enum EmployeeCategory
        {
            RECOLTEUR, CONTROLEUR, UNKNOWN
        };

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
