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
        private SupplierDAO mSupplierDAO = SupplierDAO.getInstance();
        private SupplyDAO mSupplyDAO = SupplyDAO.getInstance();
        private FarmDAO mFarmDAO = FarmDAO.getInstance();
        private ProductDAO mProductDAO = ProductDAO.getInstance();
        List<Supplier> listSupplier = new List<Supplier>();
        List<Supply> listSupply = new List<Supply>();
        private bool editSupplier = false;
        private bool editSupply = false;
        private Supplier mSupplier = new Supplier();
        private Supply mSupply = new Supply();
        private Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private Dictionary<string, Product> mProductDictionary = new Dictionary<string, Product>();


        public FormAddSupplier()
        {
            InitializeComponent();
        }

        private void FormAddSupplier_Load(object sender, EventArgs e)
        {
            initUI();
            ClearFields();
        }

        private void initUI()
        {
            SupplierNameList();
            FarmNameList();
            ProductNameList();
            DisplaySupplierData();
        }

        private void SupplierNameList()
        {
            List<string> NamesList = new List<string>();
            mSupplierDictionary.Clear();
            try
            {
                mSupplierDictionary = mSupplierDAO.SupplierDictionary(); 
                NamesList.AddRange(mSupplierDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cmbxSupplierName.DataSource = NamesList;
            }
        }

        private void FarmNameList()
        {
            List<string> NamesList = new List<string>();
            mFarmDictionary.Clear();
            try
            {
                mFarmDictionary = mFarmDAO.FarmDictionary();
                NamesList.AddRange(mFarmDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cmbxFarmSupplier.DataSource = NamesList;
            }
        }

        private void ProductNameList()
        {
            List<string> NamesList = new List<string>();
            mProductDictionary.Clear();
            try
            {
                mProductDictionary = mProductDAO.ProductDictionary();
                NamesList.AddRange(mProductDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cmbxProductSupplier.DataSource = NamesList; 
            }
        }

        public void DisplaySupplierData()
        {
            try
            {
                listSupplier = mSupplierDAO.ListSupplier();
                SupplierDataGridView.DataSource = listSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SupplierDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = SupplierDataGridView.CurrentCell.RowIndex;
            if (i < listSupplier.Count)
            {
                DisplaySupplyData(listSupplier[i]);
            }
        }

        private void DisplaySupplyData(Supplier supplier)
        {
            try
            {
                listSupply = mSupplyDAO.ListSupply(supplier);
                SupplyDataGridView.DataSource = listSupply;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SupplierNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier supplier = mSupplierDictionary.GetValueOrDefault(cmbxSupplierName.GetItemText(cmbxSupplierName.SelectedItem));
            if (supplier != null)
            {
                txtSupplierFirstName.Text = supplier.SupplierFirstName;
                txtSupplierLastName.Text = supplier.SupplierLastName;
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (editSupplier) { EditSupplier(); }
            else if (editSupply) { EditSupply(); }
            else { AddSupplier(); }
            initUI();
            ResetFields();
        }

        private void EditSupplier()
        {
            if (cmbxSupplierName.Text == "" || mSupplier.SupplierId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try
            {
                mSupplier.SupplierName = cmbxSupplierName.Text.Trim().ToUpper();
                mSupplier.SupplierFirstName = txtSupplierFirstName.Text.Trim().ToUpper();
                mSupplier.SupplierLastName = txtSupplierLastName.Text.Trim().ToUpper();
                mSupplierDAO.Update(mSupplier);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("les informations sont mises à jour.", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void EditSupply()
        {
            if (mSupply.SupplyId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try
            {
                mSupply.Farm.FarmId = mFarmDictionary.GetValueOrDefault(cmbxFarmSupplier.GetItemText(cmbxFarmSupplier.SelectedItem)).FarmId;
                mSupply.Product.ProductId = mProductDictionary.GetValueOrDefault(cmbxProductSupplier.GetItemText(cmbxProductSupplier.SelectedItem)).ProductId;
                mSupplyDAO.Update(mSupply);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Detail Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("les informations sont mises à jour.", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void AddSupplier()
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }

            Supplier supplier;
            Supply supply = new Supply();
            supply.Farm.FarmId = mFarmDictionary.GetValueOrDefault(cmbxFarmSupplier.GetItemText(cmbxFarmSupplier.SelectedItem)).FarmId;
            supply.Product.ProductId = mProductDictionary.GetValueOrDefault(cmbxProductSupplier.GetItemText(cmbxProductSupplier.SelectedItem)).ProductId;

            try
            {
                if (mSupplierDictionary.TryGetValue(cmbxSupplierName.Text, out supplier))
                {
                    supply.Supplier.SupplierId = supplier.SupplierId;
                    mSupplyDAO.Add(supply);
                }
                else
                {
                    supply.Supplier.SupplierName = cmbxSupplierName.Text.Trim().ToUpper();
                    supply.Supplier.SupplierFirstName = txtSupplierFirstName.Text.Trim().ToUpper();
                    supply.Supplier.SupplierLastName = txtSupplierLastName.Text.Trim().ToUpper();
                    mSupplierDAO.addNewSupplier(supply);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Not Added: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("Les information été ajouté à la base de données");
        }

        private bool CheckInput()
        {
            nameSupplierErrorLabel.Visible = cmbxSupplierName.SelectedIndex == -1 && cmbxSupplierName.Text == "";
            supplierFirstNameErrorLabel.Visible = (txtSupplierFirstName.Text == "") ? true : false;
            supplierLastNameErrorLabel.Visible = (txtSupplierLastName.Text == "") ? true : false;
            farmSupplierErrorLabel.Visible = cmbxFarmSupplier.SelectedIndex == -1 && cmbxFarmSupplier.Text == "";
            productSupplierErrorLabel.Visible = cmbxProductSupplier.SelectedIndex == -1 && cmbxProductSupplier.Text == ""; ;
            return nameSupplierErrorLabel.Visible || supplierFirstNameErrorLabel.Visible || supplierLastNameErrorLabel.Visible || farmSupplierErrorLabel.Visible || productSupplierErrorLabel.Visible;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ces données", "Supprimer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                if (editSupplier) { DeleteSupplier(); }
                else if (editSupply) { DeleteSupply(); }
                initUI();
                ResetFields();
            }
        }

        private void DeleteSupplier()
        {
            if (cmbxSupplierName.Text == "" || mSupplier.SupplierId <= 0)
            {
                MessageBox.Show("Select Farm required");
                return;
            }
            try { mSupplierDAO.Delete(mSupplier); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteSupply()
        {
            if (mSupply.SupplyId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try { mSupplyDAO.Delete(mSupply); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(editSupplier || editSupply) {ResetFields();} else {ClearFields();}
        }

        private void ResetFields()
        {
            cmbxSupplierName.Enabled = true;
            txtSupplierFirstName.Enabled = true;
            txtSupplierLastName.Enabled = true;
            cmbxFarmSupplier.Enabled = true;
            cmbxProductSupplier.Enabled = true;
            btnSave.Text = "Ajouter";
            btnClearReset.Text = "Vider";
            btnDelete.Visible = false;
            editSupplier = false;
            editSupply = false;
            ClearFields();
        }

        private void ClearFields()
        {
            cmbxSupplierName.SelectedIndex = -1;
            cmbxSupplierName.Text = "";
            txtSupplierFirstName.Text = "";
            txtSupplierLastName.Text = "";
            cmbxFarmSupplier.SelectedIndex = -1;
            cmbxFarmSupplier.Text = "";
            cmbxProductSupplier.SelectedIndex = -1;
            cmbxProductSupplier.Text = "";
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SupplierDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mSupplier = listSupplier[e.RowIndex];
                cmbxSupplierName.Text = mSupplier.SupplierName;
                txtSupplierFirstName.Text = mSupplier.SupplierFirstName;
                txtSupplierLastName.Text = mSupplier.SupplierLastName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EditMode(true, false);
        }

        private void SupplyDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mSupply = listSupply[e.RowIndex];
                int i = SupplierDataGridView.CurrentCell.RowIndex;
                if (i < listSupplier.Count && i != -1)
                {
                    mSupplier = listSupplier[i];
                }
                cmbxSupplierName.Text = mSupplier.SupplierName;
                txtSupplierFirstName.Text = mSupplier.SupplierFirstName;
                txtSupplierLastName.Text = mSupplier.SupplierLastName;
                cmbxFarmSupplier.Text = mSupply.Farm.FarmName;
                cmbxProductSupplier.Text = mSupply.Product.ProductName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EditMode(false, true);
        }

        private void EditMode(bool f, bool s)
        {
            editSupplier = f;
            editSupply = s;
            cmbxSupplierName.Enabled = editSupplier;
            txtSupplierFirstName.Enabled = editSupplier;
            txtSupplierLastName.Enabled = editSupplier;
            cmbxFarmSupplier.Enabled = editSupply;
            cmbxProductSupplier.Enabled = editSupply;
            ShowEditMode();
        }

        private void ShowEditMode()
        {
            btnSave.Text = "Update";
            btnClearReset.Text = "Reset";
            btnDelete.Visible = true;
        }

    }
}
