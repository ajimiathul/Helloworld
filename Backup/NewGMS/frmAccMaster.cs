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
    public partial class frmAccMaster : Form
    {
        bool flagAccNature = false;

        public frmAccMaster()
        {
            InitializeComponent();
        }

        private void frmAccMaster_Load(object sender, EventArgs e)
        {

            LoadAccNature();
            flagAccNature = true;
            LoadAccUnder();
            treeViewDisplay();
        }

        private void LoadAccNature()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select AccCode,AccName  from tAccountMaster where Levelno = 1 order by rowindex";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbAccNature.DataSource = ds.Tables[0];
            cmbAccNature.DisplayMember = "Accname";
            cmbAccNature.ValueMember = "accCode";
        }

        private void LoadAccUnder()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string str1 = " select AccCode,AccName   from tAccountMaster where GrpOrAcc ='G' and AccCat in ";
            string str2 = " (select acccat   from tAccountMaster where acccode = @gno )  order by Rowindex ";
            sda.SelectCommand.CommandText = str1 + str2;
            sda.SelectCommand.Parameters.AddWithValue("@gno", Convert.ToInt32(cmbAccNature.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUnder .DataSource = ds.Tables[0];
            cmbUnder .DisplayMember = "Accname";
            cmbUnder .ValueMember = "accCode";        
        }

        private void cmbAccNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagAccNature == true)
            {
                LoadAccUnder();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccName.Text.Trim() != "")
            {
                if (DupCheck() == false)
                {
                    if (EntryCheck() == false)
                    {
                        if (CheckLevelExeed() == false)
                        {
                            SaveMethod();
                            treeViewDisplay();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Account Name Not Entered");
                txtAccName.Clear();
            }
        }
        private bool DupCheck()
        {
            bool dup=false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select AccCode from tAccountMaster where SupCusEmpOth='OTH' and AccName=@acname";
            sda.SelectCommand.Parameters.AddWithValue("@acname", txtAccName.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dup = true;
                MessageBox.Show("Data Already Exist");
            }
            return dup;
        }
        private bool EntryCheck()
        {
            bool nonEntry = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select nonEntry from tAccountMaster where AccCode=@ac";
            sda.SelectCommand.Parameters.AddWithValue("@ac",Convert.ToInt32(cmbUnder.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows[0]["nonEntry"].ToString() == "Y")
            {
                nonEntry = true;
                MessageBox.Show("Blocked");
            }
            return nonEntry;
        }
        private bool CheckLevelExeed()
        {
            bool LevelExeed=false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Levelno from tAccountMaster where AccCode=@ac";
            sda.SelectCommand.Parameters.AddWithValue("@ac",Convert.ToInt32 (cmbUnder.SelectedValue ));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Levelno"]) == 4 && rbAccnt.Checked == false)
            {
                LevelExeed = true;
                MessageBox.Show("Entry Level Exceed");
            }
            return LevelExeed;
        }

        private void SaveMethod()
        {
            string GA = "G";
            if (rbAccnt.Checked == true)
            {
                GA = "A";
            }
            decimal OPB = Convert.ToDecimal(txtOpBal.Text);
            if (rbCredit .Checked == true)
            {
                OPB = OPB * (-1);
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "CreateAccount";
            scmd.CommandType = CommandType.StoredProcedure;
            int x = Convert.ToInt32 (cmbUnder.SelectedValue );
            scmd.Parameters.AddWithValue("@acnUnder", x );
            scmd.Parameters.AddWithValue("@acname", txtAccName.Text );
            scmd.Parameters.AddWithValue("@GAflag", GA );
            scmd.Parameters.AddWithValue("@sceoflag","OTH");
            scmd.Parameters.AddWithValue("@opbal",OPB  );
            scmd.Parameters.AddWithValue("@scr", "AccMaster");
            scmd.Parameters.AddWithValue("@sceono",0 );
            scmd.Parameters.AddWithValue("@db", 0);
            scmd.Parameters.AddWithValue("@cr", 0);
            scmd.Parameters.AddWithValue("@bal", 0);
            scmd.Parameters.AddWithValue("@nonentry", "N");
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void rbGrp_CheckedChanged(object sender, EventArgs e)
        {
            OpBalEnable();
        }

        private void rbAccnt_CheckedChanged(object sender, EventArgs e)
        {
            OpBalEnable();
        }

        private void OpBalEnable()
        {
            if (rbAccnt.Checked == true)
            {
                txtOpBal.Enabled = true;
            }
            else
            {
                txtOpBal.Enabled = false;
                txtOpBal.Text = "0.0";
            }
        }
        private void treeViewDisplay()
        {
            treeView1.Nodes.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select AccName,Levelno  from tAccountMaster order by Rowindex";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int v = -1, w = -1, x = -1, y = -1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if ((int)ds.Tables[0].Rows[i]["Levelno"] == 1)
                {

                    TreeNode parent = new TreeNode(ds.Tables[0].Rows[i]["AccName"].ToString());
                    treeView1.Nodes.Add(parent);
                    v++;
                    w = -1;
                }
                else if ((int)ds.Tables[0].Rows[i]["Levelno"] == 2)
                {
                    
                    TreeNode child = new TreeNode(ds.Tables[0].Rows[i]["AccName"].ToString());
                    treeView1.Nodes[v].Nodes.Add(child);
                   w++;
                   x = -1;
                }
                else if ((int)ds.Tables[0].Rows[i]["Levelno"] == 3)
                {
                    TreeNode child = new TreeNode(ds.Tables[0].Rows[i]["AccName"].ToString());
                    treeView1.Nodes[v].Nodes[w].Nodes.Add(child);
                    x++;
                    y = -1;
                }
                else if ((int)ds.Tables[0].Rows[i]["Levelno"] == 4)
                {
                    TreeNode child = new TreeNode(ds.Tables[0].Rows[i]["AccName"].ToString());
                    treeView1.Nodes[v].Nodes[w].Nodes[x].Nodes.Add(child);
                    y++;
                }
                else if ((int)ds.Tables[0].Rows[i]["Levelno"] == 5)
                {
                    TreeNode child = new TreeNode(ds.Tables[0].Rows[i]["AccName"].ToString());
                    treeView1.Nodes[v].Nodes[w].Nodes[x].Nodes[y].Nodes.Add(child);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeViewDisplay();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {            
           
            string s=treeView1.SelectedNode.ToString().Substring(9).Trim();
            //if(s=="Asset" || s=="Liability" || s==) 
            txtAccName.Text = s;
        }

        private void txtOpBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtOpBal.Text);
        }
        private char OnlyDecimalNum(char c, string s)
        {
            if (c == '.')
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '.')
                    {
                        c = Convert.ToChar(Keys.None);
                    }
                }
            }
            else if (c == (char)8)
            {
            }
            else if (char.IsDigit(c) == false)
            {
                c = Convert.ToChar(Keys.None);
            }
            return c;
        }
    }
}
