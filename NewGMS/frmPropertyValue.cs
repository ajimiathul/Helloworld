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
    public partial class frmPropertyValue : Form
    {
        string mode = "New";
        int pvc = 0;

        public frmPropertyValue()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMode.Text = "Mode : New";
            mode = "New";
            
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                LoadPropertyValue();
        }

        private void LoadProperty()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select PropertyCode,Property from tMaterialProperty ";
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmbProperty.DataSource = ds.Tables[0];
            cmbProperty.ValueMember = "PropertyCode";
            cmbProperty.DisplayMember = "Property";
        }


        private void LoadPropertyValue()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select A.PropertyValueCode,B.Property,B.PropertyCode,A.PropertyValue,B.ShortName from tMaterialPropertyValue A,tMaterialProperty B where A.PropertyCode = B.PropertyCode ";
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dgvProperties.DataSource = ds.Tables[0];
            dgvProperties.Columns[0].Visible = false;
            dgvProperties.Columns[2].Visible = false;
        }


        private bool NewDupChk()
        {
            bool ret = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter adp = new SqlDataAdapter("", con);
            adp.SelectCommand.CommandText = "select PropertyValueCode from tMaterialPropertyValue where PropertyCode=@pc and propertyvalue=@pv";
            adp.SelectCommand.Parameters.AddWithValue("@pc",Convert.ToInt32 ( cmbProperty.SelectedValue)  );
            adp.SelectCommand.Parameters.AddWithValue("@pv", txtValue.Text);
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
            scmd.Parameters.AddWithValue("@scr", "ProValue");
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
            scmd.Parameters.AddWithValue("@scr", "ProValue");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void insertData()
        {
            pvc = ReadLastNum();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert tMaterialPropertyValue(PropertyCode,PropertyValueCode,PropertyValue) values(@pc,@pvc,@pv)";
            cmd.Parameters.AddWithValue("@pc", Convert.ToInt32(cmbProperty.SelectedValue));
            cmd.Parameters.AddWithValue("@pvc", pvc);
            cmd.Parameters.AddWithValue("@pv", txtValue.Text.Trim());
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
            adp.SelectCommand.CommandText = "select PropertyValueCode from tMaterialPropertyValue where PropertyCode=@pc and propertyvalue=@pv and PropertyValueCode != @pvc";
            adp.SelectCommand.Parameters.AddWithValue("@pc", Convert.ToInt32(cmbProperty.SelectedValue));
            adp.SelectCommand.Parameters.AddWithValue("@pv", txtValue.Text.Trim());
            adp.SelectCommand.Parameters.AddWithValue("@pvc", pvc);
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
            cmd.CommandText = "update tMaterialPropertyValue set PropertyCode=@pc,PropertyValue=@pv where PropertyValueCode=@pvc";
            cmd.Parameters.AddWithValue("@pc", Convert.ToInt32(cmbProperty.SelectedValue));
            cmd.Parameters.AddWithValue("@pv", txtValue.Text.Trim());
            cmd.Parameters.AddWithValue("@pvc",pvc);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                MessageBox.Show("Added Successfully");
            else
                MessageBox.Show("Operation Failed");
            con.Close();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPropertyValue_Load(object sender, EventArgs e)
        {
            LoadProperty();
            LoadPropertyValue();
            txtMode.Text = "Mode : New";
        }

        private void dgvProperties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i != -1)
            {              
                mode = "Edit";
                txtMode.Text = "Mode : Edit";
                pvc = Convert.ToInt32(dgvProperties.Rows[i].Cells[0].Value);
                cmbProperty.SelectedValue = dgvProperties.Rows[i].Cells[2].Value ;
                txtValue.Text = dgvProperties.Rows[i].Cells[3].Value.ToString ();

            }
        }

        
    }
}
