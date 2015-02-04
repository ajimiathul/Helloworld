namespace NewGMS
{
    partial class frmLeaveApplication
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
            this.cmbEmpName = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.txtNoOfDays = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvAllEmpLeave = new System.Windows.Forms.DataGridView();
            this.txtSlno = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSanc = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbSancBy = new System.Windows.Forms.ComboBox();
            this.cmbLT = new System.Windows.Forms.ComboBox();
            this.cbHalf = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvLeaveStatus = new System.Windows.Forms.DataGridView();
            this.mnth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.txtDesg = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllEmpLeave)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmpName
            // 
            this.cmbEmpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpName.FormattingEnabled = true;
            this.cmbEmpName.Location = new System.Drawing.Point(186, 50);
            this.cmbEmpName.Name = "cmbEmpName";
            this.cmbEmpName.Size = new System.Drawing.Size(214, 21);
            this.cmbEmpName.TabIndex = 30;
            this.cmbEmpName.SelectedIndexChanged += new System.EventHandler(this.cmbEmpName_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Reason";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(3, 79);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(75, 20);
            this.txtFind.TabIndex = 26;
            this.txtFind.Text = "0";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(91, 109);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(199, 20);
            this.txtReason.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "No. of days ";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(88, 76);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 27;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtMode
            // 
            this.txtMode.Enabled = false;
            this.txtMode.Location = new System.Drawing.Point(2, 48);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(161, 20);
            this.txtMode.TabIndex = 28;
            // 
            // txtNoOfDays
            // 
            this.txtNoOfDays.Enabled = false;
            this.txtNoOfDays.Location = new System.Drawing.Point(90, 73);
            this.txtNoOfDays.Name = "txtNoOfDays";
            this.txtNoOfDays.Size = new System.Drawing.Size(75, 20);
            this.txtNoOfDays.TabIndex = 29;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(223, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(88, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Serial No.";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(70, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 23);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvAllEmpLeave
            // 
            this.dgvAllEmpLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllEmpLeave.Location = new System.Drawing.Point(5, 19);
            this.dgvAllEmpLeave.Name = "dgvAllEmpLeave";
            this.dgvAllEmpLeave.ReadOnly = true;
            this.dgvAllEmpLeave.Size = new System.Drawing.Size(784, 155);
            this.dgvAllEmpLeave.TabIndex = 4;
            this.dgvAllEmpLeave.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllEmpLeave_CellDoubleClick);
            // 
            // txtSlno
            // 
            this.txtSlno.Enabled = false;
            this.txtSlno.Location = new System.Drawing.Point(189, 20);
            this.txtSlno.Name = "txtSlno";
            this.txtSlno.Size = new System.Drawing.Size(75, 20);
            this.txtSlno.TabIndex = 34;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvAllEmpLeave);
            this.groupBox3.Location = new System.Drawing.Point(74, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(795, 182);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(6, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(58, 23);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNoOfDays);
            this.groupBox2.Controls.Add(this.cbSanc);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.cmbSancBy);
            this.groupBox2.Controls.Add(this.cmbLT);
            this.groupBox2.Controls.Add(this.cbHalf);
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Location = new System.Drawing.Point(79, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 288);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Leave Info";
            // 
            // cbSanc
            // 
            this.cbSanc.AutoSize = true;
            this.cbSanc.Checked = true;
            this.cbSanc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSanc.Enabled = false;
            this.cbSanc.Location = new System.Drawing.Point(304, 148);
            this.cbSanc.Name = "cbSanc";
            this.cbSanc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbSanc.Size = new System.Drawing.Size(80, 17);
            this.cbSanc.TabIndex = 13;
            this.cbSanc.Text = "Sanctioned";
            this.cbSanc.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbSanc.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sanctioned By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Leave Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Date To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date From";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMode);
            this.groupBox4.Controls.Add(this.btnFind);
            this.groupBox4.Controls.Add(this.txtFind);
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Controls.Add(this.btnEdit);
            this.groupBox4.Controls.Add(this.btnNew);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Location = new System.Drawing.Point(5, 171);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(399, 107);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(293, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbSancBy
            // 
            this.cmbSancBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSancBy.Enabled = false;
            this.cmbSancBy.FormattingEnabled = true;
            this.cmbSancBy.Location = new System.Drawing.Point(88, 145);
            this.cmbSancBy.Name = "cmbSancBy";
            this.cmbSancBy.Size = new System.Drawing.Size(199, 21);
            this.cmbSancBy.TabIndex = 4;
            // 
            // cmbLT
            // 
            this.cmbLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLT.Enabled = false;
            this.cmbLT.FormattingEnabled = true;
            this.cmbLT.Location = new System.Drawing.Point(245, 76);
            this.cmbLT.Name = "cmbLT";
            this.cmbLT.Size = new System.Drawing.Size(87, 21);
            this.cmbLT.TabIndex = 3;
            // 
            // cbHalf
            // 
            this.cbHalf.AutoSize = true;
            this.cbHalf.Location = new System.Drawing.Point(317, 118);
            this.cbHalf.Name = "cbHalf";
            this.cbHalf.Size = new System.Drawing.Size(67, 17);
            this.cbHalf.TabIndex = 2;
            this.cbHalf.Text = "Half Day";
            this.cbHalf.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(222, 37);
            this.dtpTo.MaxDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(87, 20);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(81, 37);
            this.dtpFrom.MaxDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(87, 20);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // txtEmpID
            // 
            this.txtEmpID.Enabled = false;
            this.txtEmpID.Location = new System.Drawing.Point(105, 19);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(267, 20);
            this.txtEmpID.TabIndex = 0;
            this.txtEmpID.TextChanged += new System.EventHandler(this.txtEmpID_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.dgvLeaveStatus);
            this.groupBox1.Controls.Add(this.txtDep);
            this.groupBox1.Controls.Add(this.txtDesg);
            this.groupBox1.Controls.Add(this.txtEmpID);
            this.groupBox1.Location = new System.Drawing.Point(491, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 364);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Leave Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Department";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Designation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Employee ID";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(189, 338);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(48, 20);
            this.txtTotal.TabIndex = 4;
            // 
            // dgvLeaveStatus
            // 
            this.dgvLeaveStatus.AllowUserToAddRows = false;
            this.dgvLeaveStatus.AllowUserToDeleteRows = false;
            this.dgvLeaveStatus.AllowUserToResizeColumns = false;
            this.dgvLeaveStatus.AllowUserToResizeRows = false;
            this.dgvLeaveStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLeaveStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mnth,
            this.lv,
            this.ab});
            this.dgvLeaveStatus.Location = new System.Drawing.Point(6, 106);
            this.dgvLeaveStatus.Name = "dgvLeaveStatus";
            this.dgvLeaveStatus.Size = new System.Drawing.Size(366, 226);
            this.dgvLeaveStatus.TabIndex = 3;
            // 
            // mnth
            // 
            this.mnth.HeaderText = "Month";
            this.mnth.Name = "mnth";
            this.mnth.ReadOnly = true;
            this.mnth.Width = 60;
            // 
            // lv
            // 
            this.lv.HeaderText = "Leave Applied";
            this.lv.Name = "lv";
            this.lv.ReadOnly = true;
            this.lv.Width = 60;
            // 
            // ab
            // 
            this.ab.HeaderText = "Absent";
            this.ab.Name = "ab";
            this.ab.ReadOnly = true;
            this.ab.Width = 60;
            // 
            // txtDep
            // 
            this.txtDep.Enabled = false;
            this.txtDep.Location = new System.Drawing.Point(105, 71);
            this.txtDep.Name = "txtDep";
            this.txtDep.Size = new System.Drawing.Size(267, 20);
            this.txtDep.TabIndex = 2;
            // 
            // txtDesg
            // 
            this.txtDesg.Enabled = false;
            this.txtDesg.Location = new System.Drawing.Point(105, 45);
            this.txtDesg.Name = "txtDesg";
            this.txtDesg.Size = new System.Drawing.Size(267, 20);
            this.txtDesg.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Employee Name";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(186, 50);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(214, 20);
            this.txtEmpName.TabIndex = 37;
            this.txtEmpName.Visible = false;
            // 
            // frmLeaveApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 584);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.cmbEmpName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSlno);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Name = "frmLeaveApplication";
            this.Text = "Leave Application ";
            this.Load += new System.EventHandler(this.frmLeaveApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllEmpLeave)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEmpName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.TextBox txtNoOfDays;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvAllEmpLeave;
        private System.Windows.Forms.TextBox txtSlno;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSanc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbSancBy;
        private System.Windows.Forms.ComboBox cmbLT;
        private System.Windows.Forms.CheckBox cbHalf;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgvLeaveStatus;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.TextBox txtDesg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnth;
        private System.Windows.Forms.DataGridViewTextBoxColumn lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ab;
        private System.Windows.Forms.TextBox txtEmpName;

    }
}