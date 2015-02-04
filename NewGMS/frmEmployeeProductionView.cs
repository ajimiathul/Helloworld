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
    public partial class frmEmployeeProductionView : Form
    {
        bool nameFlag = false;
        int loopFlag = 0;

        public frmEmployeeProductionView()
        {
            InitializeComponent();
        }

        private void frmEmployeeProductionView_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = dtpTo.Value.AddDays(-31);
            nameFlag = false;
            LoadEmployee();
            nameFlag = true;
            txtID.Text = "10";
        }

        private void LoadEmployee()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,employeename from employee where activeorresigned='A'   order by employeename";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbName.DataSource = ds.Tables[0];
            cmbName.DisplayMember = "employeename";
            cmbName.ValueMember = "empid";
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loopFlag = loopFlag + 1;
            if (loopFlag == 1)
            {
                if (nameFlag == true)
                {
                    txtID.Text = cmbName.SelectedValue.ToString();
                }
            }
            loopFlag = 0;

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            loopFlag = loopFlag + 1;
            if ((txtID.Text.Trim().Length != 0) && (txtID.Text != null) && (loopFlag == 1))
            {
                cmbName.SelectedValue = txtID.Text;
            }
            loopFlag = 0;
        }

        private void ShowDtls()
        {
            dataGridView1.Columns.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = " select convert(nvarchar(10),a.proddate,103) as Date,b.timedescription Time,a.activityname  Activity, ";
            string s2 = " Qty,a.LayerBatchNo LotNo,a.BunIntNo BunNo,a.stylecode StyleCode from tProdActivites a, ttimecode b,tStyleActivities d ";
            string s3 = " where a.timecode=b.timecode and d.StyleCode  = a.Stylecode  ";
            string s4 = " and d.activitycode = a.activitycode and a.empid=@empid and proddate between @dtf and @dtt ";
            string s5 = " order by a.proddate ";
            sda.SelectCommand.CommandText = s1 + s2 + s3 + s4 + s5;
            sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
            sda.SelectCommand.Parameters.AddWithValue("@dtf", Convert.ToDateTime (dtpFrom.Value.ToShortDateString()));
            sda.SelectCommand.Parameters.AddWithValue("@dtt", Convert.ToDateTime(dtpTo.Value.ToShortDateString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[2].Width = 200;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowDtls();
        }
    }
}
