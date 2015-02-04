using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmManualRegAttendance : Form
    {
        bool nameFlag = false;
        int loopFlag = 0;
        
        public frmManualRegAttendance()
        {
            InitializeComponent();
        }

        private void frmManualRegAttendance_Load(object sender, EventArgs e)
        {
            nameFlag = false;
            LoadEmployee();
            nameFlag = true;
            InHr();
            InMnts();
            OutHr();
            OutMnts();
            cmbInHr.Text = "0";
            cmbInMnt.Text = "0";
            cmbOutHr.Text = "0";
            cmbOutMnt.Text = "0";
            txtID.Text = cmbName.SelectedValue.ToString();
            ShowData();
            ShowEmployeeDateInfo();
        }

        private void InHr()
        {
            for (int i = 0; i <= 23; i++)
            {
                cmbInHr.Items.Add(i.ToString());
            }
        }


        private void InMnts()
        {
            for (int i = 0; i <= 59; i++)
            {
                cmbInMnt.Items.Add(i.ToString());
            }
        }


        private void OutHr()
        {
            for (int i = 0; i <= 23; i++)
            {
                cmbOutHr.Items.Add(i.ToString());
            }
        }


        private void OutMnts()
        {
            for (int i = 0; i <= 59; i++)
            {
                cmbOutMnt.Items.Add(i.ToString());
            }
        }


        private void LoadEmployee()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,employeename from employee where (joindate <= @dt and (dor is null or  @dt <= dor )) order by employeename";
            sda.SelectCommand.Parameters.AddWithValue("@dt", Convert.ToDateTime(dtpMReg.Value.ToShortDateString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbName.DataSource = ds.Tables[0];
            cmbName.DisplayMember = "employeename";
            cmbName.ValueMember = "empid";
        }

        private void ShowEmployeeDateInfo()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select InPunchOrManual,cast(InTimeHr  as int) InTimeHr,cast(InTimeMnt as int) InTimeMnt, OutPunchOrManual,cast(OutTimeHR as int) OutTimeHR ,cast(OutTimeMnt as int) OutTimeMnt,remarks from AttManual where   dt=@dt and empid=@empid";
            DateTime dt = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            sda.SelectCommand.Parameters.AddWithValue("@dt", dt);
            sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32  (txtID.Text));
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbInHr.Text = ds.Tables[0].Rows[0]["InTimeHr"].ToString();
                cmbInMnt.Text = ds.Tables[0].Rows[0]["InTimeMnt"].ToString();
                cmbOutHr.Text = ds.Tables[0].Rows[0]["OutTimeHR"].ToString();
                cmbOutMnt.Text = ds.Tables[0].Rows[0]["OutTimeMnt"].ToString();
                cbInManual.Checked = true;
                cbOutManual.Checked = true;
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["InPunchOrManual"].ToString() == "P")
                {
                    cbInManual.Checked = false;
                   
                }

                if (ds.Tables[0].Rows[0]["OutPunchOrManual"].ToString() == "P")
                {
                    cbOutManual.Checked = false;
                }
            }
            else
            {
                cmbInHr.Text = "0";
                cmbInMnt.Text = "0";
                cmbOutHr.Text = "0";
                cmbOutMnt.Text = "0";
                cbInManual.Checked = false;
                cbOutManual.Checked = false;
                txtRemarks.Text = "";
            }
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loopFlag = loopFlag + 1;
            if (loopFlag == 1)
            {
                if (nameFlag == true)
                {
                    txtID.Text = cmbName.SelectedValue.ToString();
                    ShowEmployeeDateInfo();
                }
                else
                {
                    cbInManual.Checked = false;
                    cbOutManual.Checked = false;
                }
            }
            loopFlag = 0;           
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            loopFlag = loopFlag + 1;
            if ((txtID.Text.Trim().Length != 0) && (txtID.Text != null) && (loopFlag == 1))
            {
                cmbName.SelectedValue = txtID.Text;
                ShowEmployeeDateInfo();
            }
            else
            {
                cbInManual.Checked = false;
                cbOutManual.Checked = false;
            }
            loopFlag = 0;           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NoDuplicate() == true)
            {
                if ((cbOutManual.Checked == true) || (cbInManual.Checked == true))
                {
                    insertNewData();
                }
            }
            UpdateIn();
            UpdateOut();
            UpdateOnAttDtl();
            UpdateOnAttDtlStatus();
            UpdateOnAttHdr();
            UpdateInAttFlag(); 
            CalculateDuration();
            ShowData();
        }
     
        private void UpdateIn()
        {
            DateTime intm = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            TimeSpan ts = new TimeSpan(Convert.ToInt32(cmbInHr.Text), Convert.ToInt32(cmbInMnt.Text), 0);
            intm = intm.Date + ts;            
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update AttManual set InpunchOrManual=@ipm,InTimeHR=@ihr,InTimeMnt=@imn,InTime=@intm,remarks=@rem,EntryTime=getdate() where dt=@dt and empid=@empid";
            scmd.CommandType = CommandType.Text;
            int ihr = Convert.ToInt32(cmbInHr.Text);
            int imn = Convert.ToInt32(cmbInMnt.Text);
            string ipm = "M";
            if (cbInManual.Checked == false )
            {
                ipm ="P";
                ihr =0;
                imn =0;
            }
            scmd.Parameters.AddWithValue("@ipm", ipm );
            scmd.Parameters.AddWithValue("@ihr", ihr);
            scmd.Parameters.AddWithValue("@imn", imn);
            scmd.Parameters.AddWithValue("@intm", intm);
            scmd.Parameters.AddWithValue("@rem", txtRemarks.Text);            
            DateTime dt = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            scmd.Parameters.AddWithValue("@dt", dt);
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbName.SelectedValue));
            int i = scmd.ExecuteNonQuery();
            sc.Close();                             
        }
        
        private void UpdateOut()
        {            
            DateTime ontm = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            TimeSpan ts = new TimeSpan(Convert.ToInt32(cmbOutHr.Text), Convert.ToInt32(cmbOutMnt.Text), 0);
            ontm = ontm.Date + ts;

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update AttManual set OutpunchOrManual=@opm,OutTimeHR=@ohr,OutTimeMnt=@omn,OutTime=@ontm,remarks=@rem,EntryTime=getdate() where dt=@dt and empid=@empid";
            scmd.CommandType = CommandType.Text;
            string opm = "M";
            int ohr = Convert.ToInt32(cmbOutHr.Text);
            int omn = Convert.ToInt32(cmbOutMnt.Text);
            if (cbOutManual.Checked  == false )
            {
                opm = "P";
                ohr = 0;
                omn = 0;
            }
            scmd.Parameters.AddWithValue("@opm", opm);
            scmd.Parameters.AddWithValue("@ohr", ohr);
            scmd.Parameters.AddWithValue("@omn", omn);
            scmd.Parameters.AddWithValue("@ontm", ontm);
            scmd.Parameters.AddWithValue("@rem", txtRemarks.Text);
            DateTime dt = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            scmd.Parameters.AddWithValue("@dt", dt);
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbName.SelectedValue));
            int i = scmd.ExecuteNonQuery();
            sc.Close();       
        }

        private void ShowData()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select a.empid,b.employeename,str((InTimeHr  +InTimeMnt/100),5,2) as InTime, str((OutTimeHR+OutTimeMnt/100),5,2) as OutTime,a.InpunchOrManual intype,a.OutpunchOrManual outtype from AttManual a,employee b where a.empid=b.empid and   a.dt=@dt ";
            DateTime dt = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            sda.SelectCommand.Parameters.AddWithValue("@dt", dt);
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvRegData.DataSource = ds.Tables[0];
        }

        private bool NoDuplicate()
        {
            bool ret = true;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid from AttManual where  empid=@empid and dt=@dt ";
            sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbName.SelectedValue));
            DateTime dt = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());           
            sda.SelectCommand.Parameters.AddWithValue("@dt", dt);
            sda.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = false;
            }
            return ret;
        }

        private void insertNewData()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert into AttManual(dt,empid) values(@dt,@empid)";
            scmd.CommandType = CommandType.Text;
            DateTime dt = Convert.ToDateTime (dtpMReg.Value.ToShortDateString());
            scmd.Parameters.AddWithValue("@dt", dt);
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(cmbName.SelectedValue));
            int i = scmd.ExecuteNonQuery();
            sc.Close();                     
        }

        private void dtpMReg_ValueChanged(object sender, EventArgs e)
        {
            LoadEmployee();
            ShowEmployeeDateInfo();
            ShowData();
        }
        
        private void UpdateOnAttDtl()
        {
            string st = "P";
            if (cbInManual.Checked == false && cbOutManual.Checked == false)
            {
                st = "A";
            }
            DateTime intm = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            TimeSpan its = new TimeSpan(Convert.ToInt32(cmbInHr.Text), Convert.ToInt32(cmbInMnt.Text), 0);
            intm = intm.Date + its;
            DateTime ontm = Convert.ToDateTime(dtpMReg.Value.ToShortDateString());
            TimeSpan ots = new TimeSpan(Convert.ToInt32(cmbOutHr.Text), Convert.ToInt32(cmbOutMnt.Text), 0);
            ontm = ontm.Date + ots;
            string ipm = "M";
            if (cbInManual.Checked  == false )
            {
                ipm = "P";
            }
            string opm = "M";
            if (cbOutManual.Checked  == false )
            {
                opm = "P";
            }            
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update AttendanceDT set mrInTime=@intm,mrOutTime=@ottm,status=@st,InPunchOrManual=@ipm,OutPunchOrManual=@opm where empid=@empid and AttendanceDate=@dt";
            scmd.CommandType = CommandType.Text;
            scmd.Parameters.AddWithValue("@intm", intm);
            scmd.Parameters.AddWithValue("@ottm", ontm);
            scmd.Parameters.AddWithValue("@st", st);
            scmd.Parameters.AddWithValue("@ipm", ipm);
            scmd.Parameters.AddWithValue("@opm", opm);
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
            scmd.Parameters.AddWithValue("@dt", Convert.ToDateTime(dtpMReg.Value.ToShortDateString()));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void UpdateOnAttDtlStatus()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update AttendanceDT set status='P' where empid=@empid and AttendanceDate=@dt and tempstatus='P'";
            scmd.CommandType = CommandType.Text ;
            scmd.Parameters.AddWithValue("@dt",dtpMReg.Value.ToShortDateString());
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
            int i = scmd.ExecuteNonQuery();
            sc.Close();    
        }

        private void UpdateInAttFlag()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "FlagEntryFromManReg";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dt", dtpMReg.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
            cmd.ExecuteNonQuery();
            con.Close();            
        }

        private void UpdateOnAttHdr()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insertOnAttendHD";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@dt", Convert.ToDateTime(dtpMReg.Value.ToShortDateString()));
            int i = scmd.ExecuteNonQuery();
            sc.Close();        
        }

        
        private void CalculateDuration()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "calDayDurationForEmpid";
            string x = dtpMReg.Value.ToShortDateString();
            DateTime y = Convert.ToDateTime(x);
            scmd.Parameters.AddWithValue("@dt", y);
            scmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtID.Text));
            scmd.CommandType = CommandType.StoredProcedure;
            int i = scmd.ExecuteNonQuery();
            sc.Close();
         }

        

    }
}
