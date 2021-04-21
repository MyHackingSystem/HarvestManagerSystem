using System;
using System.Collections.Generic;
using System.Text;
using HarvestManagerSystem.model;
using System.Data.SQLite;

namespace HarvestManagerSystem.database
{
    class PreferencesDAO:DAO
    {
            public const string TABLE_PREFERENCE = "Preferences";
            public const string COLUMN_PREFERENCE_PENALTY_GENERAL = "PenaltyGeneral";
            public const string COLUMN_PREFERENCE_DAMAGE_GENERAL = "DamageGeneral";
            public const string COLUMN_PREFERENCE_HOUR_PRICE = "HourPrice";
            public const string COLUMN_PREFERENCE_TRANSPORT_PRICE = "TransportPrice";

        private static PreferencesDAO instance = new PreferencesDAO();

        private PreferencesDAO() : base() { }

        public static PreferencesDAO getInstance()
        {
            if (instance == null)
            {
                instance = new PreferencesDAO();
            }
            return instance;
        }


        //***********************************
        //Get Preferences
        //***********************************

        public Preferences getPreferences()
        {
            Preferences pref = new Preferences();
            string selectStmt = "SELECT * FROM " + TABLE_PREFERENCE;

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        pref.PenaltyGeneral = Convert.ToDouble((result[COLUMN_PREFERENCE_PENALTY_GENERAL]).ToString());
                        pref.DamageGeneral = Convert.ToDouble((result[COLUMN_PREFERENCE_DAMAGE_GENERAL]).ToString());
                        pref.HourPrice = Convert.ToDouble((result[COLUMN_PREFERENCE_HOUR_PRICE]).ToString());
                        pref.TransportPrice = Convert.ToDouble((result[COLUMN_PREFERENCE_TRANSPORT_PRICE]).ToString());

                    }
                }
                return pref;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }


        //***********************************
        //Edit Preferences
        //***********************************
        public bool editPreferences(Preferences pref)
        {
            string updateStmt = "UPDATE " + TABLE_PREFERENCE + " SET "
                 + COLUMN_PREFERENCE_PENALTY_GENERAL + " =@" + COLUMN_PREFERENCE_PENALTY_GENERAL + ", "
                 + COLUMN_PREFERENCE_DAMAGE_GENERAL + " =@" + COLUMN_PREFERENCE_DAMAGE_GENERAL + ", "
                 + COLUMN_PREFERENCE_HOUR_PRICE + " =@" + COLUMN_PREFERENCE_HOUR_PRICE + ", "
                 + COLUMN_PREFERENCE_TRANSPORT_PRICE + " =@" + COLUMN_PREFERENCE_TRANSPORT_PRICE + " ";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(updateStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PREFERENCE_PENALTY_GENERAL, pref.PenaltyGeneral));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PREFERENCE_DAMAGE_GENERAL, pref.DamageGeneral));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PREFERENCE_HOUR_PRICE, pref.HourPrice));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_PREFERENCE_TRANSPORT_PRICE, pref.TransportPrice));
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



        //***********************************
        //Get Preferences
        //***********************************

        public Account getLogin()
        {
            Account user = new Account();
            string selectStmt = "SELECT * FROM Login where ID = 1";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        user.Name = result["User"].ToString();
                        user.Passwword = result["Password"].ToString();
                    }
                }
                return user;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        /*
         
        CREATE TABLE "Preferences" (
	"PenaltyGeneral"	REAL DEFAULT 0,
	"DamageGeneral"	REAL DEFAULT 0,
	"HourPrice"	REAL DEFAULT 0,
	"TransportPrice"	NUMERIC DEFAULT 0
);

         * */
    }
}
