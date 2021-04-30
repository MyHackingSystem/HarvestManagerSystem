
namespace HarvestManagerSystem.view
{
    partial class FormAddEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEmployee));
            this.fxEmployeeStatus = new System.Windows.Forms.CheckBox();
            this.clearFieldsButton = new System.Windows.Forms.Button();
            this.fxPermissionDate = new System.Windows.Forms.DateTimePicker();
            this.fxFireDate = new System.Windows.Forms.DateTimePicker();
            this.fxHireDate = new System.Windows.Forms.DateTimePicker();
            this.handleSaveButton = new System.Windows.Forms.Button();
            this.fxLastName = new System.Windows.Forms.TextBox();
            this.fxFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.firstNameErrorLabel = new System.Windows.Forms.Label();
            this.lastNameErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fxEmployeeStatus
            // 
            this.fxEmployeeStatus.AutoSize = true;
            this.fxEmployeeStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fxEmployeeStatus.ForeColor = System.Drawing.Color.White;
            this.fxEmployeeStatus.Location = new System.Drawing.Point(112, 376);
            this.fxEmployeeStatus.Name = "fxEmployeeStatus";
            this.fxEmployeeStatus.Size = new System.Drawing.Size(55, 25);
            this.fxEmployeeStatus.TabIndex = 6;
            this.fxEmployeeStatus.Text = "Etat";
            this.fxEmployeeStatus.UseVisualStyleBackColor = true;
            // 
            // clearFieldsButton
            // 
            this.clearFieldsButton.BackColor = System.Drawing.Color.DarkOrange;
            this.clearFieldsButton.FlatAppearance.BorderSize = 0;
            this.clearFieldsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.clearFieldsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.clearFieldsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearFieldsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearFieldsButton.Location = new System.Drawing.Point(216, 455);
            this.clearFieldsButton.Name = "clearFieldsButton";
            this.clearFieldsButton.Size = new System.Drawing.Size(120, 30);
            this.clearFieldsButton.TabIndex = 8;
            this.clearFieldsButton.Text = "Reset";
            this.clearFieldsButton.UseVisualStyleBackColor = false;
            this.clearFieldsButton.Click += new System.EventHandler(this.clearFieldsButton_Click);
            // 
            // fxPermissionDate
            // 
            this.fxPermissionDate.Location = new System.Drawing.Point(112, 330);
            this.fxPermissionDate.Name = "fxPermissionDate";
            this.fxPermissionDate.Size = new System.Drawing.Size(160, 23);
            this.fxPermissionDate.TabIndex = 5;
            // 
            // fxFireDate
            // 
            this.fxFireDate.Location = new System.Drawing.Point(112, 263);
            this.fxFireDate.Name = "fxFireDate";
            this.fxFireDate.Size = new System.Drawing.Size(160, 23);
            this.fxFireDate.TabIndex = 4;
            // 
            // fxHireDate
            // 
            this.fxHireDate.Location = new System.Drawing.Point(112, 198);
            this.fxHireDate.Name = "fxHireDate";
            this.fxHireDate.Size = new System.Drawing.Size(160, 23);
            this.fxHireDate.TabIndex = 3;
            // 
            // handleSaveButton
            // 
            this.handleSaveButton.BackColor = System.Drawing.Color.DarkOrange;
            this.handleSaveButton.FlatAppearance.BorderSize = 0;
            this.handleSaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.handleSaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.handleSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.handleSaveButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.handleSaveButton.Location = new System.Drawing.Point(58, 455);
            this.handleSaveButton.Name = "handleSaveButton";
            this.handleSaveButton.Size = new System.Drawing.Size(120, 30);
            this.handleSaveButton.TabIndex = 7;
            this.handleSaveButton.Text = "Ajouter";
            this.handleSaveButton.UseVisualStyleBackColor = false;
            this.handleSaveButton.Click += new System.EventHandler(this.handleSaveButton_Click);
            // 
            // fxLastName
            // 
            this.fxLastName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fxLastName.Location = new System.Drawing.Point(112, 132);
            this.fxLastName.MaxLength = 30;
            this.fxLastName.Name = "fxLastName";
            this.fxLastName.Size = new System.Drawing.Size(160, 23);
            this.fxLastName.TabIndex = 2;
            this.fxLastName.TextChanged += new System.EventHandler(this.fxLastName_TextChanged);
            // 
            // fxFirstName
            // 
            this.fxFirstName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fxFirstName.Location = new System.Drawing.Point(112, 72);
            this.fxFirstName.MaxLength = 30;
            this.fxFirstName.Name = "fxFirstName";
            this.fxFirstName.Size = new System.Drawing.Size(160, 23);
            this.fxFirstName.TabIndex = 1;
            this.fxFirstName.TextChanged += new System.EventHandler(this.fxFirstName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(112, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Date SCDZP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(112, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Fin CTR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(112, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Debut CTR";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLastName.ForeColor = System.Drawing.Color.White;
            this.labelLastName.Location = new System.Drawing.Point(112, 108);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(45, 21);
            this.labelLastName.TabIndex = 19;
            this.labelLastName.Text = "Nom";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFirstName.ForeColor = System.Drawing.Color.White;
            this.labelFirstName.Location = new System.Drawing.Point(112, 48);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(65, 21);
            this.labelFirstName.TabIndex = 18;
            this.labelFirstName.Text = "Prénom";
            // 
            // firstNameErrorLabel
            // 
            this.firstNameErrorLabel.AutoSize = true;
            this.firstNameErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.firstNameErrorLabel.Location = new System.Drawing.Point(253, 48);
            this.firstNameErrorLabel.Name = "firstNameErrorLabel";
            this.firstNameErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.firstNameErrorLabel.TabIndex = 31;
            this.firstNameErrorLabel.Text = "*";
            this.firstNameErrorLabel.Visible = false;
            // 
            // lastNameErrorLabel
            // 
            this.lastNameErrorLabel.AutoSize = true;
            this.lastNameErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.lastNameErrorLabel.Location = new System.Drawing.Point(253, 108);
            this.lastNameErrorLabel.Name = "lastNameErrorLabel";
            this.lastNameErrorLabel.Size = new System.Drawing.Size(28, 37);
            this.lastNameErrorLabel.TabIndex = 32;
            this.lastNameErrorLabel.Text = "*";
            this.lastNameErrorLabel.Visible = false;
            // 
            // FormAddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.fxEmployeeStatus);
            this.Controls.Add(this.clearFieldsButton);
            this.Controls.Add(this.fxPermissionDate);
            this.Controls.Add(this.fxFireDate);
            this.Controls.Add(this.fxHireDate);
            this.Controls.Add(this.handleSaveButton);
            this.Controls.Add(this.fxLastName);
            this.Controls.Add(this.fxFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.firstNameErrorLabel);
            this.Controls.Add(this.lastNameErrorLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddEmployee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddEmployee_FormClosed);
            this.Load += new System.EventHandler(this.FormAddEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox fxEmployeeStatus;
        private System.Windows.Forms.Button clearFieldsButton;
        private System.Windows.Forms.DateTimePicker fxPermissionDate;
        private System.Windows.Forms.DateTimePicker fxFireDate;
        private System.Windows.Forms.DateTimePicker fxHireDate;
        private System.Windows.Forms.Button handleSaveButton;
        private System.Windows.Forms.TextBox fxLastName;
        private System.Windows.Forms.TextBox fxFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label ProductErrorLabel;
        private System.Windows.Forms.Label firstNameErrorLabel;
        private System.Windows.Forms.Label lastNameErrorLabel;
    }
}