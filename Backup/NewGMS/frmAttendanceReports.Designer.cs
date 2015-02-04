namespace NewGMS
{
    partial class frmAttendanceReports
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
            this.btnPrn1 = new System.Windows.Forms.Button();
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.btnPrn2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbMonth2 = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.rb801829 = new System.Windows.Forms.RadioButton();
            this.rb6318 = new System.Windows.Forms.RadioButton();
            this.rbSinPnch = new System.Windows.Forms.RadioButton();
            this.rbOTHol = new System.Windows.Forms.RadioButton();
            this.rbPrsHol = new System.Windows.Forms.RadioButton();
            this.rb401630 = new System.Windows.Forms.RadioButton();
            this.rb830 = new System.Windows.Forms.RadioButton();
            this.rbOTNor = new System.Windows.Forms.RadioButton();
            this.rbAbsHol = new System.Windows.Forms.RadioButton();
            this.rb3314 = new System.Windows.Forms.RadioButton();
            this.rbAbsNor = new System.Windows.Forms.RadioButton();
            this.rb0330 = new System.Windows.Forms.RadioButton();
            this.cmbEmp2 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(6, 91);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(852, 412);
            this.crystalReportViewer1.TabIndex = 24;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // btnPrn1
            // 
            this.btnPrn1.Location = new System.Drawing.Point(271, 29);
            this.btnPrn1.Name = "btnPrn1";
            this.btnPrn1.Size = new System.Drawing.Size(49, 23);
            this.btnPrn1.TabIndex = 2;
            this.btnPrn1.Text = "Print";
            this.btnPrn1.UseVisualStyleBackColor = true;
            this.btnPrn1.Click += new System.EventHandler(this.btnPrn1_Click);
            // 
            // cmbEmp
            // 
            this.cmbEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(11, 29);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(245, 21);
            this.cmbEmp.TabIndex = 0;
            this.cmbEmp.SelectedIndexChanged += new System.EventHandler(this.cmbEmp_SelectedIndexChanged);
            // 
            // btnPrn2
            // 
            this.btnPrn2.Location = new System.Drawing.Point(192, 46);
            this.btnPrn2.Name = "btnPrn2";
            this.btnPrn2.Size = new System.Drawing.Size(89, 23);
            this.btnPrn2.TabIndex = 2;
            this.btnPrn2.Text = "Detailed Print";
            this.btnPrn2.UseVisualStyleBackColor = true;
            this.btnPrn2.Click += new System.EventHandler(this.btnPrn2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 544);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnPrn2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.crystalReportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(864, 518);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbMonth);
            this.groupBox2.Location = new System.Drawing.Point(7, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 66);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(11, 29);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(125, 21);
            this.cmbMonth.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Summary Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEmp);
            this.groupBox1.Controls.Add(this.btnPrn1);
            this.groupBox1.Location = new System.Drawing.Point(531, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 66);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Report";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbMonth2);
            this.tabPage2.Controls.Add(this.btnShow);
            this.tabPage2.Controls.Add(this.rb801829);
            this.tabPage2.Controls.Add(this.rb6318);
            this.tabPage2.Controls.Add(this.rbSinPnch);
            this.tabPage2.Controls.Add(this.rbOTHol);
            this.tabPage2.Controls.Add(this.rbPrsHol);
            this.tabPage2.Controls.Add(this.rb401630);
            this.tabPage2.Controls.Add(this.rb830);
            this.tabPage2.Controls.Add(this.rbOTNor);
            this.tabPage2.Controls.Add(this.rbAbsHol);
            this.tabPage2.Controls.Add(this.rb3314);
            this.tabPage2.Controls.Add(this.rbAbsNor);
            this.tabPage2.Controls.Add(this.rb0330);
            this.tabPage2.Controls.Add(this.cmbEmp2);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(864, 518);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // cmbMonth2
            // 
            this.cmbMonth2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth2.FormattingEnabled = true;
            this.cmbMonth2.Location = new System.Drawing.Point(32, 6);
            this.cmbMonth2.Name = "cmbMonth2";
            this.cmbMonth2.Size = new System.Drawing.Size(125, 21);
            this.cmbMonth2.TabIndex = 15;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(429, 6);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 14;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // rb801829
            // 
            this.rb801829.AutoSize = true;
            this.rb801829.Location = new System.Drawing.Point(525, 87);
            this.rb801829.Name = "rb801829";
            this.rb801829.Size = new System.Drawing.Size(76, 17);
            this.rb801829.TabIndex = 13;
            this.rb801829.TabStop = true;
            this.rb801829.Text = "8.01to8.29";
            this.rb801829.UseVisualStyleBackColor = true;
            // 
            // rb6318
            // 
            this.rb6318.AutoSize = true;
            this.rb6318.Checked = true;
            this.rb6318.Location = new System.Drawing.Point(328, 87);
            this.rb6318.Name = "rb6318";
            this.rb6318.Size = new System.Drawing.Size(61, 17);
            this.rb6318.TabIndex = 12;
            this.rb6318.TabStop = true;
            this.rb6318.Text = "6.31to8";
            this.rb6318.UseVisualStyleBackColor = true;
            // 
            // rbSinPnch
            // 
            this.rbSinPnch.AutoSize = true;
            this.rbSinPnch.Location = new System.Drawing.Point(525, 53);
            this.rbSinPnch.Name = "rbSinPnch";
            this.rbSinPnch.Size = new System.Drawing.Size(88, 17);
            this.rbSinPnch.TabIndex = 11;
            this.rbSinPnch.TabStop = true;
            this.rbSinPnch.Text = "Single Punch";
            this.rbSinPnch.UseVisualStyleBackColor = true;
            // 
            // rbOTHol
            // 
            this.rbOTHol.AutoSize = true;
            this.rbOTHol.Location = new System.Drawing.Point(179, 53);
            this.rbOTHol.Name = "rbOTHol";
            this.rbOTHol.Size = new System.Drawing.Size(98, 17);
            this.rbOTHol.TabIndex = 10;
            this.rbOTHol.TabStop = true;
            this.rbOTHol.Text = "OT on Holidays";
            this.rbOTHol.UseVisualStyleBackColor = true;
            // 
            // rbPrsHol
            // 
            this.rbPrsHol.AutoSize = true;
            this.rbPrsHol.Location = new System.Drawing.Point(32, 53);
            this.rbPrsHol.Name = "rbPrsHol";
            this.rbPrsHol.Size = new System.Drawing.Size(119, 17);
            this.rbPrsHol.TabIndex = 9;
            this.rbPrsHol.TabStop = true;
            this.rbPrsHol.Text = "Present on Holidays";
            this.rbPrsHol.UseVisualStyleBackColor = true;
            // 
            // rb401630
            // 
            this.rb401630.AutoSize = true;
            this.rb401630.Location = new System.Drawing.Point(179, 87);
            this.rb401630.Name = "rb401630";
            this.rb401630.Size = new System.Drawing.Size(76, 17);
            this.rb401630.TabIndex = 8;
            this.rb401630.TabStop = true;
            this.rb401630.Text = "4.01to6.30";
            this.rb401630.UseVisualStyleBackColor = true;
            // 
            // rb830
            // 
            this.rb830.AutoSize = true;
            this.rb830.Location = new System.Drawing.Point(726, 87);
            this.rb830.Name = "rb830";
            this.rb830.Size = new System.Drawing.Size(80, 17);
            this.rb830.TabIndex = 7;
            this.rb830.TabStop = true;
            this.rb830.Text = "Above 8.30";
            this.rb830.UseVisualStyleBackColor = true;
            // 
            // rbOTNor
            // 
            this.rbOTNor.AutoSize = true;
            this.rbOTNor.Location = new System.Drawing.Point(328, 53);
            this.rbOTNor.Name = "rbOTNor";
            this.rbOTNor.Size = new System.Drawing.Size(118, 17);
            this.rbOTNor.TabIndex = 6;
            this.rbOTNor.TabStop = true;
            this.rbOTNor.Text = "OT on Normal Days";
            this.rbOTNor.UseVisualStyleBackColor = true;
            this.rbOTNor.CheckedChanged += new System.EventHandler(this.rbOTNor_CheckedChanged);
            // 
            // rbAbsHol
            // 
            this.rbAbsHol.AutoSize = true;
            this.rbAbsHol.Location = new System.Drawing.Point(726, 15);
            this.rbAbsHol.Name = "rbAbsHol";
            this.rbAbsHol.Size = new System.Drawing.Size(109, 17);
            this.rbAbsHol.TabIndex = 5;
            this.rbAbsHol.TabStop = true;
            this.rbAbsHol.Text = "Abs. On. Holidays";
            this.rbAbsHol.UseVisualStyleBackColor = true;
            // 
            // rb3314
            // 
            this.rb3314.AutoSize = true;
            this.rb3314.Location = new System.Drawing.Point(32, 87);
            this.rb3314.Name = "rb3314";
            this.rb3314.Size = new System.Drawing.Size(65, 17);
            this.rb3314.TabIndex = 4;
            this.rb3314.TabStop = true;
            this.rb3314.Text = "3.31To4";
            this.rb3314.UseVisualStyleBackColor = true;
            // 
            // rbAbsNor
            // 
            this.rbAbsNor.AutoSize = true;
            this.rbAbsNor.Location = new System.Drawing.Point(525, 15);
            this.rbAbsNor.Name = "rbAbsNor";
            this.rbAbsNor.Size = new System.Drawing.Size(110, 17);
            this.rbAbsNor.TabIndex = 3;
            this.rbAbsNor.TabStop = true;
            this.rbAbsNor.Text = "Abs On Nor. Days";
            this.rbAbsNor.UseVisualStyleBackColor = true;
            // 
            // rb0330
            // 
            this.rb0330.AutoSize = true;
            this.rb0330.Location = new System.Drawing.Point(726, 53);
            this.rb0330.Name = "rb0330";
            this.rb0330.Size = new System.Drawing.Size(65, 17);
            this.rb0330.TabIndex = 2;
            this.rb0330.TabStop = true;
            this.rb0330.Text = "0To3.30";
            this.rb0330.UseVisualStyleBackColor = true;
            // 
            // cmbEmp2
            // 
            this.cmbEmp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmp2.FormattingEnabled = true;
            this.cmbEmp2.Location = new System.Drawing.Point(175, 6);
            this.cmbEmp2.Name = "cmbEmp2";
            this.cmbEmp2.Size = new System.Drawing.Size(248, 21);
            this.cmbEmp2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(816, 389);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmAttendanceReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 568);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAttendanceReports";
            this.Text = "frmAttendanceReports";
            this.Load += new System.EventHandler(this.frmAttendanceReports_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnPrn1;
        private System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.Button btnPrn2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rb3314;
        private System.Windows.Forms.RadioButton rbAbsNor;
        private System.Windows.Forms.RadioButton rb0330;
        private System.Windows.Forms.ComboBox cmbEmp2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rb830;
        private System.Windows.Forms.RadioButton rbOTNor;
        private System.Windows.Forms.RadioButton rbAbsHol;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.RadioButton rb801829;
        private System.Windows.Forms.RadioButton rb6318;
        private System.Windows.Forms.RadioButton rbSinPnch;
        private System.Windows.Forms.RadioButton rbOTHol;
        private System.Windows.Forms.RadioButton rbPrsHol;
        private System.Windows.Forms.RadioButton rb401630;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbMonth2;
    }
}