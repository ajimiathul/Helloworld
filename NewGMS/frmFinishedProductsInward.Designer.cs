namespace NewGMS
{
    partial class frmFinishedProductsInward
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinishedProductsInward));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Entry = new System.Windows.Forms.TabPage();
            this.grid1 = new FlexCell.Grid();
            this.History = new System.Windows.Forms.TabPage();
            this.btnShowInward = new System.Windows.Forms.Button();
            this.dgvInward = new System.Windows.Forms.DataGridView();
            this.Editinward = new System.Windows.Forms.TabPage();
            this.btshow = new System.Windows.Forms.Button();
            this.fgridedit = new FlexCell.Grid();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.btnclose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Entry.SuspendLayout();
            this.History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInward)).BeginInit();
            this.Editinward.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Entry);
            this.tabControl1.Controls.Add(this.History);
            this.tabControl1.Controls.Add(this.Editinward);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1255, 541);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // Entry
            // 
            this.Entry.Controls.Add(this.grid1);
            this.Entry.Location = new System.Drawing.Point(4, 22);
            this.Entry.Name = "Entry";
            this.Entry.Padding = new System.Windows.Forms.Padding(3);
            this.Entry.Size = new System.Drawing.Size(1247, 515);
            this.Entry.TabIndex = 0;
            this.Entry.Text = "Entry";
            this.Entry.UseVisualStyleBackColor = true;
            this.Entry.Click += new System.EventHandler(this.Entry_Click);
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 19;
            this.grid1.Location = new System.Drawing.Point(6, 28);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 1;
            this.grid1.Size = new System.Drawing.Size(1205, 341);
            this.grid1.TabIndex = 37;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.ComboClick += new FlexCell.Grid.ComboClickEventHandler(this.grid1_ComboClick);
            this.grid1.LeaveCell += new FlexCell.Grid.LeaveCellEventHandler(this.grid1_LeaveCell);
            this.grid1.HyperLinkClick += new FlexCell.Grid.HyperLinkClickEventHandler(this.grid1_HyperLinkClick);
            this.grid1.LeaveRow += new FlexCell.Grid.LeaveRowEventHandler(this.grid1_LeaveRow);
            this.grid1.KeyDown += new FlexCell.Grid.KeyDownEventHandler(this.grid1_KeyDown);
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // History
            // 
            this.History.Controls.Add(this.btnShowInward);
            this.History.Controls.Add(this.dgvInward);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(1247, 515);
            this.History.TabIndex = 1;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = true;
            // 
            // btnShowInward
            // 
            this.btnShowInward.Location = new System.Drawing.Point(6, 37);
            this.btnShowInward.Name = "btnShowInward";
            this.btnShowInward.Size = new System.Drawing.Size(75, 23);
            this.btnShowInward.TabIndex = 30;
            this.btnShowInward.Text = "Show";
            this.btnShowInward.UseVisualStyleBackColor = true;
            this.btnShowInward.Click += new System.EventHandler(this.btnShowInward_Click);
            // 
            // dgvInward
            // 
            this.dgvInward.AllowUserToAddRows = false;
            this.dgvInward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInward.Location = new System.Drawing.Point(15, 66);
            this.dgvInward.Name = "dgvInward";
            this.dgvInward.Size = new System.Drawing.Size(1188, 319);
            this.dgvInward.TabIndex = 29;
            // 
            // Editinward
            // 
            this.Editinward.Controls.Add(this.btshow);
            this.Editinward.Controls.Add(this.fgridedit);
            this.Editinward.Controls.Add(this.label3);
            this.Editinward.Controls.Add(this.label2);
            this.Editinward.Controls.Add(this.dtpto);
            this.Editinward.Controls.Add(this.dtpfrom);
            this.Editinward.Location = new System.Drawing.Point(4, 22);
            this.Editinward.Name = "Editinward";
            this.Editinward.Size = new System.Drawing.Size(1247, 515);
            this.Editinward.TabIndex = 3;
            this.Editinward.Text = "Edit";
            this.Editinward.UseVisualStyleBackColor = true;
            // 
            // btshow
            // 
            this.btshow.Location = new System.Drawing.Point(432, 28);
            this.btshow.Name = "btshow";
            this.btshow.Size = new System.Drawing.Size(75, 23);
            this.btshow.TabIndex = 5;
            this.btshow.Text = "Show";
            this.btshow.UseVisualStyleBackColor = true;
            this.btshow.Click += new System.EventHandler(this.btshow_Click);
            // 
            // fgridedit
            // 
            this.fgridedit.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgridedit.CheckedImage")));
            this.fgridedit.Cols = 19;
            this.fgridedit.Location = new System.Drawing.Point(13, 102);
            this.fgridedit.Name = "fgridedit";
            this.fgridedit.Rows = 1;
            this.fgridedit.Size = new System.Drawing.Size(1173, 385);
            this.fgridedit.TabIndex = 4;
            this.fgridedit.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgridedit.UncheckedImage")));
            this.fgridedit.LeaveCell += new FlexCell.Grid.LeaveCellEventHandler(this.fgridedit_LeaveCell);
            this.fgridedit.HyperLinkClick += new FlexCell.Grid.HyperLinkClickEventHandler(this.fgridedit_HyperLinkClick);
            this.fgridedit.Click += new FlexCell.Grid.ClickEventHandler(this.fgridedit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.CustomFormat = "dd/MM/yyyy";
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpto.Location = new System.Drawing.Point(304, 34);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(106, 20);
            this.dtpto.TabIndex = 1;
            // 
            // dtpfrom
            // 
            this.dtpfrom.CustomFormat = "dd/MM/yyyy";
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom.Location = new System.Drawing.Point(139, 35);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(110, 20);
            this.dtpfrom.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(536, 559);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 29;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmFinishedProductsInward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 594);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmFinishedProductsInward";
            this.Text = "FinishedProductsInward";
            this.Load += new System.EventHandler(this.frmFinishedProductsInward_Load);
            this.tabControl1.ResumeLayout(false);
            this.Entry.ResumeLayout(false);
            this.History.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInward)).EndInit();
            this.Editinward.ResumeLayout(false);
            this.Editinward.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Entry;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnShowInward;
        private System.Windows.Forms.DataGridView dgvInward;
        private FlexCell.Grid grid1;
        private System.Windows.Forms.TabPage Editinward;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FlexCell.Grid fgridedit;
        private System.Windows.Forms.Button btshow;
    }
}