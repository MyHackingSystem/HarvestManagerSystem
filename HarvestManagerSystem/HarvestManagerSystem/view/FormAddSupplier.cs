using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;

namespace HarvestManagerSystem.view
{
    public partial class FormAddSupplier : Form
    {
        private SupplierDAO supplierDAO = SupplierDAO.getInstance();
        private SupplyDAO supplyDAO = SupplyDAO.getInstance();
        private FarmDAO farmDAO = FarmDAO.getInstance();
        private ProductDAO productDAO = ProductDAO.getInstance();

        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private Dictionary<string, Product> mProductDictionary = new Dictionary<string, Product>();

        private HarvestMS harvestMS;

        public FormAddSupplier(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
        }


        private void FormAddSupplier_Load(object sender, EventArgs e)
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            wipeFields();
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
                SupplierNameComboBox.DataSource = NamesList;
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
                FarmSupplierComboBox.DataSource = NamesList;
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
                ProductSupplierComboBox.DataSource = NamesList; 
            }
        }

        private void SupplierNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier supplier = mSupplierDictionary.GetValueOrDefault(SupplierNameComboBox.GetItemText(SupplierNameComboBox.SelectedItem));
            if (supplier != null)
            {
                SupplierFirstNameTextBox.Text = supplier.SupplierFirstName;
                SupplierLastNameTextBox.Text = supplier.SupplierLastName;
            }

        }

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            SaveSupplierData();
            harvestMS.DisplaySupplierData();
        }

        private bool CheckInput()
        {
            nameSupplierErrorLabel.Visible = SupplierNameComboBox.SelectedIndex == -1 && SupplierNameComboBox.Text == "";
            supplierFirstNameErrorLabel.Visible = (SupplierFirstNameTextBox.Text == "") ? true : false;
            supplierLastNameErrorLabel.Visible = (SupplierLastNameTextBox.Text == "") ? true : false;
            farmSupplierErrorLabel.Visible = FarmSupplierComboBox.SelectedIndex == -1 && FarmSupplierComboBox.Text == "";
            productSupplierErrorLabel.Visible = ProductSupplierComboBox.SelectedIndex == -1 && ProductSupplierComboBox.Text == ""; ;
            return nameSupplierErrorLabel.Visible || supplierFirstNameErrorLabel.Visible || supplierLastNameErrorLabel.Visible || farmSupplierErrorLabel.Visible || productSupplierErrorLabel.Visible;
        }

        private void SaveSupplierData()
        {
            Supplier supplier;
            if (!mSupplierDictionary.TryGetValue(SupplierNameComboBox.Text, out supplier))
            {
                Console.WriteLine("no select value");
            }

            Supply supply = new Supply();
            supply.Farm.FarmId = mFarmDictionary.GetValueOrDefault(FarmSupplierComboBox.GetItemText(FarmSupplierComboBox.SelectedItem)).FarmId;
            supply.Product.ProductId = mProductDictionary.GetValueOrDefault(ProductSupplierComboBox.GetItemText(ProductSupplierComboBox.SelectedItem)).ProductId;

            bool added = false;
            if (supplier != null)
            {
                supply.Supplier.SupplierId = supplier.SupplierId;
                added = supplyDAO.addData(supply);
            }
            else
            {
                supply.Supplier.SupplierName = SupplierNameComboBox.Text.Trim().ToUpper();
                supply.Supplier.SupplierFirstName = SupplierFirstNameTextBox.Text.Trim().ToUpper();
                supply.Supplier.SupplierLastName = SupplierLastNameTextBox.Text.Trim().ToUpper();
                added = supplyDAO.addNewSupplierData(supply);

            }
            if (added)
            {
                wipeFields();
            }
            else
            {
                MessageBox.Show("Not added to database: ");
            }

            SupplierNameList();
            FarmNameList();
            ProductNameList();
            wipeFields();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            wipeFields();
        }

        private void wipeFields()
        {
            SupplierNameComboBox.SelectedIndex = -1;
            SupplierNameComboBox.Text = "";
            SupplierFirstNameTextBox.Text = "";
            SupplierLastNameTextBox.Text = "";
            FarmSupplierComboBox.SelectedIndex = -1;
            FarmSupplierComboBox.Text = "";
            ProductSupplierComboBox.SelectedIndex = -1;
            ProductSupplierComboBox.Text = "";
        }

    }
}
