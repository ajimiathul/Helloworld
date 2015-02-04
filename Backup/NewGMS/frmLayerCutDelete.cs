using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmLayerCutDelete : Form
    {
        string maxLot = "0";
        public frmLayerCutDelete()
        {
            InitializeComponent();
        }

        private void frmLayerCutDelete_Load(object sender, EventArgs e)
        {
            LoadStyleCode();
        }
        private void LoadStyleCode()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select stylecode,styleid from tstylemaster";
            sda.SelectCommand.CommandText = SqlConstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle.DataSource = ds.Tables[0];
            cmbStyle.DisplayMember = "stylecode";
            cmbStyle.ValueMember = "styleid";
        }


        private void LoadBundle()
        {
            listView1.Items.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "SelBundleForDeletion";
            sda.SelectCommand.CommandText = SqlConstr;
            sda.SelectCommand.Parameters.AddWithValue("@stc",cmbStyle.Text);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
         
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                maxLot = ds.Tables[0].Rows[0]["layerbatchNo"].ToString ();
                listView1.Items.Add(ds.Tables[0].Rows[i]["layerbatchNo"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["bundlestartno"].ToString());
                listView1.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["bundleendno"].ToString());
            }

        }
        
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadBundle();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            int lotno = 0;
            for (int i = 0; i <= listView1.Items.Count-1; i++)
            {
                if (listView1.Items[i].Checked == true)
                {                    
                    lotno = Convert.ToInt32(listView1.Items[i].Text);
                    DelData(lotno);   
                }            
            }
            LoadBundle();
        }

        private void DelData(int lotno)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "dLayCut";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@stc", cmbStyle.Text);
            scmd.Parameters.AddWithValue("@lotno", lotno );
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }


        

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           if( listView1.Items[e.Index].SubItems[0].Text!= maxLot )
            {                
                e.NewValue = CheckState.Unchecked;
            }
        }

       
       


    }
}
