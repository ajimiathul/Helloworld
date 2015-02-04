namespace NewGMS
{
    partial class frmMaterial
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
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblOpStock = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtOpeningStock = new System.Windows.Forms.TextBox();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.cmbLUUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblReorderLevel = new System.Windows.Forms.Label();
            this.cmbBM = new System.Windows.Forms.ComboBox();
            this.cmbPro = new System.Windows.Forms.ComboBox();
            this.cmbVal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.colnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(48, 453);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 0;
            this.lblMaterial.Text = "Material";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(44, 311);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 0;
            this.lblRate.Text = "Rate";
            // 
            // lblOpStock
            // 
            this.lblOpStock.AutoSize = true;
            this.lblOpStock.Location = new System.Drawing.Point(44, 340);
            this.lblOpStock.Name = "lblOpStock";
            this.lblOpStock.Size = new System.Drawing.Size(78, 13);
            this.lblOpStock.TabIndex = 0;
            this.lblOpStock.Text = "Opening Stock";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(151, 450);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(633, 20);
            this.txtMaterial.TabIndex = 4;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(151, 308);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(141, 20);
            this.txtRate.TabIndex = 4;
            this.txtRate.Text = "0.0";
            // 
            // txtOpeningStock
            // 
            this.txtOpeningStock.Location = new System.Drawing.Point(151, 337);
            this.txtOpeningStock.Name = "txtOpeningStock";
            this.txtOpeningStock.Size = new System.Drawing.Size(141, 20);
            this.txtOpeningStock.TabIndex = 4;
            this.txtOpeningStock.Text = "0.0";
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Location = new System.Drawing.Point(151, 377);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(141, 20);
            this.txtReorderLevel.TabIndex = 4;
            this.txtReorderLevel.Text = "0.0";
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Location = new System.Drawing.Point(508, 23);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.Size = new System.Drawing.Size(722, 398);
            this.dgvMaterial.TabIndex = 7;
            this.dgvMaterial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterial_CellDoubleClick);
            // 
            // cmbLUUnit
            // 
            this.cmbLUUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLUUnit.FormattingEnabled = true;
            this.cmbLUUnit.Location = new System.Drawing.Point(151, 413);
            this.cmbLUUnit.Name = "cmbLUUnit";
            this.cmbLUUnit.Size = new System.Drawing.Size(141, 21);
            this.cmbLUUnit.TabIndex = 3;
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Large Unit";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(952, 484);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(871, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = ">>";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblReorderLevel
            // 
            this.lblReorderLevel.AutoSize = true;
            this.lblReorderLevel.Location = new System.Drawing.Point(44, 380);
            this.lblReorderLevel.Name = "lblReorderLevel";
            this.lblReorderLevel.Size = new System.Drawing.Size(74, 13);
            this.lblReorderLevel.TabIndex = 0;
            this.lblReorderLevel.Text = "Reorder Level";
            // 
            // cmbBM
            // 
            this.cmbBM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBM.FormattingEnabled = true;
            this.cmbBM.Location = new System.Drawing.Point(45, 34);
            this.cmbBM.Name = "cmbBM";
            this.cmbBM.Size = new System.Drawing.Size(216, 21);
            this.cmbBM.TabIndex = 8;
            // 
            // cmbPro
            // 
            this.cmbPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPro.FormattingEnabled = true;
            this.cmbPro.Location = new System.Drawing.Point(46, 81);
            this.cmbPro.Name = "cmbPro";
            this.cmbPro.Size = new System.Drawing.Size(141, 21);
            this.cmbPro.TabIndex = 9;
            this.cmbPro.SelectedIndexChanged += new System.EventHandler(this.cmbPro_SelectedIndexChanged);
            // 
            // cmbVal
            // 
            this.cmbVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVal.FormattingEnabled = true;
            this.cmbVal.Location = new System.Drawing.Point(219, 81);
            this.cmbVal.Name = "cmbVal";
            this.cmbVal.Size = new System.Drawing.Size(141, 21);
            this.cmbVal.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Base Material";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Property";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Value";
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colnum,
            this.colProCode,
            this.colProperty,
            this.colValCode,
            this.colVal});
            this.dgvProperties.Location = new System.Drawing.Point(46, 108);
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.Size = new System.Drawing.Size(439, 178);
            this.dgvProperties.TabIndex = 16;
            this.dgvProperties.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperties_CellDoubleClick);
            // 
            // colnum
            // 
            this.colnum.HeaderText = "colnum";
            this.colnum.Name = "colnum";
            this.colnum.Visible = false;
            // 
            // colProCode
            // 
            this.colProCode.HeaderText = "colProCode";
            this.colProCode.Name = "colProCode";
            this.colProCode.Visible = false;
            // 
            // colProperty
            // 
            this.colProperty.HeaderText = "Property";
            this.colProperty.Name = "colProperty";
            this.colProperty.Width = 160;
            // 
            // colValCode
            // 
            this.colValCode.HeaderText = "colValCode";
            this.colValCode.Name = "colValCode";
            this.colValCode.Visible = false;
            // 
            // colVal
            // 
            this.colVal.HeaderText = "Value";
            this.colVal.Name = "colVal";
            this.colVal.Width = 160;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(424, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMode
            // 
            this.txtMode.Enabled = false;
            this.txtMode.Location = new System.Drawing.Point(1033, 486);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(172, 20);
            this.txtMode.TabIndex = 18;
            // 
            // frmMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 517);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProperties);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVal);
            this.Controls.Add(this.cmbPro);
            this.Controls.Add(this.cmbBM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLUUnit);
            this.Controls.Add(this.dgvMaterial);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReorderLevel);
            this.Controls.Add(this.txtOpeningStock);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblReorderLevel);
            this.Controls.Add(this.lblOpStock);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblMaterial);
            this.Name = "frmMaterial";
            this.Text = "frmMaterial";
            this.Load += new System.EventHandler(this.frmMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblOpStock;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtOpeningStock;
        private System.Windows.Forms.TextBox txtReorderLevel;
        private System.Windows.Forms.DataGridView dgvMaterial;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblReorderLevel;
        private System.Windows.Forms.ComboBox cmbLUUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBM;
        private System.Windows.Forms.ComboBox cmbPro;
        private System.Windows.Forms.ComboBox cmbVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVal;
    }
}