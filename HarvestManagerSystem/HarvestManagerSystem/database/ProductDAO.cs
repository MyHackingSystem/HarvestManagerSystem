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

        public void Update(Product product)
        {
            var updateStmt = "UPDATE " + TABLE_PRODUCT + " SET "
                 + COLUMN_PRODUCT_NAME + " =@" + COLUMN_PRODUCT_NAME + " "
                + " WHERE " + COLUMN_PRODUCT_ID + " = " + product.ProductId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_NAME, product.ProductName));
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
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Product> ProductList()
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
                        product.ProductId = result.GetInt32(result.GetOrdinal(COLUMN_PRODUCT_ID));
                        product.ProductName = result.GetString(result.GetOrdinal(COLUMN_PRODUCT_NAME));
                        list.Add(product);
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

        public void Delete(Product product)
        {
            SQLiteTransaction transaction = null;
            SQLiteCommand sQLiteCommand = null;

            var deleteDetail = "DELETE FROM " + TABLE_PRODUCT + " WHERE " + COLUMN_PRODUCT_ID + " = " + product.ProductId + " ";
            var deleteProduct = "DELETE FROM " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " WHERE " + ProductDetailDAO.COLUMN_FOREIGN_KEY_PRODUCT_ID + " = " + product.ProductId + " ";

            try
            {
                OpenConnection();
                transaction = mSQLiteConnection.BeginTransaction();

                sQLiteCommand = new SQLiteCommand(deleteDetail, mSQLiteConnection);
                sQLiteCommand.ExecuteNonQuery();

                sQLiteCommand = new SQLiteCommand(deleteProduct, mSQLiteConnection);
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

    }
}
