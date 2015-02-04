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
    public partial class frmAttendanceDaily : Form
    {
        public frmAttendanceDaily()
        {
            InitializeComponent();
        }

        private void frmAttendanceDaily_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            //CrystalReport2 oRpt = new CrystalReport2();
           // rptAbsentiveList oRpt = new rptAbsentiveList();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@dt";
            pdc.Value = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            crystalReportViewer1.ParameterFieldInfo = ps;
           // crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rptSinglePunch oRpt = new rptSinglePunch();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@dt";
            pdc.Value = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }



    }
}
