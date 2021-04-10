using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;
using System.Text.RegularExpressions;

namespace HarvestManagerSystem.view
{
    public partial class FormAddTransport : Form
    {

        private bool isEditTransport = false;
        private Transport mTransport = new Transport();
        private TransportDAO transportDAO = TransportDAO.getInstance();
        private EmployeeDAO employeeDAO = EmployeeDAO.getInstance();
        private FarmDAO farmDAO = FarmDAO.getInstance();

        private Dictionary<string, Employee> mEmployeeDictionary = new Dictionary<string, Employee>();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();

        private HarvestMS harvestMS;
        private static FormAddTransport instance;


        public FormAddTransport(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddTransport_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
            instance = null;
        }

        public static FormAddTransport getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddTransport(harvestMS);
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
                instance = new FormAddTransport(harvestMS);

            }
            instance.Show();
        }

        private void FormAddTransport_Load(object sender, EventArgs e)
        {
            EmployeeNameList();
            FarmNameList();
            if (isEditTransport)
            {
                TransportEmployeeComboBox.SelectedIndex = TransportEmployeeComboBox.FindStringExact(mTransport.Employee.FullName);
                TransportFarmComboBox.SelectedIndex = TransportFarmComboBox.FindStringExact(mTransport.Farm.FarmName);
                TransportDatePicker.Value = mTransport.TransportDate;
                TransportAmountTextBox.Text = Convert.ToString(mTransport.TransportAmount);
            }
            else
            {
                TransportEmployeeComboBox.SelectedIndex = -1;
                TransportFarmComboBox.SelectedIndex = -1;
                TransportAmountTextBox.Text = "0.0";
            }
        }

        private void EmployeeNameList()
        {
            List<string> NamesList = new List<string>();
            mEmployeeDictionary.Clear();
            try
            {
                mEmployeeDictionary = employeeDAO.EmployeeDictionary();
                NamesList.AddRange(mEmployeeDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                TransportEmployeeComboBox.DataSource = NamesList;
            }
        }


        private void FarmNameList()
        {
            List<string> NamesList = new List<string>();
            mFarmDictionary.Clear();
            try
            {
                mFarmDictionary = farmDAO.FarmDictionary();
                NamesList.AddRange(mFarmDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                TransportFarmComboBox.DataSource = NamesList;
            }
        }

        internal void InflateUI(Transport transport)
        {
            isEditTransport = true;
            TransportEmployeeComboBox.SelectedIndex = -1;
            TransportFarmComboBox.SelectedIndex = -1;
            mTransport.TransportId = transport.TransportId;
            mTransport.TransportDate = transport.TransportDate;
            mTransport.TransportAmount = transport.TransportAmount;
            mTransport.Employee.EmployeeId = transport.Employee.EmployeeId;
            mTransport.Employee.FirstName = transport.Employee.FirstName;
            mTransport.Employee.LastName = transport.Employee.LastName;
            mTransport.Farm.FarmId = transport.Farm.FarmId;
            mTransport.Farm.FarmName = transport.Farm.FarmName;
            TransportDatePicker.Enabled = false;
            TransportEmployeeComboBox.Enabled = false;
            TransportFarmComboBox.Enabled = false;
            handleSaveButton.Text = "Update";
        }

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (isEditTransport)
            {
                UpdateTransport(mTransport);
            }
            else
            {
                if (CheckInput() || !validateData())
                {
                    MessageBox.Show("Vérifier les valeurs");
                    return;
                }
                SaveTransportData();
            }
            harvestMS.DisplayTransportData();
        }

        private bool CheckInput()
        {
            transportEmployeeErrorLabel.Visible = TransportEmployeeComboBox.SelectedIndex == -1 && TransportEmployeeComboBox.Text == "";
            transportFarmErrorLabel.Visible = TransportFarmComboBox.SelectedIndex == -1 && TransportFarmComboBox.Text == "";
            transportAmountErrorLabel.Visible = (TransportAmountTextBox.Text == "") ? true : false;
            return transportEmployeeErrorLabel.Visible || transportFarmErrorLabel.Visible || transportAmountErrorLabel.Visible;
        }

        private bool validateData()
        {
            Regex regex = new Regex(@"^[0-9]+\.?[0-9]*$");
            return regex.Match(TransportAmountTextBox.Text).Success;
        }

        private void UpdateTransport(Transport transport)
        {
            transport.TransportAmount = Convert.ToDouble(TransportAmountTextBox.Text);

            if (transportDAO.UpdateData(transport))
            {
                wipeFields();
                MessageBox.Show("data updated");
            }
            else
            {
                MessageBox.Show("Not updated");
            }
            this.Close();
        }

        private void SaveTransportData()
        {
            Employee employee = new Employee();
            if (!mEmployeeDictionary.TryGetValue(TransportEmployeeComboBox.Text, out employee))
            {
                Console.WriteLine("no select value");
            }
            Farm farm = new Farm();
            if (!mFarmDictionary.TryGetValue(TransportFarmComboBox.Text, out farm))
            {
                Console.WriteLine("no select value");
            }

            Transport transport = new Transport();
            transport.Employee.EmployeeId = employee.EmployeeId;
            transport.Employee.FirstName = employee.FirstName;
            transport.Employee.LastName = employee.LastName;
            transport.Farm.FarmId = farm.FarmId;
            transport.Farm.FarmName = farm.FarmName;
            transport.TransportDate = TransportDatePicker.Value.Date;
            transport.TransportAmount = Convert.ToDouble(TransportAmountTextBox.Text);


            if (transportDAO.addData(transport))
            {
                wipeFields();
                MessageBox.Show("Added to database: ");
            }
            else
            {
                MessageBox.Show("Not added to database: ");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            wipeFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wipeFields()
        {
            EmployeeNameList();
            FarmNameList();
            TransportEmployeeComboBox.SelectedIndex = -1;
            TransportDatePicker.Value = DateTime.Now;
            TransportFarmComboBox.SelectedIndex = -1;
            TransportAmountTextBox.Text = "0.0";
        }


    }
}
