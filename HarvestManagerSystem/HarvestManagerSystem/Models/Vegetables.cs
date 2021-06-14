using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.Models
{
    class Vegetables
    {
        private int productId;
        private string productName;
        private double priceEmployee;
        private double priceCompany;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double PriceEmployee { get => priceEmployee; set => priceEmployee = value; }
        public double PriceCompany { get => priceCompany; set => priceCompany = value; }
    }
}
