using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HarvestManagerSystem.view
{
    public partial class MainForm : Form
    {
        private LoginForm loginForm;
        private Form activeForm = null;
        public MainForm(LoginForm frm)
        {
            InitializeComponent();
            this.loginForm = frm;
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null) 
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAddProduct());
        }

        private void btnAddFarm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAddFarm());
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAddSupplier());
        }

        private void btnAddCredit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAddCredit());
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAddEmployee());
        }

        private void btnAddHarvestQuantity_Click(object sender, EventArgs e)
        {

        }

        private void btnAddHarvestHours_Click(object sender, EventArgs e)
        {
            FormAddHours formAddHours = new FormAddHours();
            formAddHours.ShowDialog();
        }

        private void btnAddHarvestByGroup_Click(object sender, EventArgs e)
        {
            FormAddQuantity formAddQuantity = new FormAddQuantity();
            formAddQuantity.ShowDialog();
        }

        private void btnDisplayProduction_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HarvestMS());
        }

        private void btnUpdateSetting_Click(object sender, EventArgs e)
        {
            FormPreferences formPreferences = FormPreferences.getInstance();
            formPreferences.ShowForm();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }
    }
}
