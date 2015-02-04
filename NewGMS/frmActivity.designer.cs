namespace NewGMS
{
    partial class frmActivity
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
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShortActivityname = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.cmbSubCat = new System.Windows.Forms.ComboBox();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSubCatFilter = new System.Windows.Forms.CheckBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(409, 99);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(121, 21);
            this.cmbUnit.TabIndex = 0;
            // 
            // txtActivity
            // 
            this.txtActivity.Location = new System.Drawing.Point(93, 57);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(244, 20);
            this.txtActivity.TabIndex = 1;
            this.txtActivity.TextChanged += new System.EventHandler(this.txtStyleName_TextChanged);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(968, 324);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 19);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Activity";
            // 
            // txtShortActivityname
            // 
            this.txtShortActivityname.Location = new System.Drawing.Point(93, 99);
            this.txtShortActivityname.MaxLength = 15;
            this.txtShortActivityname.Name = "txtShortActivityname";
            this.txtShortActivityname.Size = new System.Drawing.Size(244, 20);
            this.txtShortActivityname.TabIndex = 23;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(409, 58);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(121, 20);
            this.txtUnitPrice.TabIndex = 24;
            // 
            // cmbSubCat
            // 
            this.cmbSubCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubCat.FormattingEnabled = true;
            this.cmbSubCat.Location = new System.Drawing.Point(595, 58);
            this.cmbSubCat.Name = "cmbSubCat";
            this.cmbSubCat.Size = new System.Drawing.Size(121, 21);
            this.cmbSubCat.TabIndex = 25;
            this.cmbSubCat.SelectedIndexChanged += new System.EventHandler(this.cmbSubCat_SelectedIndexChanged);
            // 
            // cmbOrder
            // 
            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Location = new System.Drawing.Point(595, 99);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(121, 21);
            this.cmbOrder.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Activity Short Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Unit Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Unit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(592, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "SubCategory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(592, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "OrderNo";
            // 
            // cbSubCatFilter
            // 
            this.cbSubCatFilter.AutoSize = true;
            this.cbSubCatFilter.Checked = true;
            this.cbSubCatFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubCatFilter.Location = new System.Drawing.Point(92, 217);
            this.cbSubCatFilter.Name = "cbSubCatFilter";
            this.cbSubCatFilter.Size = new System.Drawing.Size(114, 17);
            this.cbSubCatFilter.TabIndex = 32;
            this.cbSubCatFilter.Text = "Sub Catgeory Only\r\n";
            this.cbSubCatFilter.UseVisualStyleBackColor = true;
            this.cbSubCatFilter.CheckedChanged += new System.EventHandler(this.cbSubCatFilter_CheckedChanged);
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(765, 56);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(196, 21);
            this.cmbOperator.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(762, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Operator";
            // 
            // frmActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 606);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.cbSubCatFilter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOrder);
            this.Controls.Add(this.cmbSubCat);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtShortActivityname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtActivity);
            this.Controls.Add(this.cmbUnit);
            this.Name = "frmActivity";
            this.Text = "Activity";
            this.Load += new System.EventHandler(this.frmStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.TextBox txtActivity;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShortActivityname;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.ComboBox cmbSubCat;
        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbSubCatFilter;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Label label9;
    }
}