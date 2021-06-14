using HarvestManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.outil;


namespace HarvestManagerSystem.view
{
    public partial class FormHarvestedVegetables : Form
    {
        Carrot[] carrots = null;
        CarrotDAO carrotDAO = null;
        List<Carrot> carrotList = null;
        public FormHarvestedVegetables()
        {
            InitializeComponent();
        }

        private void FormHarvestedVegetables_Load(object sender, EventArgs e)
        {
            carrots = new Carrot[11];
            carrotList = new List<Carrot>();
            carrotDAO = CarrotDAO.getInstance();
            initFields();
        }

        private void initFields()
        {
            initCarrotArray();
            GetCarrotList();
            SetCarrotArray();
            SetTunnelFieldsValues();
            SetOpenFieldsValues();
        }

        private void initCarrotArray()
        {
            for (int i = 0; i < carrots.Length; i++)
                carrots[i] = new Carrot();
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
            if (radioOpen.Checked && carrots.Length > 0)
            {
                txtCarrotCode1.Text = carrots[6].ProductName;
                txtCarrotPriceEmployee1.Text = carrots[6].EmployeePrice.ToString();
                txtCarrotPriceCompany1.Text = carrots[6].CompanyPrice.ToString();
                txtCarrotCode2.Text = carrots[7].ProductName;
                txtCarrotPriceEmployee2.Text = carrots[7].EmployeePrice.ToString();
                txtCarrotPriceCompany2.Text = carrots[7].CompanyPrice.ToString();
                txtCarrotCode3.Text = carrots[8].ProductName;
                txtCarrotPriceEmployee3.Text = carrots[8].EmployeePrice.ToString();
                txtCarrotPriceCompany3.Text = carrots[8].CompanyPrice.ToString();
                txtCarrotCode4.Text = carrots[9].ProductName;
                txtCarrotPriceEmployee4.Text = carrots[9].EmployeePrice.ToString();
                txtCarrotPriceCompany4.Text = carrots[9].CompanyPrice.ToString();
                txtCarrotCode5.Text = carrots[10].ProductName;
                txtCarrotPriceEmployee5.Text = carrots[10].EmployeePrice.ToString();
                txtCarrotPriceCompany5.Text = carrots[10].CompanyPrice.ToString();
            }
        }

        private void SetTunnelFieldsValues()
        {
            if (radioTunnel.Checked && carrots.Length > 0)
            {
                txtCarrotCode1.Text = carrots[1].ProductName;
                txtCarrotPriceEmployee1.Text = carrots[1].EmployeePrice.ToString();
                txtCarrotPriceCompany1.Text = carrots[1].CompanyPrice.ToString();
                txtCarrotCode2.Text = carrots[2].ProductName;
                txtCarrotPriceEmployee2.Text = carrots[2].EmployeePrice.ToString();
                txtCarrotPriceCompany2.Text = carrots[2].CompanyPrice.ToString();
                txtCarrotCode3.Text = carrots[3].ProductName;
                txtCarrotPriceEmployee3.Text = carrots[3].EmployeePrice.ToString();
                txtCarrotPriceCompany3.Text = carrots[3].CompanyPrice.ToString();
                txtCarrotCode4.Text = carrots[4].ProductName;
                txtCarrotPriceEmployee4.Text = carrots[4].EmployeePrice.ToString();
                txtCarrotPriceCompany4.Text = carrots[4].CompanyPrice.ToString();
                txtCarrotCode5.Text = carrots[5].ProductName;
                txtCarrotPriceEmployee5.Text = carrots[5].EmployeePrice.ToString();
                txtCarrotPriceCompany5.Text = carrots[5].CompanyPrice.ToString();
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
            carrots[1].ProductName = txtCarrotCode1.Text;
            carrots[1].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee1.Text);
            carrots[1].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany1.Text);
            carrots[2].ProductName = txtCarrotCode2.Text;
            carrots[2].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee2.Text);
            carrots[2].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany2.Text);
            carrots[3].ProductName = txtCarrotCode3.Text;
            carrots[3].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee3.Text);
            carrots[3].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany3.Text);
            carrots[4].ProductName = txtCarrotCode4.Text;
            carrots[4].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee4.Text);
            carrots[4].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany4.Text);
            carrots[5].ProductName = txtCarrotCode5.Text;
            carrots[5].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee5.Text);
            carrots[5].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany5.Text);
        }

        private void GetOpenFieldsValues()
        {
            carrots[6].ProductName = txtCarrotCode1.Text;
            carrots[6].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee1.Text);
            carrots[6].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany1.Text);
            carrots[7].ProductName = txtCarrotCode2.Text;
            carrots[7].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee2.Text);
            carrots[7].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany2.Text);
            carrots[8].ProductName = txtCarrotCode3.Text;
            carrots[8].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee3.Text);
            carrots[8].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany3.Text);
            carrots[9].ProductName = txtCarrotCode4.Text;
            carrots[9].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee4.Text);
            carrots[9].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany4.Text);
            carrots[10].ProductName = txtCarrotCode5.Text;
            carrots[10].EmployeePrice = Convert.ToDouble(txtCarrotPriceEmployee5.Text);
            carrots[10].CompanyPrice = Convert.ToDouble(txtCarrotPriceCompany5.Text);
        }

        private void ValidateNumberEntred(object sender, KeyPressEventArgs e)
        {
            Validation.ValidateNumberEntred(sender, e);
        }
    }
}
