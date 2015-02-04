using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmEmpReports : Form
    {
        public frmEmpReports()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printEmp();
        }

        private void frmEmpReports_Load(object sender, EventArgs e)
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

        private void printEmp()
        {
            string strAR = "R";
            string strOrdr = "";
            if (rbActive.Checked == true)
            {
                strAR = "A";
            }
            if (rbName.Checked == true)
            {
                strOrdr = "Name Wise";
            }
            if (rbID.Checked == true)
            {
                strOrdr = "Emp Id Wise";
            }
            if (rbDep.Checked == true)
            {
                strOrdr = "Department Wise";
            }
            if (rbDes.Checked == true)
            {
                strOrdr = "Designation Wise";
            }
            if (rbSal.Checked == true)
            {
                strOrdr = "Sal Type Wise";
            }
            rptEmpActResList oRpt = new rptEmpActResList();
            
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@orderWise";
            pdc.Value = strOrdr ;
            p.CurrentValues.Add(pdc);
            ps.Add(p);

            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@ar";
            pdc2.Value = strAR;
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);

            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@compcode";
            pdc3.Value = clsDbForReports.companycode ;
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3);
                        
            crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }


    }
}
