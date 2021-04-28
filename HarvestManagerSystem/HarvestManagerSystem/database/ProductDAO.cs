using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using HarvestManagerSystem.model;


namespace HarvestManagerSystem.database
{
    class ProductDAO :DAO
    {
        public const string TABLE_PRODUCT = "Product";
        public const string COLUMN_PRODUCT_ID = "ProductId";
        public const string COLUMN_PRODUCT_NAME = "ProductName";

        private static ProductDAO instance = new ProductDAO();

        private ProductDAO() : base()
        {
        }

        public static ProductDAO getInstance()
        {
            if (instance == null)
            {
                instance = new ProductDAO();
            }
            return instance;
        }


        //*******************************
        //Update product data
        //*******************************
        internal bool UpdateData(Product product)
        {
            String updateStmt = "UPDATE " + TABLE_PRODUCT + " SET "
                 + COLUMN_PRODUCT_NAME + " =@" + COLUMN_PRODUCT_NAME + " "
                + " WHERE " + COLUMN_PRODUCT_ID + " = " + product.ProductId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_NAME, product.ProductName));
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Product Not Updated: " + e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*************************************************************
        //Get data product as Dictionary by product name
        //*************************************************************
        internal Dictionary<string, Product> ProductDictionary()
        {
            Dictionary<string, Product> productDictionary = new Dictionary<string, Product>();

            string selectStmt = "SELECT * FROM " + TABLE_PRODUCT + " ORDER BY " + COLUMN_PRODUCT_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Product product = new Product();
                        product.ProductId = Convert.ToInt32((result[COLUMN_PRODUCT_ID]).ToString());
                        product.ProductName = (string)result[COLUMN_PRODUCT_NAME];
                        productDictionary.Add(product.ProductName, product);
                    }
                }
                return productDictionary;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return productDictionary;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Get all product data
        //*******************************
        public List<Product> getData()
        {
            List<Product> list = new List<Product>();
            string selectStmt = "SELECT * FROM " + TABLE_PRODUCT + " ORDER BY " + COLUMN_PRODUCT_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Product product = new Product();
                        product.ProductId = Convert.ToInt32((result[COLUMN_PRODUCT_ID]).ToString());
                        product.ProductName = (string)result[COLUMN_PRODUCT_NAME];

                        list.Add(product);
                    }
                }
                CloseConnection();
                return list;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                return list;
            }
        }


        //*******************************
        //Delete product data
        //*******************************
        public bool DeleteData(Product product)
        {
            string updateStmt = "DELETE FROM " + TABLE_PRODUCT + " WHERE " + COLUMN_PRODUCT_ID + " = " + product.ProductId + " ";

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

        public void CreateTable()
        {
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_PRODUCT
                    + "(" + COLUMN_PRODUCT_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_PRODUCT_NAME + " TEXT NOT NULL)";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
            MessageBox.Show("Create table");

        }
    }
}
