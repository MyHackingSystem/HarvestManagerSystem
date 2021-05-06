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
using HarvestManagerSystem.outil;

namespace HarvestManagerSystem.view
{
    public partial class FormAddQuantity : Form
    {

        private bool isEditHarvestQuantity = false;
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

        BindingSource bindingSourceHarvesterList = new BindingSource { DataSource = HarvesterList };

        private HarvestMS harvestMS;

        public FormAddQuantity(HarvestMS harvestMS)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddQuantity_Load(object sender, EventArgs e)
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();

            AddHarvestQuantityDataGridView.DataSource = bindingSourceHarvesterList;

            if (isEditHarvestQuantity)
            {
                HarvestDateTimePicker.Value = mProduction.ProductionDate;
                SupplierHarvestQuantityComboBox.SelectedIndex = SupplierHarvestQuantityComboBox.FindStringExact(mProduction.Supplier.SupplierName);
                FarmHarvestQuantityComboBox.SelectedIndex = FarmHarvestQuantityComboBox.FindStringExact(mProduction.Farm.FarmName);
                ProductHarvestQuantityComboBox.SelectedIndex = ProductHarvestQuantityComboBox.FindStringExact(mProduction.Product.ProductName);
                ProductTypeHarvestQuantityComboBox.SelectedIndex = ProductTypeHarvestQuantityComboBox.FindStringExact(mProduction.ProductDetail.ProductType);
                ApplyHarvestQuantityButton.Text = "Update";
            }
            else
            {
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
            ValidateAddHarvestQuantityByGroup();           
        }

        private bool ValidateInput()
        {
            return
            HarvestDateTimePicker.Value == null ||
            SupplierHarvestQuantityComboBox.SelectedIndex == -1 ||
            FarmHarvestQuantityComboBox.SelectedIndex == -1 ||
            ProductHarvestQuantityComboBox.SelectedIndex == -1 ||
            ProductTypeHarvestQuantityComboBox.SelectedIndex == -1;
        }

        private void ValidateAddHarvestQuantityByGroup()
        {
            double allQuantity = 0.0;
            double badQuantity = 0.0;
            allQuantity = Convert.ToDouble(txtInputAllQuantity.Text);
            badQuantity = Convert.ToDouble(txtInputBadQuantity.Text);

            PreferencesDAO preferencesDAO = PreferencesDAO.getInstance();
            _ = new Preferences();
            Preferences pref;
            try
            {
                pref = preferencesDAO.getPreferences();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue, essayez de cliquer à nouveau sur le bouton de validation ");
                return;
            }

            double penaltyGeneral = pref.PenaltyGeneral;
            double damageGeneral = pref.DamageGeneral;
            double transPrice = pref.TransportPrice;
            int totalEmployee = HarvesterList.Count;
            double totalTransport = 0.0; double totalCredit = 0.0; double totalPayment = 0.0;
            double totalAllQuantity = 0;
            double totalBadQuantity = 0.0;
            double totalGoodQuantity = 0.0;

            double allQuantityEmp = allQuantity / totalEmployee;
            double badQuantityEmp = badQuantity / totalEmployee;

            double employeePrice = mProductDetailDictionary.GetValueOrDefault(ProductTypeHarvestQuantityComboBox.GetItemText(ProductTypeHarvestQuantityComboBox.SelectedItem)).PriceEmployee;
            double companyPrice = mProductDetailDictionary.GetValueOrDefault(ProductTypeHarvestQuantityComboBox.GetItemText(ProductTypeHarvestQuantityComboBox.SelectedItem)).PriceCompany;
            
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
                hq.Transport.TransportAmount = (hq.TransportStatus) ? transPrice : 0;
                totalTransport += hq.Transport.TransportAmount;
                totalCredit += hq.Credit.CreditAmount;
                totalPayment += hq.Payment;
                hq.HarvestType = 2;
            }

            TotalEmployeeTextBox.Text = Convert.ToString(totalEmployee);
            TotalQuantityTextBox.Text = Convert.ToString(totalAllQuantity);
            txtTotalBadQuantity.Text = Convert.ToString(totalBadQuantity);
            txtTotalGoodQuantity.Text = Convert.ToString(totalGoodQuantity);
            ProductPriceTextBox.Text = Convert.ToString(employeePrice);
            TotalTransportTextBox.Text = Convert.ToString(totalTransport);
            TotalCreditTextBox.Text = Convert.ToString(totalCredit);
            TotalPaymentTextBox.Text = Convert.ToString(totalPayment);
            mProduction.Price = companyPrice;
            AddHarvestQuantityDataGridView.Refresh();

        }

        
        private void ApplyHarvestQuantityButton_Click(object sender, EventArgs e)
        {
            if (checkApplyButtonInput())
            {
                MessageBox.Show("Vérifier les values entrée");
                return;
            }
            if (isEditHarvestQuantity)
            {
                updateProductionDataInDatabase();
            }
            else
            {
                addProductionDataToDatabase();
            }
            harvestMS.RefreshQuantityProductionTable();
        }

        private bool checkApplyButtonInput()
        {
            return (TotalEmployeeTextBox.Text == "" || 
                TotalQuantityTextBox.Text == "" ||
                txtTotalBadQuantity.Text == "" ||
                txtTotalGoodQuantity.Text == "" ||
                ProductPriceTextBox.Text == "" || 
                TotalTransportTextBox.Text == "" || 
                TotalCreditTextBox.Text == "" ||
                TotalPaymentTextBox.Text == "") || 
                (Convert.ToInt32(TotalEmployeeTextBox.Text) <= 0) || 
                (Convert.ToDouble(TotalQuantityTextBox.Text) <= 0);
        }

        private void addProductionDataToDatabase()
        {

            setProductionValueFromFields();
            long productionId = mProductionDAO.addProductionAndGetId(mProduction);
            if (productionId != -1)
            {
                mProduction.ProductionID = productionId;
                bool added = addHarvestQuantityToDatabase();
                if (added)
                {
                    MessageBox.Show("Data Was Added");
                    wipeFields();
                }

            }
            else { MessageBox.Show("Data Not Added"); }

        }

        private bool addHarvestQuantityToDatabase()
        {
            bool trackInsert = false;
            if (mProduction.ProductionID > 0)
            {
                foreach (HarvestQuantity item in HarvesterList)
                {
                    item.Production.ProductionID = mProduction.ProductionID;
                    item.HarvestDate = mProduction.ProductionDate;
                    item.Production.Farm.FarmId = mProduction.Farm.FarmId;
                    trackInsert = mHarvestQuantityDAO.addHarvestQuantity(item);
                    if (!trackInsert) break;
                }
            }
            return trackInsert;
        }

        private void updateProductionDataInDatabase()
        {
            setProductionValueFromFields();
            if (mProductionDAO.updateProductionData(mProduction))
            {
                if (updateHarvestQuantityInDatabase())
                {
                    MessageBox.Show("Data updated");
                }
            }
            else
            {
                MessageBox.Show("Data not updated");
            }
            isEditHarvestQuantity = false;
            this.Close();
        }

        private bool updateHarvestQuantityInDatabase()
        {
            bool trackInsert = false;
            foreach (HarvestQuantity item in HarvesterList)
            {
                item.HarvestDate = mProduction.ProductionDate;
                item.Production.Farm.FarmId = mProduction.Farm.FarmId;
                item.Production.ProductionID = mProduction.ProductionID;
                trackInsert =  mHarvestQuantityDAO.updateQuantityWork(item);
                if (!trackInsert) break;
            }
            return trackInsert;
        }

        private void setProductionValueFromFields()
        {
            mProduction.ProductionType = 2;
            mProduction.ProductionDate = HarvestDateTimePicker.Value;
            mProduction.Supplier.SupplierId = mSupplierDictionary.GetValueOrDefault(SupplierHarvestQuantityComboBox.GetItemText(SupplierHarvestQuantityComboBox.SelectedItem)).SupplierId;
            mProduction.Farm.FarmId = mFarmDictionary.GetValueOrDefault(FarmHarvestQuantityComboBox.GetItemText(FarmHarvestQuantityComboBox.SelectedItem)).FarmId;
            mProduction.Product.ProductId = mProductDictionary.GetValueOrDefault(ProductHarvestQuantityComboBox.GetItemText(ProductHarvestQuantityComboBox.SelectedItem)).ProductId;
            mProduction.ProductDetail.ProductDetailId = mProductDetailDictionary.GetValueOrDefault(ProductTypeHarvestQuantityComboBox.GetItemText(ProductTypeHarvestQuantityComboBox.SelectedItem)).ProductDetailId;
            mProduction.TotalEmployee = Convert.ToInt32(TotalEmployeeTextBox.Text);
            mProduction.TotalQuantity = Convert.ToDouble(TotalQuantityTextBox.Text);
            mProduction.TotalMinutes = 0.0;
            mProduction.Price = Convert.ToDouble(ProductPriceTextBox.Text);
        }

        internal void InflateUI(Production production)
        {
            isEditHarvestQuantity = true;

            mProduction.ProductionID = production.ProductionID;
            mProduction.ProductionDate = production.ProductionDate;
            mProduction.Supplier.SupplierName = production.Supplier.SupplierName;
            mProduction.Farm.FarmName = production.Farm.FarmName;
            mProduction.Product.ProductName = production.Product.ProductName;
            mProduction.ProductDetail.ProductType = production.ProductDetail.ProductType;
            mProduction.ProductionType = production.ProductionType;

            HarvesterList.Clear();
            try
            {
                HarvesterList = mHarvestQuantityDAO.HarvestQuantityByProduction(production);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            double AllQuantity = 0;
            double BadQuantity = 0;

            foreach (HarvestQuantity quantity in HarvesterList)
            {
                AllQuantity += quantity.AllQuantity;
                BadQuantity += quantity.BadQuantity;
                quantity.TransportStatus = (quantity.TransportAmount > 0) ? true : false;
            }
            txtInputAllQuantity.Text = AllQuantity.ToString();
            txtInputBadQuantity.Text = BadQuantity.ToString();
            SetToTotalZero();
        }

        #region Common code

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
                ProductTypeHarvestQuantityComboBox.DataSource = CodeList;
            }
        }

        private void FormAddQuantity_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
        }

        private void wipeFields()
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            HarvestDateTimePicker.Value = DateTime.Now;
            SupplierHarvestQuantityComboBox.SelectedIndex = -1;
            FarmHarvestQuantityComboBox.SelectedIndex = -1;
            ProductHarvestQuantityComboBox.SelectedIndex = -1;
            ProductTypeHarvestQuantityComboBox.SelectedIndex = -1;
            txtInputAllQuantity.Text = "";
            txtInputBadQuantity.Text = "";
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            foreach (HarvestQuantity h in HarvesterList)
            {
                h.HarvestDate = DateTime.Now;
                h.AllQuantity = 0.0;
                h.BadQuantity = 0.0;
                h.ProductPrice = 0.0;
                h.TransportStatus = false;
                h.Transport.TransportAmount = 0.0;
                h.Credit.CreditAmount = 0.0;
                h.HarvestType = 2;
                h.Remarque = "";
            }

            SetToTotalZero();
            AddHarvestQuantityDataGridView.Refresh();
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

        private void SetToTotalZero()
        {
            TotalEmployeeTextBox.Text = "0";
            TotalQuantityTextBox.Text = "0.0";
            txtTotalBadQuantity.Text = "0.0";
            txtTotalGoodQuantity.Text = "0.0";
            ProductPriceTextBox.Text = "0.0";
            TotalTransportTextBox.Text = "0.0";
            TotalCreditTextBox.Text = "0.0";
            TotalPaymentTextBox.Text = "0.0";
        }

        private void ClearHarvestButton_Click(object sender, EventArgs e)
        {
            wipeFields();
            SortDisplayIndex();
        }

        #endregion

        private void ImportExcelButton_Click(object sender, EventArgs e)
        {

        }

        private bool validateListEmployee(List<HarvestQuantity> imported)
        {

            List<HarvestQuantity> selected = new List<HarvestQuantity>();

            try
            {
                selected = mHarvestQuantityDAO.HarvestersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List<int> selectedID = new List<int>();
            List<int> importedID = new List<int>();

            foreach (HarvestQuantity q in selected) {
                selectedID.Add(q.Employee.EmployeeId);
            }
            foreach (HarvestQuantity q in imported)
            {
                importedID.Add(q.Employee.EmployeeId);
            }
            return Validation.ScrambledEquals(importedID, selectedID);
        }

        private void txtInputAllQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtInputBadQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
