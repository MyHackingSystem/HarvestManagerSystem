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
        EmployeeDAO mEmployeeDAO = EmployeeDAO.getInstance();
        private bool editEmployee = false;
        List<Employee> listEmployee = new List<Employee>();
        private Employee mEmployee = new Employee();
        public FormAddEmployee()
        {
            InitializeComponent();
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {
            DisplayEmployeeData();
        }

        public void DisplayEmployeeData()
        {
            try
            {
                listEmployee = mEmployeeDAO.ListEmployee();
                EmployeeDataGridView.DataSource = listEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EndCotract();
        }

        private void EndCotract()
        {
            txtListEmployeeCloseFire.Text = "";
            foreach (Employee emp in listEmployee)
            {
                if (emp.FireDate.AddDays(-5) <= DateTime.Now.Date)
                {
                    txtListEmployeeCloseFire.Text += "* " + emp.FullName + Environment.NewLine;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (editEmployee) 
            { 
                EditEmployee(); 
            }else { 
                AddEmployee(); 
            }
            DisplayEmployeeData();
            ResetFields();
        }

        private void EditEmployee()
        {
            if (CheckInput() || mEmployee.EmployeeId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            mEmployee.EmployeeStatus = chackEmployeeStatus.Checked;
            mEmployee.FirstName = txtFirstName.Text.ToUpper().Trim();
            mEmployee.LastName = txtLastName.Text.ToUpper().Trim();
            mEmployee.FireDate = dateFireDate.Value;
            mEmployee.HireDate = dateHireDate.Value;
            mEmployee.PermitDate = datePermissionDate.Value;
            try
            {
                mEmployeeDAO.Update(mEmployee);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("les informations sont mises à jour.", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void AddEmployee()
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            Employee employee = new Employee();
            employee.EmployeeStatus = chackEmployeeStatus.Checked;
            employee.FirstName = txtFirstName.Text.ToUpper().Trim();
            employee.LastName = txtLastName.Text.ToUpper().Trim();
            employee.FireDate = dateFireDate.Value;
            employee.HireDate = dateHireDate.Value;
            employee.PermitDate = datePermissionDate.Value;
            try
            {
                mEmployeeDAO.Add(employee);
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
            firstNameErrorLabel.Visible = (txtFirstName.Text == "") ? true : false;
            lastNameErrorLabel.Visible = (txtLastName.Text == "") ? true : false;
            return firstNameErrorLabel.Visible || lastNameErrorLabel.Visible;
        }

        private void fxFirstName_TextChanged(object sender, EventArgs e)
        {
            firstNameErrorLabel.Visible = (txtFirstName.Text == "") ? true : false;
        }

        private void fxLastName_TextChanged(object sender, EventArgs e)
        {
            lastNameErrorLabel.Visible = (txtLastName.Text == "") ? true : false;
        }

        private void btnClearReset_Click(object sender, EventArgs e)
        {
            if (editEmployee) { ResetFields(); } else { ClearFields(); }
        }

        private void ResetFields()
        {
            btnSave.Text = "Ajouter";
            btnClearReset.Text = "Vider";
            btnDelete.Visible = false;
            editEmployee = false;
            ClearFields();
        }

        private void ClearFields()
        {
            chackEmployeeStatus.Checked = false;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dateFireDate.Value = DateTime.Now;
            dateHireDate.Value = DateTime.Now;
            datePermissionDate.Value = DateTime.Now;
            firstNameErrorLabel.Visible = false;
            lastNameErrorLabel.Visible = false;
        }

        private void EmployeeDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mEmployee = listEmployee[e.RowIndex];
                txtFirstName.Text = mEmployee.FirstName;
                txtLastName.Text = mEmployee.LastName;
                dateHireDate.Value = mEmployee.HireDate;
                dateFireDate.Value = mEmployee.FireDate;
                datePermissionDate.Value = mEmployee.PermitDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            editEmployee = true;
            ShowEditMode();
        }

        private void ShowEditMode()
        {
            btnSave.Text = "Update";
            btnClearReset.Text = "Reset";
            btnDelete.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ces données", "Supprimer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                if (editEmployee) { DeleteEmployee(); }
                DisplayEmployeeData();
                ResetFields();
            }
        }

        private void DeleteEmployee()
        {
            if (txtFirstName.Text == "" || mEmployee.EmployeeId <= 0)
            {
                MessageBox.Show("Select Employee required");
                return;
            }
            try { mEmployeeDAO.Delete(mEmployee); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
