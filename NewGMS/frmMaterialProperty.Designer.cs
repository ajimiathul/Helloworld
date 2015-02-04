namespace NewGMS
{
    partial class frmMaterialProperty
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
            this.txtProperty = new System.Windows.Forms.TextBox();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProperty
            // 
            this.txtProperty.Location = new System.Drawing.Point(26, 33);
            this.txtProperty.Name = "txtProperty";
            this.txtProperty.Size = new System.Drawing.Size(206, 20);
            this.txtProperty.TabIndex = 0;
            this.txtProperty.TextChanged += new System.EventHandler(this.txtProperty_TextChanged);
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperties.Location = new System.Drawing.Point(26, 120);
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.Size = new System.Drawing.Size(416, 359);
            this.dgvProperties.TabIndex = 1;
            this.dgvProperties.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperties_CellDoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(367, 30);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(367, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(367, 91);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMode
            // 
            this.txtMode.Enabled = false;
            this.txtMode.Location = new System.Drawing.Point(26, 485);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(172, 20);
            this.txtMode.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Property";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(26, 77);
            this.txtShortName.MaxLength = 10;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(126, 20);
            this.txtShortName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Short Name";
            // 
            // frmMaterialProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 517);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvProperties);
            this.Controls.Add(this.txtProperty);
            this.Name = "frmMaterialProperty";
            this.Text = "Material Property";
            this.Load += new System.EventHandler(this.frmMaterialProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProperty;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label label2;
    }
}