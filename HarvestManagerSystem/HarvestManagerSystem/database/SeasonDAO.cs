using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;

namespace HarvestManagerSystem.database
{
    class SeasonDAO:DAO
    {
        public const string TABLE_SEASON = "Season";
        public const string COLUMN_SEASON_ID = "Id";
        public const string COLUMN_SEASON_PLANTING_DATE = "PlantingDate";
        public const string COLUMN_SEASON_HARVEST_DATE = "HarvestDate";
        public const string COLUMN_FOREIGN_KEY_FARM_ID = "FarmId";

        

        private static SeasonDAO instance = new SeasonDAO();

        private SeasonDAO() : base(){}

        public static SeasonDAO getInstance()
        {
            if (instance == null)
            {
                instance = new SeasonDAO();
            }
            return instance;
        }


        public void CreateTable()
        {
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_SEASON
                   + "(" + COLUMN_SEASON_ID + " INTEGER PRIMARY KEY, "
                    + COLUMN_SEASON_PLANTING_DATE + " DATE, "
                    + COLUMN_SEASON_HARVEST_DATE + " DATE, "
                    + COLUMN_FOREIGN_KEY_FARM_ID + " INTEGER NOT NULL, "
                    + " FOREIGN KEY (" + COLUMN_FOREIGN_KEY_FARM_ID + ") REFERENCES " + FarmDAO.TABLE_FARM + " (" + FarmDAO.COLUMN_FARM_ID + ") "
                    + ")";

            SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
            OpenConnection();
            sQLiteCommand.ExecuteNonQuery();
            CloseConnection();
            MessageBox.Show("Create table");

        }

        //*******************************
        //Update season data
        //*******************************
        internal bool UpdateData(Season season)
        {
            String updateStmt = "UPDATE " + TABLE_SEASON + " SET "
                 + COLUMN_SEASON_PLANTING_DATE + " =@" + COLUMN_SEASON_PLANTING_DATE + ", "
                 + COLUMN_SEASON_HARVEST_DATE + " =@" + COLUMN_SEASON_HARVEST_DATE + " "
                 + " WHERE " + COLUMN_SEASON_ID + " = " + season.SeasonId + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SEASON_PLANTING_DATE, season.SeasonPlantingDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_SEASON_HARVEST_DATE, season.SeasonHarvestDate));
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
        //Get all season data by farm id
        //*******************************
        public List<Season> getData(Farm farm)
        {
            List<Season> list = new List<Season>();
            string selectStmt = "SELECT * FROM " + TABLE_SEASON
                + " WHERE " + COLUMN_FOREIGN_KEY_FARM_ID + " = " + farm.FarmId
                + " ORDER BY " + COLUMN_SEASON_PLANTING_DATE + " ASC ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Season season = new Season();
                        season.SeasonId = Convert.ToInt32((result[COLUMN_SEASON_ID]).ToString());
                        season.SeasonPlantingDate = (DateTime)result[COLUMN_SEASON_PLANTING_DATE];
                        season.SeasonHarvestDate = (DateTime)result[COLUMN_SEASON_HARVEST_DATE];
                        season.Farm.FarmId = Convert.ToInt32((result[COLUMN_FOREIGN_KEY_FARM_ID]).ToString());
                        list.Add(season);
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
        //Add new farm and season data 
        //*******************************
        internal bool addNewFarmSeason(Season season)
        {
            string insertStmt = "INSERT INTO Farm_For_Insert (PlantingDate, HarvestDate, FarmName, FarmAddress) VALUES ("
                    + "@" + COLUMN_SEASON_PLANTING_DATE + ", "
                    + "@" + COLUMN_SEASON_HARVEST_DATE + ", "
                    + "@FarmName, "
                    + "@FarmAddress "
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SEASON_PLANTING_DATE, season.SeasonPlantingDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SEASON_HARVEST_DATE, season.SeasonHarvestDate);
                sQLiteCommand.Parameters.AddWithValue("@FarmName", season.Farm.FarmName);
                sQLiteCommand.Parameters.AddWithValue("@FarmAddress", season.Farm.FarmAddress);
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
        //Add new farm season data 
        //*******************************
        public bool addData(Season season)
        {
            String insertStmt = "INSERT INTO " + TABLE_SEASON + " ("
                    + COLUMN_SEASON_PLANTING_DATE + ", "
                    + COLUMN_SEASON_HARVEST_DATE + ", "
                    + COLUMN_FOREIGN_KEY_FARM_ID +
                    ") VALUES ( "
                    + "@" + COLUMN_SEASON_PLANTING_DATE + ", "
                    + "@" + COLUMN_SEASON_HARVEST_DATE + ", "
                    + "@" + COLUMN_FOREIGN_KEY_FARM_ID + ""
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SEASON_PLANTING_DATE, season.SeasonPlantingDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_SEASON_HARVEST_DATE, season.SeasonHarvestDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_FOREIGN_KEY_FARM_ID, season.Farm.FarmId);
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
        //Delete farm season
        //*******************************
        public bool DeleteData(Season season)
        {
            String updateStmt = "DELETE FROM " + TABLE_SEASON + " WHERE " + COLUMN_SEASON_ID + " = " + season.SeasonId + " ";

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
