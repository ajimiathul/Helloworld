using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmItem : Form
    {
        string newedit = "New";
        int fcode = 0;
        public frmItem()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStyle_Load(object sender, EventArgs e)
        {
            LoadSupplier();
            ViewInGrid();
            label3.Text = "0";
            label4.Text = "New Mode";
        }

        private void LoadSupplier()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select suppliercode,suppliername  from tsupplier order by suppliername";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSup.DataSource = ds.Tables[0];
            cmbSup.DisplayMember = "suppliername";
            cmbSup.ValueMember = "suppliercode";       
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (newedit == "New")
            {
                if (DuplicateInsertChk() == false)
                {
                    InsertFabric();
                }
                else
                {
                    MessageBox.Show("Already exists");
                }
            }
            else
            {
                if (DuplicateUpdateChk() == false)
                {
                    UpdateFabric();
                }
                else
                {
                    MessageBox.Show("Already exists for another Item Code");
                }
            }
            label3.Text = fcode.ToString();
            ViewInGrid();
        }

        private bool DuplicateInsertChk()
        {
            bool ret = false;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select itemcode  from titem where itemcode=@icode";
            sda.SelectCommand.Parameters.AddWithValue("@icode", txtFabCode.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }

        private bool DuplicateUpdateChk()
        {
            bool ret = false;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select itemname  from titem where itemcode=@icode and ItemCodeInt!=@fc";
            sda.SelectCommand.Parameters.AddWithValue("@icode", txtFabCode.Text.Trim());
            sda.SelectCommand.Parameters.AddWithValue("@fc", fcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }

        private void UpdateFabric()
        {
            if (fcode  != 0)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "update tItem set itemname=@fn,itemcode=@fc,suplrcode=@sc,fabcolor=@fcolor where itemcodeint=@fcode";
                scmd.Parameters.AddWithValue("@fn", txtFabName.Text);
                scmd.Parameters.AddWithValue("@fc",txtFabCode.Text);
                scmd.Parameters.AddWithValue ("@sc",Convert.ToInt32(cmbSup.SelectedValue));
                scmd.Parameters.AddWithValue("@fcolor", txtColor.Text);
                scmd.Parameters.AddWithValue("@fcode",fcode);
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
            scmd.Parameters.AddWithValue("@scr", "Item");
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
            scmd.Parameters.AddWithValue("@scr", "Item");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        
        private void InsertFabric()
        {
            fcode  = ReadLastNum() ;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert tItem(ItemCodeInt,itemcode,itemname,suplrcode,fabcolor) Values(@fcInt,@fc,@fn,@sc,@fcolor)";
            scmd.Parameters.AddWithValue("@fcInt", fcode );
            scmd.Parameters.AddWithValue("@fn",txtFabName.Text  );
            scmd.Parameters.AddWithValue("@fc", txtFabCode.Text);
            scmd.Parameters.AddWithValue("@sc",Convert.ToInt32 (cmbSup.SelectedValue ));
            scmd.Parameters.AddWithValue("@fcolor", txtColor.Text); 
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void ViewInGrid()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "";
            cmdstr = "select a.itemcodeint,a.itemcode,a.itemname,b.suppliername,a.fabcolor from titem a,tsupplier b where a.suplrcode=b.suppliercode order by itemcodeint desc";            
            sda.SelectCommand.CommandText = cmdstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newedit == "Edit")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    fcode  = Convert.ToInt32(dataGridView1.Rows[x].Cells[0].Value.ToString());
                    LoadStockDetails(fcode);
                }
            }
            else
            {
                MessageBox.Show("Not in Edit Mode");
            }
        }

        private void LoadStockDetails(int fcode)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select itemcode,itemName,suplrcode,fabcolor from titem where itemcodeint=@fc";
            sda.SelectCommand.Parameters.AddWithValue("@fc", fcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSup.SelectedValue = ds.Tables[0].Rows[0]["suplrcode"].ToString();
            txtFabName.Text = ds.Tables[0].Rows[0]["itemName"].ToString();
            txtFabCode.Text = ds.Tables[0].Rows[0]["itemcode"].ToString();
            txtColor.Text = ds.Tables[0].Rows[0]["fabcolor"].ToString();
            label3.Text = fcode.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newedit = "New";
            label4.Text = "New Mode";
            fcode= 0;
            label3.Text = fcode.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            newedit = "Edit";
            label4.Text = "Edit Mode";
            fcode = 0;
            label3.Text = fcode.ToString();
        }

        private void rbCat_CheckedChanged(object sender, EventArgs e)
        {
            ViewInGrid();
        }

        private void rbStyle_CheckedChanged(object sender, EventArgs e)
        {
            ViewInGrid();
        }

        private void txtStyleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFabCode_TextChanged(object sender, EventArgs e)
        {
            txtFabName.Text = txtFabCode.Text;
        }        

    }
}
