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
    public partial class frmMaterialProperty : Form
    {
        string mode = "New";
        int pc = 0;

        public frmMaterialProperty()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMode.Text = "Mode : New";
            mode = "New";
            txtProperty.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProperty.Text.Trim().Length  == 0)
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
                LoadProperty();
            }
        }

        private bool NewDupChk()
        { 
        bool ret=false;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = clsDbForReports.constr;
        SqlDataAdapter adp = new SqlDataAdapter("", con);
        adp.SelectCommand.CommandText = "select PropertyCode from tMaterialProperty where Property=@pro";
        adp.SelectCommand.Parameters.AddWithValue("@pro", txtProperty.Text.Trim());
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
            scmd.Parameters.AddWithValue("@scr", "Property");
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
            scmd.Parameters.AddWithValue("@scr", "Property");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void insertData()
        {
            pc = ReadLastNum();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert tMaterialProperty(PropertyCode,Property,ShortName) values(@pc,@pro,@sn)";
            cmd.Parameters.AddWithValue("@pc", pc);
            cmd.Parameters.AddWithValue("@pro", txtProperty.Text.Trim());
            cmd.Parameters.AddWithValue("@sn", txtShortName.Text.Trim());
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
            adp.SelectCommand.CommandText = "select PropertyCode from tMaterialProperty where Property=@pro and PropertyCode != @pc";
            adp.SelectCommand.Parameters.AddWithValue("@pro", txtProperty.Text.Trim());
            adp.SelectCommand.Parameters.AddWithValue("@pc", pc);
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
            cmd.CommandText = "update tMaterialProperty set Property= @pro,shortname=@sn where PropertyCode=@pc";
            cmd.Parameters.AddWithValue("@pro", txtProperty.Text.Trim());
            cmd.Parameters.AddWithValue("@pc", pc);
            cmd.Parameters.AddWithValue("@sn", txtShortName .Text.Trim());
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                MessageBox.Show("Added Successfully");
            else
                MessageBox.Show("Operation Failed");
            con.Close();
        }


        private void frmMaterialProperty_Load(object sender, EventArgs e)
        {
            txtMode.Text = "Mode : New";
            mode = "New";
            LoadProperty();
        }

        private void LoadProperty()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select PropertyCode,Property,ShortName from tMaterialProperty ";
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dgvProperties.DataSource = ds.Tables[0];
            dgvProperties.Columns[0].Visible = false;
        }

        private void dgvProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i != -1)
            {
                celldoubleclick(i);
            }
        }

        private void celldoubleclick(int row)
        {
                mode = "Edit";
                txtMode.Text = "Mode : Edit";
                pc  = Convert.ToInt32(dgvProperties.Rows[row].Cells[0].Value);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                string str = "select Property,shortname from tMaterialProperty where PropertyCode=@pc";
                adp.SelectCommand.CommandText = str;
                adp.SelectCommand.Parameters.AddWithValue("@pc", pc);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                txtProperty.Text = ds.Tables[0].Rows[0][0].ToString();
                txtShortName.Text = ds.Tables[0].Rows[0][1].ToString();
        }

        private void txtProperty_TextChanged(object sender, EventArgs e)
        {
            txtShortName.Text = txtProperty.Text;
        }
    }
}
