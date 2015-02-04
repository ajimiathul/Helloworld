namespace NewGMS
{
    partial class frmBankReconsolation
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbsA = new System.Windows.Forms.RadioButton();
            this.rbSuc = new System.Windows.Forms.RadioButton();
            this.rbSc = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt60 = new System.Windows.Forms.RadioButton();
            this.rbtdal = new System.Windows.Forms.RadioButton();
            this.rbt120 = new System.Windows.Forms.RadioButton();
            this.lvBankReconsltn = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.cmbBankAccont = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpclear = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbsA);
            this.groupBox3.Controls.Add(this.rbSuc);
            this.groupBox3.Controls.Add(this.rbSc);
            this.groupBox3.Location = new System.Drawing.Point(356, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 93);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // rbsA
            // 
            this.rbsA.AutoSize = true;
            this.rbsA.Location = new System.Drawing.Point(7, 62);
            this.rbsA.Name = "rbsA";
            this.rbsA.Size = new System.Drawing.Size(36, 17);
            this.rbsA.TabIndex = 2;
            this.rbsA.TabStop = true;
            this.rbsA.Text = "All";
            this.rbsA.UseVisualStyleBackColor = true;
            this.rbsA.CheckedChanged += new System.EventHandler(this.rbsA_CheckedChanged);
            // 
            // rbSuc
            // 
            this.rbSuc.AutoSize = true;
            this.rbSuc.Location = new System.Drawing.Point(111, 28);
            this.rbSuc.Name = "rbSuc";
            this.rbSuc.Size = new System.Drawing.Size(74, 17);
            this.rbSuc.TabIndex = 1;
            this.rbSuc.TabStop = true;
            this.rbSuc.Text = "Uncleared";
            this.rbSuc.UseVisualStyleBackColor = true;
            this.rbSuc.CheckedChanged += new System.EventHandler(this.rbSuc_CheckedChanged);
            // 
            // rbSc
            // 
            this.rbSc.AutoSize = true;
            this.rbSc.Location = new System.Drawing.Point(7, 28);
            this.rbSc.Name = "rbSc";
            this.rbSc.Size = new System.Drawing.Size(61, 17);
            this.rbSc.TabIndex = 0;
            this.rbSc.TabStop = true;
            this.rbSc.Text = "Cleared";
            this.rbSc.UseVisualStyleBackColor = true;
            this.rbSc.CheckedChanged += new System.EventHandler(this.rbSc_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt60);
            this.groupBox2.Controls.Add(this.rbtdal);
            this.groupBox2.Controls.Add(this.rbt120);
            this.groupBox2.Location = new System.Drawing.Point(56, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 85);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Days";
            // 
            // rbt60
            // 
            this.rbt60.AutoSize = true;
            this.rbt60.Location = new System.Drawing.Point(15, 29);
            this.rbt60.Name = "rbt60";
            this.rbt60.Size = new System.Drawing.Size(62, 17);
            this.rbt60.TabIndex = 40;
            this.rbt60.TabStop = true;
            this.rbt60.Text = "60 days";
            this.rbt60.UseVisualStyleBackColor = true;
            this.rbt60.CheckedChanged += new System.EventHandler(this.rbt60_CheckedChanged);
            // 
            // rbtdal
            // 
            this.rbtdal.AutoSize = true;
            this.rbtdal.Location = new System.Drawing.Point(15, 63);
            this.rbtdal.Name = "rbtdal";
            this.rbtdal.Size = new System.Drawing.Size(36, 17);
            this.rbtdal.TabIndex = 42;
            this.rbtdal.TabStop = true;
            this.rbtdal.Text = "All";
            this.rbtdal.UseVisualStyleBackColor = true;
            this.rbtdal.CheckedChanged += new System.EventHandler(this.rbtdal_CheckedChanged);
            // 
            // rbt120
            // 
            this.rbt120.AutoSize = true;
            this.rbt120.Location = new System.Drawing.Point(106, 29);
            this.rbt120.Name = "rbt120";
            this.rbt120.Size = new System.Drawing.Size(68, 17);
            this.rbt120.TabIndex = 41;
            this.rbt120.TabStop = true;
            this.rbt120.Text = "120 days";
            this.rbt120.UseVisualStyleBackColor = true;
            this.rbt120.CheckedChanged += new System.EventHandler(this.rbt120_CheckedChanged);
            // 
            // lvBankReconsltn
            // 
            this.lvBankReconsltn.CheckBoxes = true;
            this.lvBankReconsltn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvBankReconsltn.FullRowSelect = true;
            this.lvBankReconsltn.GridLines = true;
            this.lvBankReconsltn.Location = new System.Drawing.Point(21, 180);
            this.lvBankReconsltn.MultiSelect = false;
            this.lvBankReconsltn.Name = "lvBankReconsltn";
            this.lvBankReconsltn.Size = new System.Drawing.Size(788, 298);
            this.lvBankReconsltn.TabIndex = 39;
            this.lvBankReconsltn.UseCompatibleStateImageBehavior = false;
            this.lvBankReconsltn.View = System.Windows.Forms.View.Details;
            this.lvBankReconsltn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvBankReconsltn_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Cheque No.";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cheque Date";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Clearence Date";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Cleared";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Debit";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Credit";
            this.columnHeader6.Width = 100;
            // 
            // cmbBankAccont
            // 
            this.cmbBankAccont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankAccont.FormattingEnabled = true;
            this.cmbBankAccont.Location = new System.Drawing.Point(160, 24);
            this.cmbBankAccont.Name = "cmbBankAccont";
            this.cmbBankAccont.Size = new System.Drawing.Size(121, 21);
            this.cmbBankAccont.TabIndex = 9;
            this.cmbBankAccont.SelectedIndexChanged += new System.EventHandler(this.cmbBankAccont_SelectedIndexChanged);
            this.cmbBankAccont.DropDownClosed += new System.EventHandler(this.cmbBankAccont_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bank Account";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(456, 25);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "As On";
            // 
            // dtpclear
            // 
            this.dtpclear.CustomFormat = "dd/MM/yyyy";
            this.dtpclear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpclear.Location = new System.Drawing.Point(818, 435);
            this.dtpclear.Name = "dtpclear";
            this.dtpclear.Size = new System.Drawing.Size(91, 20);
            this.dtpclear.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(815, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Clearence Date";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(834, 461);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 49;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click_1);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Recid";
            this.columnHeader7.Width = 78;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "VocherDate";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "VoucherNo";
            // 
            // frmBankReconsolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 511);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dtpclear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvBankReconsltn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBankAccont);
            this.Controls.Add(this.dtpDate);
            this.Name = "frmBankReconsolation";
            this.Text = "frmBankReconsolation";
            this.Load += new System.EventHandler(this.frmBankReconsolation_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBankAccont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvBankReconsltn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.RadioButton rbt120;
        private System.Windows.Forms.RadioButton rbt60;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbsA;
        private System.Windows.Forms.RadioButton rbSuc;
        private System.Windows.Forms.RadioButton rbSc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtdal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpclear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;

    }
}