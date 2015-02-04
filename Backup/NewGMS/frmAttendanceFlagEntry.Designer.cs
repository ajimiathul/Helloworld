namespace NewGMS
{
    partial class frmAttendanceFlagEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendanceFlagEntry));
            this.dtpAttendance = new System.Windows.Forms.DateTimePicker();
            this.fcgAttFlagPresent = new FlexCell.Grid();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fcgAttFlagAbsent = new FlexCell.Grid();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpAttendance
            // 
            this.dtpAttendance.CustomFormat = "dd/MM/yyyy";
            this.dtpAttendance.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttendance.Location = new System.Drawing.Point(426, 12);
            this.dtpAttendance.Name = "dtpAttendance";
            this.dtpAttendance.Size = new System.Drawing.Size(97, 20);
            this.dtpAttendance.TabIndex = 0;
            this.dtpAttendance.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // fcgAttFlagPresent
            // 
            this.fcgAttFlagPresent.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fcgAttFlagPresent.CheckedImage")));
            this.fcgAttFlagPresent.Cols = 13;
            this.fcgAttFlagPresent.Location = new System.Drawing.Point(19, 45);
            this.fcgAttFlagPresent.Name = "fcgAttFlagPresent";
            this.fcgAttFlagPresent.Rows = 1;
            this.fcgAttFlagPresent.Size = new System.Drawing.Size(764, 319);
            this.fcgAttFlagPresent.TabIndex = 1;
            this.fcgAttFlagPresent.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fcgAttFlagPresent.UncheckedImage")));
            this.fcgAttFlagPresent.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.fcgAttendanceFlag_CellChange);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(891, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(830, 418);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fcgAttFlagPresent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(822, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fcgAttFlagAbsent);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(822, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fcgAttFlagAbsent
            // 
            this.fcgAttFlagAbsent.CheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fcgAttFlagAbsent.CheckedImage")));
            this.fcgAttFlagAbsent.Cols = 7;
            this.fcgAttFlagAbsent.Location = new System.Drawing.Point(18, 50);
            this.fcgAttFlagAbsent.Name = "fcgAttFlagAbsent";
            this.fcgAttFlagAbsent.Rows = 1;
            this.fcgAttFlagAbsent.Size = new System.Drawing.Size(476, 327);
            this.fcgAttFlagAbsent.TabIndex = 2;
            this.fcgAttFlagAbsent.UncheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("fcgAttFlagAbsent.UncheckedImage")));
            this.fcgAttFlagAbsent.CellChange += new FlexCell.Grid.CellChangeEventHandler(this.fcgAttFlagAbsent_CellChange);
            // 
            // frmAttendanceFlagEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 459);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpAttendance);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAttendanceFlagEntry";
            this.Text = "frmAttendanceFlagEntry";
            this.Load += new System.EventHandler(this.frmAttendanceFlagEntry_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAttendance;
        private FlexCell.Grid fcgAttFlagPresent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FlexCell.Grid fcgAttFlagAbsent;
    }
}