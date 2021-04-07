using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.view
{
    public partial class FormAddEmployee : Form
    {
        EmployeeDAO emplouyeeDAO = EmployeeDAO.getInstance();
        Employee mEmployee = new Employee();
        bool isEditStatus = false;

        private HarvestMS harvestMS;
        private static FormAddEmployee instance;

        private FormAddEmployee(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
            instance = null;
        }


        public static FormAddEmployee getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddEmployee(harvestMS);
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
                instance = new FormAddEmployee(harvestMS);

            }
            instance.Show();
        }

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {  
                return;
            }
            if (isEditStatus)
            {
                UpdateEmployeedata(mEmployee);
            }
            else
            {
                SaveEmployeedata();
            }
            harvestMS.DisplayEmployeeData();
            
        }

        private void UpdateEmployeedata(Employee employee)
        {
            employee.EmployeeStatus = fxEmployeeStatus.Checked;
            employee.FirstName = fxFirstName.Text.ToUpper().Trim();
            employee.LastName = fxLastName.Text.ToUpper().Trim();
            employee.FireDate = fxFireDate.Value;
            employee.HireDate = fxHireDate.Value;
            employee.PermissionDate = fxPermissionDate.Value;

            bool isAdded = emplouyeeDAO.UpdateData(employee);
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

        private void SaveEmployeedata()
        {
            Employee employee = new Employee();

            employee.EmployeeStatus = fxEmployeeStatus.Checked;
            employee.FirstName = fxFirstName.Text.ToUpper().Trim();
            employee.LastName = fxLastName.Text.ToUpper().Trim();
            employee.FireDate = fxFireDate.Value;
            employee.HireDate = fxHireDate.Value;
            employee.PermissionDate = fxPermissionDate.Value;

            bool isAdded = emplouyeeDAO.addData(employee);
            if (isAdded)
            {
                wipeFields();
                MessageBox.Show("Data Added");
            }
            else
            {
                MessageBox.Show("Data not added");
            }
        }

        private bool CheckInput()
        {
            firstNameErrorLabel.Visible = (fxFirstName.Text == "") ? true : false;
            lastNameErrorLabel.Visible = (fxLastName.Text == "") ? true : false;
            return firstNameErrorLabel.Visible || lastNameErrorLabel.Visible;
        }

        private void fxFirstName_TextChanged(object sender, EventArgs e)
        {
            firstNameErrorLabel.Visible = (fxFirstName.Text == "") ? true : false;
        }

        private void fxLastName_TextChanged(object sender, EventArgs e)
        {
            lastNameErrorLabel.Visible = (fxLastName.Text == "") ? true : false;
        }

        private void clearFieldsButton_Click(object sender, EventArgs e)
        {
            wipeFields();
        }

        private void wipeFields()
        {
            fxEmployeeStatus.Checked = false;
            fxFirstName.Text = "";
            fxLastName.Text = "";
            fxFireDate.Value = DateTime.Now;
            fxHireDate.Value = DateTime.Now;
            fxPermissionDate.Value = DateTime.Now;
            firstNameErrorLabel.Visible = false;
            lastNameErrorLabel.Visible = false;
        }

        private void handleCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {

        }

        public void InflateUI(Employee employee)
        {
            isEditStatus = true;
            mEmployee.EmployeeId = employee.EmployeeId;
            fxEmployeeStatus.Checked = employee.EmployeeStatus;
            fxFirstName.Text = employee.FirstName;
            fxLastName.Text = employee.LastName;
            fxFireDate.Value = employee.HireDate;
            fxHireDate.Value = employee.FireDate;
            fxPermissionDate.Value = employee.PermissionDate;
            handleSaveButton.Text = "Update";
        }


    }
}
