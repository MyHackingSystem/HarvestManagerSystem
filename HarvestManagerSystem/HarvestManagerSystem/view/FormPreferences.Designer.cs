
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
            this.SuspendLayout();
            // 
            // txtPenaltyGeneral
            // 
            this.txtPenaltyGeneral.Location = new System.Drawing.Point(191, 91);
            this.txtPenaltyGeneral.Name = "txtPenaltyGeneral";
            this.txtPenaltyGeneral.Size = new System.Drawing.Size(100, 23);
            this.txtPenaltyGeneral.TabIndex = 0;
            // 
            // txtfxDamageGeneral
            // 
            this.txtfxDamageGeneral.Location = new System.Drawing.Point(191, 142);
            this.txtfxDamageGeneral.Name = "txtfxDamageGeneral";
            this.txtfxDamageGeneral.Size = new System.Drawing.Size(100, 23);
            this.txtfxDamageGeneral.TabIndex = 1;
            // 
            // txtHourPrice
            // 
            this.txtHourPrice.Location = new System.Drawing.Point(191, 195);
            this.txtHourPrice.Name = "txtHourPrice";
            this.txtHourPrice.Size = new System.Drawing.Size(100, 23);
            this.txtHourPrice.TabIndex = 2;
            // 
            // txtTransportPrice
            // 
            this.txtTransportPrice.Location = new System.Drawing.Point(191, 246);
            this.txtTransportPrice.Name = "txtTransportPrice";
            this.txtTransportPrice.Size = new System.Drawing.Size(100, 23);
            this.txtTransportPrice.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 97);
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
            this.label2.Location = new System.Drawing.Point(60, 150);
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
            this.label3.Location = new System.Drawing.Point(60, 198);
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
            this.label4.Location = new System.Drawing.Point(60, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Prix Transport:";
            // 
            // UpdatePreferencesButton
            // 
            this.UpdatePreferencesButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UpdatePreferencesButton.Location = new System.Drawing.Point(132, 345);
            this.UpdatePreferencesButton.Name = "UpdatePreferencesButton";
            this.UpdatePreferencesButton.Size = new System.Drawing.Size(92, 31);
            this.UpdatePreferencesButton.TabIndex = 8;
            this.UpdatePreferencesButton.Text = "Valider";
            this.UpdatePreferencesButton.UseVisualStyleBackColor = true;
            this.UpdatePreferencesButton.Click += new System.EventHandler(this.UpdatePreferencesButton_Click);
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.UpdatePreferencesButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTransportPrice);
            this.Controls.Add(this.txtHourPrice);
            this.Controls.Add(this.txtfxDamageGeneral);
            this.Controls.Add(this.txtPenaltyGeneral);
            this.Name = "FormPreferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPreferences_FormClosed);
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}