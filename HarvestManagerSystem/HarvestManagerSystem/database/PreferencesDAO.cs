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
                instance = new PreferencesDAO();
            return instance;
        }

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
                        pref.PenaltyGeneral = result.GetDouble(result.GetOrdinal(COLUMN_PREFERENCE_PENALTY_GENERAL));
                        pref.DamageGeneral = result.GetDouble(result.GetOrdinal(COLUMN_PREFERENCE_DAMAGE_GENERAL));
                        pref.HourPrice = result.GetDouble(result.GetOrdinal(COLUMN_PREFERENCE_HOUR_PRICE));
                        pref.TransportPrice = result.GetDouble(result.GetOrdinal(COLUMN_PREFERENCE_TRANSPORT_PRICE));
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
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

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
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdatePassword(string password)
        {
            string updateStmt = "UPDATE Login SET Password ='" + password + "'  WHERE ID=1";

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
