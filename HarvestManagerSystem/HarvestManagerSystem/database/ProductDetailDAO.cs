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
        public const string COLUMN_PRODUCT_DETAIL_ID = "Id";
        public const string COLUMN_PRODUCT_TYPE = "ProductType";
        public const string COLUMN_PRODUCT_CODE = "ProductCode";
        public const string COLUMN_PRODUCT_PRICE_EMPLOYEE = "PriceEmployee";
        public const string COLUMN_PRODUCT_PRICE_COMPANY = "PriceCompany";
        public const string COLUMN_FOREIGN_KEY_PRODUCT_ID = "ProductId";
        public const string COLUMN_PRODUCT_DETAIL_IS_EXIST = "is_exist";

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
            String updateStmt = "UPDATE " + TABLE_PRODUCT_DETAIL + " SET "
                 + COLUMN_PRODUCT_TYPE + " =@" + COLUMN_PRODUCT_TYPE + ", "
                 + COLUMN_PRODUCT_CODE + " =@" + COLUMN_PRODUCT_CODE + ", "
                 + COLUMN_PRODUCT_PRICE_EMPLOYEE + " =@" + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                 + COLUMN_PRODUCT_PRICE_COMPANY + " =@" + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                 + COLUMN_FOREIGN_KEY_PRODUCT_ID + " =@" + COLUMN_FOREIGN_KEY_PRODUCT_ID + " "
                 + " WHERE " + COLUMN_FOREIGN_KEY_PRODUCT_ID + " = " + productDetail.ProductDetailId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_TYPE, productDetail.ProductType));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_CODE, productDetail.ProductCode));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_PRICE_EMPLOYEE, productDetail.PriceEmployee));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCT_PRICE_COMPANY, productDetail.PriceCompany));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_FOREIGN_KEY_PRODUCT_ID, productDetail.PriceCompany));
                sQLiteCommand.ExecuteNonQuery();
                CloseConnection();
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

        //*************************************************************
        //Get productdetail as Dictionary by product type
        //*************************************************************
        internal Dictionary<string, ProductDetail> ProductDetailDictionary(Product product)
        {
            Dictionary<string, ProductDetail> productDictionary = new Dictionary<string, ProductDetail>();

            string selectStmt = "SELECT * FROM " + TABLE_PRODUCT_DETAIL
                + " WHERE " + COLUMN_FOREIGN_KEY_PRODUCT_ID + " = " + product.ProductId
                + " AND " + COLUMN_PRODUCT_DETAIL_IS_EXIST + " = " + 1
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
                        productDetail.ProductDetailId = Convert.ToInt32((result["Id"]).ToString());
                        productDetail.ProductType = (string)result["ProductType"];
                        productDetail.ProductCode = (string)result["ProductCode"];
                        productDetail.PriceEmployee = Convert.ToDouble((result["PriceEmployee"]).ToString());
                        productDetail.PriceCompany = Convert.ToDouble((result["PriceCompany"]).ToString());
                        productDetail.Product.ProductId = Convert.ToInt32((result["ProductId"]).ToString());
                        productDictionary.Add(productDetail.ProductType, productDetail);
                    }
                }
                CloseConnection();
                return productDictionary;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
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
                + " AND " + COLUMN_PRODUCT_DETAIL_IS_EXIST + " = " + 1
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
                        productDetail.ProductDetailId = Convert.ToInt32((result["Id"]).ToString());
                        productDetail.ProductType = (string)result["ProductType"];
                        productDetail.ProductCode = (string)result["ProductCode"];
                        productDetail.PriceEmployee = Convert.ToDouble((result["PriceEmployee"]).ToString());
                        productDetail.PriceCompany = Convert.ToDouble((result["PriceCompany"]).ToString());
                        productDetail.Product.ProductId = Convert.ToInt32((result["ProductId"]).ToString());
                        list.Add(productDetail);
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
        //Get all product data
        //*******************************
        public List<ProductDetail> getData()
        {
            List<ProductDetail> list = new List<ProductDetail>();
            string selectStmt = "SELECT * FROM " + TABLE_PRODUCT_DETAIL
                + " WHERE " + COLUMN_PRODUCT_DETAIL_IS_EXIST + " = " + 1
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
                        productDetail.ProductDetailId = Convert.ToInt32((result["Id"]).ToString());
                        productDetail.ProductType = (string)result["ProductType"];
                        productDetail.ProductCode = (string)result["ProductCode"];
                        productDetail.PriceEmployee = Convert.ToDouble((result["PriceEmployee"]).ToString());
                        productDetail.PriceCompany = Convert.ToDouble((result["PriceCompany"]).ToString());
                        productDetail.Product.ProductId = Convert.ToInt32((result["ProductId"]).ToString());
                        list.Add(productDetail);
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

        internal bool addNewProductDetail(ProductDetail productDetail)
        {
            string insertStmt = "INSERT INTO Product_For_Insert (ProductType, ProductCode, PriceEmployee, PriceCompany, ProductName) VALUES ("
                    + "@" + COLUMN_PRODUCT_TYPE + ", "
                    + "@" + COLUMN_PRODUCT_CODE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                    + "@ProductName "
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_TYPE, productDetail.ProductType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_CODE, productDetail.ProductCode);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_EMPLOYEE, productDetail.PriceEmployee);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_COMPANY, productDetail.PriceCompany);
                sQLiteCommand.Parameters.AddWithValue("@ProductName", productDetail.Product.ProductName);
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
        //Add new product data 
        //*******************************
        public bool addData(ProductDetail productDetail)
        {
            String insertStmt = "INSERT INTO " + TABLE_PRODUCT_DETAIL + " ("
                    + COLUMN_PRODUCT_TYPE + ", "
                    + COLUMN_PRODUCT_CODE + ", "
                    + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                    + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                    + COLUMN_FOREIGN_KEY_PRODUCT_ID + ", "
                    + COLUMN_PRODUCT_DETAIL_IS_EXIST +
                    ") VALUES ( "
                    + "@" + COLUMN_PRODUCT_TYPE + ", "
                    + "@" + COLUMN_PRODUCT_CODE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_EMPLOYEE + ", "
                    + "@" + COLUMN_PRODUCT_PRICE_COMPANY + ", "
                    + "@" + COLUMN_FOREIGN_KEY_PRODUCT_ID + ", "
                    + "@" + COLUMN_PRODUCT_DETAIL_IS_EXIST + ""
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_TYPE, productDetail.ProductType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_CODE, productDetail.ProductCode);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_EMPLOYEE, productDetail.PriceEmployee);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_PRICE_COMPANY, productDetail.PriceCompany);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_FOREIGN_KEY_PRODUCT_ID, productDetail.Product.ProductId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_PRODUCT_DETAIL_IS_EXIST, 1);
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
        //Delete product data (hide)
        //*******************************
        public bool DeleteData(ProductDetail productDetail)
        {
            String updateStmt = "UPDATE " + TABLE_PRODUCT_DETAIL + " SET "
                 + COLUMN_PRODUCT_DETAIL_IS_EXIST + " = 0 "
                + " WHERE " + COLUMN_PRODUCT_DETAIL_ID + " = " + productDetail.ProductDetailId + " ";

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
            String createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_PRODUCT_DETAIL
                   + "(" + COLUMN_PRODUCT_DETAIL_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_PRODUCT_TYPE + " TEXT NOT NULL, "
                    + COLUMN_PRODUCT_CODE + " TEXT NOT NULL UNIQUE, "
                    + COLUMN_PRODUCT_PRICE_EMPLOYEE + " REAL NOT NULL DEFAULT 0, "
                    + COLUMN_PRODUCT_PRICE_COMPANY + " REAL NOT NULL DEFAULT 0, "
                    + COLUMN_FOREIGN_KEY_PRODUCT_ID + " INTEGER NOT NULL, "
                    + COLUMN_PRODUCT_DETAIL_IS_EXIST + " INTEGER DEFAULT 1, "
                    + "FOREIGN KEY (" + COLUMN_FOREIGN_KEY_PRODUCT_ID + ") REFERENCES " + ProductDAO.TABLE_PRODUCT + " (" + ProductDAO.COLUMN_PRODUCT_ID + ") "
                    + ")";


            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
            MessageBox.Show("Create table");

        }
    }
}
