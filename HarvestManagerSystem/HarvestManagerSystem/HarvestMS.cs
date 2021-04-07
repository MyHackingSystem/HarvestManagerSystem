using HarvestManagerSystem.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem
{
    public partial class HarvestMS : Form
    {
        EmployeeDAO employeeDAO = EmployeeDAO.getInstance();
        ProductDAO productDAO = ProductDAO.getInstance();
        ProductDetailDAO productDetailDAO = ProductDetailDAO.getInstance();
        private static List<Employee> list = new List<Employee>();


        public HarvestMS()
        {
            InitializeComponent();
            
        }



        private void HarvestMS_Load(object sender, EventArgs e)
        {

        }

        private void tabProduction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabProduction.SelectedIndex)
            {
                case 0:
                    DisplayQuantityData();
                    break;
                case 1:
                    DisplayHoursData();
                    break;
                case 2:
                    DisplayCreditData();
                    DisplayTransportData();
                    break;
                case 3:
                    DisplayEmployeeData();
                    break;
                case 4:
                    MessageBox.Show(Convert.ToString(tabProduction.SelectedIndex));
                    break;
                case 5:
                    MessageBox.Show(Convert.ToString(tabProduction.SelectedIndex));
                    break;
                case 6:
                    DisplayProductData();
                    break;
                default:
                    Console.WriteLine("nothing");
                    break;
            }          
        }


        #region PRODUCT CODE
        List<Product> listProduct = new List<Product>();
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FormAddProduct formAddProduct = FormAddProduct.getInstance(this);
            formAddProduct.ShowFormAdd();
        }

         public void DisplayProductData()
        {
            listProduct = productDAO.getData();
            ProductDataGridView.DataSource = listProduct;
        }

        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = ProductDataGridView.CurrentCell.RowIndex;
            if (i < listProduct.Count)
            {
                DisplayProductDetailData(listProduct[i]);
            }

        }

        private void ProductContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditProductStrip.Name)
            {
                ProductContextMenuStrip.Visible = false;
                HandleEditProductTable();
            }
            else if (e.ClickedItem.Name == DeleteProductStrip.Name)
            {
                ProductContextMenuStrip.Visible = false;
                HandleDeleteProductTable();
            }
        }

        void HandleEditProductTable()
        {
            
            FormAddProduct formAddProduct = FormAddProduct.getInstance(this);
            Product product = (Product)ProductDataGridView.CurrentRow.DataBoundItem;
            if (product == null)
            {
                MessageBox.Show("Select Product");
                return;
            }

            formAddProduct.InflateUI(product);
            formAddProduct.ShowFormAdd();
        }

        void HandleDeleteProductTable()
        {
            Product product = (Product)ProductDataGridView.CurrentRow.DataBoundItem;
            if (product == null)
            {
                MessageBox.Show("Select product");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete: " + product.ProductName, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = productDAO.DeleteData(product);
                DisplayProductData();
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
                DisplayEmployeeData();
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }

        }

        #endregion

        #region PRODUCT DETAIL CODE

        private void DisplayProductDetailData(Product product)
        {
            ProductDetailDataGridView.DataSource = productDetailDAO.getData(product);
        }

        private void ProductDetailContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditProductDetailStrip.Name)
            {
                ProductDetailContextMenuStrip.Visible = false;
                HandleEditProductDetailTable();
            }
            else if (e.ClickedItem.Name == DeleteProductDetailStrip.Name)
            {
                ProductDetailContextMenuStrip.Visible = false;
                HandleDeleteProductDetailTable();
            }
        }

        void HandleEditProductDetailTable()
        {

            FormAddProduct formEditProductDetail = FormAddProduct.getInstance(this);
            Product product = (Product)ProductDataGridView.CurrentRow.DataBoundItem;
            ProductDetail productDetail = (ProductDetail)ProductDetailDataGridView.CurrentRow.DataBoundItem;
            if (productDetail == null)
            {
                MessageBox.Show("Select Product Detail");
                return;
            }

            formEditProductDetail.InflateUI(productDetail, product);
            formEditProductDetail.ShowFormAdd();
        }

        void HandleDeleteProductDetailTable()
        {
            ProductDetail productDetail = (ProductDetail)ProductDetailDataGridView.CurrentRow.DataBoundItem;
            if (productDetail == null)
            {
                MessageBox.Show("Select product");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete product with code: " + productDetail.ProductCode, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = productDetailDAO.DeleteData(productDetail);
                DisplayProductData();
            }

            if (deleted)
            {
                MessageBox.Show("Delete");
                DisplayEmployeeData();
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }

        }

        #endregion

        #region //TO DO QUANTITY CODE
        void DisplayQuantityData()
        {

        }
        private void btnSearchQuantityProduction_Click(object sender, EventArgs e)
        {

            loadDataProgressBar.Visible = true;
            loadDataProgressBar.Value = 20;

        }

        private void displayQuantityContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        #endregion

        #region //TO DO HOURS CODE
        void DisplayHoursData()
        {

        }
        #endregion

        #region //TO DO Credit CODE
        void DisplayCreditData()
        {

        }
        #endregion

        #region //To do Credit CODE
        void DisplayTransportData()
        {

        }
        #endregion

        #region EMPLOYEE CODE

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = FormAddEmployee.getInstance(this);
            formAddEmployee.ShowFormAdd();
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DisplayEmployeeData();
        }
        public void DisplayEmployeeData()
        {
            EmployeeDataGridView.DataSource = employeeDAO.getData();
        }

        private void EmployeeContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditEmployeeStrip.Name)
            {
                EmployeeContextMenuStrip.Visible = false;
                HandleEditEmployeeTable();
            }
            else if (e.ClickedItem.Name == DeleteEmployeeStrip.Name)
            {
                EmployeeContextMenuStrip.Visible = false;
                HandleDeleteEmployeeTable();
            }
        }

        void HandleEditEmployeeTable()
        {
            FormAddEmployee formAddEmployee = FormAddEmployee.getInstance(this);
            Employee employee = (Employee) EmployeeDataGridView.CurrentRow.DataBoundItem;
            if (employee == null)
            {
                MessageBox.Show("Select Employee");
                return;
            }           
            formAddEmployee.InflateUI(employee);
            formAddEmployee.ShowFormAdd();
        }

        void HandleDeleteEmployeeTable()
        {
            Employee selectedEmployee = (Employee)EmployeeDataGridView.CurrentRow.DataBoundItem;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Select Employee");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete: " + selectedEmployee.FullName, "Delete", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);
            bool deleted = false;
            if (dr == DialogResult.Yes)
            {
                deleted = employeeDAO.DeleteData(selectedEmployee);
            }
            
            if (deleted)
            {
                MessageBox.Show("Delete");
                DisplayEmployeeData();
            }else if(dr == DialogResult.Yes)
            {
                MessageBox.Show("Not Delete");
            }
            
        }

        private void EmployeeDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == EmployeeDataGridView.Columns["employeeStatusColumn"].Index)
            {
                Employee selectedEmployee = (Employee)EmployeeDataGridView.CurrentRow.DataBoundItem;
                employeeDAO.updateEmployeeStatusById(selectedEmployee);
            }

        }

        private void employeeDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (EmployeeDataGridView.DataSource != null)
            {
                if (e.ColumnIndex == EmployeeDataGridView.Columns["employeeStatusColumn"].Index && e.RowIndex != -1)
                {
                    EmployeeDataGridView.EndEdit();
                }
            }
        }


        #endregion


    }
}
