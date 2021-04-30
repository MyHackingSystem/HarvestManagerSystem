
namespace HarvestManagerSystem.view
{
    partial class FormAddFarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFarm));
            this.btnReset = new System.Windows.Forms.Button();
            this.handleSaveButton = new System.Windows.Forms.Button();
            this.FarmNameComboBox = new System.Windows.Forms.ComboBox();
            this.ChampLabel = new System.Windows.Forms.Label();
            this.nameFarmErrorLabel = new System.Windows.Forms.Label();
            this.addressFarmErrorLabel = new System.Windows.Forms.Label();
            this.FarmAddress = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.HarvestDate = new System.Windows.Forms.DateTimePicker();
            this.PlantingDate = new System.Windows.Forms.DateTimePicker();
            this.HarvestLabel = new System.Windows.Forms.Label();
            this.PlantationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DarkOrange;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(196, 436);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 30);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // handleSaveButton
            // 
            this.handleSaveButton.BackColor = System.Drawing.Color.DarkOrange;
            this.handleSaveButton.FlatAppearance.BorderSize = 0;
            this.handleSaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.handleSaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.handleSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.handleSaveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.handleSaveButton.Location = new System.Drawing.Point(26, 436);
            this.handleSaveButton.Name = "handleSaveButton";
            this.handleSaveButton.Size = new System.Drawing.Size(120, 30);
            this.handleSaveButton.TabIndex = 5;
            this.handleSaveButton.Text = "Ajouter";
            this.handleSaveButton.UseVisualStyleBackColor = false;
            this.handleSaveButton.Click += new System.EventHandler(this.handleSaveButton_Click);
            // 
            // FarmNameComboBox
            // 
            this.FarmNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.FarmNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FarmNameComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FarmNameComboBox.FormattingEnabled = true;
            this.FarmNameComboBox.Location = new System.Drawing.Point(107, 112);
            this.FarmNameComboBox.Name = "FarmNameComboBox";
            this.FarmNameComboBox.Size = new System.Drawing.Size(160, 29);
            this.FarmNameComboBox.TabIndex = 1;
            this.FarmNameComboBox.SelectedIndexChanged += new System.EventHandler(this.FarmNameComboBox_SelectedIndexChanged);
            // 
            // ChampLabel
            // 
            this.ChampLabel.AutoSize = true;
            this.ChampLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChampLabel.ForeColor = System.Drawing.Color.White;
            this.ChampLabel.Location = new System.Drawing.Point(107, 87);
            this.ChampLabel.Name = "ChampLabel";
            this.ChampLabel.Size = new System.Drawing.Size(63, 21);
            this.ChampLabel.TabIndex = 29;
            this.ChampLabel.Text = "Champ:";
            // 
            // nameFarmErrorLabel
            // 
            this.nameFarmErrorLabel.AutoSize = true;
            this.nameFarmErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameFarmErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.nameFarmErrorLabel.Location = new System.Drawing.Point(249, 87);
            this.nameFarmErrorLabel.Name = "nameFarmErrorLabel";
            this.nameFarmErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.nameFarmErrorLabel.TabIndex = 31;
            this.nameFarmErrorLabel.Text = "*";
            this.nameFarmErrorLabel.Visible = false;
            // 
            // addressFarmErrorLabel
            // 
            this.addressFarmErrorLabel.AutoSize = true;
            this.addressFarmErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressFarmErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.addressFarmErrorLabel.Location = new System.Drawing.Point(249, 155);
            this.addressFarmErrorLabel.Name = "addressFarmErrorLabel";
            this.addressFarmErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.addressFarmErrorLabel.TabIndex = 32;
            this.addressFarmErrorLabel.Text = "*";
            this.addressFarmErrorLabel.Visible = false;
            // 
            // FarmAddress
            // 
            this.FarmAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FarmAddress.Location = new System.Drawing.Point(107, 181);
            this.FarmAddress.Name = "FarmAddress";
            this.FarmAddress.Size = new System.Drawing.Size(160, 29);
            this.FarmAddress.TabIndex = 2;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.AddressLabel.Location = new System.Drawing.Point(107, 157);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(68, 21);
            this.AddressLabel.TabIndex = 34;
            this.AddressLabel.Text = "Adresse:";
            // 
            // HarvestDate
            // 
            this.HarvestDate.Location = new System.Drawing.Point(107, 332);
            this.HarvestDate.Name = "HarvestDate";
            this.HarvestDate.Size = new System.Drawing.Size(160, 23);
            this.HarvestDate.TabIndex = 4;
            // 
            // PlantingDate
            // 
            this.PlantingDate.Location = new System.Drawing.Point(107, 259);
            this.PlantingDate.Name = "PlantingDate";
            this.PlantingDate.Size = new System.Drawing.Size(160, 23);
            this.PlantingDate.TabIndex = 3;
            // 
            // HarvestLabel
            // 
            this.HarvestLabel.AutoSize = true;
            this.HarvestLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HarvestLabel.ForeColor = System.Drawing.Color.White;
            this.HarvestLabel.Location = new System.Drawing.Point(107, 308);
            this.HarvestLabel.Name = "HarvestLabel";
            this.HarvestLabel.Size = new System.Drawing.Size(64, 21);
            this.HarvestLabel.TabIndex = 38;
            this.HarvestLabel.Text = "Récolte:";
            // 
            // PlantationLabel
            // 
            this.PlantationLabel.AutoSize = true;
            this.PlantationLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlantationLabel.ForeColor = System.Drawing.Color.White;
            this.PlantationLabel.Location = new System.Drawing.Point(107, 234);
            this.PlantationLabel.Name = "PlantationLabel";
            this.PlantationLabel.Size = new System.Drawing.Size(83, 21);
            this.PlantationLabel.TabIndex = 37;
            this.PlantationLabel.Text = "Plantation:";
            // 
            // FormAddFarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.HarvestDate);
            this.Controls.Add(this.PlantingDate);
            this.Controls.Add(this.HarvestLabel);
            this.Controls.Add(this.PlantationLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.FarmAddress);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.handleSaveButton);
            this.Controls.Add(this.FarmNameComboBox);
            this.Controls.Add(this.ChampLabel);
            this.Controls.Add(this.nameFarmErrorLabel);
            this.Controls.Add(this.addressFarmErrorLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddFarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddFarm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddProduct_FormClosed);
            this.Load += new System.EventHandler(this.FormAddFarm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button handleSaveButton;
        private System.Windows.Forms.ComboBox FarmNameComboBox;
        private System.Windows.Forms.Label ChampLabel;
        private System.Windows.Forms.Label nameFarmErrorLabel;
        private System.Windows.Forms.Label addressFarmErrorLabel;
        private System.Windows.Forms.TextBox FarmAddress;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.DateTimePicker HarvestDate;
        private System.Windows.Forms.DateTimePicker PlantingDate;
        private System.Windows.Forms.Label HarvestLabel;
        private System.Windows.Forms.Label PlantationLabel;
    }
}