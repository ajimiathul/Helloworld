﻿using System;
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
    public partial class frmInformationAndSpecificAccountLedger : Form
    {
        public frmInformationAndSpecificAccountLedger()
        {
            InitializeComponent();
        }


        private void CmbAccLoad()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select accCode,accname  from tAccountMaster where GrpOrAcc='A' and SupCusEmpOth = 'OTH' order by accname";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbAccount.DataSource = ds.Tables[0];
            cmbAccount.DisplayMember = "accname";
            cmbAccount.ValueMember = "acccode";
        }

        private void CmbInfoAccLoad()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select accCode,(accname+'-'+SupCusEmpOth) dis from tAccountMaster where GrpOrAcc='A' and SupCusEmpOth <> 'OTH' order by accname";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbInfoAccount.DataSource = ds.Tables[0];
            cmbInfoAccount.DisplayMember = "dis";
            cmbInfoAccount.ValueMember  = "acccode";
        }

        private void frmInformationAndSpecificAccountLedger_Load(object sender, EventArgs e)
        {
            CmbAccLoad();
            CmbInfoAccLoad();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
          //  rptInformationSpecific oRpt = new rptInformationSpecific(); 
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            p.Name = "@fmdate";
            pdc.Value = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@todate";
            pdc2.Value = Convert.ToDateTime(dtpTo.Value.ToShortDateString());
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            ParameterField p4 = new ParameterField();
            ParameterDiscreteValue pdc4 = new ParameterDiscreteValue();
            p4.Name = "@InformationAccount";
            pdc4.Value = Convert.ToInt32(cmbInfoAccount.SelectedValue);
            p4.CurrentValues.Add(pdc4);
            ps.Add(p4);
            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@accCode";
            pdc3.Value = Convert.ToInt32(cmbAccount.SelectedValue);
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3);
            crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
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
    }
}
