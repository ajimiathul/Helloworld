namespace NewGMS
{
    partial class frmRPTPurchaseorder
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
            this.cmbpono = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbpono
            // 
            this.cmbpono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpono.FormattingEnabled = true;
            this.cmbpono.Location = new System.Drawing.Point(15, 41);
            this.cmbpono.Name = "cmbpono";
            this.cmbpono.Size = new System.Drawing.Size(121, 21);
            this.cmbpono.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Purchase Order";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 70);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1208, 595);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Show\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRPTPurchaseorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 677);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbpono);
            this.Name = "frmRPTPurchaseorder";
            this.Text = "frmRPTPurchaseorder";
            this.Load += new System.EventHandler(this.frmRPTPurchaseorder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbpono;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button1;
    }
}