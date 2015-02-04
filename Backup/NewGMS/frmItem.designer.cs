namespace NewGMS
{
    partial class frmItem
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
            this.cmbSup = new System.Windows.Forms.ComboBox();
            this.txtFabName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFabCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSup
            // 
            this.cmbSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSup.FormattingEnabled = true;
            this.cmbSup.Location = new System.Drawing.Point(393, 48);
            this.cmbSup.Name = "cmbSup";
            this.cmbSup.Size = new System.Drawing.Size(121, 21);
            this.cmbSup.TabIndex = 0;
            // 
            // txtFabName
            // 
            this.txtFabName.Location = new System.Drawing.Point(134, 91);
            this.txtFabName.Name = "txtFabName";
            this.txtFabName.Size = new System.Drawing.Size(121, 20);
            this.txtFabName.TabIndex = 1;
            this.txtFabName.TextChanged += new System.EventHandler(this.txtStyleName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fabric Code";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(221, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(55, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(282, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(90, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(685, 314);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(159, 163);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 23);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(89, 163);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 23);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            // 
            // txtFabCode
            // 
            this.txtFabCode.Location = new System.Drawing.Point(134, 50);
            this.txtFabCode.Name = "txtFabCode";
            this.txtFabCode.Size = new System.Drawing.Size(121, 20);
            this.txtFabCode.TabIndex = 21;
            this.txtFabCode.TextChanged += new System.EventHandler(this.txtFabCode_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fabric Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Colour";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(393, 94);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(121, 20);
            this.txtColor.TabIndex = 23;
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 606);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFabCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFabName);
            this.Controls.Add(this.cmbSup);
            this.Name = "frmItem";
            this.Text = "Fabric";
            this.Load += new System.EventHandler(this.frmStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSup;
        private System.Windows.Forms.TextBox txtFabName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFabCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColor;
    }
}