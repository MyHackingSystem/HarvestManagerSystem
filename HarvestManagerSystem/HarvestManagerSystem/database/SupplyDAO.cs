using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;
using System.Windows.Forms;

namespace HarvestManagerSystem.database
{
    class SupplyDAO:DAO
    {
        public const string TABLE_SUPPLY = "Supply";
        public const string COLUMN_SUPPLY_ID = "SupplyId";
        public const string COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID = "SupplierId";
        public const string COLUMN_SUPPLY_FRGN_KEY_FARM_ID = "FarmId";
        public const string COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID = "ProductId";


        private static SupplyDAO instance = new SupplyDAO();

        private SupplyDAO() : base() { }

        public static SupplyDAO getInstance()
        {
            if (instance == null)
            {
                instance = new SupplyDAO();
            }
            return instance;
        }

        //*******************************
        //Get all farm data
        //*******************************
        public List<Supply> getData(Supplier supplier)
        {
            List<Supply> list = new List<Supply>();

            var selectStmt = "SELECT "
                + TABLE_SUPPLY + "." + COLUMN_SUPPLY_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + " "
                + " FROM " + TABLE_SUPPLY + " "
                + "LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + TABLE_SUPPLY + "." + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + " "
                + "LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + TABLE_SUPPLY + "." + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + " "
                + "LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + TABLE_SUPPLY + "." + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + " "
                + " WHERE " + TABLE_SUPPLY + "." + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + " = " + supplier.SupplierId + " "
                + " ORDER BY " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + " ASC ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Supply supply = new Supply();
                        supply.SupplyId = Convert.ToInt32((result[COLUMN_SUPPLY_ID]).ToString());
                        supply.Supplier.SupplierId = Convert.ToInt32((result[SupplierDAO.COLUMN_SUPPLIER_ID]).ToString());
                        supply.Supplier.SupplierName = (string)result[SupplierDAO.COLUMN_SUPPLIER_NAME];
                        supply.Farm.FarmId = Convert.ToInt32((result[FarmDAO.COLUMN_FARM_ID]).ToString());
                        supply.Farm.FarmName = (string)result[FarmDAO.COLUMN_FARM_NAME];
                        supply.Product.ProductId = Convert.ToInt32((result[ProductDAO.COLUMN_PRODUCT_ID]).ToString());
                        supply.Product.ProductName = (string)result[ProductDAO.COLUMN_PRODUCT_NAME];
                        list.Add(supply);
                    }
                }
                return list;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return list;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Add new supply data 
        //*******************************
        public bool addData(Supply Supply)
        {
            string insertStmt = "INSERT INTO " + TABLE_SUPPLY + " ("
                    + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + ", "
                    + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + ", "
                    + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + 
                    " ) VALUES ( "
                    + "@" + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + ", "
                    + "@" + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + ", "
                    + "@" + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID 
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID, Supply.Supplier.SupplierId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLY_FRGN_KEY_FARM_ID, Supply.Farm.FarmId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID, Supply.Product.ProductId);
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Delete Supply data (hide)
        //*******************************
        public bool DeleteData(Supply supply)
        {
            String updateStmt = "DELETE FROM " + TABLE_SUPPLY + " WHERE " + COLUMN_SUPPLY_ID + " = " + supply.SupplyId + " ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Update Supply data
        //*******************************
        internal bool UpdateData(Supply supply)
        {
            String updateStmt = "UPDATE " + TABLE_SUPPLY + " SET "
                 + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + " =@" + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + ", "
                 + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + " =@" + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + ", "
                 + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + " =@" + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + " "
                + " WHERE " + COLUMN_SUPPLY_ID + " = " + supply.SupplyId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID, supply.Supplier.SupplierId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLY_FRGN_KEY_FARM_ID, supply.Farm.FarmId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID, supply.Product.ProductId));
                sQLiteCommand.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Add new Supplier data
        //*******************************
        internal bool addNewSupplierData(Supply supply)
        {
            string insertStmt = "INSERT INTO Supplier_For_Insert (FarmId, ProductId, SupplierName, SupplierFirstName, SupplierLastName) VALUES ("
        + "@" + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + ", "
        + "@" + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + ", "
        + "@SupplierName, "
        + "@SupplierFirstName, "
        + "@SupplierLastName "
        + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLY_FRGN_KEY_FARM_ID, supply.Farm.FarmId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID, supply.Product.ProductId);
                sQLiteCommand.Parameters.AddWithValue("@SupplierName", supply.Supplier.SupplierName);
                sQLiteCommand.Parameters.AddWithValue("@SupplierFirstName", supply.Supplier.SupplierFirstName);
                sQLiteCommand.Parameters.AddWithValue("@SupplierLastName", supply.Supplier.SupplierLastName);
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }


        public void CreateTable()
        {
            string createStmt =  "CREATE TABLE IF NOT EXISTS " + TABLE_SUPPLY  + "("
                    + COLUMN_SUPPLY_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + " INTEGER NOT NULL, "
                    + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + " INTEGER NOT NULL, "
                    + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + " INTEGER NOT NULL, "
                    + " FOREIGN KEY (" + COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + ") REFERENCES " + SupplierDAO.TABLE_SUPPLIER + " (" + SupplierDAO.COLUMN_SUPPLIER_ID + "), "
                    + " FOREIGN KEY (" + COLUMN_SUPPLY_FRGN_KEY_FARM_ID + ") REFERENCES " + FarmDAO.TABLE_FARM + " (" + FarmDAO.COLUMN_FARM_ID + "), "
                    + " FOREIGN KEY (" + COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + ") REFERENCES " + ProductDAO.TABLE_PRODUCT + " (" + ProductDAO.COLUMN_PRODUCT_ID + ") "
                    + ")";

            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
