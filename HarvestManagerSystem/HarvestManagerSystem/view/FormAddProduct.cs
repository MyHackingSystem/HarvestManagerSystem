using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HarvestManagerSystem.view
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            initComboBox();
        }

        private void initComboBox()
        {
            List<string> list = new List<string>();

            list.Add("aaa");
            list.Add("bbb");
            list.Add("ccc");
            list.Add("ddd");

            fxProductNameComboBox.DataSource = list;
            fxProductNameComboBox.SelectedIndex = -1;
            fxProductTypeComboBox.DataSource = list;
            fxProductTypeComboBox.SelectedIndex = -1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fxProductNameComboBox.SelectedIndex = -1;
            fxProductTypeComboBox.SelectedIndex = -1;
            fxProductCode.Text = "";
            fxProductPriceEmployee.Text = "";
            fxProductPriceCompany.Text = "";
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                MessageBox.Show("field missing");
                return;
            }
            addNewProduct();
        }

        private bool CheckInput()
        {
            nameProductErrorLabel.Visible = fxProductNameComboBox.SelectedIndex == -1 && fxProductNameComboBox.Text == "";
            typeProductErrorLabel.Visible = fxProductTypeComboBox.SelectedIndex == -1 && fxProductTypeComboBox.Text == "";
            codeProductErrorLabel.Visible = (fxProductCode.Text == "") ? true : false;
            prixEmployeeErrorlabel.Visible = (fxProductPriceEmployee.Text == "") ? true : false;
            prixCompanyErrorlabel.Visible = (fxProductPriceCompany.Text == "") ? true : false;
            return nameProductErrorLabel.Visible || typeProductErrorLabel.Visible || codeProductErrorLabel.Visible || prixEmployeeErrorlabel.Visible || prixCompanyErrorlabel.Visible;
        }

        private void addNewProduct()
        {
            if (!validateData())
            {
                MessageBox.Show("price not number");
                return;
            }

            string productName = fxProductNameComboBox.Text;
            string productType = fxProductTypeComboBox.Text;
            string productCode = fxProductCode.Text;
            double productPriceEmployee = Convert.ToDouble(fxProductPriceEmployee.Text);
            double productPriceCompany = Convert.ToDouble(fxProductPriceCompany.Text);

            string msg = productName + " " + productType + " " + productCode + " " + Convert.ToString(productPriceEmployee) + " " + Convert.ToString(productPriceCompany);

            MessageBox.Show("added to database: " + msg);

            // add to database
        }

        private bool validateData()
        {
            Regex regex = new Regex("^[0-9]+$"); // need to be fixed for double not just integer
            return regex.Match(fxProductPriceEmployee.Text).Success && regex.Match(fxProductPriceCompany.Text).Success;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
