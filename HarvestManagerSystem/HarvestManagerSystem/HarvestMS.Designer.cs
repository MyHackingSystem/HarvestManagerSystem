
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HarvestMS));
            this.tabProduction = new System.Windows.Forms.TabControl();
            this.tabPageQuantity = new System.Windows.Forms.TabPage();
            this.toLabel = new System.Windows.Forms.Label();
            this.btnSearchQuantityProduction = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageHours = new System.Windows.Forms.TabPage();
            this.tabPageTransportCredit = new System.Windows.Forms.TabPage();
            this.tabPageEmployee = new System.Windows.Forms.TabPage();
            this.tabPageSupplier = new System.Windows.Forms.TabPage();
            this.tabPageFarm = new System.Windows.Forms.TabPage();
            this.tabPageProduct = new System.Windows.Forms.TabPage();
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
            this.tabProduction.SuspendLayout();
            this.tabPageQuantity.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabProduction
            // 
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
            this.tabProduction.Size = new System.Drawing.Size(1129, 614);
            this.tabProduction.TabIndex = 2;
            // 
            // tabPageQuantity
            // 
            this.tabPageQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageQuantity.Controls.Add(this.toLabel);
            this.tabPageQuantity.Controls.Add(this.btnSearchQuantityProduction);
            this.tabPageQuantity.Controls.Add(this.dateTimePicker2);
            this.tabPageQuantity.Controls.Add(this.dateTimePicker1);
            this.tabPageQuantity.Controls.Add(this.label2);
            this.tabPageQuantity.ForeColor = System.Drawing.Color.White;
            this.tabPageQuantity.Location = new System.Drawing.Point(4, 34);
            this.tabPageQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageQuantity.Name = "tabPageQuantity";
            this.tabPageQuantity.Size = new System.Drawing.Size(1121, 576);
            this.tabPageQuantity.TabIndex = 0;
            this.tabPageQuantity.Text = "Quantity";
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
            this.btnSearchQuantityProduction.ForeColor = System.Drawing.Color.Black;
            this.btnSearchQuantityProduction.Location = new System.Drawing.Point(658, 16);
            this.btnSearchQuantityProduction.Name = "btnSearchQuantityProduction";
            this.btnSearchQuantityProduction.Size = new System.Drawing.Size(120, 30);
            this.btnSearchQuantityProduction.TabIndex = 3;
            this.btnSearchQuantityProduction.Text = "Chercher";
            this.btnSearchQuantityProduction.UseVisualStyleBackColor = false;
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
            this.tabPageHours.Size = new System.Drawing.Size(1121, 576);
            this.tabPageHours.TabIndex = 1;
            this.tabPageHours.Text = "Heures";
            // 
            // tabPageTransportCredit
            // 
            this.tabPageTransportCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageTransportCredit.Location = new System.Drawing.Point(4, 34);
            this.tabPageTransportCredit.Name = "tabPageTransportCredit";
            this.tabPageTransportCredit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTransportCredit.Size = new System.Drawing.Size(1121, 576);
            this.tabPageTransportCredit.TabIndex = 2;
            this.tabPageTransportCredit.Text = "Transport / Credit";
            // 
            // tabPageEmployee
            // 
            this.tabPageEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageEmployee.Location = new System.Drawing.Point(4, 34);
            this.tabPageEmployee.Name = "tabPageEmployee";
            this.tabPageEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployee.Size = new System.Drawing.Size(1121, 576);
            this.tabPageEmployee.TabIndex = 3;
            this.tabPageEmployee.Text = "Employées";
            // 
            // tabPageSupplier
            // 
            this.tabPageSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageSupplier.Location = new System.Drawing.Point(4, 34);
            this.tabPageSupplier.Name = "tabPageSupplier";
            this.tabPageSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupplier.Size = new System.Drawing.Size(1121, 576);
            this.tabPageSupplier.TabIndex = 4;
            this.tabPageSupplier.Text = "Fournisseur";
            // 
            // tabPageFarm
            // 
            this.tabPageFarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageFarm.Location = new System.Drawing.Point(4, 34);
            this.tabPageFarm.Name = "tabPageFarm";
            this.tabPageFarm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFarm.Size = new System.Drawing.Size(1121, 576);
            this.tabPageFarm.TabIndex = 5;
            this.tabPageFarm.Text = "Champs";
            // 
            // tabPageProduct
            // 
            this.tabPageProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPageProduct.Location = new System.Drawing.Point(4, 34);
            this.tabPageProduct.Name = "tabPageProduct";
            this.tabPageProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduct.Size = new System.Drawing.Size(1121, 576);
            this.tabPageProduct.TabIndex = 6;
            this.tabPageProduct.Text = "Produits";
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
            // HarvestMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1284, 661);
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppLogo)).EndInit();
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
    }
}

