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
    public partial class frmLayerCutReports : Form
    {
        bool flag = false;
        public frmLayerCutReports()
        {
            InitializeComponent();
        }

        private void frmLayerCutReports_Load(object sender, EventArgs e)
        {
            radiobuttonsClick();
            flag = false;
            LoadStyle();
            LoadLayerBatchNo();
            flag = true ;
            LoadLetters();
            LoadParts();
            FindMaxMin();
            FindCutDate();
        }

        private void LoadStyle()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select styleid,stylecode from tstylemaster";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle .DataSource = ds.Tables[0];
            cmbStyle.DisplayMember = "stylecode";
            cmbStyle.ValueMember = "styleid";
        }

        private void radiobuttonsClick()
        {
            if (rbTag.Checked == true)
            {
                cmbLetters.Enabled = true;
                cmbParts.Enabled = true;
                txtBunFrom.Enabled = true;
                txtBunTo.Enabled = true;
            }
            else
            {
                cmbLetters.Enabled = false ;
                cmbParts.Enabled = false ;
                txtBunFrom.Enabled = false ;
                txtBunTo.Enabled = false ;            
            }        
        }

        private void LoadLayerBatchNo()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select LayerBatchNo from tLayerCutHD where stylecode=@stcode order by LayerBatchNo desc";
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbLayerBatchNo.DataSource = ds.Tables[0];
            cmbLayerBatchNo.DisplayMember = "LayerBatchNo";
            cmbLayerBatchNo.ValueMember = "LayerBatchNo";
        }

        private void LoadParts()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string str ;
            str = " select b.partscode,b.partsname from tLayerCutParts a, tbundleparts b " ;
            str = str +" where a.partscode = b.partscode and a.layerbatchno = @lno and a.stylecode = @stcode order by partsname";
            sda.SelectCommand.Parameters.AddWithValue("@lno", Convert.ToInt32(cmbLayerBatchNo.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.CommandText = str;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbParts.DataSource = ds.Tables[0];
            cmbParts.DisplayMember = "partsname";
            cmbParts.ValueMember = "partscode";
        }


        private void LoadLetters()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select distinct bunletter  from tLayerCutBundle where  stylecode=@stcode and LayerBatchNo = @lbno order by bunletter";
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@lbno",Convert.ToInt32 (cmbLayerBatchNo.SelectedValue ));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbLetters.DataSource = ds.Tables[0];
            cmbLetters.DisplayMember = "bunletter";
            cmbLetters.ValueMember = "bunletter";
        }

        private void FindMaxMin()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select Max(BunIntNo) mx,Min(BunIntNo) mn from tLayerCutBundle where stylecode=@stcode and LayerBatchNo = @lbno and bunletter = @bltr";
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@lbno", Convert.ToInt32(cmbLayerBatchNo.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@bltr", cmbLetters.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtBunFrom.Text = ds.Tables[0].Rows[0]["mn"].ToString();
                txtBunTo.Text = ds.Tables[0].Rows[0]["mx"].ToString();
            }
        }

        
        private void FindCutDate()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select cutdate from tLayerCutHD where stylecode=@stcode and LayerBatchNo = @lbno";
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@lbno", Convert.ToInt32(cmbLayerBatchNo.SelectedValue));            
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txthidDate.Text  = ds.Tables[0].Rows[0]["cutdate"].ToString();               
            }
        }

        private void TagPrint()
        {
           // rPrintTag oRpt = new rPrintTag();
            //SetDBLogonForReport(oRpt);
            //oRpt.SetParameterValue(0, Convert.ToInt32(cmbLayerBatchNo.SelectedValue));
            //oRpt.SetParameterValue(1, cmbLetters.Text);
            //oRpt.SetParameterValue(2, Convert.ToInt32(cmbParts.SelectedValue));
            //oRpt.SetParameterValue(3, Convert.ToInt32(txtBunFrom.Text));
            //oRpt.SetParameterValue(4, Convert.ToInt32(txtBunTo.Text));
            //oRpt.SetParameterValue(5, cmbStyle.Text);
            //oRpt.PrintOptions.PrinterName = "Datamax-O'Neil E-4204B Mark III";
            //oRpt.PrintToPrinter(1, false, 1, -1);
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

        private void cmbLayerBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                LoadLetters();                
                FindCutDate();
                LoadParts();              
            }
        }

        private void rbHeader_CheckedChanged(object sender, EventArgs e)
        {
            radiobuttonsClick();
        }

        private void rbDtl_CheckedChanged(object sender, EventArgs e)
        {
            radiobuttonsClick();
        }

        private void rbTag_CheckedChanged(object sender, EventArgs e)
        {
            radiobuttonsClick();
        }

        private void cmbLetters_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (flag == true)
            {
                FindMaxMin();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rbHeader.Checked == true)
            {
                printHDR();
            }
            else if (rbDtl1.Checked == true)
            {
                printDtl1();
            }
            else if (rbDtl2.Checked == true)
            {
                printDtl2();
            }            
            else
            {
                TagPrint();            
            }
        }

        private void printDtl1()
        {
            //rptCutBundlePlanSheet oRpt = new rptCutBundlePlanSheet();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@LayBatNo";
            //pdc.Value = Convert.ToInt32 (cmbLayerBatchNo.SelectedValue );
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@cutDate";
            //pdc2.Value = Convert.ToDateTime (txthidDate.Text);
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();        
        }

        private void printDtl2()
        {
            //rptCutBundlePlanSheet2 oRpt = new rptCutBundlePlanSheet2();
            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@LayBatNo";
            //pdc.Value = Convert.ToInt32(cmbLayerBatchNo.SelectedValue);
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //ParameterField p2 = new ParameterField();
            //ParameterDiscreteValue pdc2 = new ParameterDiscreteValue();
            //p2.Name = "@cutDate";
            //pdc2.Value = Convert.ToDateTime(txthidDate.Text);
            //p2.CurrentValues.Add(pdc2);
            //ps.Add(p2);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }

        private void printHDR()
        {
            //rCombinedLayCut oRpt = new rCombinedLayCut();

            //ParameterFields ps = new ParameterFields();
            //ParameterField p = new ParameterField();
            //ParameterDiscreteValue pdc = new ParameterDiscreteValue();
            //SetDBLogonForReport(oRpt);
            //p.Name = "@lbno";
            //pdc.Value = Convert.ToInt32(cmbLayerBatchNo.SelectedValue);
            //p.CurrentValues.Add(pdc);
            //ps.Add(p);
            //crystalReportViewer1.ParameterFieldInfo = ps;
            //crystalReportViewer1.ReportSource = oRpt;
            //crystalReportViewer1.Show();
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                LoadLayerBatchNo();
            }
        }

        private void cmbParts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
