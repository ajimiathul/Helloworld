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
    public partial class frmUserMenuSelect : Form
    {
        bool menuflag = false;

        public frmUserMenuSelect()
        {
            InitializeComponent();
        }
        private void showUserCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select uid,empid from tUser";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUser.DataSource = ds.Tables[0];
            cmbUser.DisplayMember = "uid";
            cmbUser.ValueMember = "empid";
        }

        private void frmUserMenuSelect_Load(object sender, EventArgs e)
        {
            menuflag = false;
            showUserCombo();
            showCheckedListBox();
            menuflag = true;
            makeTic();
        }
        private void showCheckedListBox()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select menuSubName,menuID from tMenu";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                clbMenu .Items.Add(ds.Tables[0].Rows[i]["menuSubName"].ToString());
                
                ltbMenuId.Items.Add(ds.Tables[0].Rows[i]["menuID"].ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clrData();
            insertData();
            MessageBox.Show("Updated");
            
        }
        private void clrData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "DELETE FROM tUserMenu WHERE userid=@id";
            cmd.Parameters.AddWithValue("@id", cmbUser.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void insertData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();            
            for (int i = 0; i < clbMenu.Items.Count; i++)
            {
                if (clbMenu.GetItemChecked(i) == true)
                {
                    cmd.CommandText = "INSERT INTO tUserMenu(userid,menuid)VALUES(@id,@menu)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", cmbUser.SelectedValue);
                    cmd.Parameters.AddWithValue("@menu", ltbMenuId.Items[i]);
                    cmd.ExecuteNonQuery();
                }
            }            
            con.Close();           
        }
        private void makeTic()
        {
            for (int k = 0; k < clbMenu.Items.Count; k++)
            {
                clbMenu.SetItemChecked(k, false);
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText="select menuid from tUserMenu where userid=@id";
            sda.SelectCommand.Parameters.AddWithValue("@id", cmbUser.SelectedValue);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ltbMenuId.Items.Count; j++)
                {
                    if (ds.Tables[0].Rows[i][0].ToString() == ltbMenuId.Items[j].ToString())
                    {
                        clbMenu.SetItemChecked(j, true);
                    }
                }
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuflag == true)
            {
                makeTic();
            }
        }                      
    }
}
