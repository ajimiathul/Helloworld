namespace NewGMS
{
    partial class frmSizeType
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblsizetype = new System.Windows.Forms.Label();
            this.txtSizetype = new System.Windows.Forms.TextBox();
            this.dataGridViewSizetype = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblmodsize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSizetype)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(213, 14);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(213, 102);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(213, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(145, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblsizetype
            // 
            this.lblsizetype.AutoSize = true;
            this.lblsizetype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsizetype.Location = new System.Drawing.Point(25, 36);
            this.lblsizetype.Name = "lblsizetype";
            this.lblsizetype.Size = new System.Drawing.Size(31, 13);
            this.lblsizetype.TabIndex = 4;
            this.lblsizetype.Text = "Size";
            // 
            // txtSizetype
            // 
            this.txtSizetype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSizetype.Location = new System.Drawing.Point(28, 63);
            this.txtSizetype.Name = "txtSizetype";
            this.txtSizetype.Size = new System.Drawing.Size(100, 20);
            this.txtSizetype.TabIndex = 3;
            // 
            // dataGridViewSizetype
            // 
            this.dataGridViewSizetype.AllowUserToAddRows = false;
            this.dataGridViewSizetype.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSizetype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSizetype.Location = new System.Drawing.Point(36, 159);
            this.dataGridViewSizetype.Name = "dataGridViewSizetype";
            this.dataGridViewSizetype.Size = new System.Drawing.Size(299, 303);
            this.dataGridViewSizetype.TabIndex = 5;
            this.dataGridViewSizetype.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSizetype_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblmodsize);
            this.groupBox1.Controls.Add(this.lblsizetype);
            this.groupBox1.Controls.Add(this.txtSizetype);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(36, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 141);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblmodsize
            // 
            this.lblmodsize.AutoSize = true;
            this.lblmodsize.Location = new System.Drawing.Point(6, 0);
            this.lblmodsize.Name = "lblmodsize";
            this.lblmodsize.Size = new System.Drawing.Size(34, 13);
            this.lblmodsize.TabIndex = 5;
            this.lblmodsize.Text = "Mode";
            // 
            // frmSizeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 517);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewSizetype);
            this.Controls.Add(this.btnClose);
            this.Name = "frmSizeType";
            this.Text = "frmSizeType";
            this.Load += new System.EventHandler(this.frmSizeType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSizetype)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblsizetype;
        private System.Windows.Forms.TextBox txtSizetype;
        private System.Windows.Forms.DataGridView dataGridViewSizetype;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblmodsize;
    }
}