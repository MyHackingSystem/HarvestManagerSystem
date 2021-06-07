
namespace HarvestManagerSystem.view
{
    partial class FormPreferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPenaltyGeneral = new System.Windows.Forms.TextBox();
            this.txtfxDamageGeneral = new System.Windows.Forms.TextBox();
            this.txtHourPrice = new System.Windows.Forms.TextBox();
            this.txtTransportPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdatePreferencesButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRepassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPenaltyGeneral
            // 
            this.txtPenaltyGeneral.Location = new System.Drawing.Point(192, 181);
            this.txtPenaltyGeneral.Name = "txtPenaltyGeneral";
            this.txtPenaltyGeneral.Size = new System.Drawing.Size(142, 23);
            this.txtPenaltyGeneral.TabIndex = 0;
            // 
            // txtfxDamageGeneral
            // 
            this.txtfxDamageGeneral.Location = new System.Drawing.Point(192, 232);
            this.txtfxDamageGeneral.Name = "txtfxDamageGeneral";
            this.txtfxDamageGeneral.Size = new System.Drawing.Size(142, 23);
            this.txtfxDamageGeneral.TabIndex = 1;
            // 
            // txtHourPrice
            // 
            this.txtHourPrice.Location = new System.Drawing.Point(192, 285);
            this.txtHourPrice.Name = "txtHourPrice";
            this.txtHourPrice.Size = new System.Drawing.Size(142, 23);
            this.txtHourPrice.TabIndex = 2;
            // 
            // txtTransportPrice
            // 
            this.txtTransportPrice.Location = new System.Drawing.Point(192, 336);
            this.txtTransportPrice.Name = "txtTransportPrice";
            this.txtTransportPrice.Size = new System.Drawing.Size(142, 23);
            this.txtTransportPrice.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Penalty General:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(61, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Defective General:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(61, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prix Heure:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(61, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Prix Transport:";
            // 
            // UpdatePreferencesButton
            // 
            this.UpdatePreferencesButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UpdatePreferencesButton.Location = new System.Drawing.Point(159, 408);
            this.UpdatePreferencesButton.Name = "UpdatePreferencesButton";
            this.UpdatePreferencesButton.Size = new System.Drawing.Size(120, 35);
            this.UpdatePreferencesButton.TabIndex = 8;
            this.UpdatePreferencesButton.Text = "Valider";
            this.UpdatePreferencesButton.UseVisualStyleBackColor = true;
            this.UpdatePreferencesButton.Click += new System.EventHandler(this.UpdatePreferencesButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnUpdatePassword);
            this.panel1.Controls.Add(this.txtOldPassword);
            this.panel1.Controls.Add(this.txtNewPassword);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtRepassword);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(462, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 644);
            this.panel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(76, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ancien mot de passe";
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdatePassword.Location = new System.Drawing.Point(170, 408);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(120, 35);
            this.btnUpdatePassword.TabIndex = 17;
            this.btnUpdatePassword.Text = "Valider";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(232, 214);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(142, 23);
            this.txtOldPassword.TabIndex = 9;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(232, 265);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(142, 23);
            this.txtNewPassword.TabIndex = 10;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(43, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Confirmez le mot de passe";
            // 
            // txtRepassword
            // 
            this.txtRepassword.Location = new System.Drawing.Point(232, 318);
            this.txtRepassword.Name = "txtRepassword";
            this.txtRepassword.PasswordChar = '*';
            this.txtRepassword.Size = new System.Drawing.Size(142, 23);
            this.txtRepassword.TabIndex = 11;
            this.txtRepassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(65, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Nouveau mot de passe";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.UpdatePreferencesButton);
            this.panel2.Controls.Add(this.txtPenaltyGeneral);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtfxDamageGeneral);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtHourPrice);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTransportPrice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 644);
            this.panel2.TabIndex = 10;
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(933, 644);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormPreferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPenaltyGeneral;
        private System.Windows.Forms.TextBox txtfxDamageGeneral;
        private System.Windows.Forms.TextBox txtHourPrice;
        private System.Windows.Forms.TextBox txtTransportPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UpdatePreferencesButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRepassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
    }
}