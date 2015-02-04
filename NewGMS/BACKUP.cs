using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessLayer;

namespace NewGMS
{
    public partial class BACKUP : Form
    {
        
        
        public BACKUP()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.MaximizeBox = false;
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sqlada = new SqlDataAdapter(" ", conn);
            string FileName = "";
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    FileName = saveFileDialog1.FileName + ".bak";
                }
                else
                {
                    return;
                }
                tssl.Text = " File Saved as '" + FileName + "'";
                if (!(conn.State == ConnectionState.Open))
                {
                    conn.Open();
                }
                string dbnm = clsDbForReports.db;
                string str1 = "backup database " + dbnm.ToString().Trim() + " to disk=@Disk with format";
                var _with1 = sqlada.SelectCommand;
                _with1.Connection = conn;
                _with1.CommandTimeout = 800;
                _with1.CommandType = CommandType.Text;
                _with1.CommandText = str1;
                _with1.Parameters.AddWithValue("@Disk", FileName);
                _with1.ExecuteNonQuery();
                MessageBox.Show("Database Backup process complete successfully", "Back up", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Backup process complete successfully"+ ex.Message);
            }
            finally
            {
                if (!(conn.State == ConnectionState.Closed))
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
