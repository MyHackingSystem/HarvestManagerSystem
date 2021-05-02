
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
            this.btnReset.Location = new System.Drawing.Point(214, 422);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 30);
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
            this.handleSaveButton.Location = new System.Drawing.Point(44, 422);
            this.handleSaveButton.Name = "handleSaveButton";
            this.handleSaveButton.Size = new System.Drawing.Size(120, 30);
            this.handleSaveButton.TabIndex = 28;
            this.handleSaveButton.Text = "Ajouter";
            this.handleSaveButton.UseVisualStyleBackColor = false;
            this.handleSaveButton.Click += new System.EventHandler(this.handleSaveButton_Click);
            // 
            // CreditAmountTextBox
            // 
            this.CreditAmountTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreditAmountTextBox.Location = new System.Drawing.Point(89, 293);
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
            this.CreditEmployeeComboBox.Location = new System.Drawing.Point(89, 209);
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
            this.creditPriceLabel.Location = new System.Drawing.Point(89, 269);
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
            this.EmployeeLabel.Location = new System.Drawing.Point(89, 184);
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
            this.creditEmployeeErrorLabel.Location = new System.Drawing.Point(261, 184);
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
            this.creditAmountErrorLabel.Location = new System.Drawing.Point(261, 269);
            this.creditAmountErrorLabel.Name = "creditAmountErrorLabel";
            this.creditAmountErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.creditAmountErrorLabel.TabIndex = 34;
            this.creditAmountErrorLabel.Text = "*";
            this.creditAmountErrorLabel.Visible = false;
            // 
            // CreditDatePicker
            // 
            this.CreditDatePicker.Location = new System.Drawing.Point(89, 129);
            this.CreditDatePicker.Name = "CreditDatePicker";
            this.CreditDatePicker.Size = new System.Drawing.Size(200, 23);
            this.CreditDatePicker.TabIndex = 35;
            // 
            // creditDateLabel
            // 
            this.creditDateLabel.AutoSize = true;
            this.creditDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.creditDateLabel.ForeColor = System.Drawing.Color.White;
            this.creditDateLabel.Location = new System.Drawing.Point(89, 105);
            this.creditDateLabel.Name = "creditDateLabel";
            this.creditDateLabel.Size = new System.Drawing.Size(42, 21);
            this.creditDateLabel.TabIndex = 36;
            this.creditDateLabel.Text = "Date";
            // 
            // FormAddCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.CreditDatePicker);
            this.Controls.Add(this.creditDateLabel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.handleSaveButton);
            this.Controls.Add(this.CreditAmountTextBox);
            this.Controls.Add(this.CreditEmployeeComboBox);
            this.Controls.Add(this.creditPriceLabel);
            this.Controls.Add(this.EmployeeLabel);
            this.Controls.Add(this.creditEmployeeErrorLabel);
            this.Controls.Add(this.creditAmountErrorLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddCredit";
            this.Load += new System.EventHandler(this.FormAddCredit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}