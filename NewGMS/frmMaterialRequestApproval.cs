using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmMaterialRequestApproval : Form
    {
        public frmMaterialRequestApproval()
        {
            InitializeComponent();
        }
        int matreqcode=0;

        private void frmMaterialRequestApproval_Load(object sender, EventArgs e)
        {
            FillMatReqGrid();
            btnApproval.Enabled = false;
            btnRejection.Enabled = false;
            btnPending.Enabled = false;
        }
        private void FillMatReqGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select matreqCode,matreqDate,SendForSanction,SendForSupplier from tMatReqHD A order by matreqCode desc";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvMatReq.Rows.Add(1);
                int x = dgvMatReq.Rows.Count;
                dgvMatReq.Rows[x - 1].Cells["ColMatReq"].Value = ds.Tables[0].Rows[i]["matreqCode"];
                dgvMatReq.Rows[x - 1].Cells["colMatReqDt"].Value =Convert.ToDateTime( ds.Tables[0].Rows[i]["matreqDate"]).ToShortDateString();
                dgvMatReq.Rows[x - 1].Cells["ColSanction"].Value = ds.Tables[0].Rows[i]["SendForSanction"];
                dgvMatReq.Rows[x - 1].Cells["ColSupSendStatus"].Value = ds.Tables[0].Rows[i]["SendForSupplier"];
            }
        }
        private void FillItemsGrid(int matreqcode)
        {
            dgvItems.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select B.MatDesc,B.Rate,A.qty from tMatReqDtl A inner join tMaterial B on A.matcode=B.MatCode where matreqCode=@matreqCode";
            sda.SelectCommand.Parameters.AddWithValue("@matreqCode", matreqcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvItems.Rows.Add(1);
                int k = dgvItems.Rows.Count;
                dgvItems.Rows[k - 1].Cells["ColItems"].Value = ds.Tables[0].Rows[i]["MatDesc"];
                dgvItems.Rows[k - 1].Cells["ColRate"].Value = ds.Tables[0].Rows[i]["Rate"];
                dgvItems.Rows[k - 1].Cells["ColQty"].Value = ds.Tables[0].Rows[i]["qty"];              
            }
        }
        private bool  FillOthersStatus(int matreqcode)
        {
            bool val = false;
            dgvOthersStatus.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select B.EmployeeName,status= case A.sanctionedOrNot when 'A' then 'Approved' when 'R' then 'Rejected' when 'P' then 'Pending' end ,A.sanctionedDate,A.remarks,a.empid from tSanctionStatus A inner join Employee B on A.empid=B.EmpId  where A.reccode=@matreq and A.screen=@scn";
            sda.SelectCommand.Parameters.AddWithValue("@matreq", matreqcode);
            sda.SelectCommand.Parameters.AddWithValue("@empid", clsDbForReports.userid);
            sda.SelectCommand.Parameters.AddWithValue("@scn", "MatRequest");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvOthersStatus.Rows.Add(1);
                int k = dgvOthersStatus.Rows.Count;
                dgvOthersStatus.Rows[k - 1].Cells["ColManager"].Value = ds.Tables[0].Rows[i]["EmployeeName"];
                dgvOthersStatus.Rows[k - 1].Cells["ColManStatus"].Value = ds.Tables[0].Rows[i]["status"];
                dgvOthersStatus.Rows[k - 1].Cells["ColOthersStatusDt"].Value = ds.Tables[0].Rows[i]["sanctionedDate"];
                dgvOthersStatus.Rows[k - 1].Cells["ColOthersRemarks"].Value = ds.Tables[0].Rows[i]["remarks"];
                if (ds.Tables[0].Rows[i]["empid"].ToString() == clsDbForReports.userid.ToString())
                {
                    val = true;
                }
            }
            return val;
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMatReq_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            bool val = false;
            int x=e.RowIndex;
            if (x != -1)
            {
               matreqcode = Convert.ToInt32(dgvMatReq.Rows[x].Cells["ColMatReq"].Value);
               txtMatReqNo.Text = matreqcode.ToString();
               FillItemsGrid(matreqcode);
               val = FillOthersStatus(matreqcode);
               if (dgvMatReq.Rows[e.RowIndex].Cells["ColSupSendStatus"].Value.ToString() == "N" && val == true)
               {
                   btnApproval.Enabled = true;
                   btnPending.Enabled = true;
                   btnRejection.Enabled = true;
               }
               else
               {
                   btnApproval.Enabled = false ;
                   btnPending.Enabled = false ;
                   btnRejection.Enabled = false ;
                            
               }
                
            }
        }

        private void SetApproved()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tSanctionStatus set sanctionedOrNot='A',remarks=@rem,sanctionedDate=@saDate where reccode=@matreqcode and empid=@empid and screen='MatRequest'";
            cmd.Parameters.AddWithValue("@saDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@matreqcode", matreqcode);
            cmd.Parameters.AddWithValue("@empid", clsDbForReports.userid);
            cmd.Parameters.AddWithValue("@rem", txtRemarks.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            FillOthersStatus(matreqcode);
        }

        private void SetRejected()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tSanctionStatus set sanctionedOrNot='R', remarks=@rem where reccode=@matreqcode and empid=@empid and screen='MatRequest'";
            cmd.Parameters.AddWithValue("@matreqcode", matreqcode);
            cmd.Parameters.AddWithValue("@rem", txtRemarks.Text);
            cmd.Parameters.AddWithValue("@empid", clsDbForReports.userid);
            cmd.ExecuteNonQuery();
            con.Close();
            FillOthersStatus( matreqcode);
        }
        private void SetPending()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tSanctionStatus set sanctionedOrNot='P',remarks=@rem where reccode=@matreqcode and empid=@empid and screen='MatRequest'";
            cmd.Parameters.AddWithValue("@matreqcode", matreqcode);
            cmd.Parameters.AddWithValue("@rem", txtRemarks.Text);
            cmd.Parameters.AddWithValue("@empid", clsDbForReports.userid);
            cmd.ExecuteNonQuery();
            con.Close();
            FillOthersStatus(matreqcode);
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            SetApproved();
            NextlevelStatus();            
        }

        private void btnRejection_Click(object sender, EventArgs e)
        {
            SetRejected();
            NextlevelStatus();
        }       

        private void btnPending_Click(object sender, EventArgs e)
        {
            SetPending();
            NextlevelStatus();
        }

        private void NextlevelStatus()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMatReqHD set NextLevel = 'Yes' where matreqCode=@mrqcd and exists (select * from tSanctionStatus where sanctionedOrNot in ('A','R') and reccode = @mrqcd)";
            cmd.Parameters.AddWithValue("@mrqcd", matreqcode);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("", con);
            cmd1.CommandText = "update tMatReqHD set NextLevel = 'No' where matreqCode=@mrqcd and not exists (select * from tSanctionStatus where sanctionedOrNot in ('A','R') and reccode = @mrqcd)";
            cmd1.Parameters.AddWithValue("@mrqcd", matreqcode);
            cmd1.ExecuteNonQuery();

            con.Close();        
        }

    }
}
