namespace NewGMS
{
    partial class frmBundleParts
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtParts = new System.Windows.Forms.TextBox();
            this.cmbSub = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSubCatFilter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Parts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "label4";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(104, 368);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 23);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(34, 368);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 23);
            this.btnNew.TabIndex = 28;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "label3";
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToDeleteRows = false;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(445, 80);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.ReadOnly = true;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParts.Size = new System.Drawing.Size(372, 538);
            this.dgvParts.TabIndex = 26;
            this.dgvParts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellDoubleClick);
            this.dgvParts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(227, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(166, 368);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(65, 23);
            this.btnOk.TabIndex = 24;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtParts
            // 
            this.txtParts.Location = new System.Drawing.Point(34, 157);
            this.txtParts.MaxLength = 15;
            this.txtParts.Name = "txtParts";
            this.txtParts.Size = new System.Drawing.Size(148, 20);
            this.txtParts.TabIndex = 23;
            // 
            // cmbSub
            // 
            this.cmbSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSub.FormattingEnabled = true;
            this.cmbSub.Location = new System.Drawing.Point(34, 55);
            this.cmbSub.Name = "cmbSub";
            this.cmbSub.Size = new System.Drawing.Size(176, 21);
            this.cmbSub.TabIndex = 32;
            this.cmbSub.SelectedIndexChanged += new System.EventHandler(this.cmbSub_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "SubCategory";
            // 
            // cbSubCatFilter
            // 
            this.cbSubCatFilter.AutoSize = true;
            this.cbSubCatFilter.Checked = true;
            this.cbSubCatFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubCatFilter.Location = new System.Drawing.Point(445, 57);
            this.cbSubCatFilter.Name = "cbSubCatFilter";
            this.cbSubCatFilter.Size = new System.Drawing.Size(114, 17);
            this.cbSubCatFilter.TabIndex = 34;
            this.cbSubCatFilter.Text = "Sub Catgeory Only\r\n";
            this.cbSubCatFilter.UseVisualStyleBackColor = true;
            this.cbSubCatFilter.CheckedChanged += new System.EventHandler(this.cbSubCatFilter_CheckedChanged);
            // 
            // frmBundleParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 656);
            this.Controls.Add(this.cbSubCatFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSub);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtParts);
            this.Name = "frmBundleParts";
            this.Text = "Parts";
            this.Load += new System.EventHandler(this.frmBundleParts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtParts;
        private System.Windows.Forms.ComboBox cmbSub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSubCatFilter;
    }
}