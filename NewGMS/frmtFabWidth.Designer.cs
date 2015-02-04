namespace NewGMS
{
    partial class frmtFabWidth
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
            this.grpbFabWidth = new System.Windows.Forms.GroupBox();
            this.lblExample = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtWidthSize = new System.Windows.Forms.TextBox();
            this.lblWidthSize = new System.Windows.Forms.Label();
            this.txtWidthName = new System.Windows.Forms.TextBox();
            this.lblWidthName = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.dataGridFabWidth = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpbFabWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFabWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbFabWidth
            // 
            this.grpbFabWidth.Controls.Add(this.lblExample);
            this.grpbFabWidth.Controls.Add(this.btnDelete);
            this.grpbFabWidth.Controls.Add(this.btnSave);
            this.grpbFabWidth.Controls.Add(this.btnNew);
            this.grpbFabWidth.Controls.Add(this.txtWidthSize);
            this.grpbFabWidth.Controls.Add(this.lblWidthSize);
            this.grpbFabWidth.Controls.Add(this.txtWidthName);
            this.grpbFabWidth.Controls.Add(this.lblWidthName);
            this.grpbFabWidth.Controls.Add(this.lblMode);
            this.grpbFabWidth.Location = new System.Drawing.Point(36, 12);
            this.grpbFabWidth.Name = "grpbFabWidth";
            this.grpbFabWidth.Size = new System.Drawing.Size(278, 164);
            this.grpbFabWidth.TabIndex = 0;
            this.grpbFabWidth.TabStop = false;
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(49, 75);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(113, 13);
            this.lblExample.TabIndex = 8;
            this.lblExample.Text = "Example:91cm/36inch";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(192, 119);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(192, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(192, 31);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtWidthSize
            // 
            this.txtWidthSize.Location = new System.Drawing.Point(52, 138);
            this.txtWidthSize.Name = "txtWidthSize";
            this.txtWidthSize.Size = new System.Drawing.Size(100, 20);
            this.txtWidthSize.TabIndex = 4;
            // 
            // lblWidthSize
            // 
            this.lblWidthSize.AutoSize = true;
            this.lblWidthSize.Location = new System.Drawing.Point(27, 109);
            this.lblWidthSize.Name = "lblWidthSize";
            this.lblWidthSize.Size = new System.Drawing.Size(58, 13);
            this.lblWidthSize.TabIndex = 2;
            this.lblWidthSize.Text = "Width Size";
            // 
            // txtWidthName
            // 
            this.txtWidthName.Location = new System.Drawing.Point(52, 52);
            this.txtWidthName.Name = "txtWidthName";
            this.txtWidthName.Size = new System.Drawing.Size(100, 20);
            this.txtWidthName.TabIndex = 3;
            // 
            // lblWidthName
            // 
            this.lblWidthName.AutoSize = true;
            this.lblWidthName.Location = new System.Drawing.Point(27, 19);
            this.lblWidthName.Name = "lblWidthName";
            this.lblWidthName.Size = new System.Drawing.Size(66, 13);
            this.lblWidthName.TabIndex = 2;
            this.lblWidthName.Text = "Width Name";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(-3, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Mode";
            // 
            // dataGridFabWidth
            // 
            this.dataGridFabWidth.AllowUserToAddRows = false;
            this.dataGridFabWidth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridFabWidth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFabWidth.Location = new System.Drawing.Point(36, 182);
            this.dataGridFabWidth.Name = "dataGridFabWidth";
            this.dataGridFabWidth.Size = new System.Drawing.Size(278, 259);
            this.dataGridFabWidth.TabIndex = 1;
            this.dataGridFabWidth.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFabWidth_CellDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(135, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmtFabWidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 491);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridFabWidth);
            this.Controls.Add(this.grpbFabWidth);
            this.Name = "frmtFabWidth";
            this.Text = "frmtFabWidth";
            this.Load += new System.EventHandler(this.frmtFabWidth_Load);
            this.grpbFabWidth.ResumeLayout(false);
            this.grpbFabWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFabWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbFabWidth;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.DataGridView dataGridFabWidth;
        private System.Windows.Forms.TextBox txtWidthName;
        private System.Windows.Forms.Label lblWidthName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtWidthSize;
        private System.Windows.Forms.Label lblWidthSize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblExample;
    }
}