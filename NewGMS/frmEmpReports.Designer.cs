namespace NewGMS
{
    partial class frmEmpReports
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbResigned = new System.Windows.Forms.RadioButton();
            this.rbID = new System.Windows.Forms.RadioButton();
            this.rbDep = new System.Windows.Forms.RadioButton();
            this.rbDes = new System.Windows.Forms.RadioButton();
            this.rbSal = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.rbSal);
            this.groupBox1.Controls.Add(this.rbDes);
            this.groupBox1.Controls.Add(this.rbDep);
            this.groupBox1.Controls.Add(this.rbID);
            this.groupBox1.Controls.Add(this.rbName);
            this.groupBox1.Location = new System.Drawing.Point(279, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order";
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.Location = new System.Drawing.Point(7, 21);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(80, 17);
            this.rbName.TabIndex = 0;
            this.rbName.TabStop = true;
            this.rbName.Text = "Name Wise";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbResigned);
            this.groupBox2.Controls.Add(this.rbActive);
            this.groupBox2.Location = new System.Drawing.Point(12, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Location = new System.Drawing.Point(6, 19);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(55, 17);
            this.rbActive.TabIndex = 0;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // rbResigned
            // 
            this.rbResigned.AutoSize = true;
            this.rbResigned.Location = new System.Drawing.Point(114, 19);
            this.rbResigned.Name = "rbResigned";
            this.rbResigned.Size = new System.Drawing.Size(70, 17);
            this.rbResigned.TabIndex = 1;
            this.rbResigned.Text = "Resigned";
            this.rbResigned.UseVisualStyleBackColor = true;
            // 
            // rbID
            // 
            this.rbID.AutoSize = true;
            this.rbID.Location = new System.Drawing.Point(113, 19);
            this.rbID.Name = "rbID";
            this.rbID.Size = new System.Drawing.Size(63, 17);
            this.rbID.TabIndex = 1;
            this.rbID.Text = "ID Wise";
            this.rbID.UseVisualStyleBackColor = true;
            // 
            // rbDep
            // 
            this.rbDep.AutoSize = true;
            this.rbDep.Location = new System.Drawing.Point(197, 18);
            this.rbDep.Name = "rbDep";
            this.rbDep.Size = new System.Drawing.Size(107, 17);
            this.rbDep.TabIndex = 2;
            this.rbDep.Text = "Department Wise";
            this.rbDep.UseVisualStyleBackColor = true;
            // 
            // rbDes
            // 
            this.rbDes.AutoSize = true;
            this.rbDes.Location = new System.Drawing.Point(311, 15);
            this.rbDes.Name = "rbDes";
            this.rbDes.Size = new System.Drawing.Size(108, 17);
            this.rbDes.TabIndex = 3;
            this.rbDes.Text = "Designation Wise";
            this.rbDes.UseVisualStyleBackColor = true;
            // 
            // rbSal
            // 
            this.rbSal.AutoSize = true;
            this.rbSal.Location = new System.Drawing.Point(437, 16);
            this.rbSal.Name = "rbSal";
            this.rbSal.Size = new System.Drawing.Size(108, 17);
            this.rbSal.TabIndex = 4;
            this.rbSal.Text = "Salary Type Wise";
            this.rbSal.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(575, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 75);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(943, 423);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmEmpReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 510);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmpReports";
            this.Text = "frmEmpReports";
            this.Load += new System.EventHandler(this.frmEmpReports_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbResigned;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rbSal;
        private System.Windows.Forms.RadioButton rbDes;
        private System.Windows.Forms.RadioButton rbDep;
        private System.Windows.Forms.RadioButton rbID;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}