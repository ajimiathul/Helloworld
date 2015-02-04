namespace NewGMS
{
    partial class frmUserMenuSelect
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
            this.btnSave = new System.Windows.Forms.Button();
            this.clbMenu = new System.Windows.Forms.CheckedListBox();
            this.ltbMenuId = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(65, 32);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(193, 21);
            this.cmbUser.TabIndex = 0;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(123, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // clbMenu
            // 
            this.clbMenu.CheckOnClick = true;
            this.clbMenu.FormattingEnabled = true;
            this.clbMenu.Location = new System.Drawing.Point(47, 70);
            this.clbMenu.Name = "clbMenu";
            this.clbMenu.Size = new System.Drawing.Size(247, 349);
            this.clbMenu.TabIndex = 3;
            // 
            // ltbMenuId
            // 
            this.ltbMenuId.FormattingEnabled = true;
            this.ltbMenuId.Location = new System.Drawing.Point(138, 110);
            this.ltbMenuId.Name = "ltbMenuId";
            this.ltbMenuId.Size = new System.Drawing.Size(120, 95);
            this.ltbMenuId.TabIndex = 4;
            this.ltbMenuId.Visible = false;
            // 
            // frmUserMenuSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 477);
            this.Controls.Add(this.clbMenu);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.ltbMenuId);
            this.Name = "frmUserMenuSelect";
            this.Text = "frmUserMenuSelect";
            this.Load += new System.EventHandler(this.frmUserMenuSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox clbMenu;
        private System.Windows.Forms.ListBox ltbMenuId;
    }
}