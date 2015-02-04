using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;


namespace NewGMS
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void ChkPwd()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select pwd from tuser where empid=@eid";
            sda.SelectCommand.Parameters.AddWithValue("@eid", clsDbForReports.userid);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            
            if (ds.Tables[0].Rows[0]["pwd"].ToString() == txtOldPwd.Text)
            {
                ChangePwd();
            }
            else
            {
                MessageBox.Show("Old password is wrong");
            }
        }

        private void ChangePwd()
        {
            if (txtNewPwd.Text == txtConfirmPwd.Text)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "update tuser set pwd=@pwd where empid=@eid";
                scmd.Parameters.AddWithValue("@pwd", txtNewPwd.Text );
                scmd.Parameters.AddWithValue("@eid", clsDbForReports.userid);
                int i = scmd.ExecuteNonQuery();
                sc.Close();
                btnChange.Enabled = false;
            }
            else
            {
                MessageBox.Show("New Password and Confirm password are not matching");
            }        
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ChkPwd();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
