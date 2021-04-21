using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class CompanyRapport
    {
        private DateTime harvestDate;
        private string supplier;
        private string employee;
        private string farm;
        private string product;
        private string type;
        private double allQuantity;
        private double badQuantity;
        private double goodQuantity;
        private double price;
        private double payment;

        public DateTime HarvestDate { get => harvestDate; set => harvestDate = value; }
        public string Supplier { get => supplier; set => supplier = value; }
        public string Employee { get => employee; set => employee = value; }
        public string Farm { get => farm; set => farm = value; }
        public string Product { get => product; set => product = value; }
        public string Type { get => type; set => type = value; }
        public double AllQuantity { get => allQuantity; set => allQuantity = value; }
        public double Price { get => price; set => price = value; }
        public double Payment { get => AllQuantity * price;}
        public double BadQuantity { get => badQuantity; set => badQuantity = value; }
        public double GoodQuantity { get => allQuantity - badQuantity;}
    }
}
