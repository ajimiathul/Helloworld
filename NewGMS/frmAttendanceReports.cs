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
    public partial class frmAttendanceReports : Form
    {
        public frmAttendanceReports()
        {
            InitializeComponent();
        }

        private void frmAttendanceReports_Load(object sender, EventArgs e)
        {
            LoadEmp();
            LoadEmp2();
            LoadMonth();
            LoadMonth2();
        }

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
        }

        private void LoadMonth2()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select *  from holidayMonth";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbMonth2.DataSource = ds.Tables[0];
            cmbMonth2.DisplayMember = "MonthName";
            cmbMonth2.ValueMember = "monthNumber";
        }


        private void printMnthEmp()
        {
           // rptMonthAttEmployee oRpt = new rptMonthAttEmployee();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@empid";
            pdc.Value = Convert.ToInt32(cmbEmp.SelectedValue);
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@mno";
            pdc2.Value = Convert.ToInt32(cmbMonth.SelectedValue);
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void LoadEmp()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,(employeename + ' '+ str(empid)) employeename from employee where ActiveOrResigned='A' order by employeename";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbEmp.DataSource = ds.Tables[0];
            cmbEmp.DisplayMember = "employeeName";
            cmbEmp.ValueMember = "empid";
        }

        private void LoadEmp2()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,(employeename + ' '+ str(empid)) employeename from employee where ActiveOrResigned='A' order by employeename";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbEmp2.DataSource = ds.Tables[0];
            cmbEmp2.DisplayMember = "employeeName";
            cmbEmp2.ValueMember = "empid";
        }


        private void btnPrn1_Click(object sender, EventArgs e)
        {
            printMnthEmp();
        }

        private void btnPrn2_Click(object sender, EventArgs e)
        {

           // rptMonthAttendance oRpt = new rptMonthAttendance();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@cc";
            pdc.Value = 1; 
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@mno";
            pdc2.Value = Convert.ToInt32(cmbMonth.SelectedValue); 
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            crystalReportViewer1.ParameterFieldInfo = ps;
           // crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();

        
        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int x = 1;
            if (rbAbsNor.Checked == true)
            {
                x = 1;
            }

            if (rbAbsHol.Checked == true)
            {
                x = 2;
            }

            if (rbPrsHol.Checked == true)
            {
                x = 3;
            }

            if (rbOTHol.Checked == true)
            {
                x = 4;
            }
            if (rbOTNor .Checked == true)
            {
                x = 5;
            }

            if (rbSinPnch .Checked == true)
            {
                x = 6;
            }

            if (rb0330 .Checked == true)
            {
                x = 7;
            }

            if (rb3314 .Checked == true)
            {
                x = 8;
            }

            if (rb401630 .Checked == true)
            {
                x = 9;
            }

            if (rb6318 .Checked == true)
            {
                x = 10;
            }

            if (rb801829.Checked == true)
            {
                x = 11;
            }
            if (rb830.Checked == true)
            {
                x = 12;
            }

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "MonthAttendance3";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;      
            sda.SelectCommand.Parameters.AddWithValue("@empid",Convert.ToInt32 (cmbEmp2.SelectedValue.ToString ()));
            sda.SelectCommand.Parameters.AddWithValue("@mno", Convert.ToInt32(cmbMonth2.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@num", x);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[6].Width = 60;
            dataGridView1.Columns[7].Width = 60;
            dataGridView1.Columns[8].Width = 60;
            dataGridView1.Columns[9].Width = 60;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // chitra oRpt = new chitra();
    
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@cc";
            pdc.Value = 1;//Convert.ToInt32(cmbMonth.SelectedValue);
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@mno";
            pdc2.Value = Convert.ToInt32(cmbMonth.SelectedValue);
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
         
            crystalReportViewer1.ParameterFieldInfo = ps;
           // crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void rbOTNor_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
