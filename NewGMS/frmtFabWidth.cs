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
    public partial class frmtFabWidth : Form
    {
        string mode;
        int y;
        public frmtFabWidth()
        {
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            mode = "New";
            lblMode.Text = "Mode:New";
            txtWidthName.Text = "";
            txtWidthSize.Text = "";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtWidthName.Text.Trim () == "") || (txtWidthSize.Text.Trim () == ""))
                 MessageBox.Show("Enter any data");
            else if (mode == "New")
            {
               bool  k = insrt_Chk();
                if (k == false )
                    newSave_Fab();
                else 
                {
                    MessageBox.Show("Data already exists");
                    txtWidthName.Text = "";
                    txtWidthSize.Text = "";
                }
            }
            else if (mode == "Edit")
            {
                bool  m=edit_Chk();
                if (m == false )
                      editSave_Fab();
                else 
                {
                    MessageBox.Show("Data already exists");
                    txtWidthName.Text = "";
                    txtWidthSize.Text = "";
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((txtWidthName.Text.Trim () == "") || (txtWidthSize.Text.Trim () == ""))
                MessageBox.Show("Enter any data");
            else if (mode == "New")
                MessageBox.Show("Not in edit mode");
            else if (mode == "Edit")
            {
               bool k = del_chk();
                if (k == false )
                    del_Fab();
                else 
                {
                    MessageBox.Show("Cannot delete data since it exists in another table ");
                    txtWidthName.Text = "";
                    txtWidthSize.Text = "";
                }
            }
        }
        private void frmtFabWidth_Load(object sender, EventArgs e)
        {
            lblMode.Text = "Mode:New";
            mode = "New";
            showdata();
        }
        private void showdata()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select FabWidthId,FabWidthName,WidthSize from tFabWidth order by FabWidthId desc";
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridFabWidth.DataSource = ds.Tables[0];
            }
            catch(Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "showdata", er);
            }
        }
        private void newSave_Fab()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "insrtFabWidth";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@compcode", clsDbForReports.companycode);
                cmd.Parameters.AddWithValue("@offcode", clsDbForReports.officecode);
                cmd.Parameters.AddWithValue("@fabwidthid", 0).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@fabwidthname", txtWidthName.Text);
                cmd.Parameters.AddWithValue("@fabwidthsize", txtWidthSize.Text);
                int i = cmd.ExecuteNonQuery();
                int fid = (int)cmd.Parameters["@fabwidthid"].Value;
                if (i != 0)
                    MessageBox.Show("Inserted Successfully");
                else
                    MessageBox.Show("Insertion Failed");
                con.Close();
                insrt_tFabWidthLog('N', fid);
                txtWidthName.Text = "";
                txtWidthSize.Text = "";
                showdata();
            }
            catch(Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "newSave_Fab", er);
            }
         }
        private void editSave_Fab()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "update tFabWidth set  FabWidthName= @FabWidthName,WidthSize= @WidthSize from tFabWidth where FabWidthId= @FabWidthId";
                cmd.Parameters.AddWithValue("@FabWidthId", y);
                cmd.Parameters.AddWithValue("@FabWidthName", txtWidthName.Text);
                cmd.Parameters.AddWithValue("@WidthSize", txtWidthSize.Text);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Updated Successfully");
                else if (i == 0)
                    MessageBox.Show("Updation Failed");
                con.Close();
                insrt_tFabWidthLog('E', y);
                txtWidthName.Text = "";
                txtWidthSize.Text = "";
                showdata();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "editSave_Fab", er);
            }
        }
        private void del_Fab()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "FabWidthDel";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FabWidthId", y);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Deleted Successfully");
                else if (i == 0)
                    MessageBox.Show("Deletion Failed");
                con.Close();
                insrt_tFabWidthLog('D', y);
                txtWidthName.Text = "";
                txtWidthSize.Text = "";
                showdata();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "del_Fab", er);
            }
        }
        private void dataGridFabWidth_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            celldoubleclick(i);
        }
        private void celldoubleclick(int a)
        {
            try
            {
                mode = "Edit";
                lblMode.Text = "Mode:Edit";
                y = Convert.ToInt32(dataGridFabWidth.Rows[a].Cells[0].Value);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select FabWidthName,WidthSize from tFabWidth where FabWidthId=@FabWidthId";
                adp.SelectCommand.Parameters.AddWithValue("@FabWidthId", y);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                txtWidthName.Text = ds.Tables[0].Rows[0][0].ToString();
                txtWidthSize.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "celldoubleclick", er);
            }
        }
        private bool insrt_Chk()
        {
            bool val = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select FabWidthId from tfabWidth where FabWidthName=@FabWidthName";
                adp.SelectCommand.Parameters.AddWithValue("@FabWidthName", txtWidthName.Text.Trim());
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    val = true;
                }
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "insrt_Chk", er);
            }
            return val;
        }
        private bool edit_Chk()
        {
            bool val = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select  FabWidthId from tfabWidth where FabWidthName=@FabWidthName and FabWidthId!=@FabWidthId ";
                adp.SelectCommand.Parameters.AddWithValue("@FabWidthName", txtWidthName.Text.Trim());
                adp.SelectCommand.Parameters.AddWithValue("@FabWidthId", y);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    val = true;
                }
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "edit_Chk", er);
            }
            return val;
        }
        private bool del_chk()
        {
            bool val = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select FabWidthId from tStyleMaster where FabWidthId=@FabWidthId";
                adp.SelectCommand.Parameters.AddWithValue("@FabWidthId", y);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    val = true;
                }
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("tFabWidth", "del_chk", er);
            }
            return val;
        }
        private void insrt_tFabWidthLog(char op, int z)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constrlog;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tFabWidthLog(accessId,userId,operation,dt,tim) values(@accessId,@userId,@operation,@dt,@tim)";
            cmd.Parameters.AddWithValue("@accessId", z);
            cmd.Parameters.AddWithValue("@userId", clsDbForReports.userid);
            cmd.Parameters.AddWithValue("@operation", op);
            cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@tim", DateTime.Now.ToShortTimeString());
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
