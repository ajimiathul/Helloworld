namespace NewGMS
{
    partial class frmLogin
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
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCombany = new System.Windows.Forms.Label();
            this.lblOffice = new System.Windows.Forms.Label();
            this.cmbOffice = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(77, 106);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(182, 21);
            this.cmbUser.TabIndex = 0;
            this.cmbUser.DropDownClosed += new System.EventHandler(this.cmbUser_DropDownClosed);
            this.cmbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUser_KeyDown);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(77, 154);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(182, 20);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "UID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(79, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(79, 24);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(182, 21);
            this.cmbCompany.TabIndex = 6;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // lblCombany
            // 
            this.lblCombany.AutoSize = true;
            this.lblCombany.Location = new System.Drawing.Point(19, 32);
            this.lblCombany.Name = "lblCombany";
            this.lblCombany.Size = new System.Drawing.Size(51, 13);
            this.lblCombany.TabIndex = 7;
            this.lblCombany.Text = "Company";
            // 
            // lblOffice
            // 
            this.lblOffice.AutoSize = true;
            this.lblOffice.Location = new System.Drawing.Point(21, 68);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(35, 13);
            this.lblOffice.TabIndex = 7;
            this.lblOffice.Text = "Office";
            // 
            // cmbOffice
            // 
            this.cmbOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffice.FormattingEnabled = true;
            this.cmbOffice.Location = new System.Drawing.Point(79, 65);
            this.cmbOffice.Name = "cmbOffice";
            this.cmbOffice.Size = new System.Drawing.Size(182, 21);
            this.cmbOffice.TabIndex = 6;
            this.cmbOffice.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.lblOffice);
            this.Controls.Add(this.lblCombany);
            this.Controls.Add(this.cmbOffice);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.cmbUser);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCombany;
        private System.Windows.Forms.Label lblOffice;
        private System.Windows.Forms.ComboBox cmbOffice;
    }
}