using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmLeaveApplication : Form
    {
        string NewEdit = "New";
        bool EmpFlag = false;
        string scr = "Leave";
        string ActiveOrRes = "A";
        public frmLeaveApplication()
        {
            InitializeComponent();
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLeaveApplication_Load(object sender, EventArgs e)
        {
            EmpFlag = false;
            NewEdit = "New";
            LoadEmployeeName();
            txtEmpID.Text = cmbEmpName.SelectedValue.ToString();
            EmpFlag = true;
            EmpChange();
            cbHalf.Enabled = true;
            ShowAllEmpLeave();
            txtMode.Text = "Mode is New";                

        }

        private void LoadEmployeeName()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,employeeName from employee where activeorResigned='A' order by employeeName";
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbEmpName.DataSource = ds.Tables[0];
            cmbEmpName.DisplayMember = "employeename";
            cmbEmpName.ValueMember = "empid";
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            EmpChange();
        }

        private void cmbEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveOrRes == "A")
            {
                txtEmpID.Text = cmbEmpName.SelectedValue.ToString();
            }
        }

        private void EmpChange()
        {
            if (EmpFlag == true)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                sda.SelectCommand.CommandText = "select  c.designation,b.department from employee a,department b,designation c where  empid=@empid and a.depcode=b.depid and a.desigcode=c.designationid";
                sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(txtEmpID.Text));
                sda.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                txtDep.Text = ds.Tables[0].Rows[0]["department"].ToString();
                txtDesg.Text = ds.Tables[0].Rows[0]["designation"].ToString();
                CountAbsent();
            }
        }

        private void CountAbsent()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "CountAbsent";
            sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(txtEmpID.Text));
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            dgvLeaveStatus.Rows.Clear();
            sda.Fill(ds);
            txtTotal.Text = "0";
            if (ds.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvLeaveStatus.Rows.Add(1);
                    dgvLeaveStatus.Rows[i].Cells["mnth"].Value = ds.Tables[0].Rows[i]["monthname"].ToString();
                    dgvLeaveStatus.Rows[i].Cells["lv"].Value = ds.Tables[0].Rows[i]["lv"].ToString();
                    dgvLeaveStatus.Rows[i].Cells["ab"].Value = ds.Tables[0].Rows[i]["ab"].ToString(); 
                    if (ds.Tables[0].Rows[i]["ab"].ToString().ToString().Trim().Length != 0)
                    {
                        txtTotal.Text = (Convert.ToInt32(txtTotal.Text) + Convert.ToInt32(ds.Tables[0].Rows[i]["ab"].ToString())).ToString();
                    }
                }
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                dtpTo.Value = dtpFrom.Value;

            }
            else
            {
                SetHalfDay();
                CalculateNoOfDays();
            }
        }


        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                dtpFrom.Value = dtpTo.Value;

            }
            else
            {
                SetHalfDay();
                CalculateNoOfDays();
            }

        }


        private void CalculateNoOfDays()
        {
            DateTime d1 = dtpFrom.Value;
            DateTime d2 = d1;
            DateTime df = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
            DateTime dt = Convert.ToDateTime(dtpTo.Value.ToShortDateString());
            TimeSpan no = dt.Subtract(df);
            int noDays = no.Days;
            int j = 0;
            for (int i = 0; i <= noDays; i++)
            {
                if (d2.DayOfWeek.ToString() != "Sunday")
                {
                    j = j + 1;
                }
                d2 = d1.AddDays(i);
            }
            txtNoOfDays.Text = j.ToString();
        }

        private void SetHalfDay()
        {
            if (dtpFrom.Value == dtpTo.Value)
            {
                cbHalf.Enabled = true;
            }
            else
            {
                cbHalf.Enabled = false;
                cbHalf.Checked = false;
            }
        }

        private void InsertMethod()
        {
            InsertMethodHdr();
            chkAndInsertDtl();
        }
       
        private void UpdLeaveFlag(DateTime dt)
        {
            SqlConnection con = new SqlConnection(clsDbForReports.constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "ULeaveFlag";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dt", dt.ToShortDateString());
            cmd.Parameters.AddWithValue("@empid",cmbEmpName.SelectedValue);
            if (cbHalf.Checked == true)
            {
                cmd.Parameters.AddWithValue("@FOrH", "H");
            }
            else
            {
                cmd.Parameters.AddWithValue("@FOrH", "F");
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void chkAndInsertDtl()
        {
            DateTime d1 = dtpFrom.Value;
            DateTime d2 = d1;
            DateTime df = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
            DateTime dt = Convert.ToDateTime(dtpTo.Value.ToShortDateString());
            TimeSpan no = dt.Subtract(df);
            int noDays = no.Days + 1;
            DateTime cdt;
            for (int i = 1; i <= noDays; i++)
            {
                if (d2.DayOfWeek.ToString() != "Sunday")
                {
                    cdt = Convert.ToDateTime(d2.ToShortDateString());
                    InsertMethodDtl(cdt);
                    UpdateLeaveFlagOnAttDtl(cdt, "New");
                    UpdateLeaveCountOnAttHdr(cdt);
                    UpdLeaveFlag(cdt);
                }
                d2 = d1.AddDays(i);
            }
        }

        private void UpdateLeaveCountOnAttHdr(DateTime dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insertOnAttendHD";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@dt", dt);
            int i = scmd.ExecuteNonQuery();
            sc.Close();        

        }

        private int FindCompCode()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select compcode from employee where empid=@empid";
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbEmpName.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());                   
        }

        private bool NoDuplicate()
        {
            bool ret = true ;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid from tLeavedtl where  empid=@empid and (leavedate between @df and @dt)";
            sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbEmpName.SelectedValue));
            DateTime df = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
            DateTime dt = Convert.ToDateTime(dtpTo.Value.ToShortDateString());
            sda.SelectCommand.Parameters.AddWithValue("@df",df);
            sda.SelectCommand.Parameters.AddWithValue("@dt",dt);
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = false;
            }                
            return ret;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NewEdit == "New")
            {
                if (NoDuplicate() == true)
                {
                    InsertMethod();
                }
                else
                {
                    MessageBox.Show("Already exists");
                }
            }
            else
            {
                if (ActiveOrRes == "A")
                {
                    if (txtSlno.Text != "0" && txtSlno.Text.Trim().Length != 0)
                    {
                        UpdateEmployeeLeave();
                    }
                    else
                    {
                        MessageBox.Show("Please select a leave data or Find");
                    }
                }
                else
                {
                    MessageBox.Show("Cannot make modification for Resigned Employees");
                }
            }
            ShowAllEmpLeave();
        }

        private void UpdateEmployeeLeave()
        {
            UpdateEmployeeHdr();
            LoopOldDatesInDtl();
            DeleteDtl();
            chkAndInsertDtl();
        }

        private void ReverseStatusInAttDtl(DateTime dt)
        {
            SqlConnection con = new SqlConnection(clsDbForReports.constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update AttendanceDT set status=oldStatus from tleavedtl a join AttendanceDT b on a.empid=b.empid and a.LeaveDate=b.AttendanceDate where a.LeaveDate=@dt and a.empid=@empid";
            cmd.Parameters.AddWithValue("@dt", dt.ToShortDateString());
            cmd.Parameters.AddWithValue("@empid", cmbEmpName.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void LoopOldDatesInDtl()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select LeaveDate  from tLeaveDtl where  hdrrecid=@hrid";
            sda.SelectCommand.CommandType = CommandType.Text;
            sda.SelectCommand.Parameters.AddWithValue("@hrId", Convert.ToInt32(txtSlno.Text));      
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DateTime dt;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dt = Convert.ToDateTime ( ds.Tables[0].Rows[i]["LeaveDate"].ToString());
                    ReverseStatusInAttDtl(dt);
                    UpdateLeaveFlagOnAttDtl  (dt,"Edit");
                    UpdateLeaveCountOnAttHdr(dt);
                }
            }
        }
   
        private void UpdateLeaveFlagOnAttDtl(DateTime dt,string mod)
        {
            double hf = 1;
            if (cbHalf.Checked == true)
            {
                hf = 0.5;
            }
            if (mod == "Edit")
            {
                hf = 0.0;
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update AttendanceDT set Leave=@hf where empid=@empid and AttendanceDate=@dt";
            scmd.CommandType = CommandType.Text;
            scmd.Parameters.AddWithValue("@hf", hf);
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbEmpName.SelectedValue));
            scmd.Parameters.AddWithValue("@dt", dt);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void ReverseFlaginAtt()
        {
            SqlConnection con = new SqlConnection(clsDbForReports.constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "ReverseFlaginAtt";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@hdrRecid", Convert.ToInt32(txtSlno.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void DeleteDtl()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete tLeavedtl where hdrRecid=@hdrRecid";
            scmd.CommandType = CommandType.Text;
            scmd.Parameters.AddWithValue("@hdrRecid", Convert.ToInt32(txtSlno.Text));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void DeleteHdr()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete tLeaveHdr where hdrRecid=@hdrRecid";
            scmd.CommandType = CommandType.Text;
            scmd.Parameters.AddWithValue("@hdrRecid", Convert.ToInt32(txtSlno.Text));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void UpdateEmployeeHdr()
        {
            string hf = "N";
            if (cbHalf.Checked == true)
            {
                hf = "Y";
            }
            string san = "N";
            if (cbSanc.Checked == true)
            {
                san = "Y";
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "uLeaveHdr";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbEmpName.SelectedValue));
            scmd.Parameters.AddWithValue("@dtfrom", Convert.ToDateTime (dtpFrom.Value.ToShortDateString ()));
            scmd.Parameters.AddWithValue("@dtTo", Convert.ToDateTime (dtpTo.Value.ToShortDateString ()));
            scmd.Parameters.AddWithValue("@hf", hf);
            scmd.Parameters.AddWithValue("@sanctionedYN", san);
            scmd.Parameters.AddWithValue("@ltype", 1);
            scmd.Parameters.AddWithValue("@sanctionedBy", 10);
            scmd.Parameters.AddWithValue("@reason", txtReason.Text);
            scmd.Parameters.AddWithValue("@hdrRecid", Convert.ToInt32(txtSlno.Text));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void ShowAllEmpLeave()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string sqlString = "";
            sqlString = "select c.hdrRecid SlNo,a.EmpID,a.EmployeeName,b.Designation,convert(nvarchar(10),C.DTFROM,103) [From],convert(nvarchar(10),C.DTTo,103) [To],C.SanctionedYN,c.hf HalfDay,ActiveOrResigned [Active Or Resigned] from employee a,designation b,tleavehdr c where  a.empid=c.empid and a.desigcode=b.designationid order by c.recid desc";
            sda.SelectCommand.CommandText = sqlString;
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvAllEmpLeave.DataSource = ds.Tables[0];
            dgvAllEmpLeave.Columns[0].Width = 70;
            dgvAllEmpLeave.Columns[1].Width = 60;
            dgvAllEmpLeave.Columns[4].Width = 80;
            dgvAllEmpLeave.Columns[5].Width = 80;
            dgvAllEmpLeave.Columns[6].Width = 60;
            dgvAllEmpLeave.Columns[8].Width = 60;
        }

        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", scr);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private int ReadLastNum()
        {
            UpdateLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "select lastnum from tNumbers where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", scr);
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void InsertMethodHdr()
        {
            string hf = "N";
            if (cbHalf.Checked == true)
            {
                hf = "Y";
            }
            string san = "N";
            if (cbSanc.Checked == true)
            {
                san = "Y";
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "iLeaveHdr";
            scmd.CommandType = CommandType.StoredProcedure;
            txtSlno.Text = ReadLastNum().ToString();
            scmd.Parameters.AddWithValue("@hdrRecid", Convert.ToInt32 ( txtSlno.Text));
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbEmpName.SelectedValue));
            scmd.Parameters.AddWithValue("@dtfrom", Convert.ToDateTime (dtpFrom.Value.ToShortDateString ()));
            scmd.Parameters.AddWithValue("@dtTo", Convert.ToDateTime (dtpTo.Value.ToShortDateString ()));
            scmd.Parameters.AddWithValue("@hf", hf);
            scmd.Parameters.AddWithValue("@sanctionedYN", san);
            scmd.Parameters.AddWithValue("@ltype", 1);
            scmd.Parameters.AddWithValue("@sanctionedBy", 10);
            scmd.Parameters.AddWithValue("@reason", txtReason.Text);            
            int i = scmd.ExecuteNonQuery();
            sc.Close();            
        }
        private void InsertMethodDtl(DateTime dt)
        {
            double hf = 1;
            if (cbHalf.Checked == true)
            {
                hf = 0.5;
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "iLeaveDtl";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@hdrRecid", Convert.ToInt32(txtSlno.Text));
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbEmpName.SelectedValue));
            scmd.Parameters.AddWithValue("@LeaveDate", dt.ToShortDateString());
            scmd.Parameters.AddWithValue("@hf", hf);
            scmd.Parameters.AddWithValue("@ahf", hf);           
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewEdit = "New";
            txtMode.Text = "Mode is New";
            txtSlno.Text = "0";
            cmbEmpName.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            NewEdit = "Edit";
            txtMode.Text = "Mode is Edit";
            txtSlno.Text = "0";
            cmbEmpName.Enabled = false;
        }

        private void dgvAllEmpLeave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (NewEdit == "Edit")
            {
                cmbEmpName.Enabled = false;
                int x = e.RowIndex;
                if (x != -1)
                {
                    ActiveOrRes = dgvAllEmpLeave.Rows[x].Cells[8].Value.ToString();
                    txtSlno.Text = dgvAllEmpLeave.Rows[x].Cells[0].Value.ToString();
                    cmbEmpName.SelectedValue = dgvAllEmpLeave.Rows[x].Cells[1].Value;
                    if (ActiveOrRes == "R")
                    {
                        txtEmpName.Visible = true;
                        txtEmpName.Text = dgvAllEmpLeave.Rows[x].Cells[2].Value.ToString();
                    }
                    else
                    {
                        txtEmpName.Visible = false;
                    }
                    txtEmpID.Text = dgvAllEmpLeave.Rows[x].Cells[1].Value.ToString();
                    LoadLeaveDetails();
                }
            }
            else
            {
                MessageBox.Show("Not in Edit Mode");
                cmbEmpName.Enabled = true;
            }
        }

        private void LoadLeaveDetails()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,dtfrom,dtto,hf,SanctionedYN from tLeavehdr  where hdrRecid=@rc";
            sda.SelectCommand.Parameters.AddWithValue("@rc", Convert.ToInt32(txtSlno.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dtpFrom.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtfrom"].ToString());
                dtpTo.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtto"].ToString());
                if (ds.Tables[0].Rows[0]["hf"].ToString() == "Y")
                {
                    cbHalf.Checked = true;
                }
                else
                {
                    cbHalf.Checked = false;
                }
                if (ds.Tables[0].Rows[0]["SanctionedYN"].ToString() == "Y")
                {
                    cbSanc.Checked = true;
                }
                else
                {
                    cbSanc.Checked = false;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (NewEdit == "Edit")
            {
                if (txtFind.Text.Length != 0)
                {
                    txtSlno.Text = txtFind.Text;
                    LoadLeaveDetails();
                }
            }
            else
            {
                MessageBox.Show("Should be in edit mode");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (NewEdit == "Edit" && txtSlno.Text.Trim().Length != 0)
            {
                ReverseFlaginAtt();
                DeleteHdr();
                LoopOldDatesInDtl();            
                DeleteDtl();
                ShowAllEmpLeave();
            }
        }
    }
}
