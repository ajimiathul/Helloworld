namespace NewGMS
{
    partial class frmEmployee
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMaster = new System.Windows.Forms.TabPage();
            this.cmbneedmachine = new System.Windows.Forms.ComboBox();
            this.lblneedmachine = new System.Windows.Forms.Label();
            this.cmbempstatus = new System.Windows.Forms.ComboBox();
            this.lblstatus = new System.Windows.Forms.Label();
            this.cmboperator = new System.Windows.Forms.ComboBox();
            this.lbloperator = new System.Windows.Forms.Label();
            this.grpGender = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.grpAuthority = new System.Windows.Forms.GroupBox();
            this.rbAuthorityNo = new System.Windows.Forms.RadioButton();
            this.rbAuthorityYes = new System.Windows.Forms.RadioButton();
            this.grpLeave = new System.Windows.Forms.GroupBox();
            this.rbNoLeave = new System.Windows.Forms.RadioButton();
            this.rbYesLeave = new System.Windows.Forms.RadioButton();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.rbResigned = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dtpDOR = new System.Windows.Forms.DateTimePicker();
            this.dtpDOJ = new System.Windows.Forms.DateTimePicker();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAdr = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabQualification = new System.Windows.Forms.TabPage();
            this.tabSalary = new System.Windows.Forms.TabPage();
            this.tabAttendance = new System.Windows.Forms.TabPage();
            this.tabProduction = new System.Windows.Forms.TabPage();
            this.tabSeachByDtls = new System.Windows.Forms.TabPage();
            this.btnSearchByTls = new System.Windows.Forms.Button();
            this.dgvSearchDtls = new System.Windows.Forms.DataGridView();
            this.tabSearchByName = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmpCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNewEdit = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabMaster.SuspendLayout();
            this.grpGender.SuspendLayout();
            this.grpAuthority.SuspendLayout();
            this.grpLeave.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.tabSeachByDtls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchDtls)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMaster);
            this.tabControl1.Controls.Add(this.tabQualification);
            this.tabControl1.Controls.Add(this.tabSalary);
            this.tabControl1.Controls.Add(this.tabAttendance);
            this.tabControl1.Controls.Add(this.tabProduction);
            this.tabControl1.Controls.Add(this.tabSeachByDtls);
            this.tabControl1.Controls.Add(this.tabSearchByName);
            this.tabControl1.Location = new System.Drawing.Point(12, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 507);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMaster
            // 
            this.tabMaster.Controls.Add(this.cmbneedmachine);
            this.tabMaster.Controls.Add(this.lblneedmachine);
            this.tabMaster.Controls.Add(this.cmbempstatus);
            this.tabMaster.Controls.Add(this.lblstatus);
            this.tabMaster.Controls.Add(this.cmboperator);
            this.tabMaster.Controls.Add(this.lbloperator);
            this.tabMaster.Controls.Add(this.grpGender);
            this.tabMaster.Controls.Add(this.grpAuthority);
            this.tabMaster.Controls.Add(this.grpLeave);
            this.tabMaster.Controls.Add(this.grpStatus);
            this.tabMaster.Controls.Add(this.cmbType);
            this.tabMaster.Controls.Add(this.cmbDesignation);
            this.tabMaster.Controls.Add(this.cmbDepartment);
            this.tabMaster.Controls.Add(this.cmbLocation);
            this.tabMaster.Controls.Add(this.dtpDOR);
            this.tabMaster.Controls.Add(this.dtpDOJ);
            this.tabMaster.Controls.Add(this.dtpDOB);
            this.tabMaster.Controls.Add(this.txtMail);
            this.tabMaster.Controls.Add(this.txtMobile);
            this.tabMaster.Controls.Add(this.txtPhone);
            this.tabMaster.Controls.Add(this.txtAdr);
            this.tabMaster.Controls.Add(this.label13);
            this.tabMaster.Controls.Add(this.label12);
            this.tabMaster.Controls.Add(this.label11);
            this.tabMaster.Controls.Add(this.label9);
            this.tabMaster.Controls.Add(this.label8);
            this.tabMaster.Controls.Add(this.label1);
            this.tabMaster.Controls.Add(this.label6);
            this.tabMaster.Controls.Add(this.label5);
            this.tabMaster.Controls.Add(this.label4);
            this.tabMaster.Controls.Add(this.label3);
            this.tabMaster.Controls.Add(this.label2);
            this.tabMaster.Location = new System.Drawing.Point(4, 22);
            this.tabMaster.Name = "tabMaster";
            this.tabMaster.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaster.Size = new System.Drawing.Size(832, 481);
            this.tabMaster.TabIndex = 0;
            this.tabMaster.Text = "Master";
            this.tabMaster.UseVisualStyleBackColor = true;
            this.tabMaster.Click += new System.EventHandler(this.tabMaster_Click);
            // 
            // cmbneedmachine
            // 
            this.cmbneedmachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbneedmachine.FormattingEnabled = true;
            this.cmbneedmachine.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbneedmachine.Location = new System.Drawing.Point(664, 145);
            this.cmbneedmachine.Name = "cmbneedmachine";
            this.cmbneedmachine.Size = new System.Drawing.Size(153, 21);
            this.cmbneedmachine.TabIndex = 44;
            this.cmbneedmachine.SelectedIndexChanged += new System.EventHandler(this.cmbneedmachine_SelectedIndexChanged);
            // 
            // lblneedmachine
            // 
            this.lblneedmachine.AutoSize = true;
            this.lblneedmachine.Location = new System.Drawing.Point(576, 145);
            this.lblneedmachine.Name = "lblneedmachine";
            this.lblneedmachine.Size = new System.Drawing.Size(77, 13);
            this.lblneedmachine.TabIndex = 43;
            this.lblneedmachine.Text = "Need Machine";
            // 
            // cmbempstatus
            // 
            this.cmbempstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbempstatus.FormattingEnabled = true;
            this.cmbempstatus.Location = new System.Drawing.Point(664, 115);
            this.cmbempstatus.Name = "cmbempstatus";
            this.cmbempstatus.Size = new System.Drawing.Size(149, 21);
            this.cmbempstatus.TabIndex = 42;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(616, 115);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(37, 13);
            this.lblstatus.TabIndex = 41;
            this.lblstatus.Text = "Status";
            // 
            // cmboperator
            // 
            this.cmboperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboperator.FormattingEnabled = true;
            this.cmboperator.Location = new System.Drawing.Point(664, 79);
            this.cmboperator.Name = "cmboperator";
            this.cmboperator.Size = new System.Drawing.Size(149, 21);
            this.cmboperator.TabIndex = 40;
            // 
            // lbloperator
            // 
            this.lbloperator.AutoSize = true;
            this.lbloperator.Location = new System.Drawing.Point(578, 79);
            this.lbloperator.Name = "lbloperator";
            this.lbloperator.Size = new System.Drawing.Size(75, 13);
            this.lbloperator.TabIndex = 39;
            this.lbloperator.Text = "Operator Type";
            // 
            // grpGender
            // 
            this.grpGender.Controls.Add(this.rbFemale);
            this.grpGender.Controls.Add(this.rbMale);
            this.grpGender.Location = new System.Drawing.Point(88, 242);
            this.grpGender.Margin = new System.Windows.Forms.Padding(0);
            this.grpGender.Name = "grpGender";
            this.grpGender.Size = new System.Drawing.Size(202, 43);
            this.grpGender.TabIndex = 38;
            this.grpGender.TabStop = false;
            this.grpGender.Text = "Gender";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Checked = true;
            this.rbFemale.Location = new System.Drawing.Point(124, 18);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 18;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(17, 17);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 17;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // grpAuthority
            // 
            this.grpAuthority.Controls.Add(this.rbAuthorityNo);
            this.grpAuthority.Controls.Add(this.rbAuthorityYes);
            this.grpAuthority.Location = new System.Drawing.Point(585, 345);
            this.grpAuthority.Margin = new System.Windows.Forms.Padding(0);
            this.grpAuthority.Name = "grpAuthority";
            this.grpAuthority.Size = new System.Drawing.Size(236, 64);
            this.grpAuthority.TabIndex = 36;
            this.grpAuthority.TabStop = false;
            this.grpAuthority.Text = "Authority To Sign";
            // 
            // rbAuthorityNo
            // 
            this.rbAuthorityNo.AutoSize = true;
            this.rbAuthorityNo.Checked = true;
            this.rbAuthorityNo.Location = new System.Drawing.Point(17, 38);
            this.rbAuthorityNo.Name = "rbAuthorityNo";
            this.rbAuthorityNo.Size = new System.Drawing.Size(39, 17);
            this.rbAuthorityNo.TabIndex = 18;
            this.rbAuthorityNo.TabStop = true;
            this.rbAuthorityNo.Text = "No";
            this.rbAuthorityNo.UseVisualStyleBackColor = true;
            // 
            // rbAuthorityYes
            // 
            this.rbAuthorityYes.AutoSize = true;
            this.rbAuthorityYes.Location = new System.Drawing.Point(17, 19);
            this.rbAuthorityYes.Name = "rbAuthorityYes";
            this.rbAuthorityYes.Size = new System.Drawing.Size(43, 17);
            this.rbAuthorityYes.TabIndex = 17;
            this.rbAuthorityYes.Text = "Yes";
            this.rbAuthorityYes.UseVisualStyleBackColor = true;
            // 
            // grpLeave
            // 
            this.grpLeave.Controls.Add(this.rbNoLeave);
            this.grpLeave.Controls.Add(this.rbYesLeave);
            this.grpLeave.Location = new System.Drawing.Point(585, 260);
            this.grpLeave.Margin = new System.Windows.Forms.Padding(0);
            this.grpLeave.Name = "grpLeave";
            this.grpLeave.Size = new System.Drawing.Size(236, 76);
            this.grpLeave.TabIndex = 35;
            this.grpLeave.TabStop = false;
            this.grpLeave.Text = "On Leave";
            // 
            // rbNoLeave
            // 
            this.rbNoLeave.AutoSize = true;
            this.rbNoLeave.Checked = true;
            this.rbNoLeave.Enabled = false;
            this.rbNoLeave.Location = new System.Drawing.Point(17, 48);
            this.rbNoLeave.Name = "rbNoLeave";
            this.rbNoLeave.Size = new System.Drawing.Size(39, 17);
            this.rbNoLeave.TabIndex = 18;
            this.rbNoLeave.TabStop = true;
            this.rbNoLeave.Text = "No";
            this.rbNoLeave.UseVisualStyleBackColor = true;
            this.rbNoLeave.CheckedChanged += new System.EventHandler(this.rbNoLeave_CheckedChanged);
            // 
            // rbYesLeave
            // 
            this.rbYesLeave.AutoSize = true;
            this.rbYesLeave.Enabled = false;
            this.rbYesLeave.Location = new System.Drawing.Point(17, 18);
            this.rbYesLeave.Name = "rbYesLeave";
            this.rbYesLeave.Size = new System.Drawing.Size(43, 17);
            this.rbYesLeave.TabIndex = 17;
            this.rbYesLeave.Text = "Yes";
            this.rbYesLeave.UseVisualStyleBackColor = true;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.rbResigned);
            this.grpStatus.Controls.Add(this.rbActive);
            this.grpStatus.Location = new System.Drawing.Point(585, 170);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(0);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(232, 76);
            this.grpStatus.TabIndex = 34;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // rbResigned
            // 
            this.rbResigned.AutoSize = true;
            this.rbResigned.Location = new System.Drawing.Point(17, 48);
            this.rbResigned.Name = "rbResigned";
            this.rbResigned.Size = new System.Drawing.Size(70, 17);
            this.rbResigned.TabIndex = 18;
            this.rbResigned.Text = "Resigned";
            this.rbResigned.UseVisualStyleBackColor = true;
            this.rbResigned.CheckedChanged += new System.EventHandler(this.rbResigned_CheckedChanged);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Location = new System.Drawing.Point(17, 18);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(55, 17);
            this.rbActive.TabIndex = 17;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(664, 44);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(149, 21);
            this.cmbType.TabIndex = 31;
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Location = new System.Drawing.Point(89, 107);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(189, 21);
            this.cmbDesignation.TabIndex = 29;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(88, 75);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(190, 21);
            this.cmbDepartment.TabIndex = 28;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(88, 44);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(190, 21);
            this.cmbLocation.TabIndex = 27;
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.cmbLocation_SelectedIndexChanged);
            // 
            // dtpDOR
            // 
            this.dtpDOR.CustomFormat = "dd/MM/yyyy";
            this.dtpDOR.Enabled = false;
            this.dtpDOR.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOR.Location = new System.Drawing.Point(90, 200);
            this.dtpDOR.Name = "dtpDOR";
            this.dtpDOR.Size = new System.Drawing.Size(95, 20);
            this.dtpDOR.TabIndex = 25;
            // 
            // dtpDOJ
            // 
            this.dtpDOJ.CustomFormat = "dd/MM/yyyy";
            this.dtpDOJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOJ.Location = new System.Drawing.Point(90, 170);
            this.dtpDOJ.Name = "dtpDOJ";
            this.dtpDOJ.Size = new System.Drawing.Size(95, 20);
            this.dtpDOJ.TabIndex = 25;
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(90, 140);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(95, 20);
            this.dtpDOB.TabIndex = 24;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(91, 389);
            this.txtMail.MaxLength = 50;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(201, 20);
            this.txtMail.TabIndex = 23;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(91, 363);
            this.txtMobile.MaxLength = 20;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(140, 20);
            this.txtMobile.TabIndex = 22;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(90, 341);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(141, 20);
            this.txtPhone.TabIndex = 21;
            // 
            // txtAdr
            // 
            this.txtAdr.Location = new System.Drawing.Point(88, 315);
            this.txtAdr.MaxLength = 200;
            this.txtAdr.Name = "txtAdr";
            this.txtAdr.Size = new System.Drawing.Size(334, 20);
            this.txtAdr.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(578, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Employee Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 393);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "E-Mail";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 366);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Mobile";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "DOR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "DOJ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "DOB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Designation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location";
            // 
            // tabQualification
            // 
            this.tabQualification.Location = new System.Drawing.Point(4, 22);
            this.tabQualification.Name = "tabQualification";
            this.tabQualification.Padding = new System.Windows.Forms.Padding(3);
            this.tabQualification.Size = new System.Drawing.Size(832, 481);
            this.tabQualification.TabIndex = 1;
            this.tabQualification.Text = "Qualifications";
            this.tabQualification.UseVisualStyleBackColor = true;
            // 
            // tabSalary
            // 
            this.tabSalary.Location = new System.Drawing.Point(4, 22);
            this.tabSalary.Name = "tabSalary";
            this.tabSalary.Size = new System.Drawing.Size(832, 481);
            this.tabSalary.TabIndex = 2;
            this.tabSalary.Text = "Salary";
            this.tabSalary.UseVisualStyleBackColor = true;
            // 
            // tabAttendance
            // 
            this.tabAttendance.Location = new System.Drawing.Point(4, 22);
            this.tabAttendance.Name = "tabAttendance";
            this.tabAttendance.Size = new System.Drawing.Size(832, 481);
            this.tabAttendance.TabIndex = 5;
            this.tabAttendance.Text = "Attendance";
            this.tabAttendance.UseVisualStyleBackColor = true;
            // 
            // tabProduction
            // 
            this.tabProduction.Location = new System.Drawing.Point(4, 22);
            this.tabProduction.Name = "tabProduction";
            this.tabProduction.Size = new System.Drawing.Size(832, 481);
            this.tabProduction.TabIndex = 6;
            this.tabProduction.Text = "Production Details";
            this.tabProduction.UseVisualStyleBackColor = true;
            // 
            // tabSeachByDtls
            // 
            this.tabSeachByDtls.Controls.Add(this.btnSearchByTls);
            this.tabSeachByDtls.Controls.Add(this.dgvSearchDtls);
            this.tabSeachByDtls.Location = new System.Drawing.Point(4, 22);
            this.tabSeachByDtls.Name = "tabSeachByDtls";
            this.tabSeachByDtls.Size = new System.Drawing.Size(832, 481);
            this.tabSeachByDtls.TabIndex = 3;
            this.tabSeachByDtls.Text = "Search By Details";
            this.tabSeachByDtls.UseVisualStyleBackColor = true;
            // 
            // btnSearchByTls
            // 
            this.btnSearchByTls.Location = new System.Drawing.Point(18, 17);
            this.btnSearchByTls.Name = "btnSearchByTls";
            this.btnSearchByTls.Size = new System.Drawing.Size(75, 23);
            this.btnSearchByTls.TabIndex = 21;
            this.btnSearchByTls.Text = "Search";
            this.btnSearchByTls.UseVisualStyleBackColor = true;
            this.btnSearchByTls.Click += new System.EventHandler(this.btnSearchByTls_Click);
            // 
            // dgvSearchDtls
            // 
            this.dgvSearchDtls.AllowUserToAddRows = false;
            this.dgvSearchDtls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchDtls.Location = new System.Drawing.Point(18, 46);
            this.dgvSearchDtls.Name = "dgvSearchDtls";
            this.dgvSearchDtls.ReadOnly = true;
            this.dgvSearchDtls.Size = new System.Drawing.Size(747, 292);
            this.dgvSearchDtls.TabIndex = 0;
            this.dgvSearchDtls.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchDtls_CellDoubleClick);
            // 
            // tabSearchByName
            // 
            this.tabSearchByName.Location = new System.Drawing.Point(4, 22);
            this.tabSearchByName.Name = "tabSearchByName";
            this.tabSearchByName.Size = new System.Drawing.Size(832, 481);
            this.tabSearchByName.TabIndex = 4;
            this.tabSearchByName.Text = "Search by Name";
            this.tabSearchByName.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Employee";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(97, 34);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(173, 20);
            this.txtEmpName.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(330, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Employee Code";
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.Location = new System.Drawing.Point(425, 31);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.ReadOnly = true;
            this.txtEmpCode.Size = new System.Drawing.Size(94, 20);
            this.txtEmpCode.TabIndex = 16;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(506, 585);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(423, 585);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(333, 585);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNewEdit
            // 
            this.lblNewEdit.AutoSize = true;
            this.lblNewEdit.Location = new System.Drawing.Point(610, 31);
            this.lblNewEdit.Name = "lblNewEdit";
            this.lblNewEdit.Size = new System.Drawing.Size(17, 13);
            this.lblNewEdit.TabIndex = 21;
            this.lblNewEdit.Text = "lbl";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(252, 585);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 635);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblNewEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label10);
            this.Name = "frmEmployee";
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabMaster.ResumeLayout(false);
            this.tabMaster.PerformLayout();
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            this.grpAuthority.ResumeLayout(false);
            this.grpAuthority.PerformLayout();
            this.grpLeave.ResumeLayout(false);
            this.grpLeave.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.tabSeachByDtls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchDtls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMaster;
        private System.Windows.Forms.TabPage tabQualification;
        private System.Windows.Forms.TabPage tabSalary;
        private System.Windows.Forms.TabPage tabSeachByDtls;
        private System.Windows.Forms.TabPage tabSearchByName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtAdr;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.DateTimePicker dtpDOJ;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbDesignation;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.RadioButton rbResigned;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.GroupBox grpLeave;
        private System.Windows.Forms.RadioButton rbNoLeave;
        private System.Windows.Forms.RadioButton rbYesLeave;
        private System.Windows.Forms.GroupBox grpAuthority;
        private System.Windows.Forms.RadioButton rbAuthorityNo;
        private System.Windows.Forms.RadioButton rbAuthorityYes;
        private System.Windows.Forms.GroupBox grpGender;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.TextBox txtEmpCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearchByTls;
        private System.Windows.Forms.DataGridView dgvSearchDtls;
        private System.Windows.Forms.TabPage tabAttendance;
        private System.Windows.Forms.TabPage tabProduction;
        private System.Windows.Forms.Label lblNewEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DateTimePicker dtpDOR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboperator;
        private System.Windows.Forms.Label lbloperator;
        private System.Windows.Forms.ComboBox cmbempstatus;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Label lblneedmachine;
        private System.Windows.Forms.ComboBox cmbneedmachine;
    }
}