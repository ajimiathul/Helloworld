namespace NewGMS
{
    partial class frmMaterialRequestApproval
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
            this.dgvMatReq = new System.Windows.Forms.DataGridView();
            this.ColMatReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatReqDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSanction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSupSendStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.ColItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOthersStatus = new System.Windows.Forms.DataGridView();
            this.ColManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColManStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOthersStatusDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOthersRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMatReqNo = new System.Windows.Forms.TextBox();
            this.lblMatReqNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnRejection = new System.Windows.Forms.Button();
            this.btnApproval = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOthersStatus)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMatReq
            // 
            this.dgvMatReq.AllowUserToAddRows = false;
            this.dgvMatReq.AllowUserToResizeRows = false;
            this.dgvMatReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatReq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMatReq,
            this.colMatReqDt,
            this.ColSanction,
            this.ColSupSendStatus});
            this.dgvMatReq.Location = new System.Drawing.Point(33, 46);
            this.dgvMatReq.Name = "dgvMatReq";
            this.dgvMatReq.ReadOnly = true;
            this.dgvMatReq.RowHeadersWidth = 30;
            this.dgvMatReq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMatReq.Size = new System.Drawing.Size(303, 349);
            this.dgvMatReq.TabIndex = 0;
            this.dgvMatReq.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatReq_CellClick);
            // 
            // ColMatReq
            // 
            this.ColMatReq.FillWeight = 121.8274F;
            this.ColMatReq.HeaderText = "Material Req No";
            this.ColMatReq.Name = "ColMatReq";
            this.ColMatReq.ReadOnly = true;
            this.ColMatReq.Width = 60;
            // 
            // colMatReqDt
            // 
            this.colMatReqDt.FillWeight = 92.7242F;
            this.colMatReqDt.HeaderText = "Date";
            this.colMatReqDt.Name = "colMatReqDt";
            this.colMatReqDt.ReadOnly = true;
            this.colMatReqDt.Width = 85;
            // 
            // ColSanction
            // 
            this.ColSanction.FillWeight = 92.7242F;
            this.ColSanction.HeaderText = "Sanction Status";
            this.ColSanction.Name = "ColSanction";
            this.ColSanction.ReadOnly = true;
            this.ColSanction.Width = 55;
            // 
            // ColSupSendStatus
            // 
            this.ColSupSendStatus.FillWeight = 92.7242F;
            this.ColSupSendStatus.HeaderText = "Supplier Send Status";
            this.ColSupSendStatus.Name = "ColSupSendStatus";
            this.ColSupSendStatus.ReadOnly = true;
            this.ColSupSendStatus.Width = 55;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColItems,
            this.ColRate,
            this.ColQty});
            this.dgvItems.Location = new System.Drawing.Point(405, 71);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvItems.Size = new System.Drawing.Size(439, 138);
            this.dgvItems.TabIndex = 1;
            // 
            // ColItems
            // 
            this.ColItems.HeaderText = "Items";
            this.ColItems.Name = "ColItems";
            this.ColItems.ReadOnly = true;
            // 
            // ColRate
            // 
            this.ColRate.HeaderText = "Rate";
            this.ColRate.Name = "ColRate";
            this.ColRate.ReadOnly = true;
            // 
            // ColQty
            // 
            this.ColQty.HeaderText = "Qty";
            this.ColQty.Name = "ColQty";
            this.ColQty.ReadOnly = true;
            // 
            // dgvOthersStatus
            // 
            this.dgvOthersStatus.AllowUserToAddRows = false;
            this.dgvOthersStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOthersStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColManager,
            this.ColManStatus,
            this.ColOthersStatusDt,
            this.ColOthersRemarks});
            this.dgvOthersStatus.Location = new System.Drawing.Point(405, 259);
            this.dgvOthersStatus.Name = "dgvOthersStatus";
            this.dgvOthersStatus.ReadOnly = true;
            this.dgvOthersStatus.RowHeadersVisible = false;
            this.dgvOthersStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOthersStatus.Size = new System.Drawing.Size(439, 136);
            this.dgvOthersStatus.TabIndex = 1;
            // 
            // ColManager
            // 
            this.ColManager.HeaderText = "ManagerName";
            this.ColManager.Name = "ColManager";
            this.ColManager.ReadOnly = true;
            this.ColManager.Width = 129;
            // 
            // ColManStatus
            // 
            this.ColManStatus.HeaderText = "ManagerStatus";
            this.ColManStatus.Name = "ColManStatus";
            this.ColManStatus.ReadOnly = true;
            this.ColManStatus.Width = 86;
            // 
            // ColOthersStatusDt
            // 
            this.ColOthersStatusDt.HeaderText = "Date";
            this.ColOthersStatusDt.Name = "ColOthersStatusDt";
            this.ColOthersStatusDt.ReadOnly = true;
            this.ColOthersStatusDt.Width = 115;
            // 
            // ColOthersRemarks
            // 
            this.ColOthersRemarks.HeaderText = "Remarks";
            this.ColOthersRemarks.Name = "ColOthersRemarks";
            this.ColOthersRemarks.ReadOnly = true;
            this.ColOthersRemarks.Width = 109;
            // 
            // txtMatReqNo
            // 
            this.txtMatReqNo.Location = new System.Drawing.Point(611, 19);
            this.txtMatReqNo.Name = "txtMatReqNo";
            this.txtMatReqNo.ReadOnly = true;
            this.txtMatReqNo.Size = new System.Drawing.Size(58, 20);
            this.txtMatReqNo.TabIndex = 10;
            this.txtMatReqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMatReqNo
            // 
            this.lblMatReqNo.AutoSize = true;
            this.lblMatReqNo.Location = new System.Drawing.Point(493, 22);
            this.lblMatReqNo.Name = "lblMatReqNo";
            this.lblMatReqNo.Size = new System.Drawing.Size(116, 13);
            this.lblMatReqNo.TabIndex = 9;
            this.lblMatReqNo.Text = "Material Requisition No";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(256, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPending
            // 
            this.btnPending.Location = new System.Drawing.Point(179, 21);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(75, 23);
            this.btnPending.TabIndex = 5;
            this.btnPending.Text = "Pending";
            this.btnPending.UseVisualStyleBackColor = true;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnRejection
            // 
            this.btnRejection.Location = new System.Drawing.Point(98, 21);
            this.btnRejection.Name = "btnRejection";
            this.btnRejection.Size = new System.Drawing.Size(75, 23);
            this.btnRejection.TabIndex = 6;
            this.btnRejection.Text = "Reject";
            this.btnRejection.UseVisualStyleBackColor = true;
            this.btnRejection.Click += new System.EventHandler(this.btnRejection_Click);
            // 
            // btnApproval
            // 
            this.btnApproval.Location = new System.Drawing.Point(17, 21);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(75, 23);
            this.btnApproval.TabIndex = 7;
            this.btnApproval.Text = "Approve";
            this.btnApproval.UseVisualStyleBackColor = true;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(386, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 172);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details ";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(17, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 389);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Material Request ";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(386, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 172);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Others Status ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtRemarks);
            this.groupBox4.Controls.Add(this.btnApproval);
            this.groupBox4.Controls.Add(this.btnPending);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.btnRejection);
            this.groupBox4.Location = new System.Drawing.Point(879, 109);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 137);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(17, 102);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(305, 20);
            this.txtRemarks.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Remarks";
            // 
            // frmMaterialRequestApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 426);
            this.Controls.Add(this.lblMatReqNo);
            this.Controls.Add(this.txtMatReqNo);
            this.Controls.Add(this.dgvOthersStatus);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.dgvMatReq);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "frmMaterialRequestApproval";
            this.Text = "frmMaterialRequestApproval";
            this.Load += new System.EventHandler(this.frmMaterialRequestApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOthersStatus)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMatReq;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridView dgvOthersStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.TextBox txtMatReqNo;
        private System.Windows.Forms.Label lblMatReqNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnRejection;
        private System.Windows.Forms.Button btnApproval;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMatReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatReqDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSanction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSupSendStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColManStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOthersStatusDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOthersRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
    }
}