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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }
        int id=0;
        string mod = "new";        
        private void frmSupplier_Shown(object sender, EventArgs e)
        {
            txtSupplierName.Focus();
        }
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            FillCombo();
            ShowInGrid();
        }
        private void lblSave_Click(object sender, EventArgs e)
        {
            MainSave();
        }
        private void FillCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select suppliertypeDescription,suppliertypecode from tSupplierType";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSupplierType.DataSource = ds.Tables[0];
            cmbSupplierType.DisplayMember = "suppliertypeDescription";
            cmbSupplierType.ValueMember = "suppliertypecode";
        }
        private void ShowInGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.Suppliercode supplierId,A.SupplierName,B.suppliertypeDescription suppliertype,A.ContactName ContactPerson,Address from tSupplier A left join tSupplierType B on A.SupplierTypeCode=B.suppliertypecode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvSupplier.DataSource = ds.Tables[0];
        }
        private bool CheckDupNew()
        {
            bool check = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Suppliercode from tSupplier where SupplierName=@name";
            sda.SelectCommand.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Name Already Exist");
                check = true;
            }
            return check;
        }
        
        private void MainSave()
        {
            if (CheckEmpty() == false)
            {
                if (mod == "new")
                {
                    if (CheckDupNew() == false)
                    {
                        SaveInAccMaster();
                        SaveInSupplier();

                    }
                }
                else if (mod == "edit")
                {
                    if (CheckDupEdit() == false)
                    {
                        UpdateInSupplier();
                        UpdateInAccMaster();
                    }
                }
                ShowInGrid();
                ClearFn();
            }
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
            scmd.Parameters.AddWithValue("@acname", txtSupplierName.Text.Trim());
            scmd.Parameters.AddWithValue("@GAflag", GA);
            scmd.Parameters.AddWithValue("@sceoflag", "SUP");
            scmd.Parameters.AddWithValue("@opbal", 0);
            scmd.Parameters.AddWithValue("@scr", "AccMaster");
            scmd.Parameters.AddWithValue("@sceono", 0);
            scmd.Parameters.AddWithValue("@db", 0);
            scmd.Parameters.AddWithValue("@cr", 0);
            scmd.Parameters.AddWithValue("@bal", 0);
            scmd.Parameters.AddWithValue("@nonentry", "N");
            scmd.ExecuteNonQuery();
            sc.Close();
        }
        private int GetMappedAccCode()
        {
            int x = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("",con);
            sda.SelectCommand.CommandText = "select EqtAccHeadCode from tSupplierType where suppliertypecode=@code";
            sda.SelectCommand.Parameters.AddWithValue("@code", Convert .ToInt32( cmbSupplierType.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                x = Convert.ToInt32(ds.Tables[0].Rows[0]["EqtAccHeadCode"]);
            }
            return x;
        }
        private void SaveInSupplier()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "CreateSupplier";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@scr", "Supplier");
            cmd.Parameters.AddWithValue("@nm", txtSupplierName.Text.Trim());
            cmd.Parameters.AddWithValue("@typecode", cmbSupplierType.SelectedValue);
            cmd.Parameters.AddWithValue("@cname", txtContactPerson.Text.Trim());
            cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }        
        private void ClearFn()
        {
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtAddress.Clear();
        }
        private void CellDoubleClick(int i)
        {
            txtMode.Text="Edit";
            mod = "edit";
            id=Convert.ToInt32(dgvSupplier.Rows[i].Cells[0].Value);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.Suppliercode,A.SupplierName,B.suppliertypeDescription,A.ContactName,Address from tSupplier A left join tSupplierType B on A.SupplierTypeCode=B.suppliertypecode where A.Suppliercode=@supid";
            sda.SelectCommand.Parameters.AddWithValue("@supid", id);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            txtSupplierName.Text = ds.Tables[0].Rows[0][1].ToString();
            cmbSupplierType.Text = ds.Tables[0].Rows[0][2].ToString();
            txtContactPerson.Text = ds.Tables[0].Rows[0][3].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0][4].ToString();

        }
        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i != -1)
            {
                CellDoubleClick(i);
            }
        }
        private void UpdateInSupplier()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tSupplier set SupplierName=@name,SupplierTypeCode=@typecode,ContactName=@cname,Address=@addr where Suppliercode=@id";
            cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim());
            cmd.Parameters.AddWithValue("@typecode", cmbSupplierType.SelectedValue);
            cmd.Parameters.AddWithValue("@cname", txtContactPerson.Text.Trim());
            cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdateInAccMaster()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UpdateAccountForSupplier";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim());
            cmd.Parameters.AddWithValue("@suptype", cmbSupplierType.SelectedValue);
            cmd.Parameters.AddWithValue("@subid", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mod = "new";
           txtMode.Text = "New";
            ClearFn(); 
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckEmpty()
        {
            bool empty = false;
            if (txtSupplierName.Text.Trim() == "" || txtContactPerson.Text.Trim() == "" || txtAddress.Text.Trim() == "")
            {
                empty = true;
                MessageBox.Show("Data is not Entered");
                if (txtSupplierName.Text.Trim() == "")
                {
                    txtSupplierName.Focus();
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
        private bool CheckDupEdit()
        {
            bool checkdup = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Suppliercode from tSupplier where SupplierName=@name and Suppliercode<>@id";
            sda.SelectCommand.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim());
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Data Already Exist");
                checkdup = true;
            }
            return checkdup;
        }
        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSupplierType.Focus();
            }
        }
        private void cmbSupplierType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContactPerson.Focus();
            }
        }
        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MainSave();
            }
        }
    }
}