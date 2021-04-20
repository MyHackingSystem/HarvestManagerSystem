using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;
using System.Linq;


namespace HarvestManagerSystem.view
{
    public partial class FormAddHours : Form
    {
        private bool isEditHarvestHours = false;
        private HarvestHours mHarvestHours = new HarvestHours();

        private TransportDAO transportDAO = TransportDAO.getInstance();
        private EmployeeDAO employeeDAO = EmployeeDAO.getInstance();
        private FarmDAO farmDAO = FarmDAO.getInstance();
        private SupplierDAO supplierDAO = SupplierDAO.getInstance();
        private ProductDAO productDAO = ProductDAO.getInstance();
        private ProductDetailDAO productDetailDAO = ProductDetailDAO.getInstance();
        private HarvestHoursDAO harvestHoursDAO = HarvestHoursDAO.getInstance();
        private Production mProduction = new Production();
        private ProductionDAO mProductionDAO = ProductionDAO.getInstance();
        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private Dictionary<string, Product> mProductDictionary = new Dictionary<string, Product>();
        private Dictionary<string, ProductDetail> mProductDetailDictionary = new Dictionary<string, ProductDetail>();
        static List<HarvestHours> HarvesterList = new List<HarvestHours>();

        BindingSource bindingSourceHarvesterList = new System.Windows.Forms.BindingSource { DataSource = HarvesterList };

        private HarvestMS harvestMS;
        private static FormAddHours instance;

        public FormAddHours(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        public static FormAddHours getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddHours(harvestMS);
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
                instance = new FormAddHours(harvestMS);

            }
            instance.Show();
        }

        private void FormAddHours_Load(object sender, EventArgs e)
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            AddHarvestHoursDataGridView.DataSource = bindingSourceHarvesterList;
            if (isEditHarvestHours)
            {
                HarvestHoursDateTimePicker.Value = mProduction.ProductionDate;
                SupplierHarvestHoursComboBox.SelectedIndex = SupplierHarvestHoursComboBox.FindStringExact(mProduction.Supplier.SupplierName);
                FarmHarvestHoursComboBox.SelectedIndex = FarmHarvestHoursComboBox.FindStringExact(mProduction.Farm.FarmName);
                ProductHarvestHoursComboBox.SelectedIndex = ProductHarvestHoursComboBox.FindStringExact(mProduction.Product.ProductName);
                ProductCodeHarvestHoursComboBox.SelectedIndex = ProductCodeHarvestHoursComboBox.FindStringExact(mProduction.ProductDetail.ProductCode);
                ApplyHarvestHoursButton.Text = "Update";
            }
            else
            {
                HarvesterRadioButton.Checked = true;
                HarvesterList = harvestHoursDAO.HarvestersData();

            }

            bindingSourceHarvesterList.DataSource = HarvesterList;
            SortDisplayIndex();
            disableTotalTextBoxField();
        }

        private void ValidateHarvestHoursButton_Click(object sender, EventArgs e)
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
            SupplierHarvestHoursComboBox.SelectedIndex == -1 ||
            FarmHarvestHoursComboBox.SelectedIndex == -1 ||
            ProductHarvestHoursComboBox.SelectedIndex == -1 ||
            ProductCodeHarvestHoursComboBox.SelectedIndex == -1 ||
            SMHoursDateTimePicker.Value == null ||
            EMHoursDateTimePicker.Value == null ||
            SNHoursDateTimePicker.Value == null ||
            ENHoursDateTimePicker.Value == null ;
            
        }

        private void ValidateAddHarvestHours()
        {
            PreferencesDAO preferencesDAO = PreferencesDAO.getInstance();
            _ = new Preferences();
            Preferences pref;
            try
            {
                pref = preferencesDAO.getPreferences();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue, essayez de cliquer à nouveau sur le bouton de validation \n" + ex.Message);
                return;
            }
            double hourPrice = pref.HourPrice;
            double transPrice = pref.TransportPrice;
            double totalMinute = 0; double totalTransport = 0.0; double totalCredit = 0.0; double totalPayment = 0.0;
            double employeePrice = mProductDetailDictionary.GetValueOrDefault(ProductCodeHarvestHoursComboBox.GetItemText(ProductCodeHarvestHoursComboBox.SelectedItem)).PriceEmployee;
            double companyPrice = mProductDetailDictionary.GetValueOrDefault(ProductCodeHarvestHoursComboBox.GetItemText(ProductCodeHarvestHoursComboBox.SelectedItem)).PriceCompany;
            foreach (HarvestHours h in HarvesterList)
            {
                h.StartMorning = SMHoursDateTimePicker.Value;
                h.EndMorning = EMHoursDateTimePicker.Value;
                h.StartNoon = SNHoursDateTimePicker.Value;
                h.EndNoon = ENHoursDateTimePicker.Value;
                h.EmployeeType = getEmployeeType();
                h.HourPrice = hourPrice;
                totalMinute += h.TotalMinutes;
                h.Transport.TransportAmount = (h.TransportStatus) ? transPrice : 0;
                totalTransport += h.Transport.TransportAmount;
                totalCredit += h.Credit.CreditAmount;
                totalPayment += h.Payment;
            }

            TotalEmployeeTextBox.Text = Convert.ToString(HarvesterList.Count);
            TotalMinutesTextBox.Text = Convert.ToString(totalMinute);
            HourPriceTextBox.Text = Convert.ToString(hourPrice);
            TotalTransportTextBox.Text = Convert.ToString(totalTransport);
            TotalCreditTextBox.Text = Convert.ToString(totalCredit);
            TotalPaymentTextBox.Text = Convert.ToString(totalPayment);
            AddHarvestHoursDataGridView.Refresh();

        }

        private void ApplyHarvestHoursButton_Click(object sender, EventArgs e)
        {
            if (checkApplyButtonInput())
            {
                MessageBox.Show("Check values");
                return;
            }

            if (isEditHarvestHours)
            {
                updateProductionDataInDatabase();
            }
            else 
            { 
                addProductionDataToDatabase();
                harvestMS.RefreshHoursProductionTable();
            }
        }

        private bool checkApplyButtonInput()
        {
            return (TotalEmployeeTextBox.Text == "" || TotalMinutesTextBox.Text == "" || HourPriceTextBox.Text == "" || TotalTransportTextBox.Text == "" || TotalCreditTextBox.Text == "" ||
            TotalPaymentTextBox.Text == "") || (Convert.ToInt32(TotalEmployeeTextBox.Text) <= 0) || (Convert.ToDouble(TotalMinutesTextBox.Text) <= 0);
        }

        private void addProductionDataToDatabase()
        {

            setProductionValueFromFields();
            long productionId = mProductionDAO.addProductionAndGetId(mProduction);
            if (productionId != -1)
            {
                mProduction.ProductionID = productionId;
                bool added = addHarvestHoursToDatabase();
                if (added) {
                    MessageBox.Show("Data Was Added");
                    wipeFields();
                }
                
            }
            else { MessageBox.Show("Data Not Added"); }

        }

        private bool addHarvestHoursToDatabase()
        {
            bool trackInsert = false;
            if (mProduction.ProductionID > 0)
            {
                foreach (HarvestHours item in HarvesterList)
                {
                    item.Production.ProductionID = mProduction.ProductionID;
                    item.HarvestDate = mProduction.ProductionDate;
                    item.Production.Farm.FarmId = mProduction.Farm.FarmId;
                    trackInsert = harvestHoursDAO.addHoursWork(item);
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
                var message = (updateHoursWorkInDatabase()) ? "Updated production and hours" : "Not updated production and hours";
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Not Update Production");
            }
            harvestMS.RefreshHoursProductionTable();
        
            isEditHarvestHours = false;
            this.Close();
        }

        private bool updateHoursWorkInDatabase()
        {
            bool trackInsert = false;
            foreach (HarvestHours item in HarvesterList)
            {
                item.HarvestDate = mProduction.ProductionDate;
                item.Production.Farm.FarmId = mProduction.Farm.FarmId;
                item.Production.ProductionID = mProduction.ProductionID;
                trackInsert = harvestHoursDAO.updateHoursWork(item); 
                if (!trackInsert) break;
            }
            return trackInsert;
        }

        private void setProductionValueFromFields()
        {
            mProduction.ProductionType = 1;
            mProduction.ProductionDate = HarvestHoursDateTimePicker.Value;
            mProduction.Supplier.SupplierId = mSupplierDictionary.GetValueOrDefault(SupplierHarvestHoursComboBox.GetItemText(SupplierHarvestHoursComboBox.SelectedItem)).SupplierId;
            mProduction.Farm.FarmId = mFarmDictionary.GetValueOrDefault(FarmHarvestHoursComboBox.GetItemText(FarmHarvestHoursComboBox.SelectedItem)).FarmId;
            mProduction.Product.ProductId = mProductDictionary.GetValueOrDefault(ProductHarvestHoursComboBox.GetItemText(ProductHarvestHoursComboBox.SelectedItem)).ProductId;
            mProduction.ProductDetail.ProductDetailId = mProductDetailDictionary.GetValueOrDefault(ProductCodeHarvestHoursComboBox.GetItemText(ProductCodeHarvestHoursComboBox.SelectedItem)).ProductDetailId;
            mProduction.TotalEmployee = Convert.ToInt32(TotalEmployeeTextBox.Text);
            mProduction.TotalMinutes = Convert.ToDouble(TotalMinutesTextBox.Text);
            mProduction.TotalQuantity = 0.0;
            mProduction.Price = Convert.ToDouble(HourPriceTextBox.Text);
        }

        // Update Harvest hours Section
        internal void InflateUI(Production production)
        {
            isEditHarvestHours = true;

            mProduction.ProductionID = production.ProductionID;
            mProduction.ProductionDate = production.ProductionDate;
            mProduction.Supplier.SupplierName = production.SupplierName;
            mProduction.Farm.FarmName = production.FarmName;
            mProduction.Product.ProductName = production.ProductName;
            mProduction.ProductDetail.ProductCode = production.ProductCode;

            HarvesterList.Clear();
            try
            {
                HarvesterList = harvestHoursDAO.HarvestHoursByProduction(production);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            HarvestHours firstEmpoyee = HarvesterList[0];
            SMHoursDateTimePicker.Value = firstEmpoyee.StartMorning;
            EMHoursDateTimePicker.Value = firstEmpoyee.EndMorning;
            SNHoursDateTimePicker.Value = firstEmpoyee.StartNoon;
            ENHoursDateTimePicker.Value = firstEmpoyee.EndNoon;
            setEmployeeType(firstEmpoyee.EmployeeType);

            foreach (HarvestHours hours in HarvesterList)
            {
                hours.TransportStatus = (hours.TransportAmount > 0) ? true : false;
            }
            SetToTotalZero();
        }

        public int getEmployeeType()
        {
            if (ControllerRadioButton.Checked)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public void setEmployeeType(int i)
        {
            if (i == 2)
            {
                ControllerRadioButton.Checked = true;
            }
            else
            {
                HarvesterRadioButton.Checked = true;
            }
        }

        private void SetToTotalZero()
        {
            TotalEmployeeTextBox.Text = "0";
            TotalMinutesTextBox.Text = "0";
            HourPriceTextBox.Text = "0";
            TotalTransportTextBox.Text = "0";
            TotalCreditTextBox.Text = "0";
            TotalPaymentTextBox.Text = "0";
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
                SupplierHarvestHoursComboBox.DataSource = NamesList;
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
                FarmHarvestHoursComboBox.DataSource = NamesList;
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
                ProductHarvestHoursComboBox.DataSource = NamesList;
            }
        }

        private void ProductHarvestHoursComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ProductHarvestHoursComboBox.SelectedIndex;
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
                ProductCodeHarvestHoursComboBox.DataSource = CodeList;
            }

        }

        private void FormAddHours_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
            instance = null;
        }

        private void ClearHarvestHoursButton_Click(object sender, EventArgs e)
        {
            wipeFields();
            SortDisplayIndex();
        }
        private void wipeFields()
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            HarvesterRadioButton.Checked = true;
            HarvestHoursDateTimePicker.Value = DateTime.Now;
            SupplierHarvestHoursComboBox.SelectedIndex = -1;
            FarmHarvestHoursComboBox.SelectedIndex = -1;
            ProductHarvestHoursComboBox.SelectedIndex = -1;
            ProductCodeHarvestHoursComboBox.SelectedIndex = -1;
            SMHoursDateTimePicker.Value = DateTime.Today;
            EMHoursDateTimePicker.Value = DateTime.Today;
            SNHoursDateTimePicker.Value = DateTime.Today;
            ENHoursDateTimePicker.Value = DateTime.Today;
            InitDataGridView();
        }

        private void disableTotalTextBoxField()
        {
            TotalEmployeeTextBox.Enabled = false;
            TotalMinutesTextBox.Enabled = false;
            HourPriceTextBox.Enabled = false;
            TotalTransportTextBox.Enabled = false;
            TotalCreditTextBox.Enabled = false;
            TotalPaymentTextBox.Enabled = false;
        }

        private void SortDisplayIndex()
        {
            AddHarvestHoursDataGridView.Columns["HarvestHoursIDColumn"].DisplayIndex = 0;
            AddHarvestHoursDataGridView.Columns["HarvestDateColumn"].DisplayIndex = 1;
            AddHarvestHoursDataGridView.Columns["EmployeeNameColumn"].DisplayIndex = 2;
            AddHarvestHoursDataGridView.Columns["StartMorningColumn"].DisplayIndex = 3;
            AddHarvestHoursDataGridView.Columns["EndMorningColumn"].DisplayIndex = 4;
            AddHarvestHoursDataGridView.Columns["StartNoonColumn"].DisplayIndex = 5;
            AddHarvestHoursDataGridView.Columns["EndNoonColumn"].DisplayIndex = 6;
            AddHarvestHoursDataGridView.Columns["TimeStartMorningColumn"].DisplayIndex = 7;
            AddHarvestHoursDataGridView.Columns["TimeEndMorningColumn"].DisplayIndex = 8;
            AddHarvestHoursDataGridView.Columns["TimeStartNoonColumn"].DisplayIndex = 9;
            AddHarvestHoursDataGridView.Columns["TimeEndNoonColumn"].DisplayIndex = 10;
            AddHarvestHoursDataGridView.Columns["TotalMinutesColumn"].DisplayIndex = 11;
            AddHarvestHoursDataGridView.Columns["HourPriceColumn"].DisplayIndex = 12;
            AddHarvestHoursDataGridView.Columns["TransportStatusColumn"].DisplayIndex = 13;
            AddHarvestHoursDataGridView.Columns["CreditColumn"].DisplayIndex = 14;
            AddHarvestHoursDataGridView.Columns["PaymentColumn"].DisplayIndex = 15;
            AddHarvestHoursDataGridView.Columns["RemarqueColumn"].DisplayIndex = 16;
        }

        private void InitDataGridView()
        {
            foreach (HarvestHours h in HarvesterList)
            {
                h.StartMorning = SMHoursDateTimePicker.Value;
                h.EndMorning = EMHoursDateTimePicker.Value;
                h.StartNoon = SNHoursDateTimePicker.Value;
                h.EndNoon = ENHoursDateTimePicker.Value;
                h.EmployeeType = getEmployeeType();
                h.HourPrice = 0.0;
                h.TransportStatus = false;
                h.Transport.TransportAmount = 0.0;
                h.Credit.CreditAmount = 0.0;
                h.Remarque = "";

            }

            TotalEmployeeTextBox.Text = "0";
            TotalMinutesTextBox.Text = "0.0";
            HourPriceTextBox.Text = "0.0";
            TotalTransportTextBox.Text = "0.0";
            TotalCreditTextBox.Text = "0.0";
            TotalPaymentTextBox.Text = "0.0";
            AddHarvestHoursDataGridView.Refresh();
        }
    }
}
