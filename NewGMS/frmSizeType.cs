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
    public partial class frmSizeType : Form
    {
        string mode;
        int y;
        public frmSizeType()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            mode = "New";
            lblmodsize.Text = "Mode:New";
            txtSizetype.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSizetype.Text.Trim () =="")
                MessageBox.Show("Enter any data");
            else if (mode == "New")
            {
                MessageBox.Show("Not in Edit Mode");
                txtSizetype.Text = "";
            }
            else if (mode == "Edit")
            {
                bool k = delSize_Chk();
                if (k == false)
                    delSizeType_fun();
                else
                {
                    MessageBox.Show("Cannot delete data since it exists in another table");
                    txtSizetype.Text = "";
                }
            }
        }
        private void frmSizeType_Load(object sender, EventArgs e)
        {
            mode = "New";
            lblmodsize.Text = "Mode:New";
            showdata();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSizetype.Text.Trim () == "")
                 MessageBox.Show("Enter any data");
            else if (mode == "New")
            {
                bool  x = newInsert_chk();
                if (x == false)
                    newSave_size();
                else
                {
                    MessageBox.Show("Data already exists");
                    txtSizetype.Text = "";
                }
             }
            else if (mode == "Edit")
            {
                bool  z = edit_Chk();
                if (z == false )
                     editSave_size();
                else
                {
                    MessageBox.Show("Data already exists");
                    txtSizetype.Text = "";
                }  
            }
        }
        private void showdata()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select SizeTypeId,SizeType from tSizeType Order by SizeTypeId desc ";
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridViewSizetype.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("SizeType", "showdata", er);
            }
        }       
        private void dataGridViewSizetype_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            celldoubleclick(i);
        }
        private void celldoubleclick(int b)
        {
            try
            {
                mode = "Edit";
                lblmodsize.Text = "Mode:Edit";
                y = Convert.ToInt32(dataGridViewSizetype.Rows[b].Cells[0].Value);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                string str = "select SizeType from tSizeType where SizeTypeId=@typesizeid";
                adp.SelectCommand.CommandText = str;
                adp.SelectCommand.Parameters.AddWithValue("@typesizeid", y);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                txtSizetype.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("SizeType", "celldoubleclick", er);
            }
        }
        private void delSizeType_fun()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "delSizeType";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sizetypeid", y);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Deleted Successfully");
                con.Close();
                txtSizetype.Text = "";
                tSizetypeLog_ins('D', y);
                showdata();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("SizeType", "delSizeType_fun", er);
            }
        }
        private void editSave_size()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "update tSizeType set SizeType =@sizetype where SizeTypeId=@sizetypeid";
                cmd.Parameters.AddWithValue("@sizetypeid", y);
                cmd.Parameters.AddWithValue("@sizetype", txtSizetype.Text);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Updated Successfully");
                else
                    MessageBox.Show("Updation Failed");
                con.Close();
                txtSizetype.Text = "";
                tSizetypeLog_ins('E', y);
                showdata();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("SizeType", "editSave_sizetype", er);
            }
        }
        private void newSave_size()
        {
            try
            {
                int val;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "insrtSizeType";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sizetype", txtSizetype.Text);
                cmd.Parameters.AddWithValue("@sizetypeid", 0).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@compcode", clsDbForReports.companycode);
                cmd.Parameters.AddWithValue("@offcode", clsDbForReports.officecode);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Inserted Successfully");
                else
                    MessageBox.Show("Insertion Failed");
                con.Close();
                val = (int)cmd.Parameters["@sizetypeid"].Value;
                txtSizetype.Text = "";
                tSizetypeLog_ins('N', val);
                showdata();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("SizeType", "newSave_sizetype", er);
            }
        }
        private bool newInsert_chk()
        {
            bool val = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("",con );
                adp.SelectCommand.CommandText = "select SizeTypeId from tSizeType where SizeType=@SizeType";
                adp.SelectCommand.Parameters.AddWithValue("@SizeType", txtSizetype.Text.Trim());
                DataSet ds = new DataSet();
                adp.Fill (ds );
                if (ds.Tables[0].Rows.Count > 0)
                {
                    val = true;
                }
                return val;
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("SizeType", "newInsert_chk", er);
            }
            return val;
        }
        private bool edit_Chk()
        {
            bool val=false ;
            try
            {
               SqlConnection con = new SqlConnection();
               con.ConnectionString = clsDbForReports.constr;
               SqlDataAdapter adp=new SqlDataAdapter ("",con );
               adp.SelectCommand.CommandText = "select SizeTypeId from tSizeType where SizeTypeId!=@SizeTypeId and SizeType=@SizeType";
               adp.SelectCommand.Parameters.AddWithValue("@SizeType", txtSizetype.Text.Trim());
               adp.SelectCommand.Parameters.AddWithValue("@SizeTypeId", y);
               DataSet ds = new DataSet();
               adp.Fill(ds);
               if(ds.Tables[0].Rows.Count >0)
               {
                    val=true ;
               }
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("SizeType", "edit_Chk", er);
            }
           return val;
        }
        private bool  delSize_Chk()
        {
            bool val = false;
            try
            {
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select SizeTypeId from tStyleMaster where SizeTypeId=@SizeTypeId";
                adp.SelectCommand.Parameters.AddWithValue("@SizeTypeId", y);
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
                eobj.write("SizeType", "delSize_Chk", er);
            }
            return val;
        }
        private void tSizetypeLog_ins(char op, int y)
        {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constrlog;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = " insert into tSizeTypeLog(accessId,userId,operation,dt,time) values(@accessId,@userId,@operation,@dt,@tim)";
                cmd.Parameters.AddWithValue("@accessId", y);
                cmd.Parameters.AddWithValue("@userId", clsDbForReports.userid);
                cmd.Parameters.AddWithValue("@operation", op);
                cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@tim", DateTime.Now.ToShortTimeString());
                cmd.ExecuteNonQuery();
                con.Close();
        }
    }   
}
