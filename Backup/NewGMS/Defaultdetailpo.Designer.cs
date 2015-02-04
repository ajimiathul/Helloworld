namespace NewGMS
{
    partial class Defaultdetailpo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btcancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtdelivery = new System.Windows.Forms.TextBox();
            this.txtpayment = new System.Windows.Forms.TextBox();
            this.txtref = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btsave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btcancel
            // 
            this.btcancel.Location = new System.Drawing.Point(471, 503);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(75, 23);
            this.btcancel.TabIndex = 25;
            this.btcancel.Text = "cancel";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtdelivery);
            this.groupBox2.Controls.Add(this.txtpayment);
            this.groupBox2.Controls.Add(this.txtref);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(52, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 321);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // txtdelivery
            // 
            this.txtdelivery.Location = new System.Drawing.Point(123, 136);
            this.txtdelivery.Multiline = true;
            this.txtdelivery.Name = "txtdelivery";
            this.txtdelivery.Size = new System.Drawing.Size(163, 43);
            this.txtdelivery.TabIndex = 2;
            // 
            // txtpayment
            // 
            this.txtpayment.Location = new System.Drawing.Point(123, 230);
            this.txtpayment.Multiline = true;
            this.txtpayment.Name = "txtpayment";
            this.txtpayment.Size = new System.Drawing.Size(163, 42);
            this.txtpayment.TabIndex = 3;
            // 
            // txtref
            // 
            this.txtref.Location = new System.Drawing.Point(123, 47);
            this.txtref.Multiline = true;
            this.txtref.Name = "txtref";
            this.txtref.Size = new System.Drawing.Size(163, 45);
            this.txtref.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Delivery";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Our-Reference";
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(360, 503);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 23);
            this.btsave.TabIndex = 22;
            this.btsave.Text = "save";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Organisations Norms and conditions\r\n";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(448, 87);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(548, 317);
            this.dataGridView1.TabIndex = 0;
            // 
            // Defaultdetailpo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 643);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btcancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btsave);
            this.Name = "Defaultdetailpo";
            this.Text = "Defaultdetailpo";
            this.Load += new System.EventHandler(this.Defaultdetailpo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtdelivery;
        private System.Windows.Forms.TextBox txtpayment;
        private System.Windows.Forms.TextBox txtref;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btsave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}