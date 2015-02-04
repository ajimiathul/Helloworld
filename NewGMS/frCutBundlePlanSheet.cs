using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using BussinessLayer;

namespace NewGMS
{
    public partial class frCutBundlePlanSheet : Form
    {
        public frCutBundlePlanSheet()
        {
            InitializeComponent();
        }

        private void frCutBundlePlanSheet_Load(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void PrintReport()
        {
            //rptCutBundlePlanSheet oRpt = new rptCutBundlePlanSheet();

            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@LayBatNo";
            pdc.Value = clsDbForReports.pubLayBatNo;
            p.CurrentValues.Add(pdc);
            ps.Add(p);

            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@cutDate";
            pdc2.Value = clsDbForReports.pubCutDate;
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);


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

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
