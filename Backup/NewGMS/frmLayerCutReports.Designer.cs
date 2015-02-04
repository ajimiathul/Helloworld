namespace NewGMS
{
    partial class frmLayerCutReports
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
            this.txtBunTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBunFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbParts = new System.Windows.Forms.ComboBox();
            this.cmbLetters = new System.Windows.Forms.ComboBox();
            this.cmbLayerBatchNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbHeader = new System.Windows.Forms.RadioButton();
            this.rbDtl1 = new System.Windows.Forms.RadioButton();
            this.rbTag = new System.Windows.Forms.RadioButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txthidDate = new System.Windows.Forms.TextBox();
            this.rbDtl2 = new System.Windows.Forms.RadioButton();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBunTo
            // 
            this.txtBunTo.Location = new System.Drawing.Point(969, 66);
            this.txtBunTo.Name = "txtBunTo";
            this.txtBunTo.Size = new System.Drawing.Size(100, 20);
            this.txtBunTo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(971, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "To";
            // 
            // txtBunFrom
            // 
            this.txtBunFrom.Location = new System.Drawing.Point(852, 68);
            this.txtBunFrom.Name = "txtBunFrom";
            this.txtBunFrom.Size = new System.Drawing.Size(100, 20);
            this.txtBunFrom.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Bundle No From";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1108, 64);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(712, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Parts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Size";
            // 
            // cmbParts
            // 
            this.cmbParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParts.FormattingEnabled = true;
            this.cmbParts.Location = new System.Drawing.Point(715, 66);
            this.cmbParts.Name = "cmbParts";
            this.cmbParts.Size = new System.Drawing.Size(121, 21);
            this.cmbParts.TabIndex = 10;
            this.cmbParts.SelectedIndexChanged += new System.EventHandler(this.cmbParts_SelectedIndexChanged);
            // 
            // cmbLetters
            // 
            this.cmbLetters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLetters.FormattingEnabled = true;
            this.cmbLetters.Location = new System.Drawing.Point(568, 65);
            this.cmbLetters.Name = "cmbLetters";
            this.cmbLetters.Size = new System.Drawing.Size(121, 21);
            this.cmbLetters.TabIndex = 9;
            this.cmbLetters.SelectedIndexChanged += new System.EventHandler(this.cmbLetters_SelectedIndexChanged);
            // 
            // cmbLayerBatchNo
            // 
            this.cmbLayerBatchNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayerBatchNo.FormattingEnabled = true;
            this.cmbLayerBatchNo.Location = new System.Drawing.Point(409, 65);
            this.cmbLayerBatchNo.Name = "cmbLayerBatchNo";
            this.cmbLayerBatchNo.Size = new System.Drawing.Size(121, 21);
            this.cmbLayerBatchNo.TabIndex = 18;
            this.cmbLayerBatchNo.SelectedIndexChanged += new System.EventHandler(this.cmbLayerBatchNo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Layer Batch No";
            // 
            // rbHeader
            // 
            this.rbHeader.AutoSize = true;
            this.rbHeader.Enabled = false;
            this.rbHeader.Location = new System.Drawing.Point(12, 36);
            this.rbHeader.Name = "rbHeader";
            this.rbHeader.Size = new System.Drawing.Size(92, 17);
            this.rbHeader.TabIndex = 20;
            this.rbHeader.Text = "Print Summary";
            this.rbHeader.UseVisualStyleBackColor = true;
            this.rbHeader.CheckedChanged += new System.EventHandler(this.rbHeader_CheckedChanged);
            // 
            // rbDtl1
            // 
            this.rbDtl1.AutoSize = true;
            this.rbDtl1.Enabled = false;
            this.rbDtl1.Location = new System.Drawing.Point(13, 12);
            this.rbDtl1.Name = "rbDtl1";
            this.rbDtl1.Size = new System.Drawing.Size(162, 17);
            this.rbDtl1.TabIndex = 21;
            this.rbDtl1.Text = "Print Bundle Details(36 to 44)";
            this.rbDtl1.UseVisualStyleBackColor = true;
            this.rbDtl1.CheckedChanged += new System.EventHandler(this.rbDtl_CheckedChanged);
            // 
            // rbTag
            // 
            this.rbTag.AutoSize = true;
            this.rbTag.Checked = true;
            this.rbTag.Location = new System.Drawing.Point(12, 65);
            this.rbTag.Name = "rbTag";
            this.rbTag.Size = new System.Drawing.Size(68, 17);
            this.rbTag.TabIndex = 22;
            this.rbTag.TabStop = true;
            this.rbTag.Text = "Print Tag";
            this.rbTag.UseVisualStyleBackColor = true;
            this.rbTag.CheckedChanged += new System.EventHandler(this.rbTag_CheckedChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 94);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1171, 376);
            this.crystalReportViewer1.TabIndex = 23;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // txthidDate
            // 
            this.txthidDate.Location = new System.Drawing.Point(680, 12);
            this.txthidDate.Name = "txthidDate";
            this.txthidDate.Size = new System.Drawing.Size(100, 20);
            this.txthidDate.TabIndex = 24;
            this.txthidDate.Visible = false;
            // 
            // rbDtl2
            // 
            this.rbDtl2.AutoSize = true;
            this.rbDtl2.Enabled = false;
            this.rbDtl2.Location = new System.Drawing.Point(222, 12);
            this.rbDtl2.Name = "rbDtl2";
            this.rbDtl2.Size = new System.Drawing.Size(162, 17);
            this.rbDtl2.TabIndex = 25;
            this.rbDtl2.Text = "Print Bundle Details(46 to 54)";
            this.rbDtl2.UseVisualStyleBackColor = true;
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(120, 64);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(247, 21);
            this.cmbStyle.TabIndex = 26;
            this.cmbStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Style";
            // 
            // frmLayerCutReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 482);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStyle);
            this.Controls.Add(this.rbDtl2);
            this.Controls.Add(this.txthidDate);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.rbTag);
            this.Controls.Add(this.rbDtl1);
            this.Controls.Add(this.rbHeader);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbLayerBatchNo);
            this.Controls.Add(this.txtBunTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBunFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbParts);
            this.Controls.Add(this.cmbLetters);
            this.Name = "frmLayerCutReports";
            this.Text = "frmLayerCutReports";
            this.Load += new System.EventHandler(this.frmLayerCutReports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBunTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBunFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbParts;
        private System.Windows.Forms.ComboBox cmbLetters;
        private System.Windows.Forms.ComboBox cmbLayerBatchNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbHeader;
        private System.Windows.Forms.RadioButton rbDtl1;
        private System.Windows.Forms.RadioButton rbTag;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox txthidDate;
        private System.Windows.Forms.RadioButton rbDtl2;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label6;
    }
}