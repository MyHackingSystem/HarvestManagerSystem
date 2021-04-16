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
    class HarvestQuantityDAO:DAO
    {
        public const string TABLE_QUANTITY = "HarvestQuantity";
        public const string COLUMN_QUANTITY_ID = "HarvestQuantityId";
        public const string COLUMN_QUANTITY_DATE = "HarvestDate";
        public const string COLUMN_QUANTITY_ALL_QUANTITY = "AllQuantity";
        public const string COLUMN_QUANTITY_BAD_QUANTITY = "BadQuantity";
        public const string COLUMN_QUANTITY_PENALTY_GENERAL = "PenaltyGeneral";
        public const string COLUMN_QUANTITY_DAMAGE_GENERAL = "DamageGeneral";
        public const string COLUMN_QUANTITY_PRICE = "ProductPrice";
        public const string COLUMN_QUANTITY_REMARQUE = "Remarque";
        public const string COLUMN_QUANTITY_HARVEST_TYPE = "HarvestType";
        public const string COLUMN_QUANTITY_EMPLOYEE_ID = "EmployeeId";
        public const string COLUMN_QUANTITY_TRANSPORT_ID = "TransportId";
        public const string COLUMN_QUANTITY_CREDIT_ID = "CreditId";
        public const string COLUMN_QUANTITY_PRODUCTION_ID = "ProductionId";

        private static HarvestQuantityDAO instance = new HarvestQuantityDAO();

        private HarvestQuantityDAO() : base() { }

        public static HarvestQuantityDAO getInstance()
        {
            if (instance == null)
            {
                instance = new HarvestQuantityDAO();
            }
            return instance;
        }


        //*******************************
        //Add production data
        //*******************************
        public bool addHarvestQuantity(HarvestQuantity harvestQuantity)
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


            var insertHarvestHours = "INSERT INTO " + TABLE_QUANTITY + " ("
                    + COLUMN_QUANTITY_DATE + ", "
                    + COLUMN_QUANTITY_ALL_QUANTITY + ", "
                    + COLUMN_QUANTITY_BAD_QUANTITY + ", "
                    + COLUMN_QUANTITY_PENALTY_GENERAL + ", "
                    + COLUMN_QUANTITY_DAMAGE_GENERAL + ", "
                    + COLUMN_QUANTITY_PRICE + ", "
                    + COLUMN_QUANTITY_REMARQUE + ", "
                    + COLUMN_QUANTITY_HARVEST_TYPE + ", "
                    + COLUMN_QUANTITY_EMPLOYEE_ID + ", "
                    + COLUMN_QUANTITY_TRANSPORT_ID + ", "
                    + COLUMN_QUANTITY_CREDIT_ID + ", "
                    + COLUMN_QUANTITY_PRODUCTION_ID +
                    " ) VALUES ( "
                    + "@" + COLUMN_QUANTITY_DATE + ", "
                    + "@" + COLUMN_QUANTITY_ALL_QUANTITY + ", "
                    + "@" + COLUMN_QUANTITY_BAD_QUANTITY + ", "
                    + "@" + COLUMN_QUANTITY_PENALTY_GENERAL + ", "
                    + "@" + COLUMN_QUANTITY_DAMAGE_GENERAL + ", "
                    + "@" + COLUMN_QUANTITY_PRICE + ", "
                    + "@" + COLUMN_QUANTITY_REMARQUE + ", "
                    + "@" + COLUMN_QUANTITY_HARVEST_TYPE + ", "
                    + "@" + COLUMN_QUANTITY_EMPLOYEE_ID + ", "
                    + "@" + COLUMN_QUANTITY_TRANSPORT_ID + ", "
                    + "@" + COLUMN_QUANTITY_CREDIT_ID + ", "
                    + "@" + COLUMN_QUANTITY_PRODUCTION_ID
                    + " )";

            try
            {
                OpenConnection();
                transaction = mSQLiteConnection.BeginTransaction();
                sQLiteCommand = new SQLiteCommand(insertTransport, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_DATE, harvestQuantity.HarvestDate);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_AMOUNT, harvestQuantity.Transport.TransportAmount);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_EMPLOYEE_ID, harvestQuantity.Employee.EmployeeId);
                sQLiteCommand.Parameters.AddWithValue(TransportDAO.COLUMN_TRANSPORT_FARM_ID, harvestQuantity.Production.Farm.FarmId);
                sQLiteCommand.ExecuteNonQuery();

                long rowTransportId = 0;

                rowTransportId = mSQLiteConnection.LastInsertRowId;

                sQLiteCommand = new SQLiteCommand(insertCredit, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(CreditDAO.COLUMN_CREDIT_DATE, harvestQuantity.HarvestDate);
                sQLiteCommand.Parameters.AddWithValue(CreditDAO.COLUMN_CREDIT_AMOUNT, harvestQuantity.Credit.CreditAmount);
                sQLiteCommand.Parameters.AddWithValue(CreditDAO.COLUMN_CREDIT_EMPLOYEE_ID, harvestQuantity.Employee.EmployeeId);
                sQLiteCommand.ExecuteNonQuery();

                long rowCreditId = 0;
                rowCreditId = mSQLiteConnection.LastInsertRowId;

                sQLiteCommand = new SQLiteCommand(insertHarvestHours, mSQLiteConnection);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_DATE, harvestQuantity.HarvestDate);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_ALL_QUANTITY, harvestQuantity.AllQuantity);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_BAD_QUANTITY, harvestQuantity.BadQuantity);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_PENALTY_GENERAL, harvestQuantity.PenaltyGeneral);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_DAMAGE_GENERAL, harvestQuantity.DamageGeneral);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_PRICE, harvestQuantity.ProductPrice);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_REMARQUE, harvestQuantity.Remarque);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_HARVEST_TYPE, harvestQuantity.HarvestType);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_EMPLOYEE_ID, harvestQuantity.Employee.EmployeeId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_TRANSPORT_ID, rowTransportId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_CREDIT_ID, rowCreditId);
                sQLiteCommand.Parameters.AddWithValue(COLUMN_QUANTITY_PRODUCTION_ID, harvestQuantity.Production.ProductionID);
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

        //***********************************
        //Get Quantity data by production id
        //***********************************
        public List<HarvestQuantity> HarvestQuantityByProduction(Production production)
        {
            string selectStmt = "SELECT "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_ID + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_DATE + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_ALL_QUANTITY + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_BAD_QUANTITY + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_PENALTY_GENERAL + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_DAMAGE_GENERAL + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_PRICE + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_REMARQUE + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_HARVEST_TYPE + ", "
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
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_CODE + " "
                + " FROM " + TABLE_QUANTITY + " "
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_EMPLOYEE_ID
                + " LEFT JOIN " + TransportDAO.TABLE_TRANSPORT + " "
                + " ON " + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_TRANSPORT_ID
                + " LEFT JOIN " + CreditDAO.TABLE_CREDIT + " "
                + " ON " + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_CREDIT_ID
                + " LEFT JOIN " + ProductionDAO.TABLE_PRODUCTION + " "
                + " ON " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_PRODUCTION_ID
                + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
                + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
                + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
                + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
                + " WHERE " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_PRODUCTION_ID + " = " + production.ProductionID + " "
                + " ORDER BY " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_DATE + " DESC ;";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return getHarvestQuantityFromResultSet(result);
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

        public List<HarvestQuantity> getHarvestQuantityFromResultSet(SQLiteDataReader result)
        {
            List<HarvestQuantity> list = new List<HarvestQuantity>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    HarvestQuantity item = new HarvestQuantity();
                    item.HarvestQuantityId = Convert.ToInt32((result[COLUMN_QUANTITY_ID]).ToString());
                    item.HarvestDate = (DateTime)result[COLUMN_QUANTITY_DATE];
                    item.AllQuantity = Convert.ToDouble((result[COLUMN_QUANTITY_ALL_QUANTITY]).ToString());
                    item.BadQuantity = Convert.ToDouble((result[COLUMN_QUANTITY_BAD_QUANTITY]).ToString());
                    item.PenaltyGeneral = Convert.ToDouble((result[COLUMN_QUANTITY_PENALTY_GENERAL]).ToString());
                    item.DamageGeneral = Convert.ToDouble((result[COLUMN_QUANTITY_DAMAGE_GENERAL]).ToString());
                    item.ProductPrice = Convert.ToDouble((result[COLUMN_QUANTITY_PRICE]).ToString());
                    item.Remarque = Convert.ToString(result[COLUMN_QUANTITY_REMARQUE]);
                    item.HarvestType = Convert.ToInt32((result[COLUMN_QUANTITY_HARVEST_TYPE]).ToString());
                    item.Employee.EmployeeId = Convert.ToInt32((result[EmployeeDAO.COLUMN_EMPLOYEE_ID]).ToString());
                    item.Employee.FirstName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME];
                    item.Employee.LastName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME];
                    item.Transport.TransportId = Convert.ToInt32((result[TransportDAO.COLUMN_TRANSPORT_ID]).ToString());
                    item.Transport.TransportAmount = Convert.ToDouble((result[TransportDAO.COLUMN_TRANSPORT_AMOUNT]).ToString());
                    item.Credit.CreditId = Convert.ToInt32((result[CreditDAO.COLUMN_CREDIT_ID]).ToString());
                    item.Credit.CreditAmount = Convert.ToDouble((result[CreditDAO.COLUMN_CREDIT_AMOUNT]).ToString());
                    item.Production.ProductionID = Convert.ToInt32((result[ProductionDAO.COLUMN_PRODUCTION_ID]).ToString());
                    item.Production.Supplier.SupplierId = Convert.ToInt32((result[SupplierDAO.COLUMN_SUPPLIER_ID]).ToString());
                    item.Production.Supplier.SupplierName = (string)result[SupplierDAO.COLUMN_SUPPLIER_NAME];
                    item.Production.Farm.FarmId = Convert.ToInt32((result[FarmDAO.COLUMN_FARM_ID]).ToString());
                    item.Production.Farm.FarmName = (string)result[FarmDAO.COLUMN_FARM_NAME];
                    item.Production.Product.ProductId = Convert.ToInt32((result[ProductDAO.COLUMN_PRODUCT_ID]).ToString());
                    item.Production.Product.ProductName = (string)result[ProductDAO.COLUMN_PRODUCT_NAME];
                    item.Production.ProductDetail.ProductDetailId = Convert.ToInt32((result[ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID]).ToString());
                    item.Production.ProductDetail.ProductType = (string)result[ProductDetailDAO.COLUMN_PRODUCT_TYPE];
                    item.Production.ProductDetail.ProductCode = (string)result[ProductDetailDAO.COLUMN_PRODUCT_CODE];
                    list.Add(item);
                }
            }
            return list;
        }


        //***********************************
        //Get Quantity data
        //***********************************
        public List<HarvestQuantity> getData()
        {
            string selectStmt = "SELECT "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_ID + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_DATE + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_ALL_QUANTITY + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_BAD_QUANTITY + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_PENALTY_GENERAL + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_DAMAGE_GENERAL + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_PRICE + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_REMARQUE + ", "
                + TABLE_QUANTITY + "." + COLUMN_QUANTITY_HARVEST_TYPE + ", "
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
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + ", "
                + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_CODE + " "
                + " FROM " + TABLE_QUANTITY + " "
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_EMPLOYEE_ID
                + " LEFT JOIN " + TransportDAO.TABLE_TRANSPORT + " "
                + " ON " + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_TRANSPORT_ID
                + " LEFT JOIN " + CreditDAO.TABLE_CREDIT + " "
                + " ON " + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_CREDIT_ID
                + " LEFT JOIN " + ProductionDAO.TABLE_PRODUCTION + " "
                + " ON " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + " = " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_PRODUCTION_ID
                + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
                + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
                + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
                + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
                + " ORDER BY " + TABLE_QUANTITY + "." + COLUMN_QUANTITY_DATE + " DESC ;";
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(selectStmt, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return getHarvestQuantityFromResultSet(result);
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


        internal bool updateHoursWork(HarvestQuantity item)
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
                                       + " WHERE " + CreditDAO.COLUMN_CREDIT_ID + " = " + item.Credit.CreditId + " ";


            string updateHarvestHours = "UPDATE " + TABLE_QUANTITY + " SET "
                           + COLUMN_QUANTITY_DATE + " =@" + COLUMN_QUANTITY_DATE + ", "
                           + COLUMN_QUANTITY_ALL_QUANTITY + " =@" + COLUMN_QUANTITY_ALL_QUANTITY + ", "
                           + COLUMN_QUANTITY_BAD_QUANTITY + " =@" + COLUMN_QUANTITY_BAD_QUANTITY + ", "
                           + COLUMN_QUANTITY_PENALTY_GENERAL + " =@" + COLUMN_QUANTITY_PENALTY_GENERAL + ", "
                           + COLUMN_QUANTITY_DAMAGE_GENERAL + " =@" + COLUMN_QUANTITY_DAMAGE_GENERAL + ", "
                           + COLUMN_QUANTITY_PRICE + " =@" + COLUMN_QUANTITY_PRICE + ", "
                           + COLUMN_QUANTITY_REMARQUE + " =@" + COLUMN_QUANTITY_REMARQUE + ", "
                           + COLUMN_QUANTITY_HARVEST_TYPE + " =@" + COLUMN_QUANTITY_HARVEST_TYPE + ", "
                           + COLUMN_QUANTITY_EMPLOYEE_ID + " =@" + COLUMN_QUANTITY_EMPLOYEE_ID + ", "
                           + COLUMN_QUANTITY_TRANSPORT_ID + " =@" + COLUMN_QUANTITY_TRANSPORT_ID + ", "
                           + COLUMN_QUANTITY_CREDIT_ID + " =@" + COLUMN_QUANTITY_CREDIT_ID + ", "
                           + COLUMN_QUANTITY_PRODUCTION_ID + " =@" + COLUMN_QUANTITY_PRODUCTION_ID + " "
                           + " WHERE " + COLUMN_QUANTITY_ID + " = " + item.HarvestQuantityId + " ";

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
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_DATE, item.HarvestDate));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_ALL_QUANTITY, item.AllQuantity));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_BAD_QUANTITY, item.BadQuantity));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_PENALTY_GENERAL, item.PenaltyGeneral));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_DAMAGE_GENERAL, item.DamageGeneral));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_PRICE, item.ProductPrice));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_REMARQUE, item.Remarque));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_HARVEST_TYPE, item.Employee.EmployeeId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_EMPLOYEE_ID, item.Transport.TransportId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_TRANSPORT_ID, item.Credit.CreditId));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_CREDIT_ID, item.Production.ProductionID));
                sQLiteCommand.Parameters.Add(new SQLiteParameter(COLUMN_QUANTITY_PRODUCTION_ID, item.Production.ProductionID));
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


        //*******************************
        //Get Add Hours data
        //*******************************
        public List<HarvestQuantity> HarvestersData()
        {
            List<HarvestQuantity> list = new List<HarvestQuantity>();
            String selectStmt = "SELECT "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
                + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + " "
                    + " FROM " + EmployeeDAO.TABLE_EMPLOYEE
                    + " WHERE " + EmployeeDAO.COLUMN_EMPLOYEE_STATUS + " = 1 "
                    + " AND " + EmployeeDAO.COLUMN_EMPLOYEE_IS_EXIST + " = 1 "
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
                        HarvestQuantity item = new HarvestQuantity();
                        item.Employee.EmployeeId = Convert.ToInt32((result[EmployeeDAO.COLUMN_EMPLOYEE_ID]).ToString());
                        item.Employee.FirstName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME];
                        item.Employee.LastName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME];
                        list.Add(item);
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
            string createStmt = "CREATE TABLE IF NOT EXISTS " + TABLE_QUANTITY + " ("
                + COLUMN_QUANTITY_ID + " INTEGER PRIMARY KEY, "
                + COLUMN_QUANTITY_DATE + " DATE NOT NULL, "
                + COLUMN_QUANTITY_ALL_QUANTITY + " REAL DEFAULT 0, "
                + COLUMN_QUANTITY_BAD_QUANTITY + " REAL DEFAULT 0, "
                + COLUMN_QUANTITY_PENALTY_GENERAL + " REAL DEFAULT 0, "
                + COLUMN_QUANTITY_DAMAGE_GENERAL + " REAL DEFAULT 0, "
                + COLUMN_QUANTITY_PRICE + " REAL DEFAULT 0, "
                + COLUMN_QUANTITY_REMARQUE + " TEXT, "
                + COLUMN_QUANTITY_HARVEST_TYPE + " INTEGER NOT NULL, "
                + COLUMN_QUANTITY_EMPLOYEE_ID + " INTEGER NOT NULL, "
                + COLUMN_QUANTITY_TRANSPORT_ID + " INTEGER NOT NULL, "
                + COLUMN_QUANTITY_CREDIT_ID + " INTEGER NOT NULL, "
                + COLUMN_QUANTITY_PRODUCTION_ID + " INTEGER NOT NULL, "
                + " FOREIGN KEY (" + COLUMN_QUANTITY_EMPLOYEE_ID + ") REFERENCES " + EmployeeDAO.TABLE_EMPLOYEE + " (" + EmployeeDAO.COLUMN_EMPLOYEE_ID + ")"
                + " FOREIGN KEY (" + COLUMN_QUANTITY_TRANSPORT_ID + ") REFERENCES " + TransportDAO.TABLE_TRANSPORT + " (" + TransportDAO.COLUMN_TRANSPORT_ID + ")"
                + " FOREIGN KEY (" + COLUMN_QUANTITY_CREDIT_ID + ") REFERENCES " + CreditDAO.TABLE_CREDIT + " (" + CreditDAO.COLUMN_CREDIT_ID + ")"
                + " FOREIGN KEY (" + COLUMN_QUANTITY_PRODUCTION_ID + ") REFERENCES " + ProductionDAO.TABLE_PRODUCTION + " (" + ProductionDAO.COLUMN_PRODUCTION_ID + ")"
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

    }
}
