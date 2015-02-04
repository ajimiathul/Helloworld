namespace NewGMS
{
    partial class HolidayEntry
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
            this.components = new System.ComponentModel.Container();
            this.lblholiday = new System.Windows.Forms.Label();
            this.lvholiday = new System.Windows.Forms.ListView();
            this.colSlno = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colDay = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.colMonth = new System.Windows.Forms.ColumnHeader();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblremark = new System.Windows.Forms.Label();
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.btsave = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.lblmode = new System.Windows.Forms.Label();
            this.lblmodechange = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.update = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btcancel = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblholiday
            // 
            this.lblholiday.AutoSize = true;
            this.lblholiday.Location = new System.Drawing.Point(482, 9);
            this.lblholiday.Name = "lblholiday";
            this.lblholiday.Size = new System.Drawing.Size(73, 13);
            this.lblholiday.TabIndex = 0;
            this.lblholiday.Text = "List of Holiday";
            // 
            // lvholiday
            // 
            this.lvholiday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlno,
            this.colDate,
            this.colDay,
            this.colRemarks,
            this.colMonth});
            this.lvholiday.FullRowSelect = true;
            this.lvholiday.GridLines = true;
            this.lvholiday.Location = new System.Drawing.Point(485, 25);
            this.lvholiday.Name = "lvholiday";
            this.lvholiday.Size = new System.Drawing.Size(514, 452);
            this.lvholiday.TabIndex = 1;
            this.lvholiday.UseCompatibleStateImageBehavior = false;
            this.lvholiday.View = System.Windows.Forms.View.Details;
            this.lvholiday.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvholiday_MouseDown);
            // 
            // colSlno
            // 
            this.colSlno.Text = "Sl.No.";
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colDay
            // 
            this.colDay.Text = "Day";
            this.colDay.Width = 100;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 160;
            // 
            // colMonth
            // 
            this.colMonth.Text = "Month";
            this.colMonth.Width = 0;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(24, 229);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(30, 13);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Date";
            // 
            // lblremark
            // 
            this.lblremark.AutoSize = true;
            this.lblremark.Location = new System.Drawing.Point(24, 267);
            this.lblremark.Name = "lblremark";
            this.lblremark.Size = new System.Drawing.Size(44, 13);
            this.lblremark.TabIndex = 3;
            this.lblremark.Text = "Remark";
            // 
            // dtdate
            // 
            this.dtdate.CustomFormat = "dd/MM/yyyy";
            this.dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtdate.Location = new System.Drawing.Point(106, 222);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(87, 20);
            this.dtdate.TabIndex = 4;
            this.dtdate.ValueChanged += new System.EventHandler(this.dtdate_ValueChanged);
            this.dtdate.Leave += new System.EventHandler(this.dtdate_Leave);
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(106, 267);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(225, 20);
            this.txtremark.TabIndex = 5;
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(106, 321);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 6;
            this.btsave.Text = "Save";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(187, 321);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(75, 25);
            this.btclose.TabIndex = 7;
            this.btclose.Text = "Close";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // lblmode
            // 
            this.lblmode.AutoSize = true;
            this.lblmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmode.Location = new System.Drawing.Point(24, 58);
            this.lblmode.Name = "lblmode";
            this.lblmode.Size = new System.Drawing.Size(47, 16);
            this.lblmode.TabIndex = 8;
            this.lblmode.Text = "Mode";
            // 
            // lblmodechange
            // 
            this.lblmodechange.AutoSize = true;
            this.lblmodechange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmodechange.Location = new System.Drawing.Point(94, 58);
            this.lblmodechange.Name = "lblmodechange";
            this.lblmodechange.Size = new System.Drawing.Size(38, 16);
            this.lblmodechange.TabIndex = 9;
            this.lblmodechange.Text = "New";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.update,
            this.Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // update
            // 
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(106, 22);
            this.update.Text = "edit";
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(106, 22);
            this.Delete.Text = "delete";
            // 
            // btcancel
            // 
            this.btcancel.Location = new System.Drawing.Point(268, 323);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(75, 23);
            this.btcancel.TabIndex = 10;
            this.btcancel.Text = "Cancel";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // HolidayEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 489);
            this.Controls.Add(this.lblmodechange);
            this.Controls.Add(this.btcancel);
            this.Controls.Add(this.lblmode);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.dtdate);
            this.Controls.Add(this.lblremark);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lblholiday);
            this.Controls.Add(this.lvholiday);
            this.Name = "HolidayEntry";
            this.Text = "HolidayEntry";
            this.Load += new System.EventHandler(this.HolidayEntry_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblholiday;
        private System.Windows.Forms.ListView lvholiday;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblremark;
        private System.Windows.Forms.DateTimePicker dtdate;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.ColumnHeader colSlno;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colDay;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colMonth;
        private System.Windows.Forms.Label lblmode;
        private System.Windows.Forms.Label lblmodechange;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem update;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.Button btcancel;
    }
}