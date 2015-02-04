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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace NewGMS
{
    public partial class frmSubCategory : Form
    {
        string mode;
        int globalID = 0;

        public frmSubCategory()
        {
            InitializeComponent();
        }

        int flag = 0;
        void LoadSubCat()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select SubCategory, SubCategoryId from tSubCategory order by SubCategory";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSubCategory.DataSource = ds.Tables[0];
            cmbSubCategory.DisplayMember = "SubCategory";
            cmbSubCategory.ValueMember = "SubCategoryId";

        }
        void fillprocess()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select process  from tprocess order by process";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grid1.Rows = grid1.Rows + 1;
                j = i + 1;
                grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["process"].ToString();
                //grid1.Cell(j, 2).Text =

                grid1.Cell(j, 1).Locked = true;

            }

        }
        void naminggrid()
        {
            grid1.Cell(0, 1).Text = "Process";
            grid1.Cell(0, 2).Text = "Activity";
            grid1.Column(2).Width = 200;
            grid1.Column(2).CellType = FlexCell.CellTypeEnum.ComboBox;
        }
        void fillActivity()
        {
            int st = Convert.ToInt32(cmbSubCategory.SelectedValue.ToString());
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            //sda.SelectCommand.CommandText = "select A.ActivityName ,A.ActivityCode  from tActivity A  join  tSubCategory ts  on A.SubCategoryId =ts.SubCategoryId  where ts.SubCategoryId = @sc union  select 'NA' ActivityName, 0 ActivityCode";
            sda.SelectCommand.CommandText = "select A.ActivityName ,A.ActivityCode  from tActivity A  where a.SubCategoryId  = @sc union  select 'NA' ActivityName, 0 ActivityCode";
            sda.SelectCommand.Parameters.AddWithValue("@sc", st);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(2).DataSource = ds.Tables[0];
            grid1.ComboBox(2).DisplayMember = "ActivityName";
            grid1.ComboBox(2).ValueMember = "ActivityCode";            
        }

        private void frmSubCategory_Load(object sender, EventArgs e)
        {
            naminggrid();
            LoadSubCat();
            //fillprocess();
            flag = 1;
            
            mode = "new";
            show_grid();
            show_combo();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            gpbMode.Text = "Mode : New";
            mode="new";
            txtSubCategory.Text = "";
        }
        private void txtSubCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Enabled = true;
        }       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSubCategory.Text == "")
            {
                MessageBox.Show("Must enter any data");
            }
            else if (mode=="new")
            {
                if (Newinsertcheck() == true)
                    MessageBox.Show("Data already exist");
                else
                    InsertSubCat();
            }
            else
            if (mode=="edit")
            {
                if (EditCheck() == false)
                    EditSubCat();
                else
                    MessageBox.Show("Data already exists");
            }
            txtSubCategory.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSubCategory.Text == "")
                MessageBox.Show("Must select any data");
            else
            {
                if (DelCheck() == true)
                    MessageBox.Show("Could not delete");
                else
                    DeleteSubCat();
                txtSubCategory.Text = "";
            }
        }
        private void dgvSubCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex;
            if (x != -1)
            {
                Celldoubleclick(x);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void show_grid()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select A.SubCategoryId,A.SubCategory,B.Category from tSubCategory A inner join tCategory B on A.CategoryId=B.CategoryId order by A.SubCategoryId";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgvSubCategory.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }

        }
        private void show_combo()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "SELECT Category,CategoryId FROM tCategory";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmbCategory.DataSource = ds.Tables[0];
                cmbCategory.DisplayMember = "Category";
                cmbCategory.ValueMember = "CategoryId";
            }
            catch(Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
        }
        private void Celldoubleclick(int x)
        {
            try
            {
                gpbMode.Text = "Mode : Edit";
                mode = "edit";
                globalID = Convert.ToInt32(dgvSubCategory.Rows[x].Cells[0].Value);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select A.SubCategory,B.Category from tSubCategory A inner join tCategory B on A.CategoryId=B.CategoryId where SubCategoryId=@id";
                sda.SelectCommand.Parameters.AddWithValue("@id", globalID);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                txtSubCategory.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
        }
        
        private void InsertSubCat()
        {
            int k = Insertsubmethod();
            show_grid();
            SubCatlog(k,'N');
        }
        private void EditSubCat()
        {
            Editsubmethod();
            show_grid();
            SubCatlog(globalID, 'E');
        }
        private void DeleteSubCat()
        {
            Deletesubmethod();
            show_grid();
            SubCatlog(globalID, 'D');
        }
        private int Insertsubmethod()
        {
            int k = 0;
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "subcat_sel_ins";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@compcode", clsDbForReports.companycode);
                cmd.Parameters.AddWithValue("@offcode", 100);
                cmd.Parameters.AddWithValue("@catid", cmbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@subcat", txtSubCategory.Text);
                cmd.Parameters.AddWithValue("@subcatid", 0).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                int returnvalue = (int)cmd.Parameters["@subcatid"].Value;
                k = Convert.ToInt32(returnvalue);
            }
            catch (Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
            finally
            {
                con.Close();
            }
            return k;                       
        }
        private bool Newinsertcheck()
        {
            bool chck = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;                
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select SubCategoryId from tSubCategory where SubCategory=@subcat";
                sda.SelectCommand.Parameters.AddWithValue("@subcat", txtSubCategory.Text);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chck = true;
                }
            }
            catch (Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
            return chck;
        }
        private void Editsubmethod()
        {
            SqlConnection con2 = new SqlConnection();
            try
            {
                con2.ConnectionString = clsDbForReports.constr;
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("", con2);
                cmd2.CommandText = "Update tSubCategory set SubCategory=@subnm2 WHERE SubCategoryId=@id";
                cmd2.Parameters.AddWithValue("@id", globalID);
                cmd2.Parameters.AddWithValue("subnm2", txtSubCategory.Text);
                int i = cmd2.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Updated");
                }
            }
            catch (Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
            finally
            {
                con2.Close();
            }
        }
        private bool EditCheck()
        {
            bool ck = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select SubCategoryId from tSubCategory where SubCategory= @subcat and SubCategoryId<>@id";
                sda.SelectCommand.Parameters.AddWithValue("@id", globalID);
                sda.SelectCommand.Parameters.AddWithValue("@subcat", txtSubCategory.Text);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ck = true;
                }
            }
            catch(Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
            return ck;

        }
        private void Deletesubmethod()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "subcat_del";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@subcatid", globalID);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Deleted");
                }
                txtSubCategory.Text = "";
            }
            catch (Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private bool DelCheck()
        {
            bool ckdel=false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select SubCategoryId from tStyleMaster where SubCategoryId=@id";
                sda.SelectCommand .Parameters.AddWithValue("@id", globalID);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ckdel = true;
                }
            }
            catch (Exception e)
            {
                Clserrlogr eobj = new Clserrlogr();
                eobj.write("Category", "btnNew_Save", e.Message);
            }
            return ckdel;
        }
        private void SubCatlog(int id, char c)
        {
            SqlConnection conlog = new SqlConnection();
            try
            {
                conlog.ConnectionString = clsDbForReports.constrlog;
                conlog.Open();
                SqlCommand cmdlog = new SqlCommand("", conlog);
                cmdlog.CommandText = "INSERT INTO tSubCategoryLog(accessId,userId,operation,dt) VALUES(@accessId,@userId,@operation,@dt)";
                cmdlog.Parameters.AddWithValue("@accessId", id);
                cmdlog.Parameters.AddWithValue("@userId", clsDbForReports.userid);
                cmdlog.Parameters.AddWithValue("@operation", c);
                cmdlog.Parameters.AddWithValue("@dt", DateTime.Now);
                cmdlog.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                conlog.Close();
            }           
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                fillActivity();
                comboSelect();
            }
        }
        void comboSelect()
        {
            grid1.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = "select A.process,C.ActivityName  from tProcess A left join tProcessEqtSubCat B on";
            string s2 = " A.processid = B.processid and B.SubcatCode = @subcode left join tActivity C on B.EqtActCode = C.ActivityCode";
            sda.SelectCommand.CommandText = s1 + s2;
            int st = Convert.ToInt32(cmbSubCategory.SelectedValue.ToString());
            sda.SelectCommand.Parameters.AddWithValue("@subcode", st);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grid1.Rows = grid1.Rows + 1;
                int j = i + 1;

                grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["process"].ToString();
                grid1.Cell(j, 2).Text = ds.Tables[0].Rows[i]["ActivityName"].ToString();

            }
            for (int m = 1; m < grid1.Rows; m++)
            {
                if (grid1.Cell(m, 2).Text.Trim().Length == 0)
                {
                    grid1.Cell(m, 2).Text = "NA";
                }

            }

        }

        private void grid1_Load(object sender, EventArgs e)
        {

        }

        private void grid1_Click(object Sender, EventArgs e)
        {
            if (grid1.ActiveCell.Col == 2)
            {
                grid1.Cell(grid1.ActiveCell.Row, 2).SetFocus();
            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            DelSubCat();
            saveProcessSubCat();
        }


        void DelSubCat()
        { 
            int st =  Convert.ToInt32 ( cmbSubCategory.SelectedValue.ToString());
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete from tProcessEqtSubCat  where SubcatCode =@scode";
            cmd.Parameters.AddWithValue("@scode", st);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        void saveProcessSubCat()
        {
            string st = cmbSubCategory.SelectedValue.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            int loop = 0;
            for (int i = 0; i < grid1.Rows - 1; i++)
            {
                cmd.Parameters.Clear();
                loop = i + 1;
                string strr = grid1.Cell(loop, 1).Text.ToString();
                int prid = getprocessid(strr);
                cmd.CommandText = "INSERT INTO tProcessEqtSubCat(SubcatCode,processid,EqtActCode) VALUES(@sc,@procid,@actcode)";
                cmd.Parameters.AddWithValue("@sc", st);
                cmd.Parameters.AddWithValue("@procid", prid);
                cmd.Parameters.AddWithValue("@actcode", Convert.ToInt32(grid1.ComboBox(2).GetItemValue(grid1.Cell(loop, 2).Text).ToString()));
                cmd.ExecuteNonQuery();                
            }
            con.Close();
            MessageBox.Show("Sucess");
        }

        int getprocessid(string proc)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "Select processid from tprocess where process=@Pr";
            sda.SelectCommand.Parameters.AddWithValue("@pr", proc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int pid = Convert.ToInt32(ds.Tables[0].Rows[0]["processid"].ToString());
            con.Close();
            return (pid);
        }

        //Boolean exitdata(int pid)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = clsDbForReports.constr;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("", con);
        //    cmd.CommandText = "select COUNT(*)  cnt from tProcessEqtSubCat where SubcatCode =@stcode and processid =@id";
        //    cmd.Parameters.AddWithValue("@stcode", cmbSubCategory.SelectedValue.ToString());
        //    cmd.Parameters.AddWithValue("@id", pid);

        //    int i = Convert.ToInt32(cmd.ExecuteScalar());
        //    if (i > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }


        //}

        private void cmbSubCategory_ValueMemberChanged(object sender, EventArgs e)
        {
            fillActivity();
            comboSelect();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                LoadSubCat();

            }
        }


        
    }
}
