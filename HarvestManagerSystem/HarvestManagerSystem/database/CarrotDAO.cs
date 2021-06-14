using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using HarvestManagerSystem.Models;

namespace HarvestManagerSystem.database
{
    class CarrotDAO:DAO
    {
        public const string TABLE_CARROT = "Carrots";
        public const string COLUMN_CARROT_ID = "Id";
        public const string COLUMN_CARROT_TYPE = "Type";
        public const string COLUMN_CARROT_NAME = "Name";
        public const string COLUMN_CARROT_EMPLOYEE_PRICE = "EmployeePrice";
        public const string COLUMN_CARROT_COMPANY_PRICE = "CompanyPrice";

        private static CarrotDAO instance = null;

        private CarrotDAO() : base(){}

        public static CarrotDAO getInstance()
        {
            if (instance == null)
                instance = new CarrotDAO();
            return instance;
        }

        public void UpdatePrice(Carrot carrot)
        {
            string updateStmt = "UPDATE " + TABLE_CARROT + " SET "
                 + COLUMN_CARROT_EMPLOYEE_PRICE + " =@" + COLUMN_CARROT_EMPLOYEE_PRICE + ", "
                 + COLUMN_CARROT_COMPANY_PRICE + " =@" + COLUMN_CARROT_COMPANY_PRICE + " "
                 + " WHERE " + COLUMN_CARROT_ID + " = " + carrot.ProductId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_CARROT_EMPLOYEE_PRICE, carrot.EmployeePrice));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_CARROT_COMPANY_PRICE, carrot.CompanyPrice));
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

        public List<Carrot> CarrotList()
        {
            string selectStmt = "SELECT * FROM " + TABLE_CARROT + " ORDER BY " + COLUMN_CARROT_ID + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return GetCarrotListFromResult(result);
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

        private static List<Carrot> GetCarrotListFromResult(SQLiteDataReader result)
        {
            List<Carrot> list = new List<Carrot>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Carrot carrot = new Carrot();
                    carrot.ProductId = result.GetInt32(result.GetOrdinal(COLUMN_CARROT_ID));
                    carrot.HarvestType = result.GetInt32(result.GetOrdinal(COLUMN_CARROT_TYPE));
                    carrot.ProductName = result.GetString(result.GetOrdinal(COLUMN_CARROT_NAME));
                    carrot.EmployeePrice = result.GetDouble(result.GetOrdinal(COLUMN_CARROT_EMPLOYEE_PRICE));
                    carrot.CompanyPrice = result.GetDouble(result.GetOrdinal(COLUMN_CARROT_COMPANY_PRICE));
                    list.Add(carrot);
                }
            }
            return list;
        }
    }
}
