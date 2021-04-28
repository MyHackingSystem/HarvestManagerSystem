using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.view
{
    public partial class FormAddProduct : Form
    {

        private ProductDAO mProductDAO = ProductDAO.getInstance();
        private ProductDetailDAO mProductDetailDAO = ProductDetailDAO.getInstance();
        private Dictionary<string, Product> mProductDictionary = new Dictionary<string, Product>();

        private HarvestMS harvestMS;

        public FormAddProduct(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            ProductNameList();
            ProductNameComboBox.SelectedIndex = -1;
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
            if(NamesList != null)
            {
                ProductNameComboBox.DataSource = NamesList;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            SaveProductData();
            harvestMS.DisplayProductData();
        }

        private bool CheckInput()
        {
            nameProductErrorLabel.Visible = ProductNameComboBox.SelectedIndex == -1 && ProductNameComboBox.Text == "";
            codeProductErrorLabel.Visible = (ProductType.Text == "") ? true : false;
            prixEmployeeErrorlabel.Visible = (ProductPriceEmployee.Text == "") ? true : false;
            prixCompanyErrorlabel.Visible = (ProductPriceCompany.Text == "") ? true : false;
            return nameProductErrorLabel.Visible || codeProductErrorLabel.Visible || prixEmployeeErrorlabel.Visible || prixCompanyErrorlabel.Visible;
        }


        private void SaveProductData()
        {
            Product product;
            if (!mProductDictionary.TryGetValue(ProductNameComboBox.Text, out product))
            {
                Console.WriteLine("Pas de valeur de sélection");
            }

            ProductDetail productDetail = new ProductDetail();
            productDetail.ProductType = ProductType.Text;
            productDetail.PriceEmployee  = Convert.ToDouble(ProductPriceEmployee.Text);
            productDetail.PriceCompany = Convert.ToDouble(ProductPriceCompany.Text);
            bool added = false;
            if (product != null)
            {
                productDetail.Product.ProductId = product.ProductId;
                productDetail.Product.ProductName = product.ProductName;
                added = mProductDetailDAO.addData(productDetail);
            }
            else
            {
                productDetail.Product.ProductName = ProductNameComboBox.Text;
                added = mProductDetailDAO.addNewProductDetail(productDetail);
            }
            if (added)
            {
                MessageBox.Show("Produit ajouté à la base de données");
                ProductNameList();
                wipeFields();
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            wipeFields();
        }
        private void wipeFields()
        {
            ProductNameComboBox.SelectedIndex = -1;
            ProductNameComboBox.Text = "";
            ProductType.Text = "";
            ProductPriceEmployee.Text = "";
            ProductPriceCompany.Text = "";
        }

        private void ValidateNumberEntred(object sender, KeyPressEventArgs e)
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
