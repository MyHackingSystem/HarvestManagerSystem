using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;
using HarvestManagerSystem.view;

namespace HarvestManagerSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLabelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }

        }

        private void login()
        {
            PreferencesDAO preferencesDAO = PreferencesDAO.getInstance();
            Account user = new Account();

            try
            {
                user = preferencesDAO.getLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Error");
                return;
            }

            if (txtUser.Text == user.Name && txtPassword.Text == user.Passwword)
            {
                MainForm mainWindows = new MainForm(this);
                mainWindows.Show();
                //HarvestMS harvestMS = new HarvestMS();
                //harvestMS.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The User name or Password you entered is incorrect, try again.");
            }
        }

        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }
    }
}
