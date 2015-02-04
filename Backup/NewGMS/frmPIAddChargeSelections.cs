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
    public partial class frmPIAddChargeSelections : Form
    {
        public frmPIAddChargeSelections()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPIAddChargeSelections_Load(object sender, EventArgs e)
        {
            txtReqSubno.Text = clsDbForReports.PIReqSubno;
            txtSupplier.Text = clsDbForReports.PIRSupplier;          
            gridPISelectionsSettings();
            FillGridDetails();
        }

        private void FillGridDetails()
        {
            gridPISelections.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select code,description from tPerformaAddnCharges order by code";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Int32 x = 0;
            for (int y = 0; y < ds.Tables[0].Rows.Count; y++)
            {
                x=y+1;
                gridPISelections.Rows = gridPISelections.Rows + 1;
                gridPISelections.Cell(x,3).Text   = ds.Tables[0].Rows[y]["code"].ToString();
                gridPISelections.Cell(x, 2).Text  = ds.Tables[0].Rows[y]["description"].ToString();
            }
        }

        private void SaveAChargeDesc()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tPIAddnChargesTemp(code,chrgDesc,reqsubno,supcode) values (@code,@chrgDesc,@reqsubno,@supcode)";          
            for (int i = 1; i < gridPISelections.Rows; i++)
            {
                if (gridPISelections.Cell(i, 1).Text == "1")
                {
                    cmd.Parameters.AddWithValue("@code", Convert.ToInt32(gridPISelections.Cell(i, 3).Text));
                    cmd.Parameters.AddWithValue("@chrgDesc", gridPISelections.Cell(i, 2).Text);
                    cmd.Parameters.AddWithValue("@reqsubno", txtReqSubno.Text);
                    cmd.Parameters.AddWithValue("@supcode", clsDbForReports.PIRSupplierCode);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }

        private void gridPISelectionsSettings()
        {
            gridPISelections.Column(1).CellType = FlexCell.CellTypeEnum.CheckBox;
            gridPISelections.Cell(0, 2).Text = "Material";
            gridPISelections.Cell(0, 3).Text = "code";
            gridPISelections.Column(1).Width = 40;
            gridPISelections.Column(2).Width = 700;
            gridPISelections.Column(3).Width = 0;
            gridPISelections.Column(2).Locked = true;
            gridPISelections.Column(3).Locked = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DeleteACharges();
            SaveAChargeDesc();
            this.Close();
        }

        private void DeleteACharges()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete tPIAddnChargesTemp where reqsubno=@reqsubno and supcode=@supcode";
            cmd.Parameters.AddWithValue("@reqsubno", txtReqSubno.Text);
            cmd.Parameters.AddWithValue("@supcode", clsDbForReports.PIRSupplierCode);
            cmd.ExecuteNonQuery();                       
            con.Close();
        }

    }
}
