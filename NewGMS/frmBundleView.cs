using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmBundleView : Form
    {
        bool layFlag = false;
        bool bundleFlag = false;

        public frmBundleView()
        {
            InitializeComponent();
        }

        
        private void btnPnd_Click(object sender, EventArgs e)
        {
            dgvCompleted.Rows.Clear();
            dgvPending.Rows.Clear();
            if (cbCompleted.Checked == true)
            {
                ShowCompletedActivities();
            }
            if (cbPending.Checked == true)
            {
                ShowPndActivities();
            }
        }

        private void ShowCompletedActivities()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = " select convert(nvarchar(10),a.proddate,103) as dt,b.timedescription,a.activityname , ";
            string s2 = " c.employeename,qty,a.empid from tProdActivites a, ttimecode b, employee c ";
            string s3 = " where a.timecode=b.timecode and c.empid = a.empid  ";
            string s4 = " and  a.LayerBatchNo =@lbno and a.BunIntNo =@bno and a.stylecode=@stcode ";
            string s5 = " order by a.proddate ";
            sda.SelectCommand.CommandText = s1 + s2 + s3 + s4 + s5;
            sda.SelectCommand.Parameters.AddWithValue("@lbno", Convert.ToInt32(cmbLayBNO.SelectedValue ));
            sda.SelectCommand.Parameters.AddWithValue("@bno", Convert.ToInt32(cmbBundle.SelectedValue ));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int x = 0;
            dgvCompleted.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvCompleted.Rows.Add(1);
                x = dgvCompleted.Rows.Count;
                dgvCompleted.Rows[x - 1].Cells["dgvCmpColDate"].Value = ds.Tables[0].Rows[i]["dt"].ToString();
                dgvCompleted.Rows[x - 1].Cells["dgvCmpColTime"].Value = ds.Tables[0].Rows[i]["timedescription"].ToString();
                dgvCompleted.Rows[x - 1].Cells["dgvCmpColActivity"].Value = ds.Tables[0].Rows[i]["activityname"].ToString();
                dgvCompleted.Rows[x - 1].Cells["dgvCmpColEmp"].Value = ds.Tables[0].Rows[i]["employeename"].ToString();
                dgvCompleted.Rows[x - 1].Cells["dgvCmpColEmpid"].Value = ds.Tables[0].Rows[i]["empid"].ToString();
                dgvCompleted.Rows[x - 1].Cells["dgvCmpColPcs"].Value = ds.Tables[0].Rows[i]["qty"].ToString();                
                
            }
        }

        private void ShowPndActivities()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = " select Activityname,qty,cmpqty,pndqty ";
            string s2 = " from tLayCutBunAct where layerbatchno = @lbno and BunIntno = @bno and stylecode=@stcode  ";
            sda.SelectCommand.CommandText = s1 + s2;
            sda.SelectCommand.Parameters.AddWithValue("@lbno", Convert.ToInt32(cmbLayBNO.SelectedValue  ));
            sda.SelectCommand.Parameters.AddWithValue("@bno", Convert.ToInt32(cmbBundle.SelectedValue ));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int x = 0;
            dgvPending.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvPending.Rows.Add(1);
                x = dgvPending.Rows.Count;
                dgvPending.Rows[x - 1].Cells["dgvPndColAct"].Value = ds.Tables[0].Rows[i]["activityname"].ToString();
                dgvPending.Rows[x - 1].Cells["dgvPndColTotal"].Value = ds.Tables[0].Rows[i]["qty"].ToString();
                dgvPending.Rows[x - 1].Cells["dgvPndColcqty"].Value = ds.Tables[0].Rows[i]["cmpqty"].ToString();
                dgvPending.Rows[x - 1].Cells["dgvPndColpqty"].Value = ds.Tables[0].Rows[i]["pndqty"].ToString();
            }
        }

        private void frmBundleView_Load(object sender, EventArgs e)
        {
            layFlag = false;
            LoadStyleCode();
            LoadLayBNo();
            layFlag = true;
            bundleFlag = false;
            LoadBundleNumbers();
            bundleFlag = true;
        }

        private void LoadLayBNo()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select LayerBatchNo from tLayerCutHD where stylecode=@stcode order by LayerBatchNo desc";
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbLayBNO.DataSource = ds.Tables[0];
            cmbLayBNO.DisplayMember = "LayerBatchNo";
            cmbLayBNO.ValueMember = "LayerBatchNo";
        }

        private void LoadBundleNumbers()
        {
            if (bundleFlag == true)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                sda.SelectCommand.CommandText = "select bunIntNo from tLayerCutBundle where layerbatchNo=@lbno and StyleCode=@stcode";
                sda.SelectCommand.Parameters.AddWithValue("@lbno", Convert.ToInt32(cmbLayBNO.Text));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmbBundle.DataSource = ds.Tables[0];
                cmbBundle.DisplayMember = "bunIntNo";
                cmbBundle.ValueMember = "bunIntNo";
            }
        }

        private void LoadStyleCode()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select styleCode from tStyleMaster order by stylecode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle.DataSource = ds.Tables[0];
            cmbStyle.DisplayMember = "stylecode";
            cmbStyle.ValueMember = "stylecode";
        }

        private void cmbLayBNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layFlag == true)
            {
                LoadBundleNumbers();
            }
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLayBNo();
        }

        private void cmbBundle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
