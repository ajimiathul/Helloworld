using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmPerformaInvoiceRequest : Form
    {

        int Qtno = 0;
        int suplrcode = 0;
        int supsubno = 0;
        DateTime dt;
        public frmPerformaInvoiceRequest()
        {
            InitializeComponent();
        }

        private void frmPerformaInvoiceRequest_Load(object sender, EventArgs e)
        {
            FillPRequest();
            btnPINeed.Enabled = false;
            btnPINotNeed.Enabled = false;
            btnSM.Enabled = false;
        }

        private void FillPRequest()
        {
            dgvPRList.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = " select x.QtReqNo,x.SupplierName,x.supcode,C.RefNum,C.RefDate,x.sup_subno,x.nofMaterials,x.FromSource,x.PINeed,x.SupReceived,x.CanModify ";
            string s2 = " from (select top 20 A.QtReqNo , B.SupplierName ,A.supcode,A.sup_subno ,A.nofMaterials , A.FromSource ,A.PINeed,A.SupReceived,A.CanModify ";
            string s3 = " from tPurReqHD A ,tSupplier B where A.supcode = B.Suppliercode)x inner join tQuotReqVsSupplier C on C.QtRqNo=x.QtReqNo and C.suppliercode=x.supcode ";
            sda.SelectCommand.CommandText = s1 + s2+s3;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvPRList.Rows.Add(1);
                int k = dgvPRList.Rows.Count;
                dgvPRList.Rows[k - 1].Cells["QtReqNo"].Value = ds.Tables[0].Rows[i]["QtReqNo"];
                dgvPRList.Rows[k - 1].Cells["SupplierName"].Value = ds.Tables[0].Rows[i]["SupplierName"];
                dgvPRList.Rows[k - 1].Cells["supcode"].Value = ds.Tables[0].Rows[i]["supcode"];
                dgvPRList.Rows[k - 1].Cells["ColRefNum"].Value = ds.Tables[0].Rows[i]["RefNum"];
                if (DateTime.TryParse(ds.Tables[0].Rows[i]["RefDate"].ToString(), out dt))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                    dgvPRList.Rows[k - 1].Cells["ColDt"].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["RefDate"]).ToShortDateString();
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                }
                else
                {
                    dgvPRList.Rows[k - 1].Cells["ColDt"].Value = null;
                }
                dgvPRList.Rows[k - 1].Cells["ColSubNum"].Value = ds.Tables[0].Rows[i]["sup_subno"];
                dgvPRList.Rows[k - 1].Cells["ColNoOfMat"].Value = ds.Tables[0].Rows[i]["nofMaterials"];
                dgvPRList.Rows[k - 1].Cells["ColFromSource"].Value = ds.Tables[0].Rows[i]["FromSource"];
                dgvPRList.Rows[k - 1].Cells["PINeed"].Value = ds.Tables[0].Rows[i]["PINeed"];
                dgvPRList.Rows[k - 1].Cells["SupReceived"].Value = ds.Tables[0].Rows[i]["SupReceived"];
                dgvPRList.Rows[k - 1].Cells["ColCanModify"].Value = ds.Tables[0].Rows[i]["CanModify"];
            }
        }
        
        private void dgvPRList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                CellDoubleClick(e.RowIndex);
            }
        }
        
        private void CellDoubleClick(int x)
        {
            btnSM.Enabled = false;
            gbMessage.Visible = false;
             Qtno= Convert.ToInt32 ( dgvPRList.Rows[x].Cells["QtReqNo"].Value ) ;
             suplrcode = Convert.ToInt32 ( dgvPRList.Rows[x].Cells["supcode"].Value ) ;
             supsubno = Convert.ToInt32(dgvPRList.Rows[x].Cells["ColSubNum"].Value);
             if (dgvPRList.Rows[x].Cells["ColCanModify"].Value.ToString().Trim() == "No")
             {
                 btnPINotNeed.Enabled = false;
                 btnPINeed.Enabled = false;
                 btnSM.Enabled = false;
                 gbMessage.Visible = true;
             }
             else if (dgvPRList.Rows[x].Cells["PINeed"].Value.ToString().Trim() == "Yes")
             {
                 btnPINeed.Enabled = false;
                 btnPINotNeed.Enabled = true;
                 btnSM.Enabled = true;
             }
             else if (dgvPRList.Rows[x].Cells["PINeed"].Value.ToString().Trim() == "No")
             {
                 btnPINeed.Enabled = true;
                 btnPINotNeed.Enabled = false;
                 btnSM.Enabled = false;
             }
             else
             {
                 btnPINeed.Enabled = true;
                 btnPINotNeed.Enabled = true;
             }
            
            dgvMList .Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = " select B.MatDesc, A.Qturate,A.PReqQty,A.PerInvReqQty,A.matcode from tMaterialVsSupplier A ,tMaterial B where A.matcode = B.matcode and ";
            string s2 = "  A.QtRqNo = @qr1 and A.suppliercode = @sp1 and A.SubNumber =@sn1 and A.selected='Yes' order by A.QtRqNo desc ";
            sda.SelectCommand.CommandText = s1 + s2 ;
            sda.SelectCommand.Parameters .AddWithValue ("@qr1",Qtno );
            sda.SelectCommand.Parameters.AddWithValue("@sp1", suplrcode);
            sda.SelectCommand.Parameters.AddWithValue("@sn1", supsubno);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvMList.Rows.Add(1);
                int k = dgvMList.Rows.Count;
                dgvMList.Rows[k - 1].Cells["MatDesc"].Value = ds.Tables[0].Rows[i]["MatDesc"];
                dgvMList.Rows[k - 1].Cells["urate"].Value = ds.Tables[0].Rows[i]["QtUrate"];
                dgvMList.Rows[k - 1].Cells["PIReqQty"].Value = ds.Tables[0].Rows[i]["PReqQty"];
                dgvMList.Rows[k - 1].Cells["qr1"].Value = dgvPRList.Rows[x].Cells["QtReqNo"].Value.ToString ();
                dgvMList.Rows[k - 1].Cells["sp1"].Value = dgvPRList.Rows[x].Cells["supcode"].Value .ToString ();
                dgvMList.Rows[k - 1].Cells["sn1"].Value = dgvPRList.Rows[x].Cells["ColSubNum"].Value.ToString();
                dgvMList.Rows[k - 1].Cells["mc1"].Value = ds.Tables[0].Rows[i]["matcode"];
                dgvMList.Rows[k - 1].Cells["ColPIReqQty"].Value = ds.Tables[0].Rows[i]["PerInvReqQty"];                
            }       
        }

        private void btnPINeed_Click(object sender, EventArgs e)
        {
            PINeedMethod("Yes");
            MatBlock();
            UpdateQty();
            AddPerformaInvoice();
            UpdateUnSelectedMaterials();
            btnPINeed.Enabled = false;
            btnPINotNeed.Enabled = false;
            btnSM.Enabled = true;
            FillPRequest();
        }

        private void btnPINotNeed_Click(object sender, EventArgs e)
        {
            PINeedMethod("No");
            MatBlock();
            UpdateQty();
            AddPerformaInvoice();
            UpdateUnSelectedMaterials();
            btnPINotNeed.Enabled = false;
            btnPINeed.Enabled = false;
            btnSM.Enabled = false;
            FillPRequest();
        }

        private void UpdateQty()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dgvMList.Rows.Count; i++)
            {
                cmd.CommandText = "update tMaterialVsSupplier set PerInvReqQty = @mqty where suppliercode =@ms and QtRqNo =@mq and matcode = @mm";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mqty", Convert.ToDouble(dgvMList.Rows[i].Cells["ColPIReqQty"].Value));
                cmd.Parameters.AddWithValue("@ms", suplrcode);
                cmd.Parameters.AddWithValue("@mq", Qtno);
                cmd.Parameters.AddWithValue("@mm", Convert.ToInt32 (dgvMList.Rows[i].Cells[6].Value));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }

        private void PINeedMethod(string PINeedPara)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPurReqHD set PINeed =@pi where QtReqNo =@q1 and supcode =@s1 and sup_subno =@sub1";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@pi", PINeedPara );
            cmd.Parameters.AddWithValue("@q1", Qtno);
            cmd.Parameters.AddWithValue("@s1", suplrcode );
            cmd.Parameters.AddWithValue("@sub1", supsubno);
            cmd.ExecuteNonQuery();
            con.Close();
        }       

        private void MatBlock()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMaterialVsSupplier set MaterialBlocked = 'Y' where QtRqNo = @q1 and suppliercode=@s1 and selected= 'Yes' and SubNumber =@sub1";
            cmd.CommandType = CommandType.Text;          
            cmd.Parameters.AddWithValue("@q1", Qtno);
            cmd.Parameters.AddWithValue("@s1", suplrcode);
            cmd.Parameters.AddWithValue("@sub1", supsubno);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void AddPerformaInvoice()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "uPerformaInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@q1", Qtno);
            cmd.Parameters.AddWithValue("@s1", suplrcode);
            cmd.Parameters.AddWithValue("@sub1", supsubno);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void UpdateUnSelectedMaterials()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "uBlockUnSelectedMaterials";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QtReqNo", Qtno);            
            cmd.ExecuteNonQuery();
            con.Close();
        }        
        
        //supplier Mail Receive
        private void SupReceivedStatus()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPurReqHD set SupReceived='Yes' where QtReqNo =@q1 and supcode =@s1 and sup_subno =@sub1";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@q1", Qtno);
            cmd.Parameters.AddWithValue("@s1", suplrcode);
            cmd.Parameters.AddWithValue("@sub1", supsubno);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnSM_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
