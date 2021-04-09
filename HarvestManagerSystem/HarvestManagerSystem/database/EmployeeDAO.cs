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

        public const string TABLE_EMPLOYEE = "employee";
        public const string COLUMN_EMPLOYEE_ID = "id";
        public const string COLUMN_EMPLOYEE_STATUS = "status";
        public const string COLUMN_EMPLOYEE_FIRST_NAME = "first_name";
        public const string COLUMN_EMPLOYEE_LAST_NAME = "last_name";
        public const string COLUMN_EMPLOYEE_HIRE_DATE = "hire_date";
        public const string COLUMN_EMPLOYEE_FIRE_DATE = "fire_date";
        public const string COLUMN_EMPLOYEE_PERMISSION_DATE = "permission_date";
        public const string COLUMN_EMPLOYEE_IS_EXIST = "is_exist";

        private static EmployeeDAO instance = new EmployeeDAO();

        private EmployeeDAO() : base()
        {           
        }

        public static EmployeeDAO getInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeDAO();
            }
            return instance;
        }

        //*************************************************************
        //Get data Employee as Dictionary
        //*************************************************************
        internal Dictionary<string, Employee> EmployeeDictionary()
        {
            Dictionary<string, Employee> employeeDictionary = new Dictionary<string, Employee>();

            String selectStmt = "SELECT * FROM " + TABLE_EMPLOYEE
                + " WHERE " + COLUMN_EMPLOYEE_IS_EXIST + " = 1 " 
                + " ORDER BY " + COLUMN_EMPLOYEE_FIRST_NAME + " ASC;";

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
                        employee.EmployeeId = Convert.ToInt32((result[COLUMN_EMPLOYEE_ID]).ToString());
                        employee.EmployeeStatus = (bool)result[COLUMN_EMPLOYEE_STATUS];
                        employee.FirstName = (string)result[COLUMN_EMPLOYEE_FIRST_NAME];
                        employee.LastName = (string)result[COLUMN_EMPLOYEE_LAST_NAME];
                        employee.HireDate = (DateTime)result[COLUMN_EMPLOYEE_HIRE_DATE];
                        employee.FireDate = (DateTime)result[COLUMN_EMPLOYEE_FIRE_DATE];
                        employee.PermissionDate = (DateTime)result[COLUMN_EMPLOYEE_PERMISSION_DATE];
                        employeeDictionary.Add(employee.FullName, employee);
                    }
                }
                return employeeDictionary;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return employeeDictionary;
            }
            finally
            {
                CloseConnection();
            }
        }


        //*******************************
        //Update employees data in database
        //*******************************
        internal bool UpdateData(Employee employee)
        {
            String updateStmt = "UPDATE " + TABLE_EMPLOYEE + " SET " 
                 + COLUMN_EMPLOYEE_STATUS + " =@" + COLUMN_EMPLOYEE_STATUS + ", "
                + COLUMN_EMPLOYEE_FIRST_NAME + " =@" + COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + COLUMN_EMPLOYEE_LAST_NAME + " =@" + COLUMN_EMPLOYEE_LAST_NAME + ", "
                + COLUMN_EMPLOYEE_HIRE_DATE + " =@" + COLUMN_EMPLOYEE_HIRE_DATE + ", "
                + COLUMN_EMPLOYEE_FIRE_DATE + " =@" + COLUMN_EMPLOYEE_FIRE_DATE + ", "
                + COLUMN_EMPLOYEE_PERMISSION_DATE + " =@" + COLUMN_EMPLOYEE_PERMISSION_DATE + " "
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
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_PERMISSION_DATE, employee.PermissionDate));
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

        //*******************************
        //Add employees data to data base
        //*******************************
        public bool addData(Employee employee)
        {
            String insertStmt = "INSERT INTO " + TABLE_EMPLOYEE + " ("
                    + COLUMN_EMPLOYEE_STATUS + ", "
                    + COLUMN_EMPLOYEE_FIRST_NAME + ", "
                    + COLUMN_EMPLOYEE_LAST_NAME + ", "
                    + COLUMN_EMPLOYEE_HIRE_DATE + ", "
                    + COLUMN_EMPLOYEE_FIRE_DATE + ", "
                    + COLUMN_EMPLOYEE_PERMISSION_DATE + ", "
                    + COLUMN_EMPLOYEE_IS_EXIST + "" +
                    ") VALUES ( "
                    + "@" + COLUMN_EMPLOYEE_STATUS + ", "
                    + "@" + COLUMN_EMPLOYEE_FIRST_NAME + ", "
                    + "@" + COLUMN_EMPLOYEE_LAST_NAME + ", "
                    + "@" + COLUMN_EMPLOYEE_HIRE_DATE + ", "
                    + "@" + COLUMN_EMPLOYEE_FIRE_DATE + ", "
                    + "@" + COLUMN_EMPLOYEE_PERMISSION_DATE + ", "
                    + "@" + COLUMN_EMPLOYEE_IS_EXIST + "" 
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
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_PERMISSION_DATE, employee.PermissionDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_EMPLOYEE_IS_EXIST, 1);
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
        //Get all employees data
        //*******************************
        public List<Employee> getData()
        {
            List<Employee> list = new List<Employee>();
            String selectStmt = "SELECT * FROM " + TABLE_EMPLOYEE
                + " WHERE " + COLUMN_EMPLOYEE_IS_EXIST + " = " + 1
                + " ORDER BY " + COLUMN_EMPLOYEE_FIRST_NAME + " ASC;";

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
                        employee.EmployeeId = Convert.ToInt32((result["id"]).ToString());
                        employee.EmployeeStatus = (bool)result["status"];
                        employee.FirstName = (string)result["first_name"];
                        employee.LastName = (string)result["last_name"];
                        employee.HireDate = (DateTime)result["hire_date"];
                        employee.FireDate = (DateTime)result["fire_date"];
                        employee.PermissionDate = (DateTime)result["permission_date"];
                        list.Add(employee);
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

        public void updateEmployeeStatusById(Employee employee)
        {
            String updateStmt = "UPDATE " + TABLE_EMPLOYEE + " SET " 
                + COLUMN_EMPLOYEE_STATUS + " =@" + COLUMN_EMPLOYEE_STATUS + " "
                + "  WHERE " + COLUMN_EMPLOYEE_ID + " = " + employee.EmployeeId + " ";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_EMPLOYEE_STATUS, employee.EmployeeStatus));
                sQLiteCommand.ExecuteNonQuery();
            }catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        //*******************************
        //Delete employee data
        //*******************************
        public bool DeleteData(Employee employee)
        {
            String updateStmt = "UPDATE " + TABLE_EMPLOYEE + " SET "
                 + COLUMN_EMPLOYEE_IS_EXIST + " = 0 "
                + " WHERE " + COLUMN_EMPLOYEE_ID + " = " + employee.EmployeeId + " ";

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
            String createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_EMPLOYEE
                    + "(" + COLUMN_EMPLOYEE_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_EMPLOYEE_STATUS + " BOOLEAN NOT NULL, "
                    + COLUMN_EMPLOYEE_FIRST_NAME + " VARCHAR(16) NOT NULL, "
                    + COLUMN_EMPLOYEE_LAST_NAME + " VARCHAR(16) NOT NULL, "
                    + COLUMN_EMPLOYEE_HIRE_DATE + " DATE, "
                    + COLUMN_EMPLOYEE_FIRE_DATE + " DATE, "
                    + COLUMN_EMPLOYEE_PERMISSION_DATE + " DATE, "
                    + COLUMN_EMPLOYEE_IS_EXIST + " INTEGER DEFAULT 1)";


                SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
                CloseConnection();
                Console.WriteLine("table created called");

        }

    }
}
