namespace NewGMS
{
    partial class frmTrialBalance
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
            this.btnBack = new System.Windows.Forms.Button();
            this.dtpAsOnDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lvMainAcc = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lvMonthlyAcc = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.lvDayAcc = new System.Windows.Forms.ListView();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.lvLedgerDetails = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.lblLedgerDetails = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(34, 231);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<<  Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtpAsOnDate
            // 
            this.dtpAsOnDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAsOnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAsOnDate.Location = new System.Drawing.Point(76, 24);
            this.dtpAsOnDate.Name = "dtpAsOnDate";
            this.dtpAsOnDate.Size = new System.Drawing.Size(96, 20);
            this.dtpAsOnDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "As On";
            // 
            // lvMainAcc
            // 
            this.lvMainAcc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader21});
            this.lvMainAcc.FullRowSelect = true;
            this.lvMainAcc.GridLines = true;
            this.lvMainAcc.Location = new System.Drawing.Point(34, 91);
            this.lvMainAcc.MultiSelect = false;
            this.lvMainAcc.Name = "lvMainAcc";
            this.lvMainAcc.Size = new System.Drawing.Size(445, 134);
            this.lvMainAcc.TabIndex = 37;
            this.lvMainAcc.UseCompatibleStateImageBehavior = false;
            this.lvMainAcc.View = System.Windows.Forms.View.Details;
            this.lvMainAcc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvTrialMain_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Acc Name";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Code";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "GorA";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "lev";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Op Bal";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Debit";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Credit";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Clos Bal";
            this.columnHeader21.Width = 80;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(403, 22);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 38;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLevel);
            this.groupBox1.Location = new System.Drawing.Point(35, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 33);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(7, 14);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(35, 13);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "label1";
            this.lblLevel.Visible = false;
            // 
            // lvMonthlyAcc
            // 
            this.lvMonthlyAcc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader20});
            this.lvMonthlyAcc.FullRowSelect = true;
            this.lvMonthlyAcc.GridLines = true;
            this.lvMonthlyAcc.Location = new System.Drawing.Point(34, 261);
            this.lvMonthlyAcc.MultiSelect = false;
            this.lvMonthlyAcc.Name = "lvMonthlyAcc";
            this.lvMonthlyAcc.Size = new System.Drawing.Size(444, 152);
            this.lvMonthlyAcc.TabIndex = 37;
            this.lvMonthlyAcc.UseCompatibleStateImageBehavior = false;
            this.lvMonthlyAcc.View = System.Windows.Forms.View.Details;
            this.lvMonthlyAcc.Visible = false;
            this.lvMonthlyAcc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvMonthlyAcc_MouseDown);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Month";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "MonthCode";
            this.columnHeader9.Width = 0;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Op Bal";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Debit";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Credit";
            this.columnHeader13.Width = 80;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Clos Bal";
            this.columnHeader20.Width = 80;
            // 
            // lvDayAcc
            // 
            this.lvDayAcc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.lvDayAcc.FullRowSelect = true;
            this.lvDayAcc.GridLines = true;
            this.lvDayAcc.Location = new System.Drawing.Point(34, 421);
            this.lvDayAcc.MultiSelect = false;
            this.lvDayAcc.Name = "lvDayAcc";
            this.lvDayAcc.Size = new System.Drawing.Size(445, 146);
            this.lvDayAcc.TabIndex = 37;
            this.lvDayAcc.UseCompatibleStateImageBehavior = false;
            this.lvDayAcc.View = System.Windows.Forms.View.Details;
            this.lvDayAcc.Visible = false;
            this.lvDayAcc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvDayAcc_MouseDown);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Date";
            this.columnHeader14.Width = 120;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Op Bal";
            this.columnHeader15.Width = 80;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Debit";
            this.columnHeader16.Width = 80;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Credit";
            this.columnHeader17.Width = 80;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Clos Bal";
            this.columnHeader18.Width = 80;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "code";
            this.columnHeader19.Width = 0;
            // 
            // lvLedgerDetails
            // 
            this.lvLedgerDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.lvLedgerDetails.FullRowSelect = true;
            this.lvLedgerDetails.GridLines = true;
            this.lvLedgerDetails.Location = new System.Drawing.Point(514, 91);
            this.lvLedgerDetails.MultiSelect = false;
            this.lvLedgerDetails.Name = "lvLedgerDetails";
            this.lvLedgerDetails.Size = new System.Drawing.Size(348, 476);
            this.lvLedgerDetails.TabIndex = 43;
            this.lvLedgerDetails.UseCompatibleStateImageBehavior = false;
            this.lvLedgerDetails.View = System.Windows.Forms.View.Details;
            this.lvLedgerDetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvLedgerDetails_MouseDoubleClick);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Voucher No";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Voucher Type";
            this.columnHeader22.Width = 98;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Debit";
            this.columnHeader23.Width = 80;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Credit";
            this.columnHeader24.Width = 85;
            // 
            // lblLedgerDetails
            // 
            this.lblLedgerDetails.AutoSize = true;
            this.lblLedgerDetails.Location = new System.Drawing.Point(511, 70);
            this.lblLedgerDetails.Name = "lblLedgerDetails";
            this.lblLedgerDetails.Size = new System.Drawing.Size(75, 13);
            this.lblLedgerDetails.TabIndex = 44;
            this.lblLedgerDetails.Text = "Ledger Details";
            // 
            // frmTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 585);
            this.Controls.Add(this.lblLedgerDetails);
            this.Controls.Add(this.lvLedgerDetails);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lvDayAcc);
            this.Controls.Add(this.lvMonthlyAcc);
            this.Controls.Add(this.lvMainAcc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpAsOnDate);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTrialBalance";
            this.Text = "frmTrialBalance";
            this.Load += new System.EventHandler(this.frmTrialBalance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dtpAsOnDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvMainAcc;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView lvMonthlyAcc;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ListView lvDayAcc;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ListView lvLedgerDetails;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label lblLedgerDetails;
    }
}