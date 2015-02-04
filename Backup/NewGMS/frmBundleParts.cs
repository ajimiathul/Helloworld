using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmBundleParts : Form
    {
        public int pcode;
        string newedit = "New";
        bool flag = false;
        
        public frmBundleParts()
        {
            InitializeComponent();
        }

        private void frmBundleParts_Load(object sender, EventArgs e)
        {
            LoadSubCategory();
            flag = true;
            ViewInGrid2();
            label3.Text = "0";
            label4.Text = "New Mode";
            
        }


        private void ViewInGrid()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "";
            cmdstr = "select a.partscode,a.partsname,b.subcategory from tbundleparts a,tsubcategory b where a.subcategoryid=b.subcategoryid";
            sda.SelectCommand.CommandText = cmdstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvParts.DataSource = ds.Tables[0];
        }

        private void ViewInGrid2()
        {
            if (flag == true)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                string cmdstr = "";
                cmdstr = "select a.partscode,a.partsname,b.subcategory from tbundleparts a,tsubcategory b where a.subcategoryid=b.subcategoryid and b.subcategoryid=@sc";
                sda.SelectCommand.CommandText = cmdstr;
                sda.SelectCommand.Parameters.AddWithValue("@sc", Convert.ToInt32(cmbSub.SelectedValue));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgvParts.DataSource = ds.Tables[0];
            }
        }

        private void LoadSubCategory()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select SubCategory,SubCategoryId  from tSubCategory order by SubCategory";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSub.DataSource = ds.Tables[0];
            cmbSub.DisplayMember = "SubCategory";
            cmbSub.ValueMember = "SubCategoryId";
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid2();
            }
            else
            {
                ViewInGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (newedit == "New")
            {
                if (InsertChk() == true)
                {
                    InsertParts();
                }
                else
                {
                    MessageBox.Show("Already exists");
                }                
            }
            else
            {
                if (UpdateChk() == true)
                {
                    UpdateParts();
                }
                else
                {
                    MessageBox.Show("Already exists");
                }
            }
            ViewInGrid2();
            label3.Text = pcode.ToString();
        }

        private bool UpdateChk()
        {
            bool ret = true;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "select COUNT(*) from tBundleParts where rtrim(ltrim(partsname)) =@anm and SubCategoryId =@scat and partscode=@pcode";
            sda.SelectCommand.CommandText = cmdstr;
            sda.SelectCommand.Parameters.AddWithValue("@anm", txtParts.Text.Trim());
            sda.SelectCommand.Parameters.AddWithValue("@scat", Convert.ToInt32(cmbSub.SelectedValue));            
            sda.SelectCommand.Parameters.AddWithValue("@pcode", pcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) >= 1)
            {
                ret = false;
            }
            return ret;
        }


        private bool InsertChk()
        {
            bool ret = true;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "select COUNT(*) from tBundleParts where rtrim(ltrim(partsname)) =@anm and SubCategoryId =@scat";
            sda.SelectCommand.CommandText = cmdstr;
            sda.SelectCommand.Parameters.AddWithValue("@anm", txtParts.Text.Trim ());
            sda.SelectCommand.Parameters.AddWithValue("@scat", Convert.ToInt32(cmbSub.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) >= 1)
            {
                ret = false;
            }
            return ret;
        }

        private void UpdateParts()
        {
            if (pcode != 0)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "update tBundleParts set partsname=@pName  where partscode=@pcode and SubCategoryId=@SCId ";
                scmd.Parameters.AddWithValue("@pName", txtParts.Text.Trim ());
                scmd.Parameters.AddWithValue("@SCId", Convert.ToInt32(cmbSub.SelectedValue));
                scmd.Parameters.AddWithValue("@pcode", pcode);
                int i = scmd.ExecuteNonQuery();
                sc.Close();
            }
        }


        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "BundleParts");
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
            scmd.Parameters.AddWithValue("@scr", "BundleParts");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }



        private void InsertParts()
        {
            pcode = ReadLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert into tBundleParts (partscode,partsName ,SubCategoryId) values(@partscode,@pName,@SCId)";
            scmd.Parameters.AddWithValue("@partscode", pcode);
            scmd.Parameters.AddWithValue("@pName", txtParts.Text.Trim());
            scmd.Parameters.AddWithValue("@SCId", Convert.ToInt32(cmbSub.SelectedValue));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        
        private void dgvParts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (newedit == "Edit")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    pcode = Convert.ToInt32(dgvParts.Rows[x].Cells[0].Value.ToString());
                    LoadFormData();
                }
            }
            else
            {
                MessageBox.Show("Not in Edit Mode");
            }

        }

        private void LoadFormData()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select partsName ,SubCategoryId from tBundleParts where partscode=@pcode";
            sda.SelectCommand.Parameters.AddWithValue("@pcode", pcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            txtParts.Text = ds.Tables[0].Rows[0]["partsname"].ToString();
            cmbSub.SelectedValue = ds.Tables[0].Rows[0]["SubCategoryId"].ToString();
            label3.Text = pcode.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            newedit = "Edit";
            label4.Text = "Edit Mode";
            pcode = 0;
            label3.Text = pcode.ToString();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newedit = "New";
            label4.Text = "New Mode";
            pcode = 0;
            label3.Text = pcode.ToString();
        }

        private void cbSubCatFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid2();
            }
            else
            {
                ViewInGrid();
            }
        }

    }
}
