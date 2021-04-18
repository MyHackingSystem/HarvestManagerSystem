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
using HarvestManagerSystem.outil;

namespace HarvestManagerSystem.view
{
    public partial class FormPreferences : Form
    {
        Preferences pref = new Preferences();
        PreferencesDAO preferencesDAO = PreferencesDAO.getInstance();

        private static FormPreferences instance;

        private FormPreferences()
        {
            InitializeComponent();
        }

        public static FormPreferences getInstance()
        {
            if (instance == null)
            {
                instance = new FormPreferences();
            }
            return instance;
        }

        public void ShowForm()
        {
            if (instance != null)
            {
                instance.BringToFront();
            }
            else
            {
                instance = new FormPreferences();

            }
            instance.Show();
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            initFields();
        }

        private void initFields()
        {
            
            try
            {
                pref = preferencesDAO.getPreferences();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtPenaltyGeneral.Text = pref.PenaltyGeneral.ToString();
            txtfxDamageGeneral.Text = pref.DamageGeneral.ToString();
            txtHourPrice.Text = pref.HourPrice.ToString();
            txtTransportPrice.Text = pref.TransportPrice.ToString();

        }

        private void FormPreferences_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void UpdatePreferencesButton_Click(object sender, EventArgs e)
        {
            if (
                !Validation.isNumeric(txtPenaltyGeneral.Text) || 
                !Validation.isNumeric(txtfxDamageGeneral.Text) ||
                !Validation.isNumeric(txtHourPrice.Text) ||
                !Validation.isNumeric(txtTransportPrice.Text)
                )
            {
                MessageBox.Show("Vérifier les valeurs");
                return;
            }

            Preferences pref = new Preferences();
            pref.PenaltyGeneral = Convert.ToDouble(txtPenaltyGeneral.Text);
            pref.DamageGeneral = Convert.ToDouble(txtfxDamageGeneral.Text);
            pref.HourPrice = Convert.ToDouble(txtHourPrice.Text);
            pref.TransportPrice = Convert.ToDouble(txtTransportPrice.Text);

            if (preferencesDAO.editPreferences(pref))
            {
                MessageBox.Show("les valeurs ont été mises à jour ");
            }
            else
            {
                MessageBox.Show("les valeurs n'ont pas été mises à jour ");
            }


        }

    }
}
