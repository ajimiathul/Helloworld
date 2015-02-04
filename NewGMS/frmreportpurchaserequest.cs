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
    public partial class frmreportpurchaserequest : Form
    {
        public frmreportpurchaserequest()
        {
            InitializeComponent();
        }

        private void frmreportpurchaserequest_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select QtRqno from tMatRqVsQtRqNo";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmrqno.DataSource = ds.Tables[0];
            cmrqno.DisplayMember = "QtRqno";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // RPTcrypurchaserequest oRpt = new RPTcrypurchaserequest();            
            ParameterFields ps = new ParameterFields();

            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@qrno";
            pdc.Value = cmrqno.Text;
            p.CurrentValues.Add(pdc);
            ps.Add(p);

           
            ParameterField p1 = new ParameterField();
            ParameterDiscreteValue pdc1 = new ParameterDiscreteValue();
            p1.Name = "@reportMain";
            pdc1.Value = "Purchasereport"; 
            p1.CurrentValues.Add(pdc1);
            ps.Add(p1);
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

        private void cmrqno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
