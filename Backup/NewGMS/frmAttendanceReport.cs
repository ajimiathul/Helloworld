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
    public partial class frmAttendanceReport : Form
    {
        public frmAttendanceReport()
        {
            InitializeComponent();
        }
        bool formLoading = false;
        private void LoadMonth()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select *  from holidayMonth";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbMonth.DataSource = ds.Tables[0];
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "monthNumber";
            cmbMonthTab2.DataSource = ds.Tables[0];
            cmbMonthTab2.DisplayMember = "MonthName";
            cmbMonthTab2.ValueMember = "monthNumber";
        }

        private void fillcombobox()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select employeename,empid from employee where compCode=@compCode order by employeename";
            sda.SelectCommand.Parameters.AddWithValue("@compCode", cmbCompany.SelectedValue);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbemp.DataSource = ds.Tables[0];
            cmbemp.DisplayMember = "employeename";
            cmbemp.ValueMember = "empid";
            cmbEmpTab2.DataSource = ds.Tables[0];
            cmbEmpTab2.DisplayMember = "employeename";
            cmbEmpTab2.ValueMember = "empid";
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

        private void LoadCompany()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select compcode,companyName  from company order by disporder";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCompany.DataSource = ds.Tables[0];
            cmbCompany.DisplayMember = "companyName";
            cmbCompany.ValueMember = "compcode";
        }

        private void frmAttendanceReport_Load(object sender, EventArgs e)
        {
            formLoading = true;
            LoadCompany();
            fillcombobox();
            LoadMonth();
            FillComboFlag();
            formLoading = false;
            cmbFlag.Text = "P";
        }

        private void FillComboFlag()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct status from AttendanceDT";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbFlag.DataSource = ds.Tables[0];
            cmbFlag.DisplayMember = "status";
            cmbFlag.ValueMember = "status";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rptDailyAttendance oRpt = new rptDailyAttendance();           
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@dt";
            pdc.Value = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@compCode";
            pdc3.Value = cmbCompany.SelectedValue.ToString();
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3);
            ParameterField p4 = new ParameterField();
            ParameterDiscreteValue pdc4 = new ParameterDiscreteValue();
            p4.Name = "@orderBy";
            if (rbName.Checked == true)
            {
                pdc4.Value = "A";
            }
            else if (rbId.Checked == true)
            {
                pdc4.Value = "B";
            }
            else if (rbDep.Checked == true)
            {
                pdc4.Value = "C";
            }
            p4.CurrentValues.Add(pdc4);
            ps.Add(p4); crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rptDailyDepStatus oRpt = new rptDailyDepStatus();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@dt";
            pdc.Value = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@compCode";
            pdc3.Value = cmbCompany.SelectedValue.ToString();
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3);
            crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void btattendencestatus_Click(object sender, EventArgs e)
        {
            rptEmpTotAttendance oRpt = new rptEmpTotAttendance();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@empid";
            pdc.Value = cmbemp.SelectedValue;
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void btnRegSum_Click(object sender, EventArgs e)
        {
            rptDayAttendanceInMonth oRpt = new rptDayAttendanceInMonth();                          
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@month";
            pdc.Value = Convert.ToInt32(cmbMonth.SelectedValue);
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@comCode";
            pdc3.Value = cmbCompany.SelectedValue;
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3);
            crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void btnRegDet_Click(object sender, EventArgs e)
        {
            rptAttRegFullDtl oRpt = new rptAttRegFullDtl();           
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@month";
            pdc.Value = Convert.ToInt32(cmbMonth.SelectedValue);
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@comCode";
            pdc3.Value = cmbCompany.SelectedValue.ToString();
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3); 
            crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            rptMonthAttendnceSummery oRpt = new rptMonthAttendnceSummery();                  
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@month";
            pdc.Value = Convert.ToInt32(cmbMonth.SelectedValue);
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@comCode";
            pdc3.Value = cmbCompany.SelectedValue;
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3);
            crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            rptEmployeeMonth oRpt = new rptEmployeeMonth();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            SetDBLogonForReport(oRpt);
            p.Name = "@mCod";
            pdc.Value = Convert.ToInt32(cmbMonthTab2.SelectedValue);
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@empid";
            pdc2.Value = Convert.ToInt32(cmbEmpTab2.SelectedValue);
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            ParameterField p3 = new ParameterField();
            ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            p3.Name = "@status";
            pdc3.Value = cmbFlag.SelectedValue.ToString();
            p3.CurrentValues.Add(pdc3);
            ps.Add(p3);
            ParameterField p5 = new ParameterField();
            ParameterDiscreteValue pdc5 = new ParameterDiscreteValue();
            p5.Name = "@All";
            if (rbShowAll.Checked == true)
            {
                pdc5.Value = 1;
            }
            else
            {
                pdc5.Value = 0;
            }
            p5.CurrentValues.Add(pdc5);
            ps.Add(p5);
            ParameterField p4 = new ParameterField();
            ParameterDiscreteValue pdc4 = new ParameterDiscreteValue();
            p4.Name = "@YorN";
            string YorN="N";
            if (rbEqual.Checked == true)
            {
                YorN = "Y";
            }
            pdc4.Value = YorN;
            p4.CurrentValues.Add(pdc4);
            ps.Add(p4);
            crystalReportViewer1.ParameterFieldInfo = ps;
            crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formLoading == false)
            {
                fillcombobox();
            }
        }

        private void rbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShowAll.Checked == true)
            {
                cmbFlag.Visible = false;
            }
            else
            {
                cmbFlag.Visible = true;
            }
        }
    }
}
