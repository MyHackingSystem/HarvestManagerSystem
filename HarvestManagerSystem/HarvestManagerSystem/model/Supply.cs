using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Supply
    {
        private int supplyId;
        private Supplier supplier = new Supplier();
        private Farm farm = new Farm();
        private Product product = new Product();



        public int SupplyId { get => supplyId; set => supplyId = value; }
        internal Supplier Supplier { get => supplier;}
        internal Farm Farm { get => farm;}
        internal Product Product { get => product;}

        string SupplyFarmName { get => Farm.FarmName;}
        string SupplyProductName { get => Product.ProductName;}

    }
}
