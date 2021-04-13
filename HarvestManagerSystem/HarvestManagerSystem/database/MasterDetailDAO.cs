using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using HarvestManagerSystem.model;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HarvestManagerSystem.database
{
    class MasterDetailDAO:DAO
    {

        public const string TABLE_PRODUCTION = "Production";
        public const string COLUMN_PRODUCTION_ID = "ProductionId";
        public const string COLUMN_PRODUCTION_TYPE = "ProductionType";
        public const string COLUMN_PRODUCTION_DATE = "ProductionDate";
        public const string COLUMN_PRODUCTION_SUPPLIER_ID = "SupplierId";
        public const string COLUMN_PRODUCTION_FARM_ID = "FarmId";
        public const string COLUMN_PRODUCTION_PRODUCT_ID = "ProductId";
        public const string COLUMN_PRODUCTION_PRODUCT_DETAIL_ID = "ProductDetailId";
        public const string COLUMN_PRODUCTION_TOTAL_EMPLOYEES = "TotalEmployees";
        public const string COLUMN_PRODUCTION_TOTAL_QUANTITY = "TotalQuantity";
        public const string COLUMN_PRODUCTION_TOTAL_MINUTES = "TotalHours";
        public const string COLUMN_PRODUCTION_PRICE = "Price";

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



        private static MasterDetailDAO instance = new MasterDetailDAO();
        private MasterDetailDAO() : base() { }
        public static MasterDetailDAO getInstance()
        {
            if (instance == null)
            {
                instance = new MasterDetailDAO();
            }
            return instance;
        }

        private DataGridView masterDataGridView = new DataGridView();
        private BindingSource masterBindingSource = new BindingSource();
        private DataGridView detailsDataGridView = new DataGridView();
        private BindingSource detailsBindingSource = new BindingSource();

        public void GetData()
        {
            // Bind the DataGridView controls to the BindingSource
            // components and load the data from the database.
            masterDataGridView.DataSource = masterBindingSource;
            detailsDataGridView.DataSource = detailsBindingSource;
            GetData();

            // Resize the master DataGridView columns to fit the newly loaded data.
            masterDataGridView.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            detailsDataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            



            try
            {
                // Specify a connection string. Replace the given value with a
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
               // String connectionString =
               //     "Integrated Security=SSPI;Persist Security Info=False;" +
              //      "Initial Catalog=Northwind;Data Source=localhost";
                //SqlConnection connection = new SqlConnection(connectionString);

                // Create a DataSet.
                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;

                SQLiteDataAdapter masterDataAdapter = new SQLiteDataAdapter("select * from Production", mSQLiteConnection);
                masterDataAdapter.Fill(data, "Production");

                SQLiteDataAdapter detailsDataAdapter = new SQLiteDataAdapter("select * from HarvestHours", mSQLiteConnection);
                detailsDataAdapter.Fill(data, "HarvestHours");

                // Establish a relationship between the two tables.
                DataRelation relation = new DataRelation("ProductionHarvestHours",
                    data.Tables["Productio"].Columns["ProductionId"],
                    data.Tables["HarvestHours"].Columns["ProductionId"]);
                data.Relations.Add(relation);

                // Bind the master data connector to the Customers table.
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "Production";

                // Bind the details data connector to the master data connector,
                // using the DataRelation name to filter the information in the
                // details table based on the current row in the master table.
                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "ProductionHarvestHours";
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

    }
}
