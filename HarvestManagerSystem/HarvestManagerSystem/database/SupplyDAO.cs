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
                instance = new SupplyDAO();
            return instance;
        }

        public List<Supply> ListSupply(Supplier supplier)
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
                        supply.SupplyId = result.GetInt32(result.GetOrdinal(COLUMN_SUPPLY_ID)); 
                        supply.Supplier.SupplierId = result.GetInt32(result.GetOrdinal(SupplierDAO.COLUMN_SUPPLIER_ID)); 
                        supply.Supplier.SupplierName = result.GetString(result.GetOrdinal(SupplierDAO.COLUMN_SUPPLIER_NAME)); 
                        supply.Farm.FarmId = result.GetInt32(result.GetOrdinal(FarmDAO.COLUMN_FARM_ID)); 
                        supply.Farm.FarmName = result.GetString(result.GetOrdinal(FarmDAO.COLUMN_FARM_NAME)); 
                        supply.Product.ProductId = result.GetInt32(result.GetOrdinal(ProductDAO.COLUMN_PRODUCT_ID)); 
                        supply.Product.ProductName = result.GetString(result.GetOrdinal(ProductDAO.COLUMN_PRODUCT_NAME)); 
                        list.Add(supply);
                    }
                }
                return list;
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Add(Supply Supply)
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
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(Supply supply)
        {
            string deleteStmt = "DELETE FROM " + TABLE_SUPPLY + " WHERE " + COLUMN_SUPPLY_ID + " = " + supply.SupplyId + " ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(deleteStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        internal void Update(Supply supply)
        {
            var updateStmt = "UPDATE " + TABLE_SUPPLY + " SET "
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
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
