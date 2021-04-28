using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;
using HarvestManagerSystem;

namespace HarvestManagerSystem.view
{
    public partial class FormAddProduct : Form
    {
        private bool isEditProduct = false;
        private bool isEditDetail = false;
        private Product mProduct = new Product();
        private ProductDetail mProductDetail = new ProductDetail();
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
            if (isEditProduct)
            {
                ProductNameComboBox.SelectedIndex = ProductNameComboBox.FindStringExact(mProduct.ProductName);
            }else if (isEditDetail)
            {
                ProductNameComboBox.SelectedIndex = ProductNameComboBox.FindStringExact(mProduct.ProductName);
            }
            else
            {
                ProductNameComboBox.SelectedIndex = -1;
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
            if(NamesList != null)
            {
                ProductNameComboBox.DataSource = NamesList;
            }
        }

        internal void InflateUI(Product product)
        {
            isEditProduct = true;
            ProductNameComboBox.SelectedIndex = -1;
            ProductNameComboBox.SelectedIndex = ProductNameComboBox.FindStringExact(product.ProductName);
            mProduct.ProductId = product.ProductId;
            mProduct.ProductName = product.ProductName;
            ProductType.Enabled = false;
            ProductPriceEmployee.Enabled = false;
            ProductPriceCompany.Enabled = false;
            handleSaveButton.Text = "Update";
        }

        internal void InflateUI(ProductDetail productDetail, Product product)
        {
            isEditDetail = true;
            ProductNameComboBox.Enabled = false;
            mProductDetail.ProductDetailId = productDetail.ProductDetailId;
            mProductDetail.ProductType = productDetail.ProductType;
            mProduct.ProductId = product.ProductId;
            mProduct.ProductName = product.ProductName;

            ProductPriceEmployee.Text = Convert.ToString(productDetail.PriceEmployee);
            ProductPriceCompany.Text = Convert.ToString(productDetail.PriceCompany);
            handleSaveButton.Text = "Update";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isEditDetail)
            {
                UpdateProductDetail(mProductDetail);
            }
            else if (isEditProduct)
            {
                UpdateProduct(mProduct);
            }
            else
            {
                if (CheckInput() || !validateData())
                {
                    MessageBox.Show("Vérifier les valeurs");
                    return;
                }
                SaveProductData();
            }
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

        private void UpdateProductDetail(ProductDetail productDetail)
        {
            productDetail.ProductType = ProductType.Text;
            productDetail.PriceEmployee = Convert.ToDouble(ProductPriceEmployee.Text);
            productDetail.PriceCompany = Convert.ToDouble(ProductPriceCompany.Text);
            bool isAdded = mProductDetailDAO.UpdateData(productDetail);

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

        private void UpdateProduct(Product product)
        {
            product.ProductName = ProductNameComboBox.Text;

            bool isAdded = mProductDAO.UpdateData(product);
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

        private void SaveProductData()
        {
            Product product;
            if (!mProductDictionary.TryGetValue(ProductNameComboBox.Text, out product))
            {
                Console.WriteLine("no select value");
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
                wipeFields();
            }
            else
            {
                MessageBox.Show("Not added to database: ");
            }
           
            ProductNameList();
            wipeFields();
        }

        private bool validateData()
        {
            Regex regex = new Regex(@"^[0-9]+\.?[0-9]*$");
            return regex.Match(ProductPriceEmployee.Text).Success && regex.Match(ProductPriceCompany.Text).Success;
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
            ProductNameComboBox.SelectedIndex = -1;
            ProductType.Text = "";
            ProductPriceEmployee.Text = "";
            ProductPriceCompany.Text = "";
        }


    }
}
