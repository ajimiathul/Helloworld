namespace NewGMS
{
    partial class frmProductionModifications
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
            this.cmbLayBNO = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.lvBundle = new System.Windows.Forms.ListView();
            this.ColName = new System.Windows.Forms.ColumnHeader();
            this.ColID = new System.Windows.Forms.ColumnHeader();
            this.ColDate = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.ColQty = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBundle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbLayBNO
            // 
            this.cmbLayBNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayBNO.FormattingEnabled = true;
            this.cmbLayBNO.Location = new System.Drawing.Point(296, 32);
            this.cmbLayBNO.Name = "cmbLayBNO";
            this.cmbLayBNO.Size = new System.Drawing.Size(101, 21);
            this.cmbLayBNO.TabIndex = 36;
            this.cmbLayBNO.SelectedIndexChanged += new System.EventHandler(this.cmbLayBNO_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Lot No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Bundle No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Activity";
            // 
            // cmbActivity
            // 
            this.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Location = new System.Drawing.Point(294, 85);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(300, 21);
            this.cmbActivity.TabIndex = 37;
            // 
            // lvBundle
            // 
            this.lvBundle.CheckBoxes = true;
            this.lvBundle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColID,
            this.ColDate,
            this.colTime,
            this.ColQty,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvBundle.FullRowSelect = true;
            this.lvBundle.GridLines = true;
            this.lvBundle.Location = new System.Drawing.Point(19, 193);
            this.lvBundle.Name = "lvBundle";
            this.lvBundle.Size = new System.Drawing.Size(765, 220);
            this.lvBundle.TabIndex = 39;
            this.lvBundle.UseCompatibleStateImageBehavior = false;
            this.lvBundle.View = System.Windows.Forms.View.Details;
            // 
            // ColName
            // 
            this.ColName.Text = "Name";
            this.ColName.Width = 170;
            // 
            // ColID
            // 
            this.ColID.Text = "ID";
            // 
            // ColDate
            // 
            this.ColDate.Text = "Date";
            this.ColDate.Width = 120;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 120;
            // 
            // ColQty
            // 
            this.ColQty.Text = "QTY";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BundleNo";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "LotNo";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "StyleNo";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "RecID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ActivityCode";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(514, 122);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 40;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(786, 455);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(69, 23);
            this.btnReverse.TabIndex = 41;
            this.btnReverse.Text = "Delete";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(102, 32);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(86, 21);
            this.cmbStyle.TabIndex = 42;
            this.cmbStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Style";
            // 
            // cmbBundle
            // 
            this.cmbBundle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBundle.FormattingEnabled = true;
            this.cmbBundle.Location = new System.Drawing.Point(488, 32);
            this.cmbBundle.Name = "cmbBundle";
            this.cmbBundle.Size = new System.Drawing.Size(101, 21);
            this.cmbBundle.TabIndex = 44;
            // 
            // frmProductionModifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 504);
            this.Controls.Add(this.cmbBundle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStyle);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.lvBundle);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbActivity);
            this.Controls.Add(this.cmbLayBNO);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Name = "frmProductionModifications";
            this.Text = "Production Modification";
            this.Load += new System.EventHandler(this.frmProductionModifications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLayBNO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.ListView lvBundle;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBundle;
        private System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader ColID;
        private System.Windows.Forms.ColumnHeader ColDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader ColQty;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}