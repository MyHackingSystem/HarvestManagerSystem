using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HarvestManagerSystem.database
{
    class ProductionDAO : DAO
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


        private static ProductionDAO instance = new ProductionDAO();
        private ProductionDAO() : base() { }
        public static ProductionDAO getInstance()
        {
            if (instance == null)
            {
                instance = new ProductionDAO();
            }
            return instance;
        }

        //*******************************
        //Search production data by date
        //*******************************
        public List<Production> searchHarvestHoursProduction(DateTime fromDate, DateTime toDate, int type)
        {
            string select = "SELECT "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_ID + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TYPE + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_DATE + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRICE + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
        + " FROM " + TABLE_PRODUCTION
        + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
        + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_SUPPLIER_ID
        + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
        + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_FARM_ID
        + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
        + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRODUCT_ID
        + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
        + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
        + " WHERE " + COLUMN_PRODUCTION_DATE 
        + " BETWEEN strftime('%Y-%m-%d %H:%M:%S', '" + fromDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') AND strftime('%Y-%m-%d %H:%M:%S', '" + toDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') "
        + " AND " + COLUMN_PRODUCTION_TYPE + " = " + type
        + " ORDER BY " + COLUMN_PRODUCTION_DATE + " DESC ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(select, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return ProductionResultDataReader(result);
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                CloseConnection();
            }

        }

        //*******************************
        //Search production data by date
        //*******************************
        public List<Production> searchHarvestQuantityProduction(DateTime fromDate, DateTime toDate, int type)
        {
            string select = "SELECT "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_ID + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TYPE + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_DATE + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRICE + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
        + " FROM " + TABLE_PRODUCTION
        + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
        + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_SUPPLIER_ID
        + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
        + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_FARM_ID
        + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
        + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRODUCT_ID
        + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
        + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
        + " WHERE " + COLUMN_PRODUCTION_DATE
        + " BETWEEN strftime('%Y-%m-%d %H:%M:%S', '" + fromDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') AND strftime('%Y-%m-%d %H:%M:%S', '" + toDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') "
        + " AND " + COLUMN_PRODUCTION_TYPE + " != " + type
        + " ORDER BY " + COLUMN_PRODUCTION_DATE + " DESC ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(select, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return ProductionResultDataReader(result);
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                CloseConnection();
            }

        }

        //Help method to get data from SQLiteDataReader
        private List<Production> ProductionResultDataReader(SQLiteDataReader result)
        {
            List<Production> list = new List<Production>();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    Production production = new Production();
                    production.ProductionID = Convert.ToInt32((result[COLUMN_PRODUCTION_ID]).ToString());
                    production.ProductionType = Convert.ToInt32((result[COLUMN_PRODUCTION_TYPE]).ToString());
                    production.ProductionDate = (DateTime)result[COLUMN_PRODUCTION_DATE];
                    production.TotalEmployee = Convert.ToInt32((result[COLUMN_PRODUCTION_TOTAL_EMPLOYEES]).ToString());
                    production.TotalQuantity = Convert.ToDouble((result[COLUMN_PRODUCTION_TOTAL_QUANTITY]).ToString());
                    production.TotalMinutes = Convert.ToDouble((result[COLUMN_PRODUCTION_TOTAL_MINUTES]).ToString());
                    production.Price = Convert.ToDouble((result[COLUMN_PRODUCTION_PRICE]).ToString());
                    production.Supplier.SupplierId = Convert.ToInt32((result[SupplierDAO.COLUMN_SUPPLIER_ID]).ToString());
                    production.Supplier.SupplierName = (string)result[SupplierDAO.COLUMN_SUPPLIER_NAME];
                    production.Farm.FarmId = Convert.ToInt32((result[FarmDAO.COLUMN_FARM_ID]).ToString());
                    production.Farm.FarmName = (string)result[FarmDAO.COLUMN_FARM_NAME];
                    production.Product.ProductId = Convert.ToInt32((result[ProductDAO.COLUMN_PRODUCT_ID]).ToString());
                    production.Product.ProductName = (string)result[ProductDAO.COLUMN_PRODUCT_NAME];
                    production.ProductDetail.ProductDetailId = Convert.ToInt32((result[ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID]).ToString());
                    production.ProductDetail.ProductType = (string)result[ProductDetailDAO.COLUMN_PRODUCT_TYPE];
                    list.Add(production);
                }
            }
            
            return list;
        }

        public List<Production> getdata()
        {
            string select = "SELECT * FROM " + TABLE_PRODUCTION + " WHERE " + COLUMN_PRODUCTION_DATE + " BETWEEN '2021-01-01 00:00:00' AND '2021-05-05 00:00:00' ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(select, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return ResultDataReader(result);
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        private List<Production> ResultDataReader(SQLiteDataReader result)
        {
            List<Production> list = new List<Production>();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    Production production = new Production();
                    production.ProductionID = Convert.ToInt32((result[COLUMN_PRODUCTION_ID]).ToString());
                    production.ProductionDate = (DateTime)result[COLUMN_PRODUCTION_DATE];
                    production.TotalEmployee = Convert.ToInt32((result[COLUMN_PRODUCTION_TOTAL_EMPLOYEES]).ToString());
                    production.TotalQuantity = Convert.ToDouble((result[COLUMN_PRODUCTION_TOTAL_QUANTITY]).ToString());
                    production.TotalMinutes = Convert.ToDouble((result[COLUMN_PRODUCTION_TOTAL_MINUTES]).ToString());
                    production.Price = Convert.ToInt32((result[COLUMN_PRODUCTION_PRICE]).ToString());
                    list.Add(production);
                }
            }

            return list;
        }

        internal bool updateProductionData(Production production)
        {
            string updateStmt = "UPDATE " + TABLE_PRODUCTION + " SET "
                                 + COLUMN_PRODUCTION_TYPE + " =@" + COLUMN_PRODUCTION_TYPE + ", "
                                 + COLUMN_PRODUCTION_DATE + " =@" + COLUMN_PRODUCTION_DATE + ", "
                                 + COLUMN_PRODUCTION_SUPPLIER_ID + " =@" + COLUMN_PRODUCTION_SUPPLIER_ID + ", "
                                 + COLUMN_PRODUCTION_FARM_ID + " =@" + COLUMN_PRODUCTION_FARM_ID + ", "
                                 + COLUMN_PRODUCTION_PRODUCT_ID + " =@" + COLUMN_PRODUCTION_PRODUCT_ID + ", "
                                 + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID + " =@" + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID + ", "
                                 + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + " =@" + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
                                 + COLUMN_PRODUCTION_TOTAL_QUANTITY + " =@" + COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
                                 + COLUMN_PRODUCTION_TOTAL_MINUTES + " =@" + COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
                                 + COLUMN_PRODUCTION_PRICE + " =@" + COLUMN_PRODUCTION_PRICE + " "
                                 + " WHERE " + COLUMN_PRODUCTION_ID + " = " + production.ProductionID + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_TYPE, production.ProductionType));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_DATE, production.ProductionDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_SUPPLIER_ID, production.Supplier.SupplierId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_FARM_ID, production.Farm.FarmId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_PRODUCT_ID, production.Product.ProductId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_PRODUCT_DETAIL_ID, production.ProductDetail.ProductDetailId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_TOTAL_EMPLOYEES, production.TotalEmployee));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_TOTAL_QUANTITY, production.TotalQuantity));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_TOTAL_MINUTES, production.TotalMinutes));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTION_PRICE, production.Price));
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        internal bool deleteHoursProductionData(Production production, HarvestHours hours)
        {

            var deleteTransport = "DELETE FROM " + TransportDAO.TABLE_TRANSPORT
                    + " WHERE " + TransportDAO.COLUMN_TRANSPORT_ID + " = " + hours.Transport.TransportId + " ;";

            var deleteCredit = "DELETE FROM " + CreditDAO.TABLE_CREDIT
                    + " WHERE " + CreditDAO.COLUMN_CREDIT_ID + " = " + hours.Credit.CreditId + " ;";

            var deleteHours = "DELETE FROM " + HarvestHoursDAO.TABLE_HOURS
                    + " WHERE " + HarvestHoursDAO.COLUMN_HOURS_PRODUCTION_ID + " = " + production.ProductionID + " ;";

            var deleteProduction = "DELETE FROM " + TABLE_PRODUCTION
                    + " WHERE " + COLUMN_PRODUCTION_ID + " = " + production.ProductionID + " ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(deleteTransport + ";" + deleteCredit + ";" + deleteHours + ";" + deleteProduction, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        internal bool deleteQuantityProductionData(Production production, HarvestQuantity item)
        {

            var deleteTransport = "DELETE FROM " + TransportDAO.TABLE_TRANSPORT
                    + " WHERE " + TransportDAO.COLUMN_TRANSPORT_ID + " = " + item.Transport.TransportId + " ;";

            var deleteCredit = "DELETE FROM " + CreditDAO.TABLE_CREDIT
                    + " WHERE " + CreditDAO.COLUMN_CREDIT_ID + " = " + item.Credit.CreditId + " ;";

            var deleteQuantity = "DELETE FROM " + HarvestQuantityDAO.TABLE_QUANTITY
                    + " WHERE " + HarvestQuantityDAO.COLUMN_QUANTITY_PRODUCTION_ID + " = " + production.ProductionID + " ;";

            var deleteProduction = "DELETE FROM " + TABLE_PRODUCTION
                    + " WHERE " + COLUMN_PRODUCTION_ID + " = " + production.ProductionID + " ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(deleteTransport + ";" + deleteCredit + ";" + deleteQuantity + ";" + deleteProduction, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Add production data
        //*******************************
        public long addProductionAndGetId(Production production)
        {
            long rowID = -1;
            SQLiteTransaction transaction = null;
            string insertStmt = "INSERT INTO " + TABLE_PRODUCTION + " ("
                         + COLUMN_PRODUCTION_TYPE + ", "
                         + COLUMN_PRODUCTION_DATE + ", "
                         + COLUMN_PRODUCTION_SUPPLIER_ID + ", "
                         + COLUMN_PRODUCTION_FARM_ID + ", "
                         + COLUMN_PRODUCTION_PRODUCT_ID + ", "
                         + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID + ", "
                         + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
                         + COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
                         + COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
                         + COLUMN_PRODUCTION_PRICE +
                            " ) VALUES ( "
                         + "@" + COLUMN_PRODUCTION_TYPE + ", "
                         + "@" + COLUMN_PRODUCTION_DATE + ", "
                         + "@" + COLUMN_PRODUCTION_SUPPLIER_ID + ", "
                         + "@" + COLUMN_PRODUCTION_FARM_ID + ", "
                         + "@" + COLUMN_PRODUCTION_PRODUCT_ID + ", "
                         + "@" + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID + ", "
                         + "@" + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
                         + "@" + COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
                         + "@" + COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
                         + "@" + COLUMN_PRODUCTION_PRICE
                         + " )";

            try
            {
                OpenConnection();
                transaction = mSQLiteConnection.BeginTransaction();
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_TYPE, production.ProductionType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_DATE, production.ProductionDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_SUPPLIER_ID, production.Supplier.SupplierId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_FARM_ID, production.Farm.FarmId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_PRODUCT_ID, production.Product.ProductId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_PRODUCT_DETAIL_ID, production.ProductDetail.ProductDetailId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_TOTAL_EMPLOYEES, production.TotalEmployee);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_TOTAL_QUANTITY, production.TotalQuantity);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_TOTAL_MINUTES, production.TotalMinutes);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCTION_PRICE, production.Price);
                sQLiteCommand.ExecuteNonQuery();
                rowID = mSQLiteConnection.LastInsertRowId;
                transaction.Commit();
                return rowID;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return rowID;
            }
            finally
            {
                CloseConnection();
            }
        }


        public void CreateTable()
        {
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_PRODUCTION + " ("
                + COLUMN_PRODUCTION_ID + " INTEGER PRIMARY KEY, "
                + COLUMN_PRODUCTION_TYPE + " INTEGER NOT NULL, "
                + COLUMN_PRODUCTION_DATE + " DATE NOT NULL, "
                + COLUMN_PRODUCTION_SUPPLIER_ID + " INTEGER NOT NULL, "
                + COLUMN_PRODUCTION_FARM_ID + " INTEGER NOT NULL, "
                + COLUMN_PRODUCTION_PRODUCT_ID + " INTEGER NOT NULL, "
                + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID + " TEXT NOT NULL, "
                + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + " INTEGER, "
                + COLUMN_PRODUCTION_TOTAL_QUANTITY + " REAL, "
                + COLUMN_PRODUCTION_TOTAL_MINUTES + " REAL, "
                + COLUMN_PRODUCTION_PRICE + " REAL NOT NULL, "
                + " FOREIGN KEY (" + COLUMN_PRODUCTION_SUPPLIER_ID + ") REFERENCES " + SupplierDAO.TABLE_SUPPLIER + " (" + SupplierDAO.COLUMN_SUPPLIER_ID + ")"
                + " FOREIGN KEY (" + COLUMN_PRODUCTION_FARM_ID + ") REFERENCES " + FarmDAO.TABLE_FARM + " (" + FarmDAO.COLUMN_FARM_ID + ")"
                + " FOREIGN KEY (" + COLUMN_PRODUCTION_PRODUCT_ID + ") REFERENCES " + ProductDAO.TABLE_PRODUCT + " (" + ProductDAO.COLUMN_PRODUCT_ID + ")"
                + " FOREIGN KEY (" + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID + ") REFERENCES " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " (" + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ")"
                + ") ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        
        public string getSelectQuery(DateTime fromDate, DateTime toDate, int type)
        {

         string selectproduct = "SELECT "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_ID + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_DATE + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
        + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRICE + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
        + " FROM " + TABLE_PRODUCTION
        + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
        + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_SUPPLIER_ID
        + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
        + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_FARM_ID
        + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
        + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRODUCT_ID
        + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
        + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + TABLE_PRODUCTION + "." + COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
        + " WHERE " + COLUMN_PRODUCTION_DATE
        + " BETWEEN strftime('%Y-%m-%d %H:%M:%S', '" + fromDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') AND strftime('%Y-%m-%d %H:%M:%S', '" + toDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') "
        + " AND " + COLUMN_PRODUCTION_TYPE + " = " + type
        + " ORDER BY " + COLUMN_PRODUCTION_DATE + " DESC ;";


            return selectproduct;
        }

    }
}
