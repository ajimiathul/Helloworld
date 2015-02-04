using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmLogin : Form
    {
        bool compflag = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void LoginClick()
        {

            if (cmbUser.SelectedValue.ToString() == txtPwd.Text)
            {
                clsDbForReports.username = cmbUser.Text;
                RecidAndFindAdmin();
                clsDbForReports.LogStatus = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password");
                txtPwd.Focus();
            }
        
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginClick();
        }

        private void LoadUsers()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select uid,pwd from tuser where compcode= @cc order by uid";
            sda.SelectCommand.Parameters.AddWithValue("@cc", Convert.ToInt32(cmbCompany.SelectedValue.ToString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUser.DataSource = ds.Tables[0];
            cmbUser.DisplayMember = "uid";
            cmbUser.ValueMember = "pwd";
        }

        private void RecidAndFindAdmin()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,Admin from tuser where uid=@uid";
            sda.SelectCommand.Parameters.AddWithValue("@uid", cmbUser.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUser.DataSource = ds.Tables[0];
            clsDbForReports.userid = Convert.ToInt32(ds.Tables[0].Rows[0]["empid"].ToString());
            clsDbForReports.admin = Convert.ToInt32(ds.Tables[0].Rows[0]["Admin"].ToString());
            clsDbForReports.companycode = Convert.ToInt32(cmbCompany.SelectedValue.ToString());
            
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            compflag = false;
            LoadCompany();
            compflag = true;
            LoadUsers();
            
        }

        private void LoadCompany()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select compcode,companyName  from company order by disporder";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCompany.DataSource = ds.Tables[0];
            cmbCompany.DisplayMember = "companyName";
            cmbCompany.ValueMember = "compcode";
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsDbForReports.LogStatus = false;
            this.Close();
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (compflag == true)
            {
                LoadUsers();
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginClick();
            }
        }

        private void cmbUser_DropDownClosed(object sender, EventArgs e)
        {
            txtPwd.Focus();
        }

        private void cmbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPwd.Focus();
            }
        }
    }
}
