namespace NewGMS
{
    partial class frmLayerCutDelete
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colLayerBatNo = new System.Windows.Forms.ColumnHeader();
            this.colBundleRange = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.btnShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 356);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(12, 46);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(121, 21);
            this.cmbStyle.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLayerBatNo,
            this.colBundleRange,
            this.colStatus});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 95);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(448, 233);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            // 
            // colLayerBatNo
            // 
            this.colLayerBatNo.Text = "LotNo";
            this.colLayerBatNo.Width = 100;
            // 
            // colBundleRange
            // 
            this.colBundleRange.Text = "Bundle Start";
            this.colBundleRange.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Bundle End";
            this.colStatus.Width = 200;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(139, 46);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // frmLayerCutDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 441);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbStyle);
            this.Name = "frmLayerCutDelete";
            this.Text = "Layer Cut Delete";
            this.Load += new System.EventHandler(this.frmLayerCutDelete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colLayerBatNo;
        private System.Windows.Forms.ColumnHeader colBundleRange;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnShow;
    }
}