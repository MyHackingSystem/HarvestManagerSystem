using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;
using System.Linq;
using HarvestManagerSystem.outil;
using System.IO;
using ExcelDataReader;
using DataTable = System.Data.DataTable;
using HarvestManagerSystem.common;

namespace HarvestManagerSystem.view
{
    public partial class FormAddIndWork : Form
    {
        private ProductDetailDAO productDetailDAO = ProductDetailDAO.getInstance();
        private HarvestQuantityDAO mHarvestQuantityDAO = HarvestQuantityDAO.getInstance();
        private ProductionDAO mProductionDAO = ProductionDAO.getInstance();
        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private Dictionary<string, Product> mProductDictionary = new Dictionary<string, Product>();
        private Dictionary<string, ProductDetail>[] mProductDetailDictionary = new Dictionary<string, ProductDetail>[6];
        private ComboBox[] cbProductDetail = new ComboBox[6];

        List<HarvestQuantity>[] HarvestList = new List<HarvestQuantity>[6];
        Production[] ProductionArray = new Production[6];

        private HarvestMS harvestMS;

        public FormAddIndWork()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddIndWork_Load(object sender, EventArgs e)
        {
            initDictArray();
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            initComboBox();
            initHarvestArray();
            initComboBoxArray();
    }

        private void initComboBox()
        {
            SupplierHarvestQuantityComboBox.SelectedIndex = -1;
            FarmHarvestQuantityComboBox.SelectedIndex = -1;
            ComboBoxProduct1.SelectedIndex = -1;
            ComboBoxProduct2.SelectedIndex = -1;
            ComboBoxProduct3.SelectedIndex = -1;
            ComboBoxProduct4.SelectedIndex = -1;
            ComboBoxProduct5.SelectedIndex = -1;
            ComboBoxType1.SelectedIndex = -1;
            ComboBoxType2.SelectedIndex = -1;
            ComboBoxType3.SelectedIndex = -1;
            ComboBoxType4.SelectedIndex = -1;
            ComboBoxType5.SelectedIndex = -1;
        }

        private void initHarvestArray()
        {
            HarvestList[0] = new List<HarvestQuantity>();
            HarvestList[1] = new List<HarvestQuantity>();
            HarvestList[2] = new List<HarvestQuantity>();
            HarvestList[3] = new List<HarvestQuantity>();
            HarvestList[4] = new List<HarvestQuantity>();
            HarvestList[5] = new List<HarvestQuantity>();

            ProductionArray[0] = new Production();
            ProductionArray[1] = new Production();
            ProductionArray[2] = new Production();
            ProductionArray[3] = new Production();
            ProductionArray[4] = new Production();
            ProductionArray[5] = new Production();
        }

        private void initDictArray()
        {
            for (int i = 0; i < mProductDetailDictionary.Count(); i ++)
            {
                mProductDetailDictionary[i] = new Dictionary<string, ProductDetail>();
            }
        }

        private void initComboBoxArray()
        {
            cbProductDetail[1] = ComboBoxType1;
            cbProductDetail[2] = ComboBoxType2;
            cbProductDetail[3] = ComboBoxType3;
            cbProductDetail[4] = ComboBoxType4;
            cbProductDetail[5] = ComboBoxType5;
        }

        private void ValidateHarvestQuantityButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                MessageBox.Show("Vérifier les valeurs saisies");
                return;
            }
            ValidateHarvestQuantityByIndividual();
        }

        private bool ValidateInput()
        {
            return
            HarvestDateTimePicker.Value == null ||
            SupplierHarvestQuantityComboBox.SelectedIndex == -1 ||
            FarmHarvestQuantityComboBox.SelectedIndex == -1 ||
            ComboBoxProduct1.SelectedIndex == -1 ||
            ComboBoxProduct2.SelectedIndex == -1 ||
            ComboBoxProduct3.SelectedIndex == -1 ||
            ComboBoxProduct4.SelectedIndex == -1 ||
            ComboBoxProduct5.SelectedIndex == -1 ||
            ComboBoxType1.SelectedIndex == -1 ||
            ComboBoxType2.SelectedIndex == -1 ||
            ComboBoxType3.SelectedIndex == -1 ||
            ComboBoxType4.SelectedIndex == -1 ||
            ComboBoxType5.SelectedIndex == -1;
        }

        private void ValidateHarvestQuantityByIndividual()
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
                MessageBox.Show("Une erreur est survenue, essayez de cliquer à nouveau sur le bouton de validation ");
                return;
            }

            double penaltyGeneral = pref.PenaltyGeneral;
            double damageGeneral = pref.DamageGeneral;
            double transPrice = pref.TransportPrice;
            int[] totalEmployee = new int[6];
            double[] totalTransport = new double[6]; double[] totalCredit = new double[6]; double[] totalPayment = new double[6];
            double[] totalAllQuantity = new double[6]; double[] totalBadQuantity = new double[6]; double[] totalGoodQuantity = new double[6];
            double employeePrice = 0.0;
            double companyPrice = 0.0;

            for (int i = 1; i < 6; i++)
            {
                totalEmployee[i] = HarvestList[i].Count;
                try
                {
                    employeePrice = mProductDetailDictionary[i].GetValueOrDefault(cbProductDetail[i].GetItemText(cbProductDetail[i].SelectedItem)).PriceEmployee;
                    companyPrice = mProductDetailDictionary[i].GetValueOrDefault(cbProductDetail[i].GetItemText(cbProductDetail[i].SelectedItem)).PriceCompany;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                foreach (HarvestQuantity hq in HarvestList[i])
                {
                    hq.ProductPrice = employeePrice;
                    hq.PenaltyGeneral = penaltyGeneral;
                    hq.DamageGeneral = damageGeneral;
                    totalAllQuantity[i] += hq.GoodQuantity;
                    totalBadQuantity[i] += hq.BadQuantity;
                    totalGoodQuantity[i] += hq.GoodQuantity;
                    hq.Transport.TransportAmount = (hq.TransportStatus) ? transPrice : 0;
                    totalTransport[i] += hq.Transport.TransportAmount;
                    totalCredit[i] += hq.Credit.CreditAmount;
                    totalPayment[i] += hq.Payment;
                    hq.HarvestType = 1;
                }

                txtTotalPayment1.Text = "Emp: " + Convert.ToString(employeePrice * totalGoodQuantity[1]) + " / Comp: " + Convert.ToString(companyPrice * totalGoodQuantity[1]);
                txtTotalPayment2.Text = "Emp: " + Convert.ToString(employeePrice * totalGoodQuantity[2]) + " / Comp: " + Convert.ToString(companyPrice * totalGoodQuantity[2]);
                txtTotalPayment3.Text = "Emp: " + Convert.ToString(employeePrice * totalGoodQuantity[3]) + " / Comp: " + Convert.ToString(companyPrice * totalGoodQuantity[3]);
                txtTotalPayment4.Text = "Emp: " + Convert.ToString(employeePrice * totalGoodQuantity[4]) + " / Comp: " + Convert.ToString(companyPrice * totalGoodQuantity[4]);
                txtTotalPayment5.Text = "Emp: " + Convert.ToString(employeePrice * totalGoodQuantity[5]) + " / Comp: " + Convert.ToString(companyPrice * totalGoodQuantity[5]);
            }

            txttotalGoodQuantity1.Text = Convert.ToString(totalGoodQuantity[1]);
            txttotalGoodQuantity2.Text = Convert.ToString(totalGoodQuantity[2]);
            txttotalGoodQuantity3.Text = Convert.ToString(totalGoodQuantity[3]);
            txttotalGoodQuantity4.Text = Convert.ToString(totalGoodQuantity[4]);
            txttotalGoodQuantity5.Text = Convert.ToString(totalGoodQuantity[5]);

            //mProduction.Price = companyPrice;
            //AddHarvestQuantityDataGridView.Refresh();
        }

        private void ImportExcelButton_Click(object sender, EventArgs e)
        {
            List<HarvestQuantity> importedList = new List<HarvestQuantity>();
            try
            {
                importedList = ReaHarvestFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //if (!validateListEmployee(importedList))
            //{
            //    MessageBox.Show("la liste des employés sélectionnés n'est pas la même que la liste importée");
            //    return;
            //}
            loadDGVData();
        }

        private bool validateListEmployee(List<HarvestQuantity> imported)
        {

            List<Employee> selected = new List<Employee>();
            EmployeeDAO employeeDAO = EmployeeDAO.getInstance();

            try
            {
                selected = employeeDAO.ListEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List<int> selectedID = new List<int>();
            List<int> importedID = new List<int>();

            foreach (Employee q in selected)
            {
                selectedID.Add(q.EmployeeId);
            }
            foreach (HarvestQuantity q in imported)
            {
                importedID.Add(q.Employee.EmployeeId);
            }
            return Validation.ScrambledEquals(importedID, selectedID);
        }

        private void loadDGVData()
        {
            dgvIndividualEmployeeList.DataSource = HarvestList[0];
            dgvTotalProduct.DataSource = HarvestList[0];
            dgvProduct1.DataSource = HarvestList[1];
            dgvProduct2.DataSource = HarvestList[2];
            dgvProduct3.DataSource = HarvestList[3];
            dgvProduct4.DataSource = HarvestList[4];
            dgvProduct5.DataSource = HarvestList[5];
        }

        private List<HarvestQuantity> ReaHarvestFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Office Files|*.xlsx;*.xls;", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                    DataSet result = reader.AsDataSet();
                    DataTable tbl = result.Tables[0];

                    initHarvestArray();

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

                        HarvestList[0].Add(hq);
                        HarvestList[1].Add(h1);
                        HarvestList[2].Add(h2);
                        HarvestList[3].Add(h3);
                        HarvestList[4].Add(h4);
                        HarvestList[5].Add(h5);
                    }
                    reader.Close();
                }
            }
            return HarvestList[5];
        }

        public static bool ScrambledEquals(List<int> x, List<int> y)
        {
            return !x.Except(y).Any();
        }

        private void ComboBoxProduct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ComboBoxProduct1.SelectedIndex;
            if (i < mProductDictionary.Values.Count && i >= 0)
            {
                List<string> CodeList = new List<string>();
                mProductDetailDictionary[1].Clear();
                try
                {
                    mProductDetailDictionary[1] = productDetailDAO.ProductTypeDictionary(mProductDictionary.ElementAt(i).Value);

                    CodeList.AddRange(mProductDetailDictionary[1].Keys);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (CodeList != null)
                {
                    ComboBoxType1.DataSource = CodeList;
                }
            }
        }

        private void ComboBoxProduct2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ComboBoxProduct2.SelectedIndex;
            if (i < mProductDictionary.Values.Count && i >= 0)
            {
                List<string> CodeList = new List<string>();
                mProductDetailDictionary[2].Clear();
                try
                {
                    mProductDetailDictionary[2] = productDetailDAO.ProductTypeDictionary(mProductDictionary.ElementAt(i).Value);

                    CodeList.AddRange(mProductDetailDictionary[2].Keys);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (CodeList != null)
                {
                    ComboBoxType2.DataSource = CodeList;
                }
            }
        }

        private void ComboBoxProduct3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ComboBoxProduct3.SelectedIndex;
            if (i < mProductDictionary.Values.Count && i >= 0)
            {
                List<string> CodeList = new List<string>();
                mProductDetailDictionary[3].Clear();
                try
                {
                    mProductDetailDictionary[3] = productDetailDAO.ProductTypeDictionary(mProductDictionary.ElementAt(i).Value);

                    CodeList.AddRange(mProductDetailDictionary[3].Keys);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (CodeList != null)
                {
                    ComboBoxType3.DataSource = CodeList;
                }
            }
        }

        private void ComboBoxProduct4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ComboBoxProduct4.SelectedIndex;
            if (i < mProductDictionary.Values.Count && i >= 0)
            {
                List<string> CodeList = new List<string>();
                mProductDetailDictionary[4].Clear();
                try
                {
                    mProductDetailDictionary[4] = productDetailDAO.ProductTypeDictionary(mProductDictionary.ElementAt(i).Value);

                    CodeList.AddRange(mProductDetailDictionary[4].Keys);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (CodeList != null)
                {
                    ComboBoxType4.DataSource = CodeList;
                }
            }
        }

        private void ComboBoxProduct5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ComboBoxProduct5.SelectedIndex;
            if (i < mProductDictionary.Values.Count && i >= 0)
            {
                List<string> CodeList = new List<string>();
                mProductDetailDictionary[5].Clear();
                try
                {
                    mProductDetailDictionary[5] = productDetailDAO.ProductTypeDictionary(mProductDictionary.ElementAt(i).Value);

                    CodeList.AddRange(mProductDetailDictionary[5].Keys);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (CodeList != null)
                {
                    ComboBoxType5.DataSource = CodeList;
                }
            }
        }

        private void ClearHarvestButton_Click(object sender, EventArgs e)
        {
            WipeFields();
        }

        private void WipeFields()
        {
            HarvestDateTimePicker.Value = DateTime.Now;
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            initComboBox();
            InitDataGridView();
        }

        private void SupplierNameList()
        {
            mSupplierDictionary = Common.SupplierNameList(SupplierHarvestQuantityComboBox);
        }

        private void FarmNameList()
        {
            mFarmDictionary = Common.FarmNameList(FarmHarvestQuantityComboBox);
        }

        private void ProductNameList()
        {
            mProductDictionary = Common.ProductNameList(ComboBoxProduct1);
            Common.ProductNameList(ComboBoxProduct2);
            Common.ProductNameList(ComboBoxProduct3);
            Common.ProductNameList(ComboBoxProduct4);
            Common.ProductNameList(ComboBoxProduct5);
        }

        private void InitDataGridView()
        {
            for (int i = 0; i < HarvestList.Count(); i++)
            {
                foreach (HarvestQuantity h in HarvestList[i])
                {
                    h.Employee.FirstName = "";
                    h.Employee.LastName = "";
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
            }

            loadDGVData();
            dgvIndividualEmployeeList.Refresh();
            dgvTotalProduct.Refresh();
            dgvProduct1.Refresh();
            dgvProduct2.Refresh();
            dgvProduct3.Refresh();
            dgvProduct4.Refresh();
            dgvProduct5.Refresh();
            SetToTotalZero();
        }

        private void SetToTotalZero()
        {
            txttotalGoodQuantity1.Text = "0.0";
            txttotalGoodQuantity2.Text = "0.0";
            txttotalGoodQuantity3.Text = "0.0";
            txttotalGoodQuantity4.Text = "0.0";
            txttotalGoodQuantity5.Text = "0.0";
        }

        private void ComboBoxType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProductPayment1.Text = ComboBoxType1.Text;
        }

        private void ComboBoxType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProductPayment2.Text = ComboBoxType2.Text;
        }

        private void ComboBoxType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProductPayment3.Text = ComboBoxType3.Text;
        }

        private void ComboBoxType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProductPayment4.Text = ComboBoxType4.Text;
        }

        private void ComboBoxType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProductPayment5.Text = ComboBoxType5.Text;
        }

        private void btnApplyHarvestIndividual_Click(object sender, EventArgs e)
        {
            if (checkApplyButtonInput())
            {
                MessageBox.Show("Vérifier les values entrée");
                return;
            }
            addProductionDataToDatabase();
            harvestMS.RefreshQuantityProductionTable();
        }

        private bool checkApplyButtonInput()
        {
            return (txttotalGoodQuantity1.Text == "" ||
                txttotalGoodQuantity2.Text == "" ||
                txttotalGoodQuantity3.Text == "" ||
                txttotalGoodQuantity4.Text == "" ||
                txttotalGoodQuantity5.Text == "");
        }

        private void addProductionDataToDatabase()
        {
            bool added = false;
            for (int i= 1; i <6 ; i++)
            {
                setProductionValueFromFields(i);
                if (ProductionArray[i].TotalQuantity > 0)
                {
                    long productionId = mProductionDAO.addProductionAndGetId(ProductionArray[i]);
                    if (productionId > 0)
                    {
                        ProductionArray[i].ProductionID = productionId;
                        added = addHarvestQuantityToDatabase(i);
                        if (!added) break;
                    }
                }
            }
            if (added)
            {
                MessageBox.Show("Data Was Added");
            }
            else { MessageBox.Show("Data Not Added"); }
        }

        private void setProductionValueFromFields(int i)
        {
            ProductionArray[i].ProductionType = 3;
            ProductionArray[i].ProductionDate = HarvestDateTimePicker.Value;
            ProductionArray[i].Supplier.SupplierId = mSupplierDictionary.GetValueOrDefault(SupplierHarvestQuantityComboBox.GetItemText(SupplierHarvestQuantityComboBox.SelectedItem)).SupplierId;
            ProductionArray[i].Farm.FarmId = mFarmDictionary.GetValueOrDefault(FarmHarvestQuantityComboBox.GetItemText(FarmHarvestQuantityComboBox.SelectedItem)).FarmId;
            switch (i)
            {
                case 1:
                    ProductionArray[i].Product.ProductId = mProductDictionary.GetValueOrDefault(ComboBoxProduct1.GetItemText(ComboBoxProduct1.SelectedItem)).ProductId;
                    ProductionArray[i].ProductDetail.ProductDetailId = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType1.GetItemText(ComboBoxType1.SelectedItem)).ProductDetailId;
                    ProductionArray[i].TotalEmployee = getTotalEmployee(HarvestList[i]);
                    ProductionArray[i].TotalQuantity = Convert.ToDouble(txttotalGoodQuantity1.Text);
                    ProductionArray[i].TotalMinutes = 0.0;
                    ProductionArray[i].Price = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType1.GetItemText(ComboBoxType1.SelectedItem)).PriceCompany;
                    break;
                case 2:
                    ProductionArray[i].Product.ProductId = mProductDictionary.GetValueOrDefault(ComboBoxProduct2.GetItemText(ComboBoxProduct2.SelectedItem)).ProductId;
                    ProductionArray[i].ProductDetail.ProductDetailId = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType2.GetItemText(ComboBoxType2.SelectedItem)).ProductDetailId;
                    ProductionArray[i].TotalEmployee = getTotalEmployee(HarvestList[i]);
                    ProductionArray[i].TotalQuantity = Convert.ToDouble(txttotalGoodQuantity2.Text);
                    ProductionArray[i].TotalMinutes = 0.0;
                    ProductionArray[i].Price = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType2.GetItemText(ComboBoxType2.SelectedItem)).PriceCompany;
                    break;
                case 3:
                    ProductionArray[i].Product.ProductId = mProductDictionary.GetValueOrDefault(ComboBoxProduct3.GetItemText(ComboBoxProduct3.SelectedItem)).ProductId;
                    ProductionArray[i].ProductDetail.ProductDetailId = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType3.GetItemText(ComboBoxType3.SelectedItem)).ProductDetailId;
                    ProductionArray[i].TotalEmployee = getTotalEmployee(HarvestList[i]);
                    ProductionArray[i].TotalQuantity = Convert.ToDouble(txttotalGoodQuantity3.Text);
                    ProductionArray[i].TotalMinutes = 0.0;
                    ProductionArray[i].Price = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType3.GetItemText(ComboBoxType3.SelectedItem)).PriceCompany;
                    break;
                case 4:
                    ProductionArray[i].Product.ProductId = mProductDictionary.GetValueOrDefault(ComboBoxProduct4.GetItemText(ComboBoxProduct4.SelectedItem)).ProductId;
                    ProductionArray[i].ProductDetail.ProductDetailId = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType4.GetItemText(ComboBoxType4.SelectedItem)).ProductDetailId;
                    ProductionArray[i].TotalEmployee = getTotalEmployee(HarvestList[i]);
                    ProductionArray[i].TotalQuantity = Convert.ToDouble(txttotalGoodQuantity4.Text);
                    ProductionArray[i].TotalMinutes = 0.0;
                    ProductionArray[i].Price = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType4.GetItemText(ComboBoxType4.SelectedItem)).PriceCompany;
                    break;
                case 5:
                    ProductionArray[i].Product.ProductId = mProductDictionary.GetValueOrDefault(ComboBoxProduct5.GetItemText(ComboBoxProduct5.SelectedItem)).ProductId;
                    ProductionArray[i].ProductDetail.ProductDetailId = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType5.GetItemText(ComboBoxType5.SelectedItem)).ProductDetailId;
                    ProductionArray[i].TotalEmployee = getTotalEmployee(HarvestList[i]);
                    ProductionArray[i].TotalQuantity = Convert.ToDouble(txttotalGoodQuantity5.Text);
                    ProductionArray[i].TotalMinutes = 0.0;
                    ProductionArray[i].Price = mProductDetailDictionary[i].GetValueOrDefault(ComboBoxType5.GetItemText(ComboBoxType5.SelectedItem)).PriceCompany;
                    break;
            }
              
        }

        private int getTotalEmployee(List<HarvestQuantity> listItem)
        {
            int sum = 0;
            foreach (HarvestQuantity item in listItem)
            {
                if (item.GoodQuantity > 0) sum++;
            }
            return sum;
        }

        private bool addHarvestQuantityToDatabase(int i)
        {
            bool trackInsert = false;
            if (ProductionArray[i].ProductionID > 0)
            {
                foreach (HarvestQuantity item in HarvestList[i])
                {
                    if (item.GoodQuantity > 0)
                    {
                        item.Production.ProductionID = ProductionArray[i].ProductionID;
                        item.HarvestDate = ProductionArray[i].ProductionDate;
                        item.Production.Farm.FarmId = ProductionArray[i].Farm.FarmId;
                        trackInsert = mHarvestQuantityDAO.addHarvestQuantity(item);
                    }
                    if (!trackInsert) break;
                }
            }
            return trackInsert;
        }
    }
}
