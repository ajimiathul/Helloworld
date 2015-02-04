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
    public partial class HolidayEntry : Form
    {
        public HolidayEntry()
        {
            InitializeComponent();
        }

        int num = 0;
        DateTime dt12 = new DateTime();
        int falg = 0;
        private void InsertDates()
        {
            string day = dtdate.Value.DayOfWeek.ToString();
            string dt1 = dtdate.Value.ToShortDateString();
            DateTime dt2 = Convert.ToDateTime(dt1);

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();

            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select wdate from holiday where wdate=@dt2";
            sda.SelectCommand.Parameters.AddWithValue("@dt2",dt2);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Already exist");
            }
            else
            {
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "insert holiday (Wdate,Remarks,Wday) Values(@wdate,@remarks,@wday)";
               
                scmd.Parameters.AddWithValue("@wdate", dt2);
                scmd.Parameters.AddWithValue("@remarks", txtremark.Text);
                scmd.Parameters.AddWithValue("@wday", day.Trim().Substring(0, 3));
                int i = scmd.ExecuteNonQuery();
            }
                sc.Close();
             
            }

        private void AddGroupInListView()
        {
            lvholiday.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);

            sda.SelectCommand.CommandText = "select monthnumber,MonthName from holidayMonth order by disporder";

            DataSet ds = new DataSet();
            sda.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvholiday.Groups.Add(new ListViewGroup(ds.Tables[0].Rows[i]["monthname"].ToString(), HorizontalAlignment.Left));
                lvholiday.Groups[i].Name = ds.Tables[0].Rows[i]["monthnumber"].ToString();
            }
        }

        private void AssignGroupForItem()
        {
            for (int i = 0; i < lvholiday.Items.Count; i++)
            {
                for (int j = 0; j < lvholiday.Groups.Count; j++)
                {

                    if (lvholiday.Items[i].SubItems[4].Text == lvholiday.Groups[j].Name)
                    {
                        lvholiday.Items[i].Group = lvholiday.Groups[j];
                    }
                }
            }
        }
        private void btsave_Click(object sender, EventArgs e)
        {
            if (falg == 0)
            {
                
                InsertDates();
                AddGroupInListView();
                fillmaterial();
                AssignGroupForItem();

            }
            if (falg == 1)
            {
                updateholiday();
                AddGroupInListView();
                fillmaterial();
                AssignGroupForItem();
            }
            if (falg == 2)
            {
                deleteholiday();
                AddGroupInListView();
                fillmaterial();
                AssignGroupForItem();
            }

            btsave.Text = "save";
            falg = 0;
            txtremark.Text = "";
            lblmodechange.Text = "New";
        }

        private void fillmaterial()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "getholiday";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvholiday.Items.Add(ds.Tables[0].Rows[i]["slno"].ToString());
                //lvholiday.Items.Add(ds.Tables[0].Rows[i]["wdate"].ToString());
                lvholiday.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["wdate"].ToString());
                lvholiday.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["wday"].ToString());
                lvholiday.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["remarks"].ToString());
                lvholiday.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["montnum"].ToString());

            }

        }

        private void HolidayEntry_Load(object sender, EventArgs e)
        {

            AddGroupInListView();
            fillmaterial();
            AssignGroupForItem();


        }
        ListViewItem ItemSelected = new ListViewItem();

        private void lvholiday_MouseDown(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(lvholiday, new Point(e.X, e.Y));
            }

        }
        private void updateholiday()
        {

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update holiday set wdate=@wdate ,remarks=@remarks, wday=@wday where wdate=@w12date";
            string dt1 = dtdate.Value.ToShortDateString();
            DateTime dt2 = Convert.ToDateTime(dt1);
            string day = dtdate.Value.DayOfWeek.ToString();
            scmd.Parameters.AddWithValue("@remarks", txtremark.Text);
            scmd.Parameters.AddWithValue("@wdate", dt2);
            scmd.Parameters.AddWithValue("@w12date", dt12);
            scmd.Parameters.AddWithValue("@wday", day.Trim().Substring(0, 3));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }
        private void deleteholiday()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete from holiday  where wdate=@wdate";
            string dt1 = dtdate.Value.ToShortDateString();
            DateTime dt2 = Convert.ToDateTime(dt1);
            scmd.Parameters.AddWithValue("@wdate", dt2);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime d = Convert.ToDateTime(lvholiday.Items[(lvholiday.SelectedItems[0].Index)].SubItems[1].Text);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            dtdate.Value = d;
            txtremark.Text = lvholiday.Items[(lvholiday.SelectedItems[0].Index)].SubItems[3].Text;
            dt12 = dtdate.Value;

            if (e.ClickedItem.Text == "edit")
            {
                lblmodechange.Text = "update";
                btsave.Text = "update";
                falg = 1;

            }
            if (e.ClickedItem.Text == "delete")
            {
                lblmodechange.Text = "Delete";
                btsave.Text = "delete";
                falg = 2;

            }

        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            btsave.Text = "save";
            txtremark.Text = "";
            falg = 0;
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtdate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtdate_Leave(object sender, EventArgs e)
        {
            string dt1 = dtdate.Value.ToShortDateString();
            DateTime dt2 = Convert.ToDateTime(dt1);

            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Now;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", sc);


            sda.SelectCommand.CommandText = "getvalidyear";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                d1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]);
                d2 = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]);
            }


            if (!(dt2 > d1 && dt2 < d2))
            {
                MessageBox.Show("Invalid Date");

            }

        }

        }
    }


  
        

       
    

