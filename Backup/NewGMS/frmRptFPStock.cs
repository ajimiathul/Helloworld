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
    public partial class frmRptFPStock : Form
    {
        public frmRptFPStock()
        {
            InitializeComponent();
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

        private void frmRptFPStock_Load(object sender, EventArgs e)
        {
            rptViewStock rpt = new rptViewStock();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(rpt);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Show();
        }
    }
}
