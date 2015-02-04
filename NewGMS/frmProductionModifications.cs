using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient ;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmProductionModifications : Form
    {
        bool layFlag = false;

        public frmProductionModifications()
        {
            InitializeComponent();
        }

        private void frmProductionModifications_Load(object sender, EventArgs e)
        {
            layFlag = false;
            LoadStyleCode();
            LoadLayBNo();
            layFlag = true;
            LoadBundleNumbers();
            LoadActivities();            
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

        private void LoadActivities()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string str1 = " select a.activitycode,a.activityname ";
            string str2 = " from tActivity a,tstyleActivities b,tstyleMaster c ";
            string str3 = " where b.activitycode=a.activitycode ";
            string str4 = " and c.styleid= b.styleid and c.stylecode = @stcode ";
            string str5 = " order by a.activityname ";
            string str6 = str1 + str2 + str3 + str4 + str5;
            sda.SelectCommand.CommandText = str6;
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbActivity.DataSource = ds.Tables[0];
            cmbActivity.DisplayMember = "activityname";
            cmbActivity.ValueMember = "activitycode";
        }

        private void cmbLayBNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layFlag == true)
            {
                LoadBundleNumbers();
                LoadActivities();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.Parameters.Clear();
            string str1 =" select c.employeename Name,c.empid ID,convert(nvarchar(10),a.proddate,103) Date, ";
            string str2 = " b.timedescription Time,a.qty Qty,a.bunintno,a.Layerbatchno,a.stylecode,a.recid,a.activitycode from tProdActivites a ,ttimecode b,employee c  ";
            string str3 =" where a.timecode=b.timecode and a.empid = c.empid ";
            string str4 = " and Layerbatchno = @lbno and stylecode= @stcode and bunIntno = @bno and a.Activitycode=@act ";
            sda.SelectCommand.CommandText = str1+str2+str3+str4;
            sda.SelectCommand.Parameters.AddWithValue("@lbno", Convert.ToInt32(cmbLayBNO.Text));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text );
            sda.SelectCommand.Parameters.AddWithValue("@bno", Convert.ToInt32(cmbBundle.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@act", Convert.ToInt32(cmbActivity.SelectedValue.ToString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lvBundle.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        lvBundle.Items.Add(ds.Tables[0].Rows[i]["Name"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["ID"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Date"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Time"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Qty"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["bunintno"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["layerbatchno"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["stylecode"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["recid"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["activitycode"].ToString());
                    }         
            }          
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            ReverseProcess();
        }

        private void ReverseProcess()
        {
            for (int i = 0; i < lvBundle.Items.Count; i++)
            {
                if (lvBundle.Items[i].Checked == true)
                {
                    int qty2 = Convert.ToInt32(lvBundle.Items[i].SubItems[4].Text);
                    int bunno = Convert.ToInt32(lvBundle.Items[i].SubItems[5].Text);
                    int LotNo = Convert.ToInt32(lvBundle.Items[i].SubItems[6].Text);
                    string StCode = lvBundle.Items[i].SubItems[7].Text;
                    int recid = Convert.ToInt32(lvBundle.Items[i].SubItems[8].Text);
                    int actid = Convert.ToInt32(lvBundle.Items[i].SubItems[9].Text);
                    ChangeInBunAct(qty2,bunno,LotNo ,StCode,actid);
                    InsertIntoLog(bunno);
                    DeleteInProdAct(recid);                                  
                }
            }
        }
        
        private void ChangeInBunAct(int qty2,int bunno,int LotNo,string StCode, int actid)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tLayCutBunAct set cmpqty=cmpqty-@qty2,pndqty=pndqty+@qty2 where LayerBatchNo=@lno and BunIntNo = @bno and StyleCode=@stcode and ActivityCode=@acode";
            scmd.Parameters.AddWithValue("@qty2", qty2);
            scmd.Parameters.AddWithValue("@lno",LotNo);
            scmd.Parameters.AddWithValue("@bno", bunno);
            scmd.Parameters.AddWithValue("@StCode", StCode);            
            scmd.Parameters.AddWithValue("@acode", actid);
            int i = scmd.ExecuteNonQuery();
            sc.Close();            
        }

        private void DeleteInProdAct(int recid)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete tProdActivites where recid=@recid";
            scmd.Parameters.AddWithValue("@recid", recid);
            int i = scmd.ExecuteNonQuery();
            sc.Close();       
        }

        private void InsertIntoLog(int recid)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert into tProdActivitesDelLog select * from tProdActivites where recid=@recid";
            scmd.Parameters.AddWithValue("@recid", recid);
            int i = scmd.ExecuteNonQuery();
            sc.Close();        
        }

        private void LoadStyleCode()
        {            
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select styleCode from tStyleMaster order by styleid desc";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle.DataSource = ds.Tables[0];
            cmbStyle.DisplayMember = "stylecode";
            cmbStyle.ValueMember = "stylecode";
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLayBNo();

        }
    }
}
