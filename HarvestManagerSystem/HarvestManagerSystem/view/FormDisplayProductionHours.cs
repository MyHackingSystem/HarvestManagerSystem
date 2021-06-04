using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.database;
using HarvestManagerSystem.model;

namespace HarvestManagerSystem.view
{
    public partial class FormDisplayProductionHours : Form
    {

        HarvestHoursDAO harvestHoursDAO = HarvestHoursDAO.getInstance();
        ProductionDAO productionDAO = ProductionDAO.getInstance();
        int HoursDataGridSelectedRowIndex = -1;
        List<Production> listHoursProduction = new List<Production>();
        List<HarvestHours> listHarvestHours = new List<HarvestHours>();

        public FormDisplayProductionHours()
        {
            InitializeComponent();
        }

        private void FormDisplayProductionHours_Load(object sender, EventArgs e)
        {
            DisplayHoursData();
        }

        void DisplayHoursData()
        {
            StartHoursSearchDateTimePicker.Value = DateTime.Now.AddDays(-29);
            EndHoursSearchDateTimePicker.Value = DateTime.Now.AddDays(1);
            UpdateDisplayHarvestHoursData(StartHoursSearchDateTimePicker.Value, EndHoursSearchDateTimePicker.Value);
        }

        private void UpdateDisplayHarvestHoursData(DateTime fromDate, DateTime toDate)
        {
            listHoursProduction.Clear();
            try
            {
                listHoursProduction = productionDAO.searchHarvestHoursProduction(StartHoursSearchDateTimePicker.Value, EndHoursSearchDateTimePicker.Value, 1);

                if (listHoursProduction.Count > 0)
                {
                    masterHoursDataGridView.DataSource = listHoursProduction;
                }
                else
                {
                    masterHoursDataGridView.DataSource = new List<Production>();
                    detailsHoursDataGridView.DataSource = new List<HarvestHours>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Harvest Data called: " + ex.Message);
            }
            SortDisplayMasterHoursColumnsIndex();
        }

        private void masterHoursDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (masterHoursDataGridView.CurrentRow.Index < listHoursProduction.Count && masterHoursDataGridView.CurrentRow.Index >= 0)
                {
                    DisplayDetailHoursData(listHoursProduction[masterHoursDataGridView.CurrentRow.Index]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayDetailHoursData(Production production)
        {
            listHarvestHours.Clear();
            try
            {
                listHarvestHours = harvestHoursDAO.HarvestHoursByProduction(production);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Display Detail Data called: " + ex.Message);
            }
            detailsHoursDataGridView.DataSource = listHarvestHours;
            SortDisplayDetailsHoursColumnsIndex();
        }

        private void SearchHoursButton_Click(object sender, EventArgs e)
        {
            UpdateDisplayHarvestHoursData(StartHoursSearchDateTimePicker.Value, EndHoursSearchDateTimePicker.Value);
        }

        public void RefreshHoursProductionTable()
        {
            UpdateDisplayHarvestHoursData(StartHoursSearchDateTimePicker.Value, EndHoursSearchDateTimePicker.Value);
        }

        private void masterHoursDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                masterHoursDataGridView.Rows[e.RowIndex].Selected = true;
                HoursContextMenuStrip.Show(this.masterHoursDataGridView, e.Location);
                HoursDataGridSelectedRowIndex = e.RowIndex;
                HoursContextMenuStrip.Show(Cursor.Position);
                DisplayDetailHoursData(listHoursProduction[HoursDataGridSelectedRowIndex]);

            }
        }

        private void HoursContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Name == EditHoursStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleEditHoursTable();
            }
            else if (e.ClickedItem.Name == DeleteHoursStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleDeleteHoursTable();
            }
        }

        private void HandleEditHoursTable()
        {
            FormAddHours formAddHours = new FormAddHours();
            Production production = (Production)listHoursProduction[HoursDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select Item");
                return;
            }
            formAddHours.InflateUI(production);
            formAddHours.ShowDialog();
        }

        private void HandleDeleteHoursTable()
        {

            Production production = (Production)listHoursProduction[HoursDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select production");
                return;
            }

            List<HarvestHours> listHours = new List<HarvestHours>();
            try
            {
                listHours = harvestHoursDAO.HarvestHoursByProduction(production);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this data ", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                bool trackInsert = false;
                foreach (HarvestHours hours in listHours)
                {
                    trackInsert = productionDAO.deleteHoursProductionData(production, hours);
                    if (!trackInsert) break;
                }
                var msg = (trackInsert) ? "deleted" : "not deleted";
                MessageBox.Show(msg);
                RefreshHoursProductionTable();
            }

        }

        private void SortDisplayDetailsHoursColumnsIndex()
        {
            detailsHoursDataGridView.Columns["HarvestHoursIDColumn"].DisplayIndex = 0;
            detailsHoursDataGridView.Columns["HarvestDateColumn"].DisplayIndex = 1;
            detailsHoursDataGridView.Columns["HoursEmployeeNameColumn"].DisplayIndex = 2;
            detailsHoursDataGridView.Columns["TimeStartMorningColumn"].DisplayIndex = 3;
            detailsHoursDataGridView.Columns["TimeEndMorningColumn"].DisplayIndex = 4;
            detailsHoursDataGridView.Columns["TimeStartNoonColumn"].DisplayIndex = 5;
            detailsHoursDataGridView.Columns["TimeEndNoonColumn"].DisplayIndex = 6;
            detailsHoursDataGridView.Columns["HoursTotalMinutesColumn"].DisplayIndex = 7;
            detailsHoursDataGridView.Columns["HourPriceColumn"].DisplayIndex = 8;
            detailsHoursDataGridView.Columns["HoursCreditAmountColumn"].DisplayIndex = 9;
            detailsHoursDataGridView.Columns["HoursTransportAmountColumn"].DisplayIndex = 10;
            detailsHoursDataGridView.Columns["PaymentEmployeeColumn"].DisplayIndex = 11;
            detailsHoursDataGridView.Columns["EmployeeCategoryColumn"].DisplayIndex = 12;
            detailsHoursDataGridView.Columns["RemarqueColumn"].DisplayIndex = 13;
        }

        private void SortDisplayMasterHoursColumnsIndex()
        {
            masterHoursDataGridView.Columns["ProductionIDColumn"].DisplayIndex = 0;
            masterHoursDataGridView.Columns["ProductionDateColumn"].DisplayIndex = 1;
            masterHoursDataGridView.Columns["ProductionSupplierNameColumn"].DisplayIndex = 2;
            masterHoursDataGridView.Columns["ProductionFarmNameColumn"].DisplayIndex = 3;
            masterHoursDataGridView.Columns["ProductionProductNameColumn"].DisplayIndex = 4;
            masterHoursDataGridView.Columns["ProductionProductCodeColumn"].DisplayIndex = 5;
            masterHoursDataGridView.Columns["TotalQuantityColumn"].DisplayIndex = 6;
            masterHoursDataGridView.Columns["TotalMinutesColumn"].DisplayIndex = 7;
            masterHoursDataGridView.Columns["PriceColumn"].DisplayIndex = 8;
            masterHoursDataGridView.Columns["PaymentCompanyColumn"].DisplayIndex = 9;
            masterHoursDataGridView.Columns["TotalEmployeeColumn"].DisplayIndex = 10;
            masterHoursDataGridView.Columns["ProductionTypeColumn"].DisplayIndex = 11;
            masterHoursDataGridView.Columns["ProductionSupplierColumn"].DisplayIndex = 11;
            masterHoursDataGridView.Columns["ProductionFarmColumn"].DisplayIndex = 13;
            masterHoursDataGridView.Columns["ProductionProductColumn"].DisplayIndex = 14;
            masterHoursDataGridView.Columns["ProductionProductDetailColumn"].DisplayIndex = 15;
        }

 
    }
}
