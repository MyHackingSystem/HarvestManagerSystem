using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;


namespace HarvestManagerSystem.view
{
    public partial class FormAddCredit : Form
    {

        private CreditDAO mCreditDAO = CreditDAO.getInstance();
        private EmployeeDAO mEmployeeDAO = EmployeeDAO.getInstance();
        private TransportDAO mTransportDAO = TransportDAO.getInstance();
        private Dictionary<string, Employee> mEmployeeDictionary = new Dictionary<string, Employee>();
        List<Credit> listCredit = new List<Credit>();
        List<Transport> listTransport = new List<Transport>();

        public FormAddCredit()
        {
            InitializeComponent();
        }

        private void FormAddCredit_Load(object sender, EventArgs e)
        {
            DisplayCreditData();
            DisplayTransportData();
        }

        public void DisplayCreditData()
        {
            try
            {
                listCredit = mCreditDAO.getData();
                CreditDataGridView.DataSource = listCredit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Display Credit: " + ex.Message);
            }
        }

        public void DisplayTransportData()
        {
            try
            {
                listTransport = mTransportDAO.getData();
                TransportDataGridView.DataSource = listTransport;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Display Transport: " + ex.Message);
            }
        }

        private void EmployeeNameList()
        {
            List<string> NamesList = new List<string>();
            mEmployeeDictionary.Clear();
            try
            {
                mEmployeeDictionary = mEmployeeDAO.EmployeeDictionary();
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

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            SaveCreditData();
            DisplayCreditData();
        }

        private bool CheckInput()
        {
            creditEmployeeErrorLabel.Visible = CreditEmployeeComboBox.SelectedIndex == -1 && CreditEmployeeComboBox.Text == "";
            creditAmountErrorLabel.Visible = (CreditAmountTextBox.Text == "") ? true : false;
            return creditEmployeeErrorLabel.Visible || creditAmountErrorLabel.Visible;
        }

        private void ValidateNumberEntred(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
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
            try
            {
                mCreditDAO.Add(credit);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            ClearFields();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            EmployeeNameList();
            CreditDatePicker.Value = DateTime.Now;
            CreditEmployeeComboBox.SelectedIndex = -1;
            CreditAmountTextBox.Text = "";
        }
    }
}
