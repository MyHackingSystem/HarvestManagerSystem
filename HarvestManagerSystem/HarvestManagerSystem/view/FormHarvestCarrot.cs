using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;
using System.IO;
using ExcelDataReader;
using DataTable = System.Data.DataTable;

namespace HarvestManagerSystem.view
{
    public partial class FormHarvestCarrot : Form
    {
        List<Harvest>[] HarvestList = new List<Harvest>[6];
        List<Employee> employeeList = new List<Employee>();

        public FormHarvestCarrot()
        {
            InitializeComponent();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        private void dgvProduct1_MouseClick(object sender, MouseEventArgs e)
        {
            if(dgvProduct1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                foreach(DataGridViewColumn column in dgvProduct1.Columns)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = column.HeaderText;
                    item.Checked = column.Visible;
                    item.Click += (obj, ea) =>
                    {
                        column.Visible = !item.Checked;
                        item.Checked = column.Visible;
                        menuStrip.Show(dgvProduct1, e.Location);
                    };
                    menuStrip.Items.Add(item);
                }

                menuStrip.Show(dgvProduct1, e.Location);
            }
        }

        private List<Harvest> ReaHarvestFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Office Files|*.xlsx;*.xls;", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                    DataSet result = reader.AsDataSet();
                    DataTable tbl = result.Tables[0];

                    HarvestList[0] = new List<Harvest>();
                    HarvestList[1] = new List<Harvest>();
                    HarvestList[2] = new List<Harvest>();
                    HarvestList[3] = new List<Harvest>();
                    HarvestList[4] = new List<Harvest>();
                    HarvestList[5] = new List<Harvest>();

                    foreach (DataRow row in tbl.Rows)
                    {

                        if (row.ItemArray[0].ToString() == "ID") continue;

                        Employee employee = new Employee();
                        Harvest h1 = new Harvest();
                        Harvest h2 = new Harvest();
                        Harvest h3 = new Harvest();
                        Harvest h4 = new Harvest();
                        Harvest h5 = new Harvest();

                        try
                        {
                            employee.EmployeeId = (row.ItemArray[0].ToString() != null && !row.ItemArray[0].ToString().Equals("")) ? Convert.ToInt32(row.ItemArray[0].ToString()) : -1;
                            employee.FirstName = row.ItemArray[1].ToString();


                            h1.HarvestQuantity = (row.ItemArray[2].ToString() != null && !row.ItemArray[2].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[2].ToString()) : 0;

                            h2.HarvestQuantity = (row.ItemArray[3].ToString() != null && !row.ItemArray[3].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[3].ToString()) : 0;

                            h3.HarvestQuantity = (row.ItemArray[4].ToString() != null && !row.ItemArray[4].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[4].ToString()) : 0;

                            h4.HarvestQuantity = (row.ItemArray[5].ToString() != null && !row.ItemArray[5].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[5].ToString()) : 0;

                            h5.HarvestQuantity = (row.ItemArray[6].ToString() != null && !row.ItemArray[6].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[6].ToString()) : 0;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        employeeList.Add(employee);
                        HarvestList[1].Add(h1);
                        HarvestList[2].Add(h2);
                        HarvestList[3].Add(h3);
                        HarvestList[4].Add(h4);
                        HarvestList[5].Add(h5);
                    }
                    reader.Close();
                    fs.Close();
                }
            }
            return HarvestList[5];
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            List<Harvest> importedList = new List<Harvest>();
            try
            {
                importedList = ReaHarvestFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadDGVData();
        }

        private void loadDGVData()
        {
            dgvProduct1.DataSource = HarvestList[1];
            dgvProduct2.DataSource = HarvestList[2];
            dgvProduct3.DataSource = HarvestList[3];
            dgvProduct4.DataSource = HarvestList[4];
            dgvProduct5.DataSource = HarvestList[5];
            dgvEmployee.DataSource = employeeList;
        }
    }
}
