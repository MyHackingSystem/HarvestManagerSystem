
namespace HarvestManagerSystem.view
{
    partial class FormAddProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProduct));
            this.btnClearReset = new System.Windows.Forms.Button();
            this.btnSaveProductData = new System.Windows.Forms.Button();
            this.txtProductPriceCompany = new System.Windows.Forms.TextBox();
            this.txtProductPriceEmployee = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.cmbxProductName = new System.Windows.Forms.ComboBox();
            this.PriceCLabel = new System.Windows.Forms.Label();
            this.PriceELabel = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.nameProductErrorLabel = new System.Windows.Forms.Label();
            this.codeProductErrorLabel = new System.Windows.Forms.Label();
            this.prixEmployeeErrorlabel = new System.Windows.Forms.Label();
            this.prixCompanyErrorlabel = new System.Windows.Forms.Label();
            this.pnlAddProduct = new System.Windows.Forms.Panel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.pnlDisplayProducts = new System.Windows.Forms.Panel();
            this.ProductDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.ProductDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPriceEmployeeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPriceCompanyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlAddProduct.SuspendLayout();
            this.pnlDisplayProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.btnClearReset.Location = new System.Drawing.Point(142, 481);
            this.btnClearReset.Name = "btnClearReset";
            this.btnClearReset.Size = new System.Drawing.Size(90, 30);
            this.btnClearReset.TabIndex = 6;
            this.btnClearReset.Text = "Vider";
            this.btnClearReset.UseVisualStyleBackColor = false;
            this.btnClearReset.Click += new System.EventHandler(this.btnClearReset_Click);
            // 
            // btnSaveProductData
            // 
            this.btnSaveProductData.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSaveProductData.FlatAppearance.BorderSize = 0;
            this.btnSaveProductData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnSaveProductData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnSaveProductData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProductData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveProductData.Location = new System.Drawing.Point(12, 481);
            this.btnSaveProductData.Name = "btnSaveProductData";
            this.btnSaveProductData.Size = new System.Drawing.Size(90, 30);
            this.btnSaveProductData.TabIndex = 5;
            this.btnSaveProductData.Text = "Ajouter";
            this.btnSaveProductData.UseVisualStyleBackColor = false;
            this.btnSaveProductData.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // txtProductPriceCompany
            // 
            this.txtProductPriceCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProductPriceCompany.Location = new System.Drawing.Point(41, 408);
            this.txtProductPriceCompany.Name = "txtProductPriceCompany";
            this.txtProductPriceCompany.Size = new System.Drawing.Size(160, 29);
            this.txtProductPriceCompany.TabIndex = 4;
            this.txtProductPriceCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberEntred);
            // 
            // txtProductPriceEmployee
            // 
            this.txtProductPriceEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProductPriceEmployee.Location = new System.Drawing.Point(41, 317);
            this.txtProductPriceEmployee.Name = "txtProductPriceEmployee";
            this.txtProductPriceEmployee.Size = new System.Drawing.Size(160, 29);
            this.txtProductPriceEmployee.TabIndex = 3;
            this.txtProductPriceEmployee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberEntred);
            // 
            // txtProductType
            // 
            this.txtProductType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProductType.Location = new System.Drawing.Point(39, 229);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(160, 29);
            this.txtProductType.TabIndex = 2;
            // 
            // cmbxProductName
            // 
            this.cmbxProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbxProductName.FormattingEnabled = true;
            this.cmbxProductName.Location = new System.Drawing.Point(38, 143);
            this.cmbxProductName.Name = "cmbxProductName";
            this.cmbxProductName.Size = new System.Drawing.Size(160, 29);
            this.cmbxProductName.TabIndex = 1;
            // 
            // PriceCLabel
            // 
            this.PriceCLabel.AutoSize = true;
            this.PriceCLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PriceCLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.PriceCLabel.Location = new System.Drawing.Point(41, 384);
            this.PriceCLabel.Name = "PriceCLabel";
            this.PriceCLabel.Size = new System.Drawing.Size(52, 21);
            this.PriceCLabel.TabIndex = 17;
            this.PriceCLabel.Text = "Prix.C:";
            // 
            // PriceELabel
            // 
            this.PriceELabel.AutoSize = true;
            this.PriceELabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PriceELabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.PriceELabel.Location = new System.Drawing.Point(40, 293);
            this.PriceELabel.Name = "PriceELabel";
            this.PriceELabel.Size = new System.Drawing.Size(50, 21);
            this.PriceELabel.TabIndex = 15;
            this.PriceELabel.Text = "Prix.E:";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblType.ForeColor = System.Drawing.Color.FloralWhite;
            this.LblType.Location = new System.Drawing.Point(37, 204);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(45, 21);
            this.LblType.TabIndex = 13;
            this.LblType.Text = "Type:";
            // 
            // ProductLabel
            // 
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductLabel.ForeColor = System.Drawing.Color.White;
            this.ProductLabel.Location = new System.Drawing.Point(38, 118);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(64, 21);
            this.ProductLabel.TabIndex = 9;
            this.ProductLabel.Text = "Produit:";
            // 
            // nameProductErrorLabel
            // 
            this.nameProductErrorLabel.AutoSize = true;
            this.nameProductErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameProductErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.nameProductErrorLabel.Location = new System.Drawing.Point(180, 118);
            this.nameProductErrorLabel.Name = "nameProductErrorLabel";
            this.nameProductErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.nameProductErrorLabel.TabIndex = 22;
            this.nameProductErrorLabel.Text = "*";
            this.nameProductErrorLabel.Visible = false;
            // 
            // codeProductErrorLabel
            // 
            this.codeProductErrorLabel.AutoSize = true;
            this.codeProductErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.codeProductErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.codeProductErrorLabel.Location = new System.Drawing.Point(181, 204);
            this.codeProductErrorLabel.Name = "codeProductErrorLabel";
            this.codeProductErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.codeProductErrorLabel.TabIndex = 24;
            this.codeProductErrorLabel.Text = "*";
            this.codeProductErrorLabel.Visible = false;
            // 
            // prixEmployeeErrorlabel
            // 
            this.prixEmployeeErrorlabel.AutoSize = true;
            this.prixEmployeeErrorlabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prixEmployeeErrorlabel.ForeColor = System.Drawing.Color.Red;
            this.prixEmployeeErrorlabel.Location = new System.Drawing.Point(183, 293);
            this.prixEmployeeErrorlabel.Name = "prixEmployeeErrorlabel";
            this.prixEmployeeErrorlabel.Size = new System.Drawing.Size(28, 37);
            this.prixEmployeeErrorlabel.TabIndex = 25;
            this.prixEmployeeErrorlabel.Text = "*";
            this.prixEmployeeErrorlabel.Visible = false;
            // 
            // prixCompanyErrorlabel
            // 
            this.prixCompanyErrorlabel.AutoSize = true;
            this.prixCompanyErrorlabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prixCompanyErrorlabel.ForeColor = System.Drawing.Color.Red;
            this.prixCompanyErrorlabel.Location = new System.Drawing.Point(180, 384);
            this.prixCompanyErrorlabel.Name = "prixCompanyErrorlabel";
            this.prixCompanyErrorlabel.Size = new System.Drawing.Size(28, 37);
            this.prixCompanyErrorlabel.TabIndex = 26;
            this.prixCompanyErrorlabel.Text = "*";
            this.prixCompanyErrorlabel.Visible = false;
            // 
            // pnlAddProduct
            // 
            this.pnlAddProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAddProduct.Controls.Add(this.btnCloseForm);
            this.pnlAddProduct.Controls.Add(this.btnClearReset);
            this.pnlAddProduct.Controls.Add(this.btnDeleteProduct);
            this.pnlAddProduct.Controls.Add(this.btnSaveProductData);
            this.pnlAddProduct.Controls.Add(this.txtProductPriceCompany);
            this.pnlAddProduct.Controls.Add(this.txtProductPriceEmployee);
            this.pnlAddProduct.Controls.Add(this.txtProductType);
            this.pnlAddProduct.Controls.Add(this.cmbxProductName);
            this.pnlAddProduct.Controls.Add(this.ProductLabel);
            this.pnlAddProduct.Controls.Add(this.PriceCLabel);
            this.pnlAddProduct.Controls.Add(this.LblType);
            this.pnlAddProduct.Controls.Add(this.PriceELabel);
            this.pnlAddProduct.Controls.Add(this.nameProductErrorLabel);
            this.pnlAddProduct.Controls.Add(this.codeProductErrorLabel);
            this.pnlAddProduct.Controls.Add(this.prixEmployeeErrorlabel);
            this.pnlAddProduct.Controls.Add(this.prixCompanyErrorlabel);
            this.pnlAddProduct.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAddProduct.Location = new System.Drawing.Point(0, 0);
            this.pnlAddProduct.Name = "pnlAddProduct";
            this.pnlAddProduct.Size = new System.Drawing.Size(253, 618);
            this.pnlAddProduct.TabIndex = 27;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.Red;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCloseForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseForm.Location = new System.Drawing.Point(12, 12);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(30, 30);
            this.btnCloseForm.TabIndex = 27;
            this.btnCloseForm.Text = "X";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.Color.Red;
            this.btnDeleteProduct.FlatAppearance.BorderSize = 0;
            this.btnDeleteProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnDeleteProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteProduct.Location = new System.Drawing.Point(12, 543);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(220, 30);
            this.btnDeleteProduct.TabIndex = 5;
            this.btnDeleteProduct.Text = "Supprimer";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Visible = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // pnlDisplayProducts
            // 
            this.pnlDisplayProducts.AutoScroll = true;
            this.pnlDisplayProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplayProducts.Controls.Add(this.ProductDataGridView);
            this.pnlDisplayProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDisplayProducts.Location = new System.Drawing.Point(253, 0);
            this.pnlDisplayProducts.Name = "pnlDisplayProducts";
            this.pnlDisplayProducts.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnlDisplayProducts.Size = new System.Drawing.Size(237, 618);
            this.pnlDisplayProducts.TabIndex = 28;
            // 
            // ProductDetailDataGridView
            // 
            this.ProductDetailDataGridView.AllowUserToAddRows = false;
            this.ProductDetailDataGridView.AllowUserToDeleteRows = false;
            this.ProductDetailDataGridView.AllowUserToOrderColumns = true;
            this.ProductDetailDataGridView.AllowUserToResizeColumns = false;
            this.ProductDetailDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.ProductDetailDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.ProductDetailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductDetailDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProductDetailDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProductDetailDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDetailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ProductDetailDataGridView.ColumnHeadersHeight = 36;
            this.ProductDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ProductDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductDetailId,
            this.ProductTypeColumn,
            this.ProductPriceEmployeeColumn,
            this.ProductPriceCompanyColumn,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductDetailDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.ProductDetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDetailDataGridView.EnableHeadersVisualStyles = false;
            this.ProductDetailDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProductDetailDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ProductDetailDataGridView.MultiSelect = false;
            this.ProductDetailDataGridView.Name = "ProductDetailDataGridView";
            this.ProductDetailDataGridView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDetailDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ProductDetailDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.ProductDetailDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ProductDetailDataGridView.RowTemplate.Height = 25;
            this.ProductDetailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDetailDataGridView.Size = new System.Drawing.Size(513, 614);
            this.ProductDetailDataGridView.TabIndex = 10;
            this.ProductDetailDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDetailDataGridView_CellDoubleClick);
            // 
            // ProductDetailId
            // 
            this.ProductDetailId.DataPropertyName = "ProductDetailId";
            this.ProductDetailId.HeaderText = "ProductDetailId";
            this.ProductDetailId.Name = "ProductDetailId";
            this.ProductDetailId.ReadOnly = true;
            this.ProductDetailId.Visible = false;
            // 
            // ProductTypeColumn
            // 
            this.ProductTypeColumn.DataPropertyName = "ProductType";
            this.ProductTypeColumn.FillWeight = 369.5432F;
            this.ProductTypeColumn.HeaderText = "Type";
            this.ProductTypeColumn.MinimumWidth = 140;
            this.ProductTypeColumn.Name = "ProductTypeColumn";
            this.ProductTypeColumn.ReadOnly = true;
            // 
            // ProductPriceEmployeeColumn
            // 
            this.ProductPriceEmployeeColumn.DataPropertyName = "PriceEmployee";
            this.ProductPriceEmployeeColumn.FillWeight = 2.143695F;
            this.ProductPriceEmployeeColumn.HeaderText = "Prix.E";
            this.ProductPriceEmployeeColumn.MinimumWidth = 120;
            this.ProductPriceEmployeeColumn.Name = "ProductPriceEmployeeColumn";
            this.ProductPriceEmployeeColumn.ReadOnly = true;
            // 
            // ProductPriceCompanyColumn
            // 
            this.ProductPriceCompanyColumn.DataPropertyName = "PriceCompany";
            this.ProductPriceCompanyColumn.FillWeight = 28.1496F;
            this.ProductPriceCompanyColumn.HeaderText = "Prix.C";
            this.ProductPriceCompanyColumn.MinimumWidth = 120;
            this.ProductPriceCompanyColumn.Name = "ProductPriceCompanyColumn";
            this.ProductPriceCompanyColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProductId";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.AllowUserToOrderColumns = true;
            this.ProductDataGridView.AllowUserToResizeColumns = false;
            this.ProductDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.ProductDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProductDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProductDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ProductDataGridView.ColumnHeadersHeight = 36;
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.NameColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProductDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDataGridView.EnableHeadersVisualStyles = false;
            this.ProductDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProductDataGridView.Location = new System.Drawing.Point(2, 0);
            this.ProductDataGridView.MultiSelect = false;
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ProductDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.ProductDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ProductDataGridView.RowTemplate.Height = 25;
            this.ProductDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDataGridView.Size = new System.Drawing.Size(231, 614);
            this.ProductDataGridView.TabIndex = 9;
            this.ProductDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDataGridView_CellDoubleClick);
            this.ProductDataGridView.SelectionChanged += new System.EventHandler(this.ProductDataGridView_SelectionChanged);
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "ProductId";
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "ProductName";
            this.NameColumn.HeaderText = "Product";
            this.NameColumn.MinimumWidth = 200;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.pnlDisplayProducts);
            this.panel2.Controls.Add(this.pnlAddProduct);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1007, 618);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ProductDetailDataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(490, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 618);
            this.panel1.TabIndex = 29;
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1007, 618);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.FormAddProduct_Load);
            this.pnlAddProduct.ResumeLayout(false);
            this.pnlAddProduct.PerformLayout();
            this.pnlDisplayProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClearReset;
        private System.Windows.Forms.Button btnSaveProductData;
        private System.Windows.Forms.TextBox txtProductPriceCompany;
        private System.Windows.Forms.TextBox txtProductPriceEmployee;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.ComboBox cmbxProductName;
        private System.Windows.Forms.Label PriceCLabel;
        private System.Windows.Forms.Label PriceELabel;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.Label nameProductErrorLabel;
        private System.Windows.Forms.Label codeProductErrorLabel;
        private System.Windows.Forms.Label prixEmployeeErrorlabel;
        private System.Windows.Forms.Label prixCompanyErrorlabel;
        private System.Windows.Forms.Panel pnlAddProduct;
        private System.Windows.Forms.Panel pnlDisplayProducts;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.DataGridView ProductDetailDataGridView;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPriceEmployeeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPriceCompanyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Panel panel1;
    }
}