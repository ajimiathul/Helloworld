namespace NewGMS
{
    partial class frmBundleView
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
            this.dgvPending = new System.Windows.Forms.DataGridView();
            this.btnPnd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCompleted = new System.Windows.Forms.DataGridView();
            this.dgvCmpColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCmpColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCmpColActivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCmpColEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCmpColEmpid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCmpColPcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCompleted = new System.Windows.Forms.CheckBox();
            this.cbPending = new System.Windows.Forms.CheckBox();
            this.cmbBundle = new System.Windows.Forms.ComboBox();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.cmbLayBNO = new System.Windows.Forms.ComboBox();
            this.dgvPndColAct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPndColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPndColcqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPndColpqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleted)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPending
            // 
            this.dgvPending.AllowUserToAddRows = false;
            this.dgvPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPndColAct,
            this.dgvPndColTotal,
            this.dgvPndColcqty,
            this.dgvPndColpqty});
            this.dgvPending.Location = new System.Drawing.Point(222, 262);
            this.dgvPending.Name = "dgvPending";
            this.dgvPending.Size = new System.Drawing.Size(673, 231);
            this.dgvPending.TabIndex = 23;
            // 
            // btnPnd
            // 
            this.btnPnd.Location = new System.Drawing.Point(20, 137);
            this.btnPnd.Name = "btnPnd";
            this.btnPnd.Size = new System.Drawing.Size(75, 23);
            this.btnPnd.TabIndex = 39;
            this.btnPnd.Text = "Show";
            this.btnPnd.UseVisualStyleBackColor = true;
            this.btnPnd.Click += new System.EventHandler(this.btnPnd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Bundle No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Style Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Lot No.";
            // 
            // dgvCompleted
            // 
            this.dgvCompleted.AllowUserToAddRows = false;
            this.dgvCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompleted.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCmpColDate,
            this.dgvCmpColTime,
            this.dgvCmpColActivity,
            this.dgvCmpColEmp,
            this.dgvCmpColEmpid,
            this.dgvCmpColPcs});
            this.dgvCompleted.Location = new System.Drawing.Point(222, 37);
            this.dgvCompleted.Name = "dgvCompleted";
            this.dgvCompleted.Size = new System.Drawing.Size(685, 201);
            this.dgvCompleted.TabIndex = 44;
            // 
            // dgvCmpColDate
            // 
            this.dgvCmpColDate.HeaderText = "Date";
            this.dgvCmpColDate.Name = "dgvCmpColDate";
            this.dgvCmpColDate.Width = 80;
            // 
            // dgvCmpColTime
            // 
            this.dgvCmpColTime.HeaderText = "Time";
            this.dgvCmpColTime.Name = "dgvCmpColTime";
            // 
            // dgvCmpColActivity
            // 
            this.dgvCmpColActivity.HeaderText = "Activity";
            this.dgvCmpColActivity.Name = "dgvCmpColActivity";
            this.dgvCmpColActivity.Width = 130;
            // 
            // dgvCmpColEmp
            // 
            this.dgvCmpColEmp.HeaderText = "Employee";
            this.dgvCmpColEmp.Name = "dgvCmpColEmp";
            this.dgvCmpColEmp.Width = 130;
            // 
            // dgvCmpColEmpid
            // 
            this.dgvCmpColEmpid.HeaderText = "EmpID";
            this.dgvCmpColEmpid.Name = "dgvCmpColEmpid";
            // 
            // dgvCmpColPcs
            // 
            this.dgvCmpColPcs.HeaderText = "Qty";
            this.dgvCmpColPcs.Name = "dgvCmpColPcs";
            this.dgvCmpColPcs.Width = 80;
            // 
            // cbCompleted
            // 
            this.cbCompleted.AutoSize = true;
            this.cbCompleted.Checked = true;
            this.cbCompleted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCompleted.Location = new System.Drawing.Point(222, 14);
            this.cbCompleted.Name = "cbCompleted";
            this.cbCompleted.Size = new System.Drawing.Size(109, 17);
            this.cbCompleted.TabIndex = 45;
            this.cbCompleted.Text = "Completed Status";
            this.cbCompleted.UseVisualStyleBackColor = true;
            // 
            // cbPending
            // 
            this.cbPending.AutoSize = true;
            this.cbPending.Location = new System.Drawing.Point(222, 244);
            this.cbPending.Name = "cbPending";
            this.cbPending.Size = new System.Drawing.Size(92, 17);
            this.cbPending.TabIndex = 46;
            this.cbPending.Text = "Bundle Status";
            this.cbPending.UseVisualStyleBackColor = true;
            // 
            // cmbBundle
            // 
            this.cmbBundle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBundle.FormattingEnabled = true;
            this.cmbBundle.Location = new System.Drawing.Point(20, 110);
            this.cmbBundle.Name = "cmbBundle";
            this.cmbBundle.Size = new System.Drawing.Size(109, 21);
            this.cmbBundle.TabIndex = 51;
            this.cmbBundle.SelectedIndexChanged += new System.EventHandler(this.cmbBundle_SelectedIndexChanged);
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(20, 30);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(188, 21);
            this.cmbStyle.TabIndex = 50;
            this.cmbStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // cmbLayBNO
            // 
            this.cmbLayBNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayBNO.FormattingEnabled = true;
            this.cmbLayBNO.Location = new System.Drawing.Point(20, 70);
            this.cmbLayBNO.Name = "cmbLayBNO";
            this.cmbLayBNO.Size = new System.Drawing.Size(109, 21);
            this.cmbLayBNO.TabIndex = 49;
            this.cmbLayBNO.SelectedIndexChanged += new System.EventHandler(this.cmbLayBNO_SelectedIndexChanged);
            // 
            // dgvPndColAct
            // 
            this.dgvPndColAct.HeaderText = "Activity";
            this.dgvPndColAct.Name = "dgvPndColAct";
            this.dgvPndColAct.Width = 160;
            // 
            // dgvPndColTotal
            // 
            this.dgvPndColTotal.HeaderText = "Total";
            this.dgvPndColTotal.Name = "dgvPndColTotal";
            // 
            // dgvPndColcqty
            // 
            this.dgvPndColcqty.HeaderText = "Completed";
            this.dgvPndColcqty.Name = "dgvPndColcqty";
            // 
            // dgvPndColpqty
            // 
            this.dgvPndColpqty.HeaderText = "Balance";
            this.dgvPndColpqty.Name = "dgvPndColpqty";
            // 
            // frmBundleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 517);
            this.Controls.Add(this.cmbBundle);
            this.Controls.Add(this.cmbStyle);
            this.Controls.Add(this.cmbLayBNO);
            this.Controls.Add(this.cbPending);
            this.Controls.Add(this.cbCompleted);
            this.Controls.Add(this.dgvCompleted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPending);
            this.Name = "frmBundleView";
            this.Text = "frmBundleView";
            this.Load += new System.EventHandler(this.frmBundleView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPending;
        private System.Windows.Forms.Button btnPnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCompleted;
        private System.Windows.Forms.CheckBox cbCompleted;
        private System.Windows.Forms.CheckBox cbPending;
        private System.Windows.Forms.ComboBox cmbBundle;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.ComboBox cmbLayBNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCmpColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCmpColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCmpColActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCmpColEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCmpColEmpid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCmpColPcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPndColAct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPndColTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPndColcqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPndColpqty;
    }
}