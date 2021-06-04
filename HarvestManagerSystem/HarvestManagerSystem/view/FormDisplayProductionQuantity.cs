using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;

namespace HarvestManagerSystem.view
{
    public partial class FormDisplayProductionQuantity : Form
    {
        int QuantityDataGridSelectedRowIndex = -1;
        List<Production> listQuantityProduction = new List<Production>();
        List<HarvestQuantity> listHarvestQuantity = new List<HarvestQuantity>();
        HarvestQuantityDAO harvestQuantityDAO = HarvestQuantityDAO.getInstance();
        ProductionDAO productionDAO = ProductionDAO.getInstance();

        public FormDisplayProductionQuantity()
        {
            InitializeComponent();
        }

        private void FormDisplayProductionQuantity_Load(object sender, EventArgs e)
        {
            DisplayQuantityData();
        }

        void DisplayQuantityData()
        {
            startQuantitySearchDateTimePicker.Value = DateTime.Now.AddDays(-29);
            endQuantitySearchDateTimePicker.Value = DateTime.Now.AddDays(1);
            UpdateDisplayHarvestQuantityData(startQuantitySearchDateTimePicker.Value, endQuantitySearchDateTimePicker.Value);
        }

        private void UpdateDisplayHarvestQuantityData(DateTime fromDate, DateTime toDate)
        {
            listQuantityProduction.Clear();
            try
            {
                listQuantityProduction = productionDAO.searchHarvestQuantityProduction(startQuantitySearchDateTimePicker.Value, endQuantitySearchDateTimePicker.Value, 1);

                if (listQuantityProduction.Count > 0)
                {
                    masterQuantityDataGridView.DataSource = listQuantityProduction;
                }
                else
                {
                    masterQuantityDataGridView.DataSource = new List<Production>();
                    detailQuantityDataGridView.DataSource = new List<HarvestQuantity>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateDisplayHarvestQuantityData called: " + ex.Message);
            }
            SortDisplayMasterQuantityColumnsIndex();
        }

        private void masterQuantityDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = masterQuantityDataGridView.CurrentRow.Index;
            if (i < listQuantityProduction.Count && i >= 0)
            {
                DisplayDetailQuantityData(listQuantityProduction[i]);
            }
        }

        private void DisplayDetailQuantityData(Production production)
        {
            listHarvestQuantity.Clear();
            try
            {
                listHarvestQuantity = harvestQuantityDAO.HarvestQuantityByProduction(production);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DisplayDetailQuantityData called: " + ex.Message);
            }
            detailQuantityDataGridView.DataSource = listHarvestQuantity;
            SortDisplayDetailsQuantityColumnsIndex();
        }

        private void masterQuantityDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                masterQuantityDataGridView.Rows[e.RowIndex].Selected = true;
                QuantityContextMenuStrip.Show(this.masterQuantityDataGridView, e.Location);
                QuantityDataGridSelectedRowIndex = e.RowIndex;
                QuantityContextMenuStrip.Show(Cursor.Position);
                DisplayDetailQuantityData(listQuantityProduction[QuantityDataGridSelectedRowIndex]);
            }
        }

        private void QuantityContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == EditQuantityStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleEditQuantityTable();
            }
            else if (e.ClickedItem.Name == DeleteQuantityStrip.Name)
            {
                HoursContextMenuStrip.Visible = false;
                HandleDeleteQuantityTable();
            }
        }

        private void HandleEditQuantityTable()
        {
            FormAddQuantity formAddQuantity = new FormAddQuantity();
            Production production = (Production)listQuantityProduction[QuantityDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select Item");
                return;
            }
            formAddQuantity.InflateUI(production);
            formAddQuantity.ShowDialog();
        }

        private void HandleDeleteQuantityTable()
        {

            Production production = (Production)listQuantityProduction[QuantityDataGridSelectedRowIndex];
            if (production == null)
            {
                MessageBox.Show("Select production");
                return;
            }

            List<HarvestQuantity> listQuantity = new List<HarvestQuantity>();
            try
            {
                listQuantity = harvestQuantityDAO.HarvestQuantityByProduction(production);
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
                foreach (HarvestQuantity item in listQuantity)
                {
                    trackInsert = productionDAO.deleteQuantityProductionData(production, item);
                    if (!trackInsert) break;
                }
                var msg = (trackInsert) ? "deleted" : "not deleted";
                MessageBox.Show(msg);
                RefreshQuantityProductionTable();
            }

        }

        private void btnSearchQuantityProduction_Click(object sender, EventArgs e)
        {
            UpdateDisplayHarvestQuantityData(startQuantitySearchDateTimePicker.Value, endQuantitySearchDateTimePicker.Value);
        }

        public void RefreshQuantityProductionTable()
        {
            UpdateDisplayHarvestQuantityData(DateTime.Now.AddDays(-29), DateTime.Now.AddDays(1));
        }

        private void SortDisplayDetailsQuantityColumnsIndex()
        {
            detailQuantityDataGridView.Columns["HarvestQuantityIdColumn"].DisplayIndex = 0;
            detailQuantityDataGridView.Columns["HarvestQuantityDateColumn"].DisplayIndex = 1;
            detailQuantityDataGridView.Columns["HQEmployeeNameColumn"].DisplayIndex = 2;
            detailQuantityDataGridView.Columns["AllQuantityColumn"].DisplayIndex = 3;
            detailQuantityDataGridView.Columns["BadQuantityColumn"].DisplayIndex = 4;
            detailQuantityDataGridView.Columns["GoodQuantityColumn"].DisplayIndex = 5;
            detailQuantityDataGridView.Columns["ProductPriceColumn"].DisplayIndex = 6;
            detailQuantityDataGridView.Columns["HQCreditAmountColumn"].DisplayIndex = 7;
            detailQuantityDataGridView.Columns["HQTransportAmountColumn"].DisplayIndex = 8;
            detailQuantityDataGridView.Columns["HQPaymentColumn"].DisplayIndex = 9;
            detailQuantityDataGridView.Columns["HQRemarqueColumn"].DisplayIndex = 10;
            detailQuantityDataGridView.Columns["HarvestCategoryColumn"].DisplayIndex = 11;
        }

        private void SortDisplayMasterQuantityColumnsIndex()
        {
            masterQuantityDataGridView.Columns["HQProductionIdColumn"].DisplayIndex = 0;
            masterQuantityDataGridView.Columns["HQHQProductionDateColumn"].DisplayIndex = 1;
            masterQuantityDataGridView.Columns["HQProductionSupplierNameColumn"].DisplayIndex = 2;
            masterQuantityDataGridView.Columns["HQProductionFarmNameColumn"].DisplayIndex = 3;
            masterQuantityDataGridView.Columns["HQProductionProductNameColumn"].DisplayIndex = 4;
            masterQuantityDataGridView.Columns["HQProductionProductCodeColumn"].DisplayIndex = 5;
            masterQuantityDataGridView.Columns["HQProductionTotalQuantityColumn"].DisplayIndex = 6;
            masterQuantityDataGridView.Columns["HQProductionProductPriceColumn"].DisplayIndex = 7;
            masterQuantityDataGridView.Columns["HQProductionTotalEmployeeColumn"].DisplayIndex = 8;
            masterQuantityDataGridView.Columns["HQProductionPaymentCompanyColumn"].DisplayIndex = 9;
            masterQuantityDataGridView.Columns["HQProductionTypeColumn"].DisplayIndex = 10;
        }


    }
}
