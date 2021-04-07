using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class ProductDetail
    {
        private int productDetailId;
        private string productCode;
        private string productType;
        private double priceEmployee;
        private double priceCompany;
        private Product product = new Product();

        public int ProductDetailId { get => productDetailId; set => productDetailId = value; }
        public string ProductCode { get => productCode; set => productCode = value; }
        public string ProductType { get => productType; set => productType = value; }
        public double PriceEmployee { get => priceEmployee; set => priceEmployee = value; }
        public double PriceCompany { get => priceCompany; set => priceCompany = value; }
        internal Product Product { get => product; set => product = value; }
    }
}
