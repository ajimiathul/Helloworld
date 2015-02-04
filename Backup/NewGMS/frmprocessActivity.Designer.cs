namespace NewGMS
{
    partial class frmprocessActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmprocessActivity));
            this.grid1 = new FlexCell.Grid();
            this.lblstylecode = new System.Windows.Forms.Label();
            this.cmbstylecode = new System.Windows.Forms.ComboBox();
            this.btsave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 4;
            this.grid1.Location = new System.Drawing.Point(28, 106);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 1;
            this.grid1.Size = new System.Drawing.Size(593, 304);
            this.grid1.TabIndex = 0;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.FgridprocAct_Click);
            // 
            // lblstylecode
            // 
            this.lblstylecode.AutoSize = true;
            this.lblstylecode.Location = new System.Drawing.Point(115, 54);
            this.lblstylecode.Name = "lblstylecode";
            this.lblstylecode.Size = new System.Drawing.Size(55, 13);
            this.lblstylecode.TabIndex = 1;
            this.lblstylecode.Text = "StyleCode";
            // 
            // cmbstylecode
            // 
            this.cmbstylecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstylecode.FormattingEnabled = true;
            this.cmbstylecode.Location = new System.Drawing.Point(215, 46);
            this.cmbstylecode.Name = "cmbstylecode";
            this.cmbstylecode.Size = new System.Drawing.Size(159, 21);
            this.cmbstylecode.TabIndex = 2;
            this.cmbstylecode.SelectedIndexChanged += new System.EventHandler(this.cmbstylecode_SelectedIndexChanged);
            //this.cmbstylecode.ValueMemberChanged += new System.EventHandler(this.cmbstylecode_ValueMemberChanged);
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(361, 462);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(60, 23);
            this.btsave.TabIndex = 3;
            this.btsave.Text = "Save";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmprocessActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 528);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.cmbstylecode);
            this.Controls.Add(this.lblstylecode);
            this.Controls.Add(this.grid1);
            this.Name = "frmprocessActivity";
            this.Text = "frmprocessActivity";
            this.Load += new System.EventHandler(this.frmprocessActivity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlexCell.Grid grid1;
        private System.Windows.Forms.Label lblstylecode;
        private System.Windows.Forms.ComboBox cmbstylecode;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Button button1;
    }
}