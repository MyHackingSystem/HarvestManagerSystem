using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;
using System.Linq;

namespace HarvestManagerSystem.view
{
    public partial class FormAddQuantity : Form
    {
        private bool isEditHarvestQuantity = false;
        private TransportDAO transportDAO = TransportDAO.getInstance();
        private EmployeeDAO employeeDAO = EmployeeDAO.getInstance();
        private FarmDAO farmDAO = FarmDAO.getInstance();
        private SupplierDAO supplierDAO = SupplierDAO.getInstance();
        private ProductDAO productDAO = ProductDAO.getInstance();
        private ProductDetailDAO productDetailDAO = ProductDetailDAO.getInstance();
        private HarvestQuantityDAO mHarvestQuantityDAO = HarvestQuantityDAO.getInstance();
        private Production mProduction = new Production();
        private ProductionDAO mProductionDAO = ProductionDAO.getInstance();
        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private Dictionary<string, Product> mProductDictionary = new Dictionary<string, Product>();
        private Dictionary<string, ProductDetail> mProductDetailDictionary = new Dictionary<string, ProductDetail>();
        static List<HarvestQuantity> HarvesterList = new List<HarvestQuantity>();

        BindingSource bindingSourceHarvesterList = new System.Windows.Forms.BindingSource { DataSource = HarvesterList };

        private HarvestMS harvestMS;
        private static FormAddQuantity instance;

        public FormAddQuantity(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        public static FormAddQuantity getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddQuantity(harvestMS);
            }
            return instance;
        }

        public void ShowFormAdd()
        {
            if (instance != null)
            {
                instance.BringToFront();
            }
            else
            {
                instance = new FormAddQuantity(harvestMS);

            }
            instance.Show();
        }

        private void FormAddQuantity_Load(object sender, EventArgs e)
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            AddHarvestQuantityDataGridView.DataSource = bindingSourceHarvesterList;
            if (isEditHarvestQuantity)
            {
                HarvestHoursDateTimePicker.Value = mProduction.ProductionDate;
                SupplierHarvestQuantityComboBox.SelectedIndex = SupplierHarvestQuantityComboBox.FindStringExact(mProduction.Supplier.SupplierName);
                FarmHarvestQuantityComboBox.SelectedIndex = FarmHarvestQuantityComboBox.FindStringExact(mProduction.Farm.FarmName);
                ProductHarvestQuantityComboBox.SelectedIndex = ProductHarvestQuantityComboBox.FindStringExact(mProduction.Product.ProductName);
                ProductCodeHarvestQuantityComboBox.SelectedIndex = ProductCodeHarvestQuantityComboBox.FindStringExact(mProduction.ProductDetail.ProductCode);
                ApplyHarvestQuantityButton.Text = "Update";
            }
            else
            {
                radioBtnHarvestByGroup.Checked = true;
                HarvesterList = mHarvestQuantityDAO.HarvestersData();

            }

            bindingSourceHarvesterList.DataSource = HarvesterList;
            SortDisplayIndex();
            disableTotalTextBoxField();
        }


        private void ValidateHarvestQuantityButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                MessageBox.Show("Vérifier les valeurs saisies");
                return;
            }
            ValidateAddHarvestHours();
        }

        private bool ValidateInput()
        {
            return
            HarvestHoursDateTimePicker.Value == null ||
            SupplierHarvestQuantityComboBox.SelectedIndex == -1 ||
            FarmHarvestQuantityComboBox.SelectedIndex == -1 ||
            ProductHarvestQuantityComboBox.SelectedIndex == -1 ||
            ProductCodeHarvestQuantityComboBox.SelectedIndex == -1;

        }

        private void ValidateAddHarvestHours()
        {
            //PreferencesDAO preferencesDAO = PreferencesDAO.getInstance();
            int totalEmployee = HarvesterList.Count;
            double totalTransport = 0.0; double totalCredit = 0.0; double totalPayment = 0.0;
            double totalAllQuantity = 0;
            double totalBadQuantity = 0.0;
            double totalGoodQuantity = 0.0;
            double allQuantity = Convert.ToDouble(txtInputAllQuantity.Text);
            double badQuantity = Convert.ToDouble(txtInputBadQuantity.Text);
            double allQuantityEmp = allQuantity / totalEmployee;
            double badQuantityEmp = badQuantity / totalEmployee;
            double penaltyGeneral = 20;
            double damageGeneral = 30;
            double employeePrice = mProductDetailDictionary.GetValueOrDefault(ProductCodeHarvestQuantityComboBox.GetItemText(ProductCodeHarvestQuantityComboBox.SelectedItem)).PriceEmployee;
            double companyPrice = mProductDetailDictionary.GetValueOrDefault(ProductCodeHarvestQuantityComboBox.GetItemText(ProductCodeHarvestQuantityComboBox.SelectedItem)).PriceCompany;
            foreach (HarvestQuantity hq in HarvesterList)
            {
                hq.AllQuantity = allQuantityEmp;
                hq.BadQuantity = badQuantityEmp;
                hq.ProductPrice = employeePrice;
                hq.PenaltyGeneral = penaltyGeneral;
                hq.DamageGeneral = damageGeneral;
                totalAllQuantity += hq.GoodQuantity;
                totalBadQuantity += hq.BadQuantity;
                totalGoodQuantity += hq.GoodQuantity;
                hq.Transport.TransportAmount = (hq.TransportStatus) ? 10 : 0;
                totalTransport += hq.Transport.TransportAmount;
                totalCredit += hq.Credit.CreditAmount;
                totalPayment += hq.Payment;
                hq.HarvestType = getHarvestType();
            }

            TotalEmployeeTextBox.Text = Convert.ToString(totalEmployee);
            TotalQuantityTextBox.Text = Convert.ToString(totalAllQuantity);
            txtTotalBadQuantity.Text = Convert.ToString(totalBadQuantity);
            txtTotalGoodQuantity.Text = Convert.ToString(totalGoodQuantity);
            ProductPriceTextBox.Text = Convert.ToString(employeePrice);
            TotalTransportTextBox.Text = Convert.ToString(totalTransport);
            TotalCreditTextBox.Text = Convert.ToString(totalCredit);
            TotalPaymentTextBox.Text = Convert.ToString(totalPayment);
            AddHarvestQuantityDataGridView.Refresh();

        }

        private int getHarvestType()
        {
            if (radioBtnHarvestByGroup.Checked)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        private void SupplierNameList()
        {
            List<string> NamesList = new List<string>();
            mSupplierDictionary.Clear();
            try
            {
                mSupplierDictionary = supplierDAO.SupplierDictionary();
                NamesList.AddRange(mSupplierDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                SupplierHarvestQuantityComboBox.DataSource = NamesList;
            }
        }

        private void FarmNameList()
        {
            List<string> NamesList = new List<string>();
            mFarmDictionary.Clear();
            try
            {
                mFarmDictionary = farmDAO.FarmDictionary();
                NamesList.AddRange(mFarmDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                FarmHarvestQuantityComboBox.DataSource = NamesList;
            }
        }

        private void ProductNameList()
        {
            List<string> NamesList = new List<string>();
            mProductDictionary.Clear();
            try
            {
                mProductDictionary = productDAO.ProductDictionary();
                NamesList.AddRange(mProductDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                ProductHarvestQuantityComboBox.DataSource = NamesList;
            }
        }

        private void ProductHarvestHoursComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ProductHarvestQuantityComboBox.SelectedIndex;
            if (i < mProductDictionary.Values.Count && i >= 0)
            {
                DisplayProductDetailData(mProductDictionary.ElementAt(i).Value);
            }
        }

        private void DisplayProductDetailData(Product product)
        {
            List<string> CodeList = new List<string>();
            mProductDetailDictionary.Clear();
            try
            {
                mProductDetailDictionary = productDetailDAO.ProductCodeDictionary(product);
                CodeList.AddRange(mProductDetailDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (CodeList != null)
            {
                ProductCodeHarvestQuantityComboBox.DataSource = CodeList;
            }

        }


        private void FormAddQuantity_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
            instance = null;
        }

        private void wipeFields()
        {

        }

        private void SortDisplayIndex()
        {
            AddHarvestQuantityDataGridView.Columns["HarvestHoursIDColumn"].DisplayIndex = 0;
            AddHarvestQuantityDataGridView.Columns["HarvestDateColumn"].DisplayIndex = 1;
            AddHarvestQuantityDataGridView.Columns["EmployeeNameColumn"].DisplayIndex = 2;
            AddHarvestQuantityDataGridView.Columns["AllQuantityColumn"].DisplayIndex = 3;
            AddHarvestQuantityDataGridView.Columns["BadQuantityColumn"].DisplayIndex = 4;
            AddHarvestQuantityDataGridView.Columns["GoodQuantityColumn"].DisplayIndex = 5;
            AddHarvestQuantityDataGridView.Columns["ProductPriceColumn"].DisplayIndex = 6;
            AddHarvestQuantityDataGridView.Columns["TransportStatusColumn"].DisplayIndex = 7;
            AddHarvestQuantityDataGridView.Columns["CreditAmountColumn"].DisplayIndex = 8;
            AddHarvestQuantityDataGridView.Columns["PaymentColumn"].DisplayIndex = 9;
            AddHarvestQuantityDataGridView.Columns["RemarqueColumn"].DisplayIndex = 10;
        }

        private void disableTotalTextBoxField()
        {
            TotalEmployeeTextBox.Enabled = false;
            TotalQuantityTextBox.Enabled = false;
            ProductPriceTextBox.Enabled = false;
            TotalTransportTextBox.Enabled = false;
            TotalCreditTextBox.Enabled = false;
            TotalPaymentTextBox.Enabled = false;
        }


    }
}
