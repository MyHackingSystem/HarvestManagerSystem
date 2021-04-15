using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HarvestManagerSystem.view
{
    public partial class FormAddQuantity : Form
    {

        private HarvestMS harvestMS;
        private static FormAddQuantity instance;

        public FormAddQuantity(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        public static FormAddQuantity getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddQuantity(harvestMS);
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
                instance = new FormAddQuantity(harvestMS);

            }
            instance.Show();
        }

        private void FormAddQuantity_Load(object sender, EventArgs e)
        {

        }

        private void FormAddQuantity_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
            instance = null;
        }

        private void wipeFields()
        {

        }
    }
}
