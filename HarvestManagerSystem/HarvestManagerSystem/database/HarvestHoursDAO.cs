using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace HarvestManagerSystem.database
{
    class HarvestHoursDAO : DAO
    {
        public const string TABLE_HOURS = "HarvestHours";
        public const string COLUMN_HOURS_ID = "HarvestHoursId";
        public const string COLUMN_HOURS_DATE = "HarvestDate";
        public const string COLUMN_HOURS_SM = "TimeStartMorning";
        public const string COLUMN_HOURS_EM = "TimeEndMorning";
        public const string COLUMN_HOURS_SN = "TimeStartNoon";
        public const string COLUMN_HOURS_EN = "TimeEndNoon";
        public const string COLUMN_HOURS_PRICE = "HourPrice";
        public const string COLUMN_HOURS_REMARQUE = "Remarque";
        public const string COLUMN_HOURS_EMPLOYEE_TYPE = "EmployeeType";
        public const string COLUMN_HOURS_EMPLOYEE_ID = "EmployeeId";
        public const string COLUMN_HOURS_TRANSPORT_ID = "TransportId";
        public const string COLUMN_HOURS_CREDIT_ID = "CreditId";
        public const string COLUMN_HOURS_PRODUCTION_ID = "ProductionId";


        private static HarvestHoursDAO instance = new HarvestHoursDAO();

        private HarvestHoursDAO() : base() { }

        public static HarvestHoursDAO getInstance()
        {
            if (instance == null)
                instance = new HarvestHoursDAO();
            return instance;
        }

        public bool addHoursWork(HarvestHours harvestHours)
        {
            SQLiteTransaction transaction = null;
            SQLiteCommand sQLiteCommand = null;

            var insertTransport = "INSERT INTO " + TransportDAO.TABLE_TRANSPORT + " ("
                    + TransportDAO.COLUMN_TRANSPORT_DATE + ", "
                    + TransportDAO.COLUMN_TRANSPORT_AMOUNT + ", "
                    + TransportDAO.COLUMN_TRANSPORT_EMPLOYEE_ID + ", "
                    + TransportDAO.COLUMN_TRANSPORT_FARM_ID +
                    " ) VALUES ( "
                    + "@" + TransportDAO.COLUMN_TRANSPORT_DATE + ", "
                    + "@" + TransportDAO.COLUMN_TRANSPORT_AMOUNT + ", "
                    + "@" + TransportDAO.COLUMN_TRANSPORT_EMPLOYEE_ID + ", "
                    + "@" + TransportDAO.COLUMN_TRANSPORT_FARM_ID
                    + " )";

            var insertCredit = "INSERT INTO " + CreditDAO.TABLE_CREDIT + " ("
                    + CreditDAO.COLUMN_CREDIT_DATE + ", "
                    + CreditDAO.COLUMN_CREDIT_AMOUNT + ", "
                    + CreditDAO.COLUMN_CREDIT_EMPLOYEE_ID +
                    " ) VALUES ( "
                    + "@" + CreditDAO.COLUMN_CREDIT_DATE + ", "
                    + "@" + CreditDAO.COLUMN_CREDIT_AMOUNT + ", "
                    + "@" + CreditDAO.COLUMN_CREDIT_EMPLOYEE_ID
                    + " )";

            var insertHarvestHours = "INSERT INTO " + TABLE_HOURS + " ("
                    + COLUMN_HOURS_DATE + ", "
                    + COLUMN_HOURS_SM + ", "
                    + COLUMN_HOURS_EM + ", "
                    + COLUMN_HOURS_SN + ", "
                    + COLUMN_HOURS_EN + ", "
                    + COLUMN_HOURS_PRICE + ", "
                    + COLUMN_HOURS_REMARQUE + ", "
                    + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                    + COLUMN_HOURS_EMPLOYEE_ID + ", "
                    + COLUMN_HOURS_TRANSPORT_ID + ", "
                    + COLUMN_HOURS_CREDIT_ID + ", "
                    + COLUMN_HOURS_PRODUCTION_ID +
                    " ) VALUES ( "
                    + "@" + COLUMN_HOURS_DATE + ", "
                    + "@" + COLUMN_HOURS_SM + ", "
                    + "@" + COLUMN_HOURS_EM + ", "
                    + "@" + COLUMN_HOURS_SN + ", "
                    + "@" + COLUMN_HOURS_EN + ", "
                    + "@" + COLUMN_HOURS_PRICE + ", "
                    + "@" + COLUMN_HOURS_REMARQUE + ", "
                    + "@" + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                    + "@" + COLUMN_HOURS_EMPLOYEE_ID + ", "
                    + "@" + COLUMN_HOURS_TRANSPORT_ID + ", "
                    + "@" + COLUMN_HOURS_CREDIT_ID + ", "
                    + "@" + COLUMN_HOURS_PRODUCTION_ID
                    + " )";

            try
            {
                OpenConnection();
                transaction = mSQLiteConnection.BeginTransaction();
                sQLiteCommand = new SQLiteCommand(insertTransport, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_DATE, harvestHours.HarvestDate);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_AMOUNT, harvestHours.Transport.TransportAmount);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_EMPLOYEE_ID, harvestHours.Employee.EmployeeId);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_FARM_ID, harvestHours.Production.Farm.FarmId);
                sQLiteCommand.ExecuteNonQuery();

                long rowTransportId = 0;

                rowTransportId = mSQLiteConnection.LastInsertRowId;

                sQLiteCommand = new SQLiteCommand(insertCredit, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(CreditDAO.COLUMN_CREDIT_DATE, harvestHours.HarvestDate);
                sQLiteCommand.Parameters.AddWithValue(CreditDAO.COLUMN_CREDIT_AMOUNT, harvestHours.Credit.CreditAmount);
                sQLiteCommand.Parameters.AddWithValue(CreditDAO.COLUMN_CREDIT_EMPLOYEE_ID, harvestHours.Employee.EmployeeId);
                sQLiteCommand.ExecuteNonQuery();

                long rowCreditId = 0;
                rowCreditId = mSQLiteConnection.LastInsertRowId;

                sQLiteCommand = new SQLiteCommand(insertHarvestHours, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_DATE, harvestHours.HarvestDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_SM, harvestHours.StartMorning);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EM, harvestHours.EndMorning);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_SN, harvestHours.StartNoon);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EN, harvestHours.EndNoon);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_PRICE, harvestHours.HourPrice);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_REMARQUE, harvestHours.Remarque);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EMPLOYEE_TYPE, harvestHours.EmployeeType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EMPLOYEE_ID, harvestHours.Employee.EmployeeId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_TRANSPORT_ID, rowTransportId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_CREDIT_ID, rowCreditId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_PRODUCTION_ID, harvestHours.Production.ProductionID);
                sQLiteCommand.ExecuteNonQuery();

                transaction.Commit();
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

        public List<HarvestHours> HarvestHoursByProduction(Production production)
        {
            string selectStmt = "SELECT "
                + TABLE_HOURS + "." + COLUMN_HOURS_ID + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_DATE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_SM + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EM + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_SN + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EN + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_PRICE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_REMARQUE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + ", "
                + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + ", "
                + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_AMOUNT + ", "
                + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + ", "
                + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_AMOUNT + ", "
                + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
                + " FROM " + TABLE_HOURS + " "
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_EMPLOYEE_ID
                + " LEFT JOIN " + TransportDAO.TABLE_TRANSPORT + " "
                + " ON " + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_TRANSPORT_ID
                + " LEFT JOIN " + CreditDAO.TABLE_CREDIT + " "
                + " ON " + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_CREDIT_ID
                + " LEFT JOIN " + ProductionDAO.TABLE_PRODUCTION + " "
                + " ON " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_PRODUCTION_ID
                + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
                + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
                + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
                + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
                + " WHERE " + TABLE_HOURS + "." + COLUMN_HOURS_PRODUCTION_ID + " = " + production.ProductionID + " "
                + " ORDER BY " + TABLE_HOURS + "." + COLUMN_HOURS_DATE + " DESC ;";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return getHarvestHoursFromResultSet(result);
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


        internal bool updateHoursWork(HarvestHours item)
        {
            SQLiteTransaction transaction = null;
            SQLiteCommand sQLiteCommand = null;

            string updateTransport = "UPDATE " + TransportDAO.TABLE_TRANSPORT + " SET "
                                     + TransportDAO.COLUMN_TRANSPORT_DATE + " =@" + TransportDAO.COLUMN_TRANSPORT_DATE + ", "
                                     + TransportDAO.COLUMN_TRANSPORT_AMOUNT + " =@" + TransportDAO.COLUMN_TRANSPORT_AMOUNT + ", "
                                     + TransportDAO.COLUMN_TRANSPORT_EMPLOYEE_ID + " =@" + TransportDAO.COLUMN_TRANSPORT_EMPLOYEE_ID + ", "
                                     + TransportDAO.COLUMN_TRANSPORT_FARM_ID + " =@" + TransportDAO.COLUMN_TRANSPORT_FARM_ID + " "
                                     + " WHERE " + TransportDAO.COLUMN_TRANSPORT_ID + " = " + item.Transport.TransportId + " ";


            string updateCredit = "UPDATE " + CreditDAO.TABLE_CREDIT + " SET "
                                       + CreditDAO.COLUMN_CREDIT_DATE + " =@" + CreditDAO.COLUMN_CREDIT_DATE + ", "
                                       + CreditDAO.COLUMN_CREDIT_AMOUNT + " =@" + CreditDAO.COLUMN_CREDIT_AMOUNT + ", "
                                       + CreditDAO.COLUMN_CREDIT_EMPLOYEE_ID + " =@" + CreditDAO.COLUMN_CREDIT_EMPLOYEE_ID + " "
                                       + " WHERE " + CreditDAO.COLUMN_CREDIT_ID + " = " + item.Credit.CreditId+ " ";


            string updateHarvestHours = "UPDATE " + TABLE_HOURS + " SET "
                           + COLUMN_HOURS_DATE + " =@" + COLUMN_HOURS_DATE + ", "
                           + COLUMN_HOURS_SM + " =@" + COLUMN_HOURS_SM + ", "
                           + COLUMN_HOURS_EM + " =@" + COLUMN_HOURS_EM + ", "
                           + COLUMN_HOURS_SN + " =@" + COLUMN_HOURS_SN + ", "
                           + COLUMN_HOURS_EN + " =@" + COLUMN_HOURS_EN + ", "
                           + COLUMN_HOURS_PRICE + " =@" + COLUMN_HOURS_PRICE + ", "
                           + COLUMN_HOURS_REMARQUE + " =@" + COLUMN_HOURS_REMARQUE + ", "
                           + COLUMN_HOURS_EMPLOYEE_TYPE + " =@" + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                           + COLUMN_HOURS_EMPLOYEE_ID + " =@" + COLUMN_HOURS_EMPLOYEE_ID + ", "
                           + COLUMN_HOURS_TRANSPORT_ID + " =@" + COLUMN_HOURS_TRANSPORT_ID + ", "
                           + COLUMN_HOURS_CREDIT_ID + " =@" + COLUMN_HOURS_CREDIT_ID + ", "
                           + COLUMN_HOURS_PRODUCTION_ID + " =@" + COLUMN_HOURS_PRODUCTION_ID + " "
                           + " WHERE " + COLUMN_HOURS_ID + " = " + item.HarvestHoursID + " ";


            try
            {
                OpenConnection();
                transaction = mSQLiteConnection.BeginTransaction();
                sQLiteCommand = new SQLiteCommand(updateTransport, mSQLiteConnection);
                sQLiteCommand.Parameters.Add(new SQLiteParameter(TransportDAO.COLUMN_TRANSPORT_DATE, item.HarvestDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(TransportDAO.COLUMN_TRANSPORT_AMOUNT, item.TransportAmount));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(TransportDAO.COLUMN_TRANSPORT_EMPLOYEE_ID, item.Employee.EmployeeId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(TransportDAO.COLUMN_TRANSPORT_FARM_ID, item.Production.Farm.FarmId));
                sQLiteCommand.ExecuteNonQuery();

                sQLiteCommand = new SQLiteCommand(updateCredit, mSQLiteConnection);
                sQLiteCommand.Parameters.Add(new SQLiteParameter(CreditDAO.COLUMN_CREDIT_DATE, item.HarvestDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(CreditDAO.COLUMN_CREDIT_AMOUNT, item.CreditAmount));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(CreditDAO.COLUMN_CREDIT_EMPLOYEE_ID, item.Employee.EmployeeId));
                sQLiteCommand.ExecuteNonQuery();

                sQLiteCommand = new SQLiteCommand(updateHarvestHours, mSQLiteConnection);
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_DATE, item.HarvestDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_SM, item.StartMorning));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_EM, item.EndMorning));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_SN, item.StartNoon));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_EN, item.EndNoon));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_PRICE, item.HourPrice));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_REMARQUE, item.Remarque));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_EMPLOYEE_TYPE, item.EmployeeType));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_EMPLOYEE_ID, item.Employee.EmployeeId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_TRANSPORT_ID, item.Transport.TransportId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_CREDIT_ID, item.Credit.CreditId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_HOURS_PRODUCTION_ID, item.Production.ProductionID));
                sQLiteCommand.ExecuteNonQuery();
                
                transaction.Commit();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool addData(HarvestHours harvestHours)
        {
            string insertStmt = "INSERT INTO " + TABLE_HOURS + " ("
                    + COLUMN_HOURS_DATE + ", "
                    + COLUMN_HOURS_SM + ", "
                    + COLUMN_HOURS_EM + ", "
                    + COLUMN_HOURS_SN + ", "
                    + COLUMN_HOURS_EN + ", "
                    + COLUMN_HOURS_PRICE + ", "
                    + COLUMN_HOURS_REMARQUE + ", "
                    + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                    + COLUMN_HOURS_EMPLOYEE_ID + ", "
                    + COLUMN_HOURS_TRANSPORT_ID + ", "
                    + COLUMN_HOURS_CREDIT_ID + ", "
                    + COLUMN_HOURS_PRODUCTION_ID +
                    " ) VALUES ( "
                    + "@" + COLUMN_HOURS_DATE + ", "
                    + "@" + COLUMN_HOURS_SM + ", "
                    + "@" + COLUMN_HOURS_EM + ", "
                    + "@" + COLUMN_HOURS_SN + ", "
                    + "@" + COLUMN_HOURS_EN + ", "
                    + "@" + COLUMN_HOURS_PRICE + ", "
                    + "@" + COLUMN_HOURS_REMARQUE + ", "
                    + "@" + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                    + "@" + COLUMN_HOURS_EMPLOYEE_ID + ", "
                    + "@" + COLUMN_HOURS_TRANSPORT_ID + ", "
                    + "@" + COLUMN_HOURS_CREDIT_ID + ", "
                    + "@" + COLUMN_HOURS_PRODUCTION_ID
                    + " )";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(insertStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_DATE, harvestHours.HarvestDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_SM, harvestHours.StartMorning);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EM, harvestHours.EndMorning);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_SN, harvestHours.StartNoon);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EN, harvestHours.EndNoon);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_PRICE, harvestHours.HourPrice);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_REMARQUE, harvestHours.Remarque);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EMPLOYEE_TYPE, harvestHours.EmployeeType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_EMPLOYEE_ID, harvestHours.Employee.EmployeeId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_TRANSPORT_ID, harvestHours.Transport.TransportId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_CREDIT_ID, harvestHours.Credit.CreditId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_HOURS_PRODUCTION_ID, harvestHours.Production.ProductionID);
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

        public List<HarvestHours> HarvestersData()
        {
            List<HarvestHours> list = new List<HarvestHours>();
            string selectStmt = "SELECT "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + " "
                    + " FROM " + EmployeeDAO.TABLE_EMPLOYEE
                    + " WHERE " + EmployeeDAO.COLUMN_EMPLOYEE_STATUS + " = 1 "
                    + " ORDER BY " + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + " ASC;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        HarvestHours harvestHours = new HarvestHours();
                        harvestHours.Employee.EmployeeId = result.GetInt32(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_ID));
                        harvestHours.Employee.FirstName = result.GetString(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME));
                        harvestHours.Employee.LastName = result.GetString(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME));
                        list.Add(harvestHours);
                    }
                }
                return list;
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


        public void CreateTable()
        {
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_HOURS + " ("
                + COLUMN_HOURS_ID + " INTEGER PRIMARY KEY, "
                + COLUMN_HOURS_DATE + " DATE NOT NULL, "
                + COLUMN_HOURS_SM + " DATE NOT NULL, "
                + COLUMN_HOURS_EM + " DATE NOT NULL, "
                + COLUMN_HOURS_SN + " DATE NOT NULL, "
                + COLUMN_HOURS_EN + " DATE NOT NULL, "
                + COLUMN_HOURS_PRICE + " REAL, "
                + COLUMN_HOURS_REMARQUE + " TEXT, "
                + COLUMN_HOURS_EMPLOYEE_TYPE + " INTEGER NOT NULL, "
                + COLUMN_HOURS_EMPLOYEE_ID + " INTEGER NOT NULL, "
                + COLUMN_HOURS_TRANSPORT_ID + " INTEGER NOT NULL, "
                + COLUMN_HOURS_CREDIT_ID + " INTEGER NOT NULL, "
                + COLUMN_HOURS_PRODUCTION_ID + " INTEGER NOT NULL, "
                + " FOREIGN KEY (" + COLUMN_HOURS_EMPLOYEE_ID + ") REFERENCES " + EmployeeDAO.TABLE_EMPLOYEE + " (" + EmployeeDAO.COLUMN_EMPLOYEE_ID + ")"
                + " FOREIGN KEY (" + COLUMN_HOURS_TRANSPORT_ID + ") REFERENCES " + TransportDAO.TABLE_TRANSPORT + " (" + TransportDAO.COLUMN_TRANSPORT_ID + ")"
                + " FOREIGN KEY (" + COLUMN_HOURS_CREDIT_ID + ") REFERENCES " + CreditDAO.TABLE_CREDIT + " (" + CreditDAO.COLUMN_CREDIT_ID + ")"
                + " FOREIGN KEY (" + COLUMN_HOURS_PRODUCTION_ID + ") REFERENCES " + ProductionDAO.TABLE_PRODUCTION + " (" + ProductionDAO.COLUMN_PRODUCTION_ID + ")"
                + ");";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(createStmt, mSQLiteConnection);
                OpenConnection();
                sQLiteCommand.ExecuteNonQuery();
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


        public List<HarvestHours> HarvestHoursData()
        {
            string selectStmt = "SELECT "
                + TABLE_HOURS + "." + COLUMN_HOURS_ID + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_DATE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_SM + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EM + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_SN + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EN + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_PRICE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_REMARQUE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + ", "
                + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + ", "
                + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_AMOUNT + ", "
                + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + ", "
                + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_AMOUNT + ", "
                + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
                + " FROM " + TABLE_HOURS + " "
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_EMPLOYEE_ID
                + " LEFT JOIN " + TransportDAO.TABLE_TRANSPORT + " "
                + " ON " + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_TRANSPORT_ID
                + " LEFT JOIN " + CreditDAO.TABLE_CREDIT + " "
                + " ON " + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_CREDIT_ID
                + " LEFT JOIN " + ProductionDAO.TABLE_PRODUCTION + " "
                + " ON " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_PRODUCTION_ID
                + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
                + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
                + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
                + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
                + " ORDER BY " + TABLE_HOURS + "." + COLUMN_HOURS_DATE + " DESC ;";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return getHarvestHoursFromResultSet(result);
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

        public List<HarvestHours> getHarvestHoursFromResultSet(SQLiteDataReader result)
        {
            List<HarvestHours> list = new List<HarvestHours>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    HarvestHours harvestHours = new HarvestHours();
                    harvestHours.HarvestHoursID = result.GetInt32(result.GetOrdinal(COLUMN_HOURS_ID));
                    harvestHours.HarvestDate = result.GetDateTime(result.GetOrdinal(COLUMN_HOURS_DATE));
                    harvestHours.StartMorning = result.GetDateTime(result.GetOrdinal(COLUMN_HOURS_SM));
                    harvestHours.EndMorning = result.GetDateTime(result.GetOrdinal(COLUMN_HOURS_EM));
                    harvestHours.StartNoon = result.GetDateTime(result.GetOrdinal(COLUMN_HOURS_SN));
                    harvestHours.EndNoon = result.GetDateTime(result.GetOrdinal(COLUMN_HOURS_EN));
                    harvestHours.HourPrice = result.GetDouble(result.GetOrdinal(COLUMN_HOURS_PRICE));
                    harvestHours.Remarque = result.GetString(result.GetOrdinal(COLUMN_HOURS_REMARQUE));
                    harvestHours.EmployeeType = result.GetInt32(result.GetOrdinal(COLUMN_HOURS_EMPLOYEE_TYPE));
                    harvestHours.Employee.EmployeeId = result.GetInt32(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_ID));
                    harvestHours.Employee.FirstName = result.GetString(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME));
                    harvestHours.Employee.LastName = result.GetString(result.GetOrdinal(EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME));
                    harvestHours.Transport.TransportId = result.GetInt32(result.GetOrdinal(TransportDAO.COLUMN_TRANSPORT_ID));
                    harvestHours.Transport.TransportAmount = result.GetDouble(result.GetOrdinal(TransportDAO.COLUMN_TRANSPORT_AMOUNT));
                    harvestHours.Credit.CreditId = result.GetInt32(result.GetOrdinal(CreditDAO.COLUMN_CREDIT_ID));
                    harvestHours.Credit.CreditAmount = result.GetDouble(result.GetOrdinal(CreditDAO.COLUMN_CREDIT_AMOUNT));
                    harvestHours.Production.ProductionID = result.GetInt32(result.GetOrdinal(ProductionDAO.COLUMN_PRODUCTION_ID));
                    harvestHours.Production.Supplier.SupplierId = result.GetInt32(result.GetOrdinal(SupplierDAO.COLUMN_SUPPLIER_ID));
                    harvestHours.Production.Supplier.SupplierName = result.GetString(result.GetOrdinal(SupplierDAO.COLUMN_SUPPLIER_NAME));
                    harvestHours.Production.Farm.FarmId = result.GetInt32(result.GetOrdinal(FarmDAO.COLUMN_FARM_ID));
                    harvestHours.Production.Farm.FarmName = result.GetString(result.GetOrdinal(FarmDAO.COLUMN_FARM_NAME));
                    harvestHours.Production.Product.ProductId = result.GetInt32(result.GetOrdinal(ProductDAO.COLUMN_PRODUCT_ID));
                    harvestHours.Production.Product.ProductName = result.GetString(result.GetOrdinal(ProductDAO.COLUMN_PRODUCT_NAME));
                    harvestHours.Production.ProductDetail.ProductDetailId = result.GetInt32(result.GetOrdinal(ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID));
                    harvestHours.Production.ProductDetail.ProductType = result.GetString(result.GetOrdinal(ProductDetailDAO.COLUMN_PRODUCT_TYPE));
                    list.Add(harvestHours);
                }
            }
            return list;
        }

        public string getSelectQuery()
        {

            string selectproduct = "SELECT "
            + TABLE_HOURS + "." + COLUMN_HOURS_ID + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_DATE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_SM + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EM + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_SN + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EN + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_PRICE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_REMARQUE + ", "
                + TABLE_HOURS + "." + COLUMN_HOURS_EMPLOYEE_TYPE + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + ", "
                + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + ", "
                + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_AMOUNT + ", "
                + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + ", "
                + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_AMOUNT + ", "
                + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
                + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
                + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
                + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
                + " FROM " + TABLE_HOURS + " "
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_EMPLOYEE_ID
                + " LEFT JOIN " + TransportDAO.TABLE_TRANSPORT + " "
                + " ON " + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_TRANSPORT_ID
                + " LEFT JOIN " + CreditDAO.TABLE_CREDIT + " "
                + " ON " + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_CREDIT_ID
                + " LEFT JOIN " + ProductionDAO.TABLE_PRODUCTION + " "
                + " ON " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + " = " + TABLE_HOURS + "." + COLUMN_HOURS_PRODUCTION_ID
                + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
                + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
                + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
                + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
                + " ORDER BY " + TABLE_HOURS + "." + COLUMN_HOURS_DATE + " DESC ;";


            return selectproduct;
        }

    }
}
