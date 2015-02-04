namespace NewGMS
{
    partial class frmEmpMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpMachine));
            this.grid1 = new FlexCell.Grid();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.CheckedImage")));
            this.grid1.Location = new System.Drawing.Point(35, 39);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(506, 316);
            this.grid1.TabIndex = 0;
            this.grid1.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("grid1.UncheckedImage")));
            this.grid1.ComboClick += new FlexCell.Grid.ComboClickEventHandler(this.grid1_ComboClick);
            this.grid1.KeyDown += new FlexCell.Grid.KeyDownEventHandler(this.grid1_KeyDown);
            this.grid1.Click += new FlexCell.Grid.ClickEventHandler(this.grid1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(346, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmEmpMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 474);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grid1);
            this.Name = "frmEmpMachine";
            this.Text = "frmEmpMachine";
            this.Load += new System.EventHandler(this.frmEmpMachine_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlexCell.Grid grid1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
    }
}