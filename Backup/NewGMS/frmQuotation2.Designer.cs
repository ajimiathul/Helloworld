namespace NewGMS
{
    partial class frmQuotation2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotation2));
            this.cmbQtReqNo = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fgQuotation = new FlexCell.Grid();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbQtReqNo
            // 
            this.cmbQtReqNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQtReqNo.FormattingEnabled = true;
            this.cmbQtReqNo.Location = new System.Drawing.Point(182, 34);
            this.cmbQtReqNo.Name = "cmbQtReqNo";
            this.cmbQtReqNo.Size = new System.Drawing.Size(178, 21);
            this.cmbQtReqNo.TabIndex = 0;
            this.cmbQtReqNo.SelectedIndexChanged += new System.EventHandler(this.cmbQtReqNo_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(899, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Quotation Request Number";
            // 
            // fgQuotation
            // 
            this.fgQuotation.AutoSize = true;
            this.fgQuotation.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgQuotation.CheckedImage")));
            this.fgQuotation.Cols = 13;
            this.fgQuotation.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles;
            this.fgQuotation.Location = new System.Drawing.Point(12, 102);
            this.fgQuotation.Name = "fgQuotation";
            this.fgQuotation.Rows = 1;
            this.fgQuotation.Size = new System.Drawing.Size(1068, 265);
            this.fgQuotation.TabIndex = 1;
            this.fgQuotation.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgQuotation.UncheckedImage")));
            this.fgQuotation.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.fgQuotation_CellChange);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1005, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmQuotation2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 433);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.fgQuotation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbQtReqNo);
            this.Name = "frmQuotation2";
            this.Text = "Quotation";
            this.Load += new System.EventHandler(this.frmQuotation2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbQtReqNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private FlexCell.Grid fgQuotation;
        private System.Windows.Forms.Button btnClose;
    }
}