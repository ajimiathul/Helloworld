namespace NewGMS
{
    partial class frmManualRegAttendance
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
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbInManual = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInMnt = new System.Windows.Forms.ComboBox();
            this.cmbInHr = new System.Windows.Forms.ComboBox();
            this.dtpMReg = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbOutManual = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOutMnt = new System.Windows.Forms.ComboBox();
            this.cmbOutHr = new System.Windows.Forms.ComboBox();
            this.dgvRegData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegData)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(33, 62);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(202, 21);
            this.cmbName.TabIndex = 8;
            this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Emp Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Emp ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(31, 110);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(86, 20);
            this.txtID.TabIndex = 38;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbInManual);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbInMnt);
            this.groupBox1.Controls.Add(this.cmbInHr);
            this.groupBox1.Location = new System.Drawing.Point(30, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 101);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "In Time";
            // 
            // cbInManual
            // 
            this.cbInManual.AutoSize = true;
            this.cbInManual.Location = new System.Drawing.Point(10, 20);
            this.cbInManual.Name = "cbInManual";
            this.cbInManual.Size = new System.Drawing.Size(61, 17);
            this.cbInManual.TabIndex = 13;
            this.cbInManual.Text = "Manual";
            this.cbInManual.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hour";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Minutes";
            // 
            // cmbInMnt
            // 
            this.cmbInMnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInMnt.FormattingEnabled = true;
            this.cmbInMnt.Location = new System.Drawing.Point(120, 61);
            this.cmbInMnt.Name = "cmbInMnt";
            this.cmbInMnt.Size = new System.Drawing.Size(61, 21);
            this.cmbInMnt.TabIndex = 10;
            // 
            // cmbInHr
            // 
            this.cmbInHr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInHr.FormattingEnabled = true;
            this.cmbInHr.Location = new System.Drawing.Point(6, 61);
            this.cmbInHr.Name = "cmbInHr";
            this.cmbInHr.Size = new System.Drawing.Size(59, 21);
            this.cmbInHr.TabIndex = 9;
            // 
            // dtpMReg
            // 
            this.dtpMReg.CustomFormat = "dd/MM/yyyy";
            this.dtpMReg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMReg.Location = new System.Drawing.Point(36, 23);
            this.dtpMReg.MaxDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            this.dtpMReg.Name = "dtpMReg";
            this.dtpMReg.Size = new System.Drawing.Size(103, 20);
            this.dtpMReg.TabIndex = 41;
            this.dtpMReg.ValueChanged += new System.EventHandler(this.dtpMReg_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbOutManual);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbOutMnt);
            this.groupBox2.Controls.Add(this.cmbOutHr);
            this.groupBox2.Location = new System.Drawing.Point(29, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 101);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Out Time";
            // 
            // cbOutManual
            // 
            this.cbOutManual.AutoSize = true;
            this.cbOutManual.Location = new System.Drawing.Point(8, 22);
            this.cbOutManual.Name = "cbOutManual";
            this.cbOutManual.Size = new System.Drawing.Size(61, 17);
            this.cbOutManual.TabIndex = 14;
            this.cbOutManual.Text = "Manual";
            this.cbOutManual.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hour";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Minutes";
            // 
            // cmbOutMnt
            // 
            this.cmbOutMnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutMnt.FormattingEnabled = true;
            this.cmbOutMnt.Location = new System.Drawing.Point(120, 61);
            this.cmbOutMnt.Name = "cmbOutMnt";
            this.cmbOutMnt.Size = new System.Drawing.Size(61, 21);
            this.cmbOutMnt.TabIndex = 10;
            // 
            // cmbOutHr
            // 
            this.cmbOutHr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutHr.FormattingEnabled = true;
            this.cmbOutHr.Location = new System.Drawing.Point(6, 61);
            this.cmbOutHr.Name = "cmbOutHr";
            this.cmbOutHr.Size = new System.Drawing.Size(59, 21);
            this.cmbOutHr.TabIndex = 9;
            // 
            // dgvRegData
            // 
            this.dgvRegData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegData.Location = new System.Drawing.Point(266, 12);
            this.dgvRegData.Name = "dgvRegData";
            this.dgvRegData.Size = new System.Drawing.Size(698, 450);
            this.dgvRegData.TabIndex = 44;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(29, 439);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 23);
            this.btnAdd.TabIndex = 45;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(29, 361);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(199, 59);
            this.txtRemarks.TabIndex = 46;
            // 
            // frmManualRegAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 474);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvRegData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpMReg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbName);
            this.Name = "frmManualRegAttendance";
            this.Text = "Manual Attendance Register";
            this.Load += new System.EventHandler(this.frmManualRegAttendance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbInHr;
        private System.Windows.Forms.ComboBox cmbInMnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbOutMnt;
        private System.Windows.Forms.ComboBox cmbOutHr;
        private System.Windows.Forms.DataGridView dgvRegData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.CheckBox cbInManual;
        private System.Windows.Forms.CheckBox cbOutManual;
    }
}