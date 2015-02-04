namespace NewGMS
{
    partial class frmPerformaInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerformaInvoice));
            this.cmbQtReqNo = new System.Windows.Forms.ComboBox();
            this.cmbSupplr = new System.Windows.Forms.ComboBox();
            this.txtCond = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gridPerforma = new FlexCell.Grid();
            this.btnclose = new System.Windows.Forms.Button();
            this.dtpPiDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPiNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fgAddnCharges = new FlexCell.Grid();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.llNew = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmbQtReqNo
            // 
            this.cmbQtReqNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQtReqNo.FormattingEnabled = true;
            this.cmbQtReqNo.Location = new System.Drawing.Point(358, 25);
            this.cmbQtReqNo.Name = "cmbQtReqNo";
            this.cmbQtReqNo.Size = new System.Drawing.Size(118, 21);
            this.cmbQtReqNo.TabIndex = 38;
            this.cmbQtReqNo.SelectedIndexChanged += new System.EventHandler(this.cmbQtReqNo_SelectedIndexChanged);
            // 
            // cmbSupplr
            // 
            this.cmbSupplr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplr.FormattingEnabled = true;
            this.cmbSupplr.Location = new System.Drawing.Point(91, 26);
            this.cmbSupplr.Name = "cmbSupplr";
            this.cmbSupplr.Size = new System.Drawing.Size(147, 21);
            this.cmbSupplr.TabIndex = 39;
            this.cmbSupplr.SelectedIndexChanged += new System.EventHandler(this.cmbSupplr_SelectedIndexChanged);
            // 
            // txtCond
            // 
            this.txtCond.Location = new System.Drawing.Point(913, 66);
            this.txtCond.MaxLength = 3500;
            this.txtCond.Multiline = true;
            this.txtCond.Name = "txtCond";
            this.txtCond.Size = new System.Drawing.Size(211, 379);
            this.txtCond.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(921, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Condition";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(913, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Supplier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Request No";
            // 
            // gridPerforma
            // 
            this.gridPerforma.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridPerforma.CheckedImage")));
            this.gridPerforma.Cols = 8;
            this.gridPerforma.Location = new System.Drawing.Point(44, 66);
            this.gridPerforma.Name = "gridPerforma";
            this.gridPerforma.Rows = 1;
            this.gridPerforma.Size = new System.Drawing.Size(838, 229);
            this.gridPerforma.TabIndex = 57;
            this.gridPerforma.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("gridPerforma.UncheckedImage")));
            this.gridPerforma.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.gridPerforma_CellChange);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(1034, 466);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 58;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // dtpPiDate
            // 
            this.dtpPiDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPiDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPiDate.Location = new System.Drawing.Point(735, 26);
            this.dtpPiDate.Name = "dtpPiDate";
            this.dtpPiDate.Size = new System.Drawing.Size(95, 20);
            this.dtpPiDate.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(683, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "P I Date";
            // 
            // txtPiNumber
            // 
            this.txtPiNumber.Location = new System.Drawing.Point(559, 29);
            this.txtPiNumber.Name = "txtPiNumber";
            this.txtPiNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPiNumber.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "P I Number";
            // 
            // fgAddnCharges
            // 
            this.fgAddnCharges.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgAddnCharges.CheckedImage")));
            this.fgAddnCharges.Cols = 3;
            this.fgAddnCharges.Location = new System.Drawing.Point(44, 301);
            this.fgAddnCharges.Name = "fgAddnCharges";
            this.fgAddnCharges.Rows = 1;
            this.fgAddnCharges.Size = new System.Drawing.Size(838, 144);
            this.fgAddnCharges.TabIndex = 61;
            this.fgAddnCharges.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgAddnCharges.UncheckedImage")));
            this.fgAddnCharges.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.fgAddnCharges_CellChange);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(578, 473);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(477, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Total Amount";
            // 
            // llNew
            // 
            this.llNew.AutoSize = true;
            this.llNew.Location = new System.Drawing.Point(772, 448);
            this.llNew.Name = "llNew";
            this.llNew.Size = new System.Drawing.Size(110, 13);
            this.llNew.TabIndex = 95;
            this.llNew.TabStop = true;
            this.llNew.Text = "Load DefaultCharges ";
            this.llNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNew_LinkClicked);
            // 
            // frmPerformaInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 535);
            this.Controls.Add(this.llNew);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.fgAddnCharges);
            this.Controls.Add(this.txtPiNumber);
            this.Controls.Add(this.dtpPiDate);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.gridPerforma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCond);
            this.Controls.Add(this.cmbSupplr);
            this.Controls.Add(this.cmbQtReqNo);
            this.Name = "frmPerformaInvoice";
            this.Text = "Performa Invoice";
            this.Load += new System.EventHandler(this.frmPerformaInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbQtReqNo;
        private System.Windows.Forms.ComboBox cmbSupplr;
        private System.Windows.Forms.TextBox txtCond;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private FlexCell.Grid gridPerforma;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DateTimePicker dtpPiDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPiNumber;
        private System.Windows.Forms.Label label2;
        private FlexCell.Grid fgAddnCharges;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel llNew;
    }
}