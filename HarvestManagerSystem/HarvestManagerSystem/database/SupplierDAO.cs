using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.database
{
    class SupplierDAO: DAO
    {
        public const string TABLE_SUPPLIER = "Supplier";
        public const string COLUMN_SUPPLIER_ID = "SupplierId";
        public const string COLUMN_SUPPLIER_NAME = "SupplierName";
        public const string COLUMN_SUPPLIER_FIRSTNAME = "SupplierFirstName";
        public const string COLUMN_SUPPLIER_LASTNAME = "SupplierLastName";

        private static SupplierDAO instance = new SupplierDAO();

        private SupplierDAO() : base() {}

        public static SupplierDAO getInstance()
        {
            if (instance == null)
                instance = new SupplierDAO();
            return instance;
        }

        internal Dictionary<string, Supplier> SupplierDictionary()
        {
            Dictionary<string, Supplier> dictionary = new Dictionary<string, Supplier>();

            string selectStmt = "SELECT * FROM " + TABLE_SUPPLIER + " ORDER BY " + COLUMN_SUPPLIER_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Supplier supplier = new Supplier()
                        {
                            SupplierId = result.GetInt32(result.GetOrdinal(COLUMN_SUPPLIER_ID)),
                            SupplierName = result.GetString(result.GetOrdinal(COLUMN_SUPPLIER_NAME)),
                            SupplierFirstName = result.GetString(result.GetOrdinal(COLUMN_SUPPLIER_FIRSTNAME)), 
                            SupplierLastName = result.GetString(result.GetOrdinal(COLUMN_SUPPLIER_LASTNAME))
                        };
                        dictionary.Add(supplier.SupplierName, supplier);
                    }
                }
                return dictionary;
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

        public List<Supplier> ListSupplier()
        {
            List<Supplier> list = new List<Supplier>();
            var selectStmt = "SELECT * FROM " + TABLE_SUPPLIER + " ORDER BY " + COLUMN_SUPPLIER_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Supplier supplier = new Supplier()
                        {
                            SupplierId = result.GetInt32(result.GetOrdinal(COLUMN_SUPPLIER_ID)),
                            SupplierName = result.GetString(result.GetOrdinal(COLUMN_SUPPLIER_NAME)),
                            SupplierFirstName = result.GetString(result.GetOrdinal(COLUMN_SUPPLIER_FIRSTNAME)), 
                            SupplierLastName = result.GetString(result.GetOrdinal(COLUMN_SUPPLIER_LASTNAME))
                        };
                        list.Add(supplier);
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

        public void addNewSupplier(Supply supply)
        {
            SQLiteTransaction transaction = null;
            SQLiteCommand sQLiteCommand = null;

            string insertSupplier = "INSERT INTO " + TABLE_SUPPLIER + " ("
                    + COLUMN_SUPPLIER_NAME + ", "
                    + COLUMN_SUPPLIER_FIRSTNAME + ", "
                    + COLUMN_SUPPLIER_LASTNAME + " "
                    + ") VALUES ( "
                    + "@" + COLUMN_SUPPLIER_NAME + ", "
                    + "@" + COLUMN_SUPPLIER_FIRSTNAME + ", "
                    + "@" + COLUMN_SUPPLIER_LASTNAME + " "
                    + " )";

            string insertSeason = "INSERT INTO " + SupplyDAO.TABLE_SUPPLY + " ("
                    + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + ", "
                    + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_FARM_ID + ", "
                    + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + " "
                    + ") VALUES ( "
                    + "@" + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + ", "
                    + "@" + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_FARM_ID + ", "
                    + "@" + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID + " "
                    + " )";

            try
            {
                OpenConnection();
                transaction = mSQLiteConnection.BeginTransaction();

                sQLiteCommand = new SQLiteCommand(insertSupplier, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLIER_NAME, supply.Supplier.SupplierName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLIER_FIRSTNAME, supply.Supplier.SupplierFirstName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLIER_LASTNAME, supply.Supplier.SupplierLastName);
                sQLiteCommand.ExecuteNonQuery();

                long lastSupplierRowId;
                lastSupplierRowId = mSQLiteConnection.LastInsertRowId;

                sQLiteCommand = new SQLiteCommand(insertSeason, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID, lastSupplierRowId);
                sQLiteCommand.Parameters.AddWithValue(SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_FARM_ID, supply.Farm.FarmId);
                sQLiteCommand.Parameters.AddWithValue(SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_PRODUCT_ID, supply.Product.ProductId);

                sQLiteCommand.ExecuteNonQuery();
                transaction.Commit();
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

        internal void Update(Supplier supplier)
        {
            var updateStmt = "UPDATE " + TABLE_SUPPLIER + " SET "
                 + COLUMN_SUPPLIER_NAME + " =@" + COLUMN_SUPPLIER_NAME + ", "
                 + COLUMN_SUPPLIER_FIRSTNAME + " =@" + COLUMN_SUPPLIER_FIRSTNAME + ", "
                 + COLUMN_SUPPLIER_LASTNAME + " =@" + COLUMN_SUPPLIER_LASTNAME + " "
                + " WHERE " + COLUMN_SUPPLIER_ID + " = " + supplier.SupplierId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLIER_NAME, supplier.SupplierName.Trim().ToUpper()));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLIER_FIRSTNAME, supplier.SupplierFirstName.Trim().ToUpper()));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLIER_LASTNAME, supplier.SupplierLastName.Trim().ToUpper()));
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

        public void Delete(Supplier supplier)
        {
            string deleteSupplierStmt = "DELETE FROM " + TABLE_SUPPLIER + " WHERE " + COLUMN_SUPPLIER_ID + " = " + supplier.SupplierId + " ";
            string deleteSupplyStmt = "DELETE FROM " + SupplyDAO.TABLE_SUPPLY + " WHERE " + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + " = " + supplier.SupplierId + " ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(deleteSupplierStmt + ";" + deleteSupplyStmt, mSQLiteConnection);
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

    }
}
