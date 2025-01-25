namespace DatbaseProject
{
    partial class CustomerRentalsForm
    {

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
            this.dataGridViewRentals = new System.Windows.Forms.DataGridView();
            this.btnAddRental = new System.Windows.Forms.Button();
            this.btnDeleteRental = new System.Windows.Forms.Button();
            this.comboCar = new System.Windows.Forms.ComboBox();
            this.lblCar = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRentals)).BeginInit();
            this.SuspendLayout();

            this.dataGridViewRentals.AllowUserToAddRows = false;
            this.dataGridViewRentals.AllowUserToDeleteRows = false;
            this.dataGridViewRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRentals.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRentals.Name = "dataGridViewRentals";
            this.dataGridViewRentals.ReadOnly = true;
            this.dataGridViewRentals.Size = new System.Drawing.Size(460, 150);
            this.dataGridViewRentals.TabIndex = 0;

            this.btnAddRental.Location = new System.Drawing.Point(12, 255);
            this.btnAddRental.Name = "btnAddRental";
            this.btnAddRental.Size = new System.Drawing.Size(100, 28);
            this.btnAddRental.TabIndex = 1;
            this.btnAddRental.Text = "Přidat výpůjčku";
            this.btnAddRental.UseVisualStyleBackColor = true;
            this.btnAddRental.Click += new System.EventHandler(this.btnAddRental_Click);

            this.btnDeleteRental.Location = new System.Drawing.Point(130, 255);
            this.btnDeleteRental.Name = "btnDeleteRental";
            this.btnDeleteRental.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteRental.TabIndex = 2;
            this.btnDeleteRental.Text = "Smazat výpůjčku";
            this.btnDeleteRental.UseVisualStyleBackColor = true;
            this.btnDeleteRental.Click += new System.EventHandler(this.btnDeleteRental_Click);

            this.comboCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCar.FormattingEnabled = true;
            this.comboCar.Location = new System.Drawing.Point(12, 197);
            this.comboCar.Name = "comboCar";
            this.comboCar.Size = new System.Drawing.Size(218, 21);
            this.comboCar.TabIndex = 3;
 
            this.lblCar.AutoSize = true;
            this.lblCar.Location = new System.Drawing.Point(9, 181);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(25, 13);
            this.lblCar.TabIndex = 4;
            this.lblCar.Text = "Car";

            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(246, 181);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 5;
            this.lblStartDate.Text = "Začátek od";
 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(360, 181);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(62, 13);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "Konec dne";

            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(9, 221);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(55, 13);
            this.lblTotalPrice.TabIndex = 7;
            this.lblTotalPrice.Text = "TotalPrice";

            this.dateTimePickerStart.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(249, 197);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(108, 20);
            this.dateTimePickerStart.TabIndex = 8;

            this.dateTimePickerEnd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(363, 197);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(109, 20);
            this.dateTimePickerEnd.TabIndex = 9;
   
            this.txtTotalPrice.Location = new System.Drawing.Point(70, 218);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(160, 20);
            this.txtTotalPrice.TabIndex = 10;
  
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 295);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblCar);
            this.Controls.Add(this.comboCar);
            this.Controls.Add(this.btnDeleteRental);
            this.Controls.Add(this.btnAddRental);
            this.Controls.Add(this.dataGridViewRentals);
            this.Name = "CustomerRentalsForm";
            this.Text = "CustomerRentalsForm";
            this.Load += new System.EventHandler(this.CustomerRentalsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewRentals;
        private System.Windows.Forms.Button btnAddRental;
        private System.Windows.Forms.Button btnDeleteRental;
        private System.Windows.Forms.ComboBox comboCar;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.TextBox txtTotalPrice;
    }
}
