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
            {
                instance = new CreditDAO();
            }
            return instance;
        }


        //*******************************
        //Get redit data
        //*******************************
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
                        credit.CreditId = Convert.ToInt32((result[COLUMN_CREDIT_ID]).ToString());
                        credit.CreditDate = (DateTime)result[COLUMN_CREDIT_DATE];
                        credit.CreditAmount = Convert.ToDouble((result[COLUMN_CREDIT_AMOUNT]).ToString());
                        credit.Employee.EmployeeId = Convert.ToInt32((result[EmployeeDAO.COLUMN_EMPLOYEE_ID]).ToString());
                        credit.Employee.FirstName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME];
                        credit.Employee.LastName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME];
                        list.Add(credit);
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
        //Add new credit data 
        //*******************************
        public bool addData(Credit credit)
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
        //Update credit data
        //*******************************
        internal bool UpdateData(Credit credit)
        {
            String updateStmt = "UPDATE " + TABLE_CREDIT + " SET "
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
        //Delete credit data (hide)
        //*******************************
        public bool DeleteData(Credit credit)
        {
            string updateStmt = "UPDATE " + TABLE_CREDIT + " SET "
                 + COLUMN_CREDIT_AMOUNT + " = 0 "
                + " WHERE " + COLUMN_CREDIT_ID + " = " + credit.CreditId + " ";

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
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_CREDIT + "("
                    + COLUMN_CREDIT_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_CREDIT_DATE + " DATE NOT NULL, "
                    + COLUMN_CREDIT_AMOUNT + " REAL NOT NULL DEFAULT 0, "
                    + COLUMN_CREDIT_EMPLOYEE_ID + " INTEGER NOT NULL, "
                    + " FOREIGN KEY (" + COLUMN_CREDIT_EMPLOYEE_ID + ") REFERENCES " + EmployeeDAO.TABLE_EMPLOYEE + " (" + EmployeeDAO.COLUMN_EMPLOYEE_ID + ") "
                    + ")";

            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

    }
}
