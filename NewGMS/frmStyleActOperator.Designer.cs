namespace NewGMS
{
    partial class frmStyleActOperator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStyleActOperator));
            this.btsave = new System.Windows.Forms.Button();
            this.cmbstylecode = new System.Windows.Forms.ComboBox();
            this.grid1 = new FlexCell.Grid();
            this.lblstylecode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(509, 420);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 6;
            this.btsave.Text = "Save";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // cmbstylecode
            // 
            this.cmbstylecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstylecode.FormattingEnabled = true;
            this.cmbstylecode.Location = new System.Drawing.Point(228, 26);
            this.cmbstylecode.Name = "cmbstylecode";
            this.cmbstylecode.Size = new System.Drawing.Size(121, 21);
            this.cmbstylecode.TabIndex = 5;
            this.cmbstylecode.SelectedIndexChanged += new System.EventHandler(this.cmbstylecode_SelectedIndexChanged);
            this.cmbstylecode.ValueMemberChanged += new System.EventHandler(this.cmbstylecode_ValueMemberChanged);
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 3;
            this.grid1.Location = new System.Drawing.Point(27, 63);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 1;
            this.grid1.Size = new System.Drawing.Size(613, 334);
            this.grid1.TabIndex = 4;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.Load += new System.EventHandler(this.grid1_Load);
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // lblstylecode
            // 
            this.lblstylecode.AutoSize = true;
            this.lblstylecode.Location = new System.Drawing.Point(140, 29);
            this.lblstylecode.Name = "lblstylecode";
            this.lblstylecode.Size = new System.Drawing.Size(55, 13);
            this.lblstylecode.TabIndex = 7;
            this.lblstylecode.Text = "StyleCode";
            // 
            // frmStyleActOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 475);
            this.Controls.Add(this.lblstylecode);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.cmbstylecode);
            this.Controls.Add(this.grid1);
            this.Name = "frmStyleActOperator";
            this.Text = "frmStyleActOperator";
            this.Load += new System.EventHandler(this.frmStyleActOperator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.ComboBox cmbstylecode;
        private FlexCell.Grid grid1;
        private System.Windows.Forms.Label lblstylecode;
    }
}