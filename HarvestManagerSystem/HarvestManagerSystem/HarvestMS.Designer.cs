
namespace HarvestManagerSystem
{
    partial class HarvestMS
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HarvestMS));
            this.tabProduction = new System.Windows.Forms.TabControl();
            this.tabPageQuantity = new System.Windows.Forms.TabPage();
            this.displayQuantityContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editQuantityproduction = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteQuantityproduction = new System.Windows.Forms.ToolStripMenuItem();
            this.toLabel = new System.Windows.Forms.Label();
            this.btnSearchQuantityProduction = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageHours = new System.Windows.Forms.TabPage();
            this.tabPageTransportCredit = new System.Windows.Forms.TabPage();
            this.tabPageEmployee = new System.Windows.Forms.TabPage();
            this.ReloadButton = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.employeeStatusColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.employeeIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFullNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeLastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeHireDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFireDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePermissionDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editEmployeeTable = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFromEmployeeTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSupplier = new System.Windows.Forms.TabPage();
            this.tabPageFarm = new System.Windows.Forms.TabPage();
            this.tabPageProduct = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Quantity = new System.Windows.Forms.Button();
            this.btnAddHarvestHours = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnAddCredit = new System.Windows.Forms.Button();
            this.btnAddTransport = new System.Windows.Forms.Button();
            this.btnAddfarm = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AppLogo = new System.Windows.Forms.PictureBox();
            this.statusStripProgressbar = new System.Windows.Forms.StatusStrip();
            this.loadDataProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabProduction.SuspendLayout();
            this.tabPageQuantity.SuspendLayout();
            this.displayQuantityContextMenu.SuspendLayout();
            this.tabPageEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReloadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            this.employeeMenuStrip.SuspendLayout();
            this.tabPageProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppLogo)).BeginInit();
            this.statusStripProgressbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabProduction
            // 
            this.tabProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProduction.Controls.Add(this.tabPageQuantity);
            this.tabProduction.Controls.Add(this.tabPageHours);
            this.tabProduction.Controls.Add(this.tabPageTransportCredit);
            this.tabProduction.Controls.Add(this.tabPageEmployee);
            this.tabProduction.Controls.Add(this.tabPageSupplier);
            this.tabProduction.Controls.Add(this.tabPageFarm);
            this.tabProduction.Controls.Add(this.tabPageProduct);
            this.tabProduction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabProduction.ItemSize = new System.Drawing.Size(200, 30);
            this.tabProduction.Location = new System.Drawing.Point(13, 35);
            this.tabProduction.Margin = new System.Windows.Forms.Padding(0);
            this.tabProduction.Name = "tabProduction";
            this.tabProduction.Padding = new System.Drawing.Point(41, 3);
            this.tabProduction.SelectedIndex = 0;
            this.tabProduction.Size = new System.Drawing.Size(1129, 600);
            this.tabProduction.TabIndex = 1;
            this.tabProduction.SelectedIndexChanged += new System.EventHandler(this.tabProduction_SelectedIndexChanged);
            // 
            // tabPageQuantity
            // 
            this.tabPageQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageQuantity.ContextMenuStrip = this.displayQuantityContextMenu;
            this.tabPageQuantity.Controls.Add(this.toLabel);
            this.tabPageQuantity.Controls.Add(this.btnSearchQuantityProduction);
            this.tabPageQuantity.Controls.Add(this.dateTimePicker2);
            this.tabPageQuantity.Controls.Add(this.dateTimePicker1);
            this.tabPageQuantity.Controls.Add(this.label2);
            this.tabPageQuantity.ForeColor = System.Drawing.Color.White;
            this.tabPageQuantity.Location = new System.Drawing.Point(4, 34);
            this.tabPageQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageQuantity.Name = "tabPageQuantity";
            this.tabPageQuantity.Size = new System.Drawing.Size(1121, 562);
            this.tabPageQuantity.TabIndex = 0;
            this.tabPageQuantity.Text = "Quantity";
            // 
            // displayQuantityContextMenu
            // 
            this.displayQuantityContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editQuantityproduction,
            this.deleteQuantityproduction});
            this.displayQuantityContextMenu.Name = "displayQuantityContextMenu";
            this.displayQuantityContextMenu.Size = new System.Drawing.Size(108, 48);
            this.displayQuantityContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.displayQuantityContextMenu_Opening);
            // 
            // editQuantityproduction
            // 
            this.editQuantityproduction.Name = "editQuantityproduction";
            this.editQuantityproduction.Size = new System.Drawing.Size(107, 22);
            this.editQuantityproduction.Text = "Edit";
            // 
            // deleteQuantityproduction
            // 
            this.deleteQuantityproduction.Name = "deleteQuantityproduction";
            this.deleteQuantityproduction.Size = new System.Drawing.Size(107, 22);
            this.deleteQuantityproduction.Text = "Delete";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(463, 21);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(29, 21);
            this.toLabel.TabIndex = 4;
            this.toLabel.Text = "au";
            // 
            // btnSearchQuantityProduction
            // 
            this.btnSearchQuantityProduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearchQuantityProduction.FlatAppearance.BorderSize = 0;
            this.btnSearchQuantityProduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchQuantityProduction.ForeColor = System.Drawing.Color.Black;
            this.btnSearchQuantityProduction.Location = new System.Drawing.Point(658, 16);
            this.btnSearchQuantityProduction.Name = "btnSearchQuantityProduction";
            this.btnSearchQuantityProduction.Size = new System.Drawing.Size(120, 30);
            this.btnSearchQuantityProduction.TabIndex = 3;
            this.btnSearchQuantityProduction.Text = "Chercher";
            this.btnSearchQuantityProduction.UseVisualStyleBackColor = false;
            this.btnSearchQuantityProduction.Click += new System.EventHandler(this.btnSearchQuantityProduction_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(513, 15);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(125, 29);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(320, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(125, 29);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "PRODUCTION PAR QUANTITE";
            // 
            // tabPageHours
            // 
            this.tabPageHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageHours.Location = new System.Drawing.Point(4, 34);
            this.tabPageHours.Name = "tabPageHours";
            this.tabPageHours.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHours.Size = new System.Drawing.Size(1121, 562);
            this.tabPageHours.TabIndex = 1;
            this.tabPageHours.Text = "Heures";
            // 
            // tabPageTransportCredit
            // 
            this.tabPageTransportCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageTransportCredit.Location = new System.Drawing.Point(4, 34);
            this.tabPageTransportCredit.Name = "tabPageTransportCredit";
            this.tabPageTransportCredit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTransportCredit.Size = new System.Drawing.Size(1121, 562);
            this.tabPageTransportCredit.TabIndex = 2;
            this.tabPageTransportCredit.Text = "Transport / Credit";
            // 
            // tabPageEmployee
            // 
            this.tabPageEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageEmployee.Controls.Add(this.ReloadButton);
            this.tabPageEmployee.Controls.Add(this.label3);
            this.tabPageEmployee.Controls.Add(this.employeeDataGridView);
            this.tabPageEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageEmployee.Location = new System.Drawing.Point(4, 34);
            this.tabPageEmployee.Name = "tabPageEmployee";
            this.tabPageEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployee.Size = new System.Drawing.Size(1121, 562);
            this.tabPageEmployee.TabIndex = 3;
            this.tabPageEmployee.Text = "Employées";
            // 
            // ReloadButton
            // 
            this.ReloadButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ReloadButton.Image = global::HarvestManagerSystem.Properties.Resources.refresh;
            this.ReloadButton.Location = new System.Drawing.Point(1078, 3);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(36, 36);
            this.ReloadButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ReloadButton.TabIndex = 2;
            this.ReloadButton.TabStop = false;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(1118, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Employées";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.AllowUserToAddRows = false;
            this.employeeDataGridView.AllowUserToDeleteRows = false;
            this.employeeDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.employeeDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.employeeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.employeeDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.employeeDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.employeeDataGridView.ColumnHeadersHeight = 36;
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.employeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeStatusColumn,
            this.employeeIdColumn,
            this.employeeFullNameColumn,
            this.employeeFirstNameColumn,
            this.employeeLastNameColumn,
            this.employeeHireDateColumn,
            this.employeeFireDateColumn,
            this.employeePermissionDateColumn});
            this.employeeDataGridView.ContextMenuStrip = this.employeeMenuStrip;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.employeeDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.employeeDataGridView.EnableHeadersVisualStyles = false;
            this.employeeDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.employeeDataGridView.Location = new System.Drawing.Point(5, 44);
            this.employeeDataGridView.Name = "employeeDataGridView";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.employeeDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.employeeDataGridView.RowTemplate.Height = 25;
            this.employeeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeDataGridView.Size = new System.Drawing.Size(1120, 515);
            this.employeeDataGridView.TabIndex = 0;
            this.employeeDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeDataGridView_CellEndEdit);
            this.employeeDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.employeeDataGridView_CellMouseUp);

            // 
            // employeeStatusColumn
            // 
            this.employeeStatusColumn.DataPropertyName = "EmployeeStatus";
            this.employeeStatusColumn.HeaderText = "Status";
            this.employeeStatusColumn.Name = "employeeStatusColumn";
            this.employeeStatusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeStatusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.employeeStatusColumn.Width = 80;
            // 
            // employeeIdColumn
            // 
            this.employeeIdColumn.DataPropertyName = "EmployeeId";
            this.employeeIdColumn.HeaderText = "Id";
            this.employeeIdColumn.Name = "employeeIdColumn";
            this.employeeIdColumn.Width = 80;
            // 
            // employeeFullNameColumn
            // 
            this.employeeFullNameColumn.DataPropertyName = "FullName";
            this.employeeFullNameColumn.HeaderText = "Employée";
            this.employeeFullNameColumn.Name = "employeeFullNameColumn";
            this.employeeFullNameColumn.Width = 260;
            // 
            // employeeFirstNameColumn
            // 
            this.employeeFirstNameColumn.DataPropertyName = "FirstName";
            this.employeeFirstNameColumn.HeaderText = "Prénom";
            this.employeeFirstNameColumn.Name = "employeeFirstNameColumn";
            this.employeeFirstNameColumn.ReadOnly = true;
            this.employeeFirstNameColumn.Width = 150;
            // 
            // employeeLastNameColumn
            // 
            this.employeeLastNameColumn.DataPropertyName = "LastName";
            this.employeeLastNameColumn.HeaderText = "Nom";
            this.employeeLastNameColumn.Name = "employeeLastNameColumn";
            this.employeeLastNameColumn.ReadOnly = true;
            this.employeeLastNameColumn.Width = 150;
            // 
            // employeeHireDateColumn
            // 
            this.employeeHireDateColumn.DataPropertyName = "HireDate";
            this.employeeHireDateColumn.HeaderText = "Debut CTR";
            this.employeeHireDateColumn.Name = "employeeHireDateColumn";
            this.employeeHireDateColumn.ReadOnly = true;
            this.employeeHireDateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.employeeHireDateColumn.Width = 120;
            // 
            // employeeFireDateColumn
            // 
            this.employeeFireDateColumn.DataPropertyName = "FireDate";
            this.employeeFireDateColumn.HeaderText = "Fin CTR";
            this.employeeFireDateColumn.Name = "employeeFireDateColumn";
            this.employeeFireDateColumn.ReadOnly = true;
            this.employeeFireDateColumn.Width = 120;
            // 
            // employeePermissionDateColumn
            // 
            this.employeePermissionDateColumn.DataPropertyName = "PermissionDate";
            this.employeePermissionDateColumn.HeaderText = "SCDZP";
            this.employeePermissionDateColumn.Name = "employeePermissionDateColumn";
            this.employeePermissionDateColumn.ReadOnly = true;
            this.employeePermissionDateColumn.Width = 120;
            // 
            // employeeMenuStrip
            // 
            this.employeeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editEmployeeTable,
            this.deleteFromEmployeeTable});
            this.employeeMenuStrip.Name = "employeeMenuStrip";
            this.employeeMenuStrip.Size = new System.Drawing.Size(140, 52);
            this.employeeMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.employeeMenuStrip_ItemClicked);
            // 
            // editEmployeeTable
            // 
            this.editEmployeeTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editEmployeeTable.Name = "editEmployeeTable";
            this.editEmployeeTable.Size = new System.Drawing.Size(139, 24);
            this.editEmployeeTable.Text = "Edit";
            // 
            // deleteFromEmployeeTable
            // 
            this.deleteFromEmployeeTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteFromEmployeeTable.Name = "deleteFromEmployeeTable";
            this.deleteFromEmployeeTable.Size = new System.Drawing.Size(139, 24);
            this.deleteFromEmployeeTable.Text = "Supprimer";
            // 
            // tabPageSupplier
            // 
            this.tabPageSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageSupplier.Location = new System.Drawing.Point(4, 34);
            this.tabPageSupplier.Name = "tabPageSupplier";
            this.tabPageSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupplier.Size = new System.Drawing.Size(1121, 562);
            this.tabPageSupplier.TabIndex = 4;
            this.tabPageSupplier.Text = "Fournisseur";
            // 
            // tabPageFarm
            // 
            this.tabPageFarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageFarm.Location = new System.Drawing.Point(4, 34);
            this.tabPageFarm.Name = "tabPageFarm";
            this.tabPageFarm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFarm.Size = new System.Drawing.Size(1121, 562);
            this.tabPageFarm.TabIndex = 5;
            this.tabPageFarm.Text = "Champs";
            // 
            // tabPageProduct
            // 
            this.tabPageProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageProduct.Controls.Add(this.dataGridView2);
            this.tabPageProduct.Controls.Add(this.dataGridView1);
            this.tabPageProduct.Location = new System.Drawing.Point(4, 34);
            this.tabPageProduct.Name = "tabPageProduct";
            this.tabPageProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduct.Size = new System.Drawing.Size(1121, 562);
            this.tabPageProduct.TabIndex = 6;
            this.tabPageProduct.Text = "Produits";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(327, 27);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(776, 519);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(275, 519);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Quantity);
            this.groupBox1.Controls.Add(this.btnAddHarvestHours);
            this.groupBox1.Controls.Add(this.btnAddEmployee);
            this.groupBox1.Controls.Add(this.btnAddSupplier);
            this.groupBox1.Controls.Add(this.btnAddCredit);
            this.groupBox1.Controls.Add(this.btnAddTransport);
            this.groupBox1.Controls.Add(this.btnAddfarm);
            this.groupBox1.Controls.Add(this.btnAddProduct);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(1145, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 315);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajouter";
            // 
            // Quantity
            // 
            this.Quantity.ForeColor = System.Drawing.Color.Black;
            this.Quantity.Location = new System.Drawing.Point(16, 22);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(100, 30);
            this.Quantity.TabIndex = 9;
            this.Quantity.Text = "Quantité";
            this.Quantity.UseVisualStyleBackColor = true;
            // 
            // btnAddHarvestHours
            // 
            this.btnAddHarvestHours.ForeColor = System.Drawing.Color.Black;
            this.btnAddHarvestHours.Location = new System.Drawing.Point(16, 58);
            this.btnAddHarvestHours.Name = "btnAddHarvestHours";
            this.btnAddHarvestHours.Size = new System.Drawing.Size(100, 30);
            this.btnAddHarvestHours.TabIndex = 10;
            this.btnAddHarvestHours.Text = "Heures";
            this.btnAddHarvestHours.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.ForeColor = System.Drawing.Color.Black;
            this.btnAddEmployee.Location = new System.Drawing.Point(16, 94);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(100, 30);
            this.btnAddEmployee.TabIndex = 11;
            this.btnAddEmployee.Text = "Employée";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.ForeColor = System.Drawing.Color.Black;
            this.btnAddSupplier.Location = new System.Drawing.Point(16, 130);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(100, 30);
            this.btnAddSupplier.TabIndex = 12;
            this.btnAddSupplier.Text = "Fournisseur";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // btnAddCredit
            // 
            this.btnAddCredit.ForeColor = System.Drawing.Color.Black;
            this.btnAddCredit.Location = new System.Drawing.Point(16, 166);
            this.btnAddCredit.Name = "btnAddCredit";
            this.btnAddCredit.Size = new System.Drawing.Size(100, 30);
            this.btnAddCredit.TabIndex = 13;
            this.btnAddCredit.Text = "Crédit";
            this.btnAddCredit.UseVisualStyleBackColor = true;
            // 
            // btnAddTransport
            // 
            this.btnAddTransport.ForeColor = System.Drawing.Color.Black;
            this.btnAddTransport.Location = new System.Drawing.Point(16, 202);
            this.btnAddTransport.Name = "btnAddTransport";
            this.btnAddTransport.Size = new System.Drawing.Size(100, 30);
            this.btnAddTransport.TabIndex = 14;
            this.btnAddTransport.Text = "Transport";
            this.btnAddTransport.UseVisualStyleBackColor = true;
            // 
            // btnAddfarm
            // 
            this.btnAddfarm.ForeColor = System.Drawing.Color.Black;
            this.btnAddfarm.Location = new System.Drawing.Point(16, 238);
            this.btnAddfarm.Name = "btnAddfarm";
            this.btnAddfarm.Size = new System.Drawing.Size(100, 30);
            this.btnAddfarm.TabIndex = 15;
            this.btnAddfarm.Text = "Champ";
            this.btnAddfarm.UseVisualStyleBackColor = true;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.ForeColor = System.Drawing.Color.Black;
            this.btnAddProduct.Location = new System.Drawing.Point(16, 274);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(100, 30);
            this.btnAddProduct.TabIndex = 16;
            this.btnAddProduct.Text = "Produit";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(909, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Harvest Manager System";
            // 
            // AppLogo
            // 
            this.AppLogo.Image = global::HarvestManagerSystem.Properties.Resources.Harvest;
            this.AppLogo.Location = new System.Drawing.Point(1161, 9);
            this.AppLogo.Name = "AppLogo";
            this.AppLogo.Size = new System.Drawing.Size(100, 85);
            this.AppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AppLogo.TabIndex = 5;
            this.AppLogo.TabStop = false;
            // 
            // statusStripProgressbar
            // 
            this.statusStripProgressbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataProgressBar});
            this.statusStripProgressbar.Location = new System.Drawing.Point(0, 639);
            this.statusStripProgressbar.Name = "statusStripProgressbar";
            this.statusStripProgressbar.Size = new System.Drawing.Size(1284, 22);
            this.statusStripProgressbar.TabIndex = 6;
            this.statusStripProgressbar.Text = "progreebarStrip";
            this.statusStripProgressbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // loadDataProgressBar
            // 
            this.loadDataProgressBar.Name = "loadDataProgressBar";
            this.loadDataProgressBar.Size = new System.Drawing.Size(1200, 16);
            this.loadDataProgressBar.Visible = false;
            // 
            // HarvestMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.statusStripProgressbar);
            this.Controls.Add(this.AppLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabProduction);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HarvestMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Harvest Manager System";
            this.Load += new System.EventHandler(this.HarvestMS_Load);
            this.tabProduction.ResumeLayout(false);
            this.tabPageQuantity.ResumeLayout(false);
            this.tabPageQuantity.PerformLayout();
            this.displayQuantityContextMenu.ResumeLayout(false);
            this.tabPageEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReloadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            this.employeeMenuStrip.ResumeLayout(false);
            this.tabPageProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppLogo)).EndInit();
            this.statusStripProgressbar.ResumeLayout(false);
            this.statusStripProgressbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabProduction;
        private System.Windows.Forms.TabPage tabPageQuantity;
        private System.Windows.Forms.TabPage tabPageHours;
        private System.Windows.Forms.TabPage tabPageTransportCredit;
        private System.Windows.Forms.TabPage tabPageEmployee;
        private System.Windows.Forms.TabPage tabPageSupplier;
        private System.Windows.Forms.TabPage tabPageFarm;
        private System.Windows.Forms.TabPage tabPageProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Quantity;
        private System.Windows.Forms.Button btnAddHarvestHours;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnAddCredit;
        private System.Windows.Forms.Button btnAddTransport;
        private System.Windows.Forms.Button btnAddfarm;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox AppLogo;
        private System.Windows.Forms.Button btnSearchQuantityProduction;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.ContextMenuStrip displayQuantityContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editQuantityproduction;
        private System.Windows.Forms.ToolStripMenuItem deleteQuantityproduction;
        private System.Windows.Forms.StatusStrip statusStripProgressbar;
        private System.Windows.Forms.ToolStripProgressBar loadDataProgressBar;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip employeeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editEmployeeTable;
        private System.Windows.Forms.ToolStripMenuItem deleteStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFromEmployeeTable;
        private System.Windows.Forms.PictureBox ReloadButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn employeeStatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFullNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeLastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeHireDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFireDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeePermissionDateColumn;
    }
}

