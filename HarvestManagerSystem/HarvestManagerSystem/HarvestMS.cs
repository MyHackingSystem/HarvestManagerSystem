using HarvestManagerSystem.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarvestManagerSystem
{
    public partial class HarvestMS : Form
    {
        public HarvestMS()
        {
            InitializeComponent();
            


        }

        private void HarvestMS_Load(object sender, EventArgs e)
        {
           
        }

        FormAddProduct addProduct = new FormAddProduct();
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            addProduct.Show();
        }

        FormAddEmployee addEmployee = new FormAddEmployee();
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            addEmployee.Show();
        }
    }
}
