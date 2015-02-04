namespace NewGMS
{
    partial class frmSubCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubCategory));
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvSubCategory = new System.Windows.Forms.DataGridView();
            this.gpbMode = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btsave = new System.Windows.Forms.Button();
            this.grid1 = new FlexCell.Grid();
            this.lblstylecode = new System.Windows.Forms.Label();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategory)).BeginInit();
            this.gpbMode.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSubCategory
            // 
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Location = new System.Drawing.Point(15, 22);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(67, 13);
            this.lblSubCategory.TabIndex = 0;
            this.lblSubCategory.Text = "Subcategory";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(208, 22);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(18, 47);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(112, 20);
            this.txtSubCategory.TabIndex = 1;
            this.txtSubCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubCategory_KeyPress);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(210, 46);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(124, 21);
            this.cmbCategory.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(25, 83);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(143, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(270, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvSubCategory
            // 
            this.dgvSubCategory.AllowUserToAddRows = false;
            this.dgvSubCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubCategory.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvSubCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCategory.GridColor = System.Drawing.SystemColors.Desktop;
            this.dgvSubCategory.Location = new System.Drawing.Point(24, 167);
            this.dgvSubCategory.Name = "dgvSubCategory";
            this.dgvSubCategory.Size = new System.Drawing.Size(363, 323);
            this.dgvSubCategory.TabIndex = 4;
            this.dgvSubCategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubCategory_CellDoubleClick);
            // 
            // gpbMode
            // 
            this.gpbMode.Controls.Add(this.txtSubCategory);
            this.gpbMode.Controls.Add(this.cmbCategory);
            this.gpbMode.Controls.Add(this.btnDelete);
            this.gpbMode.Controls.Add(this.lblCategory);
            this.gpbMode.Controls.Add(this.btnSave);
            this.gpbMode.Controls.Add(this.btnNew);
            this.gpbMode.Controls.Add(this.lblSubCategory);
            this.gpbMode.Location = new System.Drawing.Point(6, 16);
            this.gpbMode.Name = "gpbMode";
            this.gpbMode.Size = new System.Drawing.Size(363, 130);
            this.gpbMode.TabIndex = 5;
            this.gpbMode.TabStop = false;
            this.gpbMode.Text = "Mode : New ";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(138, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(444, 525);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabPage1.Controls.Add(this.gpbMode);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.dgvSubCategory);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(436, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btsave);
            this.tabPage2.Controls.Add(this.grid1);
            this.tabPage2.Controls.Add(this.lblstylecode);
            this.tabPage2.Controls.Add(this.cmbSubCategory);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(436, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Assignment";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(170, 334);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 10;
            this.btsave.Text = "Save";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 3;
            this.grid1.Location = new System.Drawing.Point(6, 64);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 1;
            this.grid1.Size = new System.Drawing.Size(412, 234);
            this.grid1.TabIndex = 9;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.Load += new System.EventHandler(this.grid1_Load);
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // lblstylecode
            // 
            this.lblstylecode.AutoSize = true;
            this.lblstylecode.Location = new System.Drawing.Point(26, 22);
            this.lblstylecode.Name = "lblstylecode";
            this.lblstylecode.Size = new System.Drawing.Size(71, 13);
            this.lblstylecode.TabIndex = 8;
            this.lblstylecode.Text = "Sub Category";
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Location = new System.Drawing.Point(140, 19);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(180, 21);
            this.cmbSubCategory.TabIndex = 7;
            this.cmbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSubCategory_SelectedIndexChanged);
            this.cmbSubCategory.ValueMemberChanged += new System.EventHandler(this.cmbSubCategory_ValueMemberChanged);
            // 
            // frmSubCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 540);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmSubCategory";
            this.Text = "frmSubCategory";
            this.Load += new System.EventHandler(this.frmSubCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategory)).EndInit();
            this.gpbMode.ResumeLayout(false);
            this.gpbMode.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSubCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtSubCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvSubCategory;
        private System.Windows.Forms.GroupBox gpbMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbSubCategory;
        private System.Windows.Forms.Label lblstylecode;
        private FlexCell.Grid grid1;
        private System.Windows.Forms.Button btsave;
    }
}