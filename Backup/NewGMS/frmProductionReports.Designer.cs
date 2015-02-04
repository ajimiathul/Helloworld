namespace NewGMS
{
    partial class frmProductionReports
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPStyleActQtyCost = new System.Windows.Forms.RadioButton();
            this.rbPStyleActDateQtyCost = new System.Windows.Forms.RadioButton();
            this.rbPStyleBatchStatus = new System.Windows.Forms.RadioButton();
            this.rbPStyleRate = new System.Windows.Forms.RadioButton();
            this.btnPStyle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbstylecost = new System.Windows.Forms.ComboBox();
            this.gbyearwise = new System.Windows.Forms.GroupBox();
            this.btnprintyear1 = new System.Windows.Forms.Button();
            this.gbdateinterval = new System.Windows.Forms.GroupBox();
            this.gbActivity = new System.Windows.Forms.GroupBox();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.btnprintStyAct = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbStyleSizeSum1 = new System.Windows.Forms.RadioButton();
            this.rbActivityDate1 = new System.Windows.Forms.RadioButton();
            this.rbDateActivity1 = new System.Windows.Forms.RadioButton();
            this.btnprintdatestyl = new System.Windows.Forms.Button();
            this.lblStylecodeDI = new System.Windows.Forms.Label();
            this.cmbStyleDI = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.rbEmployee1 = new System.Windows.Forms.RadioButton();
            this.rbDate1 = new System.Windows.Forms.RadioButton();
            this.rbDateEmp1 = new System.Windows.Forms.RadioButton();
            this.rbempDate1 = new System.Windows.Forms.RadioButton();
            this.btnprintdateonly = new System.Windows.Forms.Button();
            this.rbstyleactivity1 = new System.Windows.Forms.RadioButton();
            this.rbActivityStyle1 = new System.Windows.Forms.RadioButton();
            this.lblto = new System.Windows.Forms.Label();
            this.lblfrom = new System.Windows.Forms.Label();
            this.dtpto1 = new System.Windows.Forms.DateTimePicker();
            this.dtpfrom1 = new System.Windows.Forms.DateTimePicker();
            this.gbDPD2 = new System.Windows.Forms.GroupBox();
            this.lblstylecode = new System.Windows.Forms.Label();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.btnDlyPrint2 = new System.Windows.Forms.Button();
            this.rbDlyEmp2 = new System.Windows.Forms.RadioButton();
            this.lblProductDate2 = new System.Windows.Forms.Label();
            this.rbDlyAct2 = new System.Windows.Forms.RadioButton();
            this.dtpProdDate2 = new System.Windows.Forms.DateTimePicker();
            this.gbDPD1 = new System.Windows.Forms.GroupBox();
            this.rbOperations = new System.Windows.Forms.RadioButton();
            this.btnDlyPrint1 = new System.Windows.Forms.Button();
            this.rbDlyEmp1 = new System.Windows.Forms.RadioButton();
            this.lblProductDate1 = new System.Windows.Forms.Label();
            this.rbDlyAct1 = new System.Windows.Forms.RadioButton();
            this.dtpProdDate1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCutPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCutTo = new System.Windows.Forms.DateTimePicker();
            this.dtpCutFrom = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbyearwise.SuspendLayout();
            this.gbdateinterval.SuspendLayout();
            this.gbActivity.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.gbDPD2.SuspendLayout();
            this.gbDPD1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 247);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1284, 350);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1272, 229);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.gbyearwise);
            this.tabPage2.Controls.Add(this.gbdateinterval);
            this.tabPage2.Controls.Add(this.gbDPD2);
            this.tabPage2.Controls.Add(this.gbDPD1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1264, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Production";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPStyleActQtyCost);
            this.groupBox1.Controls.Add(this.rbPStyleActDateQtyCost);
            this.groupBox1.Controls.Add(this.rbPStyleBatchStatus);
            this.groupBox1.Controls.Add(this.rbPStyleRate);
            this.groupBox1.Controls.Add(this.btnPStyle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbstylecost);
            this.groupBox1.Location = new System.Drawing.Point(1043, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 191);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // rbPStyleActQtyCost
            // 
            this.rbPStyleActQtyCost.AutoSize = true;
            this.rbPStyleActQtyCost.Checked = true;
            this.rbPStyleActQtyCost.Location = new System.Drawing.Point(9, 132);
            this.rbPStyleActQtyCost.Name = "rbPStyleActQtyCost";
            this.rbPStyleActQtyCost.Size = new System.Drawing.Size(46, 17);
            this.rbPStyleActQtyCost.TabIndex = 27;
            this.rbPStyleActQtyCost.TabStop = true;
            this.rbPStyleActQtyCost.Text = "Cost";
            this.rbPStyleActQtyCost.UseVisualStyleBackColor = true;
            // 
            // rbPStyleActDateQtyCost
            // 
            this.rbPStyleActDateQtyCost.AutoSize = true;
            this.rbPStyleActDateQtyCost.Checked = true;
            this.rbPStyleActDateQtyCost.Location = new System.Drawing.Point(9, 106);
            this.rbPStyleActDateQtyCost.Name = "rbPStyleActDateQtyCost";
            this.rbPStyleActDateQtyCost.Size = new System.Drawing.Size(72, 17);
            this.rbPStyleActDateQtyCost.TabIndex = 26;
            this.rbPStyleActDateQtyCost.TabStop = true;
            this.rbPStyleActDateQtyCost.Text = "Daily Cost";
            this.rbPStyleActDateQtyCost.UseVisualStyleBackColor = true;
            // 
            // rbPStyleBatchStatus
            // 
            this.rbPStyleBatchStatus.AutoSize = true;
            this.rbPStyleBatchStatus.Checked = true;
            this.rbPStyleBatchStatus.Location = new System.Drawing.Point(9, 79);
            this.rbPStyleBatchStatus.Name = "rbPStyleBatchStatus";
            this.rbPStyleBatchStatus.Size = new System.Drawing.Size(89, 17);
            this.rbPStyleBatchStatus.TabIndex = 25;
            this.rbPStyleBatchStatus.TabStop = true;
            this.rbPStyleBatchStatus.Text = "Batch Status ";
            this.rbPStyleBatchStatus.UseVisualStyleBackColor = true;
            // 
            // rbPStyleRate
            // 
            this.rbPStyleRate.AutoSize = true;
            this.rbPStyleRate.Checked = true;
            this.rbPStyleRate.Location = new System.Drawing.Point(9, 56);
            this.rbPStyleRate.Name = "rbPStyleRate";
            this.rbPStyleRate.Size = new System.Drawing.Size(48, 17);
            this.rbPStyleRate.TabIndex = 24;
            this.rbPStyleRate.TabStop = true;
            this.rbPStyleRate.Text = "Rate";
            this.rbPStyleRate.UseVisualStyleBackColor = true;
            // 
            // btnPStyle
            // 
            this.btnPStyle.Location = new System.Drawing.Point(136, 162);
            this.btnPStyle.Name = "btnPStyle";
            this.btnPStyle.Size = new System.Drawing.Size(58, 23);
            this.btnPStyle.TabIndex = 23;
            this.btnPStyle.Text = "Print";
            this.btnPStyle.UseVisualStyleBackColor = true;
            this.btnPStyle.Click += new System.EventHandler(this.btnPStyle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Stylecode";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbstylecost
            // 
            this.cmbstylecost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstylecost.FormattingEnabled = true;
            this.cmbstylecost.Location = new System.Drawing.Point(9, 29);
            this.cmbstylecost.Name = "cmbstylecost";
            this.cmbstylecost.Size = new System.Drawing.Size(180, 21);
            this.cmbstylecost.TabIndex = 21;
            // 
            // gbyearwise
            // 
            this.gbyearwise.Controls.Add(this.btnprintyear1);
            this.gbyearwise.Location = new System.Drawing.Point(6, 149);
            this.gbyearwise.Name = "gbyearwise";
            this.gbyearwise.Size = new System.Drawing.Size(237, 48);
            this.gbyearwise.TabIndex = 13;
            this.gbyearwise.TabStop = false;
            this.gbyearwise.Text = "Yearwise Sub Category";
            // 
            // btnprintyear1
            // 
            this.btnprintyear1.Location = new System.Drawing.Point(156, 18);
            this.btnprintyear1.Name = "btnprintyear1";
            this.btnprintyear1.Size = new System.Drawing.Size(75, 23);
            this.btnprintyear1.TabIndex = 12;
            this.btnprintyear1.Text = "Print";
            this.btnprintyear1.UseVisualStyleBackColor = true;
            this.btnprintyear1.Click += new System.EventHandler(this.btnprintyear1_Click);
            // 
            // gbdateinterval
            // 
            this.gbdateinterval.Controls.Add(this.gbActivity);
            this.gbdateinterval.Controls.Add(this.groupBox11);
            this.gbdateinterval.Controls.Add(this.groupBox12);
            this.gbdateinterval.Controls.Add(this.lblto);
            this.gbdateinterval.Controls.Add(this.lblfrom);
            this.gbdateinterval.Controls.Add(this.dtpto1);
            this.gbdateinterval.Controls.Add(this.dtpfrom1);
            this.gbdateinterval.Location = new System.Drawing.Point(486, 6);
            this.gbdateinterval.Name = "gbdateinterval";
            this.gbdateinterval.Size = new System.Drawing.Size(550, 191);
            this.gbdateinterval.TabIndex = 6;
            this.gbdateinterval.TabStop = false;
            this.gbdateinterval.Text = "Date Interval";
            // 
            // gbActivity
            // 
            this.gbActivity.Controls.Add(this.cmbActivity);
            this.gbActivity.Controls.Add(this.btnprintStyAct);
            this.gbActivity.Location = new System.Drawing.Point(6, 34);
            this.gbActivity.Name = "gbActivity";
            this.gbActivity.Size = new System.Drawing.Size(272, 57);
            this.gbActivity.TabIndex = 26;
            this.gbActivity.TabStop = false;
            this.gbActivity.Text = "Activity";
            // 
            // cmbActivity
            // 
            this.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Location = new System.Drawing.Point(6, 12);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(259, 21);
            this.cmbActivity.TabIndex = 23;
            // 
            // btnprintStyAct
            // 
            this.btnprintStyAct.Location = new System.Drawing.Point(192, 34);
            this.btnprintStyAct.Name = "btnprintStyAct";
            this.btnprintStyAct.Size = new System.Drawing.Size(73, 23);
            this.btnprintStyAct.TabIndex = 25;
            this.btnprintStyAct.Text = "Print";
            this.btnprintStyAct.UseVisualStyleBackColor = true;
            this.btnprintStyAct.Click += new System.EventHandler(this.btnprintStyAct_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.rbStyleSizeSum1);
            this.groupBox11.Controls.Add(this.rbActivityDate1);
            this.groupBox11.Controls.Add(this.rbDateActivity1);
            this.groupBox11.Controls.Add(this.btnprintdatestyl);
            this.groupBox11.Controls.Add(this.lblStylecodeDI);
            this.groupBox11.Controls.Add(this.cmbStyleDI);
            this.groupBox11.Location = new System.Drawing.Point(6, 97);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(272, 93);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Style Size";
            // 
            // rbStyleSizeSum1
            // 
            this.rbStyleSizeSum1.AutoSize = true;
            this.rbStyleSizeSum1.Location = new System.Drawing.Point(9, 72);
            this.rbStyleSizeSum1.Name = "rbStyleSizeSum1";
            this.rbStyleSizeSum1.Size = new System.Drawing.Size(117, 17);
            this.rbStyleSizeSum1.TabIndex = 23;
            this.rbStyleSizeSum1.TabStop = true;
            this.rbStyleSizeSum1.Text = "Style Size Summary";
            this.rbStyleSizeSum1.UseVisualStyleBackColor = true;
            // 
            // rbActivityDate1
            // 
            this.rbActivityDate1.AutoSize = true;
            this.rbActivityDate1.Location = new System.Drawing.Point(9, 56);
            this.rbActivityDate1.Name = "rbActivityDate1";
            this.rbActivityDate1.Size = new System.Drawing.Size(85, 17);
            this.rbActivityDate1.TabIndex = 22;
            this.rbActivityDate1.TabStop = true;
            this.rbActivityDate1.Text = "Activity Date";
            this.rbActivityDate1.UseVisualStyleBackColor = true;
            // 
            // rbDateActivity1
            // 
            this.rbDateActivity1.AutoSize = true;
            this.rbDateActivity1.Checked = true;
            this.rbDateActivity1.Location = new System.Drawing.Point(9, 40);
            this.rbDateActivity1.Name = "rbDateActivity1";
            this.rbDateActivity1.Size = new System.Drawing.Size(85, 17);
            this.rbDateActivity1.TabIndex = 21;
            this.rbDateActivity1.TabStop = true;
            this.rbDateActivity1.Text = "Date Activity";
            this.rbDateActivity1.UseVisualStyleBackColor = true;
            // 
            // btnprintdatestyl
            // 
            this.btnprintdatestyl.Location = new System.Drawing.Point(207, 66);
            this.btnprintdatestyl.Name = "btnprintdatestyl";
            this.btnprintdatestyl.Size = new System.Drawing.Size(58, 23);
            this.btnprintdatestyl.TabIndex = 13;
            this.btnprintdatestyl.Text = "Print";
            this.btnprintdatestyl.UseVisualStyleBackColor = true;
            this.btnprintdatestyl.Click += new System.EventHandler(this.btnprintdatestyl_Click);
            // 
            // lblStylecodeDI
            // 
            this.lblStylecodeDI.AutoSize = true;
            this.lblStylecodeDI.Location = new System.Drawing.Point(6, 21);
            this.lblStylecodeDI.Name = "lblStylecodeDI";
            this.lblStylecodeDI.Size = new System.Drawing.Size(54, 13);
            this.lblStylecodeDI.TabIndex = 20;
            this.lblStylecodeDI.Text = "Stylecode";
            // 
            // cmbStyleDI
            // 
            this.cmbStyleDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyleDI.FormattingEnabled = true;
            this.cmbStyleDI.Location = new System.Drawing.Point(66, 13);
            this.cmbStyleDI.Name = "cmbStyleDI";
            this.cmbStyleDI.Size = new System.Drawing.Size(180, 21);
            this.cmbStyleDI.TabIndex = 19;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.rbEmployee1);
            this.groupBox12.Controls.Add(this.rbDate1);
            this.groupBox12.Controls.Add(this.rbDateEmp1);
            this.groupBox12.Controls.Add(this.rbempDate1);
            this.groupBox12.Controls.Add(this.btnprintdateonly);
            this.groupBox12.Controls.Add(this.rbstyleactivity1);
            this.groupBox12.Controls.Add(this.rbActivityStyle1);
            this.groupBox12.Location = new System.Drawing.Point(284, 89);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(260, 101);
            this.groupBox12.TabIndex = 14;
            this.groupBox12.TabStop = false;
            // 
            // rbEmployee1
            // 
            this.rbEmployee1.AutoSize = true;
            this.rbEmployee1.Location = new System.Drawing.Point(6, 77);
            this.rbEmployee1.Name = "rbEmployee1";
            this.rbEmployee1.Size = new System.Drawing.Size(117, 17);
            this.rbEmployee1.TabIndex = 16;
            this.rbEmployee1.TabStop = true;
            this.rbEmployee1.Text = "Summary-Employee";
            this.rbEmployee1.UseVisualStyleBackColor = true;
            // 
            // rbDate1
            // 
            this.rbDate1.AutoSize = true;
            this.rbDate1.Location = new System.Drawing.Point(6, 54);
            this.rbDate1.Name = "rbDate1";
            this.rbDate1.Size = new System.Drawing.Size(94, 17);
            this.rbDate1.TabIndex = 15;
            this.rbDate1.TabStop = true;
            this.rbDate1.Text = "Summary-Date";
            this.rbDate1.UseVisualStyleBackColor = true;
            // 
            // rbDateEmp1
            // 
            this.rbDateEmp1.AutoSize = true;
            this.rbDateEmp1.Location = new System.Drawing.Point(6, 36);
            this.rbDateEmp1.Name = "rbDateEmp1";
            this.rbDateEmp1.Size = new System.Drawing.Size(115, 17);
            this.rbDateEmp1.TabIndex = 14;
            this.rbDateEmp1.TabStop = true;
            this.rbDateEmp1.Text = "Summary-DateEmp\r\n";
            this.rbDateEmp1.UseVisualStyleBackColor = true;
            // 
            // rbempDate1
            // 
            this.rbempDate1.AutoSize = true;
            this.rbempDate1.Checked = true;
            this.rbempDate1.Location = new System.Drawing.Point(6, 14);
            this.rbempDate1.Name = "rbempDate1";
            this.rbempDate1.Size = new System.Drawing.Size(115, 17);
            this.rbempDate1.TabIndex = 13;
            this.rbempDate1.TabStop = true;
            this.rbempDate1.Text = "Summary-EmpDate";
            this.rbempDate1.UseVisualStyleBackColor = true;
            // 
            // btnprintdateonly
            // 
            this.btnprintdateonly.Location = new System.Drawing.Point(171, 71);
            this.btnprintdateonly.Name = "btnprintdateonly";
            this.btnprintdateonly.Size = new System.Drawing.Size(75, 23);
            this.btnprintdateonly.TabIndex = 3;
            this.btnprintdateonly.Text = "Print";
            this.btnprintdateonly.UseVisualStyleBackColor = true;
            this.btnprintdateonly.Click += new System.EventHandler(this.btnprintdateonly_Click);
            // 
            // rbstyleactivity1
            // 
            this.rbstyleactivity1.AutoSize = true;
            this.rbstyleactivity1.Location = new System.Drawing.Point(171, 16);
            this.rbstyleactivity1.Name = "rbstyleactivity1";
            this.rbstyleactivity1.Size = new System.Drawing.Size(82, 17);
            this.rbstyleactivity1.TabIndex = 0;
            this.rbstyleactivity1.TabStop = true;
            this.rbstyleactivity1.Text = "StyleActivity";
            this.rbstyleactivity1.UseVisualStyleBackColor = true;
            // 
            // rbActivityStyle1
            // 
            this.rbActivityStyle1.AutoSize = true;
            this.rbActivityStyle1.Location = new System.Drawing.Point(171, 37);
            this.rbActivityStyle1.Name = "rbActivityStyle1";
            this.rbActivityStyle1.Size = new System.Drawing.Size(82, 17);
            this.rbActivityStyle1.TabIndex = 10;
            this.rbActivityStyle1.TabStop = true;
            this.rbActivityStyle1.Text = "ActivityStyle";
            this.rbActivityStyle1.UseVisualStyleBackColor = true;
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Location = new System.Drawing.Point(137, 15);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(20, 13);
            this.lblto.TabIndex = 7;
            this.lblto.Text = "To";
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Location = new System.Drawing.Point(9, 15);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(30, 13);
            this.lblfrom.TabIndex = 6;
            this.lblfrom.Text = "From";
            // 
            // dtpto1
            // 
            this.dtpto1.CustomFormat = "dd/MM/yyyy";
            this.dtpto1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpto1.Location = new System.Drawing.Point(163, 13);
            this.dtpto1.MaxDate = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            this.dtpto1.Name = "dtpto1";
            this.dtpto1.Size = new System.Drawing.Size(86, 20);
            this.dtpto1.TabIndex = 2;
            this.dtpto1.Leave += new System.EventHandler(this.dtpto1_Leave);
            this.dtpto1.DropDown += new System.EventHandler(this.dtpto1_DropDown);
            // 
            // dtpfrom1
            // 
            this.dtpfrom1.CustomFormat = "dd/MM/yyyy";
            this.dtpfrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom1.Location = new System.Drawing.Point(45, 13);
            this.dtpfrom1.MaxDate = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            this.dtpfrom1.Name = "dtpfrom1";
            this.dtpfrom1.Size = new System.Drawing.Size(86, 20);
            this.dtpfrom1.TabIndex = 1;
            this.dtpfrom1.Leave += new System.EventHandler(this.dtpfrom1_Leave);
            this.dtpfrom1.CloseUp += new System.EventHandler(this.dtpfrom1_CloseUp);
            // 
            // gbDPD2
            // 
            this.gbDPD2.Controls.Add(this.lblstylecode);
            this.gbDPD2.Controls.Add(this.cmbStyle);
            this.gbDPD2.Controls.Add(this.btnDlyPrint2);
            this.gbDPD2.Controls.Add(this.rbDlyEmp2);
            this.gbDPD2.Controls.Add(this.lblProductDate2);
            this.gbDPD2.Controls.Add(this.rbDlyAct2);
            this.gbDPD2.Controls.Add(this.dtpProdDate2);
            this.gbDPD2.Location = new System.Drawing.Point(249, 6);
            this.gbDPD2.Name = "gbDPD2";
            this.gbDPD2.Size = new System.Drawing.Size(231, 191);
            this.gbDPD2.TabIndex = 4;
            this.gbDPD2.TabStop = false;
            this.gbDPD2.Text = "Daily Production Details";
            // 
            // lblstylecode
            // 
            this.lblstylecode.AutoSize = true;
            this.lblstylecode.Location = new System.Drawing.Point(6, 54);
            this.lblstylecode.Name = "lblstylecode";
            this.lblstylecode.Size = new System.Drawing.Size(54, 13);
            this.lblstylecode.TabIndex = 21;
            this.lblstylecode.Text = "Stylecode";
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(9, 70);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(211, 21);
            this.cmbStyle.TabIndex = 20;
            // 
            // btnDlyPrint2
            // 
            this.btnDlyPrint2.Location = new System.Drawing.Point(145, 120);
            this.btnDlyPrint2.Name = "btnDlyPrint2";
            this.btnDlyPrint2.Size = new System.Drawing.Size(75, 23);
            this.btnDlyPrint2.TabIndex = 2;
            this.btnDlyPrint2.Text = "Print";
            this.btnDlyPrint2.UseVisualStyleBackColor = true;
            this.btnDlyPrint2.Click += new System.EventHandler(this.btnDlyPrint2_Click);
            // 
            // rbDlyEmp2
            // 
            this.rbDlyEmp2.AutoSize = true;
            this.rbDlyEmp2.Checked = true;
            this.rbDlyEmp2.Location = new System.Drawing.Point(6, 97);
            this.rbDlyEmp2.Name = "rbDlyEmp2";
            this.rbDlyEmp2.Size = new System.Drawing.Size(98, 17);
            this.rbDlyEmp2.TabIndex = 1;
            this.rbDlyEmp2.TabStop = true;
            this.rbDlyEmp2.Text = "Employee Wise";
            this.rbDlyEmp2.UseVisualStyleBackColor = true;
            // 
            // lblProductDate2
            // 
            this.lblProductDate2.AutoSize = true;
            this.lblProductDate2.Location = new System.Drawing.Point(6, 22);
            this.lblProductDate2.Name = "lblProductDate2";
            this.lblProductDate2.Size = new System.Drawing.Size(84, 13);
            this.lblProductDate2.TabIndex = 1;
            this.lblProductDate2.Text = "Production Date";
            // 
            // rbDlyAct2
            // 
            this.rbDlyAct2.AutoSize = true;
            this.rbDlyAct2.Location = new System.Drawing.Point(126, 97);
            this.rbDlyAct2.Name = "rbDlyAct2";
            this.rbDlyAct2.Size = new System.Drawing.Size(94, 17);
            this.rbDlyAct2.TabIndex = 0;
            this.rbDlyAct2.TabStop = true;
            this.rbDlyAct2.Text = "Activities Wise";
            this.rbDlyAct2.UseVisualStyleBackColor = true;
            // 
            // dtpProdDate2
            // 
            this.dtpProdDate2.CustomFormat = "dd/MM/yyyy";
            this.dtpProdDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProdDate2.Location = new System.Drawing.Point(112, 19);
            this.dtpProdDate2.MaxDate = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            this.dtpProdDate2.Name = "dtpProdDate2";
            this.dtpProdDate2.Size = new System.Drawing.Size(108, 20);
            this.dtpProdDate2.TabIndex = 0;
            this.dtpProdDate2.Leave += new System.EventHandler(this.dtpProdDate2_Leave);
            this.dtpProdDate2.CloseUp += new System.EventHandler(this.dtpProdDate2_CloseUp);
            // 
            // gbDPD1
            // 
            this.gbDPD1.Controls.Add(this.rbOperations);
            this.gbDPD1.Controls.Add(this.btnDlyPrint1);
            this.gbDPD1.Controls.Add(this.rbDlyEmp1);
            this.gbDPD1.Controls.Add(this.lblProductDate1);
            this.gbDPD1.Controls.Add(this.rbDlyAct1);
            this.gbDPD1.Controls.Add(this.dtpProdDate1);
            this.gbDPD1.Location = new System.Drawing.Point(6, 6);
            this.gbDPD1.Name = "gbDPD1";
            this.gbDPD1.Size = new System.Drawing.Size(237, 137);
            this.gbDPD1.TabIndex = 3;
            this.gbDPD1.TabStop = false;
            this.gbDPD1.Text = "Daily Production Details";
            // 
            // rbOperations
            // 
            this.rbOperations.AutoSize = true;
            this.rbOperations.Location = new System.Drawing.Point(9, 97);
            this.rbOperations.Name = "rbOperations";
            this.rbOperations.Size = new System.Drawing.Size(107, 17);
            this.rbOperations.TabIndex = 3;
            this.rbOperations.TabStop = true;
            this.rbOperations.Text = "Operator Analysis";
            this.rbOperations.UseVisualStyleBackColor = true;
            // 
            // btnDlyPrint1
            // 
            this.btnDlyPrint1.Location = new System.Drawing.Point(144, 100);
            this.btnDlyPrint1.Name = "btnDlyPrint1";
            this.btnDlyPrint1.Size = new System.Drawing.Size(75, 23);
            this.btnDlyPrint1.TabIndex = 2;
            this.btnDlyPrint1.Text = "Print";
            this.btnDlyPrint1.UseVisualStyleBackColor = true;
            this.btnDlyPrint1.Click += new System.EventHandler(this.btnDlyPrint1_Click);
            // 
            // rbDlyEmp1
            // 
            this.rbDlyEmp1.AutoSize = true;
            this.rbDlyEmp1.Checked = true;
            this.rbDlyEmp1.Location = new System.Drawing.Point(9, 41);
            this.rbDlyEmp1.Name = "rbDlyEmp1";
            this.rbDlyEmp1.Size = new System.Drawing.Size(98, 17);
            this.rbDlyEmp1.TabIndex = 1;
            this.rbDlyEmp1.TabStop = true;
            this.rbDlyEmp1.Text = "Employee Wise";
            this.rbDlyEmp1.UseVisualStyleBackColor = true;
            // 
            // lblProductDate1
            // 
            this.lblProductDate1.AutoSize = true;
            this.lblProductDate1.Location = new System.Drawing.Point(6, 22);
            this.lblProductDate1.Name = "lblProductDate1";
            this.lblProductDate1.Size = new System.Drawing.Size(84, 13);
            this.lblProductDate1.TabIndex = 1;
            this.lblProductDate1.Text = "Production Date";
            // 
            // rbDlyAct1
            // 
            this.rbDlyAct1.AutoSize = true;
            this.rbDlyAct1.Location = new System.Drawing.Point(9, 64);
            this.rbDlyAct1.Name = "rbDlyAct1";
            this.rbDlyAct1.Size = new System.Drawing.Size(94, 17);
            this.rbDlyAct1.TabIndex = 0;
            this.rbDlyAct1.TabStop = true;
            this.rbDlyAct1.Text = "Activities Wise";
            this.rbDlyAct1.UseVisualStyleBackColor = true;
            // 
            // dtpProdDate1
            // 
            this.dtpProdDate1.CustomFormat = "dd/MM/yyyy";
            this.dtpProdDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProdDate1.Location = new System.Drawing.Point(123, 22);
            this.dtpProdDate1.MaxDate = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            this.dtpProdDate1.Name = "dtpProdDate1";
            this.dtpProdDate1.Size = new System.Drawing.Size(108, 20);
            this.dtpProdDate1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCutPrint);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpCutTo);
            this.tabPage1.Controls.Add(this.dtpCutFrom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1264, 203);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Cutting";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnCutPrint
            // 
            this.btnCutPrint.Location = new System.Drawing.Point(174, 68);
            this.btnCutPrint.Name = "btnCutPrint";
            this.btnCutPrint.Size = new System.Drawing.Size(75, 23);
            this.btnCutPrint.TabIndex = 12;
            this.btnCutPrint.Text = "Print";
            this.btnCutPrint.UseVisualStyleBackColor = true;
            this.btnCutPrint.Click += new System.EventHandler(this.btnCutPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "From";
            // 
            // dtpCutTo
            // 
            this.dtpCutTo.CustomFormat = "dd/MM/yyyy";
            this.dtpCutTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCutTo.Location = new System.Drawing.Point(174, 25);
            this.dtpCutTo.MaxDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            this.dtpCutTo.Name = "dtpCutTo";
            this.dtpCutTo.Size = new System.Drawing.Size(86, 20);
            this.dtpCutTo.TabIndex = 9;
            // 
            // dtpCutFrom
            // 
            this.dtpCutFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpCutFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCutFrom.Location = new System.Drawing.Point(54, 25);
            this.dtpCutFrom.Name = "dtpCutFrom";
            this.dtpCutFrom.Size = new System.Drawing.Size(86, 20);
            this.dtpCutFrom.TabIndex = 8;
            // 
            // frmProductionReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 597);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmProductionReports";
            this.Text = "Production Reports";
            this.Load += new System.EventHandler(this.frmProductionReports_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbyearwise.ResumeLayout(false);
            this.gbdateinterval.ResumeLayout(false);
            this.gbdateinterval.PerformLayout();
            this.gbActivity.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.gbDPD2.ResumeLayout(false);
            this.gbDPD2.PerformLayout();
            this.gbDPD1.ResumeLayout(false);
            this.gbDPD1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbDPD2;
        private System.Windows.Forms.Button btnDlyPrint2;
        private System.Windows.Forms.RadioButton rbDlyEmp2;
        private System.Windows.Forms.Label lblProductDate2;
        private System.Windows.Forms.RadioButton rbDlyAct2;
        private System.Windows.Forms.DateTimePicker dtpProdDate2;
        private System.Windows.Forms.GroupBox gbDPD1;
        private System.Windows.Forms.Button btnDlyPrint1;
        private System.Windows.Forms.RadioButton rbDlyEmp1;
        private System.Windows.Forms.Label lblProductDate1;
        private System.Windows.Forms.RadioButton rbDlyAct1;
        private System.Windows.Forms.DateTimePicker dtpProdDate1;
        private System.Windows.Forms.GroupBox gbdateinterval;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RadioButton rbStyleSizeSum1;
        private System.Windows.Forms.RadioButton rbActivityDate1;
        private System.Windows.Forms.RadioButton rbDateActivity1;
        private System.Windows.Forms.Button btnprintdatestyl;
        private System.Windows.Forms.Label lblStylecodeDI;
        private System.Windows.Forms.ComboBox cmbStyleDI;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnprintdateonly;
        private System.Windows.Forms.RadioButton rbstyleactivity1;
        private System.Windows.Forms.RadioButton rbActivityStyle1;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.DateTimePicker dtpto1;
        private System.Windows.Forms.DateTimePicker dtpfrom1;
        private System.Windows.Forms.Label lblstylecode;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Button btnprintStyAct;
        private System.Windows.Forms.RadioButton rbempDate1;
        private System.Windows.Forms.RadioButton rbEmployee1;
        private System.Windows.Forms.RadioButton rbDate1;
        private System.Windows.Forms.RadioButton rbDateEmp1;
        private System.Windows.Forms.GroupBox gbyearwise;
        private System.Windows.Forms.Button btnprintyear1;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.GroupBox gbActivity;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpCutTo;
        private System.Windows.Forms.DateTimePicker dtpCutFrom;
        private System.Windows.Forms.Button btnCutPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbstylecost;
        private System.Windows.Forms.RadioButton rbPStyleActQtyCost;
        private System.Windows.Forms.RadioButton rbPStyleActDateQtyCost;
        private System.Windows.Forms.RadioButton rbPStyleBatchStatus;
        private System.Windows.Forms.RadioButton rbPStyleRate;
        private System.Windows.Forms.Button btnPStyle;
        private System.Windows.Forms.RadioButton rbOperations;
    }
}