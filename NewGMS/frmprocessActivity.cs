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
    public partial class frmprocessActivity : Form
    {
        public frmprocessActivity()
        {
            InitializeComponent();
        }
        int flag = 0;
        void fillstylecode()
             
        {
            flag = 0;
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
            flag = 1;
        }

        int getprocessid(string proc)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText ="Select processid from tprocess where process=@Pr";
            sda.SelectCommand .Parameters .AddWithValue("@pr",proc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int pid=Convert.ToInt32(ds.Tables[0].Rows[0]["processid"].ToString());
            con.Close();
           return(pid);
        }


        Boolean exitdata(int pid)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd  = new SqlCommand("", con);
           cmd.CommandText = "select COUNT(*)  cnt from tProcessEqtAct where stylecode =@stcode and processid =@id";
            cmd.Parameters.AddWithValue("@stcode", cmbstylecode.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@id", pid);

            int i = Convert.ToInt32 ( cmd.ExecuteScalar());
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

        void saveProcessAct()
        {   
            string st = cmbstylecode.SelectedValue.ToString(); 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            int loop=1;

            for(int i=0;i<grid1.Rows-1;i++)
            {
                cmd.Parameters.Clear();
                loop = i + 1;
              string strr=grid1.Cell(loop,1).Text.ToString();  
              int prid=getprocessid(strr);

              if (exitdata(prid) == true)
              {
                  cmd.CommandText = "UPDATE tProcessEqtAct   SET EqtActCode = @acc  WHERE  processid =@ppid and stylecode =@scode";
                  cmd.Parameters.AddWithValue("@acc", Convert.ToInt32(grid1.ComboBox(2).GetItemValue(grid1.Cell(loop, 2).Text).ToString()));
                  cmd.Parameters.AddWithValue("@scode", st);
                  cmd.Parameters.AddWithValue("@ppid", prid);
                  cmd.ExecuteNonQuery();
              }
              else
              {                  
                  cmd.CommandText = "INSERT INTO [newgms].[dbo].[tProcessEqtAct] ([stylecode],[processid],[EqtActCode])VALUES(@sc1,@procid,@actcode)";
                  cmd.Parameters.AddWithValue("@sc1", st);
                  cmd.Parameters.AddWithValue("@procid", prid);
                  cmd.Parameters.AddWithValue("@actcode", Convert.ToInt32(grid1.ComboBox(2).GetItemValue(grid1.Cell(loop, 2).Text).ToString()));
                  cmd.ExecuteNonQuery();
              }
              }
           
            
            con.Close();
            MessageBox.Show("Sucess");
        }
        private void btsave_Click(object sender, EventArgs e)
        {

            saveProcessAct();
                 
            

        }
       
        private void frmprocessActivity_Load(object sender, EventArgs e)
        {
            flag = 0;
            naminggrid();
            fillstylecode();  
            fillprocess();
            //for (int i = 0; i < grid1.Rows - 1; i++)
            //{
            //    grid1.Cell(i + 1, 2).Text = "NA";
            //}
            flag =1;
        }


        void fillActivity()
        {
            string st = cmbstylecode.Text; 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select  ActivityName, ActivityCode from tActivity where ActivityCode in (select ActivityCode  from tStyleActivities where StyleCode = @style ) union  select 'NA' ActivityName, 0 ActivityCode  ";
            sda.SelectCommand.Parameters.AddWithValue("@style", st.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(2).DataSource = ds.Tables[0];
            grid1.ComboBox(2).DisplayMember = "ActivityName";
            grid1.ComboBox(2).ValueMember = "ActivityCode";           
        }
        
        void fillprocess()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select process  from tprocess order by process";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grid1.Rows = grid1.Rows + 1;
                j = i + 1;
                grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["process"].ToString();
                grid1.Cell(j, 1).Locked = true;

                }

        }
        void naminggrid()
        {
            grid1.Cell(0, 1).Text = "Process";
            grid1.Cell(0, 2).Text = "Activity";
            grid1.Cell(0, 3).Text = "Default Values";
            grid1.Column(2).Width =200;
            grid1.Column(1).Width = 150;
            grid1.Column(3).Width = 150;
            grid1.Column(3).Locked = true;
            grid1.Column(2).CellType = FlexCell.CellTypeEnum.ComboBox;
        }

        private void FgridprocAct_Click(object Sender, EventArgs e)
        {
            if (grid1.ActiveCell.Col == 2)
            {
               grid1.Cell(grid1.ActiveCell.Row, 2).SetFocus();
            }
        }

        

        //private void cmbstylecode_ValueMemberChanged(object sender, EventArgs e)
        //{

        //    //if (flag == 1)
        //    //{
        //        //grid1.Rows = 1;
        //        fillActivity();
        //        Check();

        //    //}
        
        //}

        private void cmbstylecode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
            // grid1.Rows = 1;
            fillActivity();
             Check();

            }
                     
        }

      
        void Check()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select COUNT (*) from tProcessEqtAct where stylecode=@style";
            sda.SelectCommand.Parameters.AddWithValue("@style", cmbstylecode.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
             int count= Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

             if (count > 0)
             {
                 grid1.Rows = 1;
                 fillSytledetail();

             }
             else
             {
                 FillDetails();
                              
             }
             for (int m = 1; m < grid1.Rows; m++)
             {
                 if (grid1.Cell(m, 2).Text.Trim().Length == 0)
                 {
                     grid1.Cell(m, 2).Text = "NA";
                 }
                 if (grid1.Cell(m, 3).Text.Trim().Length == 0)
                 {
                     grid1.Cell(m, 3).Text = "NA";
                 }
             }
        

        }
        void fillSytledetail()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = "select  b.process,a.ActivityName,b.ActivityName as DefaultValues from";
            string s2 = " (select B.process,C.ActivityName  from tProcess B  left join   tProcessEqtAct A on A.processid= B.processid ";
            string s3 = "  left join tActivity C on C.ActivityCode= A.EqtActCode where  A.stylecode=@style) a full join ";
            string s4 = " (select C.process , B.ActivityName from tProcessEqtSubCat A join tProcess  C on C.processid = A.processid left join tActivity  B";
            string s5 = " on B.ActivityCode= A.EqtActCode  where A.SubcatCode=(select  D.SubCategoryId   from tStyleMaster D where D.StyleCode= @style)) b on a.process = b.process ";

            sda.SelectCommand.CommandText = s1+s2+s3+s4+s5;
            sda.SelectCommand.Parameters.AddWithValue("@style", cmbstylecode.Text.Trim ());
            DataSet ds = new DataSet();
            sda.Fill(ds);
             for (int i =0; i< ds.Tables[0].Rows.Count;i++)
             {
                 grid1.Rows= grid1.Rows+1;
                 int j = i+1;
                 grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["process"].ToString();
                 grid1.Cell(j, 2).Text = ds.Tables[0].Rows[i]["ActivityName"].ToString();
                 grid1.Cell(j, 3).Text = ds.Tables[0].Rows[i]["DefaultValues"].ToString();
             
             }            
        
        }
        void FillDetails()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = " select C.process , B.ActivityName from tProcessEqtSubCat A join tProcess  C on C.processid = A.processid  join tActivity  B ";
            string s2 = " on B.ActivityCode= A.EqtActCode  where A.SubcatCode=(select  D.SubCategoryId   from tStyleMaster D where D.StyleCode= @style) ";
            sda.SelectCommand.CommandText = s1 + s2;
            sda.SelectCommand.Parameters.AddWithValue("@style", cmbstylecode.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grid1.Rows = grid1.Rows + 1;
                int j = i + 1;
                grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["process"].ToString();
                grid1.Cell(j, 2).Text = ds.Tables[0].Rows[i]["ActivityName"].ToString();
                grid1.Cell(j, 3).Text = ds.Tables[0].Rows[i]["ActivityName"].ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
      
    }
}
