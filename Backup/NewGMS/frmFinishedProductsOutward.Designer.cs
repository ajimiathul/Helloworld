namespace NewGMS
{
    partial class frmFinishedProductsOutward
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinishedProductsOutward));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Entery = new System.Windows.Forms.TabPage();
            this.grid1 = new FlexCell.Grid();
            this.History = new System.Windows.Forms.TabPage();
            this.btnShowOutward = new System.Windows.Forms.Button();
            this.dgvOutward = new System.Windows.Forms.DataGridView();
            this.editout = new System.Windows.Forms.TabPage();
            this.btnShow = new System.Windows.Forms.Button();
            this.GridEdit = new FlexCell.Grid();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.btnclose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Entery.SuspendLayout();
            this.History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutward)).BeginInit();
            this.editout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Entery);
            this.tabControl1.Controls.Add(this.History);
            this.tabControl1.Controls.Add(this.editout);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1310, 642);
            this.tabControl1.TabIndex = 0;
            // 
            // Entery
            // 
            this.Entery.Controls.Add(this.grid1);
            this.Entery.Location = new System.Drawing.Point(4, 22);
            this.Entery.Name = "Entery";
            this.Entery.Padding = new System.Windows.Forms.Padding(3);
            this.Entery.Size = new System.Drawing.Size(1302, 616);
            this.Entery.TabIndex = 0;
            this.Entery.Text = "Entry";
            this.Entery.UseVisualStyleBackColor = true;
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 31;
            this.grid1.Location = new System.Drawing.Point(6, 33);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 2;
            this.grid1.Size = new System.Drawing.Size(1290, 483);
            this.grid1.TabIndex = 104;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.Load += new System.EventHandler(this.grid1_Load);
            this.grid1.EnterRow += new FlexCell.Grid.EnterRowEventHandler(this.grid1_EnterRow);
            this.grid1.LeaveCell += new FlexCell.Grid.LeaveCellEventHandler(this.grid1_LeaveCell);
            this.grid1.HyperLinkClick += new FlexCell.Grid.HyperLinkClickEventHandler(this.grid1_HyperLinkClick);
            this.grid1.LeaveRow += new FlexCell.Grid.LeaveRowEventHandler(this.grid1_LeaveRow);
            this.grid1.KeyDown += new FlexCell.Grid.KeyDownEventHandler(this.grid1_KeyDown);
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // History
            // 
            this.History.Controls.Add(this.btnShowOutward);
            this.History.Controls.Add(this.dgvOutward);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(1302, 616);
            this.History.TabIndex = 1;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = true;
            // 
            // btnShowOutward
            // 
            this.btnShowOutward.Location = new System.Drawing.Point(82, 48);
            this.btnShowOutward.Name = "btnShowOutward";
            this.btnShowOutward.Size = new System.Drawing.Size(75, 23);
            this.btnShowOutward.TabIndex = 32;
            this.btnShowOutward.Text = "Show";
            this.btnShowOutward.UseVisualStyleBackColor = true;
            this.btnShowOutward.Click += new System.EventHandler(this.btnShowOutward_Click);
            // 
            // dgvOutward
            // 
            this.dgvOutward.AllowUserToAddRows = false;
            this.dgvOutward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutward.Location = new System.Drawing.Point(26, 111);
            this.dgvOutward.Name = "dgvOutward";
            this.dgvOutward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutward.Size = new System.Drawing.Size(1108, 319);
            this.dgvOutward.TabIndex = 31;
            // 
            // editout
            // 
            this.editout.Controls.Add(this.btnShow);
            this.editout.Controls.Add(this.GridEdit);
            this.editout.Controls.Add(this.label3);
            this.editout.Controls.Add(this.dtpto);
            this.editout.Controls.Add(this.label2);
            this.editout.Controls.Add(this.dtpfrom);
            this.editout.Location = new System.Drawing.Point(4, 22);
            this.editout.Name = "editout";
            this.editout.Size = new System.Drawing.Size(1302, 616);
            this.editout.TabIndex = 3;
            this.editout.Text = "Edit";
            this.editout.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(529, 38);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // GridEdit
            // 
            this.GridEdit.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("GridEdit.CheckedImage")));
            this.GridEdit.Cols = 31;
            this.GridEdit.Location = new System.Drawing.Point(62, 125);
            this.GridEdit.Name = "GridEdit";
            this.GridEdit.Rows = 1;
            this.GridEdit.Size = new System.Drawing.Size(983, 289);
            this.GridEdit.TabIndex = 4;
            this.GridEdit.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("GridEdit.UncheckedImage")));
            this.GridEdit.LeaveCell += new FlexCell.Grid.LeaveCellEventHandler(this.GridEdit_LeaveCell);
            this.GridEdit.HyperLinkClick += new FlexCell.Grid.HyperLinkClickEventHandler(this.GridEdit_HyperLinkClick);
            this.GridEdit.LeaveRow += new FlexCell.Grid.LeaveRowEventHandler(this.GridEdit_LeaveRow);
            this.GridEdit.Click += new FlexCell.Grid.ClickEventHandler(this.GridEdit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // dtpto
            // 
            this.dtpto.CustomFormat = "dd/MM/yyyy";
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpto.Location = new System.Drawing.Point(329, 41);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(107, 20);
            this.dtpto.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "From";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtpfrom
            // 
            this.dtpfrom.CustomFormat = "dd/MM/yyyy";
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom.Location = new System.Drawing.Point(110, 41);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(117, 20);
            this.dtpfrom.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(584, 684);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 31;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmFinishedProductsOutward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 746);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmFinishedProductsOutward";
            this.Text = "frmFinishedProductsOutward";
            this.Load += new System.EventHandler(this.frmFinishedProductsOutward_Load);
            this.tabControl1.ResumeLayout(false);
            this.Entery.ResumeLayout(false);
            this.History.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutward)).EndInit();
            this.editout.ResumeLayout(false);
            this.editout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Entery;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.Button btnShowOutward;
        private System.Windows.Forms.DataGridView dgvOutward;
        private System.Windows.Forms.Button btnclose;
        private FlexCell.Grid grid1;
        private System.Windows.Forms.TabPage editout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private FlexCell.Grid GridEdit;
        private System.Windows.Forms.Button btnShow;

    }
}