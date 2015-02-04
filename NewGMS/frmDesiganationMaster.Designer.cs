namespace NewGMS
{
    partial class frmDesiganationMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesiganationMaster));
            this.grid1 = new FlexCell.Grid();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 8;
            this.grid1.Location = new System.Drawing.Point(26, 41);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 1;
            this.grid1.Size = new System.Drawing.Size(1059, 318);
            this.grid1.TabIndex = 0;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.KeyDown += new FlexCell.Grid.KeyDownEventHandler(this.grid1_KeyDown);
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(672, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Update";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(782, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDesiganationMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 487);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grid1);
            this.Name = "frmDesiganationMaster";
            this.Text = "frmDesiganationMaster";
            this.Load += new System.EventHandler(this.frmDesiganationMaster_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlexCell.Grid grid1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}