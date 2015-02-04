namespace NewGMS
{
    partial class frPrintTag
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
            this.cmbLetters = new System.Windows.Forms.ComboBox();
            this.cmbParts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBunFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBunTo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbLetters
            // 
            this.cmbLetters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLetters.FormattingEnabled = true;
            this.cmbLetters.Location = new System.Drawing.Point(188, 61);
            this.cmbLetters.Name = "cmbLetters";
            this.cmbLetters.Size = new System.Drawing.Size(121, 21);
            this.cmbLetters.TabIndex = 0;
            this.cmbLetters.SelectedIndexChanged += new System.EventHandler(this.cmbLetters_SelectedIndexChanged);
            // 
            // cmbParts
            // 
            this.cmbParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParts.FormattingEnabled = true;
            this.cmbParts.Location = new System.Drawing.Point(190, 109);
            this.cmbParts.Name = "cmbParts";
            this.cmbParts.Size = new System.Drawing.Size(121, 21);
            this.cmbParts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parts";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(197, 198);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bundle No From";
            // 
            // txtBunFrom
            // 
            this.txtBunFrom.Location = new System.Drawing.Point(192, 152);
            this.txtBunFrom.Name = "txtBunFrom";
            this.txtBunFrom.Size = new System.Drawing.Size(100, 20);
            this.txtBunFrom.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // txtBunTo
            // 
            this.txtBunTo.Location = new System.Drawing.Point(332, 150);
            this.txtBunTo.Name = "txtBunTo";
            this.txtBunTo.Size = new System.Drawing.Size(100, 20);
            this.txtBunTo.TabIndex = 8;
            // 
            // frPrintTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 262);
            this.Controls.Add(this.txtBunTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBunFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbParts);
            this.Controls.Add(this.cmbLetters);
            this.Name = "frPrintTag";
            this.Text = "Tag Print";
            this.Load += new System.EventHandler(this.frPrintTag_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLetters;
        private System.Windows.Forms.ComboBox cmbParts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBunFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBunTo;
    }
}