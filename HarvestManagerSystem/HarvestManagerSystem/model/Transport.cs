using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Transport
    {
        private int transportId;
        private DateTime transportDate;
        private double transportAmount;
        private Employee employee = new Employee();
        private Farm farm = new Farm();

        public int TransportId { get => transportId; set => transportId = value; }
        public DateTime TransportDate { get => transportDate; set => transportDate = value; }
        public double TransportAmount { get => transportAmount; set => transportAmount = value; }
        public Employee Employee { get => employee;}
        public string EmployeeName { get => Employee.FullName; }
        internal Farm Farm { get => farm;}
        public string FarmName { get => Farm.FarmName; }
    }
}
