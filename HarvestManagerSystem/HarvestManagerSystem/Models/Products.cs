using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.Models
{
    class Products
    {
        private int productId;
        private string productName;
        private double employeePrice;
        private double companyPrice;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double EmployeePrice { get => employeePrice; set => employeePrice = value; }
        public double CompanyPrice { get => companyPrice; set => companyPrice = value; }
    }
}
