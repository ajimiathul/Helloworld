using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using BussinessLayer;


namespace NewGMS
{
    public partial class frPrintTag : Form
    {
        public frPrintTag()
        {
            InitializeComponent();
        }

        private void frPrintTag_Load(object sender, EventArgs e)
        {
            LoadLetters();
            LoadParts();
        }

        private void LoadParts()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select partscode,partsname from tbundleParts order by partsname";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbParts .DataSource = ds.Tables[0];
            cmbParts .DisplayMember = "partsname";
            cmbParts .ValueMember = "partscode";               
        }


        private void LoadLetters()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select distinct bunletter  from tLayerCutBundle where LayerBatchNo = @lbno order by bunletter";
            sda.SelectCommand.Parameters.AddWithValue("@lbno", clsDbForReports.pubLayBatNo);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbLetters .DataSource = ds.Tables[0];
            cmbLetters .DisplayMember = "bunletter";
            cmbLetters .ValueMember = "bunletter";
        }

        private void FindMaxMin()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select Max(BunIntNo) mx,Min(BunIntNo) mn from tLayerCutBundle where LayerBatchNo = @lbno and bunletter = @bltr";
            sda.SelectCommand.Parameters.AddWithValue("@lbno", clsDbForReports.pubLayBatNo);
            sda.SelectCommand.Parameters.AddWithValue("@bltr", cmbLetters.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtBunFrom.Text = ds.Tables[0].Rows[0]["mn"].ToString();
                txtBunTo.Text = ds.Tables[0].Rows[0]["mx"].ToString();
            }
        }


        private void TagPrint()
        {
            rPrintTag oRpt = new rPrintTag();
            SetDBLogonForReport(oRpt);
            oRpt.SetParameterValue(0, clsDbForReports.pubLayBatNo);
            oRpt.SetParameterValue(1, cmbLetters.Text );
            oRpt.SetParameterValue(2, Convert.ToInt32 ( cmbParts.SelectedValue ));
            oRpt.SetParameterValue(3, Convert.ToInt32(txtBunFrom.Text));
            oRpt.SetParameterValue(4, Convert.ToInt32(txtBunTo.Text));
            oRpt.PrintOptions.PrinterName = "Datamax-O'Neil E-4204B Mark III";
            oRpt.PrintToPrinter(1, false, 1, -1);
        }



        public void SetDBLogonForReport(ReportDocument myrep)
        {
            ConnectionInfo myConnectionInfo = new ConnectionInfo();
            myConnectionInfo.ServerName = clsDbForReports.server;
            myConnectionInfo.DatabaseName = clsDbForReports.db;
            myConnectionInfo.UserID = clsDbForReports.uid;
            myConnectionInfo.Password = clsDbForReports.pwd;
            myConnectionInfo.IntegratedSecurity = false;

            Tables tbs = myrep.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table t in tbs)
            {
                TableLogOnInfo tbl = t.LogOnInfo;
                tbl.ConnectionInfo = myConnectionInfo;
                t.ApplyLogOnInfo(tbl);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            TagPrint();
        }

        private void cmbLetters_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindMaxMin();
        }
    }
}
