using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HarvestManagerSystem.view
{
    public partial class FormAddIndWork : Form
    {
        private HarvestMS harvestMS;
        private static FormAddIndWork instance;

        private FormAddIndWork(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
            InitializeComponent();
        }

        public static FormAddIndWork getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddIndWork(harvestMS);
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
                instance = new FormAddIndWork(harvestMS);

            }
            instance.Show();
        }

        private void FormAddIndWork_Load(object sender, EventArgs e)
        {

        }

        private void FormAddIndWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
    }
}
