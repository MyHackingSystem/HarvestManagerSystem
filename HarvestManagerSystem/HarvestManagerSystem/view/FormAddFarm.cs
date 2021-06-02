using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;

namespace HarvestManagerSystem.view
{
    public partial class FormAddFarm : Form
    {

        private FarmDAO mFarmDAO = FarmDAO.getInstance();
        private SeasonDAO mSeasonDAO = SeasonDAO.getInstance();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        List<Farm> listFarm = new List<Farm>();
        List<Season> listSeason = new List<Season>();
        private bool editFarm = false;
        private bool editSeason = false;
        private Farm mFarm = new Farm();
        private Season mSeason = new Season();

        public FormAddFarm()
        {
            InitializeComponent();
        }

        private void FormAddFarm_Load(object sender, EventArgs e)
        {
            FarmNameList();
            DisplayFarmData();
            ClearFields();
        }

        private void FarmNameList()
        {
            List<string> NamesList = new List<string>();
            mFarmDictionary.Clear();
            try
            {
                mFarmDictionary = mFarmDAO.FarmDictionary();
                NamesList.AddRange(mFarmDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cmbxFarmName.DataSource = NamesList;
                cmbxFarmName.SelectedIndex = -1;
            }
        }

        private void FarmNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Farm farm = mFarmDictionary.GetValueOrDefault(cmbxFarmName.GetItemText(cmbxFarmName.SelectedItem));
            if (farm != null)
            {
                txtFarmAddress.Text = farm.FarmAddress;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (editFarm){ EditFarm();}
            else if (editSeason){ EditSeason();}
            else{ AddFarm();}
            DisplayFarmData();
            FarmNameList();
            ResetFields();
        }

        private void EditFarm()
        {
            if (cmbxFarmName.Text == "" || mFarm.FarmId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try
            {
                mFarm.FarmName = cmbxFarmName.Text.Trim().ToUpper();
                mFarm.FarmAddress = txtFarmAddress.Text.Trim().ToUpper();
                mFarmDAO.Update(mFarm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("les informations sont mises à jour.", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void EditSeason()
        {
            if (mSeason.SeasonId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try
            {
                mSeason.SeasonPlantingDate = datePlantingDate.Value.Date;
                mSeason.SeasonHarvestDate = dateHarvestDate.Value.Date;
                mSeasonDAO.Update(mSeason);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Not Updated: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("les informations sont mises à jour.", "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void AddFarm()
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            Farm farm;
            Season season = new Season();
            season.SeasonPlantingDate = datePlantingDate.Value.Date;
            season.SeasonHarvestDate = dateHarvestDate.Value.Date;
            try
            {
                if (mFarmDictionary.TryGetValue(cmbxFarmName.Text, out farm))
                {
                    season.Farm.FarmId = farm.FarmId;
                    season.Farm.FarmName = farm.FarmName;
                    season.Farm.FarmAddress = farm.FarmAddress;
                    mSeasonDAO.Add(season);
                }
                else
                {
                    season.Farm.FarmName = cmbxFarmName.Text.ToUpper().Trim();
                    season.Farm.FarmAddress = txtFarmAddress.Text.ToUpper().Trim();
                    mSeasonDAO.addNewFarm(season);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Not Added: " + ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            MessageBox.Show("Les information été ajouté à la base de données");
        }

        private bool CheckInput()
        {
            nameFarmErrorLabel.Visible = cmbxFarmName.SelectedIndex == -1 && cmbxFarmName.Text == "";
            addressFarmErrorLabel.Visible = (txtFarmAddress.Text == "") ? true : false;
            return nameFarmErrorLabel.Visible || addressFarmErrorLabel.Visible;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ces données", "Supprimer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                if (editFarm) { DeleteFarm(); }
                else if (editSeason) { DeleteSeason(); }
                DisplayFarmData();
                FarmNameList();
                ResetFields();
            }
        }

        private void DeleteFarm()
        {
            if (cmbxFarmName.Text == "" || mFarm.FarmId <= 0)
            {
                MessageBox.Show("Select Farm required");
                return;
            }
            try { mFarmDAO.Delete(mFarm); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteSeason()
        {
            if (mSeason.SeasonId <= 0)
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            try { mSeasonDAO.Delete(mSeason); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void DisplayFarmData()
        {
            try
            {
                listFarm = mFarmDAO.FarmList();
                FarmDataGridView.DataSource = listFarm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FarmtDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = FarmDataGridView.CurrentCell.RowIndex;
            if (i < listFarm.Count)
            {
                DisplaySeasonData(listFarm[i]);
            }
        }

        private void DisplaySeasonData(Farm farm)
        {
            listSeason.Clear();
            listSeason = mSeasonDAO.SeasonList(farm);
            SeasonDataGridView.DataSource = listSeason;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (editFarm || editSeason)
            {
                ResetFields();
            }
            else
            {
                ClearFields();
            }
        }

        private void ResetFields()
        {
            cmbxFarmName.Enabled = true;
            txtFarmAddress.Enabled = true;
            dateHarvestDate.Enabled = true;
            datePlantingDate.Enabled = true;
            btnSave.Text = "Ajouter";
            btnClearReset.Text = "Vider";
            btnDelete.Visible = false;
            editFarm = false;
            editSeason = false;
            ClearFields();
        }

        private void ClearFields()
        {
            cmbxFarmName.SelectedIndex = -1;
            cmbxFarmName.Text = "";
            txtFarmAddress.Text = "";
            datePlantingDate.Value = DateTime.Now;
            dateHarvestDate.Value = DateTime.Now;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FarmDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mFarm = listFarm[e.RowIndex];
                cmbxFarmName.Text = mFarm.FarmName;
                txtFarmAddress.Text = mFarm.FarmAddress;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EditMode(true, false);
        }

        private void SeasonDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mSeason = listSeason[e.RowIndex];
                int i = FarmDataGridView.CurrentCell.RowIndex;
                if (i < listFarm.Count && i != -1)
                {
                    mFarm = listFarm[i];
                }
                cmbxFarmName.Text = mFarm.FarmName;
                txtFarmAddress.Text = mFarm.FarmAddress;
                dateHarvestDate.Value = mSeason.SeasonHarvestDate;
                datePlantingDate.Value = mSeason.SeasonPlantingDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            EditMode(false, true);
        }

        private void EditMode(bool f, bool s)
        {
            editFarm = f;
            editSeason = s;
            cmbxFarmName.Enabled = editFarm;
            txtFarmAddress.Enabled = editFarm;
            dateHarvestDate.Enabled = editSeason;
            datePlantingDate.Enabled = editSeason;
            ShowEditMode();
        }

        private void ShowEditMode()
        {
            btnSave.Text = "Update";
            btnClearReset.Text = "Reset";
            btnDelete.Visible = true;
        }
    }
}
