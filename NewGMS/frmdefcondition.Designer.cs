namespace NewGMS
{
    partial class frmdefcondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdefcondition));
            this.flexGridDefCon = new FlexCell.Grid();
            this.btnselect = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flexGridDefCon
            // 
            this.flexGridDefCon.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("flexGridDefCon.CheckedImage")));
            this.flexGridDefCon.Cols = 3;
            this.flexGridDefCon.Location = new System.Drawing.Point(40, 45);
            this.flexGridDefCon.Name = "flexGridDefCon";
            this.flexGridDefCon.Size = new System.Drawing.Size(582, 234);
            this.flexGridDefCon.TabIndex = 0;
            this.flexGridDefCon.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("flexGridDefCon.UncheckedImage")));
            // 
            // btnselect
            // 
            this.btnselect.Location = new System.Drawing.Point(451, 340);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 1;
            this.btnselect.Text = "Select";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(562, 340);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 2;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmdefcondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 451);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnselect);
            this.Controls.Add(this.flexGridDefCon);
            this.Name = "frmdefcondition";
            this.Text = "frmdefcondition";
            this.Load += new System.EventHandler(this.frmdefcondition_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlexCell.Grid flexGridDefCon;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Button btnclose;
    }
}