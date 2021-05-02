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
            //creditDAO.CreateTable();
            //transportDAO.CreateTable();
            //harvestHoursDAO.CreateTable();
            //harvestQuantityDAO.CreateTable();
            //productionDAO.CreateTable();
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

        #region ********************************************* QUANTITY CODE *************************************************************************

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

                if (listQuantityProduction.Count > 0 )
                {
                    masterQuantityDataGridView.DataSource = listQuantityProduction;
                }
                else
                {
                    masterQuantityDataGridView.DataSource = new List<Production>();
                    detailQuantityDataGridView.DataSource = new List<HarvestQuantity>();
                }
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
            FormAddQuantity formAddQuantity = new FormAddQuantity(this);
            Production production = (Production)listQuantityProduction[QuantityDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select Item");
                return;
            }
            formAddQuantity.InflateUI(production);
            formAddQuantity.ShowDialog();
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


        #endregion

        #region ********************************************* HOURS CODE ****************************************************************************

        int HoursDataGridSelectedRowIndex = -1;
        List<Production> listHoursProduction = new List<Production>();
        List<HarvestHours> listHarvestHours = new List<HarvestHours>();

        void DisplayHoursData()
        {
            StartHoursSearchDateTimePicker.Value = DateTime.Now.AddDays(-29);
            EndHoursSearchDateTimePicker.Value = DateTime.Now.AddDays(1);
            UpdateDisplayHarvestHoursData(StartHoursSearchDateTimePicker.Value, EndHoursSearchDateTimePicker.Value);
        }

        private void UpdateDisplayHarvestHoursData(DateTime fromDate, DateTime toDate)
        {
            listHoursProduction.Clear();
            try
            {
                listHoursProduction = productionDAO.searchHarvestHoursProduction(startQuantitySearchDateTimePicker.Value, endQuantitySearchDateTimePicker.Value, 1);

                if (listHoursProduction.Count > 0)
                {
                    masterHoursDataGridView.DataSource = listHoursProduction;
                }
                else
                {
                    masterHoursDataGridView.DataSource = new List<Production>();
                    detailsHoursDataGridView.DataSource = new List<HarvestHours>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Harvest Data called: " + ex.Message);
            }
            SortDisplayMasterHoursColumnsIndex();
        }

        private void masterHoursDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (masterHoursDataGridView.CurrentRow.Index < listHoursProduction.Count && masterHoursDataGridView.CurrentRow.Index >= 0)
                {
                    DisplayDetailHoursData(listHoursProduction[masterHoursDataGridView.CurrentRow.Index]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayDetailHoursData(Production production)
        {
            listHarvestHours.Clear();
            try
            {
                listHarvestHours = harvestHoursDAO.HarvestHoursByProduction(production);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Display Detail Data called: " + ex.Message);
            }
            detailsHoursDataGridView.DataSource = listHarvestHours;
            SortDisplayDetailsHoursColumnsIndex();
        }

        private void SearchHoursButton_Click(object sender, EventArgs e)
        {
            UpdateDisplayHarvestHoursData(StartHoursSearchDateTimePicker.Value, EndHoursSearchDateTimePicker.Value);
        }

        public void RefreshHoursProductionTable()
        {
            UpdateDisplayHarvestHoursData(StartHoursSearchDateTimePicker.Value, EndHoursSearchDateTimePicker.Value);
        }

        private void masterHoursDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                masterHoursDataGridView.Rows[e.RowIndex].Selected = true;
                HoursContextMenuStrip.Show(this.masterHoursDataGridView, e.Location);
                HoursDataGridSelectedRowIndex = e.RowIndex;
                HoursContextMenuStrip.Show(Cursor.Position);
                DisplayDetailHoursData(listHoursProduction[HoursDataGridSelectedRowIndex]);

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
            FormAddHours formAddHours = new FormAddHours(this);
            Production production = (Production)listHoursProduction[HoursDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select Item");
                return;
            }
            formAddHours.InflateUI(production);
            formAddHours.ShowDialog();
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

        #endregion

        #region ********************************************* SUPPLIER CODE *************************************************************************

        List<Supplier> listSupplier = new List<Supplier>();
        List<Supply> listSupply = new List<Supply>();

        public void DisplaySupplierData()
        {
            try
            {
                listSupplier = supplierDAO.getData();
                SupplierDataGridView.DataSource = listSupplier;
            }
            catch
            {

            }
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
            try
            {
                listSupply = supplyDAO.getData(supplier);
                SupplyDataGridView.DataSource = listSupply;
            }
            catch
            {

            }
        }

        private void SupplierDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Supplier supplier = (Supplier)listSupplier[e.RowIndex];
            if (supplier == null)
            {
                return;
            }
            if (supplierDAO.UpdateData(supplier))
            {
                DisplaySupplierData();
            }
        }

        private void SupplyDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Supply supply = (Supply)listSupply[e.RowIndex];
            if (supply == null)
            {
                return;
            }
            if (supplyDAO.UpdateData(supply))
            {
                DisplaySupplierData();
            }
        }

        #endregion

        #region  ********************************************* FARM CODE *****************************************************************************

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

        #region ********************************************* PRODUCT CODE **************************************************************************

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

        #region ********************************************* PRODUCT DETAIL CODE *******************************************************************

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

        #region ********************************************* Credit CODE ***************************************************************************

        List<Credit> listCredit = new List<Credit>();

        public void DisplayCreditData()
        {
            try
            {
                listCredit = creditDAO.getData();
                CreditDataGridView.DataSource = listCredit;
            }
            catch
            {

            }

        }

        private void CreditDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Credit item = (Credit)listCredit[e.RowIndex];
            if (item == null)
            {
                return;
            }
            if (creditDAO.UpdateData(item))
            {
                DisplaySupplierData();
            }
        }


        #endregion

        #region ********************************************* TRANSPORT CODE ************************************************************************

        List<Transport> listTransport = new List<Transport>();

        public void DisplayTransportData()
        {
            listTransport = transportDAO.getData();
            TransportDataGridView.DataSource = listTransport;
        }

        private void TransportDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Transport item = (Transport)listTransport[e.RowIndex];
            if (item == null)
            {
                return;
            }
            if (transportDAO.UpdateData(item))
            {
                DisplaySupplierData();
            }
        }


        #endregion

        #region ********************************************* EMPLOYEE CODE *************************************************************************

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

        #region ********************************************* Side Code *****************************************************************************

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

        private void btnAddHarvestQuantity_Click(object sender, EventArgs e)
        {
            FormAddQuantity formAddQuantity = new FormAddQuantity(this);
            formAddQuantity.ShowDialog();
        }

        private void btnAddHarvestHours_Click(object sender, EventArgs e)
        {
            FormAddHours formAddHours = new FormAddHours(this);
            formAddHours.ShowDialog();
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

        private void btnAddCredit_Click(object sender, EventArgs e)
        {
            FormAddCredit formAddCredit = new FormAddCredit(this);
            formAddCredit.ShowDialog();
        }

        private void btnAddTransport_Click(object sender, EventArgs e)
        {
            FormAddTransport formAddTransport = new FormAddTransport(this);
            formAddTransport.ShowDialog();
        }


        #endregion


    }
}
