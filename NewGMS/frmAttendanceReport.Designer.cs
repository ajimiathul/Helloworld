namespace NewGMS
{
    partial class frmAttendanceReport
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btattendencestatus = new System.Windows.Forms.Button();
            this.cmbemp = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbDep = new System.Windows.Forms.RadioButton();
            this.rbId = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnSum = new System.Windows.Forms.Button();
            this.btnRegDet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegSum = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbShowAll = new System.Windows.Forms.RadioButton();
            this.cmbFlag = new System.Windows.Forms.ComboBox();
            this.rbNotEqual = new System.Windows.Forms.RadioButton();
            this.rbEqual = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMonthTab2 = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEmpTab2 = new System.Windows.Forms.ComboBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 179);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1270, 371);
            this.crystalReportViewer1.TabIndex = 7;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 22);
            this.button2.TabIndex = 6;
            this.button2.Text = "Analysis";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 22);
            this.button1.TabIndex = 5;
            this.button1.Text = "Attendance Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(43, 48);
            this.dateTimePicker1.MaxDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(81, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // btattendencestatus
            // 
            this.btattendencestatus.Location = new System.Drawing.Point(442, 71);
            this.btattendencestatus.Name = "btattendencestatus";
            this.btattendencestatus.Size = new System.Drawing.Size(107, 23);
            this.btattendencestatus.TabIndex = 1;
            this.btattendencestatus.Text = "Show";
            this.btattendencestatus.UseVisualStyleBackColor = true;
            this.btattendencestatus.Click += new System.EventHandler(this.btattendencestatus_Click);
            // 
            // cmbemp
            // 
            this.cmbemp.FormattingEnabled = true;
            this.cmbemp.Location = new System.Drawing.Point(70, 42);
            this.cmbemp.Name = "cmbemp";
            this.cmbemp.Size = new System.Drawing.Size(478, 21);
            this.cmbemp.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1269, 156);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1261, 130);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btattendencestatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbemp);
            this.groupBox1.Location = new System.Drawing.Point(698, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Months";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Employee";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbDep);
            this.groupBox4.Controls.Add(this.rbId);
            this.groupBox4.Controls.Add(this.rbName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(295, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 118);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Daily Attendance";
            // 
            // rbDep
            // 
            this.rbDep.AutoSize = true;
            this.rbDep.Location = new System.Drawing.Point(271, 93);
            this.rbDep.Name = "rbDep";
            this.rbDep.Size = new System.Drawing.Size(80, 17);
            this.rbDep.TabIndex = 8;
            this.rbDep.TabStop = true;
            this.rbDep.Text = "Department";
            this.rbDep.UseVisualStyleBackColor = true;
            // 
            // rbId
            // 
            this.rbId.AutoSize = true;
            this.rbId.Checked = true;
            this.rbId.Location = new System.Drawing.Point(271, 55);
            this.rbId.Name = "rbId";
            this.rbId.Size = new System.Drawing.Size(34, 17);
            this.rbId.TabIndex = 8;
            this.rbId.TabStop = true;
            this.rbId.Text = "Id";
            this.rbId.UseVisualStyleBackColor = true;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(271, 74);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(53, 17);
            this.rbName.TabIndex = 8;
            this.rbName.TabStop = true;
            this.rbName.Text = "Name";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbMonth);
            this.groupBox3.Controls.Add(this.btnSum);
            this.groupBox3.Controls.Add(this.btnRegDet);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnRegSum);
            this.groupBox3.Location = new System.Drawing.Point(6, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 108);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Month Attendance";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(61, 18);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(192, 21);
            this.cmbMonth.TabIndex = 8;
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(203, 52);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(65, 23);
            this.btnSum.TabIndex = 7;
            this.btnSum.Text = "Summary";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // btnRegDet
            // 
            this.btnRegDet.Location = new System.Drawing.Point(107, 52);
            this.btnRegDet.Name = "btnRegDet";
            this.btnRegDet.Size = new System.Drawing.Size(92, 23);
            this.btnRegDet.TabIndex = 6;
            this.btnRegDet.Text = "Register Details";
            this.btnRegDet.UseVisualStyleBackColor = true;
            this.btnRegDet.Click += new System.EventHandler(this.btnRegDet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Month";
            // 
            // btnRegSum
            // 
            this.btnRegSum.Location = new System.Drawing.Point(4, 52);
            this.btnRegSum.Name = "btnRegSum";
            this.btnRegSum.Size = new System.Drawing.Size(100, 23);
            this.btnRegSum.TabIndex = 4;
            this.btnRegSum.Text = "Register Summary";
            this.btnRegSum.UseVisualStyleBackColor = true;
            this.btnRegSum.Click += new System.EventHandler(this.btnRegSum_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1261, 130);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.rbShowAll);
            this.groupBox2.Controls.Add(this.cmbFlag);
            this.groupBox2.Controls.Add(this.rbNotEqual);
            this.groupBox2.Controls.Add(this.rbEqual);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbMonthTab2);
            this.groupBox2.Controls.Add(this.btnShow);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbEmpTab2);
            this.groupBox2.Location = new System.Drawing.Point(19, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(688, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "OR";
            // 
            // rbShowAll
            // 
            this.rbShowAll.AutoSize = true;
            this.rbShowAll.Location = new System.Drawing.Point(735, 35);
            this.rbShowAll.Name = "rbShowAll";
            this.rbShowAll.Size = new System.Drawing.Size(36, 17);
            this.rbShowAll.TabIndex = 15;
            this.rbShowAll.TabStop = true;
            this.rbShowAll.Text = "All";
            this.rbShowAll.UseVisualStyleBackColor = true;
            this.rbShowAll.CheckedChanged += new System.EventHandler(this.rbShowAll_CheckedChanged);
            // 
            // cmbFlag
            // 
            this.cmbFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlag.FormattingEnabled = true;
            this.cmbFlag.Location = new System.Drawing.Point(597, 60);
            this.cmbFlag.Name = "cmbFlag";
            this.cmbFlag.Size = new System.Drawing.Size(51, 21);
            this.cmbFlag.TabIndex = 14;
            // 
            // rbNotEqual
            // 
            this.rbNotEqual.AutoSize = true;
            this.rbNotEqual.Location = new System.Drawing.Point(596, 37);
            this.rbNotEqual.Name = "rbNotEqual";
            this.rbNotEqual.Size = new System.Drawing.Size(72, 17);
            this.rbNotEqual.TabIndex = 13;
            this.rbNotEqual.Text = "Not Equal";
            this.rbNotEqual.UseVisualStyleBackColor = true;
            // 
            // rbEqual
            // 
            this.rbEqual.AutoSize = true;
            this.rbEqual.Checked = true;
            this.rbEqual.Location = new System.Drawing.Point(596, 14);
            this.rbEqual.Name = "rbEqual";
            this.rbEqual.Size = new System.Drawing.Size(52, 17);
            this.rbEqual.TabIndex = 12;
            this.rbEqual.TabStop = true;
            this.rbEqual.Text = "Equal";
            this.rbEqual.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(563, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Flag";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Month";
            // 
            // cmbMonthTab2
            // 
            this.cmbMonthTab2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonthTab2.FormattingEnabled = true;
            this.cmbMonthTab2.Location = new System.Drawing.Point(327, 46);
            this.cmbMonthTab2.Name = "cmbMonthTab2";
            this.cmbMonthTab2.Size = new System.Drawing.Size(192, 21);
            this.cmbMonthTab2.TabIndex = 9;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(850, 60);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(107, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Employee";
            // 
            // cmbEmpTab2
            // 
            this.cmbEmpTab2.FormattingEnabled = true;
            this.cmbEmpTab2.Location = new System.Drawing.Point(121, 19);
            this.cmbEmpTab2.Name = "cmbEmpTab2";
            this.cmbEmpTab2.Size = new System.Drawing.Size(398, 21);
            this.cmbEmpTab2.TabIndex = 0;
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(415, 12);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(261, 21);
            this.cmbCompany.TabIndex = 11;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Company";
            // 
            // frmAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 550);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmAttendanceReport";
            this.Text = "frmAttendanceReport";
            this.Load += new System.EventHandler(this.frmAttendanceReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbemp;
        private System.Windows.Forms.Button btattendencestatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegSum;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Button btnRegDet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbShowAll;
        private System.Windows.Forms.ComboBox cmbFlag;
        private System.Windows.Forms.RadioButton rbNotEqual;
        private System.Windows.Forms.RadioButton rbEqual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMonthTab2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmpTab2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDep;
        private System.Windows.Forms.RadioButton rbId;
        private System.Windows.Forms.RadioButton rbName;
    }
}