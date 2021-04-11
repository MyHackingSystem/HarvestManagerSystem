using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.database
{
    class ProductionDAO:DAO
    {
        public const string TABLE_PRODUCTION = "Production";
        public const string COLUMN_PRODUCTION_ID = "ProductionId";
        public const string COLUMN_PRODUCTION_TYPE = "ProductionType";
        public const string COLUMN_PRODUCTION_DATE = "ProductionDate";
        public const string COLUMN_PRODUCTION_SUPPLIER_ID = "SupplierId";
        public const string COLUMN_PRODUCTION_FARM_ID = "FarmId";
        public const string COLUMN_PRODUCTION_PRODUCT_ID = "ProductId";
        public const string COLUMN_PRODUCTION_PRODUCT_DETAIL_ID = "ProductDetailId";
        public const string COLUMN_PRODUCTION_TOTAL_EMPLOYEES = "TotalEmployees";
        public const string COLUMN_PRODUCTION_TOTAL_QUANTITY = "TotalQuantity";
        public const string COLUMN_PRODUCTION_TOTAL_MINUTES = "TotalHours";
        public const string COLUMN_PRODUCTION_PRICE = "Price";
    }
}
