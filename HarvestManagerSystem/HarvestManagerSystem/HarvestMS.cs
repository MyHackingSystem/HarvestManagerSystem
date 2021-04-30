using HarvestManagerSystem.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;
using System.Data.SQLite;
using FastMember;

namespace HarvestManagerSystem
{
    public partial class HarvestMS : Form
    {
        EmployeeDAO employeeDAO = EmployeeDAO.getInstance();
        SupplierDAO supplierDAO = SupplierDAO.getInstance();
        SupplyDAO supplyDAO = SupplyDAO.getInstance();
        FarmDAO farmDAO = FarmDAO.getInstance();
        SeasonDAO seasonDAO = SeasonDAO.getInstance();
        ProductDAO productDAO = ProductDAO.getInstance();
        ProductDetailDAO productDetailDAO = ProductDetailDAO.getInstance();
        CreditDAO creditDAO = CreditDAO.getInstance();
        TransportDAO transportDAO = TransportDAO.getInstance();
        HarvestHoursDAO harvestHoursDAO = HarvestHoursDAO.getInstance();
        HarvestQuantityDAO harvestQuantityDAO = HarvestQuantityDAO.getInstance();
        ProductionDAO productionDAO = ProductionDAO.getInstance();

        private static List<Employee> list = new List<Employee>();


        public HarvestMS()
        {
            InitializeComponent();
        }

        private void HarvestMS_Load(object sender, EventArgs e)
        {
            //DisplayQuantityData();
            //employeeDAO.CreateTable();
            //farmDAO.CreateTable();
            //seasonDAO.CreateTable();
            //supplierDAO.CreateTable();
            //supplyDAO.CreateTable();
        }

        private void tabProduction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabProduction.SelectedIndex)
            {
                case 0:
                    //DisplayQuantityData();
                    break;
                case 1:
                    //DisplayHoursData();
                    break;
                case 2:
                    //DisplayCreditData();
                    //DisplayTransportData();
                    break;
                case 3:
                    DisplayEmployeeData();
                    EndCotract();
                    break;
                case 4:
                    DisplaySupplierData();
                    break;
                case 5:
                    DisplayFarmData();
                    break;
                case 6:
                    DisplayProductData();
                    break;
                default:
                    Console.WriteLine("nothing");
                    break;
            }
        }

        #region ********************************************* Individual CODE ***********************************************************************

        private void btnAddIndividualHarvest_Click(object sender, EventArgs e)
        {
            FormAddIndWork formAddIndWork = FormAddIndWork.getInstance(this);
            formAddIndWork.ShowFormAdd();
        }


        #endregion

        #region **************************************************** QUANTITY CODE ****************************************************************************

        int QuantityDataGridSelectedRowIndex = -1;


        List<Production> listQuantityProduction = new List<Production>();
        List<HarvestQuantity> listHarvestQuantity = new List<HarvestQuantity>();

        void DisplayQuantityData()
        {
            startQuantitySearchDateTimePicker.Value = DateTime.Now.AddDays(-29);
            endQuantitySearchDateTimePicker.Value = DateTime.Now.AddDays(1);
            UpdateDisplayHarvestQuantityData(startQuantitySearchDateTimePicker.Value, endQuantitySearchDateTimePicker.Value);
        }

        private void UpdateDisplayHarvestQuantityData(DateTime fromDate, DateTime toDate)
        {
            listQuantityProduction.Clear();
            try
            {
                listQuantityProduction = productionDAO.searchHarvestHoursProduction(startQuantitySearchDateTimePicker.Value, endQuantitySearchDateTimePicker.Value, 2);
                masterQuantityDataGridView.DataSource = listQuantityProduction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateDisplayHarvestQuantityData called: " + ex.Message);
            }
            SortDisplayMasterQuantityColumnsIndex();
        }

        private void masterQuantityDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = masterQuantityDataGridView.CurrentRow.Index;
            if (i < listQuantityProduction.Count && i >= 0)
            {
                DisplayDetailQuantityData(listQuantityProduction[i]);
            }
        }

        private void DisplayDetailQuantityData(Production production)
        {
            listHarvestQuantity.Clear();
            try
            {
                listHarvestQuantity = harvestQuantityDAO.HarvestQuantityByProduction(production);
            }catch(Exception ex)
            {
                MessageBox.Show("DisplayDetailQuantityData called: " +  ex.Message);
            }
            detailQuantityDataGridView.DataSource = listHarvestQuantity;
            SortDisplayDetailsQuantityColumnsIndex();
        }

        private void masterQuantityDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                masterQuantityDataGridView.Rows[e.RowIndex].Selected = true;
                QuantityContextMenuStrip.Show(this.masterQuantityDataGridView, e.Location);
                QuantityDataGridSelectedRowIndex = e.RowIndex;
                QuantityContextMenuStrip.Show(Cursor.Position);
                DisplayDetailQuantityData(listQuantityProduction[QuantityDataGridSelectedRowIndex]);
            }
        }

        private void QuantityContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditQuantityStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleEditQuantityTable();
            }
            else if (e.ClickedItem.Name == DeleteQuantityStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleDeleteQuantityTable();
            }
        }

        private void HandleEditQuantityTable()
        {
            FormAddQuantity formAddQuantity = FormAddQuantity.getInstance(this);
            Production production = (Production)listQuantityProduction[QuantityDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select Item");
                return;
            }
            formAddQuantity.InflateUI(production);
            formAddQuantity.ShowFormAdd();
        }


        private void HandleDeleteQuantityTable()
        {

            Production production = (Production)listQuantityProduction[QuantityDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select production");
                return;
            }

            List<HarvestQuantity> listQuantity = new List<HarvestQuantity>();
            try
            {
                listQuantity = harvestQuantityDAO.HarvestQuantityByProduction(production);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this data ", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                bool trackInsert = false;
                foreach (HarvestQuantity item in listQuantity)
                {
                    trackInsert = productionDAO.deleteQuantityProductionData(production, item);
                    if (!trackInsert) break;
                }
                var msg = (trackInsert) ? "deleted" : "not deleted";
                MessageBox.Show(msg);
                RefreshQuantityProductionTable();
            }

        }

        private void btnSearchQuantityProduction_Click(object sender, EventArgs e)
        {
            UpdateDisplayHarvestQuantityData(startQuantitySearchDateTimePicker.Value, endQuantitySearchDateTimePicker.Value);
        }

        public void RefreshQuantityProductionTable()
        {
            UpdateDisplayHarvestQuantityData(DateTime.Now.AddDays(-29), DateTime.Now.AddDays(1));
        }

        private void SortDisplayDetailsQuantityColumnsIndex()
        {
            detailQuantityDataGridView.Columns["HarvestQuantityIdColumn"].DisplayIndex = 0;
            detailQuantityDataGridView.Columns["HarvestQuantityDateColumn"].DisplayIndex = 1;
            detailQuantityDataGridView.Columns["HQEmployeeNameColumn"].DisplayIndex = 2;
            detailQuantityDataGridView.Columns["AllQuantityColumn"].DisplayIndex = 3;
            detailQuantityDataGridView.Columns["BadQuantityColumn"].DisplayIndex = 4;
            detailQuantityDataGridView.Columns["GoodQuantityColumn"].DisplayIndex = 5;
            detailQuantityDataGridView.Columns["ProductPriceColumn"].DisplayIndex = 6;
            detailQuantityDataGridView.Columns["HQCreditAmountColumn"].DisplayIndex = 7;
            detailQuantityDataGridView.Columns["HQTransportAmountColumn"].DisplayIndex = 8;
            detailQuantityDataGridView.Columns["HQPaymentColumn"].DisplayIndex = 9;
            detailQuantityDataGridView.Columns["HQRemarqueColumn"].DisplayIndex = 10;
            detailQuantityDataGridView.Columns["HarvestCategoryColumn"].DisplayIndex = 11;
        }

        private void SortDisplayMasterQuantityColumnsIndex()
        {
            masterQuantityDataGridView.Columns["HQProductionIdColumn"].DisplayIndex = 0;
            masterQuantityDataGridView.Columns["HQHQProductionDateColumn"].DisplayIndex = 1;
            masterQuantityDataGridView.Columns["HQProductionSupplierNameColumn"].DisplayIndex = 2;
            masterQuantityDataGridView.Columns["HQProductionFarmNameColumn"].DisplayIndex = 3;
            masterQuantityDataGridView.Columns["HQProductionProductNameColumn"].DisplayIndex = 4;
            masterQuantityDataGridView.Columns["HQProductionProductCodeColumn"].DisplayIndex = 5;
            masterQuantityDataGridView.Columns["HQProductionTotalQuantityColumn"].DisplayIndex = 6;
            masterQuantityDataGridView.Columns["HQProductionProductPriceColumn"].DisplayIndex = 7;
            masterQuantityDataGridView.Columns["HQProductionTotalEmployeeColumn"].DisplayIndex = 8;
            masterQuantityDataGridView.Columns["HQProductionPaymentCompanyColumn"].DisplayIndex = 9;
            masterQuantityDataGridView.Columns["HQProductionTypeColumn"].DisplayIndex = 10;
        }

        private void btnAddHarvestQuantity_Click(object sender, EventArgs e)
        {
            FormAddQuantity formAddQuantity = FormAddQuantity.getInstance(this);
            formAddQuantity.ShowFormAdd();
        }


        #endregion

        #region **************************************************** HOURS CODE ****************************************************************************


        List<Production> listHoursProduction = new List<Production>();

        private BindingSource masterHoursBindingSource = new BindingSource();
        private BindingSource detailsHoursBindingSource = new BindingSource();

        void DisplayHoursData()
        {
            masterHoursDataGridView.DataSource = masterHoursBindingSource;
            detailsHoursDataGridView.DataSource = detailsHoursBindingSource;
            StartSearchDateTimePicker.Value = DateTime.Now.AddDays(-29);
            EndtSearchDateTimePicker.Value = DateTime.Now.AddDays(1);
            UpdateDisplayHarvestHoursData(StartSearchDateTimePicker.Value, EndtSearchDateTimePicker.Value);
            masterHoursDataGridView.AutoResizeColumns();
            detailsHoursDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void UpdateDisplayHarvestHoursData(DateTime fromDate, DateTime toDate)
        {
            listHoursProduction.Clear();
            try
            {

                listHoursProduction = productionDAO.searchHarvestHoursProduction(fromDate, toDate, 1);
                List<HarvestHours> listHarvestHours = harvestHoursDAO.HarvestHoursData();

                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;

                IEnumerable<Production> HoursProduction = listHoursProduction;
                DataTable tableHoursProduction = new DataTable("Production");

                using (var reader = ObjectReader.Create(HoursProduction))
                {
                    tableHoursProduction.Load(reader);
                }

                data.Tables.Add(tableHoursProduction);


                IEnumerable<HarvestHours> enumHarvestHours = listHarvestHours;
                DataTable tableHarvestHours = new DataTable("HarvestHours");

                using (var reader = ObjectReader.Create(enumHarvestHours))
                {
                    tableHarvestHours.Load(reader);
                }

                data.Tables.Add(tableHarvestHours);

                DataRelation relation = null;
                try
                {
                    relation = new DataRelation("ProductionHarvestHours",
                                            data.Tables["Production"].Columns["ProductionId"],
                                            data.Tables["HarvestHours"].Columns["ProductionId"]);
                    data.Relations.Add(relation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                // Bind the master data connector to the Customers table.
                masterHoursBindingSource.DataSource = data;
                masterHoursBindingSource.DataMember = "Production";

                detailsHoursBindingSource.DataSource = masterHoursBindingSource;
                detailsHoursBindingSource.DataMember = "ProductionHarvestHours";

                SortDisplayMasterHoursColumnsIndex();
                SortDisplayDetailsHoursColumnsIndex();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            UpdateDisplayHarvestHoursData(StartSearchDateTimePicker.Value, EndtSearchDateTimePicker.Value);
        }

        public void RefreshHoursProductionTable()
        {
            UpdateDisplayHarvestHoursData(StartSearchDateTimePicker.Value, EndtSearchDateTimePicker.Value);
        }

        private void SortDisplayDetailsHoursColumnsIndex()
        {
            detailsHoursDataGridView.Columns["HarvestHoursIDColumn"].DisplayIndex = 0;
            detailsHoursDataGridView.Columns["HarvestDateColumn"].DisplayIndex = 1;
            detailsHoursDataGridView.Columns["HoursEmployeeNameColumn"].DisplayIndex = 2;
            detailsHoursDataGridView.Columns["TimeStartMorningColumn"].DisplayIndex = 3;
            detailsHoursDataGridView.Columns["TimeEndMorningColumn"].DisplayIndex = 4;
            detailsHoursDataGridView.Columns["TimeStartNoonColumn"].DisplayIndex = 5;
            detailsHoursDataGridView.Columns["TimeEndNoonColumn"].DisplayIndex = 6;
            detailsHoursDataGridView.Columns["HoursTotalMinutesColumn"].DisplayIndex = 7;
            detailsHoursDataGridView.Columns["HourPriceColumn"].DisplayIndex = 8;
            detailsHoursDataGridView.Columns["HoursCreditAmountColumn"].DisplayIndex = 9;
            detailsHoursDataGridView.Columns["HoursTransportAmountColumn"].DisplayIndex = 10;
            detailsHoursDataGridView.Columns["PaymentEmployeeColumn"].DisplayIndex = 11;
            detailsHoursDataGridView.Columns["EmployeeCategoryColumn"].DisplayIndex = 12;
            detailsHoursDataGridView.Columns["RemarqueColumn"].DisplayIndex = 13;
        }

        private void SortDisplayMasterHoursColumnsIndex()
        {
            masterHoursDataGridView.Columns["ProductionIDColumn"].DisplayIndex = 0;
            masterHoursDataGridView.Columns["ProductionDateColumn"].DisplayIndex = 1;
            masterHoursDataGridView.Columns["ProductionSupplierNameColumn"].DisplayIndex = 2;
            masterHoursDataGridView.Columns["ProductionFarmNameColumn"].DisplayIndex = 3;
            masterHoursDataGridView.Columns["ProductionProductNameColumn"].DisplayIndex = 4;
            masterHoursDataGridView.Columns["ProductionProductCodeColumn"].DisplayIndex = 5;
            masterHoursDataGridView.Columns["TotalQuantityColumn"].DisplayIndex = 6;
            masterHoursDataGridView.Columns["TotalMinutesColumn"].DisplayIndex = 7;
            masterHoursDataGridView.Columns["PriceColumn"].DisplayIndex = 8;
            masterHoursDataGridView.Columns["PaymentCompanyColumn"].DisplayIndex = 9;
            masterHoursDataGridView.Columns["TotalEmployeeColumn"].DisplayIndex = 10;
            masterHoursDataGridView.Columns["ProductionTypeColumn"].DisplayIndex = 11;
            masterHoursDataGridView.Columns["ProductionSupplierColumn"].DisplayIndex = 11;
            masterHoursDataGridView.Columns["ProductionFarmColumn"].DisplayIndex = 13;
            masterHoursDataGridView.Columns["ProductionProductColumn"].DisplayIndex = 14;
            masterHoursDataGridView.Columns["ProductionProductDetailColumn"].DisplayIndex = 15;
        }


        int HoursDataGridSelectedRowIndex = -1;
        private void masterHoursDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                masterHoursDataGridView.Rows[e.RowIndex].Selected = true;
                HoursContextMenuStrip.Show(this.masterHoursDataGridView, e.Location);
                HoursDataGridSelectedRowIndex = e.RowIndex;
                HoursContextMenuStrip.Show(Cursor.Position);
                
            }
        }



        private void HoursContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            if (e.ClickedItem.Name == EditHoursStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleEditHoursTable();
            }
            else if (e.ClickedItem.Name == DeleteHoursStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleDeleteHoursTable();
            }
        }

        private void HandleEditHoursTable()
        {
            FormAddHours formAddHours = FormAddHours.getInstance(this);
            Production production = (Production)listHoursProduction[HoursDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select Item");
                return;
            }
            formAddHours.InflateUI(production);
            formAddHours.ShowFormAdd();
        }

        private void HandleDeleteHoursTable()
        {

            Production production = (Production)listHoursProduction[HoursDataGridSelectedRowIndex];
            if(production == null)
            {
                MessageBox.Show("Select production");
                return;
            }

            List<HarvestHours> listHours = new List<HarvestHours>();
            try
            {
                listHours = harvestHoursDAO.HarvestHoursByProduction(production);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this data ", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                bool trackInsert = false;
                foreach (HarvestHours hours in listHours)
                {
                    trackInsert = productionDAO.deleteHoursProductionData(production, hours);
                    if (!trackInsert) break;
                }
                var msg = (trackInsert) ? "deleted" : "not deleted";
                MessageBox.Show(msg);
                RefreshHoursProductionTable();
            }

        }

        private void btnAddHarvestHours_Click(object sender, EventArgs e)
        {
            FormAddHours formAddHours = FormAddHours.getInstance(this);
            formAddHours.ShowFormAdd();
        }

        #endregion

        #region SUPPLIER CODE

        List<Supplier> listSupplier = new List<Supplier>();
        List<Supply> listSupply = new List<Supply>();

        public void DisplaySupplierData()
        {
            listSupplier = supplierDAO.getData();
            SupplierDataGridView.DataSource = listSupplier;
        }

        private void SupplierDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = SupplierDataGridView.CurrentCell.RowIndex;
            if (i < listSupplier.Count)
            {
                DisplaySupplyData(listSupplier[i]);
            }

        }

        private void DisplaySupplyData(Supplier supplier)
        {
            listSupply = supplyDAO.getData(supplier);
            SupplyDataGridView.DataSource = listSupply;
        }


        #endregion

        #region  ******************************************* FARM CODE *************************************************************************

        List<Farm> listFarm = new List<Farm>();

        List<Season> listSeason = new List<Season>();

        public void DisplayFarmData()
        {
            listFarm = farmDAO.getData();
            FarmDataGridView.DataSource = listFarm;
        }

        private void FarmtDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = FarmDataGridView.CurrentCell.RowIndex;
            if (i < listFarm.Count)
            {
                DisplaySeasonData(listFarm[i]);
            }

        }

        private void DisplaySeasonData(Farm farm)
        {
            listSeason.Clear();
            listSeason = seasonDAO.getData(farm);
            SeasonDataGridView.DataSource = listSeason;
        }

        private void FarmDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Farm farm = (Farm)listFarm[e.RowIndex];
            if (farm == null)
            {
                return;
            }
            if (farmDAO.UpdateData(farm))
            {
                DisplayFarmData();
            }
        }

        private void SeasonDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Season season = (Season)listSeason[e.RowIndex];
            if (season == null)
            {
                return;
            }
            if (seasonDAO.UpdateData(season))
            {
                DisplayFarmData();
            }
        }

        #endregion

        #region ******************************************* PRODUCT CODE ****************************************************************************

        List<Product> listProduct = new List<Product>();

        public void DisplayProductData()
        {
            listProduct.Clear();
            listProduct = productDAO.getData();
            ProductDataGridView.DataSource = listProduct;
        }

        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = ProductDataGridView.CurrentCell.RowIndex;
            if (i < listProduct.Count && i != -1)
            {
                DisplayProductDetailData(listProduct[i]);
            }
        }

        private void ProductDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Product product = (Product)listProduct[e.RowIndex];
            if (product == null)
            {
                return;
            }
            if (productDAO.UpdateData(product))
            {
                MessageBox.Show("les valeurs mises à jour.");
            }
        }

        #endregion

        #region ******************************************* PRODUCT DETAIL CODE *****************************************************************

        List<ProductDetail> listProductDetail = new List<ProductDetail>();

        private void DisplayProductDetailData(Product product)
        {
            listProductDetail.Clear();
            listProductDetail = productDetailDAO.getData(product);
            ProductDetailDataGridView.DataSource = listProductDetail;
        }

        private void ProductDetailDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ProductDetail item = (ProductDetail)listProductDetail[e.RowIndex];
            if (item == null)
            {
                return;
            }
            if (productDetailDAO.UpdateData(item))
            {
                MessageBox.Show("les valeurs mises à jour.");
            }
        }

        #endregion

        #region Credit CODE

        List<Credit> listCredit = new List<Credit>();
        private void btnAddCredit_Click(object sender, EventArgs e)
        {
            FormAddCredit formAddCredit = FormAddCredit.getInstance(this);
            formAddCredit.ShowFormAdd();
        }
        public void DisplayCreditData()
        {
            listCredit = creditDAO.getData();
            CreditDataGridView.DataSource = listCredit;
        }

        private void CreditContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditCreditStrip.Name)
            {
                CreditContextMenuStrip.Visible = false;
                HandleEditCreditTable();
            }
            else if (e.ClickedItem.Name == DeleteCreditStrip.Name)
            {
                CreditContextMenuStrip.Visible = false;
                HandleDeleteCreditTable();
            }
        }

        void HandleEditCreditTable()
        {
            FormAddCredit formAddCredit = FormAddCredit.getInstance(this);
            Credit credit = (Credit)CreditDataGridView.CurrentRow.DataBoundItem;


            if (credit == null)
            {
                MessageBox.Show("Select Credit");
                return;
            }

            formAddCredit.InflateUI(credit);
            formAddCredit.ShowFormAdd();
        }

        void HandleDeleteCreditTable()
        {
            Credit credit = (Credit)CreditDataGridView.CurrentRow.DataBoundItem;
            if (credit == null)
            {
                MessageBox.Show("Select product");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete " + credit.EmployeeName + " credit", "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = creditDAO.DeleteData(credit);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplayCreditData();

        }

        #endregion

        #region TRANSPORT CODE

        List<Transport> listTransport = new List<Transport>();

        private void btnAddTransport_Click(object sender, EventArgs e)
        {
            FormAddTransport formAddTransport = FormAddTransport.getInstance(this);
            formAddTransport.ShowFormAdd();
        }
        public void DisplayTransportData()
        {
            listTransport = transportDAO.getData();
            TransportDataGridView.DataSource = listTransport;
        }


        private void TransportContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditTransportStrip.Name)
            {
                TransportContextMenuStrip.Visible = false;
                HandleEditTransportTable();
            }
            else if (e.ClickedItem.Name == DeleteTransportStrip.Name)
            {
                TransportContextMenuStrip.Visible = false;
                HandleDeleteTransportTable();
            }
        }

        void HandleEditTransportTable()
        {

            FormAddTransport formAddTransport = FormAddTransport.getInstance(this);
            Transport transport = (Transport)TransportDataGridView.CurrentRow.DataBoundItem;


            if (transport == null)
            {
                MessageBox.Show("Select Credit");
                return;
            }

            formAddTransport.InflateUI(transport);
            formAddTransport.ShowFormAdd();
        }

        void HandleDeleteTransportTable()
        {
            Transport transport = (Transport)TransportDataGridView.CurrentRow.DataBoundItem;
            if (transport == null)
            {
                MessageBox.Show("Select product");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete " + transport.EmployeeName + " transport", "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = transportDAO.DeleteData(transport);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplayTransportData();

        }

        #endregion

        #region *********************************** EMPLOYEE CODE ***************************************************************

        List<Employee> listEmployee = new List<Employee>();

        public void DisplayEmployeeData()
        {
            listEmployee = employeeDAO.getData();
            EmployeeDataGridView.DataSource = listEmployee;
        }

        private void EmployeeDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Employee employee = (Employee)listEmployee[e.RowIndex];
            if (employee == null)
            {
                MessageBox.Show("Check values");
                return;
            }
            if (employeeDAO.UpdateData(employee))
            {
                EndCotract();
            }
        }

        private void EndCotract()
        {
            txtListEmployeeCloseFire.Text = "";
            foreach (Employee emp in listEmployee)
            {
                if (emp.FireDate.AddDays(-5) <= DateTime.Now.Date)
                {
                    txtListEmployeeCloseFire.Text += "* " + emp.FullName + Environment.NewLine;
                }
            }
        }

        #endregion

        #region ************************************************* Side Code ***********************************************

        private void AppLogo_Click(object sender, EventArgs e)
        {
            FormPreferences formPreferences = FormPreferences.getInstance();
            formPreferences.ShowForm();
        }

        private void RapportButton_Click(object sender, EventArgs e)
        {
            FormRapport rapport = FormRapport.getInstance();
            rapport.ShowForm();
        }

        private void HarvestMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            FormAddSupplier formAddSupplier = new FormAddSupplier(this);
            formAddSupplier.ShowDialog();

        }

        private void btnAddFarm_Click(object sender, EventArgs e)
        {
            FormAddFarm formAddFarm = new FormAddFarm(this);
            formAddFarm.ShowDialog();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = new FormAddEmployee(this);
            formAddEmployee.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FormAddProduct formAddProduct = new FormAddProduct(this);
            formAddProduct.ShowDialog();
        }



        #endregion


    }
}
