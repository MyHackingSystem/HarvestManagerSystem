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
        private bool isEditSupplier = false;
        private bool isEditSupply = false;
        private Supplier mSupplier = new Supplier();
        private Supply mSupply = new Supply();
        private SupplierDAO supplierDAO = SupplierDAO.getInstance();
        private SupplyDAO supplyDAO = SupplyDAO.getInstance();
        private FarmDAO farmDAO = FarmDAO.getInstance();
        private ProductDAO productDAO = ProductDAO.getInstance();

        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private Dictionary<string, Product> mProductDictionary = new Dictionary<string, Product>();

        private HarvestMS harvestMS;
        private static FormAddSupplier instance;

        private FormAddSupplier(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            //wipeFields();
            instance = null;
        }


        public static FormAddSupplier getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddSupplier(harvestMS);
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
                instance = new FormAddSupplier(harvestMS);

            }
            instance.Show();
        }


        private void FormAddSupplier_Load(object sender, EventArgs e)
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            if (isEditSupplier)
            {
                SupplierNameComboBox.SelectedIndex = SupplierNameComboBox.FindStringExact(mSupplier.SupplierName);
                SupplierFirstNameTextBox.Text = mSupplier.SupplierFirstName;
                SupplierLastNameTextBox.Text = mSupplier.SupplierLastName;
            }
            else if (isEditSupply)
            {
                SupplierNameComboBox.SelectedIndex = SupplierNameComboBox.FindStringExact(mSupplier.SupplierName);
                SupplierFirstNameTextBox.Text = mSupplier.SupplierFirstName;
                SupplierLastNameTextBox.Text = mSupplier.SupplierLastName;
                FarmSupplierComboBox.SelectedIndex = FarmSupplierComboBox.FindStringExact(mSupply.Farm.FarmName);
                ProductSupplierComboBox.SelectedIndex = ProductSupplierComboBox.FindStringExact(mSupply.Product.ProductName);
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

        internal void InflateUI(Supplier supplier)
        {
            isEditSupplier = true;
            SupplierNameComboBox.SelectedIndex = -1;
            mSupplier.SupplierId = supplier.SupplierId;

            SupplierNameComboBox.SelectedIndex = SupplierNameComboBox.FindStringExact(supplier.SupplierName);
            SupplierFirstNameTextBox.Text = supplier.SupplierFirstName;
            SupplierLastNameTextBox.Text = supplier.SupplierLastName;
            FarmSupplierComboBox.Enabled = false;
            ProductSupplierComboBox.Enabled = false;

            handleSaveButton.Text = "Update";
        }

        internal void InflateUI(Supply supply, Supplier supplier)
        {
            isEditSupply = true;
            mSupply.SupplyId = supply.SupplyId;
            mSupply.Supplier.SupplierId = supplier.SupplierId;
            mSupply.Supplier.SupplierName = supplier.SupplierName;
            mSupply.Farm.FarmId = supply.Farm.FarmId;
            mSupply.Farm.FarmName = supply.Farm.FarmName;
            mSupply.Product.ProductId = supply.Product.ProductId;
            mSupply.Product.ProductName = supply.Product.ProductName;

            //SupplierNameComboBox.SelectedIndex = SupplierNameComboBox.FindStringExact(supplier.SupplierName);
            //SupplierFirstNameTextBox.Text = supplier.SupplierFirstName;
            //SupplierLastNameTextBox.Text = supplier.SupplierLastName;

            SupplierNameComboBox.Enabled = false;
            SupplierFirstNameTextBox.Enabled = false;
            SupplierLastNameTextBox.Enabled = false;

            //FarmSupplierComboBox.SelectedIndex = FarmSupplierComboBox.FindStringExact(supply.Farm.FarmName);
            //ProductSupplierComboBox.SelectedIndex = ProductSupplierComboBox.FindStringExact(supply.Product.ProductName);


            handleSaveButton.Text = "Update";
        }


        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (isEditSupply)
            {
                UpdateSupply(mSupply);
            }
            else if (isEditSupplier)
            {
                UpdateSupplier(mSupplier);
            }
            else
            {
                if (CheckInput())
                {
                    MessageBox.Show("Vérifier les valeurs");
                    return;
                }
                SaveSupplierData();
            }
            harvestMS.DisplayFarmData();
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

        private void UpdateSupply(Supply supply)
        {
            supply.Supplier.SupplierId = mSupplierDictionary.GetValueOrDefault(SupplierNameComboBox.GetItemText(SupplierNameComboBox.SelectedItem)).SupplierId;
            supply.Farm.FarmId = mFarmDictionary.GetValueOrDefault(FarmSupplierComboBox.GetItemText(FarmSupplierComboBox.SelectedItem)).FarmId;
            supply.Product.ProductId = mProductDictionary.GetValueOrDefault(ProductSupplierComboBox.GetItemText(ProductSupplierComboBox.SelectedItem)).ProductId;

            bool isAdded = supplyDAO.UpdateData(supply);

            if (isAdded)
            {
                wipeFields();
                MessageBox.Show("data updated");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not updated");
                this.Close();
            }
        }

        private void UpdateSupplier(Supplier supplier)
        {
            supplier.SupplierName = SupplierNameComboBox.Text;
            supplier.SupplierFirstName = SupplierFirstNameTextBox.Text;
            supplier.SupplierLastName = SupplierLastNameTextBox.Text;

            bool isAdded = supplierDAO.UpdateData(supplier);
            if (isAdded)
            {
                wipeFields();
                MessageBox.Show("data updated");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not updated");
                this.Close();
            }
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
                supply.Supplier.SupplierName = SupplierNameComboBox.Text;
                supply.Supplier.SupplierFirstName = SupplierFirstNameTextBox.Text;
                supply.Supplier.SupplierLastName = SupplierLastNameTextBox.Text;
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

            ProductNameList();
            wipeFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            wipeFields();
        }

        private void wipeFields()
        {
            SupplierNameComboBox.SelectedIndex = -1;
            SupplierFirstNameTextBox.Text = "";
            SupplierLastNameTextBox.Text = "";
            FarmSupplierComboBox.SelectedIndex = -1;
            ProductSupplierComboBox.SelectedIndex = -1;
        }

    }
}
