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
    public partial class frmBankReconsolation : Form
    {
        string cleared = "A";
        int nofDays = -365;
        public frmBankReconsolation()
        {
            InitializeComponent();
        }

       
        private void frmBankReconsolation_Load(object sender, EventArgs e)
        {
            InsertCombo();
            cleared = "A";
            nofDays = -365;
        }

        private void InsertCombo()
        {

            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select AccName, AccCode from tAccountMaster where Groupno=@Groupno";
                sda.SelectCommand.Parameters.AddWithValue("@Groupno", "5");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    cmbBankAccont.DataSource = ds.Tables[0];
                    cmbBankAccont.DisplayMember = "AccName";
                    cmbBankAccont.ValueMember = "AccCode";
                }
                 
            }


        }

        private void FillAccounts()
        {

            lvBankReconsltn.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select recid,voucherdate,voucherno,chequeno,chequedate,cleareddate,Cleared,db, cr from tLedgerDTL where acccode= @acno and cleared != @cl and dateadd(d,@rbdt,chequedate) <= @dtpvalue";
            sda.SelectCommand.Parameters.AddWithValue("@acno",(cmbBankAccont.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@cl",cleared);
            sda.SelectCommand.Parameters.AddWithValue("@rbdt",nofDays );
            sda.SelectCommand.Parameters.AddWithValue("@dtpvalue", Convert.ToDateTime (dtpDate.Value.ToShortDateString()));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvBankReconsltn.Items.Add(ds.Tables[0].Rows[i]["recid"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["voucherdate"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["voucherno"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["chequeno"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["chequedate"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cleareddate"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Cleared"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["db"].ToString());
                lvBankReconsltn.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cr"].ToString());

                if (ds.Tables[0].Rows[i]["Cleared"].ToString() == "Y")
                {
                    lvBankReconsltn.Items[i].Checked = true;
                }
            }

        }

        private void cmbBankAccont_DropDownClosed(object sender, EventArgs e)
        {
            FillAccounts();
            rbtdal.Checked = true;
            rbSuc.Checked = true;


        }

       
        private void lvBankReconsltn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                lvBankReconsltn.Items[e.Index].SubItems[5].Text = dtpclear.Value.ToShortDateString();
                lvBankReconsltn.Items[e.Index].SubItems[6].Text = "Yes";
              
            }
            else
            {
                lvBankReconsltn.Items[e.Index].SubItems[5].Text = "";
                lvBankReconsltn.Items[e.Index].SubItems[6].Text = "N";

                            
            }
        }

        private void rbt60_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt60.Checked == true)
            {
                nofDays = -60;
                FillAccounts();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           
        }

        private void SaveItems()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
           // SqlDataAdapter sda = new SqlDataAdapter("", con);
            //DataSet ds = new DataSet();
           // sda.Fill(ds);
            for (int i = 0; i < lvBankReconsltn.Items.Count; i++)
            {
                cmd.CommandText = "update tLedgerDTL set ClearedDate=@dtpvalue, Cleared=@Cleared where recid=@recid";
                if (lvBankReconsltn.Items[i].Checked == true)
                {

                    cmd.Parameters.AddWithValue("@dtpvalue",dtpDate.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@recid", Convert.ToInt32(lvBankReconsltn.Items[i].Text));
                    cmd.Parameters.AddWithValue("@Cleared", "Y");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@recid", Convert.ToInt32(lvBankReconsltn.Items[i].Text));
                    cmd.Parameters.AddWithValue("@Cleared", "N");
                    cmd.Parameters.AddWithValue("@dtpvalue", DBNull.Value);
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }


            con.Close();
           
        }

        
        private void cmbBankAccont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbt120_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt120.Checked == true)
            {
                nofDays = -120;
                FillAccounts();

            }
        }

        private void rbtdal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtdal.Checked == true)
            {
                nofDays = -365;
                FillAccounts();

            }
        }

        private void rbSc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSc.Checked == true)
            {
                cleared = "N";
                FillAccounts();

            }
        }

        private void rbSuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSuc.Checked == true)
            {
                cleared = "Y";
                FillAccounts();
            
            }
        }

        private void rbsA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbsA.Checked == true)
            {
                cleared = "A";
                FillAccounts();

            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {

            SaveItems();
            MessageBox.Show("Saved Sucessfully");

        }

       
    }
}
