using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;
using HarvestManagerSystem.common;

namespace HarvestManagerSystem.view
{
    public partial class FormRapport : Form
    {

        private RapportDAO rapportDAO = RapportDAO.getInstance();
        private ProductionDAO productionDAO = ProductionDAO.getInstance();
        private SupplierDAO supplierDAO = SupplierDAO.getInstance();
        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Employee> mEmployeeDictionary = new Dictionary<string, Employee>();

        public FormRapport()
        {
            InitializeComponent();
        }

        private void FormRapport_Load(object sender, EventArgs e)
        {
            DisplayRapportEmployeeHours();
        }

        private void FormRapport_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        #region ******************************************** Tab Control Selected Index ***********************************************************

        private void RapportTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RapportTabControl.SelectedIndex)
            {
                case 0:
                    DisplayRapportEmployeeHours();
                    break;
                case 1:
                    DisplayRapportEmployeeQuantity();
                    break;
                case 2:
                    DisplayCompanyHoursProduction();
                    break;
                case 3:
                    DisplayCompanyQuantityProduction();
                    break;
                default:
                    Console.WriteLine("nothing");
                    break;
            }
        }

        #endregion

        #region ************************************ Employee Hours Rapport ****************************************************

        List<HoursEmployeeRapport> listEmployeeHoursProduction = new List<HoursEmployeeRapport>();

        void DisplayRapportEmployeeHours()
        {
            dtpStartEmployeeHoursRapport.Value = DateTime.Now.AddDays(-29);
            dtpEndEmployeeHoursRapport.Value = DateTime.Now.AddDays(1);
            mEmployeeDictionary = Common.EmployeeNameList(cmbEmployeeHoursRapport);
            int id = mEmployeeDictionary.GetValueOrDefault(cmbEmployeeHoursRapport.GetItemText(cmbEmployeeHoursRapport.SelectedItem)).EmployeeId;
            UpdateEmployeeHoursRapport(dtpStartEmployeeHoursRapport.Value, dtpEndEmployeeHoursRapport.Value, id);
        }

        private void UpdateEmployeeHoursRapport(DateTime fromDate, DateTime toDate, int employeeId)
        {
            listEmployeeHoursProduction.Clear();
            try
            {
                listEmployeeHoursProduction = rapportDAO.SearchHoursEmployeeRapport(fromDate, toDate, employeeId);  
                dgvEmployeHourRapport.DataSource = listEmployeeHoursProduction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateDisplayHarvestQuantityData called: " + ex.Message);
            }
            SortDisplayRapportEmployeeHoursColumnsIndex();
            txtTotalEmployeePayment.Text = calculTotalEmployeePayment().ToString();
            txtTotalEmployeeHours.Text = calculTotalEmployeeHours().ToString();
        }

        private double calculTotalEmployeePayment()
        {
            double total = 0.0;
            foreach (HoursEmployeeRapport h in listEmployeeHoursProduction)
            {
                total += h.Payment;
            }
            return total;
        }

        private double calculTotalEmployeeHours()
        {
            double total = 0.0;
            foreach (HoursEmployeeRapport h in listEmployeeHoursProduction)
            {
                total += h.TotalMinutes;
            }
            return total;
        }

        private void btnEmployeeHoursRapportSearch_Click(object sender, EventArgs e)
        {
            int id = mEmployeeDictionary.GetValueOrDefault(cmbEmployeeHoursRapport.GetItemText(cmbEmployeeHoursRapport.SelectedItem)).EmployeeId;
            UpdateEmployeeHoursRapport(dtpStartEmployeeHoursRapport.Value, dtpEndEmployeeHoursRapport.Value, id);
        }

        private void SortDisplayRapportEmployeeHoursColumnsIndex()
        {
            dgvEmployeHourRapport.Columns["EREmployeeNameColumn"].DisplayIndex = 0;
            dgvEmployeHourRapport.Columns["ERHarvestDateColumn"].DisplayIndex = 1;
            dgvEmployeHourRapport.Columns["ERTotalMinutesColumn"].DisplayIndex = 2;
            dgvEmployeHourRapport.Columns["ERHourPriceColumn"].DisplayIndex = 3;
            dgvEmployeHourRapport.Columns["ERCreditAmountColumn"].DisplayIndex = 4;
            dgvEmployeHourRapport.Columns["ERTransportAmountColumn"].DisplayIndex = 5;
            dgvEmployeHourRapport.Columns["ERPaymentColumn"].DisplayIndex = 6;
            dgvEmployeHourRapport.Columns["EREmployeeCategoryColumn"].DisplayIndex = 7;
        }

        #endregion

        #region  ****************************************** Rapport Employee Quantity ***********************************************************

        List<QuantityEmployeeRapport> listEmployeeQuantityProduction = new List<QuantityEmployeeRapport>();

        void DisplayRapportEmployeeQuantity()
        {

            dtpStartEmployeeQuantityRapport.Value = DateTime.Now.AddDays(-29);
            dtpEndEmployeeQuantityRapport.Value = DateTime.Now.AddDays(1);
            mEmployeeDictionary = Common.EmployeeNameList(cmbEmployeeQuantityRapport);
            int id = mEmployeeDictionary.GetValueOrDefault(cmbEmployeeQuantityRapport.GetItemText(cmbEmployeeQuantityRapport.SelectedItem)).EmployeeId;
            UpdateEmployeeQuantityRapport(dtpStartEmployeeQuantityRapport.Value, dtpEndEmployeeQuantityRapport.Value, id);

        }

        private void UpdateEmployeeQuantityRapport(DateTime fromDate, DateTime toDate, int employeeId)
        {
            listEmployeeQuantityProduction.Clear();
            try
            {
                listEmployeeQuantityProduction = rapportDAO.SearchQuantityEmployeeRapport(fromDate, toDate, employeeId);
                dgvEmployeQuantityRapport.DataSource = listEmployeeQuantityProduction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateDisplayHarvestQuantityData called: " + ex.Message);
            }
            SortDisplayRapportEmployeeQuantityColumnsIndex();
            txtEmployeeQuantityPayment.Text = calculTotalQuantityEmployeePayment().ToString();
            txtTotalEmployeeQuantity.Text = calculTotalEmployeeQuantity().ToString();
        }

        private double calculTotalQuantityEmployeePayment()
        {
            double total = 0.0;
            foreach (QuantityEmployeeRapport h in listEmployeeQuantityProduction)
            {
                total += h.Payment;
            }
            return total;
        }

        private double calculTotalEmployeeQuantity()
        {
            double total = 0.0;
            foreach (QuantityEmployeeRapport h in listEmployeeQuantityProduction)
            {
                total += h.GoodQuantity;
            }
            return total;
        }

        private void btnSearchEmployeeQuantityRapport_Click(object sender, EventArgs e)
        {
            int id = mEmployeeDictionary.GetValueOrDefault(cmbEmployeeQuantityRapport.GetItemText(cmbEmployeeQuantityRapport.SelectedItem)).EmployeeId;
            UpdateEmployeeQuantityRapport(dtpStartEmployeeQuantityRapport.Value, dtpEndEmployeeQuantityRapport.Value, id);
        }

        private void SortDisplayRapportEmployeeQuantityColumnsIndex()
        {
            dgvEmployeQuantityRapport.Columns["QREmployeeNameColumnColumn"].DisplayIndex = 0;
            dgvEmployeQuantityRapport.Columns["QRHarvestDateColumn"].DisplayIndex = 1;
            dgvEmployeQuantityRapport.Columns["QRAllQuantityColumn"].DisplayIndex = 2;
            dgvEmployeQuantityRapport.Columns["QRBadQuantityColumn"].DisplayIndex = 3;
            dgvEmployeQuantityRapport.Columns["QRGoodQuantityColumn"].DisplayIndex = 4;
            dgvEmployeQuantityRapport.Columns["QRPenaltyGeneralColumn"].DisplayIndex = 5;
            dgvEmployeQuantityRapport.Columns["QRDamageGeneralColumn"].DisplayIndex = 6;
            dgvEmployeQuantityRapport.Columns["QRTransportAmountColumn"].DisplayIndex = 7;
            dgvEmployeQuantityRapport.Columns["QRCreditAmountColumn"].DisplayIndex = 8;
            dgvEmployeQuantityRapport.Columns["QRProductPriceColumn"].DisplayIndex = 9;
            dgvEmployeQuantityRapport.Columns["QRPaymentColumn"].DisplayIndex = 10;
            dgvEmployeQuantityRapport.Columns["QrHarvestCatColumn"].DisplayIndex = 11;
        }

        #endregion

        #region ************************************  Display Company Quantity Production Rapport Code ***************************************

        List<Production> listCompanyQuantityProduction = new List<Production>();
        private Dictionary<string, Supplier> mSupplierQuantityDictionary = new Dictionary<string, Supplier>();

        private void DisplayCompanyQuantityProduction()
        {
            dtpStartCompanyQuantityProduction.Value = DateTime.Now.AddDays(-29);
            dtpEndCompanyQuantityProduction.Value = DateTime.Now.AddDays(1);
            SupplierNameQuantity();
            int id = mSupplierQuantityDictionary.GetValueOrDefault(comboBoxCompanyQuantityProduction.GetItemText(comboBoxCompanyQuantityProduction.SelectedItem)).SupplierId;
            UpdateDisplayHarvestQuantityData(dtpStartCompanyQuantityProduction.Value, dtpEndCompanyQuantityProduction.Value, id);
            ProductionTotalQuantityCharge();
            ProductionRapportTotalQuantity();
        }

        private void ProductionRapportTotalQuantity()
        {
            txtCompanyRapportProductionTotalQuantity.Text = calculTotalQuantity().ToString();
        }

        private void ProductionTotalQuantityCharge()
        {
            txtCompanyRapportProductionTotalQuantityCharge.Text = calculTotalQuantityPayment().ToString();
        }

        private void UpdateDisplayHarvestQuantityData(DateTime fromDate, DateTime toDate, int id)
        {
            listCompanyQuantityProduction.Clear();
            try
            {
                listCompanyQuantityProduction = rapportDAO.searchHarvestQuantityProduction(fromDate, toDate, 1, id);

                if (listCompanyQuantityProduction.Count > 0)
                {
                    CompanyQuantityProductionDataGridView.DataSource = listCompanyQuantityProduction;
                }
                else
                {
                    CompanyQuantityProductionDataGridView.DataSource = new List<Production>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateDisplayHarvestQuantityData called: " + ex.Message);
            }
            SortDisplayMasterQuantityColumnsIndex();
        }

        private void btnCompanyQuantityProduction_Click(object sender, EventArgs e)
        {
            int id = mSupplierQuantityDictionary.GetValueOrDefault(comboBoxCompanyQuantityProduction.GetItemText(comboBoxCompanyQuantityProduction.SelectedItem)).SupplierId;
            UpdateDisplayHarvestQuantityData(dtpStartCompanyQuantityProduction.Value, dtpEndCompanyQuantityProduction.Value, id);
            ProductionTotalQuantityCharge();
            ProductionRapportTotalQuantity();
        }

        public void SupplierNameQuantity()
        {
            List<string> NamesList = new List<string>();
            mSupplierQuantityDictionary.Clear();
            try
            {
                mSupplierQuantityDictionary = supplierDAO.SupplierDictionary();
                NamesList.AddRange(mSupplierQuantityDictionary.Keys);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            if (NamesList != null)
            {
                comboBoxCompanyQuantityProduction.DataSource = NamesList;
            }
        }

        private double calculTotalQuantityPayment()
        {
            double total = 0.0;
            foreach (Production p in listCompanyQuantityProduction)
            {
                total += p.QuantityPayment;
            }
            return total;
        }

        private double calculTotalQuantity()
        {
            double total = 0.0;
            foreach (Production p in listCompanyQuantityProduction)
            {
                total += p.TotalQuantity;
            }
            return total;
        }

        private void SortDisplayMasterQuantityColumnsIndex()
        {
            CompanyQuantityProductionDataGridView.Columns["HQProductionIdColumn"].DisplayIndex = 0;
            CompanyQuantityProductionDataGridView.Columns["HQHQProductionDateColumn"].DisplayIndex = 1;
            CompanyQuantityProductionDataGridView.Columns["HQProductionSupplierNameColumn"].DisplayIndex = 2;
            CompanyQuantityProductionDataGridView.Columns["HQProductionFarmNameColumn"].DisplayIndex = 3;
            CompanyQuantityProductionDataGridView.Columns["HQProductionProductNameColumn"].DisplayIndex = 4;
            CompanyQuantityProductionDataGridView.Columns["HQProductionProductCodeColumn"].DisplayIndex = 5;
            CompanyQuantityProductionDataGridView.Columns["HQProductionTotalQuantityColumn"].DisplayIndex = 6;
            CompanyQuantityProductionDataGridView.Columns["HQProductionProductPriceColumn"].DisplayIndex = 7;
            CompanyQuantityProductionDataGridView.Columns["HQProductionTotalEmployeeColumn"].DisplayIndex = 8;
            CompanyQuantityProductionDataGridView.Columns["HQProductionPaymentCompanyColumn"].DisplayIndex = 9;
            CompanyQuantityProductionDataGridView.Columns["HQProductionTypeColumn"].DisplayIndex = 10;
        }

        #endregion

        #region ************************************  Display Company Hours Production Rapport Code ***************************************

        List<Production> listCompanyHoursProduction = new List<Production>();
        private Dictionary<string, Supplier> mSupplierHoursDictionary = new Dictionary<string, Supplier>();

        private void DisplayCompanyHoursProduction()
        {
            initDateTimePicker();
            SupplierNameHours();
            int supplierId = mSupplierHoursDictionary.GetValueOrDefault(comboBoxCompanyHoursProduction.GetItemText(comboBoxCompanyHoursProduction.SelectedItem)).SupplierId;
            UpdateDisplayHarvestHoursData(dtpStartCompanyHoursProduction.Value, dtpEndCompanyHoursProduction.Value, supplierId);
            ProductionTotalHoursCharge();
            ProductionRapportTotalMinutes();
        }

        private void ProductionRapportTotalMinutes()
        {
            txtCompanyRapportProductionTotalMinutes.Text = calculTotalMinutes().ToString();
        }

        private void ProductionTotalHoursCharge()
        {
            txtCompanyRapportProductionTotalHoursCharge.Text = calculTotalHoursPayment().ToString();
        }

        private void initDateTimePicker()
        {
            dtpStartCompanyHoursProduction.Value = DateTime.Now.AddDays(-29);
            dtpEndCompanyHoursProduction.Value = DateTime.Now.AddDays(1);
        }

        private void SupplierNameHours()
        {
            List<string> NamesList = new List<string>();
            mSupplierHoursDictionary.Clear();
            try
            {
                mSupplierHoursDictionary = supplierDAO.SupplierDictionary();
                NamesList.AddRange(mSupplierHoursDictionary.Keys);
                comboBoxCompanyHoursProduction.DataSource = NamesList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateDisplayHarvestHoursData(DateTime fromDate, DateTime toDate, int id)
        {
            listCompanyHoursProduction.Clear();
            try
            {
                listCompanyHoursProduction = rapportDAO.searchHarvestHoursProduction(fromDate, toDate, 1, id);
                if (listCompanyHoursProduction.Count > 0)
                {
                    CompanyHoursProductionDataGridView.DataSource = listCompanyHoursProduction;
                }
                else
                {
                    CompanyHoursProductionDataGridView.DataSource = new List<Production>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Harvest Data called: " + ex.Message);
            }

            SortDisplayProductionHoursColumnsIndex();
        }

        private void btnCompanyHoursProduction_Click(object sender, EventArgs e)
        {
            int id = mSupplierHoursDictionary.GetValueOrDefault(comboBoxCompanyHoursProduction.GetItemText(comboBoxCompanyHoursProduction.SelectedItem)).SupplierId;
            UpdateDisplayHarvestHoursData(dtpStartCompanyHoursProduction.Value, dtpEndCompanyHoursProduction.Value, id);
            ProductionTotalHoursCharge();
            ProductionRapportTotalMinutes();
        }

        private void SortDisplayProductionHoursColumnsIndex()
        {
            CompanyHoursProductionDataGridView.Columns["ProductionIDColumn"].DisplayIndex = 0;
            CompanyHoursProductionDataGridView.Columns["ProductionDateColumn"].DisplayIndex = 1;
            CompanyHoursProductionDataGridView.Columns["ProductionSupplierNameColumn"].DisplayIndex = 2;
            CompanyHoursProductionDataGridView.Columns["ProductionFarmNameColumn"].DisplayIndex = 3;
            CompanyHoursProductionDataGridView.Columns["ProductionProductNameColumn"].DisplayIndex = 4;
            CompanyHoursProductionDataGridView.Columns["ProductionProductCodeColumn"].DisplayIndex = 5;
            CompanyHoursProductionDataGridView.Columns["TotalQuantityColumn"].DisplayIndex = 6;
            CompanyHoursProductionDataGridView.Columns["TotalMinutesColumn"].DisplayIndex = 7;
            CompanyHoursProductionDataGridView.Columns["PriceCompanyHoursColumn"].DisplayIndex = 8;
            CompanyHoursProductionDataGridView.Columns["PaymentCompanyColumn"].DisplayIndex = 9;
            CompanyHoursProductionDataGridView.Columns["TotalEmployeeColumn"].DisplayIndex = 10;
            CompanyHoursProductionDataGridView.Columns["ProductionTypeColumn"].DisplayIndex = 11;
            CompanyHoursProductionDataGridView.Columns["ProductionSupplierColumn"].DisplayIndex = 11;
            CompanyHoursProductionDataGridView.Columns["ProductionFarmColumn"].DisplayIndex = 13;
            CompanyHoursProductionDataGridView.Columns["ProductionProductColumn"].DisplayIndex = 14;
            CompanyHoursProductionDataGridView.Columns["ProductionProductDetailColumn"].DisplayIndex = 15;
        }

        private double calculTotalMinutes()
        {
            double total = 0.0;
            foreach (Production p in listCompanyHoursProduction)
            {
                total += p.TotalMinutes;
            }
            return total;
        }

        private double calculTotalHoursPayment()
        {
            double total = 0.0;
            foreach (Production p in listCompanyHoursProduction)
            {
                total += p.HoursPayment;
            }
            return total;
        }

        #endregion




    }
}
