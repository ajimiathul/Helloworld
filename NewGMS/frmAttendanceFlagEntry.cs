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
    public partial class frmAttendanceFlagEntry : Form
    {
        public frmAttendanceFlagEntry()
        {
            InitializeComponent();
        }
        bool FlexGrid1Filling = false,FlexGrid2Filling = true;
        bool needRefresh1 = false, needRefresh2 = false;
        bool Unchecking = false;
        private void FlexCellColumns1()
        {
            fcgAttFlagPresent.Cell(0, 1).Text = "Sl.No";
            fcgAttFlagPresent.Cell(0, 2).Text = "ID";
            fcgAttFlagPresent.Cell(0, 3).Text = "Name";
            fcgAttFlagPresent.Cell(0, 4).Text = "InTime";
            fcgAttFlagPresent.Cell(0, 5).Text = "OutTime";
            fcgAttFlagPresent.Cell(0, 6).Text = "Duration";
            fcgAttFlagPresent.Cell(0, 7).Text = "A";
            fcgAttFlagPresent.Cell(0, 8).Text = "H";
            fcgAttFlagPresent.Cell(0, 9).Text = "P";
            fcgAttFlagPresent.Cell(0, 10).Text = "O";
            fcgAttFlagPresent.Cell(0, 11).Text = "PreState";
            fcgAttFlagPresent.Cell(0, 12).Text = "NewState";
            fcgAttFlagPresent.Column(7).CellType = FlexCell.CellTypeEnum.CheckBox;
            fcgAttFlagPresent.Column(8).CellType = FlexCell.CellTypeEnum.CheckBox;
            fcgAttFlagPresent.Column(9).CellType = FlexCell.CellTypeEnum.CheckBox;
            fcgAttFlagPresent.Column(10).CellType = FlexCell.CellTypeEnum.CheckBox;
            fcgAttFlagPresent.Column(1).Width = 60;
            fcgAttFlagPresent.Column(2).Width = 60;
/*empName*/ fcgAttFlagPresent.Column(3).Width = 200;
            fcgAttFlagPresent.Column(4).Width = 65;
            fcgAttFlagPresent.Column(5).Width = 65;
            fcgAttFlagPresent.Column(6).Width = 65;
            fcgAttFlagPresent.Column(7).Width = 45;
            fcgAttFlagPresent.Column(8).Width = 45;
            fcgAttFlagPresent.Column(9).Width = 45;
            fcgAttFlagPresent.Column(10).Width = 45;
            fcgAttFlagPresent.Column(11).Visible = false;
            fcgAttFlagPresent.Column(12).Visible = false;
            fcgAttFlagPresent.Column(1).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagPresent.Column(2).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagPresent.Column(4).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagPresent.Column(5).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagPresent.Column(6).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagPresent.Column(11).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagPresent.Column(12).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagPresent.Column(1).Locked = true;
            fcgAttFlagPresent.Column(2).Locked = true;
            fcgAttFlagPresent.Column(3).Locked = true;
            fcgAttFlagPresent.Column(4).Locked = true;
            fcgAttFlagPresent.Column(5).Locked = true;
            fcgAttFlagPresent.Column(6).Locked = true;
        }
        private void FlexCellColumns2()
        {
            fcgAttFlagAbsent.Cell(0, 1).Text = "Sl.No";
            fcgAttFlagAbsent.Cell(0, 2).Text = "ID";
            fcgAttFlagAbsent.Cell(0, 3).Text = "Name";
            fcgAttFlagAbsent.Cell(0, 4).Text = "O";
            fcgAttFlagAbsent.Cell(0, 5).Text = "PreState";
            fcgAttFlagAbsent.Cell(0, 6).Text = "NewState";
            fcgAttFlagAbsent.Column(4).CellType = FlexCell.CellTypeEnum.CheckBox;
            fcgAttFlagAbsent.Column(1).Width = 60;
            fcgAttFlagAbsent.Column(2).Width = 60;
            fcgAttFlagAbsent.Column(3).Width = 200;
            fcgAttFlagAbsent.Column(5).Visible = false;
            fcgAttFlagAbsent.Column(6).Visible = false;
            fcgAttFlagAbsent.Column(1).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagAbsent.Column(2).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagAbsent.Column(5).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagAbsent.Column(6).Alignment = FlexCell.AlignmentEnum.CenterBottom;
            fcgAttFlagAbsent.Column(1).Locked = true;
            fcgAttFlagAbsent.Column(2).Locked = true;
            fcgAttFlagAbsent.Column(3).Locked = true;
        }

        private void frmAttendanceFlagEntry_Load(object sender, EventArgs e)
        {
            FlexCellColumns1();
            FlexCellColumns2();
            FlexGridFill1();
            FlexGridFill2();
        }

        private void FlexGridFill1()
        {
            FlexGrid1Filling = true;
            fcgAttFlagPresent.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "AttendanceExceptions";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DateTime d = Convert.ToDateTime(dtpAttendance.Value.ToShortDateString());
            sda.SelectCommand.Parameters.AddWithValue("@dt", dtpAttendance.Value);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            fcgAttFlagPresent.Rows = ds.Tables[0].Rows.Count + 1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                fcgAttFlagPresent.Cell(i + 1, 1).Text = (i + 1).ToString();
                fcgAttFlagPresent.Cell(i + 1, 2).Text = ds.Tables[0].Rows[i]["empid"].ToString();
                fcgAttFlagPresent.Cell(i + 1, 3).Text = ds.Tables[0].Rows[i]["EmployeeName"].ToString();
                fcgAttFlagPresent.Cell(i + 1, 4).Text = ds.Tables[0].Rows[i]["InTime"].ToString();
                fcgAttFlagPresent.Cell(i + 1, 5).Text = ds.Tables[0].Rows[i]["OutTime"].ToString();
                fcgAttFlagPresent.Cell(i + 1, 6).Text = ds.Tables[0].Rows[i]["InOutDurTime"].ToString();
                for (int j = 7; j <= 10; j++)
                {
                    fcgAttFlagPresent.Cell(i + 1, 11).Text = ds.Tables[0].Rows[i]["Flag"].ToString().Trim();
                    fcgAttFlagPresent.Cell(i + 1, 12).Text = ds.Tables[0].Rows[i]["Flag"].ToString().Trim();
                    if (ds.Tables[0].Rows[i]["Flag"].ToString().Trim() == fcgAttFlagPresent.Cell(0, j).Text.Trim())
                    {
                        fcgAttFlagPresent.Cell(i + 1, j).Text = "1";
                        for (int k = 1; k < fcgAttFlagPresent.Cols; k++)
                        {
                            fcgAttFlagPresent.Cell(i + 1, k).BackColor = System.Drawing.Color.LightGray;
                        }
                    }
                }
            }
            FlexGrid1Filling = false;
            needRefresh1 = false;
        }

        private void FlexGridFill2()
        {
            FlexGrid2Filling = true;
            fcgAttFlagAbsent.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select a.empid,b.EmployeeName,Flag from tAttendanceFlag a join Employee b on a.empid=b.EmpId where convert(nvarchar(10),AttendanceDate,101)=convert(nvarchar(10),@dt,101) and Flag in('A','O') and MissMatch='N' order by b.EmployeeName";
            sda.SelectCommand.Parameters.AddWithValue("@dt", dtpAttendance.Value);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            fcgAttFlagAbsent.Rows = ds.Tables[0].Rows.Count + 1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int j = 0;
                fcgAttFlagAbsent.Cell(i + 1, ++j).Text = (i + 1).ToString();
                fcgAttFlagAbsent.Cell(i + 1, ++j).Text = ds.Tables[0].Rows[i]["empid"].ToString();
                fcgAttFlagAbsent.Cell(i + 1, ++j).Text = ds.Tables[0].Rows[i]["EmployeeName"].ToString();
                fcgAttFlagAbsent.Cell(i + 1, 5).Text = ds.Tables[0].Rows[i]["Flag"].ToString().Trim();
                fcgAttFlagAbsent.Cell(i + 1, 6).Text = ds.Tables[0].Rows[i]["Flag"].ToString().Trim();
                if (ds.Tables[0].Rows[i]["Flag"].ToString().Trim() == "O")
                {
                    fcgAttFlagAbsent.Cell(i + 1, 4).Text = "1";
                    for (int k = 1; k < fcgAttFlagAbsent.Cols; k++)
                    {
                        fcgAttFlagAbsent.Cell(i + 1, k).BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }
            FlexGrid2Filling = false;
            needRefresh2 = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            FlexGridFill1();
            FlexGridFill2();
        }

        private void UncheckOthers(int row, int col)
        {
            Unchecking = true;
            for (int j = 7; j <= 10; j++)
            {
                if (j != col)
                {
                    fcgAttFlagPresent.Cell(row, j).Text = "0";
                }
            }
            Unchecking = false;
        }

        private void fcgAttendanceFlag_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            if (FlexGrid1Filling == false)
            {
                if (e.Col >= 7 && e.Col <= 10)
                {
                    if (fcgAttFlagPresent.Cell(e.Row, e.Col).BooleanValue == true)
                    {
                        fcgAttFlagPresent.Cell(e.Row, 12).Text = fcgAttFlagPresent.Cell(0, e.Col).Text;
                        UncheckOthers(e.Row, e.Col);
                    }
                    else if (Unchecking == false && fcgAttFlagPresent.Cell(e.Row, e.Col).BooleanValue == false)
                    {
                        fcgAttFlagPresent.Cell(e.Row, 12).Text = "M";
                    }
                }
            }
        }

        private void fcgAttFlagAbsent_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            if (FlexGrid2Filling == false && e.Col==4)
            {                
                if (fcgAttFlagAbsent.Cell(e.Row, e.Col).BooleanValue==true)
                {
                    fcgAttFlagAbsent.Cell(e.Row, 6).Text = "O";
                }
                else if (fcgAttFlagAbsent.Cell(e.Row, e.Col).BooleanValue == false)
                {
                    fcgAttFlagAbsent.Cell(e.Row, 6).Text = "A";
                }
            }
        }

        private void UpdateOption1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UFlagEntry";
            cmd.CommandType = CommandType.StoredProcedure;
            for (int k = 1; k < fcgAttFlagPresent.Rows; k++)
            {
                if (fcgAttFlagPresent.Cell(k, 11).Text.Trim() != fcgAttFlagPresent.Cell(k, 12).Text.Trim())
                {
                    cmd.Parameters.AddWithValue("@dt", dtpAttendance.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@empid", fcgAttFlagPresent.Cell(k, 2).Text);
                    cmd.Parameters.AddWithValue("@Flag", fcgAttFlagPresent.Cell(k, 12).Text.Trim());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    needRefresh1 = true;
                }
            }
            con.Close();
        }

        private void UpdateOption2()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UAbsentOnDuty";
            cmd.CommandType = CommandType.StoredProcedure;
            for (int k = 1; k < fcgAttFlagAbsent.Rows; k++)
            {
                if (fcgAttFlagAbsent.Cell(k, 5).Text.Trim() != fcgAttFlagAbsent.Cell(k, 6).Text.Trim())
                {
                    cmd.Parameters.AddWithValue("@dt", dtpAttendance.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@empid", fcgAttFlagAbsent.Cell(k, 2).Text);
                    cmd.Parameters.AddWithValue("@Flag", fcgAttFlagAbsent.Cell(k, 6).Text.Trim());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    needRefresh2 = true;
                }
            }
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            UpdateOption1();
            UpdateOption2();
            if (needRefresh1 == true)
            {
                FlexGridFill1();
            }
            if (needRefresh2 == true)
            {
                FlexGridFill2();
            }
        }
    }
}
