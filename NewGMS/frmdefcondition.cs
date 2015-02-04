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
    public partial class frmdefcondition : Form
    {
        public frmdefcondition()
        {
            InitializeComponent();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            
            DeleteConditionsTemp();
            SaveConditionTemp();
            this.Close();
          
        }

        private void frmdefcondition_Load(object sender, EventArgs e)
        {
            gridDefCondSelectionsSettings();
            FillGridDetails();

        }
        private void gridDefCondSelectionsSettings()
        {
            flexGridDefCon.Column(1).CellType = FlexCell.CellTypeEnum.CheckBox;
            flexGridDefCon.Cell(0, 2).Text = "Conditions";
          
            flexGridDefCon.Column(1).Width = 40;
            flexGridDefCon.Column(2).Width = 700;
            flexGridDefCon.Column(2).Locked = true;
           
        }
        private void FillGridDetails()
        {
            flexGridDefCon.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select CONDITIONS from tdefPOcondition";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Int32 x = 0;
            for (int y = 0; y < ds.Tables[0].Rows.Count; y++)
            {
                x = y + 1;
                flexGridDefCon.Rows = flexGridDefCon.Rows + 1;
                flexGridDefCon.Cell(x, 2).Text = ds.Tables[0].Rows[y]["CONDITIONS"].ToString();
            }
        }
        private void DeleteConditionsTemp()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete  from tdefPoCondTemp"; 
           
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void SaveConditionTemp()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tdefPoCondTemp values(@conditions)";
            for (int i = 1; i < flexGridDefCon.Rows; i++)
            {
                if (flexGridDefCon.Cell(i, 1).Text == "1")
                {
                    cmd.Parameters.AddWithValue("@conditions", flexGridDefCon.Cell(i,2).Text);
                   
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
