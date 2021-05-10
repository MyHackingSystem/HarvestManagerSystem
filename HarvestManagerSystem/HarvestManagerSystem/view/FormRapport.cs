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
        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Employee> mEmployeeDictionary = new Dictionary<string, Employee>();

        private static FormRapport instance;

        private FormRapport()
        {
            InitializeComponent();
        }

        public static FormRapport getInstance()
        {
            if (instance == null)
            {
                instance = new FormRapport();
            }
            return instance;
        }

        public void ShowForm()
        {
            if (instance != null)
            {
                instance.BringToFront();
            }
            else
            {
                instance = new FormRapport();

            }
            instance.Show();
        }

        private void FormRapport_Load(object sender, EventArgs e)
        {
            DisplayRapportCompanyData();
        }

        private void FormRapport_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        #region Company rapport

        List<CompanyRapport> listQuantityProduction = new List<CompanyRapport>();
        void DisplayRapportCompanyData()
        {
            dtpStartCompanyRapportSearch.Value = DateTime.Now.AddDays(-29);
            dtpEndCompanyRapportSearch.Value = DateTime.Now.AddDays(1);
            mSupplierDictionary = Common.SupplierNameList(cmbCompanyRapportSearch);
            int id = mSupplierDictionary.GetValueOrDefault(cmbCompanyRapportSearch.GetItemText(cmbCompanyRapportSearch.SelectedItem)).SupplierId;
            UpdateRapportCompanyData(dtpStartCompanyRapportSearch.Value, dtpEndCompanyRapportSearch.Value, id);
        }

        private void UpdateRapportCompanyData(DateTime fromDate, DateTime toDate, int SupplierId)
        {
            listQuantityProduction.Clear();
            try
            {
                listQuantityProduction = rapportDAO.searchCompanyProduction(dtpStartCompanyRapportSearch.Value, dtpEndCompanyRapportSearch.Value, 2, SupplierId);
                CompanyRapportDataGridView.DataSource = listQuantityProduction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateDisplayHarvestQuantityData called: " + ex.Message);
            }
            SortDisplayMasterQuantityColumnsIndex();
            txtTotalPayment.Text = calculTotalPayment().ToString();
            txtTotalQuantity.Text = calculTotalQuantity().ToString();
        }

        private double calculTotalPayment()
        {
            double total = 0.0;
            foreach (CompanyRapport cr in listQuantityProduction)
            {
                total += cr.Payment;
            }
            return total;
        }

        private double calculTotalQuantity()
        {
            double total = 0.0;
            foreach (CompanyRapport cr in listQuantityProduction)
            {
                total += cr.AllQuantity;
            }
            return total;
        }

        private void btnCompanyRapportSearch_Click(object sender, EventArgs e)
        {
            int id = mSupplierDictionary.GetValueOrDefault(cmbCompanyRapportSearch.GetItemText(cmbCompanyRapportSearch.SelectedItem)).SupplierId;
            UpdateRapportCompanyData(dtpStartCompanyRapportSearch.Value, dtpEndCompanyRapportSearch.Value, id);
        }

        private void SortDisplayMasterQuantityColumnsIndex()
        {
            
            CompanyRapportDataGridView.Columns["SupplierColumn"].DisplayIndex = 0;
            CompanyRapportDataGridView.Columns["HarvestDateColumn"].DisplayIndex = 1;
            CompanyRapportDataGridView.Columns["EmployeeColumn"].DisplayIndex = 2;
            CompanyRapportDataGridView.Columns["FarmColumn"].DisplayIndex = 3;
            CompanyRapportDataGridView.Columns["ProductColumn"].DisplayIndex = 4;
            CompanyRapportDataGridView.Columns["TypeColumn"].DisplayIndex = 5;
            CompanyRapportDataGridView.Columns["GoodQuantityColumn"].DisplayIndex = 6;
            CompanyRapportDataGridView.Columns["PriceColumn"].DisplayIndex = 7;
            CompanyRapportDataGridView.Columns["PaymentColumn"].DisplayIndex = 8;
            CompanyRapportDataGridView.Columns["PaymentColumn"].DisplayIndex = 9;
            CompanyRapportDataGridView.Columns["BadQuantityColumn"].DisplayIndex = 10;
        }


        #endregion





        #region Employee Hours Rapport

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

        private void RapportTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RapportTabControl.SelectedIndex)
            {
                case 0:
                    DisplayRapportCompanyData(); 
                    break;
                case 1:
                    DisplayRapportEmployeeHours();
                    break;
                case 2:
                    DisplayRapportEmployeeQuantity();
                    break;
                default:
                    Console.WriteLine("nothing");
                    break;
            }
        }


    }
}
