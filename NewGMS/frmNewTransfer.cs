using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessLayer;


namespace NewGMS
{
    public partial class frmNewTransfer : Form
    {
        bool compflag1 = false;
        bool compflag2 = false;
        DateTime MaxDate;
        DateTime MinDate;
        bool MonthComboLoading = false;
        bool NotFromMCombo = true;
        public frmNewTransfer()
        {
            InitializeComponent();
        }

        private void SpecicDateTime()
        {
            try
            {
                txtFromDt.Text = "";
                txtToDt.Text = "";
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.FPConStr();
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                sda.SelectCommand.CommandText = "select max(DateTime) td, min(DateTime) fd,(convert(nvarchar(10), max(DateTime),103) +' '+ convert(nvarchar(10), max(DateTime),108)) mx,(convert(nvarchar(10), min(DateTime),103) +' '+ convert(nvarchar(10), min(DateTime),108)) mn from log where convert(nvarchar(10),datetime,101)=convert(nvarchar(10),@dt,101)";
                sda.SelectCommand.Parameters.AddWithValue("@dt", Convert.ToDateTime(dtpTransfer.Value.ToShortDateString()));
                DataSet ds = new DataSet();
                sda.Fill(ds);           
                if (ds.Tables[0].Rows.Count >= 1 && ds.Tables[0].Rows[0][0]!= DBNull.Value )
                {
                    txtFromDt.Text = ds.Tables[0].Rows[0]["mn"].ToString();
                    txtToDt.Text = ds.Tables[0].Rows[0]["mx"].ToString();
                    MaxDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["td"].ToString());
                    MinDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fd"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
         }

        private void NormalTransferMinMax()
        {
            txtFromDt.Text = "";
            txtToDt.Text = "";
            LastDataTransferLogDate();
            MaxLogDate103();
            MaxLogDate101();          
        }

        private void MaxLogDate103()
        {
            try
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.FPConStr();
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                sda.SelectCommand.CommandText = "select (convert(nvarchar(10), max(DateTime),103) +' '+ convert(nvarchar(10), max(DateTime),108)) mx from log ";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    txtToDt.Text = ds.Tables[0].Rows[0]["mx"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }

       

        private void  MaxLogDate101()
        {           
            try
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.FPConStr();
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                sda.SelectCommand.CommandText = "select  max(DateTime) mx from log ";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    MaxDate  = Convert.ToDateTime(ds.Tables[0].Rows[0]["mx"].ToString());
                    
                }
            }
            catch
            {
                MessageBox.Show("No Connection");
            }            
        }

        private DateTime  chkTime()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select (convert(nvarchar(10), fpTrasferTime,103) +' '+ convert(nvarchar(10), fpTrasferTime,108)) min,fpTrasferTime  from tLastFPTransferTime  ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return  Convert.ToDateTime(ds.Tables[0].Rows[0]["fpTrasferTime"].ToString());            
        }

        private void LastDataTransferLogDate()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select (convert(nvarchar(10), fpTrasferTime,103) +' '+ convert(nvarchar(10), fpTrasferTime,108)) min,fpTrasferTime  from tLastFPTransferTime  ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                    txtFromDt.Text = ds.Tables[0].Rows[0]["min"].ToString();
                    MinDate = Convert.ToDateTime (ds.Tables[0].Rows[0]["fpTrasferTime"].ToString());                
            }          
        }
        
        private void UpdateLastTime()
        {
            if (chkSpecificDay.Checked == false)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                string cmdStr = "update tLastFPTransferTime set fpTrasferTime=@dt";
                scmd.Parameters.AddWithValue("@dt", MaxDate);
                scmd.CommandText = cmdStr;
                int i = scmd.ExecuteNonQuery();
                sc.Close();
            }
        }

        private bool CheckDateInFlagAtt(DateTime dt)
        {
            bool present = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Recid from tAttendanceFlag where AttendanceDate=@dt";
            sda.SelectCommand.Parameters.AddWithValue("@dt", dt.ToShortDateString());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                present = true;
            }
            return present;
        }

        private void UpdateFlagInAttDt(DateTime dt)
        {
            SqlConnection con = new SqlConnection(clsDbForReports.constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "uFlagInAttendanceDt";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dt", dt);
            cmd.ExecuteNonQuery();
            con.Close();            
        }

        private void InsertAttendanceFlag(DateTime dt)        
        {            
            SqlConnection con = new SqlConnection(clsDbForReports.constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "iAttendanceFlag";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dt", dt.ToShortDateString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
               
        private void btnTransferClick(DateTime dt,int k)
        {
            //progressBar1.Value = k + 100;
            //progressBar1.Value = k + 100;
            DeleteAttDtl(dt);
            //progressBar1.Value = k+100;
            InsertAllEmpData(dt);
            //progressBar1.Value = k + 100;
            LeaveUpdation(dt);
            //progressBar1.Value = k + 100;
            FromFPToGMS(dt);
            //progressBar1.Value = k + 100;
            ManualRegUpdation(dt);
            //progressBar1.Value = k + 100;
            InsertDataOnHD(dt);
            //progressBar1.Value = k + 100;
            CalculateDuration(dt);
            //progressBar1.Value = k + 100;
            //progressBar1.Value = k + 100;
        }
        
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            DateTime Expired=Convert.ToDateTime("08/31/2012 12:00:00 PM");
            if (MaxDate > Expired)
            {
                MessageBox.Show("Date Expired........!");
            }
            else
            {
                if (txtFromDt.Text.Trim().Length != 0)
                {
                    var result = MessageBox.Show("Do you want to Transfer?", "Transfer",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DateTime mxtd = Convert.ToDateTime(MaxDate.ToShortDateString());
                        DateTime dt = Convert.ToDateTime(MinDate.ToShortDateString());
                        TimeSpan no = mxtd.Subtract(dt);
                        int noDays = no.Days;
                        //progressBar1.Maximum = 1000 * noDays*2;
                        for (int i = 0; i <= noDays; i++)
                        {
                            int k = 1000;
                            //progressBar1.Value = k;
                            btnTransferClick(dt, k);
                            if (CheckDateInFlagAtt(dt) == true)
                            {
                                UpdateFlagInAttDt(dt);
                            }
                            else
                            {
                                InsertAttendanceFlag(dt);
                            }
                            k = k + 1000;
                            //progressBar1.Value = k;
                            dt = dt.AddDays(1);
                        }
                        UpdateLastTime();
                        MessageBox.Show("Transferred");
                        btnTransfer.Enabled = false;
                    }
                    LoadAttendance(MaxDate.Month);
                }
                else
                {
                    MessageBox.Show("Please Un Check the option and click transfer for normal transfer ");
                }
            }
        }

        private void CalculateDuration(DateTime dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "calDayDuration";            
            scmd.Parameters.AddWithValue("@dt", dt);
            scmd.CommandType = CommandType.StoredProcedure;
            int i = scmd.ExecuteNonQuery();
            sc.Close();
         }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteAttDtl(DateTime  dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            string cmdStr = "delete AttendanceDT where AttendanceDate=@dt";            
            scmd.Parameters.AddWithValue("@dt", dt);            
            scmd.CommandText = cmdStr;
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void InsertAllEmpData(DateTime dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);            
            scmd.CommandText = "iAttendanceFromEmployee";           
            scmd.Parameters.AddWithValue("@dt", dt);            
            scmd.CommandType = CommandType.StoredProcedure;
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void LeaveUpdation(DateTime dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "upDateLeaveInDTL";           
            scmd.Parameters.AddWithValue("@dt", dt);
            scmd.CommandType = CommandType.StoredProcedure;
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void FromFPToGMS(DateTime dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.FPConStr();
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "sLogDataNewGMS";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@dt",dt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Int32 empid;
            DateTime inTime ;
            DateTime outTime;
            int rsCount = ds.Tables[0].Rows.Count;
            if (rsCount >= 1)
            {
                for (int i = 0; i < rsCount; i++)
                {
                    empid = Convert.ToInt32(ds.Tables[0].Rows[i]["empid"]);
                    inTime = Convert.ToDateTime (ds.Tables[0].Rows[i]["mi"]);
                    outTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["mx"]);
                    UpdateTime(empid, inTime, outTime, dt);
                }
            }
        }        

        private void UpdateTime(int empid, DateTime  inTime, DateTime  outTime,DateTime dt)
        {          
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            string cmdStr = "";
            cmdStr = "update AttendanceDt set Status= @st,tempstatus=@st,pmInTime=@inT,pmOutTime=@Ot where AttendanceDate= @dt and empid=@eid";
            scmd.CommandText = cmdStr;
            scmd.Parameters.AddWithValue("@st", "P");
            scmd.Parameters.AddWithValue("@inT", inTime);
            scmd.Parameters.AddWithValue("@Ot", outTime);            
            scmd.Parameters.AddWithValue("@dt", dt);
            scmd.Parameters.AddWithValue("@eid", empid);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void ManualRegUpdation(DateTime dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "upDateManualAtt";            
            scmd.Parameters.AddWithValue("@dt", dt);
            scmd.CommandType = CommandType.StoredProcedure;
            int i = scmd.ExecuteNonQuery();
            sc.Close();            
        }

        private void InsertDataOnHD(DateTime dt)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insertOnAttendHD";
            scmd.CommandType = CommandType.StoredProcedure;                        
            scmd.Parameters.AddWithValue("@dt",dt);           
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void SpecificDayCheckig()
        {
            if (dtpTransfer.Value < chkTime())
            {
                SpecicDateTime();
                LoadAttendance(MaxDate.Month);
            }
            else
            {
                SpecicDateTime();
                dtpTransfer.Value = chkTime();
            }        
        }

        private void dtpTransfer_ValueChanged(object sender, EventArgs e)
        {
            SpecificDayCheckig();                       
        }

        private void LoadCompany()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select compcode,companyName  from company order by disporder";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbTransferCompany.DataSource = ds.Tables[0];
            cmbTransferCompany.DisplayMember = "companyName";
            cmbTransferCompany.ValueMember = "compcode";
        }

        private void LoadCompany2()
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

        private void LoadMonth()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select *  from holidayMonth";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            MonthComboLoading = true;
            cmbMonth.DataSource = ds.Tables[0];
            cmbMonth.DisplayMember = "MonthName";
            cmbMonth.ValueMember = "monthNumber";
            MonthComboLoading = false;
        }

        private void frmNewTransfer_Load(object sender, EventArgs e)
        {
            LoadMonth();
            dtpTransfer.Enabled = false;
            compflag1 = false;
            compflag2 = false;
            LoadCompany();
            LoadCompany2();
            compflag1 = true;
            compflag2 = true;
            NormalTransferMinMax(); 
            LoadAttendance(MaxDate.Month);
        }

        private void LoadAttendance(int Mcod)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = "select convert(nvarchar(10),attendancedate,103) Date,datename(dw,attendancedate) Day,  ";
            string s2 = " leavehdays [Half Day Leave],leavefdays [Full Day Leave],Present, Absent,convert(nvarchar(20),TransferTime,113) TransferTime,UnsetStatus [No.of Unset Status],TotMissMatch from attendancehd ";
            string s3 =" where transfered='Y' and compcode=@cc and month(attendancedate)=@monthCod";
            sda.SelectCommand.CommandText = s1 + s2 + s3;
            sda.SelectCommand.Parameters.AddWithValue("@cc",Convert.ToInt32 (cmbTransferCompany.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@monthCod", Mcod);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvAttHD.DataSource = ds.Tables[0];
            dgvAttHD.Columns[6].Width = 160;
            dgvAttHD.Columns[4].Width = 80;
            dgvAttHD.Columns[5].Width = 80;            
            dgvAttHD.Columns[7].Width = 80;
            dgvAttHD.Columns[8].Width = 80;
            if (NotFromMCombo == true)
            {
                cmbMonth.SelectedValue = Mcod;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (compflag1 == true)
            {
                LoadAttendance(MaxDate.Month);
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (compflag2 == true)
            {
                ShowAttDtl();
            }
        }

        private void ShowAttDtl()
        {
            dgvView.Rows.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = " select a.empid, b.employeeName,InTime=case a.InPunchOrManual when 'P' then str((DATEPART(hh,a.pmInTime) +  (cast(DATEPART(mi,a.pmInTime) as money)/100)),5,2) else str((DATEPART(hh,a.mrintime) + (cast(DATEPART(mi,a.mrintime) as money)/100)),5,2)+'*' end, ";
            string s2 = " OutTime=case a.OutPunchOrManual when 'P' then str((DATEPART(hh,a.pmOuttime)+  (cast(DATEPART(mi,a.pmOuttime) as money)/100)),5,2) else str((DATEPART(hh,a.mrouttime)+  (cast(DATEPART(mi,a.mrouttime) as money)/100)),5,2) end, ";
            string s3 = " a.Status,a.Leave,a.ActiveOrResigned,convert(nvarchar(10),B.JOINDATE,103) JOINDATE,convert(nvarchar(10),B.DOR,103) dor,a.InOutDurTime,d.MissMatch ";
            string s4 = " from attendancedt a,employee b left join tAttendanceFlag d on d.empid=b.empid and d.attendancedate=@dt where  a.empid=b.empid and a.compcode=@cc and a.attendancedate=@dt";
            string s5 = " ";
            if (rbAll.Checked == true)
            {
                 s5 = "  ";
            }
            if (rbAbsent.Checked == true)
            {
                s5 = " and a.status='A' ";
            }
            if (rbPresent.Checked == true)
            {
                s5 = " and a.status='P'";
            }
            if (rbLeave.Checked == true)
            {
                s5 = " and a.Leave<> 0.0";
            }
            if (rbOnDuty.Checked == true)
            {
                s5 = " and a.status='O'";
            }
            if (rbHalfDay.Checked == true)
            {
                s5 = " and a.status='H'";
            }
            string s7 = "";
            s7 = s1 + s2 + s3 + s4 + s5;
            string s8 = "select row_number() over(order by empid) slno,empid,employeename,InTime,OutTime,status,Leave = case  leave when 1.0 then 'F' when 0.5 then 'H' else 'Nil' end,ActiveOrResigned,JOINDATE,DOR,InOutDurTime,MissMatch from ( " + s7 + " ) ab";
            sda.SelectCommand.CommandText = s8;
            sda.SelectCommand.Parameters.AddWithValue("@cc", Convert.ToInt32(cmbCompany.SelectedValue));
            string x = dtpView.Value.ToShortDateString();
            DateTime y = Convert.ToDateTime(x);            
            sda.SelectCommand.Parameters.AddWithValue("@dt", y);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int b = 0;
            for (int a = 1; a <= ds.Tables[0].Rows.Count; a++)
            {
                dgvView.Rows.Add(1);
                b = dgvView.Rows.Count;
                dgvView.Rows[b - 1].Cells["column9"].Value = ds.Tables[0].Rows[a - 1]["slno"].ToString();
                dgvView.Rows[b - 1].Cells["column1"].Value = ds.Tables[0].Rows[a - 1]["empid"].ToString();
                dgvView.Rows[b - 1].Cells["column2"].Value = ds.Tables[0].Rows[a - 1]["employeeName"].ToString();
                dgvView.Rows[b - 1].Cells["column3"].Value = ds.Tables[0].Rows[a - 1]["InTime"].ToString();
                dgvView.Rows[b - 1].Cells["column4"].Value = ds.Tables[0].Rows[a - 1]["OutTime"].ToString();
                dgvView.Rows[b - 1].Cells["InOutDurTime"].Value = ds.Tables[0].Rows[a - 1]["InOutDurTime"].ToString();  
                dgvView.Rows[b - 1].Cells["column5"].Value = ds.Tables[0].Rows[a - 1]["status"].ToString();
                dgvView.Rows[b - 1].Cells["column6"].Value = ds.Tables[0].Rows[a - 1]["Leave"].ToString();
                dgvView.Rows[b - 1].Cells["ActiveOrResigned"].Value = ds.Tables[0].Rows[a - 1]["ActiveOrResigned"].ToString();
                dgvView.Rows[b - 1].Cells["JOINDATE"].Value = ds.Tables[0].Rows[a - 1]["JOINDATE"].ToString();
                dgvView.Rows[b - 1].Cells["DOR"].Value = ds.Tables[0].Rows[a - 1]["DOR"].ToString();
                dgvView.Rows[b - 1].Cells["MissMatch"].Value = ds.Tables[0].Rows[a - 1]["MissMatch"].ToString();
            }
            dgvView.Columns["column9"].Width = 60;
            dgvView.Columns[1].Width = 60;
            dgvView.Columns["column2"].Width = 250;
            dgvView.Columns[3].Width = 60;
            dgvView.Columns[4].Width = 60;
            dgvView.Columns[5].Width = 60;
            dgvView.Columns[6].Width = 60;
            dgvView.Columns["column6"].Width = 60;
            dgvView.Columns[8].Width = 90;
            dgvView.Columns[9].Width = 90;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ShowAttDtl();
        }
        
        private void rbPresent_CheckedChanged(object sender, EventArgs e)
        {
            ShowAttDtl();
        }

        private void rbAbsent_CheckedChanged(object sender, EventArgs e)
        {
            ShowAttDtl();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpView_ValueChanged(object sender, EventArgs e)
        {
            ShowAttDtl();
        }
                
        private void rbLeave_CheckedChanged(object sender, EventArgs e)
        {
            ShowAttDtl();
        }

        private void rbHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            ShowAttDtl();
        }

        private void rbOnDuty_CheckedChanged(object sender, EventArgs e)
        {
            ShowAttDtl();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            ShowAttDtl();
        }

        private void chkSpecificDay_CheckedChanged(object sender, EventArgs e)
        {
            btnTransfer.Enabled = true;
            if (chkSpecificDay.Checked == true)
            {
                dtpTransfer.Enabled = true;
                SpecificDayCheckig();                    
            }
            else
            {
                dtpTransfer.Enabled = false;
                NormalTransferMinMax();                
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MonthComboLoading == false)
            {
                NotFromMCombo = false;
                LoadAttendance((int)cmbMonth.SelectedValue);
                NotFromMCombo = true;
            }
        }
    }
}
