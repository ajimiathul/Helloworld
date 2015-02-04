using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmDesignation : Form
    {
        string newedit = "New";
        int dcode = 0;
       
        public frmDesignation()
        {
            InitializeComponent();
        }

        private void frmDesignation_Load(object sender, EventArgs e)
        {
            LoadOrderNo();
            ViewInGrid();
            newedit = "New";
            label4.Text = "New Mode";
        }
        
        private void LoadOrderNo()
        {
            for (int i = 1; i <= 100; i++)
            {
                cmbOrder.Items.Add(i.ToString());
            }
        }

        private void ViewInGrid()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "";
            cmdstr = "select DesignationId,Designation,disporder from Designation order by DesignationId desc";
            sda.SelectCommand.CommandText = cmdstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newedit = "New";
            label4.Text = "New Mode";
            dcode = 0;
            label3.Text = dcode.ToString();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            newedit = "Edit";
            label4.Text = "Edit Mode";
            dcode = 0;
            label3.Text = dcode.ToString();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (newedit == "New")
            {
                if (DuplicateInsertChk() == false)
                {
                    InsertDes();
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
                    UpdateDes();
                }
                else
                {
                    MessageBox.Show("Already exists for another Designation Code");
                }
            }
            label3.Text = dcode.ToString();
            ViewInGrid();
        }

        private bool DuplicateInsertChk()
        {
            bool ret = false;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select DesignationId  from Designation where Designation=@Designation";
            sda.SelectCommand.Parameters.AddWithValue("@Designation", txtDesignation.Text.Trim());
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
            sda.SelectCommand.CommandText = "select DesignationId  from Designation where DesignationId!=@dcode and Designation=@Designation";
            sda.SelectCommand.Parameters.AddWithValue("@dcode", dcode);
            sda.SelectCommand.Parameters.AddWithValue("@Designation", txtDesignation.Text.Trim());

            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }

        private void InsertDes()
        {
            if (cmbOrder.Text != null)
            {
                if (cmbOrder.Text.Trim().Length != 0)
                {
            
            dcode = ReadLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert Designation(DesignationId,Designation,disporder) Values(@desid,@desi,@ord)";
            scmd.Parameters.AddWithValue("@desid", dcode);
            scmd.Parameters.AddWithValue("@desi", txtDesignation.Text);
            scmd.Parameters.AddWithValue("@ord", Convert.ToInt32(cmbOrder.Text));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
                }
                else
                {
                    MessageBox.Show("Select order");
                }
            }
            else
            {
                MessageBox.Show("Select order");
            }
        }


        private int ReadLastNum()
        {
            UpdateLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "select lastnum from tNumbers where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "Designation");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "Designation");
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void UpdateDes()
        {
            if (dcode != 0)
            {
                if (cmbOrder.Text != null)
                {
                if (cmbOrder.Text.Trim().Length != 0)
                {
            
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "update Designation set Designation=@Designation,disporder=@ord where DesignationId=@dcode";
                scmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                scmd.Parameters.AddWithValue("@ord", Convert.ToInt32(cmbOrder.Text));
                scmd.Parameters.AddWithValue("@dcode", dcode);
                int i = scmd.ExecuteNonQuery();
                sc.Close();
                }
                else
                {
                    MessageBox.Show("Select order");
                }
                }
                else
                {
                    MessageBox.Show("Select order");
                }

            }
        }


        private void LoadStockDetails(int dcode)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select Designation,disporder from Designation where DesignationId=@dcode";
            sda.SelectCommand.Parameters.AddWithValue("@dcode", dcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbOrder.SelectedValue = ds.Tables[0].Rows[0]["disporder"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
            label3.Text = dcode.ToString();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newedit == "Edit")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    dcode = Convert.ToInt32(dataGridView1.Rows[x].Cells[0].Value.ToString());
                    LoadStockDetails(dcode);
                }
            }
            else
            {
                MessageBox.Show("Not in Edit Mode");
            }
        }

        
        
    }
}
