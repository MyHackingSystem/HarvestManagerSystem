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
using System.IO;
using ExcelDataReader;
using DataTable = System.Data.DataTable;

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

        List<HarvestQuantity>[] HarvestList = new List<HarvestQuantity>[7];

        private HarvestMS harvestMS;
        private static FormAddIndWork instance;

        public FormAddIndWork(HarvestMS harvestMS)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            this.harvestMS = harvestMS;
            InitializeComponent();
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

        private void ImportExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                HarvesterList = ReaHarvestFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!validateListEmployee(HarvesterList))
            {
                MessageBox.Show("la liste des employés sélectionnés n'est pas la même que la liste importée");
                //return;
            }
            dgvIndividualEmployeeList.DataSource = HarvesterList;
            dgvProduct1.DataSource = HarvestList[0];
            dgvProduct2.DataSource = HarvestList[1];
            dgvProduct3.DataSource = HarvestList[2];
            dgvProduct4.DataSource = HarvestList[3];
            dgvProduct5.DataSource = HarvestList[4];
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

            foreach (HarvestQuantity q in selected)
            {
                selectedID.Add(q.Employee.EmployeeId);
            }
            foreach (HarvestQuantity q in imported)
            {
                importedID.Add(q.Employee.EmployeeId);
            }
            return Validation.ScrambledEquals(importedID, selectedID);
        }

        private List<HarvestQuantity> ReaHarvestFile()
        {

            List<HarvestQuantity> HarvesterList = new List<HarvestQuantity>();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Office Files|*.xlsx;*.xls;", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                    DataSet result = reader.AsDataSet();
                    DataTable tbl = result.Tables[0];

                    HarvestList[0] = new List<HarvestQuantity>();
                    HarvestList[1] = new List<HarvestQuantity>();
                    HarvestList[2] = new List<HarvestQuantity>();
                    HarvestList[3] = new List<HarvestQuantity>();
                    HarvestList[4] = new List<HarvestQuantity>();


                    foreach (DataRow row in tbl.Rows)
                    {
                        if (row.ItemArray[0].ToString() == "ID") continue;
                        HarvestQuantity hq = new HarvestQuantity();

                        HarvestQuantity h1 = new HarvestQuantity();
                        HarvestQuantity h2 = new HarvestQuantity();
                        HarvestQuantity h3 = new HarvestQuantity();
                        HarvestQuantity h4 = new HarvestQuantity();
                        HarvestQuantity h5 = new HarvestQuantity();


                        try
                        {
                            hq.Employee.EmployeeId = (row.ItemArray[0].ToString() != null && !row.ItemArray[0].ToString().Equals("")) ? Convert.ToInt32(row.ItemArray[0].ToString()) : -1;
                            hq.Employee.FirstName = row.ItemArray[1].ToString();
                            hq.AllQuantity = (row.ItemArray[7].ToString() != null && !row.ItemArray[7].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[7].ToString()) : 0;

                            h1.Employee.EmployeeId = hq.Employee.EmployeeId;
                            h1.AllQuantity = (row.ItemArray[2].ToString() != null && !row.ItemArray[2].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[2].ToString()) : 0;
                            h2.Employee.EmployeeId = hq.Employee.EmployeeId;
                            h2.AllQuantity = (row.ItemArray[3].ToString() != null && !row.ItemArray[3].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[3].ToString()) : 0;
                            h3.Employee.EmployeeId = hq.Employee.EmployeeId;
                            h3.AllQuantity = (row.ItemArray[4].ToString() != null && !row.ItemArray[4].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[4].ToString()) : 0;
                            h4.Employee.EmployeeId = hq.Employee.EmployeeId;
                            h4.AllQuantity = (row.ItemArray[5].ToString() != null && !row.ItemArray[5].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[5].ToString()) : 0;
                            h5.Employee.EmployeeId = hq.Employee.EmployeeId;
                            h5.AllQuantity = (row.ItemArray[6].ToString() != null && !row.ItemArray[6].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[6].ToString()) : 0;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        if (hq.AllQuantity > 0 && hq.Employee.EmployeeId > 0) HarvesterList.Add(hq);
                        HarvestList[0].Add(h1);
                        HarvestList[1].Add(h2);
                        HarvestList[2].Add(h3);
                        HarvestList[3].Add(h4);
                        HarvestList[4].Add(h5);
                    }
                    reader.Close();
                }
            }
            return HarvesterList;
        }

        public static bool ScrambledEquals(List<int> x, List<int> y)
        {
            return !x.Except(y).Any();
        }
    }
}
