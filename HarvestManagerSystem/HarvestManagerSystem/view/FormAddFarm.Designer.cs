
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFarm));
            this.btnClearReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbxFarmName = new System.Windows.Forms.ComboBox();
            this.ChampLabel = new System.Windows.Forms.Label();
            this.nameFarmErrorLabel = new System.Windows.Forms.Label();
            this.addressFarmErrorLabel = new System.Windows.Forms.Label();
            this.txtFarmAddress = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.dateHarvestDate = new System.Windows.Forms.DateTimePicker();
            this.datePlantingDate = new System.Windows.Forms.DateTimePicker();
            this.HarvestLabel = new System.Windows.Forms.Label();
            this.PlantationLabel = new System.Windows.Forms.Label();
            this.pnlAddFarm = new System.Windows.Forms.Panel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlDisplayFarm = new System.Windows.Forms.Panel();
            this.panelDisplayFarm = new System.Windows.Forms.Panel();
            this.FarmDataGridView = new System.Windows.Forms.DataGridView();
            this.FarmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDisplaySeason = new System.Windows.Forms.Panel();
            this.SeasonDataGridView = new System.Windows.Forms.DataGridView();
            this.SeasonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeasonPlantingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeasonHarvestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Farm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAddFarm.SuspendLayout();
            this.pnlDisplayFarm.SuspendLayout();
            this.panelDisplayFarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FarmDataGridView)).BeginInit();
            this.pnlDisplaySeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClearReset
            // 
            this.btnClearReset.BackColor = System.Drawing.Color.DarkOrange;
            this.btnClearReset.FlatAppearance.BorderSize = 0;
            this.btnClearReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnClearReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnClearReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearReset.Location = new System.Drawing.Point(138, 469);
            this.btnClearReset.Name = "btnClearReset";
            this.btnClearReset.Size = new System.Drawing.Size(90, 30);
            this.btnClearReset.TabIndex = 6;
            this.btnClearReset.Text = "Vider";
            this.btnClearReset.UseVisualStyleBackColor = false;
            this.btnClearReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(19, 469);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Ajouter";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cmbxFarmName
            // 
            this.cmbxFarmName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxFarmName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxFarmName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbxFarmName.FormattingEnabled = true;
            this.cmbxFarmName.Location = new System.Drawing.Point(45, 132);
            this.cmbxFarmName.Name = "cmbxFarmName";
            this.cmbxFarmName.Size = new System.Drawing.Size(160, 29);
            this.cmbxFarmName.TabIndex = 1;
            this.cmbxFarmName.SelectedIndexChanged += new System.EventHandler(this.FarmNameComboBox_SelectedIndexChanged);
            // 
            // ChampLabel
            // 
            this.ChampLabel.AutoSize = true;
            this.ChampLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChampLabel.ForeColor = System.Drawing.Color.White;
            this.ChampLabel.Location = new System.Drawing.Point(45, 107);
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
            this.nameFarmErrorLabel.Location = new System.Drawing.Point(187, 107);
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
            this.addressFarmErrorLabel.Location = new System.Drawing.Point(187, 175);
            this.addressFarmErrorLabel.Name = "addressFarmErrorLabel";
            this.addressFarmErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.addressFarmErrorLabel.TabIndex = 32;
            this.addressFarmErrorLabel.Text = "*";
            this.addressFarmErrorLabel.Visible = false;
            // 
            // txtFarmAddress
            // 
            this.txtFarmAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFarmAddress.Location = new System.Drawing.Point(45, 201);
            this.txtFarmAddress.Name = "txtFarmAddress";
            this.txtFarmAddress.Size = new System.Drawing.Size(160, 29);
            this.txtFarmAddress.TabIndex = 2;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.AddressLabel.Location = new System.Drawing.Point(45, 177);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(68, 21);
            this.AddressLabel.TabIndex = 34;
            this.AddressLabel.Text = "Adresse:";
            // 
            // dateHarvestDate
            // 
            this.dateHarvestDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHarvestDate.Location = new System.Drawing.Point(45, 352);
            this.dateHarvestDate.Name = "dateHarvestDate";
            this.dateHarvestDate.Size = new System.Drawing.Size(160, 23);
            this.dateHarvestDate.TabIndex = 4;
            // 
            // datePlantingDate
            // 
            this.datePlantingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePlantingDate.Location = new System.Drawing.Point(45, 279);
            this.datePlantingDate.Name = "datePlantingDate";
            this.datePlantingDate.Size = new System.Drawing.Size(160, 23);
            this.datePlantingDate.TabIndex = 3;
            // 
            // HarvestLabel
            // 
            this.HarvestLabel.AutoSize = true;
            this.HarvestLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HarvestLabel.ForeColor = System.Drawing.Color.White;
            this.HarvestLabel.Location = new System.Drawing.Point(45, 328);
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
            this.PlantationLabel.Location = new System.Drawing.Point(45, 254);
            this.PlantationLabel.Name = "PlantationLabel";
            this.PlantationLabel.Size = new System.Drawing.Size(83, 21);
            this.PlantationLabel.TabIndex = 37;
            this.PlantationLabel.Text = "Plantation:";
            // 
            // pnlAddFarm
            // 
            this.pnlAddFarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAddFarm.Controls.Add(this.ChampLabel);
            this.pnlAddFarm.Controls.Add(this.dateHarvestDate);
            this.pnlAddFarm.Controls.Add(this.datePlantingDate);
            this.pnlAddFarm.Controls.Add(this.HarvestLabel);
            this.pnlAddFarm.Controls.Add(this.cmbxFarmName);
            this.pnlAddFarm.Controls.Add(this.PlantationLabel);
            this.pnlAddFarm.Controls.Add(this.btnSave);
            this.pnlAddFarm.Controls.Add(this.AddressLabel);
            this.pnlAddFarm.Controls.Add(this.btnCloseForm);
            this.pnlAddFarm.Controls.Add(this.btnDelete);
            this.pnlAddFarm.Controls.Add(this.btnClearReset);
            this.pnlAddFarm.Controls.Add(this.txtFarmAddress);
            this.pnlAddFarm.Controls.Add(this.nameFarmErrorLabel);
            this.pnlAddFarm.Controls.Add(this.addressFarmErrorLabel);
            this.pnlAddFarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAddFarm.Location = new System.Drawing.Point(0, 0);
            this.pnlAddFarm.Name = "pnlAddFarm";
            this.pnlAddFarm.Size = new System.Drawing.Size(250, 618);
            this.pnlAddFarm.TabIndex = 39;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.Red;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnCloseForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseForm.Location = new System.Drawing.Point(12, 12);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(30, 30);
            this.btnCloseForm.TabIndex = 6;
            this.btnCloseForm.Text = "X";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(19, 536);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(209, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlDisplayFarm
            // 
            this.pnlDisplayFarm.Controls.Add(this.panelDisplayFarm);
            this.pnlDisplayFarm.Controls.Add(this.pnlDisplaySeason);
            this.pnlDisplayFarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayFarm.Location = new System.Drawing.Point(250, 0);
            this.pnlDisplayFarm.Name = "pnlDisplayFarm";
            this.pnlDisplayFarm.Size = new System.Drawing.Size(757, 618);
            this.pnlDisplayFarm.TabIndex = 40;
            // 
            // panelDisplayFarm
            // 
            this.panelDisplayFarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDisplayFarm.Controls.Add(this.FarmDataGridView);
            this.panelDisplayFarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplayFarm.Location = new System.Drawing.Point(0, 0);
            this.panelDisplayFarm.Name = "panelDisplayFarm";
            this.panelDisplayFarm.Size = new System.Drawing.Size(497, 618);
            this.panelDisplayFarm.TabIndex = 1;
            // 
            // FarmDataGridView
            // 
            this.FarmDataGridView.AllowUserToAddRows = false;
            this.FarmDataGridView.AllowUserToDeleteRows = false;
            this.FarmDataGridView.AllowUserToOrderColumns = true;
            this.FarmDataGridView.AllowUserToResizeColumns = false;
            this.FarmDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.FarmDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.FarmDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FarmDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FarmDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FarmDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FarmDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.FarmDataGridView.ColumnHeadersHeight = 36;
            this.FarmDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.FarmDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FarmId,
            this.FarmName,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FarmDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.FarmDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FarmDataGridView.EnableHeadersVisualStyles = false;
            this.FarmDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FarmDataGridView.Location = new System.Drawing.Point(0, 0);
            this.FarmDataGridView.Name = "FarmDataGridView";
            this.FarmDataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FarmDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.FarmDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.FarmDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.FarmDataGridView.RowTemplate.Height = 25;
            this.FarmDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FarmDataGridView.Size = new System.Drawing.Size(493, 614);
            this.FarmDataGridView.TabIndex = 3;
            this.FarmDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FarmDataGridView_CellDoubleClick);
            this.FarmDataGridView.SelectionChanged += new System.EventHandler(this.FarmtDataGridView_SelectionChanged);
            // 
            // FarmId
            // 
            this.FarmId.DataPropertyName = "FarmId";
            this.FarmId.HeaderText = "FarmId";
            this.FarmId.Name = "FarmId";
            this.FarmId.ReadOnly = true;
            this.FarmId.Visible = false;
            // 
            // FarmName
            // 
            this.FarmName.DataPropertyName = "FarmName";
            this.FarmName.HeaderText = "Champs";
            this.FarmName.MinimumWidth = 200;
            this.FarmName.Name = "FarmName";
            this.FarmName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FarmAddress";
            this.dataGridViewTextBoxColumn1.HeaderText = "Adresse";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 300;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // pnlDisplaySeason
            // 
            this.pnlDisplaySeason.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplaySeason.Controls.Add(this.SeasonDataGridView);
            this.pnlDisplaySeason.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDisplaySeason.Location = new System.Drawing.Point(497, 0);
            this.pnlDisplaySeason.Name = "pnlDisplaySeason";
            this.pnlDisplaySeason.Size = new System.Drawing.Size(260, 618);
            this.pnlDisplaySeason.TabIndex = 0;
            // 
            // SeasonDataGridView
            // 
            this.SeasonDataGridView.AllowUserToAddRows = false;
            this.SeasonDataGridView.AllowUserToDeleteRows = false;
            this.SeasonDataGridView.AllowUserToOrderColumns = true;
            this.SeasonDataGridView.AllowUserToResizeColumns = false;
            this.SeasonDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.SeasonDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.SeasonDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SeasonDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SeasonDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeasonDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.SeasonDataGridView.ColumnHeadersHeight = 36;
            this.SeasonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SeasonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeasonId,
            this.SeasonPlantingDate,
            this.SeasonHarvestDate,
            this.Farm});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SeasonDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.SeasonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeasonDataGridView.EnableHeadersVisualStyles = false;
            this.SeasonDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SeasonDataGridView.Location = new System.Drawing.Point(0, 0);
            this.SeasonDataGridView.MultiSelect = false;
            this.SeasonDataGridView.Name = "SeasonDataGridView";
            this.SeasonDataGridView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.SeasonDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.SeasonDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.SeasonDataGridView.RowTemplate.Height = 25;
            this.SeasonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SeasonDataGridView.Size = new System.Drawing.Size(256, 614);
            this.SeasonDataGridView.TabIndex = 5;
            this.SeasonDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SeasonDataGridView_CellDoubleClick);
            // 
            // SeasonId
            // 
            this.SeasonId.DataPropertyName = "SeasonId";
            this.SeasonId.HeaderText = "Season Id";
            this.SeasonId.Name = "SeasonId";
            this.SeasonId.ReadOnly = true;
            this.SeasonId.Visible = false;
            // 
            // SeasonPlantingDate
            // 
            this.SeasonPlantingDate.DataPropertyName = "SeasonPlantingDate";
            this.SeasonPlantingDate.HeaderText = "Date de plantation ";
            this.SeasonPlantingDate.Name = "SeasonPlantingDate";
            this.SeasonPlantingDate.ReadOnly = true;
            // 
            // SeasonHarvestDate
            // 
            this.SeasonHarvestDate.DataPropertyName = "SeasonHarvestDate";
            this.SeasonHarvestDate.HeaderText = "Date de récolte ";
            this.SeasonHarvestDate.Name = "SeasonHarvestDate";
            this.SeasonHarvestDate.ReadOnly = true;
            // 
            // Farm
            // 
            this.Farm.DataPropertyName = "FarmID";
            this.Farm.HeaderText = "Farm ID";
            this.Farm.Name = "Farm";
            this.Farm.ReadOnly = true;
            this.Farm.Visible = false;
            // 
            // FormAddFarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1007, 618);
            this.Controls.Add(this.pnlDisplayFarm);
            this.Controls.Add(this.pnlAddFarm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddFarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddFarm";
            this.Load += new System.EventHandler(this.FormAddFarm_Load);
            this.pnlAddFarm.ResumeLayout(false);
            this.pnlAddFarm.PerformLayout();
            this.pnlDisplayFarm.ResumeLayout(false);
            this.panelDisplayFarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FarmDataGridView)).EndInit();
            this.pnlDisplaySeason.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SeasonDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClearReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbxFarmName;
        private System.Windows.Forms.Label ChampLabel;
        private System.Windows.Forms.Label nameFarmErrorLabel;
        private System.Windows.Forms.Label addressFarmErrorLabel;
        private System.Windows.Forms.TextBox txtFarmAddress;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.DateTimePicker dateHarvestDate;
        private System.Windows.Forms.DateTimePicker datePlantingDate;
        private System.Windows.Forms.Label HarvestLabel;
        private System.Windows.Forms.Label PlantationLabel;
        private System.Windows.Forms.Panel pnlAddFarm;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Panel pnlDisplayFarm;
        private System.Windows.Forms.Panel panelDisplayFarm;
        private System.Windows.Forms.Panel pnlDisplaySeason;
        private System.Windows.Forms.DataGridView SeasonDataGridView;
        private System.Windows.Forms.DataGridView FarmDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeasonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeasonPlantingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeasonHarvestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Farm;
    }
}