using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmUtilityAttendance : Form
    {
        public frmUtilityAttendance()
        {
            InitializeComponent();
        }


        private void CreateDate()
        {

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();

            DateTime st = Convert.ToDateTime("11/01/2011");
            DateTime end = Convert.ToDateTime("03/31/2012");
            DateTime dt = st;
            while (dt <= end)
            {
                SqlCommand scmd = new SqlCommand("", sc);
                string cmdStr1 = "insert into AttendanceHD(compcode,AttendanceDate,totStrength,hdays,fdays,absent,leave,transfertime,transfered) ";
                string cmdStr2 = " values(@cc,@dt,@ts,@hd,@fd,@ab,@lv,@tt,@td)";
                scmd.CommandText = cmdStr1 + cmdStr2;
                string x = dt.ToShortDateString();
                DateTime y = Convert.ToDateTime(x);
                scmd.Parameters.Clear();
                scmd.Parameters.AddWithValue("@cc", 2);
                scmd.Parameters.AddWithValue("@dt", y);
                scmd.Parameters.AddWithValue("@ts", 0);
                scmd.Parameters.AddWithValue("@hd", 0);
                scmd.Parameters.AddWithValue("@fd", 0);
                scmd.Parameters.AddWithValue("@ab", 0);
                scmd.Parameters.AddWithValue("@lv", 0);
                scmd.Parameters.AddWithValue("@tt", 0);
                scmd.Parameters.AddWithValue("@td", 'N');
                int i = scmd.ExecuteNonQuery();
                dt = dt.AddDays(1);
            }
            sc.Close();
            button1.Enabled = false;

        
        }

        private void frmUtilityAttendance_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
