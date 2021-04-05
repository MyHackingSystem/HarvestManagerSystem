using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace HarvestManagerSystem.database
{
    class DAO
    {
        public SQLiteConnection mSQLiteConnection;
        static String  DB_NAME = "database.sqlite3";
        static String CONNECTION_URL = "Data Source=" + DB_NAME;

        public DAO()
        {
            mSQLiteConnection = new SQLiteConnection(CONNECTION_URL);
            if (!File.Exists("./" + DB_NAME))
            {
                SQLiteConnection.CreateFile(DB_NAME);
                Console.WriteLine(DB_NAME + " created");
            }
           
        }

        public void OpenConnection()
        {
            if (mSQLiteConnection.State != System.Data.ConnectionState.Open)
            {
                mSQLiteConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (mSQLiteConnection.State != System.Data.ConnectionState.Closed)
            {
                mSQLiteConnection.Close();
            }
        }
    }
}
