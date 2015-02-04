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
    public partial class Defaultdetailpo : Form
    {
        public Defaultdetailpo()
        {
            InitializeComponent();
        }

       

        private void filldefaultcondition()
        {
          
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", sc);

            sda.SelectCommand.CommandText = "select CONDITIONS from tdefPOcondition";
            DataSet ds1 = new DataSet();
            sda.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds1.Tables[0];
                dataGridView1.Columns[0].Width = 400;
            }
            sc.Close();
            
        }

        private void DelProcess()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete tdefPOcondition ";
            scmd.CommandType = CommandType.Text;
            
            scmd.ExecuteNonQuery();
        }
        
        
        private void btsave_Click_1(object sender, EventArgs e)
        {
            if (txtdelivery.Text.Trim().Length != 0 & txtpayment.Text.Trim().Length != 0 & txtref.Text.Trim().Length != 0)
            {

                DelProcess();
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                SqlCommand cmd = new SqlCommand("", sc);
                cmd.CommandText = "storedefultvalpo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ourref", txtref.Text);
                cmd.Parameters.AddWithValue("@delivery", txtdelivery.Text);
                cmd.Parameters.AddWithValue("@payment", txtpayment.Text);
                cmd.ExecuteNonQuery();


                scmd.CommandText = "insert into tdefPOcondition values(@cond)";
                scmd.CommandType = CommandType.Text;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string str = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (str.Trim().Length == 0)
                    {

                        continue;
                    }


                    scmd.Parameters.AddWithValue("@cond", str);
                    scmd.ExecuteNonQuery();
                    scmd.Parameters.Clear();
                }

                sc.Close();
            }
            else
            {
                if(MessageBox.Show("Some manadatory field are Left blank", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning)==DialogResult.OK);
                {
                    txtref.Focus();
                    return;

                }
            }
        }

        private void btcancel_Click(object sender, EventArgs e)
        {

        }

        private void Defaultdetailpo_Load(object sender, EventArgs e)
        {
            filldefaultcondition();
        }

        //private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {

        //        int iRow = dataGridView1.CurrentCell.RowIndex;
        //        dataGridView1.CurrentCell = dataGridView1[0, iRow + 1];

        //        //dataGridView1.BeginEdit(true);
        //        dataGridView1.Rows[iRow].Cells[0].Selected = true;
        //    }
        //}

     
    }
}
