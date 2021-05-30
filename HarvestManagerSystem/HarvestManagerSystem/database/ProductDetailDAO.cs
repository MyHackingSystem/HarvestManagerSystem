using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.database
{
    class ProductDetailDAO : DAO
    {

        public const string TABLE_PRODUCT_DETAIL = "ProductDetail";
        public const string COLUMN_PRODUCT_DETAIL_ID = "ProductDetailId";
        public const string COLUMN_PRODUCT_TYPE = "ProductType";
        public const string COLUMN_PRODUCT_PRICE_EMPLOYEE = "PriceEmployee";
        public const string COLUMN_PRODUCT_PRICE_COMPANY = "PriceCompany";
        public const string COLUMN_FOREIGN_KEY_PRODUCT_ID = "ProductId";

        private static ProductDetailDAO instance = new ProductDetailDAO();

        private ProductDetailDAO() : base()
        {
        }

        public static ProductDetailDAO getInstance()
        {
            if (instance == null)
            {
                instance = new ProductDetailDAO();
            }
            return instance;
        }

        //*******************************
        //Update product data
        //*******************************
        internal bool UpdateData(ProductDetail productDetail)
        {
            string updateStmt = "UPDATE " + TABLE_PRODUCT_DETAIL + " SET "
                 + COLUMN_PRODUCT_TYPE + " =@" + COLUMN_PRODUCT_TYPE + ", "
                 + COLUMN_PRODUCT_PRICE_EMPLOYEE + " =@" + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                 + COLUMN_PRODUCT_PRICE_COMPANY + " =@" + COLUMN_PRODUCT_PRICE_COMPANY + " "
                 + " WHERE " + COLUMN_PRODUCT_DETAIL_ID + " = " + productDetail.ProductDetailId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_TYPE, productDetail.ProductType));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_PRICE_EMPLOYEE, productDetail.PriceEmployee));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_PRICE_COMPANY, productDetail.PriceCompany));
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*************************************************************
        //Get productdetail as Dictionary by product type
        //*************************************************************
        internal Dictionary<string, ProductDetail> ProductTypeDictionary(Product product)
        {
            Dictionary<string, ProductDetail> productDictionary = new Dictionary<string, ProductDetail>();

            string selectStmt = "SELECT * FROM " + TABLE_PRODUCT_DETAIL
                + " WHERE " + COLUMN_FOREIGN_KEY_PRODUCT_ID + " = " + product.ProductId
                + " ORDER BY " + COLUMN_PRODUCT_TYPE + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        ProductDetail productDetail = new ProductDetail();
                        productDetail.ProductDetailId = Convert.ToInt32((result[COLUMN_PRODUCT_DETAIL_ID]).ToString());
                        productDetail.ProductType = (string)result[COLUMN_PRODUCT_TYPE];
                        productDetail.PriceEmployee = Convert.ToDouble((result[COLUMN_PRODUCT_PRICE_EMPLOYEE]).ToString());
                        productDetail.PriceCompany = Convert.ToDouble((result[COLUMN_PRODUCT_PRICE_COMPANY]).ToString());
                        productDetail.Product.ProductId = Convert.ToInt32((result[COLUMN_FOREIGN_KEY_PRODUCT_ID]).ToString());
                        productDictionary.Add(productDetail.ProductType, productDetail);
                    }
                }
                CloseConnection();
                return productDictionary;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return productDictionary;
            }
        }

        //*******************************
        //Get all product data
        //*******************************
        public List<ProductDetail> getData(Product product)
        {
            List<ProductDetail> list = new List<ProductDetail>();
            string selectStmt = "SELECT * FROM " + TABLE_PRODUCT_DETAIL
                + " WHERE " + COLUMN_FOREIGN_KEY_PRODUCT_ID + " = " + product.ProductId
                + " ORDER BY " + COLUMN_PRODUCT_TYPE + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        ProductDetail productDetail = new ProductDetail();
                        productDetail.ProductDetailId = Convert.ToInt32((result[COLUMN_PRODUCT_DETAIL_ID]).ToString());
                        productDetail.ProductType = (string)result[COLUMN_PRODUCT_TYPE];
                        productDetail.PriceEmployee = Convert.ToDouble((result[COLUMN_PRODUCT_PRICE_EMPLOYEE]).ToString());
                        productDetail.PriceCompany = Convert.ToDouble((result[COLUMN_PRODUCT_PRICE_COMPANY]).ToString());
                        productDetail.Product.ProductId = Convert.ToInt32((result[COLUMN_FOREIGN_KEY_PRODUCT_ID]).ToString());
                        list.Add(productDetail);
                    }
                }
                CloseConnection();
                return list;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return list;
            }
        }

        //*******************************
        //Get all product data
        //*******************************
        public List<ProductDetail> getData()
        {
            List<ProductDetail> list = new List<ProductDetail>();
            string selectStmt = "SELECT * FROM " + TABLE_PRODUCT_DETAIL
                + " ORDER BY " + COLUMN_PRODUCT_TYPE + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        ProductDetail productDetail = new ProductDetail();
                        productDetail.ProductDetailId = Convert.ToInt32((result[COLUMN_PRODUCT_DETAIL_ID]).ToString());
                        productDetail.ProductType = (string)result[COLUMN_PRODUCT_TYPE];
                        productDetail.PriceEmployee = Convert.ToDouble((result[COLUMN_PRODUCT_PRICE_EMPLOYEE]).ToString());
                        productDetail.PriceCompany = Convert.ToDouble((result[COLUMN_PRODUCT_PRICE_COMPANY]).ToString());
                        productDetail.Product.ProductId = Convert.ToInt32((result[COLUMN_FOREIGN_KEY_PRODUCT_ID]).ToString());
                        list.Add(productDetail);
                    }
                }
                CloseConnection();
                return list;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return list;
            }
        }

        internal bool addNewProductDetail(ProductDetail productDetail)
        {
            SQLiteTransaction transaction = null;
            SQLiteCommand sQLiteCommand = null;

            string insertProduct = "INSERT INTO " + ProductDAO.TABLE_PRODUCT + " (" + ProductDAO.COLUMN_PRODUCT_NAME + ") VALUES ( @" + ProductDAO.COLUMN_PRODUCT_NAME + " )";

            string insertProductDetail = "INSERT INTO " + TABLE_PRODUCT_DETAIL + " ("
                    + COLUMN_PRODUCT_TYPE + ", "
                    + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                    + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                    + COLUMN_FOREIGN_KEY_PRODUCT_ID + " "
                    + ") VALUES ( "
                    + "@" + COLUMN_PRODUCT_TYPE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                    + "@" + COLUMN_FOREIGN_KEY_PRODUCT_ID + " "
                    + " )";

            try
            {
                OpenConnection();
                transaction = mSQLiteConnection.BeginTransaction();

                sQLiteCommand = new SQLiteCommand(insertProduct, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(ProductDAO.COLUMN_PRODUCT_NAME, productDetail.Product.ProductName);
                sQLiteCommand.ExecuteNonQuery();

                long rowProductId;
                rowProductId = mSQLiteConnection.LastInsertRowId;

                sQLiteCommand = new SQLiteCommand(insertProductDetail, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_TYPE, productDetail.ProductType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_EMPLOYEE, productDetail.PriceEmployee);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_COMPANY, productDetail.PriceCompany);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_FOREIGN_KEY_PRODUCT_ID, rowProductId);

                sQLiteCommand.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Le produit n'est pas ajouté à la base de données, erreur: " + e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Add new product data 
        //*******************************
        public bool addData(ProductDetail productDetail)
        {
            String insertStmt = "INSERT INTO " + TABLE_PRODUCT_DETAIL + " ("
                    + COLUMN_PRODUCT_TYPE + ", "
                    + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                    + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                    + COLUMN_FOREIGN_KEY_PRODUCT_ID + " "
                    + ") VALUES ( "
                    + "@" + COLUMN_PRODUCT_TYPE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                    + "@" + COLUMN_FOREIGN_KEY_PRODUCT_ID + " "
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_TYPE, productDetail.ProductType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_EMPLOYEE, productDetail.PriceEmployee);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_COMPANY, productDetail.PriceCompany);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_FOREIGN_KEY_PRODUCT_ID, productDetail.Product.ProductId);
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Le produit n'est pas ajouté à la base de données, erreur: " + e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }


        //*******************************
        //Delete product data
        //*******************************
        public bool DeleteData(ProductDetail productDetail)
        {
            string deleteStmt = "DELETE FROM " + TABLE_PRODUCT_DETAIL + " WHERE " + COLUMN_PRODUCT_DETAIL_ID + " = " + productDetail.ProductDetailId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(deleteStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Delete product data
        //*******************************
        public void Delete(ProductDetail productDetail)
        {
            var deleteStmt = "DELETE FROM " + TABLE_PRODUCT_DETAIL + " WHERE " + COLUMN_PRODUCT_DETAIL_ID + " = " + productDetail.ProductDetailId + " ";

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

        public void CreateTable()
        {
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_PRODUCT_DETAIL
                   + "(" + COLUMN_PRODUCT_DETAIL_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_PRODUCT_TYPE + " TEXT NOT NULL UNIQUE, "
                    + COLUMN_PRODUCT_PRICE_EMPLOYEE + " REAL NOT NULL DEFAULT 0, "
                    + COLUMN_PRODUCT_PRICE_COMPANY + " REAL NOT NULL DEFAULT 0, "
                    + COLUMN_FOREIGN_KEY_PRODUCT_ID + " INTEGER NOT NULL, "
                    + " FOREIGN KEY (" + COLUMN_FOREIGN_KEY_PRODUCT_ID + ") REFERENCES " + ProductDAO.TABLE_PRODUCT + " (" + ProductDAO.COLUMN_PRODUCT_ID + ") "
                    + ")";


            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
            MessageBox.Show("Create table");

        }

    }
}
