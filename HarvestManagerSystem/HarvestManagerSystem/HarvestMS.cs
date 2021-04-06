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
                default:
                    Console.WriteLine("nothing");
                    break;
            }          
        }


        #region //ADD PRODUCT CODE
        FormAddProduct addProduct = new FormAddProduct();
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            addProduct.Show();
        }

        #endregion

        #region //QUANTITY CODE
        void DisplayQuantityData()
        {

        }
        #endregion

        #region //HOURS CODE
        void DisplayHoursData()
        {

        }
        #endregion

        #region //Credit CODE
        void DisplayCreditData()
        {

        }
        #endregion

        #region //Credit CODE
        void DisplayTransportData()
        {

        }
        #endregion

        #region EMPLOYEE CODE
        FormAddEmployee addEmployee = new FormAddEmployee();

        public static List<Employee> List { get => list; set => list = value; }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            addEmployee.Show();
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DisplayEmployeeData();
        }
        public void DisplayEmployeeData()
        {
            employeeDataGridView.DataSource = employeeDAO.getData();
            
        }

        private void employeeMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            if (e.ClickedItem.Name == editEmployeeTable.Name)
            {
                employeeMenuStrip.Visible = false;
                HandleEditEmployeeTable();
            }
            else if (e.ClickedItem.Name == deleteFromEmployeeTable.Name)
            {
                employeeMenuStrip.Visible = false;
                HandleDeleteEmployeeTable();
            }
        }

        void HandleEditEmployeeTable()
        {
            Employee employee = (Employee) employeeDataGridView.CurrentRow.DataBoundItem;
            if (employee == null)
            {
                MessageBox.Show("Select Employee");
                return;
            }
            FormAddEmployee formAddEmployee = new FormAddEmployee();
            formAddEmployee.InflateUI(employee);
            formAddEmployee.Show();
        }

        void HandleDeleteEmployeeTable()
        {
            Employee selectedEmployee = (Employee)employeeDataGridView.CurrentRow.DataBoundItem;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Select Employee");
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this employee", "Delete", MessageBoxButtons.YesNoCancel,
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

        private void employeeDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == employeeDataGridView.Columns["employeeStatusColumn"].Index)
            {
                Employee selectedEmployee = (Employee)employeeDataGridView.CurrentRow.DataBoundItem;
                employeeDAO.updateEmployeeStatusById(selectedEmployee);
            }

        }

        private void employeeDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (employeeDataGridView.DataSource != null)
            {
                if (e.ColumnIndex == employeeDataGridView.Columns["employeeStatusColumn"].Index && e.RowIndex != -1)
                {
                    employeeDataGridView.EndEdit();
                }
            }
        }

        #endregion

        private void displayQuantityContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSearchQuantityProduction_Click(object sender, EventArgs e)
        {

            loadDataProgressBar.Visible = true;
            loadDataProgressBar.Value = 20;
            
        }


    }
}
