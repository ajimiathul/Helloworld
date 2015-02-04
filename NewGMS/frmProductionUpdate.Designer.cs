namespace NewGMS
{
    partial class frmProductionUpdate
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbDeletion = new System.Windows.Forms.CheckBox();
            this.clbDupLot = new System.Windows.Forms.CheckedListBox();
            this.lblBundleNo = new System.Windows.Forms.Label();
            this.txthidAct = new System.Windows.Forms.TextBox();
            this.txtBunNo = new System.Windows.Forms.TextBox();
            this.txthidBunFromDB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAlphabatical = new System.Windows.Forms.RadioButton();
            this.rbNumber = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txthidLot = new System.Windows.Forms.TextBox();
            this.clbLot = new System.Windows.Forms.CheckedListBox();
            this.txthidStyle = new System.Windows.Forms.TextBox();
            this.clbStyle = new System.Windows.Forms.CheckedListBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.rbPiece = new System.Windows.Forms.RadioButton();
            this.btnShow = new System.Windows.Forms.Button();
            this.rbBundle = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPndPcs = new System.Windows.Forms.TextBox();
            this.txtCmpltdPCS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.lvBundle = new System.Windows.Forms.ListView();
            this.colBunNo = new System.Windows.Forms.ColumnHeader();
            this.colStyleCode = new System.Windows.Forms.ColumnHeader();
            this.colLotNo = new System.Windows.Forms.ColumnHeader();
            this.colQty = new System.Windows.Forms.ColumnHeader();
            this.colCmltd = new System.Windows.Forms.ColumnHeader();
            this.colPend = new System.Windows.Forms.ColumnHeader();
            this.colActCode = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPrdQty = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lvBundle2 = new System.Windows.Forms.ListView();
            this.ColName = new System.Windows.Forms.ColumnHeader();
            this.ColID = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColDate = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnReverse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMachine = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbDeletion);
            this.groupBox1.Controls.Add(this.clbDupLot);
            this.groupBox1.Controls.Add(this.lblBundleNo);
            this.groupBox1.Controls.Add(this.txthidAct);
            this.groupBox1.Controls.Add(this.txtBunNo);
            this.groupBox1.Controls.Add(this.txthidBunFromDB);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txthidLot);
            this.groupBox1.Controls.Add(this.clbLot);
            this.groupBox1.Controls.Add(this.txthidStyle);
            this.groupBox1.Controls.Add(this.clbStyle);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cmbActivity);
            this.groupBox1.Controls.Add(this.rbPiece);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.rbBundle);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1231, 191);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bundle Selection From Cutting Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chbDeletion
            // 
            this.chbDeletion.AutoSize = true;
            this.chbDeletion.Location = new System.Drawing.Point(787, 99);
            this.chbDeletion.Name = "chbDeletion";
            this.chbDeletion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbDeletion.Size = new System.Drawing.Size(110, 17);
            this.chbDeletion.TabIndex = 48;
            this.chbDeletion.Text = "Show for Deletion";
            this.chbDeletion.UseVisualStyleBackColor = true;
            // 
            // clbDupLot
            // 
            this.clbDupLot.CheckOnClick = true;
            this.clbDupLot.FormattingEnabled = true;
            this.clbDupLot.Location = new System.Drawing.Point(1107, 21);
            this.clbDupLot.Name = "clbDupLot";
            this.clbDupLot.Size = new System.Drawing.Size(100, 79);
            this.clbDupLot.TabIndex = 44;
            this.clbDupLot.Visible = false;
            // 
            // lblBundleNo
            // 
            this.lblBundleNo.AutoSize = true;
            this.lblBundleNo.Location = new System.Drawing.Point(499, 62);
            this.lblBundleNo.Name = "lblBundleNo";
            this.lblBundleNo.Size = new System.Drawing.Size(80, 13);
            this.lblBundleNo.TabIndex = 42;
            this.lblBundleNo.Text = "Bundle Number";
            // 
            // txthidAct
            // 
            this.txthidAct.Location = new System.Drawing.Point(612, 165);
            this.txthidAct.Name = "txthidAct";
            this.txthidAct.Size = new System.Drawing.Size(30, 20);
            this.txthidAct.TabIndex = 47;
            this.txthidAct.Text = "0";
            this.txthidAct.Visible = false;
            // 
            // txtBunNo
            // 
            this.txtBunNo.Location = new System.Drawing.Point(498, 80);
            this.txtBunNo.Name = "txtBunNo";
            this.txtBunNo.Size = new System.Drawing.Size(86, 20);
            this.txtBunNo.TabIndex = 43;
            this.txtBunNo.Text = "0";
            // 
            // txthidBunFromDB
            // 
            this.txthidBunFromDB.Location = new System.Drawing.Point(574, 165);
            this.txthidBunFromDB.Name = "txthidBunFromDB";
            this.txthidBunFromDB.Size = new System.Drawing.Size(30, 20);
            this.txthidBunFromDB.TabIndex = 46;
            this.txthidBunFromDB.Text = "0";
            this.txthidBunFromDB.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAlphabatical);
            this.groupBox2.Controls.Add(this.rbNumber);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(604, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 47);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // rbAlphabatical
            // 
            this.rbAlphabatical.AutoSize = true;
            this.rbAlphabatical.Checked = true;
            this.rbAlphabatical.Location = new System.Drawing.Point(177, 25);
            this.rbAlphabatical.Name = "rbAlphabatical";
            this.rbAlphabatical.Size = new System.Drawing.Size(112, 17);
            this.rbAlphabatical.TabIndex = 28;
            this.rbAlphabatical.TabStop = true;
            this.rbAlphabatical.Text = "Alphabatical Order";
            this.rbAlphabatical.UseVisualStyleBackColor = true;
            this.rbAlphabatical.CheckedChanged += new System.EventHandler(this.rbAlphabatical_CheckedChanged);
            // 
            // rbNumber
            // 
            this.rbNumber.AutoSize = true;
            this.rbNumber.Location = new System.Drawing.Point(71, 25);
            this.rbNumber.Name = "rbNumber";
            this.rbNumber.Size = new System.Drawing.Size(98, 17);
            this.rbNumber.TabIndex = 27;
            this.rbNumber.Text = "Order No. Wise";
            this.rbNumber.UseVisualStyleBackColor = true;
            this.rbNumber.CheckedChanged += new System.EventHandler(this.rbNumber_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Activity";
            // 
            // txthidLot
            // 
            this.txthidLot.Location = new System.Drawing.Point(538, 165);
            this.txthidLot.Name = "txthidLot";
            this.txthidLot.Size = new System.Drawing.Size(30, 20);
            this.txthidLot.TabIndex = 45;
            this.txthidLot.Text = "0";
            this.txthidLot.Visible = false;
            // 
            // clbLot
            // 
            this.clbLot.CheckOnClick = true;
            this.clbLot.FormattingEnabled = true;
            this.clbLot.Location = new System.Drawing.Point(252, 37);
            this.clbLot.Name = "clbLot";
            this.clbLot.Size = new System.Drawing.Size(219, 154);
            this.clbLot.TabIndex = 34;
            this.clbLot.SelectedIndexChanged += new System.EventHandler(this.clbLot_SelectedIndexChanged);
            // 
            // txthidStyle
            // 
            this.txthidStyle.Location = new System.Drawing.Point(502, 165);
            this.txthidStyle.Name = "txthidStyle";
            this.txthidStyle.Size = new System.Drawing.Size(30, 20);
            this.txthidStyle.TabIndex = 44;
            this.txthidStyle.Text = "0";
            this.txthidStyle.Visible = false;
            // 
            // clbStyle
            // 
            this.clbStyle.CheckOnClick = true;
            this.clbStyle.FormattingEnabled = true;
            this.clbStyle.Location = new System.Drawing.Point(0, 36);
            this.clbStyle.Name = "clbStyle";
            this.clbStyle.Size = new System.Drawing.Size(163, 154);
            this.clbStyle.TabIndex = 33;
            this.clbStyle.SelectedIndexChanged += new System.EventHandler(this.clbStyle_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Style Code";
            // 
            // cmbActivity
            // 
            this.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Location = new System.Drawing.Point(604, 72);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(293, 21);
            this.cmbActivity.TabIndex = 9;
            // 
            // rbPiece
            // 
            this.rbPiece.AutoSize = true;
            this.rbPiece.Location = new System.Drawing.Point(477, 43);
            this.rbPiece.Name = "rbPiece";
            this.rbPiece.Size = new System.Drawing.Size(79, 17);
            this.rbPiece.TabIndex = 27;
            this.rbPiece.Text = "Piece Wise";
            this.rbPiece.UseVisualStyleBackColor = true;
            this.rbPiece.CheckedChanged += new System.EventHandler(this.rbPiece_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(818, 122);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 22;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // rbBundle
            // 
            this.rbBundle.AutoSize = true;
            this.rbBundle.Checked = true;
            this.rbBundle.Location = new System.Drawing.Point(477, 20);
            this.rbBundle.Name = "rbBundle";
            this.rbBundle.Size = new System.Drawing.Size(85, 17);
            this.rbBundle.TabIndex = 26;
            this.rbBundle.TabStop = true;
            this.rbBundle.Text = "Bundle Wise";
            this.rbBundle.UseVisualStyleBackColor = true;
            this.rbBundle.CheckedChanged += new System.EventHandler(this.rbBundle_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(251, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Lot No.";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(693, 310);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(942, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Completed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1098, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Pending";
            // 
            // txtPndPcs
            // 
            this.txtPndPcs.Location = new System.Drawing.Point(1185, 257);
            this.txtPndPcs.Name = "txtPndPcs";
            this.txtPndPcs.ReadOnly = true;
            this.txtPndPcs.Size = new System.Drawing.Size(50, 20);
            this.txtPndPcs.TabIndex = 14;
            // 
            // txtCmpltdPCS
            // 
            this.txtCmpltdPCS.Location = new System.Drawing.Point(1010, 257);
            this.txtCmpltdPCS.Name = "txtCmpltdPCS";
            this.txtCmpltdPCS.ReadOnly = true;
            this.txtCmpltdPCS.Size = new System.Drawing.Size(54, 20);
            this.txtCmpltdPCS.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1098, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Shift";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(942, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Date";
            // 
            // cmbTime
            // 
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(566, 250);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(103, 21);
            this.cmbTime.TabIndex = 12;
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(1132, 220);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(103, 21);
            this.cmbShift.TabIndex = 11;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(978, 221);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(86, 20);
            this.dtpDate.TabIndex = 10;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(843, 219);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(86, 20);
            this.txtID.TabIndex = 8;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(566, 218);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(202, 21);
            this.cmbName.TabIndex = 7;
            this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
            // 
            // lvBundle
            // 
            this.lvBundle.CheckBoxes = true;
            this.lvBundle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBunNo,
            this.colStyleCode,
            this.colLotNo,
            this.colQty,
            this.colCmltd,
            this.colPend,
            this.colActCode});
            this.lvBundle.FullRowSelect = true;
            this.lvBundle.GridLines = true;
            this.lvBundle.Location = new System.Drawing.Point(6, 207);
            this.lvBundle.Name = "lvBundle";
            this.lvBundle.Size = new System.Drawing.Size(471, 372);
            this.lvBundle.TabIndex = 8;
            this.lvBundle.UseCompatibleStateImageBehavior = false;
            this.lvBundle.View = System.Windows.Forms.View.Details;
            this.lvBundle.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvBundle_ItemCheck);
            // 
            // colBunNo
            // 
            this.colBunNo.Text = "Bundle No";
            this.colBunNo.Width = 65;
            // 
            // colStyleCode
            // 
            this.colStyleCode.Text = "Style Code";
            this.colStyleCode.Width = 100;
            // 
            // colLotNo
            // 
            this.colLotNo.Text = "Lot No.";
            this.colLotNo.Width = 100;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty";
            // 
            // colCmltd
            // 
            this.colCmltd.Text = "Completed";
            this.colCmltd.Width = 65;
            // 
            // colPend
            // 
            this.colPend.Text = "Pending";
            // 
            // colActCode
            // 
            this.colActCode.Text = "ActivityCode";
            this.colActCode.Width = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(784, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Emp ID";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(501, 221);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Emp Name";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(843, 257);
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(54, 20);
            this.txtQty.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(789, 261);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Qty";
            // 
            // txtPrdQty
            // 
            this.txtPrdQty.Location = new System.Drawing.Point(615, 312);
            this.txtPrdQty.Name = "txtPrdQty";
            this.txtPrdQty.Size = new System.Drawing.Size(54, 20);
            this.txtPrdQty.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(501, 315);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Production Qty";
            // 
            // lvBundle2
            // 
            this.lvBundle2.CheckBoxes = true;
            this.lvBundle2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColID,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.ColDate,
            this.colTime,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6});
            this.lvBundle2.FullRowSelect = true;
            this.lvBundle2.GridLines = true;
            this.lvBundle2.Location = new System.Drawing.Point(491, 370);
            this.lvBundle2.Name = "lvBundle2";
            this.lvBundle2.Size = new System.Drawing.Size(765, 209);
            this.lvBundle2.TabIndex = 48;
            this.lvBundle2.UseCompatibleStateImageBehavior = false;
            this.lvBundle2.View = System.Windows.Forms.View.Details;
            // 
            // ColName
            // 
            this.ColName.Text = "Name";
            this.ColName.Width = 170;
            // 
            // ColID
            // 
            this.ColID.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "BundleNo";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "LotNo";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "StyleNo";
            this.columnHeader4.Width = 90;
            // 
            // ColDate
            // 
            this.ColDate.Text = "Date";
            this.ColDate.Width = 90;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 90;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "QTY";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "RecID";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ActivityCode";
            this.columnHeader6.Width = 0;
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(493, 585);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(69, 23);
            this.btnReverse.TabIndex = 49;
            this.btnReverse.Text = "Delete";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "For Deletion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Machine";
            // 
            // cmbMachine
            // 
            this.cmbMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachine.FormattingEnabled = true;
            this.cmbMachine.Location = new System.Drawing.Point(566, 285);
            this.cmbMachine.Name = "cmbMachine";
            this.cmbMachine.Size = new System.Drawing.Size(103, 21);
            this.cmbMachine.TabIndex = 51;
            // 
            // frmProductionUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 618);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMachine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.lvBundle2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtPrdQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lvBundle);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCmpltdPCS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPndPcs);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.dtpDate);
            this.Name = "frmProductionUpdate";
            this.Load += new System.EventHandler(this.frmProductionUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPndPcs;
        private System.Windows.Forms.TextBox txtCmpltdPCS;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView lvBundle;
        private System.Windows.Forms.ColumnHeader colBunNo;
        private System.Windows.Forms.ColumnHeader colCmltd;
        private System.Windows.Forms.ColumnHeader colPend;
        private System.Windows.Forms.RadioButton rbPiece;
        private System.Windows.Forms.RadioButton rbBundle;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPrdQty;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ColumnHeader colStyleCode;
        private System.Windows.Forms.ColumnHeader colLotNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbAlphabatical;
        private System.Windows.Forms.RadioButton rbNumber;
        private System.Windows.Forms.CheckedListBox clbLot;
        private System.Windows.Forms.CheckedListBox clbStyle;
        private System.Windows.Forms.Label lblBundleNo;
        private System.Windows.Forms.TextBox txtBunNo;
        private System.Windows.Forms.CheckedListBox clbDupLot;
        private System.Windows.Forms.ColumnHeader colActCode;
        private System.Windows.Forms.TextBox txthidStyle;
        private System.Windows.Forms.TextBox txthidLot;
        private System.Windows.Forms.TextBox txthidBunFromDB;
        private System.Windows.Forms.TextBox txthidAct;
        private System.Windows.Forms.ListView lvBundle2;
        private System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader ColID;
        private System.Windows.Forms.ColumnHeader ColDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.CheckBox chbDeletion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMachine;
    }
}