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
        private bool editProduct = false;
        private bool editProductDetail = false;
        private Product mProduct = new Product();
        private ProductDetail mProductDetail = new ProductDetail();
        private List<Product> listProduct = new List<Product>();
        private List<ProductDetail> listProductDetail = new List<ProductDetail>();

        private HarvestMS harvestMS;

        public FormAddProduct(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearFields();
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            ProductNameList();
            ProductNameComboBox.SelectedIndex = -1;
            DisplayProductData();
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
            if (editProduct)
            {
                EditProduct();
            }
            else if (editProductDetail)
            {
                EditProductDetail();
            }
            else
            {
                AddProduct();
            }
        }

        private void EditProduct()
        {
            if(ProductNameComboBox.Text == "")
            {
                MessageBox.Show("Product name required");
                return;
            }
            try
            {
                mProduct.ProductName = ProductNameComboBox.Text.Trim();
                mProductDAO.Update(mProduct);
                MessageBox.Show("Product Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Brand Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            ProductNameList();
            ProductNameComboBox.SelectedIndex = -1;
            DisplayProductData();
            ResetFields();
        }

        private void EditProductDetail()
        {

        }

        private void AddProduct()
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
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
                ClearFields();
            }
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

        private void btnClearReset_Click(object sender, EventArgs e)
        {
            if (editProduct || editProductDetail)
            {
                ResetFields();
            }
            else
            {
                ClearFields();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (editProduct)
            {
                DeleteProduct();
            }
            else if (editProductDetail)
            {

            }

        }

        private void DeleteProduct()
        {
            if (ProductNameComboBox.Text == "")
            {
                MessageBox.Show("Select Product required");
                return;
            }
            try
            {
                mProductDAO.Delete(mProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DisplayProductData();
            ProductNameList();
            ProductNameComboBox.SelectedIndex = -1;
            ResetFields();
        }

        private void ResetFields()
        {
            ProductType.Enabled = true;
            ProductPriceEmployee.Enabled = true;
            ProductPriceCompany.Enabled = true;
            btnSaveProductData.Text = "Ajouter";
            btnClearReset.Text = "Vider";
            btnDeleteProduct.Visible = false;
            editProduct = false;
            ClearFields();
        }
    private void ClearFields()
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


        private void ProductDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mProduct = listProduct[e.RowIndex];
                ProductNameComboBox.Text = mProduct.ProductName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EditMode(true, false);
        }


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

        private void ProductDetailDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mProductDetail = listProductDetail[e.RowIndex];
                int i = ProductDataGridView.CurrentCell.RowIndex;
                if (i < listProduct.Count && i != -1)
                {
                    mProduct = listProduct[i];
                }
                ProductNameComboBox.Text = mProduct.ProductName;
                ProductType.Text = mProductDetail.ProductType;
                ProductPriceEmployee.Text = mProductDetail.PriceEmployee.ToString();
                ProductPriceCompany.Text = mProductDetail.PriceCompany.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EditMode(false, true);
        }

        private void EditMode(bool p, bool d)
        {
            editProduct = p;
            editProductDetail = d;
            ProductNameComboBox.Enabled = editProduct;
            ProductType.Enabled = editProductDetail;
            ProductPriceEmployee.Enabled = editProductDetail;
            ProductPriceCompany.Enabled = editProductDetail;
            ShowEditMode();
        }

        private void ShowEditMode()
        {
            btnSaveProductData.Text = "Update";
            btnClearReset.Text = "Reset";
            btnDeleteProduct.Visible = true;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
