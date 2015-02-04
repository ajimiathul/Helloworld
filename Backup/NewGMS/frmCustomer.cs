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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            FillCustomerTypeCombo();
            ShowInGrid();
        }
        private void FillCustomerTypeCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select TypeDescription,CustomerTypeCode from tCustomerType";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCustomerType.DataSource = ds.Tables[0];
            cmbCustomerType.DisplayMember = "TypeDescription";
            cmbCustomerType.ValueMember = "CustomerTypeCode";
        }
        private int GetMappedAccCode()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select EqtAccHeadCode from tCustomerType where CustomerTypeCode=@code";
            sda.SelectCommand.Parameters.AddWithValue("@code", Convert.ToInt32(cmbCustomerType.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int x = Convert.ToInt32(ds.Tables[0].Rows[0]["EqtAccHeadCode"]);
            return x;
        }
        private void SaveInAccMaster()
        {
            int x = GetMappedAccCode();
            string GA = "A";
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "CreateAccount";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@acnUnder", x);
            scmd.Parameters.AddWithValue("@acname", txtCustomerName.Text);
            scmd.Parameters.AddWithValue("@GAflag", GA);
            scmd.Parameters.AddWithValue("@sceoflag", "CUS");
            scmd.Parameters.AddWithValue("@opbal", 0);
            scmd.Parameters.AddWithValue("@scr", "AccMaster");
            scmd.Parameters.AddWithValue("@sceono", 0);
            scmd.Parameters.AddWithValue("@db",0);
            scmd.Parameters.AddWithValue("@cr", 0);
            scmd.Parameters.AddWithValue("@bal", 0);
            scmd.Parameters.AddWithValue("@nonentry", "N");
            scmd.ExecuteNonQuery();
            sc.Close();
        }
        private void SaveInCustomer()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "CreateCustomer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@scr", "Customer");
            cmd.Parameters.AddWithValue("@nm", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@typecode", cmbCustomerType.SelectedValue);
            cmd.Parameters.AddWithValue("@cname", txtContactPerson.Text);
            cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private bool CheckEmpty()
        {
            bool empty = false;
            if (txtCustomerName.Text.Trim() == "" || txtContactPerson.Text.Trim() == "" || txtAddress.Text.Trim() == "")
            {
                empty = true;
                MessageBox.Show("Data is not Entered");
                if (txtCustomerName.Text.Trim() == "")
                {
                    txtCustomerName.Focus();
                }
                else if (txtContactPerson.Text.Trim() == "")
                {
                    txtContactPerson.Focus();
                }
                else if (txtAddress.Text.Trim() == "")
                {
                    txtAddress.Focus();
                }
            }
            return empty;
        }
        private bool CheckDupNew()
        {
            bool check = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select AccCode from tAccountMaster where AccName=@name and SupCusEmpOth = 'CUS'";
            sda.SelectCommand.Parameters.AddWithValue("@name", txtCustomerName.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Name Already Exist");
                check = true;
            }
            return check;
        }
        private void ShowInGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select cuscode,customerName,B.TypeDescription,ContactName,address from tCustomer A left join tCustomerType B on A.customerTypeCode=B.CustomerTypeCode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvCustomer.DataSource = ds.Tables[0];
        }
        private void lblSave_Click(object sender, EventArgs e)
        {
            if (CheckEmpty() == false)
            {
                if (CheckDupNew() == false)
                {
                    SaveInAccMaster();
                    SaveInCustomer();
                    ShowInGrid();
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCustomerName.Text.Trim() != "")
                {
                    cmbCustomerType.Focus();
                }
                else
                {
                    txtCustomerName.Focus();
                }
            }
        }
        private void cmbCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            txtContactPerson.Focus();
        }
        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtContactPerson.Text.Trim() != "")
                {
                    txtAddress.Focus();
                }
                else
                {
                    txtContactPerson.Focus();
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCustomerName.Clear();
            txtContactPerson.Clear();
            txtAddress.Clear();
        }
    }
}
