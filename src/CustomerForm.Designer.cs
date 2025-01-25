namespace DatbaseProject
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;

 
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblIsActive;

  
        private System.Windows.Forms.Button btnShowRentals;       
        private System.Windows.Forms.Button btnGenerateReport;    

        private System.Windows.Forms.Button btnImportCars;        
        private System.Windows.Forms.Button btnImportCustomers;   

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();

  
            this.btnShowRentals = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();

            this.btnImportCars = new System.Windows.Forms.Button();
            this.btnImportCustomers = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.SuspendLayout();

            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(600, 250);
            this.dataGridViewCustomers.TabIndex = 0;
            this.dataGridViewCustomers.SelectionChanged +=
                new System.EventHandler(this.dataGridViewCustomers_SelectionChanged);

            this.txtFirstName.Location = new System.Drawing.Point(110, 280);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 23);
            this.txtFirstName.TabIndex = 1;

            this.txtLastName.Location = new System.Drawing.Point(110, 310);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 23);
            this.txtLastName.TabIndex = 2;

            this.txtEmail.Location = new System.Drawing.Point(110, 340);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 23);
            this.txtEmail.TabIndex = 3;

            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(110, 370);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(150, 23);
            this.dtpDateOfBirth.TabIndex = 4;

            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(110, 400);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(70, 19);
            this.chkIsActive.TabIndex = 5;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;

            this.btnLoad.Location = new System.Drawing.Point(320, 280);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 30);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.btnCreate.Location = new System.Drawing.Point(320, 320);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(80, 30);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            this.btnUpdate.Location = new System.Drawing.Point(320, 360);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(320, 400);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 283);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(67, 15);
            this.lblFirstName.TabIndex = 10;
            this.lblFirstName.Text = "First Name:";

            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 313);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(66, 15);
            this.lblLastName.TabIndex = 11;
            this.lblLastName.Text = "Last Name:";

            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 343);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email:";

            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(20, 376);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(80, 15);
            this.lblDateOfBirth.TabIndex = 13;
            this.lblDateOfBirth.Text = "Date of Birth:";

       
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(20, 401);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(52, 15);
            this.lblIsActive.TabIndex = 14;
            this.lblIsActive.Text = "IsActive:";

      
            this.btnShowRentals.Location = new System.Drawing.Point(420, 400);
            this.btnShowRentals.Name = "btnShowRentals";
            this.btnShowRentals.Size = new System.Drawing.Size(120, 30);
            this.btnShowRentals.TabIndex = 15;
            this.btnShowRentals.Text = "Zobrazit výpůjčky";
            this.btnShowRentals.UseVisualStyleBackColor = true;
            this.btnShowRentals.Click += new System.EventHandler(this.btnShowRentals_Click);

       
            this.btnGenerateReport.Location = new System.Drawing.Point(420, 360);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(120, 30);
            this.btnGenerateReport.TabIndex = 16;
            this.btnGenerateReport.Text = "Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

      
            this.btnImportCars.Location = new System.Drawing.Point(420, 280);
            this.btnImportCars.Name = "btnImportCars";
            this.btnImportCars.Size = new System.Drawing.Size(120, 30);
            this.btnImportCars.TabIndex = 17;
            this.btnImportCars.Text = "Import Cars";
            this.btnImportCars.UseVisualStyleBackColor = true;
            this.btnImportCars.Click += new System.EventHandler(this.btnImportCars_Click);

       
            this.btnImportCustomers.Location = new System.Drawing.Point(420, 320);
            this.btnImportCustomers.Name = "btnImportCustomers";
            this.btnImportCustomers.Size = new System.Drawing.Size(120, 30);
            this.btnImportCustomers.TabIndex = 18;
            this.btnImportCustomers.Text = "Import Customers";
            this.btnImportCustomers.UseVisualStyleBackColor = true;
            this.btnImportCustomers.Click += new System.EventHandler(this.btnImportCustomers_Click);

            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);

         
            this.Controls.Add(this.dataGridViewCustomers);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblIsActive);

           
            this.Controls.Add(this.btnShowRentals);
            this.Controls.Add(this.btnGenerateReport);

 
            this.Controls.Add(this.btnImportCars);
            this.Controls.Add(this.btnImportCustomers);

            this.Name = "CustomerForm";
            this.Text = "CustomerForm";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
