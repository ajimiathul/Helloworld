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
    public partial class frmStyleActOperator : Form
    {
        public frmStyleActOperator()
        {
            InitializeComponent();
        }
        int flag = 0;
        private void frmStyleActOperator_Load(object sender, EventArgs e)
        {
            FlexNamings();
            fillstylecode();
            //fillActivity();
            LoadOperator();
            //for (int i = 0; i < grid1.Rows - 1; i++)
            //{
            //    grid1.Cell(i + 1, 2).Text = "NA";
            //}

        }
        
        
        private void FlexNamings()
        {
            grid1.Cell(0, 1).Text = "Activity";
            grid1.Cell(0, 2).Text = "Operator Type";
            grid1.Column(1).Width = 200;
            grid1.Column(2).Width = 200;
            grid1.Column(2).CellType = FlexCell.CellTypeEnum.ComboBox;
        }
        void filloperator(string act,int j)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select o.shortDesc   from tActivity  A left join tOperatorType  o on  A.operatorTypeId =o.operatorid where A.ActivityName =@act";
            sda.SelectCommand.Parameters.AddWithValue("@act", act);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.Cell(j, 2).Text = ds.Tables[0].Rows[0][0].ToString();
            con.Close();
        }
        
        void fillActivity()
        { 
            string st = cmbstylecode.SelectedValue.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.ActivityName ,A.ActivityCode  from tStyleActivities SA left join tActivity A on A.ActivityCode =SA.ActivityCode  where StyleCode=@sc ";
            sda.SelectCommand.Parameters.AddWithValue("@sc", st);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count-1; i++)
            {
                grid1.Rows = grid1.Rows + 1;
                j = i + 1;
                grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["ActivityName"].ToString();
                filloperator(ds.Tables[0].Rows[i]["ActivityName"].ToString(),j);
                grid1.Cell(j, 1).Locked = true;

            }
            
        }
        void fillstylecode()
        {
            flag = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct stylecode  from tstylemaster order by stylecode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbstylecode.DataSource = ds.Tables[0];
            cmbstylecode.DisplayMember = "Stylecode";
            cmbstylecode.ValueMember = "Stylecode";
            con.Close();
            flag = 0;
        }
        void LoadOperator()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select operatorid ,shortDesc from tOperatorType";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(2).DataSource = ds.Tables[0];
            grid1.ComboBox(2).ValueMember = "operatorid";
            grid1.ComboBox(2).DisplayMember = "shortDesc";

        }

        private void cmbstylecode_ValueMemberChanged(object sender, EventArgs e)
        {
            grid1.Rows = 1;
            fillActivity();
        }

        private void grid1_Click(object Sender, EventArgs e)
        {
            if (grid1.ActiveCell.Col == 2)
            {
                grid1.Cell(grid1.ActiveCell.Row, 2).SetFocus();
            }
        }

        void updateActivity(int j)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tActivity set operatorTypeId=@opid where ActivityName=@act";
            cmd.Parameters.AddWithValue("@act", grid1.Cell(j, 1).Text.ToString());
            cmd.Parameters.AddWithValue("@opid", grid1.ComboBox(2).GetItemValue(grid1.Cell(j, 2).Text).ToString());
            cmd.ExecuteNonQuery();
           
            con.Close();
        }
        
        
        private void btsave_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i < grid1.Rows - 1; i++)
            {
                string s = (grid1.Rows - 1).ToString();
                j = i + 1;
                updateActivity(j);

            }
            MessageBox.Show(" Updated Successfully");
        }

        private void grid1_Load(object sender, EventArgs e)
        {

        }

        private void cmbstylecode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                grid1.Rows = 1;
                fillActivity();
            
            }
        }

       

        
    }
}
