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
        public const string COLUMN_SUPPLIER_IS_EXIST = "is_exist";

        private static SupplierDAO instance = new SupplierDAO();

        private SupplierDAO() : base() {}

        public static SupplierDAO getInstance()
        {
            if (instance == null)
            {
                instance = new SupplierDAO();
            }
            return instance;
        }

        //*************************************************************
        //Get data farm as Dictionary by farm name
        //*************************************************************
        internal Dictionary<string, Supplier> SupplierDictionary()
        {
            Dictionary<string, Supplier> dictionary = new Dictionary<string, Supplier>();

            string selectStmt = "SELECT * FROM " + TABLE_SUPPLIER
                + " WHERE " + COLUMN_SUPPLIER_IS_EXIST + " = 1 "
                + " ORDER BY " + COLUMN_SUPPLIER_NAME + " ASC;";

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
                            SupplierId = Convert.ToInt32((result[COLUMN_SUPPLIER_ID]).ToString()),
                            SupplierName = (string)result[COLUMN_SUPPLIER_NAME],
                            SupplierFirstName = (string)result[COLUMN_SUPPLIER_FIRSTNAME],
                            SupplierLastName = (string)result[COLUMN_SUPPLIER_LASTNAME]
                        };
                        dictionary.Add(supplier.SupplierName, supplier);
                    }
                }
                return dictionary;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return dictionary;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Get all supplier data
        //*******************************
        public List<Supplier> getData()
        {
            List<Supplier> list = new List<Supplier>();
            var selectStmt = "SELECT * FROM " + TABLE_SUPPLIER
                + " WHERE " + COLUMN_SUPPLIER_IS_EXIST + " = 1 "
                + " ORDER BY " + COLUMN_SUPPLIER_NAME + " ASC;";

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
                            SupplierId = Convert.ToInt32((result[COLUMN_SUPPLIER_ID]).ToString()),
                            SupplierName = (string)result[COLUMN_SUPPLIER_NAME],
                            SupplierFirstName = (string)result[COLUMN_SUPPLIER_FIRSTNAME],
                            SupplierLastName = (string)result[COLUMN_SUPPLIER_LASTNAME]
                        };
                        list.Add(supplier);
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
        //Add new supplier data 
        //*******************************
        public bool addData(Supplier supplier)
        {
            string insertStmt = "INSERT INTO " + TABLE_SUPPLIER + " ("
                    + COLUMN_SUPPLIER_NAME + ", "
                    + COLUMN_SUPPLIER_FIRSTNAME + ", "
                    + COLUMN_SUPPLIER_LASTNAME + ", "
                    + COLUMN_SUPPLIER_IS_EXIST +
                    " ) VALUES ( "
                    + "@" + COLUMN_SUPPLIER_NAME + ", "
                    + "@" + COLUMN_SUPPLIER_FIRSTNAME + ", "
                    + "@" + COLUMN_SUPPLIER_LASTNAME + ", "
                    + "@" + COLUMN_SUPPLIER_IS_EXIST
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLIER_NAME, supplier.SupplierName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLIER_FIRSTNAME, supplier.SupplierFirstName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLIER_LASTNAME, supplier.SupplierLastName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SUPPLIER_IS_EXIST, 1);
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
        //Delete supplier data (hide)
        //*******************************
        public bool DeleteData(Supplier supplier)
        {
            string updateStmt = "UPDATE " + TABLE_SUPPLIER + " SET "
                 + COLUMN_SUPPLIER_IS_EXIST + " = 0 "
                + " WHERE " + COLUMN_SUPPLIER_ID + " = " + supplier.SupplierId + " ";

            string deleteStmt = "DELETE FROM " + SupplyDAO.TABLE_SUPPLY
                + " WHERE " + SupplyDAO.COLUMN_SUPPLY_FRGN_KEY_SUPPLIER_ID + " = " + supplier.SupplierId + " ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt + ";" + deleteStmt, mSQLiteConnection);
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
        //Update supplier data
        //*******************************
        internal bool UpdateData(Supplier supplier)
        {
            String updateStmt = "UPDATE " + TABLE_SUPPLIER + " SET "
                 + COLUMN_SUPPLIER_NAME + " =@" + COLUMN_SUPPLIER_NAME + ", "
                 + COLUMN_SUPPLIER_FIRSTNAME + " =@" + COLUMN_SUPPLIER_FIRSTNAME + ", "
                 + COLUMN_SUPPLIER_LASTNAME + " =@" + COLUMN_SUPPLIER_LASTNAME + " "
                + " WHERE " + COLUMN_SUPPLIER_ID + " = " + supplier.SupplierId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLIER_NAME, supplier.SupplierName));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLIER_FIRSTNAME, supplier.SupplierFirstName));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SUPPLIER_LASTNAME, supplier.SupplierLastName));
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

        public void CreateTable()
        {
            String createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_SUPPLIER
                    + "(" + COLUMN_SUPPLIER_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_SUPPLIER_NAME + " TEXT NOT NULL, "
                    + COLUMN_SUPPLIER_FIRSTNAME + " TEXT, "
                    + COLUMN_SUPPLIER_LASTNAME + " TEXT, "
                    + COLUMN_SUPPLIER_IS_EXIST + " INTEGER DEFAULT 1)";

            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

    }
}
