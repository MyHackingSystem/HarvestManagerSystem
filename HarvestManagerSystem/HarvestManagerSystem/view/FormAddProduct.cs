using System;
using System.Collections.Generic;
using System.Globalization;
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
            DisplayProductData();
        }

        #region ********************************************* Add Product *****************************************************

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
            DisplayProductData();
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

            double priceEmp;
            double priceCom;
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");

            if (Double.TryParse(ProductPriceEmployee.Text, NumberStyles.AllowDecimalPoint,
                        provider, out priceEmp))
            {
                productDetail.PriceEmployee = priceEmp;
            }
            if (Double.TryParse(ProductPriceCompany.Text, NumberStyles.AllowDecimalPoint,
                        provider, out priceCom))
            {
                productDetail.PriceCompany = priceCom;
            }

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

        #endregion

        #region ********************************************* PRODUCT CODE **************************************************************************

        List<Product> listProduct = new List<Product>();

        public void DisplayProductData()
        {
            try
            {
                listProduct.Clear();
                listProduct = mProductDAO.getData();
                ProductDataGridView.DataSource = listProduct;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = ProductDataGridView.CurrentCell.RowIndex;
            if (i < listProduct.Count && i != -1)
            {
                DisplayProductDetailData(listProduct[i]);
            }
        }

        private void ProductDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Product product = (Product)listProduct[e.RowIndex];
            if (product == null)
            {
                return;
            }
            if (mProductDAO.UpdateData(product))
            {
                MessageBox.Show("les valeurs mises à jour.");
            }
        }

        #endregion

        #region ********************************************* PRODUCT DETAIL CODE *******************************************************************

        List<ProductDetail> listProductDetail = new List<ProductDetail>();

        private void DisplayProductDetailData(Product product)
        {
            try
            {
                listProductDetail.Clear();
                listProductDetail = mProductDetailDAO.getData(product);
                ProductDetailDataGridView.DataSource = listProductDetail;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ProductDetailDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ProductDetail item = (ProductDetail)listProductDetail[e.RowIndex];
            if (item == null)
            {
                return;
            }
            if (mProductDetailDAO.UpdateData(item))
            {
                MessageBox.Show("les valeurs mises à jour.");
            }
        }

        #endregion

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
