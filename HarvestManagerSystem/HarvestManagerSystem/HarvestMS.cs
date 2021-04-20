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
            DisplayQuantityData();
        }

        private void tabProduction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabProduction.SelectedIndex)
            {
                case 0:
                    DisplayQuantityData();
                    break;
                case 1:
                    DisplayHoursData();
                    break;
                case 2:
                    DisplayCreditData();
                    DisplayTransportData();
                    break;
                case 3:
                    DisplayEmployeeData();
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

        #region HOURS CODE


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
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            FormAddSupplier formAddSupplier = FormAddSupplier.getInstance(this);
            formAddSupplier.ShowFormAdd();

        }
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
            SupplyDataGridView.DataSource = supplyDAO.getData(supplier);
        }

        private void SupplierContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditSupplierStrip.Name)
            {
                SupplierContextMenuStrip.Visible = false;
                HandleEditSupplierTable();
            }
            else if (e.ClickedItem.Name == DeleteSupplierStrip.Name)
            {
                SupplierContextMenuStrip.Visible = false;
                HandleDeleteSupplierTable();
            }
        }


        void HandleEditSupplierTable()
        {
            FormAddSupplier formAddSupplier = FormAddSupplier.getInstance(this);
            Supplier supplier = (Supplier)SupplierDataGridView.CurrentRow.DataBoundItem;
            if (supplier == null)
            {
                MessageBox.Show("Select fournisseur");
                return;
            }
            formAddSupplier.InflateUI(supplier);
            formAddSupplier.ShowFormAdd();
        }

        void HandleDeleteSupplierTable()
        {
            Supplier supplier = (Supplier)SupplierDataGridView.CurrentRow.DataBoundItem;
            if (supplier == null)
            {
                MessageBox.Show("Select fournisseur");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete: " + supplier.SupplierName, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = supplierDAO.DeleteData(supplier);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplaySupplierData();

        }

        private void SupplyContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditSupplyStrip.Name)
            {
                SupplyContextMenuStrip.Visible = false;
                HandleEditSupplyTable();
            }
            else if (e.ClickedItem.Name == DeleteSupplyStrip.Name)
            {
                SupplyContextMenuStrip.Visible = false;
                HandleDeleteSupplyTable();
            }
        }

        void HandleEditSupplyTable()
        {
            FormAddSupplier formAddSupplier = FormAddSupplier.getInstance(this);
            Supplier supplier = (Supplier)SupplierDataGridView.CurrentRow.DataBoundItem;
            Supply supply = (Supply)SupplyDataGridView.CurrentRow.DataBoundItem;
            if (supply == null)
            {
                MessageBox.Show("Select champ");
                return;
            }

            formAddSupplier.InflateUI(supply, supplier);
            formAddSupplier.ShowFormAdd();
        }

        void HandleDeleteSupplyTable()
        {
            Supply supply = (Supply)SupplyDataGridView.CurrentRow.DataBoundItem;
            if (supply == null)
            {
                MessageBox.Show("Select champ");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete champ: " + supply.Farm.FarmName, "Delete", MessageBoxButtons.YesNoCancel,
MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = supplyDAO.DeleteData(supply);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplaySupplierData();

        }

        #endregion

        #region FARM CODE

        List<Farm> listFarm = new List<Farm>();
        private void btnAddFarm_Click(object sender, EventArgs e)
        {
            FormAddFarm formAddFarm = FormAddFarm.getInstance(this);
            formAddFarm.ShowFormAdd();
        }

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

        private void FarmContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditFarmStrip.Name)
            {
                FarmContextMenuStrip.Visible = false;
                HandleEditFarmTable();
            }
            else if (e.ClickedItem.Name == DeleteFarmStrip.Name)
            {
                FarmContextMenuStrip.Visible = false;
                HandleDeleteFarmTable();
            }
        }

        void HandleEditFarmTable()
        {

            FormAddFarm formAddFarm = FormAddFarm.getInstance(this);
            Farm farm = (Farm)FarmDataGridView.CurrentRow.DataBoundItem;
            if (farm == null)
            {
                MessageBox.Show("Select farm");
                return;
            }

            formAddFarm.InflateUI(farm);
            formAddFarm.ShowFormAdd();
        }

        void HandleDeleteFarmTable()
        {
            Farm farm = (Farm)FarmDataGridView.CurrentRow.DataBoundItem;
            if (farm == null)
            {
                MessageBox.Show("Select farm");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete: " + farm.FarmName, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = farmDAO.DeleteData(farm);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplayFarmData();

        }

        #endregion

        #region Season DATA

        private void DisplaySeasonData(Farm farm)
        {
            SeasonDataGridView.DataSource = seasonDAO.getData(farm);
        }

        private void SeasonContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditSeasonStrip.Name)
            {
                SeasonContextMenuStrip.Visible = false;
                HandleEditSeasonTable();
            }
            else if (e.ClickedItem.Name == DeleteSeasonStrip.Name)
            {
                SeasonContextMenuStrip.Visible = false;
                HandleDeleteSeasonTable();
            }
        }

        void HandleEditSeasonTable()
        {
            FormAddFarm formAddFarm = FormAddFarm.getInstance(this);
            Farm farm = (Farm)FarmDataGridView.CurrentRow.DataBoundItem;
            Season season = (Season)SeasonDataGridView.CurrentRow.DataBoundItem;
            if (season == null)
            {
                MessageBox.Show("Select season");
                return;
            }

            formAddFarm.InflateUI(season, farm);
            formAddFarm.ShowFormAdd();
        }

        void HandleDeleteSeasonTable()
        {
            Season season = (Season)SeasonDataGridView.CurrentRow.DataBoundItem;
            if (season == null)
            {
                MessageBox.Show("Select product");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete season from: " + season.SeasonPlantingDate + " to " + season.SeasonHarvestDate, "Delete", MessageBoxButtons.YesNoCancel,
MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = seasonDAO.DeleteData(season); //productDetailDAO.DeleteData(productDetail);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplayFarmData();

        }

        #endregion

        #region PRODUCT CODE

        List<Product> listProduct = new List<Product>();
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FormAddProduct formAddProduct = FormAddProduct.getInstance(this);
            formAddProduct.ShowFormAdd();
        }

        public void DisplayProductData()
        {
            listProduct = productDAO.getData();
            ProductDataGridView.DataSource = listProduct;
        }

        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = ProductDataGridView.CurrentCell.RowIndex;
            if (i < listProduct.Count)
            {
                DisplayProductDetailData(listProduct[i]);
            }

        }

        private void ProductContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditProductStrip.Name)
            {
                ProductContextMenuStrip.Visible = false;
                HandleEditProductTable();
            }
            else if (e.ClickedItem.Name == DeleteProductStrip.Name)
            {
                ProductContextMenuStrip.Visible = false;
                HandleDeleteProductTable();
            }
        }

        void HandleEditProductTable()
        {

            FormAddProduct formAddProduct = FormAddProduct.getInstance(this);
            Product product = (Product)ProductDataGridView.CurrentRow.DataBoundItem;
            if (product == null)
            {
                MessageBox.Show("Select Product");
                return;
            }

            formAddProduct.InflateUI(product);
            formAddProduct.ShowFormAdd();
        }

        void HandleDeleteProductTable()
        {
            Product product = (Product)ProductDataGridView.CurrentRow.DataBoundItem;
            if (product == null)
            {
                MessageBox.Show("Select product");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete: " + product.ProductName, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = productDAO.DeleteData(product);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplayProductData();

        }

        #endregion

        #region PRODUCT DETAIL CODE

        private void DisplayProductDetailData(Product product)
        {
            ProductDetailDataGridView.DataSource = productDetailDAO.getData(product);
        }

        private void ProductDetailContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditProductDetailStrip.Name)
            {
                ProductDetailContextMenuStrip.Visible = false;
                HandleEditProductDetailTable();
            }
            else if (e.ClickedItem.Name == DeleteProductDetailStrip.Name)
            {
                ProductDetailContextMenuStrip.Visible = false;
                HandleDeleteProductDetailTable();
            }
        }

        void HandleEditProductDetailTable()
        {

            FormAddProduct formEditProductDetail = FormAddProduct.getInstance(this);
            Product product = (Product)ProductDataGridView.CurrentRow.DataBoundItem;
            ProductDetail productDetail = (ProductDetail)ProductDetailDataGridView.CurrentRow.DataBoundItem;
            if (productDetail == null)
            {
                MessageBox.Show("Select Product Detail");
                return;
            }

            formEditProductDetail.InflateUI(productDetail, product);
            formEditProductDetail.ShowFormAdd();
        }

        void HandleDeleteProductDetailTable()
        {
            ProductDetail productDetail = (ProductDetail)ProductDetailDataGridView.CurrentRow.DataBoundItem;
            if (productDetail == null)
            {
                MessageBox.Show("Select product");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete product with code: " + productDetail.ProductCode, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = productDetailDAO.DeleteData(productDetail);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            DisplayProductData();

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
                ProductContextMenuStrip.Visible = false;
                HandleEditCreditTable();
            }
            else if (e.ClickedItem.Name == DeleteCreditStrip.Name)
            {
                ProductContextMenuStrip.Visible = false;
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
                ProductContextMenuStrip.Visible = false;
                HandleEditTransportTable();
            }
            else if (e.ClickedItem.Name == DeleteTransportStrip.Name)
            {
                ProductContextMenuStrip.Visible = false;
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

        #region EMPLOYEE CODE

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = FormAddEmployee.getInstance(this);
            formAddEmployee.ShowFormAdd();
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DisplayEmployeeData();
        }
        public void DisplayEmployeeData()
        {
            EmployeeDataGridView.DataSource = employeeDAO.getData();
        }

        private void EmployeeContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditEmployeeStrip.Name)
            {
                EmployeeContextMenuStrip.Visible = false;
                HandleEditEmployeeTable();
            }
            else if (e.ClickedItem.Name == DeleteEmployeeStrip.Name)
            {
                EmployeeContextMenuStrip.Visible = false;
                HandleDeleteEmployeeTable();
            }
        }

        void HandleEditEmployeeTable()
        {
            FormAddEmployee formAddEmployee = FormAddEmployee.getInstance(this);
            Employee employee = (Employee)EmployeeDataGridView.CurrentRow.DataBoundItem;
            if (employee == null)
            {
                MessageBox.Show("Select Employee");
                return;
            }
            formAddEmployee.InflateUI(employee);
            formAddEmployee.ShowFormAdd();
        }

        void HandleDeleteEmployeeTable()
        {
            Employee selectedEmployee = (Employee)EmployeeDataGridView.CurrentRow.DataBoundItem;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Select Employee");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete: " + selectedEmployee.FullName, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = employeeDAO.DeleteData(selectedEmployee);
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
                DisplayEmployeeData();
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }

        }

        private void EmployeeDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == EmployeeDataGridView.Columns["employeeStatusColumn"].Index)
            {
                Employee selectedEmployee = (Employee)EmployeeDataGridView.CurrentRow.DataBoundItem;
                employeeDAO.updateEmployeeStatusById(selectedEmployee);
            }

        }

        private void employeeDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (EmployeeDataGridView.DataSource != null)
            {
                if (e.ColumnIndex == EmployeeDataGridView.Columns["employeeStatusColumn"].Index && e.RowIndex != -1)
                {
                    EmployeeDataGridView.EndEdit();
                }
            }
        }






















        #endregion

        private void AppLogo_Click(object sender, EventArgs e)
        {
            FormPreferences formPreferences = FormPreferences.getInstance();
            formPreferences.ShowForm();
        }

    }
}
