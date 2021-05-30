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
    }
}
