namespace NewGMS
{
    partial class frmFinishedProductsInward
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
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.cmbSleeve = new System.Windows.Forms.ComboBox();
            this.cmbFit = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Entry = new System.Windows.Forms.TabPage();
            this.txtrecid = new System.Windows.Forms.TextBox();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.btnStock = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtR44 = new System.Windows.Forms.TextBox();
            this.txtQ44 = new System.Windows.Forms.TextBox();
            this.txtR42 = new System.Windows.Forms.TextBox();
            this.txtQ42 = new System.Windows.Forms.TextBox();
            this.txtR40 = new System.Windows.Forms.TextBox();
            this.txtQ40 = new System.Windows.Forms.TextBox();
            this.txtR38 = new System.Windows.Forms.TextBox();
            this.txtQ38 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFCode = new System.Windows.Forms.TextBox();
            this.History = new System.Windows.Forms.TabPage();
            this.btnShowInward = new System.Windows.Forms.Button();
            this.dgvInward = new System.Windows.Forms.DataGridView();
            this.Stock = new System.Windows.Forms.TabPage();
            this.dgvViewStock = new System.Windows.Forms.DataGridView();
            this.btnViewStock = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Entry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInward)).BeginInit();
            this.Stock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStock)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(219, 13);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(171, 21);
            this.cmbWarehouse.TabIndex = 0;
            // 
            // dtpEntry
            // 
            this.dtpEntry.CustomFormat = "dd/MM/yyyy";
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntry.Location = new System.Drawing.Point(219, 45);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(171, 20);
            this.dtpEntry.TabIndex = 1;
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(219, 86);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(171, 21);
            this.cmbStyle.TabIndex = 2;
            // 
            // cmbSleeve
            // 
            this.cmbSleeve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSleeve.FormattingEnabled = true;
            this.cmbSleeve.Location = new System.Drawing.Point(219, 144);
            this.cmbSleeve.Name = "cmbSleeve";
            this.cmbSleeve.Size = new System.Drawing.Size(171, 21);
            this.cmbSleeve.TabIndex = 3;
            // 
            // cmbFit
            // 
            this.cmbFit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFit.FormattingEnabled = true;
            this.cmbFit.Location = new System.Drawing.Point(219, 177);
            this.cmbFit.Name = "cmbFit";
            this.cmbFit.Size = new System.Drawing.Size(171, 21);
            this.cmbFit.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Entry);
            this.tabControl1.Controls.Add(this.History);
            this.tabControl1.Controls.Add(this.Stock);
            this.tabControl1.Location = new System.Drawing.Point(32, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1208, 442);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // Entry
            // 
            this.Entry.Controls.Add(this.txtrecid);
            this.Entry.Controls.Add(this.dgvStock);
            this.Entry.Controls.Add(this.btnStock);
            this.Entry.Controls.Add(this.label13);
            this.Entry.Controls.Add(this.label12);
            this.Entry.Controls.Add(this.label11);
            this.Entry.Controls.Add(this.label10);
            this.Entry.Controls.Add(this.label9);
            this.Entry.Controls.Add(this.label8);
            this.Entry.Controls.Add(this.label7);
            this.Entry.Controls.Add(this.txtR44);
            this.Entry.Controls.Add(this.txtQ44);
            this.Entry.Controls.Add(this.txtR42);
            this.Entry.Controls.Add(this.txtQ42);
            this.Entry.Controls.Add(this.txtR40);
            this.Entry.Controls.Add(this.txtQ40);
            this.Entry.Controls.Add(this.txtR38);
            this.Entry.Controls.Add(this.txtQ38);
            this.Entry.Controls.Add(this.label6);
            this.Entry.Controls.Add(this.label5);
            this.Entry.Controls.Add(this.label4);
            this.Entry.Controls.Add(this.label3);
            this.Entry.Controls.Add(this.label2);
            this.Entry.Controls.Add(this.label1);
            this.Entry.Controls.Add(this.txtFCode);
            this.Entry.Controls.Add(this.cmbFit);
            this.Entry.Controls.Add(this.cmbWarehouse);
            this.Entry.Controls.Add(this.cmbSleeve);
            this.Entry.Controls.Add(this.dtpEntry);
            this.Entry.Controls.Add(this.cmbStyle);
            this.Entry.Location = new System.Drawing.Point(4, 22);
            this.Entry.Name = "Entry";
            this.Entry.Padding = new System.Windows.Forms.Padding(3);
            this.Entry.Size = new System.Drawing.Size(1200, 416);
            this.Entry.TabIndex = 0;
            this.Entry.Text = "Entry";
            this.Entry.UseVisualStyleBackColor = true;
            this.Entry.Click += new System.EventHandler(this.Entry_Click);
            // 
            // txtrecid
            // 
            this.txtrecid.Location = new System.Drawing.Point(102, 210);
            this.txtrecid.Name = "txtrecid";
            this.txtrecid.Size = new System.Drawing.Size(55, 20);
            this.txtrecid.TabIndex = 29;
            this.txtrecid.Visible = false;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(445, 207);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.Size = new System.Drawing.Size(725, 193);
            this.dgvStock.TabIndex = 28;
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(219, 207);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(75, 23);
            this.btnStock.TabIndex = 27;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(226, 263);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "MRP";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(315, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Quantity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 365);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "44";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "42";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "40";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "38";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Size";
            // 
            // txtR44
            // 
            this.txtR44.Location = new System.Drawing.Point(229, 362);
            this.txtR44.Name = "txtR44";
            this.txtR44.Size = new System.Drawing.Size(72, 20);
            this.txtR44.TabIndex = 18;
            this.txtR44.Text = "0";
            this.txtR44.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtR44_KeyDown);
            this.txtR44.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtR44_KeyPress);
            // 
            // txtQ44
            // 
            this.txtQ44.Location = new System.Drawing.Point(318, 365);
            this.txtQ44.Name = "txtQ44";
            this.txtQ44.Size = new System.Drawing.Size(72, 20);
            this.txtQ44.TabIndex = 19;
            this.txtQ44.Text = "0";
            this.txtQ44.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQ44_KeyPress);
            // 
            // txtR42
            // 
            this.txtR42.Location = new System.Drawing.Point(229, 336);
            this.txtR42.Name = "txtR42";
            this.txtR42.Size = new System.Drawing.Size(72, 20);
            this.txtR42.TabIndex = 16;
            this.txtR42.Text = "0";
            this.txtR42.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtR42_KeyDown);
            this.txtR42.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtR42_KeyPress);
            // 
            // txtQ42
            // 
            this.txtQ42.Location = new System.Drawing.Point(318, 339);
            this.txtQ42.Name = "txtQ42";
            this.txtQ42.Size = new System.Drawing.Size(72, 20);
            this.txtQ42.TabIndex = 17;
            this.txtQ42.Text = "0";
            this.txtQ42.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQ42_KeyDown);
            this.txtQ42.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQ42_KeyPress);
            // 
            // txtR40
            // 
            this.txtR40.Location = new System.Drawing.Point(229, 310);
            this.txtR40.Name = "txtR40";
            this.txtR40.Size = new System.Drawing.Size(72, 20);
            this.txtR40.TabIndex = 14;
            this.txtR40.Text = "0";
            this.txtR40.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtR40_KeyDown);
            this.txtR40.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtR40_KeyPress);
            // 
            // txtQ40
            // 
            this.txtQ40.Location = new System.Drawing.Point(318, 313);
            this.txtQ40.Name = "txtQ40";
            this.txtQ40.Size = new System.Drawing.Size(72, 20);
            this.txtQ40.TabIndex = 15;
            this.txtQ40.Text = "0";
            this.txtQ40.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQ40_KeyDown);
            this.txtQ40.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQ40_KeyPress);
            // 
            // txtR38
            // 
            this.txtR38.Location = new System.Drawing.Point(229, 284);
            this.txtR38.Name = "txtR38";
            this.txtR38.Size = new System.Drawing.Size(72, 20);
            this.txtR38.TabIndex = 12;
            this.txtR38.Text = "0";
            this.txtR38.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtR38_KeyDown);
            this.txtR38.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtR38_KeyPress);
            // 
            // txtQ38
            // 
            this.txtQ38.Location = new System.Drawing.Point(318, 287);
            this.txtQ38.Name = "txtQ38";
            this.txtQ38.Size = new System.Drawing.Size(72, 20);
            this.txtQ38.TabIndex = 13;
            this.txtQ38.Text = "0";
            this.txtQ38.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQ38_KeyDown);
            this.txtQ38.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQ38_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sleeve";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fabric Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Entry Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Warehouse";
            // 
            // txtFCode
            // 
            this.txtFCode.Location = new System.Drawing.Point(219, 113);
            this.txtFCode.Name = "txtFCode";
            this.txtFCode.Size = new System.Drawing.Size(171, 20);
            this.txtFCode.TabIndex = 5;
            // 
            // History
            // 
            this.History.Controls.Add(this.btnShowInward);
            this.History.Controls.Add(this.dgvInward);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(1200, 416);
            this.History.TabIndex = 1;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = true;
            // 
            // btnShowInward
            // 
            this.btnShowInward.Location = new System.Drawing.Point(6, 37);
            this.btnShowInward.Name = "btnShowInward";
            this.btnShowInward.Size = new System.Drawing.Size(75, 23);
            this.btnShowInward.TabIndex = 30;
            this.btnShowInward.Text = "Show";
            this.btnShowInward.UseVisualStyleBackColor = true;
            this.btnShowInward.Click += new System.EventHandler(this.btnShowInward_Click);
            // 
            // dgvInward
            // 
            this.dgvInward.AllowUserToAddRows = false;
            this.dgvInward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInward.Location = new System.Drawing.Point(6, 66);
            this.dgvInward.Name = "dgvInward";
            this.dgvInward.Size = new System.Drawing.Size(1188, 319);
            this.dgvInward.TabIndex = 29;
            this.dgvInward.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInward_CellDoubleClick);
            // 
            // Stock
            // 
            this.Stock.Controls.Add(this.dgvViewStock);
            this.Stock.Controls.Add(this.btnViewStock);
            this.Stock.Location = new System.Drawing.Point(4, 22);
            this.Stock.Name = "Stock";
            this.Stock.Size = new System.Drawing.Size(1200, 416);
            this.Stock.TabIndex = 2;
            this.Stock.Text = "View Stock";
            this.Stock.UseVisualStyleBackColor = true;
            // 
            // dgvViewStock
            // 
            this.dgvViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewStock.Location = new System.Drawing.Point(89, 81);
            this.dgvViewStock.Name = "dgvViewStock";
            this.dgvViewStock.Size = new System.Drawing.Size(1049, 299);
            this.dgvViewStock.TabIndex = 1;
            // 
            // btnViewStock
            // 
            this.btnViewStock.Location = new System.Drawing.Point(22, 32);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(130, 26);
            this.btnViewStock.TabIndex = 0;
            this.btnViewStock.Text = "View Stock";
            this.btnViewStock.UseVisualStyleBackColor = true;
            this.btnViewStock.Click += new System.EventHandler(this.btnViewStock_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(489, 499);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 28;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(381, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(592, 499);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 29;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmFinishedProductsInward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 534);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmFinishedProductsInward";
            this.Text = "10";
            this.Load += new System.EventHandler(this.frmFinishedProductsInward_Load);
            this.tabControl1.ResumeLayout(false);
            this.Entry.ResumeLayout(false);
            this.Entry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.History.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInward)).EndInit();
            this.Stock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.ComboBox cmbSleeve;
        private System.Windows.Forms.ComboBox cmbFit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Entry;
        private System.Windows.Forms.TextBox txtFCode;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQ38;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtR44;
        private System.Windows.Forms.TextBox txtQ44;
        private System.Windows.Forms.TextBox txtR42;
        private System.Windows.Forms.TextBox txtQ42;
        private System.Windows.Forms.TextBox txtR40;
        private System.Windows.Forms.TextBox txtQ40;
        private System.Windows.Forms.TextBox txtR38;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnShowInward;
        private System.Windows.Forms.DataGridView dgvInward;
        private System.Windows.Forms.TextBox txtrecid;
        private System.Windows.Forms.TabPage Stock;
        private System.Windows.Forms.DataGridView dgvViewStock;
        private System.Windows.Forms.Button btnViewStock;
    }
}