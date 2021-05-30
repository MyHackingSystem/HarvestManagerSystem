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

        public FormAddProduct()
        {
            InitializeComponent();
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            ProductNameList();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error create names List: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            if(NamesList != null)
            {
                cmbxProductName.DataSource = NamesList;
                cmbxProductName.SelectedIndex = -1;
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
            if(cmbxProductName.Text == "")
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try
            {
                mProduct.ProductName = cmbxProductName.Text.Trim();
                mProductDAO.Update(mProduct);
                MessageBox.Show("Product Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            ProductNameList();
            DisplayProductData();
            ResetFields();
        }

        private void EditProductDetail()
        {
            if (txtProductType.Text == "" || txtProductPriceEmployee.Text == "" || txtProductPriceCompany.Text == "")
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try
            {
                mProductDetail.ProductType = txtProductType.Text.Trim();
                double priceEmp; double priceCom;
                IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");

                if (Double.TryParse(txtProductPriceEmployee.Text, NumberStyles.AllowDecimalPoint,
                            provider, out priceEmp))
                {
                    mProductDetail.PriceEmployee = priceEmp;
                }
                if (Double.TryParse(txtProductPriceCompany.Text, NumberStyles.AllowDecimalPoint,
                            provider, out priceCom))
                {
                    mProductDetail.PriceCompany = priceCom;
                }
                mProductDetail.Product.ProductId = mProduct.ProductId;
                mProductDetail.Product.ProductName = mProduct.ProductName;
                mProductDetailDAO.Update(mProductDetail);
                MessageBox.Show("Product detail Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Detail Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            ProductNameList();
            DisplayProductData();
            ResetFields();
        }

        private void AddProduct()
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            Product product;
            ProductDetail productDetail = new ProductDetail();
            productDetail.ProductType = txtProductType.Text.Trim();
            double priceEmp; double priceCom;
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");

            if (Double.TryParse(txtProductPriceEmployee.Text, NumberStyles.AllowDecimalPoint, provider, out priceEmp))
            {
                productDetail.PriceEmployee = priceEmp;
            }
            if (Double.TryParse(txtProductPriceCompany.Text, NumberStyles.AllowDecimalPoint, provider, out priceCom))
            {
                productDetail.PriceCompany = priceCom;
            }

            try
            {
                if (mProductDictionary.TryGetValue(cmbxProductName.Text, out product))
                {
                    productDetail.Product.ProductId = product.ProductId;
                    productDetail.Product.ProductName = product.ProductName;
                    mProductDetailDAO.add(productDetail);
                }
                else
                {
                    productDetail.Product.ProductName = cmbxProductName.Text.Trim();
                    mProductDetailDAO.addNewProduct(productDetail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Not Added: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("Produit ajouté à la base de données");
            ProductNameList();
            ClearFields();
            DisplayProductData();
        }

        private bool CheckInput()
        {
            nameProductErrorLabel.Visible = cmbxProductName.SelectedIndex == -1 && cmbxProductName.Text == "";
            codeProductErrorLabel.Visible = (txtProductType.Text == "") ? true : false;
            prixEmployeeErrorlabel.Visible = (txtProductPriceEmployee.Text == "") ? true : false;
            prixCompanyErrorlabel.Visible = (txtProductPriceCompany.Text == "") ? true : false;
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
                DeleteProductDetail();
            }
        }

        private void DeleteProduct()
        {
            if (cmbxProductName.Text == "" || mProduct.ProductId <= 0)
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
            ResetFields();
        }

        private void DeleteProductDetail()
        {
            if (txtProductType.Text == "" || txtProductPriceEmployee.Text == "" || txtProductPriceCompany.Text == "" || mProductDetail.ProductDetailId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try
            {
                mProductDetailDAO.Delete(mProductDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DisplayProductData();
            ProductNameList();
            ResetFields();
        }

        private void ResetFields()
        {
            txtProductType.Enabled = true;
            txtProductPriceEmployee.Enabled = true;
            txtProductPriceCompany.Enabled = true;
            btnSaveProductData.Text = "Ajouter";
            btnClearReset.Text = "Vider";
            btnDeleteProduct.Visible = false;
            editProduct = false;
            ClearFields();
        }

        private void ClearFields()
        {
            cmbxProductName.SelectedIndex = -1;
            cmbxProductName.Text = "";
            txtProductType.Text = "";
            txtProductPriceEmployee.Text = "";
            txtProductPriceCompany.Text = "";
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
                listProduct = mProductDAO.ProductList();
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

        private void DisplayProductDetailData(Product product)
        {
            try
            {
                listProductDetail.Clear();
                listProductDetail = mProductDetailDAO.ProductDetailList(product);
                ProductDetailDataGridView.DataSource = listProductDetail;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ProductDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mProduct = listProduct[e.RowIndex];
                cmbxProductName.Text = mProduct.ProductName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EditMode(true, false);
        }

        private void ProductDetailDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mProductDetail = listProductDetail[e.RowIndex];
                int i = ProductDataGridView.CurrentCell.RowIndex;
                if (i < listProduct.Count && i != -1)
                {
                    mProduct = listProduct[i];
                }
                cmbxProductName.Text = mProduct.ProductName;
                txtProductType.Text = mProductDetail.ProductType;
                txtProductPriceEmployee.Text = mProductDetail.PriceEmployee.ToString();
                txtProductPriceCompany.Text = mProductDetail.PriceCompany.ToString();
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
            cmbxProductName.Enabled = editProduct;
            txtProductType.Enabled = editProductDetail;
            txtProductPriceEmployee.Enabled = editProductDetail;
            txtProductPriceCompany.Enabled = editProductDetail;
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