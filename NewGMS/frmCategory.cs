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
    public partial class frmCategory : Form
    {
        int y;
        public string mode;
        int returnvalue;
        public frmCategory()
        {
            InitializeComponent();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            lblMode.Text = "Mode : New";
            mode = "New";
            showdata();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCategory.Text.Trim () == "")
                 MessageBox.Show("Enter any  Data");
            else if (mode == "New")
            {
                bool  x = NewInsert_Check();
                if (x==false )
                    btnNew_Save();
                else
                {
                    MessageBox.Show("Data already exists");
                    txtCategory.Text = "";
                }
            }
            else if (mode == "Edit")
            {
                bool  k = editCat_Chk();
                if (k == true )
                {
                    MessageBox.Show("Data already exists");
                    txtCategory.Text = "";
                }
                else
                    btnEdit_Save();
            }
         }
        private void btnNew_Click(object sender, EventArgs e)
        {
             lblMode.Text = "Mode : New";
              mode = "New";
              txtCategory.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool  x;
            if (txtCategory.Text.Trim () == "")
                MessageBox.Show("Enter any Data");
            else if (mode == "New")
                MessageBox.Show("Not in edit mode");
            else if(mode=="Edit")
            {
                x = delChk_Category();
                if (x == false )
                    delCategory_fun();
                else
                {
                    MessageBox.Show("Cannot delete since data exists in another table");
                    txtCategory.Text = "";
                }
            }              
            showdata();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showdata()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select CategoryId,Category  from tCategory order by CategoryId desc ";
                DataSet ds = new DataSet();
                adp.Fill(ds);
                datagridCategory.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "showdata", er);
            }
        }
        private void datagridCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            int i = e.RowIndex;
            if (i != -1)
            {
                celldoubleclick(i);
            }
        }
        private void celldoubleclick(int b)
        {
            try
            {
                mode = "Edit";
                lblMode.Text = "Mode : Edit";
                y = Convert.ToInt32(datagridCategory.Rows[b].Cells[0].Value);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                string str = "select Category from tCategory where CategoryId=@categoryid";
                adp.SelectCommand.CommandText = str;
                adp.SelectCommand.Parameters.AddWithValue("@categoryid", y);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                txtCategory.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "celldoubleclick", er);
            }
        }
        private void delCategory_fun()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlCommand cmd = new SqlCommand("", con);
                con.Open();
                cmd.CommandText = "tcat_del";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryId", y);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Deleted Successfully");

                con.Close();
                insertcategorylog(y, 'D');
                txtCategory.Text = "";
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "delCategory_fun", er);
            }
        }
        private void btnNew_Save()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "cat_ins";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@compcode", clsDbForReports.companycode);
                cmd.Parameters.AddWithValue("@offcode", clsDbForReports.officecode);
                cmd.Parameters.AddWithValue("@catgry", txtCategory.Text);
                cmd.Parameters.AddWithValue("@catid", 0).Direction = ParameterDirection.Output;
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Inserted Successfully");
                else
                    MessageBox.Show("Insertion Failed");
                returnvalue = (int)cmd.Parameters["@catid"].Value;
                con.Close();
                insertcategorylog(returnvalue,'N');
                txtCategory.Text = "";
                showdata();
            }
            catch (Exception e)
            {                
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
        }
        private void btnEdit_Save()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "update tCategory set Category=@category where CategoryId=@categoryid";
                cmd.Parameters.AddWithValue("@categoryid", y);
                cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                    MessageBox.Show("Updated Successfully");
                else
                    MessageBox.Show("Updation Failed");
                con.Close();
                insertcategorylog(y, 'E');
                txtCategory.Text = "";
                showdata();
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnEdit_Save", er);
            }
        }
        private bool NewInsert_Check()
        {
            bool val = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("", con);
                adp.SelectCommand.CommandText = "select CategoryId from tCategory where Category=@Category";
                adp.SelectCommand.Parameters.AddWithValue("@Category",txtCategory .Text .Trim());
                DataSet ds = new DataSet();
                adp.Fill (ds);
                if (ds.Tables [0].Rows.Count >0)
                {
                    val = true;
                }
            }
            catch (Exception e)
            {
                string er;
                er = e.ToString();
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "NewInsert_Check", er);
            }
            return val;
        }
        private bool  editCat_Chk()
        {
            bool val = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("",con );
                adp.SelectCommand.CommandText = "select  CategoryId from tCategory where Category=@Category and CategoryId!=@CategoryId";
                adp.SelectCommand.Parameters.AddWithValue("@Category",txtCategory .Text.Trim ());
                adp.SelectCommand.Parameters.AddWithValue("@CategoryId",y );
                DataSet ds = new DataSet();
                adp.Fill(ds );
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
                eobj.write("Category", "editCat_Chk", er);
            }
            return val;
        }
        private bool  delChk_Category()
        {
            bool val = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter adp = new SqlDataAdapter("",con );
                adp.SelectCommand.CommandText = "select CategoryId from tSubCategory where CategoryId=@CategoryId";
                adp.SelectCommand.Parameters.AddWithValue("@CategoryId", y);
                DataSet ds = new DataSet();
                adp.Fill(ds );
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
                eobj.write("Category", "delChk_Category", er);

            }
            return val;
        }
        private void insertcategorylog(int k, char op)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constrlog;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "insert into tCategoryLog (accessId,userId,operation,dt,tim)values(@accessid,@userid,@operation,@dt,@tim)";
            cmd.Parameters.AddWithValue("@accessid", k);
            cmd.Parameters.AddWithValue("@userid", clsDbForReports.userid);
            cmd.Parameters.AddWithValue("@operation", op);
            cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@tim", DateTime.Now.ToShortTimeString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

        
    

