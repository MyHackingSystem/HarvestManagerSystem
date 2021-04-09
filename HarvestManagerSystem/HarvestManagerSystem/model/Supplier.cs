using System;
using System.Collections.Generic;
using System.Text;

namespace HarvestManagerSystem.model
{
    class Supplier
    {
        private int supplierId;
        private string supplierName;
        private string supplierFirstName;
        private string supplierLastName;

        public int SupplierId { get => supplierId; set => supplierId = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string SupplierFirstName { get => supplierFirstName; set => supplierFirstName = value; }
        public string SupplierLastName { get => supplierLastName; set => supplierLastName = value; }

    }
}
