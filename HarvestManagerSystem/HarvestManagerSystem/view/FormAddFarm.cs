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
    public partial class FormAddFarm : Form
    {
        private bool isEditFarm = false;
        private bool isEditSeason = false;
        private Farm mFarm = new Farm();
        private Season mSeason = new Season();
        private FarmDAO farmDAO = FarmDAO.getInstance();
        private SeasonDAO seasonDAO = SeasonDAO.getInstance();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private HarvestMS harvestMS;
        private static FormAddFarm instance;

        public FormAddFarm(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }


        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
            instance = null;
        }


        public static FormAddFarm getInstance(HarvestMS harvestMS)
        {
            if (instance == null)
            {
                instance = new FormAddFarm(harvestMS);
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
                instance = new FormAddFarm(harvestMS);

            }
            instance.Show();
        }



        private void FormAddFarm_Load(object sender, EventArgs e)
        {
            FarmNameList();
            if (isEditFarm)
            {
                FarmNameComboBox.SelectedIndex = FarmNameComboBox.FindStringExact(mFarm.FarmName);
                FarmAddress.Text = mFarm.FarmAddress;
            }else if (isEditSeason)
            {
                FarmNameComboBox.SelectedIndex = FarmNameComboBox.FindStringExact(mSeason.Farm.FarmName);
                FarmAddress.Text = mSeason.Farm.FarmAddress;
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
                FarmNameComboBox.DataSource = NamesList;
            }
        }

        private void FarmNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Farm farm = mFarmDictionary.GetValueOrDefault(FarmNameComboBox.GetItemText(FarmNameComboBox.SelectedItem));
            if (farm != null)
            {
                FarmAddress.Text = farm.FarmAddress;
            }
            
        }

        internal void InflateUI(Farm farm)
        {
            isEditFarm = true;
            FarmNameComboBox.SelectedIndex = -1;
            FarmAddress.Text = farm.FarmAddress;
            mFarm.FarmId = farm.FarmId;
            mFarm.FarmName = farm.FarmName;
            mFarm.FarmAddress = farm.FarmAddress;
            PlantingDate.Enabled = false;
            HarvestDate.Enabled = false;
            handleSaveButton.Text = "Update";
        }

        internal void InflateUI(Season season, Farm farm)
        {
            isEditSeason = true;
            FarmNameComboBox.Enabled = false;
            FarmAddress.Enabled = false;
            mSeason.SeasonId = season.SeasonId;
            mSeason.Farm.FarmId = farm.FarmId;
            mSeason.Farm.FarmName = farm.FarmName;
            mSeason.Farm.FarmAddress = farm.FarmAddress;
            mSeason.SeasonPlantingDate = season.SeasonPlantingDate;
            mSeason.SeasonHarvestDate = season.SeasonHarvestDate;

            PlantingDate.Value = season.SeasonPlantingDate;
            HarvestDate.Value = season.SeasonHarvestDate;
            handleSaveButton.Text = "Update";
        }

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (isEditSeason)
            {
                UpdateSeason(mSeason);
            }
            else if (isEditFarm)
            {
                UpdateFarm(mFarm);
            }
            else
            {
                if (CheckInput())
                {
                    MessageBox.Show("Vérifier les valeurs");
                    return;
                }
                SaveFarmData();
            }
            harvestMS.DisplayFarmData();
        }

        private bool CheckInput()
        {
            nameFarmErrorLabel.Visible = FarmNameComboBox.SelectedIndex == -1 && FarmNameComboBox.Text == "";
            addressFarmErrorLabel.Visible = (FarmAddress.Text == "") ? true : false;
            return nameFarmErrorLabel.Visible || addressFarmErrorLabel.Visible;
        }

        private void UpdateSeason(Season season)
        {
            season.SeasonPlantingDate = PlantingDate.Value;
            season.SeasonHarvestDate = HarvestDate.Value;

            bool isAdded = seasonDAO.UpdateData(season); 

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

        private void UpdateFarm(Farm farm)
        {
            farm.FarmName = FarmNameComboBox.Text.ToUpper().Trim();
            farm.FarmAddress = FarmAddress.Text.ToUpper().Trim();

            bool isAdded = farmDAO.UpdateData(farm); 
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

        private void SaveFarmData()
        {
            Farm farm;
            if (!mFarmDictionary.TryGetValue(FarmNameComboBox.Text, out farm))
            {
                Console.WriteLine("no select value");
            }

            Season season = new Season();
            season.SeasonPlantingDate = PlantingDate.Value;
            season.SeasonHarvestDate = HarvestDate.Value;

            bool added = false;
            if (farm != null)
            {
                season.Farm.FarmId = farm.FarmId; 
                season.Farm.FarmName = farm.FarmName;
                season.Farm.FarmAddress = farm.FarmAddress;
                added = seasonDAO.addData(season);
            }
            else
            {
                season.Farm.FarmName = FarmNameComboBox.Text.ToUpper().Trim();
                season.Farm.FarmAddress = FarmAddress.Text.ToUpper().Trim();
                added = seasonDAO.addNewFarmSeason(season); 

            }
            if (added)
            {
                wipeFields();
            }
            else
            {
                MessageBox.Show("Not added to database: ");
            }

            FarmNameList();
            wipeFields();
        }

        private void wipeFields()
        {
            FarmNameComboBox.SelectedIndex = -1;
            FarmAddress.Text = "";
            PlantingDate.Value = DateTime.Now;
            HarvestDate.Value = DateTime.Now;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            wipeFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
