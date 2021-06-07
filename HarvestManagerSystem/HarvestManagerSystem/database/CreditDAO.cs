using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.database
{
    class CreditDAO:DAO
    {
        public const string TABLE_CREDIT = "Credit";
        public const string COLUMN_CREDIT_ID = "CreditId";
        public const string COLUMN_CREDIT_DATE = "CreditDate";
        public const string COLUMN_CREDIT_AMOUNT = "CreditAmount";
        public const string COLUMN_CREDIT_EMPLOYEE_ID = "EmployeeId";

        private static CreditDAO instance = new CreditDAO();

        private CreditDAO() : base() { }

        public static CreditDAO getInstance()
        {
            if (instance == null)
                instance = new CreditDAO();
            return instance;
        }

        public List<Credit> getData()
        {
            List<Credit> list = new List<Credit>();
            var selectStmt = "SELECT "
                + TABLE_CREDIT + "." + COLUMN_CREDIT_ID + ", "
                + TABLE_CREDIT + "." + COLUMN_CREDIT_DATE + ", "
                + TABLE_CREDIT + "." + COLUMN_CREDIT_AMOUNT + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + " "
                + " FROM " + TABLE_CREDIT
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + TABLE_CREDIT + "." + COLUMN_CREDIT_EMPLOYEE_ID
                + " WHERE " + TABLE_CREDIT + "." + COLUMN_CREDIT_AMOUNT + " > 0 "
                + " ORDER BY " + COLUMN_CREDIT_DATE + " DESC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Credit credit = new Credit();
                        credit.CreditId = result.GetInt32(result.GetOrdinal(COLUMN_CREDIT_ID));
                        credit.CreditDate = result.GetDateTime(result.GetOrdinal(COLUMN_CREDIT_DATE));
                        credit.CreditAmount = result.GetDouble(result.GetOrdinal(COLUMN_CREDIT_AMOUNT));
                        credit.Employee.EmployeeId = result.GetInt32(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_ID));
                        credit.Employee.FirstName = result.GetString(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME));
                        credit.Employee.LastName = result.GetString(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME));
                        list.Add(credit);
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

        public void Add(Credit credit)
        {
            string insertStmt = "INSERT INTO " + TABLE_CREDIT + " ("
                    + COLUMN_CREDIT_DATE + ", "
                    + COLUMN_CREDIT_AMOUNT + ", "
                    + COLUMN_CREDIT_EMPLOYEE_ID +
                    " ) VALUES ( "
                    + "@" + COLUMN_CREDIT_DATE + ", "
                    + "@" + COLUMN_CREDIT_AMOUNT + ", "
                    + "@" + COLUMN_CREDIT_EMPLOYEE_ID 
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_CREDIT_DATE, credit.CreditDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_CREDIT_AMOUNT, credit.CreditAmount);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_CREDIT_EMPLOYEE_ID, credit.Employee.EmployeeId);
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


        internal void Update(Credit credit)
        {
            string updateStmt = "UPDATE " + TABLE_CREDIT + " SET "
                 + COLUMN_CREDIT_DATE + " =@" + COLUMN_CREDIT_DATE + ", "
                 + COLUMN_CREDIT_AMOUNT + " =@" + COLUMN_CREDIT_AMOUNT + " "
                + " WHERE " + COLUMN_CREDIT_ID + " = " + credit.CreditId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_CREDIT_DATE, credit.CreditDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_CREDIT_AMOUNT, credit.CreditAmount));
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

        public void Delete(Credit credit)
        {
            string updateStmt = "UPDATE " + TABLE_CREDIT + " SET "
                 + COLUMN_CREDIT_AMOUNT + " = 0 "
                + " WHERE " + COLUMN_CREDIT_ID + " = " + credit.CreditId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
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
