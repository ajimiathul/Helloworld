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
    public partial class frmBaseMaterial : Form
    {
        string mode = "New";
        int bmc = 0;

        public frmBaseMaterial()
        {
            InitializeComponent();
        }

        private void frmBaseMaterial_Load(object sender, EventArgs e)
        {
            LoadMat();
            LoadAcc();
        }


        private void LoadAcc()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select accCode,Accname from tAccountMaster where AccCat='E' and GrpOrAcc = 'A' order by accName";           
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmbAccount.DataSource = ds.Tables[0];
            cmbAccount.DisplayMember = "accname";
            cmbAccount.ValueMember = "accCode";
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMode.Text = "Mode : New";
            mode = "New";
            txtMat.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Enter Property");
            }
            else
            {
                if (mode == "New")
                {
                    if (NewDupChk() == false)
                    {
                        insertData();
                    }
                    else
                    {
                        MessageBox.Show("Already Exist");
                    }
                }
                else
                {
                    if (EditDupChk() == false)
                    {
                        UpdateData();
                    }
                    else
                    {
                        MessageBox.Show("Another property already exist");
                    }
                }
                LoadMat();
            }
        }

        private bool NewDupChk()
        {
            bool ret = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select BaseMaterial from tBaseMaterial where BaseMaterial=@bm";
            adp.SelectCommand.Parameters.AddWithValue("@bm", txtMat .Text.Trim());
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }

        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "BaseMaterial");
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private int ReadLastNum()
        {
            UpdateLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "select lastnum from tNumbers where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "BaseMaterial");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void insertData()
        {
            bmc = ReadLastNum();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert tBaseMaterial(BaseMaterialCode,BaseMaterial,NeedRollNumber,AccCode,ToCuttingDept) values(@bmc,@bm,'N',@acc,'N')";
            cmd.Parameters.AddWithValue("@bmc", bmc);
            cmd.Parameters.AddWithValue("@bm", txtMat.Text.Trim());
            cmd.Parameters.AddWithValue("@acc", Convert.ToInt32 (cmbAccount.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                MessageBox.Show("Added Successfully");
            else
                MessageBox.Show("Operation Failed");
            con.Close();
        }

        private bool EditDupChk()
        {
            bool ret = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select BaseMaterialCode from tBaseMaterial where BaseMaterial=@bm and BaseMaterialCode != @bmc";
            adp.SelectCommand.Parameters.AddWithValue("@bm", txtMat.Text.Trim());
            adp.SelectCommand.Parameters.AddWithValue("@bmc", bmc);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }

        private void UpdateData()
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tBaseMaterial set BaseMaterial= @bm,accCode=@acc where BaseMaterialCode=@bmc";
            cmd.Parameters.AddWithValue("@bm", txtMat .Text.Trim());
            cmd.Parameters.AddWithValue("@bmc", bmc);            
            cmd.Parameters.AddWithValue("@acc", Convert.ToInt32(cmbAccount.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                MessageBox.Show("Update Successfully");
            else
                MessageBox.Show("Operation Failed");
            con.Close();
        }

        private void LoadMat()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select A.BaseMaterialCode,A.BaseMaterial,A.NeedRollNumber,B.AccName,A.accCode from tBaseMaterial A,tAccountMaster B where A.accCode=B.accCode ";
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dgvProperties.DataSource = ds.Tables[0];
            dgvProperties.Columns[0].Visible = false;
            dgvProperties.Columns[4].Visible = false;
        }

        private void dgvProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i != -1)
            {
                mode = "Edit";
                txtMode.Text = "Mode : Edit";
                bmc = Convert.ToInt32(dgvProperties.Rows[i].Cells[0].Value);
                txtMat.Text = dgvProperties.Rows[i].Cells[1].Value.ToString ();
                cmbAccount.SelectedValue = dgvProperties.Rows[i].Cells[4].Value;
            }
        }
    }
}
