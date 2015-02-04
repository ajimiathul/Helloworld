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
    public partial class EmpOperator : Form
    {
        public EmpOperator()
        {
            InitializeComponent();
        }
        string newedit = "New";
        int opcod = 0;

        private void LoadOrderNo()
        {
            for (int i = 1; i <= 100; i++)
            {
                cmborder.Items.Add(i.ToString());
            }
        }
        
        private void EmpOperator_Load(object sender, EventArgs e)
        {
            LoadOrderNo();
            gbmodeoperator.Text = "New";
            ViewInGrid();
            newedit = "New";

        }

        void clear()
        {
            txtshdesc.Text = "";
            txtoperator.Text = "";
            cmborder.Text = "";
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (newedit == "New")
            {
                if (DuplicateInsertChk() == false)
                {
                    Insertoperator();
                    clear();
                }
                else
                {
                    MessageBox.Show("Already exists");
                }
            }
            else
            {
                if (DuplicateUpdateChk() == false)
                {
                    UpdateDep();
                }
                else
                {
                    MessageBox.Show("Already exists for another Operator Code");
                }
            }
            label1.Text = opcod.ToString();
            ViewInGrid();
        }


        private void ViewInGrid()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "";
            cmdstr = "select operatorid,operator,shortDesc,OrderNo from tOperatorType where operatorid <> 0 order by operatorid desc";
            sda.SelectCommand.CommandText = cmdstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvOpeartor.DataSource = ds.Tables[0];
        }

        private void UpdateDep()
        {
            if (opcod!= 0)
            {
                if (cmborder.Text != null)
                {
                    if (cmborder.Text.Trim().Length != 0)
                    {

                        SqlConnection sc = new SqlConnection();
                        sc.ConnectionString = clsDbForReports.constr;
                        sc.Open();
                        SqlCommand scmd = new SqlCommand("", sc);
                        scmd.CommandText = "update tOperatorType  set operator=@op,shortDesc=@shop,OrderNo=@ord where operatorid=@dcode";
                        scmd.Parameters.AddWithValue("@op", txtoperator.Text);
                        scmd.Parameters.AddWithValue("@shop", txtshdesc.Text);
                        scmd.Parameters.AddWithValue("@ord", Convert.ToInt32(cmborder.Text));
                        scmd.Parameters.AddWithValue("@dcode",opcod);
                        int i = scmd.ExecuteNonQuery();
                        sc.Close();

                    }
                    else
                    {
                        MessageBox.Show("Select order");
                    }
                }
                else
                {
                    MessageBox.Show("Select order");
                }


            }
        }

        private bool DuplicateInsertChk()
        {
            bool ret = false;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select operatorid  from tOperatorType where operator=@operator";
            sda.SelectCommand.Parameters.AddWithValue("@operator", txtoperator.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }


        private bool DuplicateUpdateChk()
        {
            bool ret = false;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select operatorid  from tOperatorType where  operatorid!=@opcod and operator=@oper";
            sda.SelectCommand.Parameters.AddWithValue("@opcod", opcod);
            sda.SelectCommand.Parameters.AddWithValue("@oper", txtoperator.Text.Trim());

            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }
        
        private void Insertoperator()
        {
            if (cmborder.Text != null)
            {
                if (cmborder.Text.Trim().Length != 0)
                {
                    opcod = ReadLastNum();
                    SqlConnection sc = new SqlConnection();
                    sc.ConnectionString = clsDbForReports.constr;
                    sc.Open();
                    SqlCommand scmd = new SqlCommand("", sc);
                    scmd.CommandText = "insert tOperatorType(operatorid,operator,shortDesc,OrderNo) Values(@opid,@operator,@shdes,@ord)";
                    scmd.Parameters.AddWithValue("@opid", opcod );
                    scmd.Parameters.AddWithValue("@operator", txtoperator.Text);
                    scmd.Parameters.AddWithValue("@shdes", txtshdesc.Text);
                    scmd.Parameters.AddWithValue("@ord", Convert.ToInt32(cmborder.Text));
                    int i = scmd.ExecuteNonQuery();
                    sc.Close();
                }
                else
                {
                    MessageBox.Show("Select order");
                }
            }
            else
            {
                MessageBox.Show("Select order");
            }
        }
        private int ReadLastNum()
        {
            UpdateLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "select lastnum from tNumbers where screen=@scr";
            scmd.Parameters.AddWithValue("@scr","OperatorType");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }
        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "OperatorType");
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            newedit = "Edit";
            gbmodeoperator.Text = "Edit Mode";
            opcod = 0;
            label1.Text = opcod.ToString();
        }

        private void btnew_Click(object sender, EventArgs e)
        {
            newedit = "New";
            gbmodeoperator.Text = "New Mode";
            opcod  = 0;
            label1.Text = opcod.ToString();
            clear();
        }

        private void LoadStockDetails(int opcod)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select operatorid ,operator,shortDesc,OrderNo from tOperatorType where  operatorid=@opcod";
            sda.SelectCommand.Parameters.AddWithValue("@opcod", opcod);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmborder.SelectedValue = ds.Tables[0].Rows[0]["OrderNo"].ToString();
            txtoperator.Text = ds.Tables[0].Rows[0]["operator"].ToString();
            txtshdesc.Text = ds.Tables[0].Rows[0]["shortDesc"].ToString();
            label1.Text = opcod.ToString();
            sc.Close();
        }

       
        private void dgvOpeartor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newedit == "Edit")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    opcod = Convert.ToInt32(dgvOpeartor.Rows[x].Cells[0].Value.ToString());
                    LoadStockDetails(opcod);
                }
            }
            else
            {
                MessageBox.Show("Not in Edit Mode");
            }

        }

        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       void  ViewInGridsort()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "";
            cmdstr = "select operatorid,operator,shortDesc,OrderNo from tOperatorType where operatorid <> 0 order by orderno ";
            sda.SelectCommand.CommandText = cmdstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvOpeartor.DataSource = ds.Tables[0];
            sc.Close();

        }
        private void btSORT_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
         
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand cmd = new SqlCommand("", sc);
            cmd.CommandText = "update tOperatorType set OrderNo = x.sno  from tOperatorType A,(select DENSE_RANK() over(order by orderno) sno,operatorid,OrderNo from tOperatorType) x where A.operatorid = x.operatorid ";
            cmd.ExecuteNonQuery();
            sc.Close();
            ViewInGridsort();




        }





        }

    }

