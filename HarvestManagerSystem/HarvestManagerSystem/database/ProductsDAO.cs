using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using HarvestManagerSystem.Models;

namespace HarvestManagerSystem.database
{
    class ProductsDAO:DAO
    {
        public const string TABLE_PRODUCTS = "Products";
        public const string COLUMN_PRODUCTS_ID = "Id";
        public const string COLUMN_PRODUCTS_NAME = "Name";
        public const string COLUMN_PRODUCTS_EMPLOYEE_PRICE = "EmployeePrice";
        public const string COLUMN_PRODUCTS_COMPANY_PRICE = "CompanyPrice";

        private static ProductsDAO instance = null;

        private ProductsDAO() : base() { }

        public static ProductsDAO getInstance()
        {
            if (instance == null)
                instance = new ProductsDAO();
            return instance;
        }

        public void UpdatePrice(Products product)
        {
            string updateStmt = "UPDATE " + TABLE_PRODUCTS + " SET "
                 + COLUMN_PRODUCTS_EMPLOYEE_PRICE + " =@" + COLUMN_PRODUCTS_EMPLOYEE_PRICE + ", "
                 + COLUMN_PRODUCTS_COMPANY_PRICE + " =@" + COLUMN_PRODUCTS_COMPANY_PRICE + " "
                 + " WHERE " + COLUMN_PRODUCTS_ID + " = " + product.ProductId + " ";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTS_EMPLOYEE_PRICE, product.EmployeePrice));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PRODUCTS_COMPANY_PRICE, product.CompanyPrice));
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

        public List<Products> ProductsList()
        {
            string selectStmt = "SELECT * FROM " + TABLE_PRODUCTS + " ORDER BY " + COLUMN_PRODUCTS_ID + " ASC;";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return GetListFromResult(result);
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

        private static List<Products> GetListFromResult(SQLiteDataReader result)
        {
            List<Products> list = new List<Products>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Products product = new Products();
                    product.ProductId = result.GetInt32(result.GetOrdinal(COLUMN_PRODUCTS_ID));
                    product.ProductName = result.GetString(result.GetOrdinal(COLUMN_PRODUCTS_NAME));
                    product.EmployeePrice = result.GetDouble(result.GetOrdinal(COLUMN_PRODUCTS_EMPLOYEE_PRICE));
                    product.CompanyPrice = result.GetDouble(result.GetOrdinal(COLUMN_PRODUCTS_COMPANY_PRICE));
                    list.Add(product);
                }
            }
            return list;
        }

    }
}
