using HarvestManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HarvestManagerSystem.view
{
    public partial class FormHarvestedVegetables : Form
    {
        Carrot[] carrots = null;
        public FormHarvestedVegetables()
        {
            InitializeComponent();
        }

        private void FormHarvestedVegetables_Load(object sender, EventArgs e)
        {
            carrots = new Carrot[5];
        }

        private void getData()
        {
            carrots[0] = new Carrot();
            carrots[1] = new Carrot();
            carrots[2] = new Carrot();
            carrots[3] = new Carrot();
            carrots[4] = new Carrot();

            carrots[0].ProductName = txtCarrotCode1.Text;
            carrots[0].PriceEmployee = Convert.ToDouble(txtCarrotPriceEmployee1.Text);
            carrots[0].PriceCompany = Convert.ToDouble(txtCarrotPriceCompany1.Text);
            carrots[1].ProductName = txtCarrotCode2.Text;
            carrots[1].PriceEmployee = Convert.ToDouble(txtCarrotPriceEmployee2.Text);
            carrots[1].PriceCompany = Convert.ToDouble(txtCarrotPriceCompany2.Text);
            carrots[2].ProductName = txtCarrotCode3.Text;
            carrots[2].PriceEmployee = Convert.ToDouble(txtCarrotPriceEmployee3.Text);
            carrots[2].PriceCompany = Convert.ToDouble(txtCarrotPriceCompany3.Text);
            carrots[3].ProductName = txtCarrotCode4.Text;
            carrots[3].PriceEmployee = Convert.ToDouble(txtCarrotPriceEmployee4.Text);
            carrots[3].PriceCompany = Convert.ToDouble(txtCarrotPriceCompany4.Text);
            carrots[4].ProductName = txtCarrotCode5.Text;
            carrots[4].PriceEmployee = Convert.ToDouble(txtCarrotPriceEmployee5.Text);
            carrots[4].PriceCompany = Convert.ToDouble(txtCarrotPriceCompany5.Text);
        }

        private void btnValidateCarrotInput_Click(object sender, EventArgs e)
        {
            getData();
            for (int i = 0; i < carrots.Length; i ++)
            {
                MessageBox.Show(carrots[i].ProductName);
            }

        }
    }
}
