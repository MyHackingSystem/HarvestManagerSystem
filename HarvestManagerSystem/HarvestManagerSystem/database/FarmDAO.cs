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

        private static FarmDAO instance = new FarmDAO();

        private FarmDAO() : base(){}

        public static FarmDAO getInstance()
        {
            if (instance == null)
                instance = new FarmDAO();
            return instance;
        }

        internal Dictionary<string, Farm> FarmDictionary()
        {
            Dictionary<string, Farm> dictionary = new Dictionary<string, Farm>();
            var selectStmt = "SELECT * FROM " + TABLE_FARM + " ORDER BY " + COLUMN_FARM_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Farm farm = new Farm();
                        farm.FarmId = result.GetInt32(result.GetOrdinal(COLUMN_FARM_ID));
                        farm.FarmName = result.GetString(result.GetOrdinal(COLUMN_FARM_NAME));
                        farm.FarmAddress = result.GetString(result.GetOrdinal(COLUMN_FARM_ADDRESS));
                        dictionary.Add(farm.FarmName, farm);
                    }
                }
                return dictionary;
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

        public List<Farm> FarmList()
        {
            List<Farm> list = new List<Farm>();
            var selectStmt = "SELECT * FROM " + TABLE_FARM + " ORDER BY " + COLUMN_FARM_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Farm farm = new Farm();
                        farm.FarmId = result.GetInt32(result.GetOrdinal(COLUMN_FARM_ID));
                        farm.FarmName = result.GetString(result.GetOrdinal(COLUMN_FARM_NAME));
                        farm.FarmAddress = result.GetString(result.GetOrdinal(COLUMN_FARM_ADDRESS));
                        list.Add(farm);
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

        public void Delete(Farm farm)
        {
            string updateStmt = "DELETE FROM " + TABLE_FARM + " WHERE " + COLUMN_FARM_ID + " = " + farm.FarmId + " ";

            string deleteStmt = "DELETE FROM " + SeasonDAO.TABLE_SEASON + " WHERE " + SeasonDAO.COLUMN_FOREIGN_KEY_FARM_ID + " = " + farm.FarmId + " ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt + ";" + deleteStmt, mSQLiteConnection);
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

        public void Update(Farm farm)
        {
            string updateStmt = "UPDATE " + TABLE_FARM + " SET "
                 + COLUMN_FARM_NAME + " =@" + COLUMN_FARM_NAME + ", "
                 + COLUMN_FARM_ADDRESS + " =@" + COLUMN_FARM_ADDRESS + " "
                + " WHERE " + COLUMN_FARM_ID + " = " + farm.FarmId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_FARM_NAME, farm.FarmName.ToUpper()));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_FARM_ADDRESS, farm.FarmAddress.ToUpper()));
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
