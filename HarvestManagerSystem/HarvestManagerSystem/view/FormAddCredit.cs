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
    public partial class FormAddCredit : Form
    {
        private bool isEditCredit = false;
        private Credit mCredit = new Credit();
        private CreditDAO creditDAO = CreditDAO.getInstance();
        private EmployeeDAO employeeDAO = EmployeeDAO.getInstance();

        private Dictionary<string, Employee> mEmployeeDictionary = new Dictionary<string, Employee>();

        private HarvestMS harvestMS;
        private static FormAddCredit instance;

        public FormAddCredit(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }

        private void FormAddCredit_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
            instance = null;
        }

        public static FormAddCredit getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddCredit(harvestMS);
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
                instance = new FormAddCredit(harvestMS);

            }
            instance.Show();
        }

        private void FormAddCredit_Load(object sender, EventArgs e)
        {
            EmployeeNameList();
            if (isEditCredit)
            {
                CreditEmployeeComboBox.SelectedIndex = CreditEmployeeComboBox.FindStringExact(mCredit.Employee.FullName);
                CreditAmountTextBox.Text = Convert.ToString(mCredit.CreditAmount);
                CreditDatePicker.Value = mCredit.CreditDate;
            }
            else
            {
                CreditEmployeeComboBox.SelectedIndex = -1;
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
                CreditEmployeeComboBox.DataSource = NamesList;
            }
        }

        internal void InflateUI(Credit credit)
        {
            isEditCredit = true;
            CreditEmployeeComboBox.SelectedIndex = -1;
            mCredit.CreditId = credit.CreditId;
            mCredit.CreditDate = credit.CreditDate;
            mCredit.CreditAmount = credit.CreditAmount;
            mCredit.Employee.EmployeeId = credit.Employee.EmployeeId;
            mCredit.Employee.FirstName = credit.Employee.FirstName;
            mCredit.Employee.LastName = credit.Employee.LastName;
            CreditDatePicker.Enabled = false;
            CreditEmployeeComboBox.Enabled = false;
            handleSaveButton.Text = "Update";
        }

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (isEditCredit)
            {
                UpdateCredit(mCredit);
            }
            else
            {
                if (CheckInput() || !validateData())
                {
                    MessageBox.Show("Vérifier les valeurs");
                    return;
                }
                SaveCreditData();
            }
            harvestMS.DisplayCreditData();
        }

        private bool CheckInput()
        {
            creditEmployeeErrorLabel.Visible = CreditEmployeeComboBox.SelectedIndex == -1 && CreditEmployeeComboBox.Text == "";
            creditAmountErrorLabel.Visible = (CreditAmountTextBox.Text == "") ? true : false;
            return creditEmployeeErrorLabel.Visible || creditAmountErrorLabel.Visible;
        }

        private bool validateData()
        {
            Regex regex = new Regex(@"^[0-9]+\.?[0-9]*$");
            return regex.Match(CreditAmountTextBox.Text).Success;
        }

        private void UpdateCredit(Credit credit)
        {
            credit.CreditAmount = Convert.ToDouble(CreditAmountTextBox.Text);
            bool isAdded = creditDAO.UpdateData(credit); 

            if (isAdded)
            {
                wipeFields();
                MessageBox.Show("data updated");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not updated");
                this.Close();
            }
        }

        private void SaveCreditData()
        {
            Employee employee = new Employee();
            if (!mEmployeeDictionary.TryGetValue(CreditEmployeeComboBox.Text, out employee))
            {
                Console.WriteLine("no select value");
            }

            Credit credit = new Credit();
            credit.Employee.EmployeeId = employee.EmployeeId;
            credit.Employee.FirstName = employee.FirstName;
            credit.Employee.LastName = employee.LastName;
            credit.CreditDate = CreditDatePicker.Value.Date;
            credit.CreditAmount = Convert.ToDouble(CreditAmountTextBox.Text);
            if (creditDAO.addData(credit))
            {
                wipeFields();
                MessageBox.Show("Added to database: ");
            }
            else
            {
                MessageBox.Show("Not added to database: ");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            wipeFields();
        }

        private void wipeFields()
        {
            EmployeeNameList();
            CreditDatePicker.Value = DateTime.Now;
            CreditEmployeeComboBox.SelectedIndex = -1;
            CreditAmountTextBox.Text = "";
        }


    }
}
