namespace NewGMS
{
    partial class frmreportpurchaserequest
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
            this.cmrqno = new System.Windows.Forms.ComboBox();
            this.lblrqt = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmrqno
            // 
            this.cmrqno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmrqno.FormattingEnabled = true;
            this.cmrqno.Location = new System.Drawing.Point(134, 12);
            this.cmrqno.Name = "cmrqno";
            this.cmrqno.Size = new System.Drawing.Size(121, 21);
            this.cmrqno.TabIndex = 0;
            this.cmrqno.SelectedIndexChanged += new System.EventHandler(this.cmrqno_SelectedIndexChanged);
            // 
            // lblrqt
            // 
            this.lblrqt.AutoSize = true;
            this.lblrqt.Location = new System.Drawing.Point(12, 18);
            this.lblrqt.Name = "lblrqt";
            this.lblrqt.Size = new System.Drawing.Size(116, 13);
            this.lblrqt.TabIndex = 1;
            this.lblrqt.Text = "Quotation Request No.";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 39);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1229, 696);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmreportpurchaserequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 742);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.lblrqt);
            this.Controls.Add(this.cmrqno);
            this.Name = "frmreportpurchaserequest";
            this.Text = "frmreportpurchaserequest";
            this.Load += new System.EventHandler(this.frmreportpurchaserequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmrqno;
        private System.Windows.Forms.Label lblrqt;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button1;
    }
}