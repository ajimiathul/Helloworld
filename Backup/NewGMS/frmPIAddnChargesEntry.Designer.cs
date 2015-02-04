namespace NewGMS
{
    partial class frmPIAddnChargesEntry
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDescription = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 40);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(448, 122);
            this.txtDescription.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(487, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(487, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDescription
            // 
            this.dgvDescription.AllowUserToAddRows = false;
            this.dgvDescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescription.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCode,
            this.ColDesc});
            this.dgvDescription.Location = new System.Drawing.Point(12, 189);
            this.dgvDescription.Name = "dgvDescription";
            this.dgvDescription.Size = new System.Drawing.Size(750, 150);
            this.dgvDescription.TabIndex = 3;
            this.dgvDescription.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDescription_CellDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(487, 139);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(487, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ColCode
            // 
            this.ColCode.HeaderText = "Code";
            this.ColCode.Name = "ColCode";
            this.ColCode.Visible = false;
            // 
            // ColDesc
            // 
            this.ColDesc.HeaderText = "Description";
            this.ColDesc.Name = "ColDesc";
            this.ColDesc.Width = 700;
            // 
            // frmPIAddnChargesEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 360);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDescription);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Name = "frmPIAddnChargesEntry";
            this.Text = "PI Addn Charges Entry";
            this.Load += new System.EventHandler(this.frmPIAddnChargesEntry_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPIAddnChargesEntry_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDescription;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDesc;
    }
}