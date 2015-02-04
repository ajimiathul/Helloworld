namespace NewGMS
{
    partial class frmCustomer
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSave = new System.Windows.Forms.Button();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.lblSupplierType = new System.Windows.Forms.Label();
            this.lblCusName = new System.Windows.Forms.Label();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(208, 286);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSave
            // 
            this.lblSave.Location = new System.Drawing.Point(125, 287);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(75, 23);
            this.lblSave.TabIndex = 3;
            this.lblSave.Text = "Save";
            this.lblSave.UseVisualStyleBackColor = true;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(159, 122);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(128, 21);
            this.cmbCustomerType.TabIndex = 14;
            this.cmbCustomerType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomerType_KeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(159, 225);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(128, 20);
            this.txtAddress.TabIndex = 13;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(159, 174);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(128, 20);
            this.txtContactPerson.TabIndex = 11;
            this.txtContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactPerson_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(44, 287);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(159, 71);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(128, 20);
            this.txtCustomerName.TabIndex = 12;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyDown);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(59, 228);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Location = new System.Drawing.Point(53, 178);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(80, 13);
            this.lblContactPerson.TabIndex = 9;
            this.lblContactPerson.Text = "Contact Person";
            // 
            // lblSupplierType
            // 
            this.lblSupplierType.AutoSize = true;
            this.lblSupplierType.Location = new System.Drawing.Point(53, 125);
            this.lblSupplierType.Name = "lblSupplierType";
            this.lblSupplierType.Size = new System.Drawing.Size(78, 13);
            this.lblSupplierType.TabIndex = 8;
            this.lblSupplierType.Text = "Customer Type";
            // 
            // lblCusName
            // 
            this.lblCusName.AutoSize = true;
            this.lblCusName.Location = new System.Drawing.Point(53, 74);
            this.lblCusName.Name = "lblCusName";
            this.lblCusName.Size = new System.Drawing.Size(82, 13);
            this.lblCusName.TabIndex = 7;
            this.lblCusName.Text = "Customer Name";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(338, 30);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.Size = new System.Drawing.Size(525, 314);
            this.dgvCustomer.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(29, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 314);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Name Entry";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 376);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.cmbCustomerType);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblContactPerson);
            this.Controls.Add(this.lblSupplierType);
            this.Controls.Add(this.lblCusName);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCustomer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button lblSave;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.Label lblSupplierType;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}