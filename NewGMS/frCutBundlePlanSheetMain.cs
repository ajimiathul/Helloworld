using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using BussinessLayer;

namespace NewGMS
{
    public partial class frCutBundlePlanSheetMain : Form
    {
        public frCutBundlePlanSheetMain()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void PrintReport()
        {
            //rCombinedLayCut oRpt = new rCombinedLayCut();
            
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            p.Name = "@lbno";
            pdc.Value = clsDbForReports.pubLayBatNo;
            p.CurrentValues.Add(pdc);
            ps.Add(p);          
            crystalReportViewer1.ParameterFieldInfo = ps;
           // crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
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

        private void frCutBundlePlanSheetMain_Load(object sender, EventArgs e)
        {

        }
    }
}
