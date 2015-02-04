using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;
using  System.Data.SqlClient;


namespace NewGMS
{
    public partial class frmCustExcecutive : Form
    {
        public frmCustExcecutive()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim()=="" || txtaddrs.Text.Trim()=="")               
            {
                MessageBox.Show("Invalid Entry");
                if (txtname.Text.Trim() == "")
                {
                    txtname.Focus();
                }
                else if (txtaddrs.Text.Trim() == "")
                {
                    txtaddrs.Focus();
                }
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = " insert into tCustExcecutive (name, address)values (@name, @address)";
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddrs.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved Sucessfully");
                this.Hide();
                frmFinishedProductsOutward obj = new frmFinishedProductsOutward();
            }            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
