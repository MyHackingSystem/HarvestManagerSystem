using System;
using System.Collections.Generic;
using System.Text;
using HarvestManagerSystem.database;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace HarvestManagerSystem.database
{
    class EmployeeDAO:DAO
    {

        public const string TABLE_EMPLOYEE = "Employee";
        public const string COLUMN_EMPLOYEE_ID = "EmployeeId";
        public const string COLUMN_EMPLOYEE_STATUS = "EmployeeStatus";
        public const string COLUMN_EMPLOYEE_FIRST_NAME = "FirstName";
        public const string COLUMN_EMPLOYEE_LAST_NAME = "LastName";
        public const string COLUMN_EMPLOYEE_HIRE_DATE = "HireDate";
        public const string COLUMN_EMPLOYEE_FIRE_DATE = "FireDate";
        public const string COLUMN_EMPLOYEE_PERMIT_DATE = "PermitDate";

        private static EmployeeDAO instance = new EmployeeDAO();

        private EmployeeDAO() : base() {}

        public static EmployeeDAO getInstance()
        {
            if (instance == null)
                instance = new EmployeeDAO();
            return instance;
        }

        internal Dictionary<string, Employee> EmployeeDictionary()
        {
            Dictionary<string, Employee> employeeDictionary = new Dictionary<string, Employee>();

            string selectStmt = "SELECT * FROM " + TABLE_EMPLOYEE + " ORDER BY " + COLUMN_EMPLOYEE_FIRST_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = result.GetInt32(result.GetOrdinal(COLUMN_EMPLOYEE_ID));
                        employee.EmployeeStatus = result.GetBoolean(result.GetOrdinal(COLUMN_EMPLOYEE_STATUS));
                        employee.FirstName = result.GetString(result.GetOrdinal(COLUMN_EMPLOYEE_FIRST_NAME));
                        employee.LastName = result.GetString(result.GetOrdinal(COLUMN_EMPLOYEE_LAST_NAME));
                        employee.HireDate = result.GetDateTime(result.GetOrdinal(COLUMN_EMPLOYEE_HIRE_DATE));
                        employee.FireDate = result.GetDateTime(result.GetOrdinal(COLUMN_EMPLOYEE_FIRE_DATE));
                        employee.PermitDate = result.GetDateTime(result.GetOrdinal(COLUMN_EMPLOYEE_PERMIT_DATE));
                        employeeDictionary.Add(employee.FullName, employee);
                    }
                }
                return employeeDictionary;
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


        internal void Update(Employee employee)
        {
            var updateStmt = "UPDATE " + TABLE_EMPLOYEE + " SET " 
                 + COLUMN_EMPLOYEE_STATUS + " =@" + COLUMN_EMPLOYEE_STATUS + ", "
                + COLUMN_EMPLOYEE_FIRST_NAME + " =@" + COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + COLUMN_EMPLOYEE_LAST_NAME + " =@" + COLUMN_EMPLOYEE_LAST_NAME + ", "
                + COLUMN_EMPLOYEE_HIRE_DATE + " =@" + COLUMN_EMPLOYEE_HIRE_DATE + ", "
                + COLUMN_EMPLOYEE_FIRE_DATE + " =@" + COLUMN_EMPLOYEE_FIRE_DATE + ", "
                + COLUMN_EMPLOYEE_PERMIT_DATE + " =@" + COLUMN_EMPLOYEE_PERMIT_DATE + " "
                + " WHERE " + COLUMN_EMPLOYEE_ID + " = " + employee.EmployeeId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_STATUS, employee.EmployeeStatus));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_FIRST_NAME, employee.FirstName));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_LAST_NAME, employee.LastName));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_HIRE_DATE, employee.HireDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_FIRE_DATE, employee.FireDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_PERMIT_DATE, employee.PermitDate));
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

        public void Add(Employee employee)
        {
            string insertStmt = "INSERT INTO " + TABLE_EMPLOYEE + " ("
                    + COLUMN_EMPLOYEE_STATUS + ", "
                    + COLUMN_EMPLOYEE_FIRST_NAME + ", "
                    + COLUMN_EMPLOYEE_LAST_NAME + ", "
                    + COLUMN_EMPLOYEE_HIRE_DATE + ", "
                    + COLUMN_EMPLOYEE_FIRE_DATE + ", "
                    + COLUMN_EMPLOYEE_PERMIT_DATE + " "
                    + ") VALUES ( "
                    + "@" + COLUMN_EMPLOYEE_STATUS + ", "
                    + "@" + COLUMN_EMPLOYEE_FIRST_NAME + ", "
                    + "@" + COLUMN_EMPLOYEE_LAST_NAME + ", "
                    + "@" + COLUMN_EMPLOYEE_HIRE_DATE + ", "
                    + "@" + COLUMN_EMPLOYEE_FIRE_DATE + ", "
                    + "@" + COLUMN_EMPLOYEE_PERMIT_DATE + " "
                    +" )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_STATUS, employee.EmployeeStatus);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_FIRST_NAME, employee.FirstName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_LAST_NAME, employee.LastName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_HIRE_DATE, employee.HireDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_FIRE_DATE, employee.FireDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_PERMIT_DATE, employee.PermitDate);
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

        public List<Employee> ListEmployee()
        {
            List<Employee> list = new List<Employee>();
            var selectStmt = "SELECT * FROM " + TABLE_EMPLOYEE + " ORDER BY " + COLUMN_EMPLOYEE_FIRST_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = result.GetInt32(result.GetOrdinal(COLUMN_EMPLOYEE_ID));
                        employee.EmployeeStatus = result.GetBoolean(result.GetOrdinal(COLUMN_EMPLOYEE_STATUS));
                        employee.FirstName = result.GetString(result.GetOrdinal(COLUMN_EMPLOYEE_FIRST_NAME));
                        employee.LastName = result.GetString(result.GetOrdinal(COLUMN_EMPLOYEE_LAST_NAME));
                        employee.HireDate = result.GetDateTime(result.GetOrdinal(COLUMN_EMPLOYEE_HIRE_DATE));
                        employee.FireDate = result.GetDateTime(result.GetOrdinal(COLUMN_EMPLOYEE_FIRE_DATE));
                        employee.PermitDate = result.GetDateTime(result.GetOrdinal(COLUMN_EMPLOYEE_PERMIT_DATE));
                        list.Add(employee);
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

        public bool Delete(Employee employee)
        {
            var updateStmt = "DELETE FROM " + TABLE_EMPLOYEE + " WHERE " + COLUMN_EMPLOYEE_ID + " = " + employee.EmployeeId + " ";

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

    }
}
