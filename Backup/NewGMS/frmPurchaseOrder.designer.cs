namespace NewGMS
{
    partial class frmPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseOrder));
            this.lblPoNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtPurchaseOrderNo = new System.Windows.Forms.TextBox();
            this.dtpPODate = new System.Windows.Forms.DateTimePicker();
            this.cmbSupplr = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MatInfo = new System.Windows.Forms.TabPage();
            this.grid1 = new FlexCell.Grid();
            this.cmbQtReqNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvAmt = new System.Windows.Forms.TextBox();
            this.txtReqNo = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.PrintInfo = new System.Windows.Forms.TabPage();
            this.lnllbldefcond = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtpayment = new System.Windows.Forms.TextBox();
            this.txtdelivery = new System.Windows.Forms.TextBox();
            this.txtref = new System.Windows.Forms.TextBox();
            this.lblpayment = new System.Windows.Forms.Label();
            this.lbldelivery = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.History = new System.Windows.Forms.TabPage();
            this.btnShow = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvPO = new System.Windows.Forms.DataGridView();
            this.pono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.podate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.MatInfo.SuspendLayout();
            this.PrintInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPoNo
            // 
            this.lblPoNo.AutoSize = true;
            this.lblPoNo.Location = new System.Drawing.Point(29, 92);
            this.lblPoNo.Name = "lblPoNo";
            this.lblPoNo.Size = new System.Drawing.Size(39, 13);
            this.lblPoNo.TabIndex = 0;
            this.lblPoNo.Text = "PO No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PO Date";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(29, 38);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(45, 13);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier";
            // 
            // txtPurchaseOrderNo
            // 
            this.txtPurchaseOrderNo.Location = new System.Drawing.Point(104, 92);
            this.txtPurchaseOrderNo.Name = "txtPurchaseOrderNo";
            this.txtPurchaseOrderNo.ReadOnly = true;
            this.txtPurchaseOrderNo.Size = new System.Drawing.Size(100, 20);
            this.txtPurchaseOrderNo.TabIndex = 1;
            // 
            // dtpPODate
            // 
            this.dtpPODate.CustomFormat = "dd/MM/yyyy";
            this.dtpPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPODate.Location = new System.Drawing.Point(367, 95);
            this.dtpPODate.Name = "dtpPODate";
            this.dtpPODate.Size = new System.Drawing.Size(90, 20);
            this.dtpPODate.TabIndex = 2;
            // 
            // cmbSupplr
            // 
            this.cmbSupplr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplr.FormattingEnabled = true;
            this.cmbSupplr.Location = new System.Drawing.Point(104, 35);
            this.cmbSupplr.Name = "cmbSupplr";
            this.cmbSupplr.Size = new System.Drawing.Size(121, 21);
            this.cmbSupplr.TabIndex = 4;
            this.cmbSupplr.SelectedIndexChanged += new System.EventHandler(this.cmbSupplr_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(867, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(661, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MatInfo);
            this.tabControl1.Controls.Add(this.PrintInfo);
            this.tabControl1.Controls.Add(this.History);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1230, 442);
            this.tabControl1.TabIndex = 46;
            // 
            // MatInfo
            // 
            this.MatInfo.Controls.Add(this.grid1);
            this.MatInfo.Controls.Add(this.cmbQtReqNo);
            this.MatInfo.Controls.Add(this.label5);
            this.MatInfo.Controls.Add(this.txtInvAmt);
            this.MatInfo.Controls.Add(this.lblSupplier);
            this.MatInfo.Controls.Add(this.cmbSupplr);
            this.MatInfo.Controls.Add(this.txtReqNo);
            this.MatInfo.Controls.Add(this.txtSupplier);
            this.MatInfo.Controls.Add(this.txtPurchaseOrderNo);
            this.MatInfo.Controls.Add(this.lblPoNo);
            this.MatInfo.Controls.Add(this.label2);
            this.MatInfo.Controls.Add(this.dtpPODate);
            this.MatInfo.Location = new System.Drawing.Point(4, 22);
            this.MatInfo.Name = "MatInfo";
            this.MatInfo.Padding = new System.Windows.Forms.Padding(3);
            this.MatInfo.Size = new System.Drawing.Size(1222, 416);
            this.MatInfo.TabIndex = 0;
            this.MatInfo.Text = "Material Entry";
            this.MatInfo.UseVisualStyleBackColor = true;
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 12;
            this.grid1.Location = new System.Drawing.Point(32, 131);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 1;
            this.grid1.Size = new System.Drawing.Size(1015, 173);
            this.grid1.TabIndex = 53;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.grid1_CellChange);
            // 
            // cmbQtReqNo
            // 
            this.cmbQtReqNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQtReqNo.FormattingEnabled = true;
            this.cmbQtReqNo.Location = new System.Drawing.Point(367, 35);
            this.cmbQtReqNo.Name = "cmbQtReqNo";
            this.cmbQtReqNo.Size = new System.Drawing.Size(176, 21);
            this.cmbQtReqNo.TabIndex = 50;
            this.cmbQtReqNo.SelectedIndexChanged += new System.EventHandler(this.cmbQtReqNo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Request No";
            // 
            // txtInvAmt
            // 
            this.txtInvAmt.Location = new System.Drawing.Point(774, 321);
            this.txtInvAmt.Name = "txtInvAmt";
            this.txtInvAmt.Size = new System.Drawing.Size(90, 20);
            this.txtInvAmt.TabIndex = 52;
            this.txtInvAmt.Text = "0.00";
            this.txtInvAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvAmt_KeyPress);
            // 
            // txtReqNo
            // 
            this.txtReqNo.Location = new System.Drawing.Point(367, 35);
            this.txtReqNo.Name = "txtReqNo";
            this.txtReqNo.ReadOnly = true;
            this.txtReqNo.Size = new System.Drawing.Size(176, 20);
            this.txtReqNo.TabIndex = 1;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(104, 36);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(121, 20);
            this.txtSupplier.TabIndex = 1;
            // 
            // PrintInfo
            // 
            this.PrintInfo.Controls.Add(this.lnllbldefcond);
            this.PrintInfo.Controls.Add(this.groupBox2);
            this.PrintInfo.Controls.Add(this.groupBox1);
            this.PrintInfo.Location = new System.Drawing.Point(4, 22);
            this.PrintInfo.Name = "PrintInfo";
            this.PrintInfo.Size = new System.Drawing.Size(1222, 416);
            this.PrintInfo.TabIndex = 2;
            this.PrintInfo.Text = "Print Info";
            this.PrintInfo.UseVisualStyleBackColor = true;
            this.PrintInfo.Click += new System.EventHandler(this.PrintInfo_Click);
            // 
            // lnllbldefcond
            // 
            this.lnllbldefcond.AutoSize = true;
            this.lnllbldefcond.Location = new System.Drawing.Point(762, 366);
            this.lnllbldefcond.Name = "lnllbldefcond";
            this.lnllbldefcond.Size = new System.Drawing.Size(120, 13);
            this.lnllbldefcond.TabIndex = 35;
            this.lnllbldefcond.TabStop = true;
            this.lnllbldefcond.Text = "Load Default Conditions";
            this.lnllbldefcond.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnllbldefcond_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(378, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 314);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conditions";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(533, 246);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtpayment);
            this.groupBox1.Controls.Add(this.txtdelivery);
            this.groupBox1.Controls.Add(this.txtref);
            this.groupBox1.Controls.Add(this.lblpayment);
            this.groupBox1.Controls.Add(this.lbldelivery);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 314);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtpayment
            // 
            this.txtpayment.Location = new System.Drawing.Point(109, 243);
            this.txtpayment.Multiline = true;
            this.txtpayment.Name = "txtpayment";
            this.txtpayment.Size = new System.Drawing.Size(209, 57);
            this.txtpayment.TabIndex = 3;
            // 
            // txtdelivery
            // 
            this.txtdelivery.Location = new System.Drawing.Point(109, 141);
            this.txtdelivery.Multiline = true;
            this.txtdelivery.Name = "txtdelivery";
            this.txtdelivery.Size = new System.Drawing.Size(209, 57);
            this.txtdelivery.TabIndex = 2;
            // 
            // txtref
            // 
            this.txtref.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtref.Location = new System.Drawing.Point(109, 34);
            this.txtref.Multiline = true;
            this.txtref.Name = "txtref";
            this.txtref.Size = new System.Drawing.Size(209, 72);
            this.txtref.TabIndex = 1;
            // 
            // lblpayment
            // 
            this.lblpayment.AutoSize = true;
            this.lblpayment.Location = new System.Drawing.Point(23, 255);
            this.lblpayment.Name = "lblpayment";
            this.lblpayment.Size = new System.Drawing.Size(47, 13);
            this.lblpayment.TabIndex = 19;
            this.lblpayment.Text = "payment";
            // 
            // lbldelivery
            // 
            this.lbldelivery.AutoSize = true;
            this.lbldelivery.Location = new System.Drawing.Point(23, 158);
            this.lbldelivery.Name = "lbldelivery";
            this.lbldelivery.Size = new System.Drawing.Size(45, 13);
            this.lbldelivery.TabIndex = 18;
            this.lbldelivery.Text = "Delivery";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Our_Reference";
            // 
            // History
            // 
            this.History.Controls.Add(this.btnShow);
            this.History.Controls.Add(this.textBox1);
            this.History.Controls.Add(this.dgvPO);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(1222, 416);
            this.History.TabIndex = 1;
            this.History.Text = "Histroy";
            this.History.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(6, 22);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 54;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1102, 322);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 20);
            this.textBox1.TabIndex = 53;
            // 
            // dgvPO
            // 
            this.dgvPO.AllowUserToAddRows = false;
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pono,
            this.podate,
            this.supnm,
            this.supcod,
            this.poamt,
            this.qtnum});
            this.dgvPO.Location = new System.Drawing.Point(6, 51);
            this.dgvPO.Name = "dgvPO";
            this.dgvPO.ReadOnly = true;
            this.dgvPO.Size = new System.Drawing.Size(577, 265);
            this.dgvPO.TabIndex = 0;
            this.dgvPO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPO_CellDoubleClick);
            // 
            // pono
            // 
            this.pono.HeaderText = "pono";
            this.pono.Name = "pono";
            this.pono.ReadOnly = true;
            // 
            // podate
            // 
            this.podate.HeaderText = "poDate";
            this.podate.Name = "podate";
            this.podate.ReadOnly = true;
            // 
            // supnm
            // 
            this.supnm.HeaderText = "Supplier Name";
            this.supnm.Name = "supnm";
            this.supnm.ReadOnly = true;
            // 
            // supcod
            // 
            this.supcod.HeaderText = "supcod";
            this.supcod.Name = "supcod";
            this.supcod.ReadOnly = true;
            this.supcod.Visible = false;
            // 
            // poamt
            // 
            this.poamt.HeaderText = "po Amount";
            this.poamt.Name = "poamt";
            this.poamt.ReadOnly = true;
            // 
            // qtnum
            // 
            this.qtnum.HeaderText = "QtReqNo";
            this.qtnum.Name = "qtnum";
            this.qtnum.ReadOnly = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(764, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 553);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmPurchaseOrder";
            this.Text = "PurchaseOrder";
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.tabControl1.ResumeLayout(false);
            this.MatInfo.ResumeLayout(false);
            this.MatInfo.PerformLayout();
            this.PrintInfo.ResumeLayout(false);
            this.PrintInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.History.ResumeLayout(false);
            this.History.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPoNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtPurchaseOrderNo;
        private System.Windows.Forms.DateTimePicker dtpPODate;
        private System.Windows.Forms.ComboBox cmbSupplr;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MatInfo;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbQtReqNo;
        private System.Windows.Forms.TextBox txtInvAmt;
        private System.Windows.Forms.DataGridView dgvPO;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TabPage PrintInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtpayment;
        private System.Windows.Forms.TextBox txtdelivery;
        private System.Windows.Forms.TextBox txtref;
        private System.Windows.Forms.Label lblpayment;
        private System.Windows.Forms.Label lbldelivery;
        private System.Windows.Forms.Label label6;
        private FlexCell.Grid grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pono;
        private System.Windows.Forms.DataGridViewTextBoxColumn podate;
        private System.Windows.Forms.DataGridViewTextBoxColumn supnm;
        private System.Windows.Forms.DataGridViewTextBoxColumn supcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn poamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtnum;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtReqNo;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.LinkLabel lnllbldefcond;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}