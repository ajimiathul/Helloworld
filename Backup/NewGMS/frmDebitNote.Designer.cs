namespace NewGMS
{
    partial class frmDebitNote
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtVatPer = new System.Windows.Forms.TextBox();
            this.txtExPer = new System.Windows.Forms.TextBox();
            this.txtDiscountPer = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lvAccounts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbMaterialDetails = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.txtExDuty = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lvMaterialDetail = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtCreditTotal = new System.Windows.Forms.TextBox();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.txtDebitTotal = new System.Windows.Forms.TextBox();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.txtReturnQty = new System.Windows.Forms.TextBox();
            this.lbltotalDebit = new System.Windows.Forms.Label();
            this.lblDebitNoteNo = new System.Windows.Forms.Label();
            this.lblDebitNoteDate = new System.Windows.Forms.Label();
            this.dtpVoucherDate = new System.Windows.Forms.DateTimePicker();
            this.txtHidAccCode = new System.Windows.Forms.TextBox();
            this.dgvBankPaymentVoucher = new System.Windows.Forms.DataGridView();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cmbRefDocNo = new System.Windows.Forms.ComboBox();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.cmbRefDocDate = new System.Windows.Forms.ComboBox();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.txtCostCentre = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblRefDocDate = new System.Windows.Forms.Label();
            this.lblRefDocNo = new System.Windows.Forms.Label();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblDebit = new System.Windows.Forms.Label();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblCostCentre = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHidEmpAcode = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvBankPayHD = new System.Windows.Forms.DataGridView();
            this.ColVNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbMaterialDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankPaymentVoucher)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankPayHD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 611);
            this.tabControl1.TabIndex = 515;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtVatPer);
            this.tabPage1.Controls.Add(this.txtExPer);
            this.tabPage1.Controls.Add(this.txtDiscountPer);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.lvAccounts);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.gbMaterialDetails);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnNew);
            this.tabPage1.Controls.Add(this.txtMsg);
            this.tabPage1.Controls.Add(this.txtCreditTotal);
            this.tabPage1.Controls.Add(this.txtVoucherNo);
            this.tabPage1.Controls.Add(this.txtDebitTotal);
            this.tabPage1.Controls.Add(this.lblTotalCredit);
            this.tabPage1.Controls.Add(this.txtReturnQty);
            this.tabPage1.Controls.Add(this.lbltotalDebit);
            this.tabPage1.Controls.Add(this.lblDebitNoteNo);
            this.tabPage1.Controls.Add(this.lblDebitNoteDate);
            this.tabPage1.Controls.Add(this.dtpVoucherDate);
            this.tabPage1.Controls.Add(this.txtHidAccCode);
            this.tabPage1.Controls.Add(this.dgvBankPaymentVoucher);
            this.tabPage1.Controls.Add(this.txtAccount);
            this.tabPage1.Controls.Add(this.cmbRefDocNo);
            this.tabPage1.Controls.Add(this.txtDebit);
            this.tabPage1.Controls.Add(this.cmbRefDocDate);
            this.tabPage1.Controls.Add(this.txtCredit);
            this.tabPage1.Controls.Add(this.txtCostCentre);
            this.tabPage1.Controls.Add(this.lblAccount);
            this.tabPage1.Controls.Add(this.lblRefDocDate);
            this.tabPage1.Controls.Add(this.lblRefDocNo);
            this.tabPage1.Controls.Add(this.lblDebit);
            this.tabPage1.Controls.Add(this.lblCredit);
            this.tabPage1.Controls.Add(this.lblCostCentre);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.txtHidEmpAcode);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 585);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entry";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // txtVatPer
            // 
            this.txtVatPer.Location = new System.Drawing.Point(420, 548);
            this.txtVatPer.Name = "txtVatPer";
            this.txtVatPer.Size = new System.Drawing.Size(60, 20);
            this.txtVatPer.TabIndex = 524;
            this.txtVatPer.Visible = false;
            // 
            // txtExPer
            // 
            this.txtExPer.Location = new System.Drawing.Point(420, 519);
            this.txtExPer.Name = "txtExPer";
            this.txtExPer.Size = new System.Drawing.Size(60, 20);
            this.txtExPer.TabIndex = 524;
            this.txtExPer.Visible = false;
            // 
            // txtDiscountPer
            // 
            this.txtDiscountPer.Location = new System.Drawing.Point(420, 493);
            this.txtDiscountPer.Name = "txtDiscountPer";
            this.txtDiscountPer.Size = new System.Drawing.Size(60, 20);
            this.txtDiscountPer.TabIndex = 524;
            this.txtDiscountPer.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAcc,
            this.ColDeb,
            this.ColCre});
            this.dataGridView1.Location = new System.Drawing.Point(776, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(95, 58);
            this.dataGridView1.TabIndex = 523;
            this.dataGridView1.Visible = false;
            // 
            // ColAcc
            // 
            this.ColAcc.HeaderText = "code";
            this.ColAcc.Name = "ColAcc";
            // 
            // ColDeb
            // 
            this.ColDeb.HeaderText = "Debit";
            this.ColDeb.Name = "ColDeb";
            // 
            // ColCre
            // 
            this.ColCre.HeaderText = "Credit";
            this.ColCre.Name = "ColCre";
            // 
            // lvAccounts
            // 
            this.lvAccounts.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvAccounts.BackgroundImageTiled = true;
            this.lvAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.lvAccounts.FullRowSelect = true;
            this.lvAccounts.GridLines = true;
            this.lvAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvAccounts.Location = new System.Drawing.Point(94, 97);
            this.lvAccounts.MultiSelect = false;
            this.lvAccounts.Name = "lvAccounts";
            this.lvAccounts.Size = new System.Drawing.Size(355, 173);
            this.lvAccounts.TabIndex = 35;
            this.lvAccounts.UseCompatibleStateImageBehavior = false;
            this.lvAccounts.View = System.Windows.Forms.View.Details;
            this.lvAccounts.Visible = false;
            this.lvAccounts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvAccounts_KeyDown);
            this.lvAccounts.Click += new System.EventHandler(this.lvAccounts_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 140;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(759, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 521;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbMaterialDetails
            // 
            this.gbMaterialDetails.Controls.Add(this.txtNarration);
            this.gbMaterialDetails.Controls.Add(this.btnOK);
            this.gbMaterialDetails.Controls.Add(this.label6);
            this.gbMaterialDetails.Controls.Add(this.label5);
            this.gbMaterialDetails.Controls.Add(this.label4);
            this.gbMaterialDetails.Controls.Add(this.label3);
            this.gbMaterialDetails.Controls.Add(this.txtVat);
            this.gbMaterialDetails.Controls.Add(this.txtExDuty);
            this.gbMaterialDetails.Controls.Add(this.txtDiscount);
            this.gbMaterialDetails.Controls.Add(this.txtTotalAmt);
            this.gbMaterialDetails.Controls.Add(this.label2);
            this.gbMaterialDetails.Controls.Add(this.txtInvoiceDate);
            this.gbMaterialDetails.Controls.Add(this.label1);
            this.gbMaterialDetails.Controls.Add(this.txtInvoiceNo);
            this.gbMaterialDetails.Controls.Add(this.lvMaterialDetail);
            this.gbMaterialDetails.Controls.Add(this.lblNarration);
            this.gbMaterialDetails.Location = new System.Drawing.Point(20, 305);
            this.gbMaterialDetails.Name = "gbMaterialDetails";
            this.gbMaterialDetails.Size = new System.Drawing.Size(384, 274);
            this.gbMaterialDetails.TabIndex = 520;
            this.gbMaterialDetails.TabStop = false;
            this.gbMaterialDetails.Text = "Material Details";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(313, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 23);
            this.btnOK.TabIndex = 528;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 527;
            this.label6.Text = "Vat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 527;
            this.label5.Text = "Ex Duty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 527;
            this.label4.Text = "Discount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 527;
            this.label3.Text = "Total Amount";
            // 
            // txtVat
            // 
            this.txtVat.Location = new System.Drawing.Point(155, 211);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(49, 20);
            this.txtVat.TabIndex = 526;
            // 
            // txtExDuty
            // 
            this.txtExDuty.Location = new System.Drawing.Point(84, 211);
            this.txtExDuty.Name = "txtExDuty";
            this.txtExDuty.Size = new System.Drawing.Size(52, 20);
            this.txtExDuty.TabIndex = 526;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(8, 211);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(57, 20);
            this.txtDiscount.TabIndex = 526;
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.Location = new System.Drawing.Point(304, 205);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.Size = new System.Drawing.Size(74, 20);
            this.txtTotalAmt.TabIndex = 526;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 512;
            this.label2.Text = "Invoice Date";
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.Location = new System.Drawing.Point(231, 23);
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Size = new System.Drawing.Size(78, 20);
            this.txtInvoiceDate.TabIndex = 511;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 512;
            this.label1.Text = "Invoice No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(77, 22);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(63, 20);
            this.txtInvoiceNo.TabIndex = 511;
            // 
            // lvMaterialDetail
            // 
            this.lvMaterialDetail.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvMaterialDetail.BackgroundImageTiled = true;
            this.lvMaterialDetail.CheckBoxes = true;
            this.lvMaterialDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader5,
            this.columnHeader7});
            this.lvMaterialDetail.FullRowSelect = true;
            this.lvMaterialDetail.GridLines = true;
            this.lvMaterialDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMaterialDetail.Location = new System.Drawing.Point(8, 51);
            this.lvMaterialDetail.MultiSelect = false;
            this.lvMaterialDetail.Name = "lvMaterialDetail";
            this.lvMaterialDetail.Size = new System.Drawing.Size(360, 141);
            this.lvMaterialDetail.TabIndex = 510;
            this.lvMaterialDetail.UseCompatibleStateImageBehavior = false;
            this.lvMaterialDetail.View = System.Windows.Forms.View.Details;
            this.lvMaterialDetail.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvMaterialDetail_ItemChecked);
            this.lvMaterialDetail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvMaterialDetail_MouseDown);
            this.lvMaterialDetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvMaterialDetail_KeyPress);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Material";
            this.columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Return Quantity";
            this.columnHeader12.Width = 90;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Rate";
            this.columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Amount";
            this.columnHeader14.Width = 85;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "MatCode";
            this.columnHeader5.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "AccCode";
            this.columnHeader7.Width = 40;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(592, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 519;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(506, 410);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 519;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.Red;
            this.txtMsg.ForeColor = System.Drawing.Color.Yellow;
            this.txtMsg.Location = new System.Drawing.Point(592, 450);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(279, 20);
            this.txtMsg.TabIndex = 518;
            // 
            // txtCreditTotal
            // 
            this.txtCreditTotal.Location = new System.Drawing.Point(517, 313);
            this.txtCreditTotal.Name = "txtCreditTotal";
            this.txtCreditTotal.ReadOnly = true;
            this.txtCreditTotal.Size = new System.Drawing.Size(96, 20);
            this.txtCreditTotal.TabIndex = 100;
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(93, 5);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(102, 20);
            this.txtVoucherNo.TabIndex = 1;
            this.txtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVoucherNo_KeyPress);
            // 
            // txtDebitTotal
            // 
            this.txtDebitTotal.Location = new System.Drawing.Point(421, 313);
            this.txtDebitTotal.Name = "txtDebitTotal";
            this.txtDebitTotal.ReadOnly = true;
            this.txtDebitTotal.Size = new System.Drawing.Size(90, 20);
            this.txtDebitTotal.TabIndex = 500;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.Location = new System.Drawing.Point(514, 298);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(34, 13);
            this.lblTotalCredit.TabIndex = 501;
            this.lblTotalCredit.Text = "Credit";
            // 
            // txtReturnQty
            // 
            this.txtReturnQty.Location = new System.Drawing.Point(421, 429);
            this.txtReturnQty.Name = "txtReturnQty";
            this.txtReturnQty.Size = new System.Drawing.Size(30, 20);
            this.txtReturnQty.TabIndex = 525;
            this.txtReturnQty.Visible = false;
            // 
            // lbltotalDebit
            // 
            this.lbltotalDebit.AutoSize = true;
            this.lbltotalDebit.Location = new System.Drawing.Point(418, 299);
            this.lbltotalDebit.Name = "lbltotalDebit";
            this.lbltotalDebit.Size = new System.Drawing.Size(32, 13);
            this.lbltotalDebit.TabIndex = 501;
            this.lbltotalDebit.Text = "Debit";
            // 
            // lblDebitNoteNo
            // 
            this.lblDebitNoteNo.AutoSize = true;
            this.lblDebitNoteNo.Location = new System.Drawing.Point(11, 8);
            this.lblDebitNoteNo.Name = "lblDebitNoteNo";
            this.lblDebitNoteNo.Size = new System.Drawing.Size(75, 13);
            this.lblDebitNoteNo.TabIndex = 0;
            this.lblDebitNoteNo.Text = "Debit Note No";
            // 
            // lblDebitNoteDate
            // 
            this.lblDebitNoteDate.AutoSize = true;
            this.lblDebitNoteDate.Location = new System.Drawing.Point(248, 12);
            this.lblDebitNoteDate.Name = "lblDebitNoteDate";
            this.lblDebitNoteDate.Size = new System.Drawing.Size(84, 13);
            this.lblDebitNoteDate.TabIndex = 0;
            this.lblDebitNoteDate.Text = "Debit Note Date";
            // 
            // dtpVoucherDate
            // 
            this.dtpVoucherDate.CustomFormat = "dd/MM/yyyy";
            this.dtpVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVoucherDate.Location = new System.Drawing.Point(345, 8);
            this.dtpVoucherDate.Name = "dtpVoucherDate";
            this.dtpVoucherDate.Size = new System.Drawing.Size(91, 20);
            this.dtpVoucherDate.TabIndex = 2;
            // 
            // txtHidAccCode
            // 
            this.txtHidAccCode.Location = new System.Drawing.Point(476, 8);
            this.txtHidAccCode.Name = "txtHidAccCode";
            this.txtHidAccCode.Size = new System.Drawing.Size(39, 20);
            this.txtHidAccCode.TabIndex = 507;
            this.txtHidAccCode.Visible = false;
            // 
            // dgvBankPaymentVoucher
            // 
            this.dgvBankPaymentVoucher.AllowUserToAddRows = false;
            this.dgvBankPaymentVoucher.AllowUserToResizeRows = false;
            this.dgvBankPaymentVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBankPaymentVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column5,
            this.Column8,
            this.Column10});
            this.dgvBankPaymentVoucher.Location = new System.Drawing.Point(48, 98);
            this.dgvBankPaymentVoucher.Name = "dgvBankPaymentVoucher";
            this.dgvBankPaymentVoucher.ReadOnly = true;
            this.dgvBankPaymentVoucher.RowHeadersVisible = false;
            this.dgvBankPaymentVoucher.Size = new System.Drawing.Size(765, 191);
            this.dgvBankPaymentVoucher.TabIndex = 200;
            this.dgvBankPaymentVoucher.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBankPaymentVoucher_CellDoubleClick);
            this.dgvBankPaymentVoucher.Click += new System.EventHandler(this.dgvBankPaymentVoucher_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(95, 74);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(159, 20);
            this.txtAccount.TabIndex = 5;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            this.txtAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccount_KeyDown);
            // 
            // cmbRefDocNo
            // 
            this.cmbRefDocNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRefDocNo.FormattingEnabled = true;
            this.cmbRefDocNo.Location = new System.Drawing.Point(349, 74);
            this.cmbRefDocNo.Name = "cmbRefDocNo";
            this.cmbRefDocNo.Size = new System.Drawing.Size(100, 21);
            this.cmbRefDocNo.TabIndex = 7;
            this.cmbRefDocNo.DropDownClosed += new System.EventHandler(this.cmbRefDocNo_DropDownClosed);
            this.cmbRefDocNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRefDocNo_KeyDown);
            // 
            // txtDebit
            // 
            this.txtDebit.Location = new System.Drawing.Point(453, 72);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(77, 20);
            this.txtDebit.TabIndex = 13;
            this.txtDebit.Visible = false;
            this.txtDebit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDebit_KeyDown);
            this.txtDebit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebit_KeyPress);
            // 
            // cmbRefDocDate
            // 
            this.cmbRefDocDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRefDocDate.FormattingEnabled = true;
            this.cmbRefDocDate.Location = new System.Drawing.Point(258, 73);
            this.cmbRefDocDate.Name = "cmbRefDocDate";
            this.cmbRefDocDate.Size = new System.Drawing.Size(89, 21);
            this.cmbRefDocDate.TabIndex = 6;
            this.cmbRefDocDate.DropDownClosed += new System.EventHandler(this.cmbRefDocDate_DropDownClosed);
            this.cmbRefDocDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRefDocDate_KeyDown);
            // 
            // txtCredit
            // 
            this.txtCredit.Location = new System.Drawing.Point(534, 72);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(79, 20);
            this.txtCredit.TabIndex = 14;
            this.txtCredit.Visible = false;
            this.txtCredit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCredit_KeyDown);
            this.txtCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredit_KeyPress);
            // 
            // txtCostCentre
            // 
            this.txtCostCentre.Location = new System.Drawing.Point(814, 72);
            this.txtCostCentre.Name = "txtCostCentre";
            this.txtCostCentre.Size = new System.Drawing.Size(40, 20);
            this.txtCostCentre.TabIndex = 17;
            this.txtCostCentre.Visible = false;
            this.txtCostCentre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostCentre_KeyDown);
            this.txtCostCentre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostCentre_KeyPress);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(101, 57);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(47, 13);
            this.lblAccount.TabIndex = 6;
            this.lblAccount.Text = "Account";
            // 
            // lblRefDocDate
            // 
            this.lblRefDocDate.AutoSize = true;
            this.lblRefDocDate.Location = new System.Drawing.Point(257, 58);
            this.lblRefDocDate.Name = "lblRefDocDate";
            this.lblRefDocDate.Size = new System.Drawing.Size(73, 13);
            this.lblRefDocDate.TabIndex = 6;
            this.lblRefDocDate.Text = "Ref.Doc.Date";
            // 
            // lblRefDocNo
            // 
            this.lblRefDocNo.AutoSize = true;
            this.lblRefDocNo.Location = new System.Drawing.Point(352, 58);
            this.lblRefDocNo.Name = "lblRefDocNo";
            this.lblRefDocNo.Size = new System.Drawing.Size(64, 13);
            this.lblRefDocNo.TabIndex = 6;
            this.lblRefDocNo.Text = "Ref.Doc.No";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(45, 246);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(50, 13);
            this.lblNarration.TabIndex = 6;
            this.lblNarration.Text = "Narration";
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.Location = new System.Drawing.Point(453, 56);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(32, 13);
            this.lblDebit.TabIndex = 6;
            this.lblDebit.Text = "Debit";
            this.lblDebit.Visible = false;
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Location = new System.Drawing.Point(536, 56);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(34, 13);
            this.lblCredit.TabIndex = 6;
            this.lblCredit.Text = "Credit";
            this.lblCredit.Visible = false;
            // 
            // lblCostCentre
            // 
            this.lblCostCentre.Location = new System.Drawing.Point(811, 39);
            this.lblCostCentre.Name = "lblCostCentre";
            this.lblCostCentre.Size = new System.Drawing.Size(39, 30);
            this.lblCostCentre.TabIndex = 6;
            this.lblCostCentre.Text = "Cost Centre";
            this.lblCostCentre.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(678, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHidEmpAcode
            // 
            this.txtHidEmpAcode.Location = new System.Drawing.Point(521, 8);
            this.txtHidEmpAcode.Name = "txtHidEmpAcode";
            this.txtHidEmpAcode.Size = new System.Drawing.Size(39, 20);
            this.txtHidEmpAcode.TabIndex = 508;
            this.txtHidEmpAcode.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvBankPayHD);
            this.tabPage2.Controls.Add(this.btnShow);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvBankPayHD
            // 
            this.dgvBankPayHD.AllowUserToAddRows = false;
            this.dgvBankPayHD.AllowUserToResizeColumns = false;
            this.dgvBankPayHD.AllowUserToResizeRows = false;
            this.dgvBankPayHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBankPayHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBankPayHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColVNo,
            this.ColDt,
            this.ColAmt});
            this.dgvBankPayHD.Location = new System.Drawing.Point(109, 105);
            this.dgvBankPayHD.Name = "dgvBankPayHD";
            this.dgvBankPayHD.ReadOnly = true;
            this.dgvBankPayHD.Size = new System.Drawing.Size(509, 181);
            this.dgvBankPayHD.TabIndex = 0;
            this.dgvBankPayHD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBankPayHD_CellDoubleClick);
            // 
            // ColVNo
            // 
            this.ColVNo.HeaderText = "Voucher No";
            this.ColVNo.Name = "ColVNo";
            this.ColVNo.ReadOnly = true;
            // 
            // ColDt
            // 
            this.ColDt.HeaderText = "Date";
            this.ColDt.Name = "ColDt";
            this.ColDt.ReadOnly = true;
            // 
            // ColAmt
            // 
            this.ColAmt.HeaderText = "Amount";
            this.ColAmt.Name = "ColAmt";
            this.ColAmt.ReadOnly = true;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(109, 64);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 516;
            this.label7.Text = "Mode";
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(435, 9);
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(43, 20);
            this.txtMode.TabIndex = 517;
            this.txtMode.Text = "New";
            this.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(101, 243);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(161, 20);
            this.txtNarration.TabIndex = 529;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Sl.No";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 45;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Account";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 158;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ref.Doc.Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 92;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ref.Doc.No";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 102;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Debit";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 85;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Credit";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 82;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Narration";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 195;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Cost Centre";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 60;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "acccode";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // frmDebitNote
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(963, 640);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "frmDebitNote";
            this.Text = "Debit Note";
            this.Load += new System.EventHandler(this.frmBankPaymentVoucher_Load);
            this.Shown += new System.EventHandler(this.frmBankPaymentVoucher_Shown);
            this.Click += new System.EventHandler(this.frmBankPaymentVoucher_Click);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbMaterialDetails.ResumeLayout(false);
            this.gbMaterialDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankPaymentVoucher)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBankPayHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvBankPayHD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmt;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvAccounts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbMaterialDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtHidEmpAcode;
        private System.Windows.Forms.TextBox txtCreditTotal;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.TextBox txtDebitTotal;
        private System.Windows.Forms.Label lblTotalCredit;
        private System.Windows.Forms.Label lbltotalDebit;
        private System.Windows.Forms.Label lblDebitNoteNo;
        private System.Windows.Forms.Label lblDebitNoteDate;
        private System.Windows.Forms.DateTimePicker dtpVoucherDate;
        private System.Windows.Forms.TextBox txtHidAccCode;
        private System.Windows.Forms.DataGridView dgvBankPaymentVoucher;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cmbRefDocNo;
        private System.Windows.Forms.TextBox txtDebit;
        private System.Windows.Forms.ComboBox cmbRefDocDate;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.TextBox txtCostCentre;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblRefDocDate;
        private System.Windows.Forms.Label lblRefDocNo;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label lblCostCentre;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.ListView lvMaterialDetail;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.TextBox txtExDuty;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox txtVatPer;
        private System.Windows.Forms.TextBox txtExPer;
        private System.Windows.Forms.TextBox txtDiscountPer;
        private System.Windows.Forms.TextBox txtReturnQty;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}