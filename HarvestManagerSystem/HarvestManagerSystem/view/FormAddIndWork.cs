using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.view
{
    public partial class FormAddIndWork : Form
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

        private HarvestMS harvestMS;
        private static FormAddIndWork instance;

        private FormAddIndWork(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
            InitializeComponent();
        }

        public static FormAddIndWork getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddIndWork(harvestMS);
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
                instance = new FormAddIndWork(harvestMS);

            }
            instance.Show();
        }

        private void FormAddIndWork_Load(object sender, EventArgs e)
        {

        }

        private void FormAddIndWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void ValidateHarvestQuantityButton_Click(object sender, EventArgs e)
        {
            //if (ValidateInput())
            //{
            //    MessageBox.Show("Vérifier les valeurs saisies");
            //    return;
            //}

            //ValidateAddHarvestQuantityByIndividual();


        }

        private void ValidateAddHarvestQuantityByIndividual()
        {
            //PreferencesDAO preferencesDAO = PreferencesDAO.getInstance();
            //_ = new Preferences();
            //Preferences pref;
            //try
            //{
            //    pref = preferencesDAO.getPreferences();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Une erreur est survenue, essayez de cliquer à nouveau sur le bouton de validation ");
            //    return;
            //}

            //double penaltyGeneral = pref.PenaltyGeneral;
            //double damageGeneral = pref.DamageGeneral;
            //double transPrice = pref.TransportPrice;
            //int totalEmployee = HarvesterList.Count;
            //double totalTransport = 0.0; double totalCredit = 0.0; double totalPayment = 0.0;
            //double totalAllQuantity = 0;
            //double totalBadQuantity = 0.0;
            //double totalGoodQuantity = 0.0;

            //double employeePrice = mProductDetailDictionary.GetValueOrDefault(ProductTypeHarvestQuantityComboBox.GetItemText(ProductTypeHarvestQuantityComboBox.SelectedItem)).PriceEmployee;
            //double companyPrice = mProductDetailDictionary.GetValueOrDefault(ProductTypeHarvestQuantityComboBox.GetItemText(ProductTypeHarvestQuantityComboBox.SelectedItem)).PriceCompany;

            //foreach (HarvestQuantity hq in HarvesterList)
            //{
            //    hq.ProductPrice = employeePrice;
            //    hq.PenaltyGeneral = penaltyGeneral;
            //    hq.DamageGeneral = damageGeneral;
            //    totalAllQuantity += hq.GoodQuantity;
            //    totalBadQuantity += hq.BadQuantity;
            //    totalGoodQuantity += hq.GoodQuantity;
            //    hq.Transport.TransportAmount = (hq.TransportStatus) ? transPrice : 0;
            //    totalTransport += hq.Transport.TransportAmount;
            //    totalCredit += hq.Credit.CreditAmount;
            //    totalPayment += hq.Payment;
            //    hq.HarvestType = 2;
            //}

            //TotalEmployeeTextBox.Text = Convert.ToString(totalEmployee);
            //TotalQuantityTextBox.Text = Convert.ToString(totalAllQuantity);
            //txtTotalBadQuantity.Text = Convert.ToString(totalBadQuantity);
            //txtTotalGoodQuantity.Text = Convert.ToString(totalGoodQuantity);
            //ProductPriceTextBox.Text = Convert.ToString(employeePrice);
            //TotalTransportTextBox.Text = Convert.ToString(totalTransport);
            //TotalCreditTextBox.Text = Convert.ToString(totalCredit);
            //TotalPaymentTextBox.Text = Convert.ToString(totalPayment);
            //mProduction.Price = companyPrice;
            //AddHarvestQuantityDataGridView.Refresh();
        }
    }
}
