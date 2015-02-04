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
    public partial class frmLeaveDtlFilling : Form
    {
        public frmLeaveDtlFilling()
        {
            InitializeComponent();
        }
        private void InsDate()
        {
            DateTime dt;
            decimal half=0.0M;
            SqlConnection conS = new SqlConnection(clsDbForReports.constr);
            SqlDataAdapter sda = new SqlDataAdapter("", conS);
            sda.SelectCommand.CommandText = "select hdrRecid,empid,dtfrom,dtTo,hf from tLeaveHdr order by dtfrom,empid";
            DataSet ds = new DataSet();
            sda.Fill(ds); 
            SqlConnection conI = new SqlConnection(clsDbForReports.constr);
            conI.Open();
            SqlCommand cmd = new SqlCommand("", conI);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["dtfrom"]);
                for (int j = 0; dt <= Convert.ToDateTime(ds.Tables[0].Rows[i]["dtTo"]); j++)
                {
                    if (dt.DayOfWeek.ToString() != "Sunday")
                    {
                        cmd.CommandText = "insert into tleavedtl (hdrRecid,empid,LeaveDate,HF,AHF) values(@hdrRecid,@empid,@LeaveDate,@HF,@HF)";
                        cmd.Parameters.AddWithValue("@hdrRecid", Convert.ToInt32(ds.Tables[0].Rows[i]["hdrRecid"]));
                        cmd.Parameters.AddWithValue("@empid", Convert.ToInt32(ds.Tables[0].Rows[i]["empid"]));
                        cmd.Parameters.AddWithValue("@LeaveDate", dt);
                        if (ds.Tables[0].Rows[i]["hf"].ToString() == "Y")
                        {
                            half = 0.5M;
                        }
                        else
                        {
                            half = 1.0M;
                        }
                        cmd.Parameters.AddWithValue("@HF", half);
                        cmd.Parameters.AddWithValue("@AHF", half);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    dt = dt.AddDays(1);
                }
            }
            conI.Close();
        }

        private void NewRecId()
        {
            SqlConnection conS = new SqlConnection(clsDbForReports.constr);
            SqlDataAdapter sda = new SqlDataAdapter("", conS);
            sda.SelectCommand.CommandText = "select hdrRecid,empid,dtfrom,dtTo,hf from tLeaveHdr order by dtfrom,empid";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            SqlConnection conU = new SqlConnection(clsDbForReports.constr);
            conU.Open();
            SqlCommand cmd = new SqlCommand("", conU);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cmd.CommandText = "update tLeaveHdr set hdrRecid=@rec where empid=@em and dtfrom=@dt";
                cmd.Parameters.AddWithValue("@rec", i + 1);
                cmd.Parameters.AddWithValue("@em", ds.Tables[0].Rows[i]["empid"].ToString());
                cmd.Parameters.AddWithValue("@dt",Convert.ToDateTime(ds.Tables[0].Rows[i]["dtfrom"]));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            conU.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewRecId();
            InsDate();
        }       
    }
}
