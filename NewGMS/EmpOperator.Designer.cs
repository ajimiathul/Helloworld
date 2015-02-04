namespace NewGMS
{
    partial class EmpOperator
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
            this.lblOperator = new System.Windows.Forms.Label();
            this.gbmodeoperator = new System.Windows.Forms.GroupBox();
            this.btclose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btedit = new System.Windows.Forms.Button();
            this.btnew = new System.Windows.Forms.Button();
            this.cmborder = new System.Windows.Forms.ComboBox();
            this.txtshdesc = new System.Windows.Forms.TextBox();
            this.lblorder = new System.Windows.Forms.Label();
            this.lblshortdes = new System.Windows.Forms.Label();
            this.txtoperator = new System.Windows.Forms.TextBox();
            this.dgvOpeartor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btSORT = new System.Windows.Forms.Button();
            this.gbmodeoperator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeartor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(19, 44);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(48, 13);
            this.lblOperator.TabIndex = 0;
            this.lblOperator.Text = "Operator";
            // 
            // gbmodeoperator
            // 
            this.gbmodeoperator.Controls.Add(this.btclose);
            this.gbmodeoperator.Controls.Add(this.btSave);
            this.gbmodeoperator.Controls.Add(this.btedit);
            this.gbmodeoperator.Controls.Add(this.btnew);
            this.gbmodeoperator.Controls.Add(this.cmborder);
            this.gbmodeoperator.Controls.Add(this.txtshdesc);
            this.gbmodeoperator.Controls.Add(this.lblorder);
            this.gbmodeoperator.Controls.Add(this.lblshortdes);
            this.gbmodeoperator.Controls.Add(this.txtoperator);
            this.gbmodeoperator.Controls.Add(this.lblOperator);
            this.gbmodeoperator.Location = new System.Drawing.Point(73, 12);
            this.gbmodeoperator.Name = "gbmodeoperator";
            this.gbmodeoperator.Size = new System.Drawing.Size(398, 201);
            this.gbmodeoperator.TabIndex = 1;
            this.gbmodeoperator.TabStop = false;
            this.gbmodeoperator.Text = "Mode";
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(279, 159);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(75, 23);
            this.btclose.TabIndex = 10;
            this.btclose.Text = "Close";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(198, 159);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 9;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btedit
            // 
            this.btedit.Location = new System.Drawing.Point(117, 159);
            this.btedit.Name = "btedit";
            this.btedit.Size = new System.Drawing.Size(75, 23);
            this.btedit.TabIndex = 8;
            this.btedit.Text = "Edit";
            this.btedit.UseVisualStyleBackColor = true;
            this.btedit.Click += new System.EventHandler(this.btedit_Click);
            // 
            // btnew
            // 
            this.btnew.Location = new System.Drawing.Point(22, 159);
            this.btnew.Name = "btnew";
            this.btnew.Size = new System.Drawing.Size(75, 23);
            this.btnew.TabIndex = 7;
            this.btnew.Text = "New";
            this.btnew.UseVisualStyleBackColor = true;
            this.btnew.Click += new System.EventHandler(this.btnew_Click);
            // 
            // cmborder
            // 
            this.cmborder.FormattingEnabled = true;
            this.cmborder.Location = new System.Drawing.Point(128, 117);
            this.cmborder.Name = "cmborder";
            this.cmborder.Size = new System.Drawing.Size(219, 21);
            this.cmborder.TabIndex = 6;
            // 
            // txtshdesc
            // 
            this.txtshdesc.Location = new System.Drawing.Point(128, 80);
            this.txtshdesc.Name = "txtshdesc";
            this.txtshdesc.Size = new System.Drawing.Size(219, 20);
            this.txtshdesc.TabIndex = 5;
            // 
            // lblorder
            // 
            this.lblorder.AutoSize = true;
            this.lblorder.Location = new System.Drawing.Point(19, 117);
            this.lblorder.Name = "lblorder";
            this.lblorder.Size = new System.Drawing.Size(33, 13);
            this.lblorder.TabIndex = 4;
            this.lblorder.Text = "Order";
            // 
            // lblshortdes
            // 
            this.lblshortdes.AutoSize = true;
            this.lblshortdes.Location = new System.Drawing.Point(19, 83);
            this.lblshortdes.Name = "lblshortdes";
            this.lblshortdes.Size = new System.Drawing.Size(88, 13);
            this.lblshortdes.TabIndex = 3;
            this.lblshortdes.Text = "Short Description";
            // 
            // txtoperator
            // 
            this.txtoperator.Location = new System.Drawing.Point(128, 37);
            this.txtoperator.Name = "txtoperator";
            this.txtoperator.Size = new System.Drawing.Size(219, 20);
            this.txtoperator.TabIndex = 2;
            // 
            // dgvOpeartor
            // 
            this.dgvOpeartor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpeartor.Location = new System.Drawing.Point(73, 232);
            this.dgvOpeartor.Name = "dgvOpeartor";
            this.dgvOpeartor.Size = new System.Drawing.Size(398, 244);
            this.dgvOpeartor.TabIndex = 7;
            this.dgvOpeartor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOpeartor_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // btSORT
            // 
            this.btSORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSORT.Location = new System.Drawing.Point(396, 482);
            this.btSORT.Name = "btSORT";
            this.btSORT.Size = new System.Drawing.Size(75, 27);
            this.btSORT.TabIndex = 9;
            this.btSORT.Text = "SORT";
            this.btSORT.UseVisualStyleBackColor = true;
            this.btSORT.Click += new System.EventHandler(this.btSORT_Click);
            // 
            // EmpOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 511);
            this.Controls.Add(this.btSORT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOpeartor);
            this.Controls.Add(this.gbmodeoperator);
            this.Name = "EmpOperator";
            this.Text = "EmpOperator";
            this.Load += new System.EventHandler(this.EmpOperator_Load);
            this.gbmodeoperator.ResumeLayout(false);
            this.gbmodeoperator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeartor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.GroupBox gbmodeoperator;
        private System.Windows.Forms.TextBox txtshdesc;
        private System.Windows.Forms.Label lblorder;
        private System.Windows.Forms.Label lblshortdes;
        private System.Windows.Forms.TextBox txtoperator;
        private System.Windows.Forms.ComboBox cmborder;
        private System.Windows.Forms.DataGridView dgvOpeartor;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btedit;
        private System.Windows.Forms.Button btnew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSORT;
    }
}