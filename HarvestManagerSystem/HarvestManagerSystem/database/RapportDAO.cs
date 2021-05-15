using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.database
{
    class RapportDAO:DAO
    {

        private static RapportDAO instance = new RapportDAO();

        private RapportDAO() : base() { }

        public static RapportDAO getInstance()
        {
            if (instance == null)
            {
                instance = new RapportDAO();
            }
            return instance;
        }


        //*******************************
        //Search Company Rapport data by date
        //*******************************
        public List<CompanyRapport> searchCompanyProduction(DateTime fromDate, DateTime toDate, int type, int supplierId)
        {
            string select = "SELECT "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_DATE + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRICE + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
        + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_ID + ", "
        + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_ALL_QUANTITY + ", "
        + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_BAD_QUANTITY + ", "
        + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + ", "
        + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME + ", "
        + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
        + " FROM " + ProductionDAO.TABLE_PRODUCTION
        + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
        + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
        + " LEFT JOIN " + HarvestQuantityDAO.TABLE_QUANTITY + " "
        + " ON " + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_PRODUCTION_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID
        + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
        + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_EMPLOYEE_ID
        + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
        + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
        + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
        + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
        + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
        + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
        + " WHERE " + ProductionDAO.COLUMN_PRODUCTION_DATE
        + " BETWEEN strftime('%Y-%m-%d %H:%M:%S', '" + fromDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') AND strftime('%Y-%m-%d %H:%M:%S', '" + toDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') "
        + " AND " + ProductionDAO.COLUMN_PRODUCTION_TYPE + " != " + type
        + " AND " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + supplierId
        + " ORDER BY " + ProductionDAO.COLUMN_PRODUCTION_DATE + " DESC ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(select, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return CompanyProductionDataReader(result);
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

        //Help method to get data from SQLiteDataReader
        private List<CompanyRapport> CompanyProductionDataReader(SQLiteDataReader result)
        {
            List<CompanyRapport> list = new List<CompanyRapport>();

            if (result.HasRows)
            {
                while (result.Read())
                {
                  
                    CompanyRapport rpr = new CompanyRapport();
                    rpr.HarvestDate = (DateTime)result[ProductionDAO.COLUMN_PRODUCTION_DATE];
                    rpr.AllQuantity = Convert.ToDouble((result[HarvestQuantityDAO.COLUMN_QUANTITY_ALL_QUANTITY]).ToString());
                    rpr.BadQuantity = Convert.ToDouble((result[HarvestQuantityDAO.COLUMN_QUANTITY_BAD_QUANTITY]).ToString());
                    rpr.Price = Convert.ToDouble((result[ProductionDAO.COLUMN_PRODUCTION_PRICE]).ToString());
                    rpr.Supplier = (string)result[SupplierDAO.COLUMN_SUPPLIER_NAME];
                    rpr.Employee = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME] + (string)result[EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME]; ; 
                    rpr.Farm = (string)result[FarmDAO.COLUMN_FARM_NAME];
                    rpr.Product = (string)result[ProductDAO.COLUMN_PRODUCT_NAME];
                    rpr.Type = (string)result[ProductDetailDAO.COLUMN_PRODUCT_TYPE];
                    list.Add(rpr);
                }
            }

            return list;
        }


        //*******************************
        //Get Hours Employee Rapport
        //*******************************
        public List<HoursEmployeeRapport> SearchHoursEmployeeRapport(DateTime fromDate, DateTime toDate, int employeeId)
        {
            string selectStmt = "SELECT "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_ID + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_DATE + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_SM + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_EM + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_SN + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_EN + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_PRICE + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_REMARQUE + ", "
                + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_EMPLOYEE_TYPE + ", "
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
                + " FROM " + HarvestHoursDAO.TABLE_HOURS + " "
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_EMPLOYEE_ID
                + " LEFT JOIN " + TransportDAO.TABLE_TRANSPORT + " "
                + " ON " + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + " = " + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_TRANSPORT_ID
                + " LEFT JOIN " + CreditDAO.TABLE_CREDIT + " "
                + " ON " + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + " = " + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_CREDIT_ID
                + " LEFT JOIN " + ProductionDAO.TABLE_PRODUCTION + " "
                + " ON " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + " = " + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_PRODUCTION_ID
                + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
                + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
                + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
                + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
                + " WHERE " + HarvestHoursDAO.COLUMN_HOURS_DATE
                + " BETWEEN strftime('%Y-%m-%d %H:%M:%S', '" + fromDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') AND strftime('%Y-%m-%d %H:%M:%S', '" + toDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') "
                + " AND " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + employeeId
                + " ORDER BY " + HarvestHoursDAO.TABLE_HOURS + "." + HarvestHoursDAO.COLUMN_HOURS_DATE + " DESC ;";
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

        public List<HoursEmployeeRapport> getHarvestHoursFromResultSet(SQLiteDataReader result)
        {
            List<HoursEmployeeRapport> list = new List<HoursEmployeeRapport>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    HoursEmployeeRapport harvestHours = new HoursEmployeeRapport();
                    harvestHours.HarvestDate = (DateTime)result[HarvestHoursDAO.COLUMN_HOURS_DATE];
                    harvestHours.StartMorning = (DateTime)result[HarvestHoursDAO.COLUMN_HOURS_SM];
                    harvestHours.EndMorning = (DateTime)result[HarvestHoursDAO.COLUMN_HOURS_EM];
                    harvestHours.StartNoon = (DateTime)result[HarvestHoursDAO.COLUMN_HOURS_SN];
                    harvestHours.EndNoon = (DateTime)result[HarvestHoursDAO.COLUMN_HOURS_EN];
                    harvestHours.HourPrice = Convert.ToDouble((result[HarvestHoursDAO.COLUMN_HOURS_PRICE]).ToString());
                    harvestHours.EmployeeType = Convert.ToInt32((result[HarvestHoursDAO.COLUMN_HOURS_EMPLOYEE_TYPE]).ToString());
                    harvestHours.Employee.EmployeeId = Convert.ToInt32((result[EmployeeDAO.COLUMN_EMPLOYEE_ID]).ToString());
                    harvestHours.Employee.FirstName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_FIRST_NAME];
                    harvestHours.Employee.LastName = (string)result[EmployeeDAO.COLUMN_EMPLOYEE_LAST_NAME];
                    harvestHours.Transport.TransportId = Convert.ToInt32((result[TransportDAO.COLUMN_TRANSPORT_ID]).ToString());
                    harvestHours.Transport.TransportAmount = Convert.ToDouble((result[TransportDAO.COLUMN_TRANSPORT_AMOUNT]).ToString());
                    harvestHours.Credit.CreditId = Convert.ToInt32((result[CreditDAO.COLUMN_CREDIT_ID]).ToString());
                    harvestHours.Credit.CreditAmount = Convert.ToDouble((result[CreditDAO.COLUMN_CREDIT_AMOUNT]).ToString());
                    harvestHours.Production.ProductionID = Convert.ToInt32((result[ProductionDAO.COLUMN_PRODUCTION_ID]).ToString());
                    harvestHours.Production.Supplier.SupplierId = Convert.ToInt32((result[SupplierDAO.COLUMN_SUPPLIER_ID]).ToString());
                    harvestHours.Production.Supplier.SupplierName = (string)result[SupplierDAO.COLUMN_SUPPLIER_NAME];
                    harvestHours.Production.Farm.FarmId = Convert.ToInt32((result[FarmDAO.COLUMN_FARM_ID]).ToString());
                    harvestHours.Production.Farm.FarmName = (string)result[FarmDAO.COLUMN_FARM_NAME];
                    harvestHours.Production.Product.ProductId = Convert.ToInt32((result[ProductDAO.COLUMN_PRODUCT_ID]).ToString());
                    harvestHours.Production.Product.ProductName = (string)result[ProductDAO.COLUMN_PRODUCT_NAME];
                    harvestHours.Production.ProductDetail.ProductDetailId = Convert.ToInt32((result[ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID]).ToString());
                    harvestHours.Production.ProductDetail.ProductType = (string)result[ProductDetailDAO.COLUMN_PRODUCT_TYPE];
                    list.Add(harvestHours);
                }
            }

            return list;
        }


        //***********************************
        //Get Quantity Employee Rapport
        //***********************************
        public List<QuantityEmployeeRapport> SearchQuantityEmployeeRapport(DateTime fromDate, DateTime toDate, int employeeId)
        {
            string selectStmt = "SELECT "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_ID + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_DATE + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_ALL_QUANTITY + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_BAD_QUANTITY + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_PENALTY_GENERAL + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_DAMAGE_GENERAL + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_PRICE + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_REMARQUE + ", "
                + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_HARVEST_TYPE + ", "
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
                + " FROM " + HarvestQuantityDAO.TABLE_QUANTITY + " "
                + " LEFT JOIN " + EmployeeDAO.TABLE_EMPLOYEE + " "
                + " ON " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_EMPLOYEE_ID
                + " LEFT JOIN " + TransportDAO.TABLE_TRANSPORT + " "
                + " ON " + TransportDAO.TABLE_TRANSPORT + "." + TransportDAO.COLUMN_TRANSPORT_ID + " = " + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_TRANSPORT_ID
                + " LEFT JOIN " + CreditDAO.TABLE_CREDIT + " "
                + " ON " + CreditDAO.TABLE_CREDIT + "." + CreditDAO.COLUMN_CREDIT_ID + " = " + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_CREDIT_ID
                + " LEFT JOIN " + ProductionDAO.TABLE_PRODUCTION + " "
                + " ON " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + " = " + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_PRODUCTION_ID
                + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
                + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
                + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
                + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
                + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
                + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
                + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
                + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
                + " WHERE " + HarvestHoursDAO.COLUMN_HOURS_DATE
                + " BETWEEN strftime('%Y-%m-%d %H:%M:%S', '" + fromDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') AND strftime('%Y-%m-%d %H:%M:%S', '" + toDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') "
                + " AND " + EmployeeDAO.TABLE_EMPLOYEE + "." + EmployeeDAO.COLUMN_EMPLOYEE_ID + " = " + employeeId
                + " ORDER BY " + HarvestQuantityDAO.TABLE_QUANTITY + "." + HarvestQuantityDAO.COLUMN_QUANTITY_DATE + " DESC ;";
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

        public List<QuantityEmployeeRapport> getHarvestQuantityFromResultSet(SQLiteDataReader result)
        {
            List<QuantityEmployeeRapport> list = new List<QuantityEmployeeRapport>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    QuantityEmployeeRapport item = new QuantityEmployeeRapport();
                    item.HarvestDate = (DateTime)result[HarvestQuantityDAO.COLUMN_QUANTITY_DATE];
                    item.AllQuantity = Convert.ToDouble((result[HarvestQuantityDAO.COLUMN_QUANTITY_ALL_QUANTITY]).ToString());
                    item.BadQuantity = Convert.ToDouble((result[HarvestQuantityDAO.COLUMN_QUANTITY_BAD_QUANTITY]).ToString());
                    item.PenaltyGeneral = Convert.ToDouble((result[HarvestQuantityDAO.COLUMN_QUANTITY_PENALTY_GENERAL]).ToString());
                    item.DamageGeneral = Convert.ToDouble((result[HarvestQuantityDAO.COLUMN_QUANTITY_DAMAGE_GENERAL]).ToString());
                    item.ProductPrice = Convert.ToDouble((result[HarvestQuantityDAO.COLUMN_QUANTITY_PRICE]).ToString());
                    item.HarvestType = Convert.ToInt32((result[HarvestQuantityDAO.COLUMN_QUANTITY_HARVEST_TYPE]).ToString());
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
                    list.Add(item);
                }
            }
            return list;
        }

        //*******************************
        //Search production data by date
        //*******************************
        public List<Production> searchHarvestQuantityProduction(DateTime fromDate, DateTime toDate, int type, int supplierId)
        {
            string select = "SELECT "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_ID + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_TYPE + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_DATE + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_TOTAL_EMPLOYEES + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_TOTAL_QUANTITY + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_TOTAL_MINUTES + ", "
        + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRICE + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + ", "
        + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_NAME + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + ", "
        + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_NAME + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + ", "
        + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_NAME + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + ", "
        + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_TYPE + " "
        + " FROM " + ProductionDAO.TABLE_PRODUCTION
        + " LEFT JOIN " + SupplierDAO.TABLE_SUPPLIER + " "
        + " ON " + SupplierDAO.TABLE_SUPPLIER + "." + SupplierDAO.COLUMN_SUPPLIER_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID
        + " LEFT JOIN " + FarmDAO.TABLE_FARM + " "
        + " ON " + FarmDAO.TABLE_FARM + "." + FarmDAO.COLUMN_FARM_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_FARM_ID
        + " LEFT JOIN " + ProductDAO.TABLE_PRODUCT + " "
        + " ON " + ProductDAO.TABLE_PRODUCT + "." + ProductDAO.COLUMN_PRODUCT_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_ID
        + " LEFT JOIN " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + " "
        + " ON " + ProductDetailDAO.TABLE_PRODUCT_DETAIL + "." + ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID + " = " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_PRODUCT_DETAIL_ID
        + " WHERE " + ProductionDAO.COLUMN_PRODUCTION_DATE
        + " BETWEEN strftime('%Y-%m-%d %H:%M:%S', '" + fromDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') AND strftime('%Y-%m-%d %H:%M:%S', '" + toDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "') "
        + " AND " + ProductionDAO.COLUMN_PRODUCTION_TYPE + " != " + type
        + " AND " + ProductionDAO.TABLE_PRODUCTION + "." + ProductionDAO.COLUMN_PRODUCTION_SUPPLIER_ID + " = " + supplierId
        + " ORDER BY " + ProductionDAO.COLUMN_PRODUCTION_DATE + " DESC ;";

            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(select, mSQLiteConnection);
                OpenConnection();
                SQLiteDataReader result = sQLiteCommand.ExecuteReader();
                return ProductionResultDataReader(result);
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

        //Help method to get data from SQLiteDataReader
        private List<Production> ProductionResultDataReader(SQLiteDataReader result)
        {
            List<Production> list = new List<Production>();

            if (result.HasRows)
            {
                while (result.Read())
                {
                    Production production = new Production();
                    production.ProductionID = Convert.ToInt32((result[ProductionDAO.COLUMN_PRODUCTION_ID]).ToString());
                    production.ProductionType = Convert.ToInt32((result[ProductionDAO.COLUMN_PRODUCTION_TYPE]).ToString());
                    production.ProductionDate = (DateTime)result[ProductionDAO.COLUMN_PRODUCTION_DATE];
                    production.TotalEmployee = Convert.ToInt32((result[ProductionDAO.COLUMN_PRODUCTION_TOTAL_EMPLOYEES]).ToString());
                    production.TotalQuantity = Convert.ToDouble((result[ProductionDAO.COLUMN_PRODUCTION_TOTAL_QUANTITY]).ToString());
                    production.TotalMinutes = Convert.ToDouble((result[ProductionDAO.COLUMN_PRODUCTION_TOTAL_MINUTES]).ToString());
                    production.Price = Convert.ToDouble((result[ProductionDAO.COLUMN_PRODUCTION_PRICE]).ToString());
                    production.Supplier.SupplierId = Convert.ToInt32((result[SupplierDAO.COLUMN_SUPPLIER_ID]).ToString());
                    production.Supplier.SupplierName = (string)result[SupplierDAO.COLUMN_SUPPLIER_NAME];
                    production.Farm.FarmId = Convert.ToInt32((result[FarmDAO.COLUMN_FARM_ID]).ToString());
                    production.Farm.FarmName = (string)result[FarmDAO.COLUMN_FARM_NAME];
                    production.Product.ProductId = Convert.ToInt32((result[ProductDAO.COLUMN_PRODUCT_ID]).ToString());
                    production.Product.ProductName = (string)result[ProductDAO.COLUMN_PRODUCT_NAME];
                    production.ProductDetail.ProductDetailId = Convert.ToInt32((result[ProductDetailDAO.COLUMN_PRODUCT_DETAIL_ID]).ToString());
                    production.ProductDetail.ProductType = (string)result[ProductDetailDAO.COLUMN_PRODUCT_TYPE];
                    list.Add(production);
                }
            }

            return list;
        }

    }
}
