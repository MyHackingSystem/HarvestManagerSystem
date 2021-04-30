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

        private HarvestMS harvestMS;

        public FormAddEmployee(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void FormAddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
        }

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {  
                return;
            }
            SaveEmployeedata();
            harvestMS.DisplayEmployeeData();
        }

        private void SaveEmployeedata()
        {
            Employee employee = new Employee();
            employee.EmployeeStatus = fxEmployeeStatus.Checked;
            employee.FirstName = fxFirstName.Text.ToUpper().Trim();
            employee.LastName = fxLastName.Text.ToUpper().Trim();
            employee.FireDate = fxFireDate.Value;
            employee.HireDate = fxHireDate.Value;
            employee.PermitDate = fxPermissionDate.Value;

            if (emplouyeeDAO.addData(employee))
            {
                MessageBox.Show("Data Added");
                wipeFields();
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
    }
}
