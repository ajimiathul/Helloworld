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
    public partial class frmPIAddnChargesEntry : Form
    {
        public frmPIAddnChargesEntry()
        {
            InitializeComponent();
        }
        int cod = -1;
        private void SaveProcess()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "InsPIAddnCharges";
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desc",txtDescription.Text);
            cmd.Parameters.AddWithValue("@scn","PIAddnChargesEntry");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdateProcess()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPerformaAddnCharges set description=@desc where code=@cod";
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
            cmd.Parameters.AddWithValue("@cod", cod);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Trim().Length != 0)
            {
                if (btnSave.Text == "Save")
                {
                    SaveProcess();
                }
                else
                {
                    UpdateProcess();
                }
            }
            FillGridDetails();
            //this.Parent.Refresh();
            //this.Hide();
            //frmPerformaInvoiceRequest obj = new frmPerformaInvoiceRequest();
        }

        private void FillGridDetails()
        {
            dgvDescription.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select code,description from tPerformaAddnCharges order by code";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int y = 0; y < ds.Tables[0].Rows.Count; y++)
            {
                dgvDescription.Rows.Add(1);
                int k = dgvDescription.Rows.Count;
                dgvDescription.Rows[k - 1].Cells["ColCode"].Value = ds.Tables[0].Rows[y]["code"].ToString();
                dgvDescription.Rows[k - 1].Cells["ColDesc"].Value = ds.Tables[0].Rows[y]["description"].ToString();
            }
        }

        private void frmPIAddnChargesEntry_Load(object sender, EventArgs e)
        {
            FillGridDetails();
        }

        private void dgvDescription_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnSave.Text = "Update";
                txtDescription.Text = dgvDescription.Rows[e.RowIndex].Cells["ColDesc"].Value.ToString();
                cod = Convert.ToInt32(dgvDescription.Rows[e.RowIndex].Cells["ColCode"].Value);
            }
        }
        private void DeleteProcess()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete from tPerformaAddnCharges where code=@cod";
            cmd.Parameters.AddWithValue("@cod", cod);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProcess();
            FillGridDetails();
            txtDescription.Clear();
            btnSave.Text = "Save";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDescription.Clear();
            btnSave.Text = "Save";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPIAddnChargesEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
        }        
    }
}
