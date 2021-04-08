using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.database
{
    class FarmDAO: DAO
    {

        public const string TABLE_FARM = "Farm";
        public const string COLUMN_FARM_ID = "FarmId";
        public const string COLUMN_FARM_NAME = "FarmName";
        public const string COLUMN_FARM_ADDRESS = "FarmAddress";
        public const string COLUMN_FARM_IS_EXIST = "is_exist";

        private static FarmDAO instance = new FarmDAO();

        private FarmDAO() : base()
        {

        }

        public static FarmDAO getInstance()
        {
            if (instance == null)
            {
                instance = new FarmDAO();
            }
            return instance;
        }

        //*************************************************************
        //Get data farm as Dictionary by farm name
        //*************************************************************
        internal Dictionary<string, Farm> FarmDictionary()
        {
            Dictionary<string, Farm> dictionary = new Dictionary<string, Farm>();

            String selectStmt = "SELECT * FROM " + TABLE_FARM
                + " WHERE " + COLUMN_FARM_IS_EXIST + " = 1 "
                + " ORDER BY " + COLUMN_FARM_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Farm farm = new Farm
                        {
                            FarmId = Convert.ToInt32((result[COLUMN_FARM_ID]).ToString()),
                            FarmName = (string)result[COLUMN_FARM_NAME],
                            FarmAddress = (string)result[COLUMN_FARM_ADDRESS]
                        };
                        dictionary.Add(farm.FarmName, farm);
                    }
                }
                return dictionary;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                return dictionary;
            }
            finally
            {
                CloseConnection();
            }
        }

        //*******************************
        //Get all farm data
        //*******************************
        public List<Farm> getData()
        {
            List<Farm> list = new List<Farm>();
            var selectStmt = "SELECT * FROM " + TABLE_FARM
                + " WHERE " + COLUMN_FARM_IS_EXIST + " = 1 " 
                + " ORDER BY " + COLUMN_FARM_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Farm farm = new Farm
                        {
                            FarmId = Convert.ToInt32((result[COLUMN_FARM_ID]).ToString()),
                            FarmName = (string)result[COLUMN_FARM_NAME],
                            FarmAddress = (string)result[COLUMN_FARM_ADDRESS]
                        };
                        list.Add(farm);
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
        //Add new product data 
        //*******************************
        public bool addData(Farm farm)
        {
            String insertStmt = "INSERT INTO " + TABLE_FARM + " ("
                    + COLUMN_FARM_NAME + ", "
                    + COLUMN_FARM_ADDRESS + ", "
                    + COLUMN_FARM_IS_EXIST + 
                    " ) VALUES ( "
                    + "@" + COLUMN_FARM_NAME + ", "
                    + "@" + COLUMN_FARM_ADDRESS + ", "
                    + "@" + COLUMN_FARM_IS_EXIST
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_FARM_NAME, farm.FarmName);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_FARM_ADDRESS, farm.FarmAddress);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_FARM_IS_EXIST, 1);
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
        //Delete product data (hide)
        //*******************************
        public bool DeleteData(Farm farm)
        {
            String updateStmt = "UPDATE " + TABLE_FARM + " SET "
                 + COLUMN_FARM_IS_EXIST + " = 0 "
                + " WHERE " + COLUMN_FARM_ID + " = " + farm.FarmId + " ";

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

        //*******************************
        //Update farm data
        //*******************************
        internal bool UpdateData(Farm farm)
        {
            String updateStmt = "UPDATE " + TABLE_FARM + " SET "
                 + COLUMN_FARM_NAME + " =@" + COLUMN_FARM_NAME + ", "
                 + COLUMN_FARM_ADDRESS + " =@" + COLUMN_FARM_ADDRESS + " "
                + " WHERE " + COLUMN_FARM_ID + " = " + farm.FarmId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_FARM_NAME, farm.FarmName));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_FARM_ADDRESS, farm.FarmAddress));
                sQLiteCommand.ExecuteNonQuery();
                CloseConnection();
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

        public void CreateTable()
        {
            String createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_FARM
                    + "(" + COLUMN_FARM_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_FARM_NAME + " TEXT NOT NULL, "
                    + COLUMN_FARM_ADDRESS + " TEXT, "
                    + COLUMN_FARM_IS_EXIST + " INTEGER DEFAULT 1)";

            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

    }
}
