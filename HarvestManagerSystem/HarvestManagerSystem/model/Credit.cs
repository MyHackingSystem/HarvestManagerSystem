using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Credit
    {
        private int creditId;
        private DateTime creditDate;
        private double creditAmount;
        private Employee employee = new Employee();

        public int CreditId { get => creditId; set => creditId = value; }
        public DateTime CreditDate { get => creditDate; set => creditDate = value; }
        public double CreditAmount { get => creditAmount; set => creditAmount = value; }
        public Employee Employee { get => employee;}

        public string EmployeeName { get => Employee.FirstName + " " + Employee.LastName; }
    }
}
