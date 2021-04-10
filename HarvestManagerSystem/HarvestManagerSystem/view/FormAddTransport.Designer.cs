
namespace HarvestManagerSystem.view
{
    partial class FormAddTransport
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
            this.TransportDatePicker = new System.Windows.Forms.DateTimePicker();
            this.transportDateLabel = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.handleSaveButton = new System.Windows.Forms.Button();
            this.TransportAmountTextBox = new System.Windows.Forms.TextBox();
            this.TransportEmployeeComboBox = new System.Windows.Forms.ComboBox();
            this.transportAmountLabel = new System.Windows.Forms.Label();
            this.transportEmployeeLabel = new System.Windows.Forms.Label();
            this.transportEmployeeErrorLabel = new System.Windows.Forms.Label();
            this.transportAmountErrorLabel = new System.Windows.Forms.Label();
            this.TransportFarmComboBox = new System.Windows.Forms.ComboBox();
            this.transportFarmLabel = new System.Windows.Forms.Label();
            this.transportFarmErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TransportDatePicker
            // 
            this.TransportDatePicker.Location = new System.Drawing.Point(80, 90);
            this.TransportDatePicker.Name = "TransportDatePicker";
            this.TransportDatePicker.Size = new System.Drawing.Size(200, 23);
            this.TransportDatePicker.TabIndex = 46;
            // 
            // transportDateLabel
            // 
            this.transportDateLabel.AutoSize = true;
            this.transportDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transportDateLabel.ForeColor = System.Drawing.Color.White;
            this.transportDateLabel.Location = new System.Drawing.Point(80, 66);
            this.transportDateLabel.Name = "transportDateLabel";
            this.transportDateLabel.Size = new System.Drawing.Size(42, 21);
            this.transportDateLabel.TabIndex = 47;
            this.transportDateLabel.Text = "Date";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DarkOrange;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(205, 435);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 30);
            this.btnReset.TabIndex = 40;
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
            this.btnCancel.TabIndex = 41;
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
            this.handleSaveButton.Location = new System.Drawing.Point(35, 435);
            this.handleSaveButton.Name = "handleSaveButton";
            this.handleSaveButton.Size = new System.Drawing.Size(120, 30);
            this.handleSaveButton.TabIndex = 39;
            this.handleSaveButton.Text = "Ajouter";
            this.handleSaveButton.UseVisualStyleBackColor = false;
            this.handleSaveButton.Click += new System.EventHandler(this.handleSaveButton_Click);
            // 
            // TransportAmountTextBox
            // 
            this.TransportAmountTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TransportAmountTextBox.Location = new System.Drawing.Point(80, 254);
            this.TransportAmountTextBox.Name = "TransportAmountTextBox";
            this.TransportAmountTextBox.Size = new System.Drawing.Size(200, 29);
            this.TransportAmountTextBox.TabIndex = 38;
            // 
            // TransportEmployeeComboBox
            // 
            this.TransportEmployeeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TransportEmployeeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TransportEmployeeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransportEmployeeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TransportEmployeeComboBox.FormattingEnabled = true;
            this.TransportEmployeeComboBox.Location = new System.Drawing.Point(80, 170);
            this.TransportEmployeeComboBox.MinimumSize = new System.Drawing.Size(180, 0);
            this.TransportEmployeeComboBox.Name = "TransportEmployeeComboBox";
            this.TransportEmployeeComboBox.Size = new System.Drawing.Size(200, 29);
            this.TransportEmployeeComboBox.TabIndex = 37;
            // 
            // transportAmountLabel
            // 
            this.transportAmountLabel.AutoSize = true;
            this.transportAmountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transportAmountLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.transportAmountLabel.Location = new System.Drawing.Point(80, 230);
            this.transportAmountLabel.Name = "transportAmountLabel";
            this.transportAmountLabel.Size = new System.Drawing.Size(72, 21);
            this.transportAmountLabel.TabIndex = 43;
            this.transportAmountLabel.Text = "Montant:";
            // 
            // transportEmployeeLabel
            // 
            this.transportEmployeeLabel.AutoSize = true;
            this.transportEmployeeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transportEmployeeLabel.ForeColor = System.Drawing.Color.White;
            this.transportEmployeeLabel.Location = new System.Drawing.Point(80, 145);
            this.transportEmployeeLabel.Name = "transportEmployeeLabel";
            this.transportEmployeeLabel.Size = new System.Drawing.Size(81, 21);
            this.transportEmployeeLabel.TabIndex = 42;
            this.transportEmployeeLabel.Text = "Employée:";
            // 
            // transportEmployeeErrorLabel
            // 
            this.transportEmployeeErrorLabel.AutoSize = true;
            this.transportEmployeeErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transportEmployeeErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.transportEmployeeErrorLabel.Location = new System.Drawing.Point(252, 145);
            this.transportEmployeeErrorLabel.Name = "transportEmployeeErrorLabel";
            this.transportEmployeeErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.transportEmployeeErrorLabel.TabIndex = 44;
            this.transportEmployeeErrorLabel.Text = "*";
            this.transportEmployeeErrorLabel.Visible = false;
            // 
            // transportAmountErrorLabel
            // 
            this.transportAmountErrorLabel.AutoSize = true;
            this.transportAmountErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transportAmountErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.transportAmountErrorLabel.Location = new System.Drawing.Point(252, 230);
            this.transportAmountErrorLabel.Name = "transportAmountErrorLabel";
            this.transportAmountErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.transportAmountErrorLabel.TabIndex = 45;
            this.transportAmountErrorLabel.Text = "*";
            this.transportAmountErrorLabel.Visible = false;
            // 
            // TransportFarmComboBox
            // 
            this.TransportFarmComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TransportFarmComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TransportFarmComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransportFarmComboBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TransportFarmComboBox.FormattingEnabled = true;
            this.TransportFarmComboBox.Location = new System.Drawing.Point(80, 337);
            this.TransportFarmComboBox.MinimumSize = new System.Drawing.Size(180, 0);
            this.TransportFarmComboBox.Name = "TransportFarmComboBox";
            this.TransportFarmComboBox.Size = new System.Drawing.Size(200, 29);
            this.TransportFarmComboBox.TabIndex = 48;
            // 
            // transportFarmLabel
            // 
            this.transportFarmLabel.AutoSize = true;
            this.transportFarmLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transportFarmLabel.ForeColor = System.Drawing.Color.White;
            this.transportFarmLabel.Location = new System.Drawing.Point(80, 312);
            this.transportFarmLabel.Name = "transportFarmLabel";
            this.transportFarmLabel.Size = new System.Drawing.Size(63, 21);
            this.transportFarmLabel.TabIndex = 49;
            this.transportFarmLabel.Text = "Champ:";
            // 
            // transportFarmErrorLabel
            // 
            this.transportFarmErrorLabel.AutoSize = true;
            this.transportFarmErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transportFarmErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.transportFarmErrorLabel.Location = new System.Drawing.Point(252, 312);
            this.transportFarmErrorLabel.Name = "transportFarmErrorLabel";
            this.transportFarmErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.transportFarmErrorLabel.TabIndex = 50;
            this.transportFarmErrorLabel.Text = "*";
            this.transportFarmErrorLabel.Visible = false;
            // 
            // FormAddTransport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.TransportFarmComboBox);
            this.Controls.Add(this.transportFarmLabel);
            this.Controls.Add(this.transportFarmErrorLabel);
            this.Controls.Add(this.TransportDatePicker);
            this.Controls.Add(this.transportDateLabel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.handleSaveButton);
            this.Controls.Add(this.TransportAmountTextBox);
            this.Controls.Add(this.TransportEmployeeComboBox);
            this.Controls.Add(this.transportAmountLabel);
            this.Controls.Add(this.transportEmployeeLabel);
            this.Controls.Add(this.transportEmployeeErrorLabel);
            this.Controls.Add(this.transportAmountErrorLabel);
            this.Name = "FormAddTransport";
            this.Text = "FormAddTransport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddTransport_FormClosed);
            this.Load += new System.EventHandler(this.FormAddTransport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker TransportDatePicker;
        private System.Windows.Forms.Label transportDateLabel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button handleSaveButton;
        private System.Windows.Forms.TextBox TransportAmountTextBox;
        private System.Windows.Forms.ComboBox TransportEmployeeComboBox;
        private System.Windows.Forms.Label transportAmountLabel;
        private System.Windows.Forms.Label transportEmployeeLabel;
        private System.Windows.Forms.Label transportEmployeeErrorLabel;
        private System.Windows.Forms.Label transportAmountErrorLabel;
        private System.Windows.Forms.ComboBox TransportFarmComboBox;
        private System.Windows.Forms.Label transportFarmLabel;
        private System.Windows.Forms.Label transportFarmErrorLabel;
    }
}