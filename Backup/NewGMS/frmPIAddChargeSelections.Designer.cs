namespace NewGMS
{
    partial class frmPIAddChargeSelections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPIAddChargeSelections));
            this.gridPISelections = new FlexCell.Grid();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtReqSubno = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gridPISelections
            // 
            this.gridPISelections.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridPISelections.CheckedImage")));
            this.gridPISelections.Cols = 4;
            this.gridPISelections.Location = new System.Drawing.Point(53, 44);
            this.gridPISelections.Name = "gridPISelections";
            this.gridPISelections.Size = new System.Drawing.Size(863, 335);
            this.gridPISelections.TabIndex = 0;
            this.gridPISelections.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridPISelections.UncheckedImage")));
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(749, 394);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(841, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtReqSubno
            // 
            this.txtReqSubno.Location = new System.Drawing.Point(53, 18);
            this.txtReqSubno.Name = "txtReqSubno";
            this.txtReqSubno.ReadOnly = true;
            this.txtReqSubno.Size = new System.Drawing.Size(149, 20);
            this.txtReqSubno.TabIndex = 3;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(334, 12);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(149, 20);
            this.txtSupplier.TabIndex = 4;
            // 
            // frmPIAddChargeSelections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 452);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.txtReqSubno);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.gridPISelections);
            this.Name = "frmPIAddChargeSelections";
            this.Text = "frmPIAddChargeSelections";
            this.Load += new System.EventHandler(this.frmPIAddChargeSelections_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlexCell.Grid gridPISelections;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtReqSubno;
        private System.Windows.Forms.TextBox txtSupplier;
    }
}