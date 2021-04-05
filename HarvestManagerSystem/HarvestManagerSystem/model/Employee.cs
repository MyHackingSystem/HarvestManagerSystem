using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    public class Employee
    {
        private int employeeId;
        private bool employeeStatus;
        private string firstName;
        private string lastName;
        private DateTime hireDate;
        private DateTime fireDate;
        private DateTime permissionDate;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public bool EmployeeStatus { get => employeeStatus; set => employeeStatus = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime HireDate { get => hireDate.Date; set => hireDate = value; }
        public DateTime FireDate { get => fireDate.Date; set => fireDate = value; }
        public DateTime PermissionDate { get => permissionDate.Date; set => permissionDate = value; }
        public string FullName
        {
            get
            {
                return $"{firstName} {lastName}";
            }
        }
    }
}
