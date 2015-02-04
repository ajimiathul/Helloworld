namespace NewGMS
{
    partial class frmAccMaster
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
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbGrpAcc = new System.Windows.Forms.GroupBox();
            this.rbAccnt = new System.Windows.Forms.RadioButton();
            this.rbGrp = new System.Windows.Forms.RadioButton();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.cmbUnder = new System.Windows.Forms.ComboBox();
            this.cmbAccNature = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOpBal = new System.Windows.Forms.TextBox();
            this.rbDebit = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.gbGrpAcc.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAccCode
            // 
            this.txtAccCode.Location = new System.Drawing.Point(137, 315);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.ReadOnly = true;
            this.txtAccCode.Size = new System.Drawing.Size(121, 20);
            this.txtAccCode.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Account Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Under";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nature";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Account Name";
            // 
            // gbGrpAcc
            // 
            this.gbGrpAcc.Controls.Add(this.rbAccnt);
            this.gbGrpAcc.Controls.Add(this.rbGrp);
            this.gbGrpAcc.Location = new System.Drawing.Point(137, 65);
            this.gbGrpAcc.Name = "gbGrpAcc";
            this.gbGrpAcc.Size = new System.Drawing.Size(215, 50);
            this.gbGrpAcc.TabIndex = 12;
            this.gbGrpAcc.TabStop = false;
            // 
            // rbAccnt
            // 
            this.rbAccnt.AutoSize = true;
            this.rbAccnt.Checked = true;
            this.rbAccnt.Location = new System.Drawing.Point(6, 19);
            this.rbAccnt.Name = "rbAccnt";
            this.rbAccnt.Size = new System.Drawing.Size(65, 17);
            this.rbAccnt.TabIndex = 1;
            this.rbAccnt.TabStop = true;
            this.rbAccnt.Text = "Account";
            this.rbAccnt.UseVisualStyleBackColor = true;
            this.rbAccnt.CheckedChanged += new System.EventHandler(this.rbAccnt_CheckedChanged);
            // 
            // rbGrp
            // 
            this.rbGrp.AutoSize = true;
            this.rbGrp.Location = new System.Drawing.Point(121, 19);
            this.rbGrp.Name = "rbGrp";
            this.rbGrp.Size = new System.Drawing.Size(54, 17);
            this.rbGrp.TabIndex = 0;
            this.rbGrp.Text = "Group";
            this.rbGrp.UseVisualStyleBackColor = true;
            this.rbGrp.CheckedChanged += new System.EventHandler(this.rbGrp_CheckedChanged);
            // 
            // txtAccName
            // 
            this.txtAccName.Location = new System.Drawing.Point(137, 188);
            this.txtAccName.MaxLength = 50;
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.Size = new System.Drawing.Size(215, 20);
            this.txtAccName.TabIndex = 10;
            // 
            // cmbUnder
            // 
            this.cmbUnder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnder.FormattingEnabled = true;
            this.cmbUnder.Location = new System.Drawing.Point(137, 135);
            this.cmbUnder.Name = "cmbUnder";
            this.cmbUnder.Size = new System.Drawing.Size(121, 21);
            this.cmbUnder.TabIndex = 13;
            // 
            // cmbAccNature
            // 
            this.cmbAccNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccNature.FormattingEnabled = true;
            this.cmbAccNature.Location = new System.Drawing.Point(137, 28);
            this.cmbAccNature.Name = "cmbAccNature";
            this.cmbAccNature.Size = new System.Drawing.Size(121, 21);
            this.cmbAccNature.TabIndex = 9;
            this.cmbAccNature.SelectedIndexChanged += new System.EventHandler(this.cmbAccNature_SelectedIndexChanged);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(401, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(536, 455);
            this.treeView1.TabIndex = 18;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(137, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOpBal
            // 
            this.txtOpBal.Location = new System.Drawing.Point(137, 234);
            this.txtOpBal.MaxLength = 50;
            this.txtOpBal.Name = "txtOpBal";
            this.txtOpBal.Size = new System.Drawing.Size(127, 20);
            this.txtOpBal.TabIndex = 20;
            this.txtOpBal.Text = "0.0";
            this.txtOpBal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpBal_KeyPress);
            // 
            // rbDebit
            // 
            this.rbDebit.AutoSize = true;
            this.rbDebit.Checked = true;
            this.rbDebit.Location = new System.Drawing.Point(137, 260);
            this.rbDebit.Name = "rbDebit";
            this.rbDebit.Size = new System.Drawing.Size(50, 17);
            this.rbDebit.TabIndex = 21;
            this.rbDebit.TabStop = true;
            this.rbDebit.Text = "Debit";
            this.rbDebit.UseVisualStyleBackColor = true;
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.Location = new System.Drawing.Point(137, 283);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(52, 17);
            this.rbCredit.TabIndex = 22;
            this.rbCredit.Text = "Credit";
            this.rbCredit.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Opening Bal.";
            // 
            // frmAccMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 479);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbCredit);
            this.Controls.Add(this.rbDebit);
            this.Controls.Add(this.txtOpBal);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.txtAccCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbGrpAcc);
            this.Controls.Add(this.txtAccName);
            this.Controls.Add(this.cmbUnder);
            this.Controls.Add(this.cmbAccNature);
            this.Name = "frmAccMaster";
            this.Text = "Account Master";
            this.Load += new System.EventHandler(this.frmAccMaster_Load);
            this.gbGrpAcc.ResumeLayout(false);
            this.gbGrpAcc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbGrpAcc;
        private System.Windows.Forms.RadioButton rbAccnt;
        private System.Windows.Forms.RadioButton rbGrp;
        private System.Windows.Forms.TextBox txtAccName;
        private System.Windows.Forms.ComboBox cmbUnder;
        private System.Windows.Forms.ComboBox cmbAccNature;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOpBal;
        private System.Windows.Forms.RadioButton rbDebit;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.Label label5;
    }
}