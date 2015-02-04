namespace NewGMS
{
    partial class frmMaterialIssue
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialIssue));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabEntry = new System.Windows.Forms.TabPage();
            this.gridEntry = new FlexCell.Grid();
            this.txtMatReqNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMatReq = new System.Windows.Forms.ComboBox();
            this.dtpIssue = new System.Windows.Forms.DateTimePicker();
            this.txtIssueNo = new System.Windows.Forms.TextBox();
            this.tabIssueHistory = new System.Windows.Forms.TabPage();
            this.btnShowIssHistory = new System.Windows.Forms.Button();
            this.gridIssueHistoryDTL = new FlexCell.Grid();
            this.gridIssueHistoryHD = new FlexCell.Grid();
            this.tabRequestHistory = new System.Windows.Forms.TabPage();
            this.txtDisplayMatReqNo = new System.Windows.Forms.TextBox();
            this.chbMreq = new System.Windows.Forms.CheckBox();
            this.btnShowReq = new System.Windows.Forms.Button();
            this.gridReqHisIssDetails = new FlexCell.Grid();
            this.gridReqHisIssSum = new FlexCell.Grid();
            this.gridReqHisMatDTL = new FlexCell.Grid();
            this.gridReqHisHD = new FlexCell.Grid();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain.SuspendLayout();
            this.tabEntry.SuspendLayout();
            this.tabIssueHistory.SuspendLayout();
            this.tabRequestHistory.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabEntry);
            this.tabMain.Controls.Add(this.tabIssueHistory);
            this.tabMain.Controls.Add(this.tabRequestHistory);
            this.tabMain.Location = new System.Drawing.Point(12, 26);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1136, 443);
            this.tabMain.TabIndex = 0;
            this.tabMain.Click += new System.EventHandler(this.tabMain_Click);
            // 
            // tabEntry
            // 
            this.tabEntry.Controls.Add(this.gridEntry);
            this.tabEntry.Controls.Add(this.txtMatReqNo);
            this.tabEntry.Controls.Add(this.label3);
            this.tabEntry.Controls.Add(this.label2);
            this.tabEntry.Controls.Add(this.label1);
            this.tabEntry.Controls.Add(this.cmbMatReq);
            this.tabEntry.Controls.Add(this.dtpIssue);
            this.tabEntry.Controls.Add(this.txtIssueNo);
            this.tabEntry.Location = new System.Drawing.Point(4, 22);
            this.tabEntry.Name = "tabEntry";
            this.tabEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntry.Size = new System.Drawing.Size(1128, 417);
            this.tabEntry.TabIndex = 0;
            this.tabEntry.Text = "Entry";
            this.tabEntry.UseVisualStyleBackColor = true;
            this.tabEntry.Click += new System.EventHandler(this.tabEntry_Click);
            // 
            // gridEntry
            // 
            this.gridEntry.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridEntry.CheckedImage")));
            this.gridEntry.Cols = 11;
            this.gridEntry.Location = new System.Drawing.Point(27, 64);
            this.gridEntry.Name = "gridEntry";
            this.gridEntry.Size = new System.Drawing.Size(871, 283);
            this.gridEntry.TabIndex = 6;
            this.gridEntry.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridEntry.UncheckedImage")));
            this.gridEntry.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.gridEntry_CellChange);
            // 
            // txtMatReqNo
            // 
            this.txtMatReqNo.Location = new System.Drawing.Point(788, 24);
            this.txtMatReqNo.Name = "txtMatReqNo";
            this.txtMatReqNo.ReadOnly = true;
            this.txtMatReqNo.Size = new System.Drawing.Size(100, 20);
            this.txtMatReqNo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(655, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Material Request No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Issue Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Issue No.";
            // 
            // cmbMatReq
            // 
            this.cmbMatReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatReq.FormattingEnabled = true;
            this.cmbMatReq.Location = new System.Drawing.Point(787, 24);
            this.cmbMatReq.Name = "cmbMatReq";
            this.cmbMatReq.Size = new System.Drawing.Size(100, 21);
            this.cmbMatReq.TabIndex = 2;
            this.cmbMatReq.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtpIssue
            // 
            this.dtpIssue.CustomFormat = "dd/MM/yyyy";
            this.dtpIssue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssue.Location = new System.Drawing.Point(381, 28);
            this.dtpIssue.Name = "dtpIssue";
            this.dtpIssue.Size = new System.Drawing.Size(123, 20);
            this.dtpIssue.TabIndex = 1;
            // 
            // txtIssueNo
            // 
            this.txtIssueNo.Location = new System.Drawing.Point(95, 28);
            this.txtIssueNo.Name = "txtIssueNo";
            this.txtIssueNo.ReadOnly = true;
            this.txtIssueNo.Size = new System.Drawing.Size(100, 20);
            this.txtIssueNo.TabIndex = 0;
            // 
            // tabIssueHistory
            // 
            this.tabIssueHistory.Controls.Add(this.btnShowIssHistory);
            this.tabIssueHistory.Controls.Add(this.gridIssueHistoryDTL);
            this.tabIssueHistory.Controls.Add(this.gridIssueHistoryHD);
            this.tabIssueHistory.Location = new System.Drawing.Point(4, 22);
            this.tabIssueHistory.Name = "tabIssueHistory";
            this.tabIssueHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabIssueHistory.Size = new System.Drawing.Size(1128, 417);
            this.tabIssueHistory.TabIndex = 1;
            this.tabIssueHistory.Text = "Issue History";
            this.tabIssueHistory.UseVisualStyleBackColor = true;
            // 
            // btnShowIssHistory
            // 
            this.btnShowIssHistory.Location = new System.Drawing.Point(19, 16);
            this.btnShowIssHistory.Name = "btnShowIssHistory";
            this.btnShowIssHistory.Size = new System.Drawing.Size(75, 23);
            this.btnShowIssHistory.TabIndex = 2;
            this.btnShowIssHistory.Text = "Show";
            this.btnShowIssHistory.UseVisualStyleBackColor = true;
            this.btnShowIssHistory.Click += new System.EventHandler(this.btnShowIssHistory_Click);
            // 
            // gridIssueHistoryDTL
            // 
            this.gridIssueHistoryDTL.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridIssueHistoryDTL.CheckedImage")));
            this.gridIssueHistoryDTL.Cols = 4;
            this.gridIssueHistoryDTL.Location = new System.Drawing.Point(677, 45);
            this.gridIssueHistoryDTL.Name = "gridIssueHistoryDTL";
            this.gridIssueHistoryDTL.Size = new System.Drawing.Size(432, 352);
            this.gridIssueHistoryDTL.TabIndex = 1;
            this.gridIssueHistoryDTL.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridIssueHistoryDTL.UncheckedImage")));
            // 
            // gridIssueHistoryHD
            // 
            this.gridIssueHistoryHD.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridIssueHistoryHD.CheckedImage")));
            this.gridIssueHistoryHD.Cols = 8;
            this.gridIssueHistoryHD.Location = new System.Drawing.Point(19, 45);
            this.gridIssueHistoryHD.Name = "gridIssueHistoryHD";
            this.gridIssueHistoryHD.Size = new System.Drawing.Size(633, 219);
            this.gridIssueHistoryHD.TabIndex = 0;
            this.gridIssueHistoryHD.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridIssueHistoryHD.UncheckedImage")));
            this.gridIssueHistoryHD.MouseDown += new FlexCell.Grid.MouseDownEventHandler(this.gridIssueHistoryHD_MouseDown);
            this.gridIssueHistoryHD.HyperLinkClick += new FlexCell.Grid.HyperLinkClickEventHandler(this.gridIssueHistoryHD_HyperLinkClick);
            // 
            // tabRequestHistory
            // 
            this.tabRequestHistory.Controls.Add(this.txtDisplayMatReqNo);
            this.tabRequestHistory.Controls.Add(this.chbMreq);
            this.tabRequestHistory.Controls.Add(this.btnShowReq);
            this.tabRequestHistory.Controls.Add(this.gridReqHisIssDetails);
            this.tabRequestHistory.Controls.Add(this.gridReqHisIssSum);
            this.tabRequestHistory.Controls.Add(this.gridReqHisMatDTL);
            this.tabRequestHistory.Controls.Add(this.gridReqHisHD);
            this.tabRequestHistory.Location = new System.Drawing.Point(4, 22);
            this.tabRequestHistory.Name = "tabRequestHistory";
            this.tabRequestHistory.Size = new System.Drawing.Size(1128, 417);
            this.tabRequestHistory.TabIndex = 2;
            this.tabRequestHistory.Text = "Request History";
            this.tabRequestHistory.UseVisualStyleBackColor = true;
            // 
            // txtDisplayMatReqNo
            // 
            this.txtDisplayMatReqNo.Location = new System.Drawing.Point(147, 11);
            this.txtDisplayMatReqNo.Name = "txtDisplayMatReqNo";
            this.txtDisplayMatReqNo.ReadOnly = true;
            this.txtDisplayMatReqNo.Size = new System.Drawing.Size(100, 20);
            this.txtDisplayMatReqNo.TabIndex = 6;
            // 
            // chbMreq
            // 
            this.chbMreq.AutoSize = true;
            this.chbMreq.Location = new System.Drawing.Point(294, 15);
            this.chbMreq.Name = "chbMreq";
            this.chbMreq.Size = new System.Drawing.Size(227, 17);
            this.chbMreq.TabIndex = 5;
            this.chbMreq.Text = "Link to Material Request No.  in New Entry";
            this.chbMreq.UseVisualStyleBackColor = true;
            // 
            // btnShowReq
            // 
            this.btnShowReq.Location = new System.Drawing.Point(4, 11);
            this.btnShowReq.Name = "btnShowReq";
            this.btnShowReq.Size = new System.Drawing.Size(75, 23);
            this.btnShowReq.TabIndex = 4;
            this.btnShowReq.Text = "Show";
            this.btnShowReq.UseVisualStyleBackColor = true;
            this.btnShowReq.Click += new System.EventHandler(this.btnShowReq_Click);
            // 
            // gridReqHisIssDetails
            // 
            this.gridReqHisIssDetails.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisIssDetails.CheckedImage")));
            this.gridReqHisIssDetails.Cols = 4;
            this.gridReqHisIssDetails.Location = new System.Drawing.Point(628, 173);
            this.gridReqHisIssDetails.Name = "gridReqHisIssDetails";
            this.gridReqHisIssDetails.Size = new System.Drawing.Size(477, 208);
            this.gridReqHisIssDetails.TabIndex = 3;
            this.gridReqHisIssDetails.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisIssDetails.UncheckedImage")));
            // 
            // gridReqHisIssSum
            // 
            this.gridReqHisIssSum.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisIssSum.CheckedImage")));
            this.gridReqHisIssSum.Cols = 4;
            this.gridReqHisIssSum.Location = new System.Drawing.Point(628, 40);
            this.gridReqHisIssSum.Name = "gridReqHisIssSum";
            this.gridReqHisIssSum.Size = new System.Drawing.Size(319, 127);
            this.gridReqHisIssSum.TabIndex = 2;
            this.gridReqHisIssSum.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisIssSum.UncheckedImage")));
            // 
            // gridReqHisMatDTL
            // 
            this.gridReqHisMatDTL.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisMatDTL.CheckedImage")));
            this.gridReqHisMatDTL.Location = new System.Drawing.Point(3, 206);
            this.gridReqHisMatDTL.Name = "gridReqHisMatDTL";
            this.gridReqHisMatDTL.Size = new System.Drawing.Size(589, 175);
            this.gridReqHisMatDTL.TabIndex = 1;
            this.gridReqHisMatDTL.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisMatDTL.UncheckedImage")));
            // 
            // gridReqHisHD
            // 
            this.gridReqHisHD.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisHD.CheckedImage")));
            this.gridReqHisHD.Cols = 5;
            this.gridReqHisHD.Location = new System.Drawing.Point(3, 40);
            this.gridReqHisHD.Name = "gridReqHisHD";
            this.gridReqHisHD.Size = new System.Drawing.Size(589, 160);
            this.gridReqHisHD.TabIndex = 0;
            this.gridReqHisHD.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridReqHisHD.UncheckedImage")));
            this.gridReqHisHD.HyperLinkClick += new FlexCell.Grid.HyperLinkClickEventHandler(this.gridReqHisHD_HyperLinkClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(394, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(501, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(620, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RowToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 114);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // RowToolStripMenuItem
            // 
            this.RowToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RowToolStripMenuItem.Name = "RowToolStripMenuItem";
            this.RowToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem1.Text = "New";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem2.Text = "Edit";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem3.Text = "Delete";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem4.Text = "Cancel";
            // 
            // frmMaterialIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 533);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMaterialIssue";
            this.Text = "frmMaterialIssue";
            this.Load += new System.EventHandler(this.frmMaterialIssue_Load);
            this.tabMain.ResumeLayout(false);
            this.tabEntry.ResumeLayout(false);
            this.tabEntry.PerformLayout();
            this.tabIssueHistory.ResumeLayout(false);
            this.tabRequestHistory.ResumeLayout(false);
            this.tabRequestHistory.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabEntry;
        private System.Windows.Forms.TabPage tabIssueHistory;
        private System.Windows.Forms.TabPage tabRequestHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMatReq;
        private System.Windows.Forms.DateTimePicker dtpIssue;
        private System.Windows.Forms.TextBox txtIssueNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private FlexCell.Grid gridEntry;
        private FlexCell.Grid gridIssueHistoryDTL;
        private FlexCell.Grid gridIssueHistoryHD;
        private System.Windows.Forms.Button btnShowIssHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem RowToolStripMenuItem;
        private System.Windows.Forms.TextBox txtMatReqNo;
        private FlexCell.Grid gridReqHisMatDTL;
        private FlexCell.Grid gridReqHisHD;
        private FlexCell.Grid gridReqHisIssDetails;
        private FlexCell.Grid gridReqHisIssSum;
        private System.Windows.Forms.Button btnShowReq;
        private System.Windows.Forms.CheckBox chbMreq;
        private System.Windows.Forms.TextBox txtDisplayMatReqNo;

    }
}