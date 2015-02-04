namespace NewGMS
{
    partial class frmSupplier
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
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblSupplierType = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.cmbSupplierType = new System.Windows.Forms.ComboBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblSave = new System.Windows.Forms.Button();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.gbMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(49, 106);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(76, 13);
            this.lblSupplierName.TabIndex = 0;
            this.lblSupplierName.Text = "Supplier Name";
            // 
            // lblSupplierType
            // 
            this.lblSupplierType.AutoSize = true;
            this.lblSupplierType.Location = new System.Drawing.Point(49, 157);
            this.lblSupplierType.Name = "lblSupplierType";
            this.lblSupplierType.Size = new System.Drawing.Size(72, 13);
            this.lblSupplierType.TabIndex = 0;
            this.lblSupplierType.Text = "Supplier Type";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Location = new System.Drawing.Point(49, 210);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(80, 13);
            this.lblContactPerson.TabIndex = 0;
            this.lblContactPerson.Text = "Contact Person";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(55, 260);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(155, 103);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(128, 20);
            this.txtSupplierName.TabIndex = 1;
            this.txtSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierName_KeyDown);
            // 
            // cmbSupplierType
            // 
            this.cmbSupplierType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierType.FormattingEnabled = true;
            this.cmbSupplierType.Location = new System.Drawing.Point(155, 154);
            this.cmbSupplierType.Name = "cmbSupplierType";
            this.cmbSupplierType.Size = new System.Drawing.Size(128, 21);
            this.cmbSupplierType.TabIndex = 2;
            this.cmbSupplierType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSupplierType_KeyDown);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(155, 206);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(128, 20);
            this.txtContactPerson.TabIndex = 1;
            this.txtContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactPerson_KeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(155, 257);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(128, 20);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // lblSave
            // 
            this.lblSave.Location = new System.Drawing.Point(104, 241);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(75, 23);
            this.lblSave.TabIndex = 3;
            this.lblSave.Text = "Save";
            this.lblSave.UseVisualStyleBackColor = true;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.AllowUserToAddRows = false;
            this.dgvSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.Location = new System.Drawing.Point(314, 22);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            this.dgvSupplier.Size = new System.Drawing.Size(591, 317);
            this.dgvSupplier.TabIndex = 4;
            this.dgvSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellDoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(187, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbMode
            // 
            this.gbMode.Controls.Add(this.btnCancel);
            this.gbMode.Controls.Add(this.btnNew);
            this.gbMode.Controls.Add(this.lblSave);
            this.gbMode.Location = new System.Drawing.Point(21, 63);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(274, 276);
            this.gbMode.TabIndex = 6;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Supplier Entry";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(13, 240);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(148, 12);
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(52, 20);
            this.txtMode.TabIndex = 6;
            this.txtMode.Text = "New";
            this.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mode";
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 363);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSupplier);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.cmbSupplierType);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblContactPerson);
            this.Controls.Add(this.lblSupplierType);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.gbMode);
            this.Name = "frmSupplier";
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.Shown += new System.EventHandler(this.frmSupplier_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.gbMode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblSupplierType;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.ComboBox cmbSupplierType;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button lblSave;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Label label1;
    }
}