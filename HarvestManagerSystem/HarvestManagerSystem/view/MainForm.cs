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
        LoginForm loginForm;
        public MainForm(LoginForm frm)
        {
            InitializeComponent();
            this.loginForm = frm;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Show();
        }
    }
}
