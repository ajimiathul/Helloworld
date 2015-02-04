namespace NewGMS
{
    partial class frmNewTransfer
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.dtpTransfer = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToDt = new System.Windows.Forms.TextBox();
            this.txtFromDt = new System.Windows.Forms.TextBox();
            this.chkSpecificDay = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTransferCompany = new System.Windows.Forms.ComboBox();
            this.dgvAttHD = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rbLeave = new System.Windows.Forms.RadioButton();
            this.rbAbsent = new System.Windows.Forms.RadioButton();
            this.rbPresent = new System.Windows.Forms.RadioButton();
            this.rbHalfDay = new System.Windows.Forms.RadioButton();
            this.rbOnDuty = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InOutDurTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActiveOrResigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOINDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MissMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.dtpView = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttHD)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1070, 239);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 25);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(994, 375);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(979, 239);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(85, 25);
            this.btnTransfer.TabIndex = 18;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // dtpTransfer
            // 
            this.dtpTransfer.CustomFormat = "dd/MM/yyyy";
            this.dtpTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransfer.Location = new System.Drawing.Point(1006, 77);
            this.dtpTransfer.MaxDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            this.dtpTransfer.Name = "dtpTransfer";
            this.dtpTransfer.Size = new System.Drawing.Size(85, 20);
            this.dtpTransfer.TabIndex = 17;
            this.dtpTransfer.ValueChanged += new System.EventHandler(this.dtpTransfer_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1182, 496);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.cmbMonth);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtToDt);
            this.tabPage1.Controls.Add(this.txtFromDt);
            this.tabPage1.Controls.Add(this.chkSpecificDay);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmbTransferCompany);
            this.tabPage1.Controls.Add(this.dgvAttHD);
            this.tabPage1.Controls.Add(this.btnTransfer);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.dtpTransfer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1174, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transfer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 441);
            this.progressBar1.Maximum = 7000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(967, 10);
            this.progressBar1.TabIndex = 31;
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(343, 27);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(204, 21);
            this.cmbMonth.TabIndex = 30;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(979, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Time To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(979, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Time From";
            // 
            // txtToDt
            // 
            this.txtToDt.Location = new System.Drawing.Point(979, 190);
            this.txtToDt.Name = "txtToDt";
            this.txtToDt.ReadOnly = true;
            this.txtToDt.Size = new System.Drawing.Size(188, 20);
            this.txtToDt.TabIndex = 27;
            // 
            // txtFromDt
            // 
            this.txtFromDt.Location = new System.Drawing.Point(982, 144);
            this.txtFromDt.Name = "txtFromDt";
            this.txtFromDt.ReadOnly = true;
            this.txtFromDt.Size = new System.Drawing.Size(185, 20);
            this.txtFromDt.TabIndex = 26;
            // 
            // chkSpecificDay
            // 
            this.chkSpecificDay.AutoSize = true;
            this.chkSpecificDay.Location = new System.Drawing.Point(979, 54);
            this.chkSpecificDay.Name = "chkSpecificDay";
            this.chkSpecificDay.Size = new System.Drawing.Size(122, 17);
            this.chkSpecificDay.TabIndex = 25;
            this.chkSpecificDay.Text = "Transfer for the date";
            this.chkSpecificDay.UseVisualStyleBackColor = true;
            this.chkSpecificDay.CheckedChanged += new System.EventHandler(this.chkSpecificDay_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Company";
            // 
            // cmbTransferCompany
            // 
            this.cmbTransferCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferCompany.FormattingEnabled = true;
            this.cmbTransferCompany.Location = new System.Drawing.Point(74, 27);
            this.cmbTransferCompany.Name = "cmbTransferCompany";
            this.cmbTransferCompany.Size = new System.Drawing.Size(188, 21);
            this.cmbTransferCompany.TabIndex = 23;
            this.cmbTransferCompany.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgvAttHD
            // 
            this.dgvAttHD.AllowUserToAddRows = false;
            this.dgvAttHD.AllowUserToDeleteRows = false;
            this.dgvAttHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttHD.Location = new System.Drawing.Point(5, 54);
            this.dgvAttHD.Name = "dgvAttHD";
            this.dgvAttHD.Size = new System.Drawing.Size(968, 387);
            this.dgvAttHD.TabIndex = 22;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rbLeave);
            this.tabPage2.Controls.Add(this.rbAbsent);
            this.tabPage2.Controls.Add(this.rbPresent);
            this.tabPage2.Controls.Add(this.rbHalfDay);
            this.tabPage2.Controls.Add(this.rbOnDuty);
            this.tabPage2.Controls.Add(this.rbAll);
            this.tabPage2.Controls.Add(this.dgvView);
            this.tabPage2.Controls.Add(this.cmbCompany);
            this.tabPage2.Controls.Add(this.btnClose2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnView);
            this.tabPage2.Controls.Add(this.dtpView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1174, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rbLeave
            // 
            this.rbLeave.AutoSize = true;
            this.rbLeave.Location = new System.Drawing.Point(205, 56);
            this.rbLeave.Name = "rbLeave";
            this.rbLeave.Size = new System.Drawing.Size(55, 17);
            this.rbLeave.TabIndex = 40;
            this.rbLeave.Text = "Leave";
            this.rbLeave.UseVisualStyleBackColor = true;
            this.rbLeave.CheckedChanged += new System.EventHandler(this.rbLeave_CheckedChanged);
            // 
            // rbAbsent
            // 
            this.rbAbsent.AutoSize = true;
            this.rbAbsent.Location = new System.Drawing.Point(101, 56);
            this.rbAbsent.Name = "rbAbsent";
            this.rbAbsent.Size = new System.Drawing.Size(58, 17);
            this.rbAbsent.TabIndex = 39;
            this.rbAbsent.Text = "Absent";
            this.rbAbsent.UseVisualStyleBackColor = true;
            this.rbAbsent.CheckedChanged += new System.EventHandler(this.rbAbsent_CheckedChanged);
            // 
            // rbPresent
            // 
            this.rbPresent.AutoSize = true;
            this.rbPresent.Checked = true;
            this.rbPresent.Location = new System.Drawing.Point(21, 56);
            this.rbPresent.Name = "rbPresent";
            this.rbPresent.Size = new System.Drawing.Size(61, 17);
            this.rbPresent.TabIndex = 38;
            this.rbPresent.TabStop = true;
            this.rbPresent.Text = "Present";
            this.rbPresent.UseVisualStyleBackColor = true;
            this.rbPresent.CheckedChanged += new System.EventHandler(this.rbPresent_CheckedChanged);
            // 
            // rbHalfDay
            // 
            this.rbHalfDay.AutoSize = true;
            this.rbHalfDay.Location = new System.Drawing.Point(278, 56);
            this.rbHalfDay.Name = "rbHalfDay";
            this.rbHalfDay.Size = new System.Drawing.Size(63, 17);
            this.rbHalfDay.TabIndex = 37;
            this.rbHalfDay.Text = "HalfDay";
            this.rbHalfDay.UseVisualStyleBackColor = true;
            this.rbHalfDay.CheckedChanged += new System.EventHandler(this.rbHalfDay_CheckedChanged);
            // 
            // rbOnDuty
            // 
            this.rbOnDuty.AutoSize = true;
            this.rbOnDuty.Location = new System.Drawing.Point(364, 56);
            this.rbOnDuty.Name = "rbOnDuty";
            this.rbOnDuty.Size = new System.Drawing.Size(64, 17);
            this.rbOnDuty.TabIndex = 37;
            this.rbOnDuty.Text = "On Duty";
            this.rbOnDuty.UseVisualStyleBackColor = true;
            this.rbOnDuty.CheckedChanged += new System.EventHandler(this.rbOnDuty_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(449, 56);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(36, 17);
            this.rbAll.TabIndex = 37;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.ColumnHeadersHeight = 50;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.InOutDurTime,
            this.Column5,
            this.Column6,
            this.ActiveOrResigned,
            this.JOINDATE,
            this.DOR,
            this.MissMatch});
            this.dgvView.Location = new System.Drawing.Point(18, 90);
            this.dgvView.Name = "dgvView";
            this.dgvView.Size = new System.Drawing.Size(1150, 374);
            this.dgvView.TabIndex = 36;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "SL.No.";
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Emp ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "In Time";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Out Time";
            this.Column4.Name = "Column4";
            // 
            // InOutDurTime
            // 
            this.InOutDurTime.HeaderText = "Duration";
            this.InOutDurTime.Name = "InOutDurTime";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Status";
            this.Column5.Name = "Column5";
            this.Column5.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Leave";
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // ActiveOrResigned
            // 
            this.ActiveOrResigned.HeaderText = "ActiveOr Resigned";
            this.ActiveOrResigned.Name = "ActiveOrResigned";
            this.ActiveOrResigned.Width = 60;
            // 
            // JOINDATE
            // 
            this.JOINDATE.HeaderText = "JOINDATE";
            this.JOINDATE.Name = "JOINDATE";
            // 
            // DOR
            // 
            this.DOR.HeaderText = "DOResigned";
            this.DOR.Name = "DOR";
            // 
            // MissMatch
            // 
            this.MissMatch.HeaderText = "MissMatch";
            this.MissMatch.Name = "MissMatch";
            this.MissMatch.Width = 80;
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(205, 15);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(160, 21);
            this.cmbCompany.TabIndex = 35;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // btnClose2
            // 
            this.btnClose2.Location = new System.Drawing.Point(480, 14);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(84, 23);
            this.btnClose2.TabIndex = 34;
            this.btnClose2.Text = "Close";
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Select Date";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(371, 14);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 23);
            this.btnView.TabIndex = 32;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dtpView
            // 
            this.dtpView.CustomFormat = "dd/MM/yyyy";
            this.dtpView.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpView.Location = new System.Drawing.Point(102, 15);
            this.dtpView.MaxDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            this.dtpView.Name = "dtpView";
            this.dtpView.Size = new System.Drawing.Size(85, 20);
            this.dtpView.TabIndex = 31;
            this.dtpView.ValueChanged += new System.EventHandler(this.dtpView_ValueChanged);
            // 
            // frmNewTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 520);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmNewTransfer";
            this.Text = "Finger Print - Attendance Details";
            this.Load += new System.EventHandler(this.frmNewTransfer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttHD)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.DateTimePicker dtpTransfer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dtpView;
        private System.Windows.Forms.DataGridView dgvAttHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTransferCompany;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.RadioButton rbAbsent;
        private System.Windows.Forms.RadioButton rbPresent;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbLeave;
        private System.Windows.Forms.CheckBox chkSpecificDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToDt;
        private System.Windows.Forms.TextBox txtFromDt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn InOutDurTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActiveOrResigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOINDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MissMatch;
        private System.Windows.Forms.RadioButton rbOnDuty;
        private System.Windows.Forms.RadioButton rbHalfDay;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}