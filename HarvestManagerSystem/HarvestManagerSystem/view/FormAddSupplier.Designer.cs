
namespace HarvestManagerSystem.view
{
    partial class FormAddSupplier
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
            this.SupplierFirstNameLabel = new System.Windows.Forms.Label();
            this.SupplierFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.handleSaveButton = new System.Windows.Forms.Button();
            this.SupplierNameComboBox = new System.Windows.Forms.ComboBox();
            this.SupplierLabel = new System.Windows.Forms.Label();
            this.nameSupplierErrorLabel = new System.Windows.Forms.Label();
            this.supplierFirstNameErrorLabel = new System.Windows.Forms.Label();
            this.SupplierLastNameLabel = new System.Windows.Forms.Label();
            this.SupplierLastNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierLastNameErrorLabel = new System.Windows.Forms.Label();
            this.FarmSupplierComboBox = new System.Windows.Forms.ComboBox();
            this.farmSupplierLabel = new System.Windows.Forms.Label();
            this.farmSupplierErrorLabel = new System.Windows.Forms.Label();
            this.ProductSupplierComboBox = new System.Windows.Forms.ComboBox();
            this.productSupplierLabel = new System.Windows.Forms.Label();
            this.productSupplierErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SupplierFirstNameLabel
            // 
            this.SupplierFirstNameLabel.AutoSize = true;
            this.SupplierFirstNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SupplierFirstNameLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.SupplierFirstNameLabel.Location = new System.Drawing.Point(119, 126);
            this.SupplierFirstNameLabel.Name = "SupplierFirstNameLabel";
            this.SupplierFirstNameLabel.Size = new System.Drawing.Size(68, 21);
            this.SupplierFirstNameLabel.TabIndex = 43;
            this.SupplierFirstNameLabel.Text = "Prénom:";
            // 
            // SupplierFirstNameTextBox
            // 
            this.SupplierFirstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SupplierFirstNameTextBox.Location = new System.Drawing.Point(119, 150);
            this.SupplierFirstNameTextBox.Name = "SupplierFirstNameTextBox";
            this.SupplierFirstNameTextBox.Size = new System.Drawing.Size(160, 29);
            this.SupplierFirstNameTextBox.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DarkOrange;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(218, 467);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 30);
            this.btnReset.TabIndex = 38;
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
            this.handleSaveButton.Location = new System.Drawing.Point(47, 467);
            this.handleSaveButton.Name = "handleSaveButton";
            this.handleSaveButton.Size = new System.Drawing.Size(120, 30);
            this.handleSaveButton.TabIndex = 37;
            this.handleSaveButton.Text = "Ajouter";
            this.handleSaveButton.UseVisualStyleBackColor = false;
            this.handleSaveButton.Click += new System.EventHandler(this.handleSaveButton_Click);
            // 
            // SupplierNameComboBox
            // 
            this.SupplierNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SupplierNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SupplierNameComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SupplierNameComboBox.FormattingEnabled = true;
            this.SupplierNameComboBox.Location = new System.Drawing.Point(119, 81);
            this.SupplierNameComboBox.Name = "SupplierNameComboBox";
            this.SupplierNameComboBox.Size = new System.Drawing.Size(160, 29);
            this.SupplierNameComboBox.TabIndex = 1;
            this.SupplierNameComboBox.SelectedIndexChanged += new System.EventHandler(this.SupplierNameComboBox_SelectedIndexChanged);
            // 
            // SupplierLabel
            // 
            this.SupplierLabel.AutoSize = true;
            this.SupplierLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SupplierLabel.ForeColor = System.Drawing.Color.White;
            this.SupplierLabel.Location = new System.Drawing.Point(119, 56);
            this.SupplierLabel.Name = "SupplierLabel";
            this.SupplierLabel.Size = new System.Drawing.Size(95, 21);
            this.SupplierLabel.TabIndex = 40;
            this.SupplierLabel.Text = "Fournisseur:";
            // 
            // nameSupplierErrorLabel
            // 
            this.nameSupplierErrorLabel.AutoSize = true;
            this.nameSupplierErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameSupplierErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.nameSupplierErrorLabel.Location = new System.Drawing.Point(261, 56);
            this.nameSupplierErrorLabel.Name = "nameSupplierErrorLabel";
            this.nameSupplierErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.nameSupplierErrorLabel.TabIndex = 41;
            this.nameSupplierErrorLabel.Text = "*";
            this.nameSupplierErrorLabel.Visible = false;
            // 
            // supplierFirstNameErrorLabel
            // 
            this.supplierFirstNameErrorLabel.AutoSize = true;
            this.supplierFirstNameErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.supplierFirstNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.supplierFirstNameErrorLabel.Location = new System.Drawing.Point(261, 124);
            this.supplierFirstNameErrorLabel.Name = "supplierFirstNameErrorLabel";
            this.supplierFirstNameErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.supplierFirstNameErrorLabel.TabIndex = 42;
            this.supplierFirstNameErrorLabel.Text = "*";
            this.supplierFirstNameErrorLabel.Visible = false;
            // 
            // SupplierLastNameLabel
            // 
            this.SupplierLastNameLabel.AutoSize = true;
            this.SupplierLastNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SupplierLastNameLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.SupplierLastNameLabel.Location = new System.Drawing.Point(119, 196);
            this.SupplierLastNameLabel.Name = "SupplierLastNameLabel";
            this.SupplierLastNameLabel.Size = new System.Drawing.Size(48, 21);
            this.SupplierLastNameLabel.TabIndex = 46;
            this.SupplierLastNameLabel.Text = "Nom:";
            // 
            // SupplierLastNameTextBox
            // 
            this.SupplierLastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SupplierLastNameTextBox.Location = new System.Drawing.Point(119, 220);
            this.SupplierLastNameTextBox.Name = "SupplierLastNameTextBox";
            this.SupplierLastNameTextBox.Size = new System.Drawing.Size(160, 29);
            this.SupplierLastNameTextBox.TabIndex = 3;
            // 
            // supplierLastNameErrorLabel
            // 
            this.supplierLastNameErrorLabel.AutoSize = true;
            this.supplierLastNameErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.supplierLastNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.supplierLastNameErrorLabel.Location = new System.Drawing.Point(261, 194);
            this.supplierLastNameErrorLabel.Name = "supplierLastNameErrorLabel";
            this.supplierLastNameErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.supplierLastNameErrorLabel.TabIndex = 45;
            this.supplierLastNameErrorLabel.Text = "*";
            this.supplierLastNameErrorLabel.Visible = false;
            // 
            // FarmSupplierComboBox
            // 
            this.FarmSupplierComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.FarmSupplierComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FarmSupplierComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FarmSupplierComboBox.FormattingEnabled = true;
            this.FarmSupplierComboBox.Location = new System.Drawing.Point(119, 294);
            this.FarmSupplierComboBox.Name = "FarmSupplierComboBox";
            this.FarmSupplierComboBox.Size = new System.Drawing.Size(160, 29);
            this.FarmSupplierComboBox.TabIndex = 47;
            // 
            // farmSupplierLabel
            // 
            this.farmSupplierLabel.AutoSize = true;
            this.farmSupplierLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.farmSupplierLabel.ForeColor = System.Drawing.Color.White;
            this.farmSupplierLabel.Location = new System.Drawing.Point(119, 269);
            this.farmSupplierLabel.Name = "farmSupplierLabel";
            this.farmSupplierLabel.Size = new System.Drawing.Size(70, 21);
            this.farmSupplierLabel.TabIndex = 48;
            this.farmSupplierLabel.Text = "Champs:";
            // 
            // farmSupplierErrorLabel
            // 
            this.farmSupplierErrorLabel.AutoSize = true;
            this.farmSupplierErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.farmSupplierErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.farmSupplierErrorLabel.Location = new System.Drawing.Point(261, 269);
            this.farmSupplierErrorLabel.Name = "farmSupplierErrorLabel";
            this.farmSupplierErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.farmSupplierErrorLabel.TabIndex = 49;
            this.farmSupplierErrorLabel.Text = "*";
            this.farmSupplierErrorLabel.Visible = false;
            // 
            // ProductSupplierComboBox
            // 
            this.ProductSupplierComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ProductSupplierComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ProductSupplierComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductSupplierComboBox.FormattingEnabled = true;
            this.ProductSupplierComboBox.Location = new System.Drawing.Point(119, 364);
            this.ProductSupplierComboBox.Name = "ProductSupplierComboBox";
            this.ProductSupplierComboBox.Size = new System.Drawing.Size(160, 29);
            this.ProductSupplierComboBox.TabIndex = 50;
            // 
            // productSupplierLabel
            // 
            this.productSupplierLabel.AutoSize = true;
            this.productSupplierLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productSupplierLabel.ForeColor = System.Drawing.Color.White;
            this.productSupplierLabel.Location = new System.Drawing.Point(119, 341);
            this.productSupplierLabel.Name = "productSupplierLabel";
            this.productSupplierLabel.Size = new System.Drawing.Size(71, 21);
            this.productSupplierLabel.TabIndex = 51;
            this.productSupplierLabel.Text = "Produits:";
            // 
            // productSupplierErrorLabel
            // 
            this.productSupplierErrorLabel.AutoSize = true;
            this.productSupplierErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productSupplierErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.productSupplierErrorLabel.Location = new System.Drawing.Point(259, 341);
            this.productSupplierErrorLabel.Name = "productSupplierErrorLabel";
            this.productSupplierErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.productSupplierErrorLabel.TabIndex = 52;
            this.productSupplierErrorLabel.Text = "*";
            this.productSupplierErrorLabel.Visible = false;
            // 
            // FormAddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.ProductSupplierComboBox);
            this.Controls.Add(this.productSupplierLabel);
            this.Controls.Add(this.productSupplierErrorLabel);
            this.Controls.Add(this.FarmSupplierComboBox);
            this.Controls.Add(this.farmSupplierLabel);
            this.Controls.Add(this.farmSupplierErrorLabel);
            this.Controls.Add(this.SupplierLastNameLabel);
            this.Controls.Add(this.SupplierLastNameTextBox);
            this.Controls.Add(this.supplierLastNameErrorLabel);
            this.Controls.Add(this.SupplierFirstNameLabel);
            this.Controls.Add(this.SupplierFirstNameTextBox);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.handleSaveButton);
            this.Controls.Add(this.SupplierNameComboBox);
            this.Controls.Add(this.SupplierLabel);
            this.Controls.Add(this.nameSupplierErrorLabel);
            this.Controls.Add(this.supplierFirstNameErrorLabel);
            this.Name = "FormAddSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddSupplier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddProduct_FormClosed);
            this.Load += new System.EventHandler(this.FormAddSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SupplierFirstNameLabel;
        private System.Windows.Forms.TextBox SupplierFirstNameTextBox;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button handleSaveButton;
        private System.Windows.Forms.ComboBox SupplierNameComboBox;
        private System.Windows.Forms.Label SupplierLabel;
        private System.Windows.Forms.Label nameSupplierErrorLabel;
        private System.Windows.Forms.Label supplierFirstNameErrorLabel;
        private System.Windows.Forms.Label SupplierLastNameLabel;
        private System.Windows.Forms.TextBox SupplierLastNameTextBox;
        private System.Windows.Forms.Label supplierLastNameErrorLabel;
        private System.Windows.Forms.ComboBox FarmSupplierComboBox;
        private System.Windows.Forms.Label farmSupplierLabel;
        private System.Windows.Forms.Label farmSupplierErrorLabel;
        private System.Windows.Forms.ComboBox ProductSupplierComboBox;
        private System.Windows.Forms.Label productSupplierLabel;
        private System.Windows.Forms.Label productSupplierErrorLabel;
    }
}