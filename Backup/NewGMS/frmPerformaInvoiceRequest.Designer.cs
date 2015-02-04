namespace NewGMS
{
    partial class frmPerformaInvoiceRequest
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
            this.dgvPRList = new System.Windows.Forms.DataGridView();
            this.dgvMList = new System.Windows.Forms.DataGridView();
            this.MatDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIReqQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPIReqQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPINotNeed = new System.Windows.Forms.Button();
            this.btnPINeed = new System.Windows.Forms.Button();
            this.btnSM = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.QtReqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PINeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNoOfMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFromSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCanModify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPRList
            // 
            this.dgvPRList.AllowUserToAddRows = false;
            this.dgvPRList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QtReqNo,
            this.SupplierName,
            this.supcode,
            this.ColRefNum,
            this.ColDt,
            this.PINeed,
            this.SupReceived,
            this.ColSubNum,
            this.ColNoOfMat,
            this.ColFromSource,
            this.ColCanModify});
            this.dgvPRList.Location = new System.Drawing.Point(11, 39);
            this.dgvPRList.Name = "dgvPRList";
            this.dgvPRList.RowHeadersWidth = 30;
            this.dgvPRList.Size = new System.Drawing.Size(612, 226);
            this.dgvPRList.TabIndex = 0;
            this.dgvPRList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRList_CellClick);
            // 
            // dgvMList
            // 
            this.dgvMList.AllowUserToAddRows = false;
            this.dgvMList.ColumnHeadersHeight = 33;
            this.dgvMList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatDesc,
            this.urate,
            this.PIReqQty,
            this.qr1,
            this.sp1,
            this.sn1,
            this.mc1,
            this.ColPIReqQty});
            this.dgvMList.Location = new System.Drawing.Point(638, 39);
            this.dgvMList.Name = "dgvMList";
            this.dgvMList.RowHeadersVisible = false;
            this.dgvMList.Size = new System.Drawing.Size(434, 226);
            this.dgvMList.TabIndex = 1;
            // 
            // MatDesc
            // 
            this.MatDesc.HeaderText = "MatDesc";
            this.MatDesc.Name = "MatDesc";
            this.MatDesc.ReadOnly = true;
            this.MatDesc.Width = 160;
            // 
            // urate
            // 
            this.urate.HeaderText = "Rate";
            this.urate.Name = "urate";
            this.urate.ReadOnly = true;
            this.urate.Width = 90;
            // 
            // PIReqQty
            // 
            this.PIReqQty.HeaderText = "Qty";
            this.PIReqQty.Name = "PIReqQty";
            this.PIReqQty.ReadOnly = true;
            this.PIReqQty.Width = 90;
            // 
            // qr1
            // 
            this.qr1.HeaderText = "qr1";
            this.qr1.Name = "qr1";
            this.qr1.ReadOnly = true;
            this.qr1.Visible = false;
            // 
            // sp1
            // 
            this.sp1.HeaderText = "sp1";
            this.sp1.Name = "sp1";
            this.sp1.ReadOnly = true;
            this.sp1.Visible = false;
            // 
            // sn1
            // 
            this.sn1.HeaderText = "sn1";
            this.sn1.Name = "sn1";
            this.sn1.ReadOnly = true;
            this.sn1.Visible = false;
            // 
            // mc1
            // 
            this.mc1.HeaderText = "mc1";
            this.mc1.Name = "mc1";
            this.mc1.Visible = false;
            // 
            // ColPIReqQty
            // 
            this.ColPIReqQty.HeaderText = "New Qty";
            this.ColPIReqQty.Name = "ColPIReqQty";
            this.ColPIReqQty.Width = 90;
            // 
            // btnPINotNeed
            // 
            this.btnPINotNeed.Location = new System.Drawing.Point(106, 23);
            this.btnPINotNeed.Name = "btnPINotNeed";
            this.btnPINotNeed.Size = new System.Drawing.Size(75, 23);
            this.btnPINotNeed.TabIndex = 2;
            this.btnPINotNeed.Text = "PI Not Need";
            this.btnPINotNeed.UseVisualStyleBackColor = true;
            this.btnPINotNeed.Click += new System.EventHandler(this.btnPINotNeed_Click);
            // 
            // btnPINeed
            // 
            this.btnPINeed.Location = new System.Drawing.Point(16, 23);
            this.btnPINeed.Name = "btnPINeed";
            this.btnPINeed.Size = new System.Drawing.Size(75, 23);
            this.btnPINeed.TabIndex = 3;
            this.btnPINeed.Text = "PI Need";
            this.btnPINeed.UseVisualStyleBackColor = true;
            this.btnPINeed.Click += new System.EventHandler(this.btnPINeed_Click);
            // 
            // btnSM
            // 
            this.btnSM.Location = new System.Drawing.Point(835, 302);
            this.btnSM.Name = "btnSM";
            this.btnSM.Size = new System.Drawing.Size(75, 23);
            this.btnSM.TabIndex = 5;
            this.btnSM.Text = "Send Mail";
            this.btnSM.UseVisualStyleBackColor = true;
            this.btnSM.Click += new System.EventHandler(this.btnSM_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPINeed);
            this.groupBox1.Controls.Add(this.btnPINotNeed);
            this.groupBox1.Location = new System.Drawing.Point(194, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // gbMessage
            // 
            this.gbMessage.Controls.Add(this.label1);
            this.gbMessage.Location = new System.Drawing.Point(482, 302);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(157, 26);
            this.gbMessage.TabIndex = 7;
            this.gbMessage.TabStop = false;
            this.gbMessage.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cannot Make Modification";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(933, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // QtReqNo
            // 
            this.QtReqNo.HeaderText = "Qt Req No";
            this.QtReqNo.Name = "QtReqNo";
            this.QtReqNo.ReadOnly = true;
            this.QtReqNo.Width = 70;
            // 
            // SupplierName
            // 
            this.SupplierName.HeaderText = "Supplier";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            this.SupplierName.Width = 140;
            // 
            // supcode
            // 
            this.supcode.HeaderText = "supcode";
            this.supcode.Name = "supcode";
            this.supcode.ReadOnly = true;
            this.supcode.Visible = false;
            // 
            // ColRefNum
            // 
            this.ColRefNum.HeaderText = "RefNo";
            this.ColRefNum.Name = "ColRefNum";
            // 
            // ColDt
            // 
            this.ColDt.HeaderText = "RefDate";
            this.ColDt.Name = "ColDt";
            // 
            // PINeed
            // 
            this.PINeed.HeaderText = "Is Need Performa";
            this.PINeed.Name = "PINeed";
            this.PINeed.ReadOnly = true;
            this.PINeed.Width = 85;
            // 
            // SupReceived
            // 
            this.SupReceived.HeaderText = "Supplier Received";
            this.SupReceived.Name = "SupReceived";
            this.SupReceived.ReadOnly = true;
            this.SupReceived.Width = 85;
            // 
            // ColSubNum
            // 
            this.ColSubNum.HeaderText = "SubNum";
            this.ColSubNum.Name = "ColSubNum";
            this.ColSubNum.Visible = false;
            // 
            // ColNoOfMat
            // 
            this.ColNoOfMat.HeaderText = "NoOfMat";
            this.ColNoOfMat.Name = "ColNoOfMat";
            this.ColNoOfMat.Visible = false;
            // 
            // ColFromSource
            // 
            this.ColFromSource.HeaderText = "FromSource";
            this.ColFromSource.Name = "ColFromSource";
            this.ColFromSource.Visible = false;
            // 
            // ColCanModify
            // 
            this.ColCanModify.HeaderText = "CanModify";
            this.ColCanModify.Name = "ColCanModify";
            // 
            // frmPerformaInvoiceRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 369);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSM);
            this.Controls.Add(this.dgvPRList);
            this.Controls.Add(this.dgvMList);
            this.Name = "frmPerformaInvoiceRequest";
            this.Text = "Performa Invoice Request";
            this.Load += new System.EventHandler(this.frmPerformaInvoiceRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gbMessage.ResumeLayout(false);
            this.gbMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPRList;
        private System.Windows.Forms.DataGridView dgvMList;
        private System.Windows.Forms.Button btnPINotNeed;
        private System.Windows.Forms.Button btnPINeed;
        private System.Windows.Forms.Button btnSM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn urate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIReqQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn qr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPIReqQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtReqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn supcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn PINeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNoOfMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFromSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCanModify;
    }
}