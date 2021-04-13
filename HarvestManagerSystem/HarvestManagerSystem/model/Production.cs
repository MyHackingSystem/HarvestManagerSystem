using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Production
    {
        private long productionId;
        private DateTime productionDate;
        private int totalEmployee;
        private double totalQuantity;
        private double totalMinutes;
        private double price;
        private int productionType;
        private Supplier supplier = new Supplier();
        private Farm farm = new Farm();
        private Product product = new Product();
        private ProductDetail productDetail = new ProductDetail();

        public long ProductionID { get => productionId; set => productionId = value; }
        public DateTime ProductionDate { get => productionDate.Date; set => productionDate = value; }
        public int TotalEmployee { get => totalEmployee; set => totalEmployee = value; }
        public double TotalQuantity { get => System.Math.Round(totalQuantity, 2); set => totalQuantity = value; }
        public double TotalMinutes { get => System.Math.Round(totalMinutes, 2); set => totalMinutes = value; }
        public double Price { get => price; set => price = value; }
        public int ProductionType { get => productionType; set => productionType = value; }
        internal Supplier Supplier { get => supplier;}
        public string SupplierName { get => Supplier.SupplierName; }
        internal Farm Farm { get => farm;}
        public string FarmName { get => Farm.FarmName; }
        internal Product Product { get => product;}

        public string ProductName { get => Product.ProductName; }
        internal ProductDetail ProductDetail { get => productDetail;}
        public string ProductCode { get => ProductDetail.ProductCode; }
        public double PaymentCompany { get => System.Math.Round(TotalMinutes * (Price / 60), 2); }
    }
}
