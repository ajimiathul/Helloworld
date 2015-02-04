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
    public partial class frmProductionReports : Form
    {
        public frmProductionReports()
        {
            InitializeComponent();
        }


        void fillstylecode()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct stylecode  from tProdActivites where ProdDate between @dt1 and @dt2 order by stylecode";
            sda.SelectCommand.Parameters.AddWithValue("@dt1", Convert.ToDateTime(dtpfrom1.Value.ToShortDateString()));
            sda.SelectCommand.Parameters.AddWithValue("@dt2", Convert.ToDateTime(dtpto1.Value.ToShortDateString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);                    
            cmbStyleDI.DataSource = ds.Tables[0];
            cmbStyleDI.DisplayMember = "Stylecode";            
        }

        void fillstylecode1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct stylecode  from tstylemaster order by stylecode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle.DataSource = ds.Tables[0];
            cmbStyle.DisplayMember = "Stylecode";
            cmbstylecost.DataSource = ds.Tables[0];
            cmbstylecost.DisplayMember = "Stylecode";
            con.Close();
        }
        

        private void frmProductionReports_Load(object sender, EventArgs e)
        {
            dtpfrom1.Value = Convert.ToDateTime(dtpto1.Value.Month.ToString() + "/01/" + dtpto1.Value.Year.ToString());
            dtpCutFrom.Value = Convert.ToDateTime(dtpto1.Value.Month.ToString() + "/01/" + dtpto1.Value.Year.ToString());
            fillstylecode();
            showCurrentActivity();
            fillstylecode1();
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

       
       
       
        
       

        //
        private void PrintDateEmp()
        {
           // rptprodDataIntervalDataEmp oRpt = new rptprodDataIntervalDataEmp();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@dt1";
            pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@dt2";
            pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            crystalReportViewer1.ParameterFieldInfo = ps;
           // crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();        
        }
        //
        private void PrintEmpDate()
        {
           // rptprodDateIntervalEmpDate oRpt = new rptprodDateIntervalEmpDate();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@dt1";
            pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@dt2";
            pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            crystalReportViewer1.ParameterFieldInfo = ps;
           // crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        
        }
        //
        private void PrintDate()
        {
            //rptProdDateInterval oRpt = new rptProdDateInterval();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@dt1";
            pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@dt2";
            pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            crystalReportViewer1.ParameterFieldInfo = ps;
           // crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();        
        }
        //
        private void PrintEmployee()
        {
           // prodByDtIntrvlSummary oRpt = new prodByDtIntrvlSummary();
            ParameterFields ps = new ParameterFields();
            ParameterField p = new ParameterField();
            ParameterDiscreteValue pdc = new ParameterDiscreteValue();
           // SetDBLogonForReport(oRpt);
            p.Name = "@dt1";
            pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            p.CurrentValues.Add(pdc);
            ps.Add(p);
            ParameterField p2 = new ParameterField();
            ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            p2.Name = "@dt2";
            pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            p2.CurrentValues.Add(pdc2);
            ps.Add(p2);
            crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            crystalReportViewer1.Show();
        }

        private void showCurrentActivity()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct Activitycode,ActivityName  from tProdActivites where ProdDate between @dt1 and @dt2 order by ActivityName";
            sda.SelectCommand.Parameters.AddWithValue("@dt1",Convert.ToDateTime(dtpfrom1.Value.ToShortDateString()));
            sda.SelectCommand.Parameters.AddWithValue("@dt2", Convert.ToDateTime(dtpto1.Value.ToShortDateString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);           
            cmbActivity.DataSource = ds.Tables[0];
            cmbActivity.ValueMember = "activitycode";
            cmbActivity.DisplayMember = "activityname";
        }

       
        private void btnDlyPrint1_Click(object sender, EventArgs e)
        {   
            if (rbDlyEmp1.Checked == true)
            {
               // printDailyEmp1();
            }
            if (rbDlyAct1.Checked == true)
            {
               // printDailyact1();
            }
            if (rbOperations.Checked == true)
            {
               // operatorAnalysis();
            }
        }

        private void btnDlyPrint2_Click(object sender, EventArgs e)
        {
            if (rbDlyEmp2.Checked == true)
            {
               // printDailyEmp2();


            }
            if (rbDlyAct2.Checked == true)
            {
                //printDailyact2();
            }
        }

        private void btnprintdateonly_Click(object sender, EventArgs e)
        {
            if (rbDate1.Checked == true)
            {
               // PrintDate();
            }
            if (rbEmployee1.Checked == true)
            {
               // PrintEmployee();
            }
            if (rbempDate1.Checked == true)
            {
               // PrintEmpDate();
            }
            if (rbDateEmp1.Checked == true)
            {
                //PrintDateEmp();
            }
            
            
            if (rbstyleactivity1.Checked == true)
            {
                //DateIntervalSumStyleAct();

            }
            if (rbActivityStyle1.Checked == true)
            {
                //DateIntervalSumActStyle();
            }
                   
        }

        private void printDailyEmp2()
        {
            //rptDailyProductionEmploywise oRpt = new rptDailyProductionEmploywise();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt";
            //pdc.Value = dtpProdDate2.Value;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //ParameterField p1 = new ParameterField();
            //ParameterDiscreteValue pdc1 = new ParameterDiscreteValue();
            //p1.Name = "@stc";
            //pdc1.Value = cmbStyle.Text;
            //p1.CurrentValues.Add(pdc1);
            //ps.Add(p1);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }

        private void operatorAnalysis()
        {
            //RptOperatorTimeWiseReport oRpt = new RptOperatorTimeWiseReport();       
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt";
            //pdc.Value = dtpProdDate1.Value;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }

        private void printDailyEmp1()
        {
            //rptDailyProductionEmploywise1 oRpt = new rptDailyProductionEmploywise1();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt";
            //pdc.Value = dtpProdDate1.Value;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }



        void printDailyact2()
        {
            //RptDailyProductionActivitywise oRpt = new RptDailyProductionActivitywise();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt";
            //pdc.Value = dtpProdDate2.Value;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //ParameterField p1 = new ParameterField();
            //ParameterDiscreteValue pdc1 = new ParameterDiscreteValue();
            //p1.Name = "@stc";
            //pdc1.Value = cmbStyle.Text;
            //p1.CurrentValues.Add(pdc1);
            //ps.Add(p1);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        void printDailyact1()
        {
            //rptDailyproductionActivitywise1 oRpt = new rptDailyproductionActivitywise1();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt";
            //pdc.Value = dtpProdDate1.Value;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);


            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        void DateIntervalSumStyleAct()
        {
            //rptprodByDateIntervalSumStyleAct1 oRpt = new rptprodByDateIntervalSumStyleAct1();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt1";
            //pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@dt2";
            //pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        void DateIntervalSumActStyle()
        {
            //rptProdDateIntervalSumactstyl2 oRpt = new rptProdDateIntervalSumactstyl2();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt1";
            //pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@dt2";
            //pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }

        void CuttingBySize()
        {
            //RptCuttingSize oRpt = new RptCuttingSize();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt1";
            //pdc.Value = Convert.ToDateTime(dtpCutFrom.Value.ToShortDateString());
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@dt2";
            //pdc2.Value = Convert.ToDateTime(dtpCutTo.Value.ToShortDateString());
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }


        void actDateStyleCode()
        {
            //rptACtDateStylecode2 oRpt = new rptACtDateStylecode2();          
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt1";
            //pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@dt2";
            //pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);

            //ParameterField p3 = new ParameterField();
            //ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            //p3.Name = "@act";
            //pdc3.Value = cmbActivity.SelectedValue;
            //p3.CurrentValues.Add(pdc3);
            //ps.Add(p3);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }

        void ActsizeDateACt()
        {
            //rpActSizeDateAct3  oRpt = new rpActSizeDateAct3();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt1";
            //pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@dt2";
            //pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);

            //ParameterField p3 = new ParameterField();
            //ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            //p3.Name = "@stc";
            //pdc3.Value = cmbStyleDI.Text;
            //p3.CurrentValues.Add(pdc3);
            //ps.Add(p3);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        void styleSizesum()
        {
            //rptActVsSizeQty33 oRpt = new rptActVsSizeQty33();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt1";
            //pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@dt2";
            //pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);

            //ParameterField p3 = new ParameterField();
            //ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            //p3.Name = "@stc";
            //pdc3.Value = cmbStyleDI.Text;
            //p3.CurrentValues.Add(pdc3);
            //ps.Add(p3);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();



        }
        void ActSizeActDate()
        {
            //rptAtSizeActDate3 oRpt = new rptAtSizeActDate3();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@dt1";
            //pdc.Value = Convert.ToDateTime(dtpfrom1.Value.ToShortDateString());
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@dt2";
            //pdc2.Value = Convert.ToDateTime(dtpto1.Value.ToShortDateString());
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);

            //ParameterField p3 = new ParameterField();
            //ParameterDiscreteValue pdc3 = new ParameterDiscreteValue();
            //p3.Name = "@stc";
            //pdc3.Value = cmbStyleDI.Text;
            //p3.CurrentValues.Add(pdc3);
            //ps.Add(p3);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();


        }

        private void btnNewAct_Click(object sender, EventArgs e)
        {
            actDateStyleCode();
        }

        private void btnprintdatestyl_Click(object sender, EventArgs e)
        {
            if (rbDateActivity1.Checked == true)
            {
                ActsizeDateACt();

            }
            if (rbActivityDate1.Checked == true)
            {
                ActSizeActDate();
            }
            if (rbStyleSizeSum1.Checked == true)
            {
                styleSizesum();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
           //
        private void btnprintyear1_Click(object sender, EventArgs e)
        {
            //rptCuttingEmpYear oRpt = new rptCuttingEmpYear();
            //SetDBLogonForReport(oRpt);
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }

        private void btnprintStyAct_Click(object sender, EventArgs e)
        {
            actDateStyleCode(); 

        }

        private void dtpProdDate2_Leave(object sender, EventArgs e)
        {
            fillstyle();
        }

        private void dtpProdDate2_CloseUp(object sender, EventArgs e)
        {
            fillstyle();
        }

        void fillstyle()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct stylecode  from tProdActivites where ProdDate = @dt1  order by stylecode";
            sda.SelectCommand.Parameters.AddWithValue("@dt1", Convert.ToDateTime(dtpProdDate2.Value.ToShortDateString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle.DataSource = ds.Tables[0];
            cmbStyle.DisplayMember = "Stylecode";
        }

        private void btnCutPrint_Click(object sender, EventArgs e)
        {           
                CuttingBySize();            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dtpfrom1_CloseUp(object sender, EventArgs e)
        {
            fillstylecode();
            showCurrentActivity();
        }

        private void dtpfrom1_Leave(object sender, EventArgs e)
        {
            fillstylecode();
            showCurrentActivity();
        }

        private void dtpto1_Leave(object sender, EventArgs e)
        {
            fillstylecode();
            showCurrentActivity();
        }

        private void dtpto1_DropDown(object sender, EventArgs e)
        {
            fillstylecode();
            showCurrentActivity();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        void styleActivityRate()
        {
            //rptActivityRate oRpt = new rptActivityRate();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);

            //p.Name = "@stc";
            //pdc.Value = cmbstylecost.Text;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        void StyleBatchStatus()
        {
            //rptStyleProdBatch oRpt = new rptStyleProdBatch();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);

            //p.Name = "@stc";
            //pdc.Value = cmbstylecost.Text;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        void StyleDateActCost()
        {
            //rptDateActCost oRpt = new rptDateActCost();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);

            //p.Name = "@stc";
            //pdc.Value = cmbstylecost.Text;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        void StyleActCost()
        {
            //rptActCost oRpt = new rptActCost();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);

            //p.Name = "@stc";
            //pdc.Value = cmbstylecost.Text;
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);

            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();

        }
        
        private void btnPStyle_Click(object sender, EventArgs e)
        {
            if (rbPStyleRate.Checked == true)
            {
                styleActivityRate();
            }
            if (rbPStyleBatchStatus.Checked == true)
            {
                StyleBatchStatus();

            }
            if(rbPStyleActDateQtyCost.Checked ==true)
            {
                StyleDateActCost();
            }
            if(rbPStyleActQtyCost.Checked ==true)
            {
                StyleActCost();

            }

        }

    }
}
