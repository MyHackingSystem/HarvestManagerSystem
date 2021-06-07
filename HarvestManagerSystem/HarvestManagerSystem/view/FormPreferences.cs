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
        PreferencesDAO mPreferencesDAO = PreferencesDAO.getInstance();
        Account admin = new Account();

        public FormPreferences()
        {
            InitializeComponent();
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            initFields();
        }

        private void initFields()
        {
            
            try
            {
                pref = mPreferencesDAO.getPreferences();
                admin = mPreferencesDAO.getLogin();
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

            if (mPreferencesDAO.editPreferences(pref))
            {
                MessageBox.Show("les valeurs ont été mises à jour.");
            }
            else
            {
                MessageBox.Show("les valeurs n'ont pas été mises à jour.");
            }

        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if(txtOldPassword.Text == "" || txtNewPassword.Text == "" || txtRepassword.Text == "")
            {
                MessageBox.Show("Vérifier les valeurs.");
                return;
            }
            if(txtOldPassword.Text != admin.Passwword)
            {
                MessageBox.Show("Ancien mot de passe incorrect.");
                return;
            }
            if (txtNewPassword.Text != txtRepassword.Text)
            {
                MessageBox.Show("Les mots de passe que vous avez entrés ne correspondent pas.");
                return;
            }

            try
            {
                mPreferencesDAO.UpdatePassword(txtNewPassword.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("les valeurs n'ont pas été mises à jour. " + ex.Message);
                return;
            }
            initFields();
            MessageBox.Show("les valeurs ont été mises à jour.");
            ClearPassword();
        }

        private void ClearPassword()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtRepassword.Text = "";
        }
    }
}
