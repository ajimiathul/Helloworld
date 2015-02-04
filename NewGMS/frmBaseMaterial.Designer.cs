namespace NewGMS
{
    partial class frmBaseMaterial
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.txtMat = new System.Windows.Forms.TextBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Base Material";
            // 
            // txtMode
            // 
            this.txtMode.Enabled = false;
            this.txtMode.Location = new System.Drawing.Point(12, 482);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(172, 20);
            this.txtMode.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(385, 114);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(385, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(385, 27);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperties.Location = new System.Drawing.Point(12, 143);
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.Size = new System.Drawing.Size(448, 333);
            this.dgvProperties.TabIndex = 10;
            this.dgvProperties.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperties_CellDoubleClick);
            // 
            // txtMat
            // 
            this.txtMat.Location = new System.Drawing.Point(12, 30);
            this.txtMat.Name = "txtMat";
            this.txtMat.Size = new System.Drawing.Size(206, 20);
            this.txtMat.TabIndex = 9;
            // 
            // cmbAccount
            // 
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(12, 77);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(206, 21);
            this.cmbAccount.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Eqt Account Head";
            // 
            // frmBaseMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvProperties);
            this.Controls.Add(this.txtMat);
            this.Name = "frmBaseMaterial";
            this.Text = "frmBaseMaterial";
            this.Load += new System.EventHandler(this.frmBaseMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.TextBox txtMat;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label label2;
    }
}