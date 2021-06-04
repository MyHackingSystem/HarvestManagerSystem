
namespace HarvestManagerSystem.view
{
    partial class FormAddCredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddCredit));
            this.btnReset = new System.Windows.Forms.Button();
            this.handleSaveButton = new System.Windows.Forms.Button();
            this.CreditAmountTextBox = new System.Windows.Forms.TextBox();
            this.CreditEmployeeComboBox = new System.Windows.Forms.ComboBox();
            this.creditPriceLabel = new System.Windows.Forms.Label();
            this.EmployeeLabel = new System.Windows.Forms.Label();
            this.creditEmployeeErrorLabel = new System.Windows.Forms.Label();
            this.creditAmountErrorLabel = new System.Windows.Forms.Label();
            this.CreditDatePicker = new System.Windows.Forms.DateTimePicker();
            this.creditDateLabel = new System.Windows.Forms.Label();
            this.pnlAddCredit = new System.Windows.Forms.Panel();
            this.pnlDisplayCredit = new System.Windows.Forms.Panel();
            this.TransportDataGridView = new System.Windows.Forms.DataGridView();
            this.TransportIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportEmployeeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportFarmColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDisplayTransport = new System.Windows.Forms.Panel();
            this.CreditDataGridView = new System.Windows.Forms.DataGridView();
            this.CreditIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditEmployeeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAddCredit.SuspendLayout();
            this.pnlDisplayCredit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransportDataGridView)).BeginInit();
            this.pnlDisplayTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreditDataGridView)).BeginInit();
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
            this.btnReset.Location = new System.Drawing.Point(126, 452);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 30);
            this.btnReset.TabIndex = 29;
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
            this.handleSaveButton.Location = new System.Drawing.Point(16, 452);
            this.handleSaveButton.Name = "handleSaveButton";
            this.handleSaveButton.Size = new System.Drawing.Size(90, 30);
            this.handleSaveButton.TabIndex = 28;
            this.handleSaveButton.Text = "Ajouter";
            this.handleSaveButton.UseVisualStyleBackColor = false;
            this.handleSaveButton.Click += new System.EventHandler(this.handleSaveButton_Click);
            // 
            // CreditAmountTextBox
            // 
            this.CreditAmountTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreditAmountTextBox.Location = new System.Drawing.Point(16, 334);
            this.CreditAmountTextBox.Name = "CreditAmountTextBox";
            this.CreditAmountTextBox.Size = new System.Drawing.Size(200, 29);
            this.CreditAmountTextBox.TabIndex = 27;
            this.CreditAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberEntred);
            // 
            // CreditEmployeeComboBox
            // 
            this.CreditEmployeeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CreditEmployeeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CreditEmployeeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditEmployeeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreditEmployeeComboBox.FormattingEnabled = true;
            this.CreditEmployeeComboBox.Location = new System.Drawing.Point(16, 250);
            this.CreditEmployeeComboBox.MinimumSize = new System.Drawing.Size(180, 0);
            this.CreditEmployeeComboBox.Name = "CreditEmployeeComboBox";
            this.CreditEmployeeComboBox.Size = new System.Drawing.Size(200, 29);
            this.CreditEmployeeComboBox.TabIndex = 26;
            // 
            // creditPriceLabel
            // 
            this.creditPriceLabel.AutoSize = true;
            this.creditPriceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.creditPriceLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.creditPriceLabel.Location = new System.Drawing.Point(16, 310);
            this.creditPriceLabel.Name = "creditPriceLabel";
            this.creditPriceLabel.Size = new System.Drawing.Size(72, 21);
            this.creditPriceLabel.TabIndex = 32;
            this.creditPriceLabel.Text = "Montant:";
            // 
            // EmployeeLabel
            // 
            this.EmployeeLabel.AutoSize = true;
            this.EmployeeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmployeeLabel.ForeColor = System.Drawing.Color.White;
            this.EmployeeLabel.Location = new System.Drawing.Point(16, 225);
            this.EmployeeLabel.Name = "EmployeeLabel";
            this.EmployeeLabel.Size = new System.Drawing.Size(81, 21);
            this.EmployeeLabel.TabIndex = 31;
            this.EmployeeLabel.Text = "Employee:";
            // 
            // creditEmployeeErrorLabel
            // 
            this.creditEmployeeErrorLabel.AutoSize = true;
            this.creditEmployeeErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.creditEmployeeErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.creditEmployeeErrorLabel.Location = new System.Drawing.Point(188, 225);
            this.creditEmployeeErrorLabel.Name = "creditEmployeeErrorLabel";
            this.creditEmployeeErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.creditEmployeeErrorLabel.TabIndex = 33;
            this.creditEmployeeErrorLabel.Text = "*";
            this.creditEmployeeErrorLabel.Visible = false;
            // 
            // creditAmountErrorLabel
            // 
            this.creditAmountErrorLabel.AutoSize = true;
            this.creditAmountErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.creditAmountErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.creditAmountErrorLabel.Location = new System.Drawing.Point(188, 310);
            this.creditAmountErrorLabel.Name = "creditAmountErrorLabel";
            this.creditAmountErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.creditAmountErrorLabel.TabIndex = 34;
            this.creditAmountErrorLabel.Text = "*";
            this.creditAmountErrorLabel.Visible = false;
            // 
            // CreditDatePicker
            // 
            this.CreditDatePicker.Location = new System.Drawing.Point(16, 170);
            this.CreditDatePicker.Name = "CreditDatePicker";
            this.CreditDatePicker.Size = new System.Drawing.Size(200, 23);
            this.CreditDatePicker.TabIndex = 35;
            // 
            // creditDateLabel
            // 
            this.creditDateLabel.AutoSize = true;
            this.creditDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.creditDateLabel.ForeColor = System.Drawing.Color.White;
            this.creditDateLabel.Location = new System.Drawing.Point(16, 146);
            this.creditDateLabel.Name = "creditDateLabel";
            this.creditDateLabel.Size = new System.Drawing.Size(42, 21);
            this.creditDateLabel.TabIndex = 36;
            this.creditDateLabel.Text = "Date";
            // 
            // pnlAddCredit
            // 
            this.pnlAddCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAddCredit.Controls.Add(this.creditDateLabel);
            this.pnlAddCredit.Controls.Add(this.CreditDatePicker);
            this.pnlAddCredit.Controls.Add(this.btnReset);
            this.pnlAddCredit.Controls.Add(this.EmployeeLabel);
            this.pnlAddCredit.Controls.Add(this.handleSaveButton);
            this.pnlAddCredit.Controls.Add(this.creditPriceLabel);
            this.pnlAddCredit.Controls.Add(this.CreditAmountTextBox);
            this.pnlAddCredit.Controls.Add(this.CreditEmployeeComboBox);
            this.pnlAddCredit.Controls.Add(this.creditEmployeeErrorLabel);
            this.pnlAddCredit.Controls.Add(this.creditAmountErrorLabel);
            this.pnlAddCredit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAddCredit.Location = new System.Drawing.Point(0, 0);
            this.pnlAddCredit.Name = "pnlAddCredit";
            this.pnlAddCredit.Size = new System.Drawing.Size(245, 687);
            this.pnlAddCredit.TabIndex = 37;
            this.pnlAddCredit.Visible = false;
            // 
            // pnlDisplayCredit
            // 
            this.pnlDisplayCredit.AutoScroll = true;
            this.pnlDisplayCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplayCredit.Controls.Add(this.TransportDataGridView);
            this.pnlDisplayCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayCredit.Location = new System.Drawing.Point(245, 0);
            this.pnlDisplayCredit.Name = "pnlDisplayCredit";
            this.pnlDisplayCredit.Size = new System.Drawing.Size(533, 687);
            this.pnlDisplayCredit.TabIndex = 38;
            // 
            // TransportDataGridView
            // 
            this.TransportDataGridView.AllowUserToAddRows = false;
            this.TransportDataGridView.AllowUserToDeleteRows = false;
            this.TransportDataGridView.AllowUserToOrderColumns = true;
            this.TransportDataGridView.AllowUserToResizeColumns = false;
            this.TransportDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.TransportDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TransportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TransportDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TransportDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TransportDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TransportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TransportDataGridView.ColumnHeadersHeight = 36;
            this.TransportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TransportDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransportIdColumn,
            this.TransportDateColumn,
            this.TransportEmployeeColumn,
            this.TransportAmountColumn,
            this.TransportFarmColumn,
            this.dataGridViewTextBoxColumn2,
            this.FarmColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TransportDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.TransportDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransportDataGridView.EnableHeadersVisualStyles = false;
            this.TransportDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TransportDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TransportDataGridView.Name = "TransportDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TransportDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.TransportDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.TransportDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.TransportDataGridView.RowTemplate.Height = 25;
            this.TransportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TransportDataGridView.Size = new System.Drawing.Size(529, 683);
            this.TransportDataGridView.TabIndex = 5;
            // 
            // TransportIdColumn
            // 
            this.TransportIdColumn.DataPropertyName = "TransportId";
            this.TransportIdColumn.HeaderText = "TransportId";
            this.TransportIdColumn.Name = "TransportIdColumn";
            this.TransportIdColumn.Visible = false;
            // 
            // TransportDateColumn
            // 
            this.TransportDateColumn.DataPropertyName = "TransportDate";
            this.TransportDateColumn.HeaderText = "Date";
            this.TransportDateColumn.MinimumWidth = 80;
            this.TransportDateColumn.Name = "TransportDateColumn";
            this.TransportDateColumn.ReadOnly = true;
            // 
            // TransportEmployeeColumn
            // 
            this.TransportEmployeeColumn.DataPropertyName = "EmployeeName";
            this.TransportEmployeeColumn.HeaderText = "Employée";
            this.TransportEmployeeColumn.MinimumWidth = 140;
            this.TransportEmployeeColumn.Name = "TransportEmployeeColumn";
            this.TransportEmployeeColumn.ReadOnly = true;
            // 
            // TransportAmountColumn
            // 
            this.TransportAmountColumn.DataPropertyName = "TransportAmount";
            this.TransportAmountColumn.HeaderText = "Transport";
            this.TransportAmountColumn.MinimumWidth = 100;
            this.TransportAmountColumn.Name = "TransportAmountColumn";
            this.TransportAmountColumn.ReadOnly = true;
            // 
            // TransportFarmColumn
            // 
            this.TransportFarmColumn.DataPropertyName = "FarmName";
            this.TransportFarmColumn.HeaderText = "Farm";
            this.TransportFarmColumn.MinimumWidth = 140;
            this.TransportFarmColumn.Name = "TransportFarmColumn";
            this.TransportFarmColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Employee";
            this.dataGridViewTextBoxColumn2.HeaderText = "EmployeeColumn";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // FarmColumn
            // 
            this.FarmColumn.DataPropertyName = "Farm";
            this.FarmColumn.HeaderText = "FarmColumn";
            this.FarmColumn.Name = "FarmColumn";
            this.FarmColumn.Visible = false;
            // 
            // pnlDisplayTransport
            // 
            this.pnlDisplayTransport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplayTransport.Controls.Add(this.CreditDataGridView);
            this.pnlDisplayTransport.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDisplayTransport.Location = new System.Drawing.Point(778, 0);
            this.pnlDisplayTransport.Name = "pnlDisplayTransport";
            this.pnlDisplayTransport.Size = new System.Drawing.Size(386, 687);
            this.pnlDisplayTransport.TabIndex = 39;
            // 
            // CreditDataGridView
            // 
            this.CreditDataGridView.AllowUserToAddRows = false;
            this.CreditDataGridView.AllowUserToDeleteRows = false;
            this.CreditDataGridView.AllowUserToOrderColumns = true;
            this.CreditDataGridView.AllowUserToResizeColumns = false;
            this.CreditDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.CreditDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.CreditDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CreditDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CreditDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CreditDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CreditDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.CreditDataGridView.ColumnHeadersHeight = 36;
            this.CreditDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CreditDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreditIdColumn,
            this.CreditDateColumn,
            this.CreditEmployeeColumn,
            this.CreditAmountColumn,
            this.EmployeeColumn});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CreditDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.CreditDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreditDataGridView.EnableHeadersVisualStyles = false;
            this.CreditDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CreditDataGridView.Location = new System.Drawing.Point(0, 0);
            this.CreditDataGridView.Name = "CreditDataGridView";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CreditDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.CreditDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.CreditDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.CreditDataGridView.RowTemplate.Height = 25;
            this.CreditDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CreditDataGridView.Size = new System.Drawing.Size(382, 683);
            this.CreditDataGridView.TabIndex = 7;
            // 
            // CreditIdColumn
            // 
            this.CreditIdColumn.DataPropertyName = "CreditId";
            this.CreditIdColumn.HeaderText = "CreditId";
            this.CreditIdColumn.Name = "CreditIdColumn";
            this.CreditIdColumn.Visible = false;
            // 
            // CreditDateColumn
            // 
            this.CreditDateColumn.DataPropertyName = "CreditDate";
            this.CreditDateColumn.HeaderText = "Date";
            this.CreditDateColumn.MinimumWidth = 100;
            this.CreditDateColumn.Name = "CreditDateColumn";
            this.CreditDateColumn.ReadOnly = true;
            // 
            // CreditEmployeeColumn
            // 
            this.CreditEmployeeColumn.DataPropertyName = "EmployeeName";
            this.CreditEmployeeColumn.HeaderText = "Employée";
            this.CreditEmployeeColumn.MinimumWidth = 160;
            this.CreditEmployeeColumn.Name = "CreditEmployeeColumn";
            this.CreditEmployeeColumn.ReadOnly = true;
            // 
            // CreditAmountColumn
            // 
            this.CreditAmountColumn.DataPropertyName = "CreditAmount";
            this.CreditAmountColumn.HeaderText = "Credit";
            this.CreditAmountColumn.MinimumWidth = 80;
            this.CreditAmountColumn.Name = "CreditAmountColumn";
            // 
            // EmployeeColumn
            // 
            this.EmployeeColumn.DataPropertyName = "Employee";
            this.EmployeeColumn.HeaderText = "EmployeeColumn";
            this.EmployeeColumn.Name = "EmployeeColumn";
            this.EmployeeColumn.Visible = false;
            // 
            // FormAddCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1164, 687);
            this.Controls.Add(this.pnlDisplayCredit);
            this.Controls.Add(this.pnlDisplayTransport);
            this.Controls.Add(this.pnlAddCredit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddCredit";
            this.Load += new System.EventHandler(this.FormAddCredit_Load);
            this.pnlAddCredit.ResumeLayout(false);
            this.pnlAddCredit.PerformLayout();
            this.pnlDisplayCredit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransportDataGridView)).EndInit();
            this.pnlDisplayTransport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CreditDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button handleSaveButton;
        private System.Windows.Forms.TextBox CreditAmountTextBox;
        private System.Windows.Forms.ComboBox CreditEmployeeComboBox;
        private System.Windows.Forms.Label creditPriceLabel;
        private System.Windows.Forms.Label EmployeeLabel;
        private System.Windows.Forms.Label creditEmployeeErrorLabel;
        private System.Windows.Forms.Label creditAmountErrorLabel;
        private System.Windows.Forms.DateTimePicker CreditDatePicker;
        private System.Windows.Forms.Label creditDateLabel;
        private System.Windows.Forms.Panel pnlAddCredit;
        private System.Windows.Forms.Panel pnlDisplayCredit;
        private System.Windows.Forms.Panel pnlDisplayTransport;
        private System.Windows.Forms.DataGridView TransportDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportEmployeeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportFarmColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmColumn;
        private System.Windows.Forms.DataGridView CreditDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditEmployeeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeColumn;
    }
}