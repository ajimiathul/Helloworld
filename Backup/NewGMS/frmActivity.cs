using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmActivity : Form
    {
        string newedit = "New";
        int Acode = 0;
        bool flag = false;

        public frmActivity()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStyle_Load(object sender, EventArgs e)
        {
            flag = false;
            LoadUnit();
            LoadSubCategory();
            LoadOrderNo();
            LoadOperator();
            cmbOrder.Text = "1";
            flag = true;
            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid();
            }
            else
            {
                ViewInGrid2();
            }
            label3.Text = "0";
            label4.Text = "New Mode";
        }

        private void LoadUnit()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select UnitId,unit from UnitMaster order by unit";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUnit.DataSource = ds.Tables[0];
            cmbUnit.DisplayMember = "unit";
            cmbUnit.ValueMember = "unitid";       
        }


        private void LoadOperator()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select operatorid,Operator  from tOperatorType ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbOperator .DataSource = ds.Tables[0];
            cmbOperator.DisplayMember = "operator";
            cmbOperator.ValueMember = "operatorid";
        }


        private void LoadSubCategory()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select SubCategory,SubCategoryId  from tSubCategory order by SubCategory";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSubCat.DataSource = ds.Tables[0];
            cmbSubCat.DisplayMember = "SubCategory";
            cmbSubCat.ValueMember = "SubCategoryId";
        }

        private void LoadOrderNo()
        {
            for (int i = 1; i <= 100; i++)
            { 
                cmbOrder.Items.Add(i.ToString());
            }
        }

        private bool InsertChk()
        {
            bool ret = true;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "select COUNT(*) from tActivity where rtrim(ltrim(ActivityName)) =@anm and SubCategoryId =@scat";
            sda.SelectCommand.CommandText = cmdstr;
            sda.SelectCommand.Parameters.AddWithValue("@anm",txtActivity.Text.Trim ());
            sda.SelectCommand.Parameters.AddWithValue("@scat",Convert.ToInt32(cmbSubCat.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32 ( ds.Tables[0].Rows[0][0].ToString ()) >=1)
            {
                ret = false;
            }
            return ret;
        }


        private bool UpdateChk()
        {
            bool ret = true;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "select COUNT(*) from tActivity where ActivityName =@anm and SubCategoryId =@scat and activitycode=@ac";
            sda.SelectCommand.CommandText = cmdstr;
            sda.SelectCommand.Parameters.AddWithValue("@anm", txtActivity.Text.Trim());
            sda.SelectCommand.Parameters.AddWithValue("@scat", Convert.ToInt32(cmbSubCat.SelectedValue));            
            sda.SelectCommand.Parameters.AddWithValue("@ac", Acode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) >= 1)
            {
                ret = false;
            }        
            return ret;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtActivity.Text.Trim().Length != 0)
            {
                if (newedit == "New")
                {
                    if (InsertChk() == true)
                    {
                        InsertActivity();
                    }
                    else
                    {
                        MessageBox.Show("Activity already exists");
                    }
                }
                else
                {
                    if (UpdateChk() == true)
                    {
                        UpdateActivity();
                    }
                    else
                    {
                        MessageBox.Show("Activity already exists for another id");
                    }
                }
            }

            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid();
            }
            else
            {
                ViewInGrid2();
            }

            label3.Text = Acode.ToString();
        }

        private void UpdateActivity()
        {
            if (Acode  != 0)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "update tActivity set activityName=@AName ,ShortName=@SName,UnitPrice=@UPrice ,UnitId=@UId,SubCategoryId=@SCId,ORDERNO=@ONO,operatorTypeId=@oTId  where activitycode=@acode";
                scmd.Parameters.AddWithValue("@AName", txtActivity.Text);
                scmd.Parameters.AddWithValue("@SName", txtShortActivityname.Text);
                scmd.Parameters.AddWithValue("@UPrice", txtUnitPrice.Text);
                scmd.Parameters.AddWithValue("@UId", Convert.ToInt32(cmbUnit.SelectedValue));
                scmd.Parameters.AddWithValue("@SCId", Convert.ToInt32(cmbSubCat.SelectedValue));
                scmd.Parameters.AddWithValue("@ONO", Convert.ToInt32(cmbOrder.Text ));
                scmd.Parameters.AddWithValue("@oTId", Convert.ToInt32(cmbOperator.SelectedValue)); 
                scmd.Parameters.AddWithValue("@acode",Acode);
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
            scmd.Parameters.AddWithValue("@scr", "Activity");
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
            scmd.Parameters.AddWithValue("@scr", "Activity");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        

        private void InsertActivity()
        {
            Acode  = ReadLastNum() ;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert into tActivity (Activitycode,ActivityName ,ShortName,UnitPrice ,UnitId,SubCategoryId,ORDERNO,operatorTypeId) values(@Activitycode,@AName ,@SName,@UPrice ,@UId,@SCId,@ONO,@oTId)";
            scmd.Parameters.AddWithValue("@Activitycode", Acode);
            scmd.Parameters.AddWithValue("@AName", txtActivity.Text);
            scmd.Parameters.AddWithValue("@SName", txtShortActivityname.Text );
            scmd.Parameters.AddWithValue("@UPrice", txtUnitPrice.Text);
            scmd.Parameters.AddWithValue("@UId",Convert.ToInt32 (cmbUnit.SelectedValue ));
            scmd.Parameters.AddWithValue("@SCId", Convert.ToInt32(cmbSubCat.SelectedValue));
            scmd.Parameters.AddWithValue("@ONO", Convert.ToInt32(cmbOrder.Text));
            scmd.Parameters.AddWithValue("@oTId", Convert.ToInt32(cmbOperator.SelectedValue));            
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void ViewInGrid()
        {
            if (flag == true)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                string cmdstr = "";
                cmdstr = "select activitycode,activityName,ShortName,UnitPrice,c.Unit ,b.SubCategory,ORDERNO from tactivity a,tSubCategory b,UnitMaster c where a.UnitId = c.UnitId and a.SubCategoryId = b.SubCategoryId and a.SubCategoryId=@sid  order by orderno";
                sda.SelectCommand.CommandText = cmdstr;
                sda.SelectCommand.Parameters.AddWithValue("@sid", Convert.ToInt32(cmbSubCat.SelectedValue.ToString()));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }


        private void ViewInGrid2()
        {
            if (flag == true)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                string cmdstr = "";
                cmdstr = "select activitycode,activityName,ShortName,UnitPrice,c.Unit ,b.SubCategory,ORDERNO from tactivity a,tSubCategory b,UnitMaster c where a.UnitId = c.UnitId and a.SubCategoryId = b.SubCategoryId order by activitycode desc";
                sda.SelectCommand.CommandText = cmdstr;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newedit == "Edit")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    Acode  = Convert.ToInt32(dataGridView1.Rows[x].Cells[0].Value.ToString());
                    LoadFormData(Acode);
                }
            }
            else
            {
                MessageBox.Show("Not in Edit Mode");
            }
        }

        private void LoadFormData(int acode)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select ActivityName,ShortName,UnitPrice,UnitId  ,SubCategoryId ,ORDERNO,operatorTypeId from tactivity where activitycode=@acode";
            sda.SelectCommand.Parameters.AddWithValue("@acode", acode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUnit.SelectedValue = ds.Tables[0].Rows[0]["UnitId"].ToString();
            txtActivity.Text = ds.Tables[0].Rows[0]["Activityname"].ToString();
            txtShortActivityname .Text = ds.Tables[0].Rows[0]["shortname"].ToString();
            txtUnitPrice.Text = ds.Tables[0].Rows[0]["UnitPrice"].ToString();
            cmbOrder.Text  = ds.Tables[0].Rows[0]["ORDERNO"].ToString();
            cmbSubCat.SelectedValue = ds.Tables[0].Rows[0]["SubCategoryId"].ToString();
            cmbOperator.SelectedValue = ds.Tables[0].Rows[0]["operatorTypeId"].ToString();
            label3.Text = acode.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newedit = "New";
            label4.Text = "New Mode";
            Acode= 0;
            label3.Text = Acode.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            newedit = "Edit";
            label4.Text = "Edit Mode";
            Acode = 0;
            label3.Text = Acode.ToString();
        }

        private void rbCat_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid();
            }
            else
            {
                ViewInGrid2();
            }

            
        }

        private void rbStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid();
            }
            else
            {
                ViewInGrid2();
            }

        }

        private void txtStyleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtActivity.Text = "";
            txtShortActivityname.Text = "";
            Acode = 0;
            label3.Text = "0";
            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid();
            }
            else
            {
                ViewInGrid2();
            }

        }

        private void cbSubCatFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubCatFilter.Checked == true)
            {
                ViewInGrid();
            }
            else
            {
                ViewInGrid2();
            }

        }        

    }
}
