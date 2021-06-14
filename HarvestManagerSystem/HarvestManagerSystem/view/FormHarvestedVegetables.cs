using HarvestManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.outil;
using System.Drawing;

namespace HarvestManagerSystem.view
{
    public partial class FormHarvestedVegetables : Form
    {
        Carrot[] carrots = null;
        Products[] products = null;
        CarrotDAO carrotDAO = null;
        ProductsDAO productsDAO = null;
        List<Carrot> carrotList = null;
        List<Products> productsList = null;
        Label[] carrotNames = null;
        TextBox[] carrotEmployeePrice = null;
        TextBox[] carrotCompanyPrice = null;
        public FormHarvestedVegetables()
        {
            InitializeComponent();
        }

        private void FormHarvestedVegetables_Load(object sender, EventArgs e)
        {
            carrots = new Carrot[11];
            products = new Products[4];
            carrotNames = new Label[6];
            carrotEmployeePrice = new TextBox[6];
            carrotCompanyPrice = new TextBox[6];
            carrotList = new List<Carrot>();
            productsList = new List<Products>();
            carrotDAO = CarrotDAO.getInstance();
            productsDAO = ProductsDAO.getInstance();
            DrawCarrotFields();
            initFields();
        }
        private void DrawCarrotFields()
        {
            for (int i = 1; i < carrotNames.Length; i++)
            {
                DrawLabel(i);
                DrawEmployeeTextBoxPrice(i);
                DrawCompanyTextBoxPrice(i);
            }
        }
        private void DrawLabel(int i)
        {
            carrotNames[i] = new Label();
            carrotNames[i].Location = new Point(60, 211 + (i * 60));
            carrotNames[i].BorderStyle = BorderStyle.FixedSingle;
            carrotNames[i].BackColor = Color.DarkOrange;
            carrotNames[i].BringToFront();
            pnlCarrot.Controls.Add(carrotNames[i]);
        }

        private void DrawEmployeeTextBoxPrice(int i)
        {
            carrotEmployeePrice[i] = new TextBox();
            carrotEmployeePrice[i].Location = new Point(180, 211 + (i * 60));
            carrotEmployeePrice[i].BorderStyle = BorderStyle.FixedSingle;
            carrotEmployeePrice[i].BringToFront();
            carrotEmployeePrice[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberEntred);
            pnlCarrot.Controls.Add(carrotEmployeePrice[i]);
        }

        private void DrawCompanyTextBoxPrice(int i)
        {
            carrotCompanyPrice[i] = new TextBox();
            carrotCompanyPrice[i].Location = new Point(300, 211 + (i * 60));
            carrotCompanyPrice[i].BorderStyle = BorderStyle.FixedSingle;
            carrotCompanyPrice[i].BringToFront();
            carrotCompanyPrice[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberEntred);
            pnlCarrot.Controls.Add(carrotCompanyPrice[i]);
        }

        private void initFields()
        {
            initCarrotArray();
            initProductsArray();
            GetCarrotList();
            SetCarrotArray();
            SetTunnelFieldsValues();
            SetOpenFieldsValues();
            GetProductsList();
            SetProductArray();
            SetProductsFieldsValues();
        }

        private void initCarrotArray()
        {
            for (int i = 0; i < carrots.Length; i++)
                carrots[i] = new Carrot();
        }
        private void initProductsArray()
        {
            for (int i = 0; i < products.Length; i++)
                products[i] = new Products();
        }

        private void GetCarrotList()
        {
            try
            {
                carrotList.Clear();
                carrotList = carrotDAO.CarrotList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetCarrotArray()
        {
            if (carrotList.Count > 0)
            {
                foreach (Carrot carrot in carrotList)
                {
                    carrots[carrot.ProductId] = carrot;
                }
            }
        }

        private void SetProductArray()
        {
            if (productsList.Count > 0)
            {
                foreach (Products product in productsList)
                {
                    products[product.ProductId] = product;
                }
            }
        }

        private void radioTunnel_CheckedChanged(object sender, EventArgs e)
        {
            GetCarrotList();
            SetCarrotArray();
            SetTunnelFieldsValues();
        }

        private void radioOpen_CheckedChanged(object sender, EventArgs e)
        {
            GetCarrotList();
            SetCarrotArray();
            SetOpenFieldsValues();
        }

        private void SetOpenFieldsValues()
        {
            if (radioOpen.Checked && carrotList.Count > 0)
            {
                for(int i = 1; i < 6; i++)
                {
                    carrotNames[i].Text = carrots[i+5].ProductName;
                    carrotEmployeePrice[i].Text = carrots[i + 5].EmployeePrice.ToString();
                    carrotCompanyPrice[i].Text = carrots[i + 5].CompanyPrice.ToString();
                }
            }
        }

        private void SetTunnelFieldsValues()
        {
            if (radioTunnel.Checked && carrotList.Count > 0)
            {
                for (int i = 1; i < 6; i++)
                {
                    carrotNames[i].Text = carrots[i].ProductName;
                    carrotEmployeePrice[i].Text = carrots[i].EmployeePrice.ToString();
                    carrotCompanyPrice[i].Text = carrots[i].CompanyPrice.ToString();
                }
            }
        }

        private void btnValidateCarrotInput_Click(object sender, EventArgs e)
        {
            if (radioTunnel.Checked)
            {
                UpdateCarrotTunnelHarvest();
            }
            if (radioOpen.Checked)
            {
                UpdateCarrotOpenHarvest();
            }
        }

        private void UpdateCarrotTunnelHarvest()
        {
            try
            {
                GetTunnelFieldsValues();
                for (int i = 1; i < 6; i++)
                {
                    carrotDAO.UpdatePrice(carrots[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCarrotOpenHarvest()
        {
            try
            {
                GetOpenFieldsValues();
                for (int i = 6; i < 11; i++)
                {
                    carrotDAO.UpdatePrice(carrots[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTunnelFieldsValues()
        {
            for (int i = 1; i < 6; i++)
            {
                carrots[i].EmployeePrice = Convert.ToDouble(carrotEmployeePrice[i].Text);
                carrots[i].CompanyPrice = Convert.ToDouble(carrotCompanyPrice[i].Text);
            }
        }

        private void GetOpenFieldsValues()
        {
            for (int i = 1; i < 6; i++)
            {
                carrots[i+5].EmployeePrice = Convert.ToDouble(carrotEmployeePrice[i].Text);
                carrots[i+5].CompanyPrice = Convert.ToDouble(carrotCompanyPrice[i].Text);
            }
        }


        private void GetProductsList()
        {
            try
            {
                productsList.Clear();
                productsList = productsDAO.ProductsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetProductsFieldsValues()
        {
            if (productsList.Count > 0)
            {
                txtRoundTurnipPriceE.Text = products[1].EmployeePrice.ToString();
                txtRoundTurnipPriceC.Text = products[1].CompanyPrice.ToString();
                txtLongTurnipPriceE.Text = products[2].EmployeePrice.ToString();
                txtLongTurnipPriceC.Text = products[2].CompanyPrice.ToString();
                txtWaterMelonPriceE.Text = products[3].EmployeePrice.ToString();
                txtWaterMelonPriceC.Text = products[3].CompanyPrice.ToString();
            }
        }

        private void ValidateNumberEntred(object sender, KeyPressEventArgs e)
        {
            Validation.ValidateNumberEntred(sender, e);
        }

        private void btnValidateRoundTurnipInput_Click(object sender, EventArgs e)
        {
            GetRoundTurnipPrice();
            UpdateProductPrice(1);
        }

        private void GetRoundTurnipPrice()
        {
            products[1].EmployeePrice = Convert.ToDouble(txtRoundTurnipPriceE.Text);
            products[1].CompanyPrice = Convert.ToDouble(txtRoundTurnipPriceC.Text);
        }

        private void btnValidateLongTurnipInput_Click(object sender, EventArgs e)
        {
            GetLongTurnipPrice();
            UpdateProductPrice(2);
        }

        private void GetLongTurnipPrice()
        {
            products[2].EmployeePrice = Convert.ToDouble(txtLongTurnipPriceE.Text);
            products[2].CompanyPrice = Convert.ToDouble(txtLongTurnipPriceC.Text);
        }

        private void btnValidateWatermelonInput_Click(object sender, EventArgs e)
        {
            GetWaterMelonPrice();
            UpdateProductPrice(3);
        }

        private void GetWaterMelonPrice()
        {
            products[3].EmployeePrice = Convert.ToDouble(txtWaterMelonPriceE.Text);
            products[3].CompanyPrice = Convert.ToDouble(txtWaterMelonPriceC.Text);
        }

        private void UpdateProductPrice(int i)
        {
            try
            {
                productsDAO.UpdatePrice(products[i]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
