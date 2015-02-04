namespace NewGMS
{
    partial class frmPurchaseRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseRequest));
            this.cmbQtReqNo = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbOneSupplier = new System.Windows.Forms.RadioButton();
            this.rbManySupplier = new System.Windows.Forms.RadioButton();
            this.rbSupplier = new System.Windows.Forms.RadioButton();
            this.rbMaterial = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fgMaterials = new FlexCell.Grid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtStaus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbQtReqNo
            // 
            this.cmbQtReqNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQtReqNo.FormattingEnabled = true;
            this.cmbQtReqNo.Location = new System.Drawing.Point(104, 42);
            this.cmbQtReqNo.Name = "cmbQtReqNo";
            this.cmbQtReqNo.Size = new System.Drawing.Size(121, 21);
            this.cmbQtReqNo.TabIndex = 1;
            this.cmbQtReqNo.SelectedIndexChanged += new System.EventHandler(this.cmbQtReqNo_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1008, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbOneSupplier
            // 
            this.rbOneSupplier.AutoSize = true;
            this.rbOneSupplier.Location = new System.Drawing.Point(21, 48);
            this.rbOneSupplier.Name = "rbOneSupplier";
            this.rbOneSupplier.Size = new System.Drawing.Size(154, 17);
            this.rbOneSupplier.TabIndex = 44;
            this.rbOneSupplier.Text = "one material to one supplier";
            this.rbOneSupplier.UseVisualStyleBackColor = true;
            // 
            // rbManySupplier
            // 
            this.rbManySupplier.AutoSize = true;
            this.rbManySupplier.Checked = true;
            this.rbManySupplier.Location = new System.Drawing.Point(21, 21);
            this.rbManySupplier.Name = "rbManySupplier";
            this.rbManySupplier.Size = new System.Drawing.Size(161, 17);
            this.rbManySupplier.TabIndex = 45;
            this.rbManySupplier.TabStop = true;
            this.rbManySupplier.Text = "one material to many supplier";
            this.rbManySupplier.UseVisualStyleBackColor = true;
            this.rbManySupplier.CheckedChanged += new System.EventHandler(this.rbManySupplier_CheckedChanged);
            // 
            // rbSupplier
            // 
            this.rbSupplier.AutoSize = true;
            this.rbSupplier.Checked = true;
            this.rbSupplier.Location = new System.Drawing.Point(21, 29);
            this.rbSupplier.Name = "rbSupplier";
            this.rbSupplier.Size = new System.Drawing.Size(63, 17);
            this.rbSupplier.TabIndex = 46;
            this.rbSupplier.TabStop = true;
            this.rbSupplier.Text = "Supplier";
            this.rbSupplier.UseVisualStyleBackColor = true;
            // 
            // rbMaterial
            // 
            this.rbMaterial.AutoSize = true;
            this.rbMaterial.Location = new System.Drawing.Point(140, 29);
            this.rbMaterial.Name = "rbMaterial";
            this.rbMaterial.Size = new System.Drawing.Size(62, 17);
            this.rbMaterial.TabIndex = 47;
            this.rbMaterial.Text = "Material";
            this.rbMaterial.UseVisualStyleBackColor = true;
            this.rbMaterial.CheckedChanged += new System.EventHandler(this.rbMaterial_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSupplier);
            this.groupBox1.Controls.Add(this.rbMaterial);
            this.groupBox1.Location = new System.Drawing.Point(931, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 66);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Sort By ";
            // 
            // fgMaterials
            // 
            this.fgMaterials.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgMaterials.CheckedImage")));
            this.fgMaterials.Cols = 15;
            this.fgMaterials.Location = new System.Drawing.Point(12, 87);
            this.fgMaterials.Name = "fgMaterials";
            this.fgMaterials.Rows = 1;
            this.fgMaterials.Size = new System.Drawing.Size(902, 299);
            this.fgMaterials.TabIndex = 49;
            this.fgMaterials.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fgMaterials.UncheckedImage")));
            this.fgMaterials.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.fgMaterials_CellChange);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbManySupplier);
            this.groupBox2.Controls.Add(this.rbOneSupplier);
            this.groupBox2.Location = new System.Drawing.Point(931, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 86);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Selection ";
            // 
            // txtStaus
            // 
            this.txtStaus.Location = new System.Drawing.Point(296, 41);
            this.txtStaus.Name = "txtStaus";
            this.txtStaus.ReadOnly = true;
            this.txtStaus.Size = new System.Drawing.Size(212, 20);
            this.txtStaus.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Request Number";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1008, 355);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPurchaseRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 427);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.fgMaterials);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtStaus);
            this.Controls.Add(this.cmbQtReqNo);
            this.Name = "frmPurchaseRequest";
            this.Text = "Purchase Request";
            this.Load += new System.EventHandler(this.frmPurchaseRequest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbQtReqNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbOneSupplier;
        private System.Windows.Forms.RadioButton rbManySupplier;
        private System.Windows.Forms.RadioButton rbSupplier;
        private System.Windows.Forms.RadioButton rbMaterial;
        private System.Windows.Forms.GroupBox groupBox1;
        private FlexCell.Grid fgMaterials;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStaus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}