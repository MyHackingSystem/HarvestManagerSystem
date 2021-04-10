using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.database
{
    class TransportDAO:DAO
    {
        public const string TABLE_TRANSPORT = "Transport";
        public const string COLUMN_TRANSPORT_ID = "TransportId";
        public const string COLUMN_TRANSPORT_DATE = "TransportDate";
        public const string COLUMN_TRANSPORT_AMOUNT = "TransportAmount";
        public const string COLUMN_TRANSPORT_EMPLOYEE_ID = "EmployeeId";
        public const string COLUMN_TRANSPORT_FARM_ID = "FarmId";


        private static TransportDAO instance = new TransportDAO();

        private TransportDAO() : base() { }

        public static TransportDAO getInstance()
        {
            if (instance == null)
            {
                instance = new TransportDAO();
            }
            return instance;
        }

        //*******************************
        //Get Transport data
        //*******************************
        public List<Transport> getData()
        {
            List<Transport> list = new List<Transport>();
            var selectStmt = "SELECT "
                + TABLE_TRANSPORT + "." + COLUMN_TRANSPORT_ID + ", "
                + TABLE_TRANSPORT + "." + COLUMN_TRANSPORT_DATE + ", "
                + TABLE_TRANSPORT + "." + COLUMN_TRANSPORT_AMOUNT + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + " "
                + " FROM " + TABLE_TRANSPORT
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + TABLE_TRANSPORT + "." + COLUMN_TRANSPORT_EMPLOYEE_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + TABLE_TRANSPORT + "." + COLUMN_TRANSPORT_FARM_ID
                + " WHERE " + TABLE_TRANSPORT + "." + COLUMN_TRANSPORT_AMOUNT + " > 0 "
                + " ORDER BY " + COLUMN_TRANSPORT_DATE + " DESC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Transport transport = new Transport();
                        transport.TransportId = Convert.ToInt32((result[COLUMN_TRANSPORT_ID]).ToString());
                        transport.TransportDate = (DateTime)result[COLUMN_TRANSPORT_DATE];
                        transport.TransportAmount = Convert.ToDouble((result[COLUMN_TRANSPORT_AMOUNT]).ToString());
                        transport.Employee.EmployeeId = Convert.ToInt32((result[EmployeeDAO.COLUMN_EMPLOYEE_ID]).ToString());
                        transport.Employee.FirstName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME];
                        transport.Employee.LastName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME];
                        transport.Farm.FarmId = Convert.ToInt32((result[FarmDAO.COLUMN_FARM_ID]).ToString());
                        transport.Farm.FarmName = (string)result[FarmDAO.COLUMN_FARM_NAME];
                        list.Add(transport);
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
        //Add new transport data 
        //*******************************
        public bool addData(Transport transport)
        {
            string insertStmt = "INSERT INTO " + TABLE_TRANSPORT + " ("
                    + COLUMN_TRANSPORT_DATE + ", "
                    + COLUMN_TRANSPORT_AMOUNT + ", "
                    + COLUMN_TRANSPORT_EMPLOYEE_ID + ", "
                    + COLUMN_TRANSPORT_FARM_ID +
                    " ) VALUES ( "
                    + "@" + COLUMN_TRANSPORT_DATE + ", "
                    + "@" + COLUMN_TRANSPORT_AMOUNT + ", "
                    + "@" + COLUMN_TRANSPORT_EMPLOYEE_ID + ", "
                    + "@" + COLUMN_TRANSPORT_FARM_ID
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_TRANSPORT_DATE, transport.TransportDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_TRANSPORT_AMOUNT, transport.TransportAmount);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_TRANSPORT_EMPLOYEE_ID, transport.Employee.EmployeeId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_TRANSPORT_FARM_ID, transport.Farm.FarmId);
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
        //Update transport data
        //*******************************
        internal bool UpdateData(Transport transport)
        {
            string updateStmt = "UPDATE " + TABLE_TRANSPORT + " SET "
                 + COLUMN_TRANSPORT_AMOUNT + " =@" + COLUMN_TRANSPORT_AMOUNT + " "
                + " WHERE " + COLUMN_TRANSPORT_ID + " = " + transport.TransportId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_TRANSPORT_AMOUNT, transport.TransportAmount));
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
        //Delete transport data (hide)
        //*******************************
        public bool DeleteData(Transport transport)
        {
            string updateStmt = "UPDATE " + TABLE_TRANSPORT + " SET "
                 + COLUMN_TRANSPORT_AMOUNT + " = 0 "
                + " WHERE " + COLUMN_TRANSPORT_ID + " = " + transport.TransportId + " ";

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
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_TRANSPORT + "("
                    + COLUMN_TRANSPORT_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_TRANSPORT_DATE + " DATE NOT NULL, "
                    + COLUMN_TRANSPORT_AMOUNT + " REAL DEFAULT 0, "
                    + COLUMN_TRANSPORT_EMPLOYEE_ID + " INTEGER NOT NULL, "
                    + COLUMN_TRANSPORT_FARM_ID + " INTEGER NOT NULL, "
                    + " FOREIGN KEY (" + COLUMN_TRANSPORT_EMPLOYEE_ID + ") REFERENCES " + EmployeeDAO.TABLE_EMPLOYEE + " (" + EmployeeDAO.COLUMN_EMPLOYEE_ID + "), "
                    + " FOREIGN KEY (" + COLUMN_TRANSPORT_FARM_ID + ") REFERENCES " + FarmDAO.TABLE_FARM + " (" + FarmDAO.COLUMN_FARM_ID + ") "
                    + ")";

            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
