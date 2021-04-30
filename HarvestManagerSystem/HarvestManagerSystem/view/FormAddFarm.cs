using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;

namespace HarvestManagerSystem.view
{
    public partial class FormAddFarm : Form
    {

        private FarmDAO farmDAO = FarmDAO.getInstance();
        private SeasonDAO seasonDAO = SeasonDAO.getInstance();
        private Dictionary<string, Farm> mFarmDictionary = new Dictionary<string, Farm>();
        private HarvestMS harvestMS;

        public FormAddFarm(HarvestMS harvestMS)
        {
            this.harvestMS = harvestMS;
            InitializeComponent();
        }


        private void FormAddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            wipeFields();
        }

        private void FormAddFarm_Load(object sender, EventArgs e)
        {
            FarmNameList();
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
            wipeFields();
        }

        private void FarmNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Farm farm = mFarmDictionary.GetValueOrDefault(FarmNameComboBox.GetItemText(FarmNameComboBox.SelectedItem));
            if (farm != null)
            {
                FarmAddress.Text = farm.FarmAddress;
            }
            
        }

        private void handleSaveButton_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }
            SaveFarmData();
            harvestMS.DisplayFarmData();
        }

        private bool CheckInput()
        {
            nameFarmErrorLabel.Visible = FarmNameComboBox.SelectedIndex == -1 && FarmNameComboBox.Text == "";
            addressFarmErrorLabel.Visible = (FarmAddress.Text == "") ? true : false;
            return nameFarmErrorLabel.Visible || addressFarmErrorLabel.Visible;
        }

        private void SaveFarmData()
        {
            Farm farm;
            if (!mFarmDictionary.TryGetValue(FarmNameComboBox.Text, out farm))
            {
                Console.WriteLine("no select value");
            }

            Season season = new Season();
            season.SeasonPlantingDate = PlantingDate.Value.Date;
            season.SeasonHarvestDate = HarvestDate.Value.Date;

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
            FarmNameList();
        }

        private void wipeFields()
        {
            FarmNameComboBox.SelectedIndex = -1;
            FarmNameComboBox.Text = "";
            FarmAddress.Text = "";
            PlantingDate.Value = DateTime.Now;
            HarvestDate.Value = DateTime.Now;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            wipeFields();
        }

    }
}
