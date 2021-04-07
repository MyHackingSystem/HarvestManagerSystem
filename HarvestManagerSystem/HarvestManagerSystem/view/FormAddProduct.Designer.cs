
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProduct));
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.handleSaveButton = new System.Windows.Forms.Button();
            this.ProductPriceCompany = new System.Windows.Forms.TextBox();
            this.ProductPriceEmployee = new System.Windows.Forms.TextBox();
            this.ProductCode = new System.Windows.Forms.TextBox();
            this.ProductTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProductNameComboBox = new System.Windows.Forms.ComboBox();
            this.PriceCLabel = new System.Windows.Forms.Label();
            this.PriceELabel = new System.Windows.Forms.Label();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.nameProductErrorLabel = new System.Windows.Forms.Label();
            this.typeProductErrorLabel = new System.Windows.Forms.Label();
            this.codeProductErrorLabel = new System.Windows.Forms.Label();
            this.prixEmployeeErrorlabel = new System.Windows.Forms.Label();
            this.prixCompanyErrorlabel = new System.Windows.Forms.Label();
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
            this.btnReset.Location = new System.Drawing.Point(210, 451);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 30);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(302, 519);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // handleSaveButton
            // 
            this.handleSaveButton.BackColor = System.Drawing.Color.DarkOrange;
            this.handleSaveButton.FlatAppearance.BorderSize = 0;
            this.handleSaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.handleSaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.handleSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.handleSaveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.handleSaveButton.Location = new System.Drawing.Point(40, 451);
            this.handleSaveButton.Name = "handleSaveButton";
            this.handleSaveButton.Size = new System.Drawing.Size(120, 30);
            this.handleSaveButton.TabIndex = 6;
            this.handleSaveButton.Text = "Ajouter";
            this.handleSaveButton.UseVisualStyleBackColor = false;
            this.handleSaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ProductPriceCompany
            // 
            this.ProductPriceCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductPriceCompany.Location = new System.Drawing.Point(107, 345);
            this.ProductPriceCompany.Name = "ProductPriceCompany";
            this.ProductPriceCompany.Size = new System.Drawing.Size(160, 29);
            this.ProductPriceCompany.TabIndex = 5;
            // 
            // ProductPriceEmployee
            // 
            this.ProductPriceEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductPriceEmployee.Location = new System.Drawing.Point(108, 275);
            this.ProductPriceEmployee.Name = "ProductPriceEmployee";
            this.ProductPriceEmployee.Size = new System.Drawing.Size(160, 29);
            this.ProductPriceEmployee.TabIndex = 4;
            // 
            // ProductCode
            // 
            this.ProductCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductCode.Location = new System.Drawing.Point(108, 201);
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Size = new System.Drawing.Size(160, 29);
            this.ProductCode.TabIndex = 3;
            // 
            // ProductTypeComboBox
            // 
            this.ProductTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductTypeComboBox.FormattingEnabled = true;
            this.ProductTypeComboBox.Location = new System.Drawing.Point(108, 133);
            this.ProductTypeComboBox.Name = "ProductTypeComboBox";
            this.ProductTypeComboBox.Size = new System.Drawing.Size(160, 29);
            this.ProductTypeComboBox.TabIndex = 2;
            // 
            // ProductNameComboBox
            // 
            this.ProductNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ProductNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ProductNameComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductNameComboBox.FormattingEnabled = true;
            this.ProductNameComboBox.Location = new System.Drawing.Point(108, 66);
            this.ProductNameComboBox.Name = "ProductNameComboBox";
            this.ProductNameComboBox.Size = new System.Drawing.Size(160, 29);
            this.ProductNameComboBox.TabIndex = 1;
            this.ProductNameComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductNameComboBox_SelectedIndexChanged);
            this.ProductNameComboBox.SelectedValueChanged += new System.EventHandler(this.ProductNameComboBox_SelectedValueChanged);
            // 
            // PriceCLabel
            // 
            this.PriceCLabel.AutoSize = true;
            this.PriceCLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PriceCLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.PriceCLabel.Location = new System.Drawing.Point(108, 321);
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
            this.PriceELabel.Location = new System.Drawing.Point(107, 251);
            this.PriceELabel.Name = "PriceELabel";
            this.PriceELabel.Size = new System.Drawing.Size(50, 21);
            this.PriceELabel.TabIndex = 15;
            this.PriceELabel.Text = "Prix.E:";
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CodeLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.CodeLabel.Location = new System.Drawing.Point(106, 176);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(49, 21);
            this.CodeLabel.TabIndex = 13;
            this.CodeLabel.Text = "Code:";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TypeLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.TypeLabel.Location = new System.Drawing.Point(107, 109);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(45, 21);
            this.TypeLabel.TabIndex = 11;
            this.TypeLabel.Text = "Type:";
            // 
            // ProductLabel
            // 
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductLabel.ForeColor = System.Drawing.Color.White;
            this.ProductLabel.Location = new System.Drawing.Point(108, 41);
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
            this.nameProductErrorLabel.Location = new System.Drawing.Point(250, 41);
            this.nameProductErrorLabel.Name = "nameProductErrorLabel";
            this.nameProductErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.nameProductErrorLabel.TabIndex = 22;
            this.nameProductErrorLabel.Text = "*";
            this.nameProductErrorLabel.Visible = false;
            // 
            // typeProductErrorLabel
            // 
            this.typeProductErrorLabel.AutoSize = true;
            this.typeProductErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.typeProductErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.typeProductErrorLabel.Location = new System.Drawing.Point(250, 109);
            this.typeProductErrorLabel.Name = "typeProductErrorLabel";
            this.typeProductErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.typeProductErrorLabel.TabIndex = 23;
            this.typeProductErrorLabel.Text = "*";
            this.typeProductErrorLabel.Visible = false;
            // 
            // codeProductErrorLabel
            // 
            this.codeProductErrorLabel.AutoSize = true;
            this.codeProductErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.codeProductErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.codeProductErrorLabel.Location = new System.Drawing.Point(250, 176);
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
            this.prixEmployeeErrorlabel.Location = new System.Drawing.Point(250, 251);
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
            this.prixCompanyErrorlabel.Location = new System.Drawing.Point(250, 321);
            this.prixCompanyErrorlabel.Name = "prixCompanyErrorlabel";
            this.prixCompanyErrorlabel.Size = new System.Drawing.Size(28, 37);
            this.prixCompanyErrorlabel.TabIndex = 26;
            this.prixCompanyErrorlabel.Text = "*";
            this.prixCompanyErrorlabel.Visible = false;
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.handleSaveButton);
            this.Controls.Add(this.ProductPriceCompany);
            this.Controls.Add(this.ProductPriceEmployee);
            this.Controls.Add(this.ProductCode);
            this.Controls.Add(this.ProductTypeComboBox);
            this.Controls.Add(this.ProductNameComboBox);
            this.Controls.Add(this.PriceCLabel);
            this.Controls.Add(this.PriceELabel);
            this.Controls.Add(this.CodeLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.ProductLabel);
            this.Controls.Add(this.nameProductErrorLabel);
            this.Controls.Add(this.typeProductErrorLabel);
            this.Controls.Add(this.codeProductErrorLabel);
            this.Controls.Add(this.prixEmployeeErrorlabel);
            this.Controls.Add(this.prixCompanyErrorlabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddProduct_FormClosed);
            this.Load += new System.EventHandler(this.FormAddProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button handleSaveButton;
        private System.Windows.Forms.TextBox ProductPriceCompany;
        private System.Windows.Forms.TextBox ProductPriceEmployee;
        private System.Windows.Forms.TextBox ProductCode;
        private System.Windows.Forms.ComboBox ProductTypeComboBox;
        private System.Windows.Forms.ComboBox ProductNameComboBox;
        private System.Windows.Forms.Label PriceCLabel;
        private System.Windows.Forms.Label PriceELabel;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.Label nameProductErrorLabel;
        private System.Windows.Forms.Label typeProductErrorLabel;
        private System.Windows.Forms.Label codeProductErrorLabel;
        private System.Windows.Forms.Label prixEmployeeErrorlabel;
        private System.Windows.Forms.Label prixCompanyErrorlabel;
    }
}