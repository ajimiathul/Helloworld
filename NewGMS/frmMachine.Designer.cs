namespace NewGMS
{
    partial class frmMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachine));
            this.grid1 = new FlexCell.Grid();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Cols = 12;
            this.grid1.Location = new System.Drawing.Point(35, 40);
            this.grid1.Name = "grid1";
            this.grid1.Rows = 2;
            this.grid1.Size = new System.Drawing.Size(1021, 394);
            this.grid1.TabIndex = 0;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.Load += new System.EventHandler(this.grid1_Load);
            this.grid1.LeaveCell += new FlexCell.Grid.LeaveCellEventHandler(this.grid1_LeaveCell);
            this.grid1.KeyPress += new FlexCell.Grid.KeyPressEventHandler(this.grid1_KeyPress);
            this.grid1.KeyUp += new FlexCell.Grid.KeyUpEventHandler(this.grid1_KeyUp);
            this.grid1.HyperLinkClick += new FlexCell.Grid.HyperLinkClickEventHandler(this.grid1_HyperLinkClick);
            this.grid1.LeaveRow += new FlexCell.Grid.LeaveRowEventHandler(this.grid1_LeaveRow);
            this.grid1.KeyDown += new FlexCell.Grid.KeyDownEventHandler(this.grid1_KeyDown);
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(981, 440);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 506);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.grid1);
            this.Name = "frmMachine";
            this.Text = "frmMachine";
            this.Load += new System.EventHandler(this.frmMachine_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlexCell.Grid grid1;
        private System.Windows.Forms.Button btnclose;
    }
}