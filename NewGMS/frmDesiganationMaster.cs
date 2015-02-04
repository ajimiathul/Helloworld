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
    public partial class frmDesiganationMaster : Form
    {
        public frmDesiganationMaster()
        {
            InitializeComponent();
        }
        void FlexNamings()
        {

            grid1.Cell(0, 1).Text = "EmpId";
            grid1.Cell(0, 2).Text = "Employee";
            grid1.Cell(0, 3).Text = "Designation";
            grid1.Cell(0, 4).Text = "Operator";
            grid1.Cell(0, 5).Text = "Type";
            grid1.Cell(0, 6).Text = "P/T";
            grid1.Cell(0, 7).Text = "Need Machine";
            //grid1.Cell(0, 8).Text = "Floor";

            grid1.Column(1).Width = 50;
            grid1.Column(2).Width = 150;
            grid1.Column(3).Width = 150;
            grid1.Column(4).Width = 150;
            grid1.Column(5).Width = 150;
            grid1.Column(6).Width = 150;
            grid1.Column(7).Width = 100;
            //grid1.Column(8).Width = 120;



            grid1.Column(1).Locked = true;
            grid1.Column(2).Locked = true;

            grid1.Column(3).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(4).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(5).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(6).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(7).CellType = FlexCell.CellTypeEnum.CheckBox;
            //grid1.Column(8).CellType = FlexCell.CellTypeEnum.ComboBox;
           
        }
        void LoadEmpdetails()
        { 
           SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = " select   e.EmpId,e.EmployeeName,d.Designation ,ot.shortDesc,st.SalType, t.Empstatus, Status= case NeedMachine  when 'Yes' then '1' else '0'  end from Employee e ";
            string s2 = " left join designation d on d.DesignationId=e.desigcode";
            string s3 = " left join  tOperatorType ot on ot.operatorid= e.Operatorid";
            string s4 = " left join TEmpstatus t on t.Id= e.Statusid ";
            string s5 = " left join SalType st on st.SalTypeCode= e.SalTypeCode  where e.ActiveOrResigned ='A'";
            sda.SelectCommand.CommandText = s1 + s2 + s3 + s4 + s5;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j=0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
            {
                grid1.Rows = grid1.Rows + 1;
                j = i + 1;
                grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["EmpId"].ToString();
                grid1.Cell(j, 2).Text = ds.Tables[0].Rows[i]["EmployeeName"].ToString();
                grid1.Cell(j, 3).Text = ds.Tables[0].Rows[i]["designation"].ToString();
                grid1.Cell(j, 4).Text = ds.Tables[0].Rows[i]["shortDesc"].ToString();
                grid1.Cell(j, 5).Text = ds.Tables[0].Rows[i]["saltype"].ToString();
                grid1.Cell(j, 6).Text = ds.Tables[0].Rows[i]["Empstatus"].ToString();
                grid1.Cell(j, 7).Text = ds.Tables[0].Rows[i]["Status"].ToString();
                //grid1.Cell(j, 8).Text = ds.Tables[0].Rows[i]["floor"].ToString();
            }
        }
        void LoadDesignation()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select  DesignationId,  designation from designation";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(3).DataSource = ds.Tables[0];
            grid1.ComboBox(3).ValueMember = "DesignationId";
            grid1.ComboBox(3).DisplayMember= "designation";
        
        
        }

        void LoadOperator()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select operatorid ,shortDesc from tOperatorType";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(4).DataSource = ds.Tables[0];
            grid1.ComboBox(4).ValueMember = "operatorid";
            grid1.ComboBox(4).DisplayMember = "shortDesc";
            
        }

        //void LoadFloor()
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = clsDbForReports.constr;
        //    SqlDataAdapter sda = new SqlDataAdapter("", con);
        //    sda.SelectCommand.CommandText = "select floorid ,floor from tfloor";
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    grid1.ComboBox(8).DataSource = ds.Tables[0];
        //    grid1.ComboBox(8).ValueMember = "floorid";
        //    grid1.ComboBox(8).DisplayMember = "floor";

        //}




        private void LoadSalType()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select saltypecode,saltype  from saltype order by saltypecode ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(5).DataSource = ds.Tables[0];
            grid1.ComboBox(5).DisplayMember = "saltype";
            grid1.ComboBox(5).ValueMember = "saltypecode";
        }
        void Loadtemp()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select  id,Empstatus from TEmpstatus ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(6).DataSource = ds.Tables[0];
            grid1.ComboBox(6).DisplayMember = "Empstatus";
            grid1.ComboBox(6).ValueMember = "id";
        
        }

        private void grid1_Click(object Sender, EventArgs e)
        {
            if (grid1.ActiveCell.Col == 4)
            {
                grid1.Cell(grid1.ActiveCell.Row, 4).SetFocus();
            }
            if (grid1.ActiveCell.Col == 5)
            {
                grid1.Cell(grid1.ActiveCell.Row, 5).SetFocus();

            }
            if (grid1.ActiveCell.Col == 3)
            {
                grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();

            }
            if (grid1.ActiveCell.Col == 6)
            {
                grid1.Cell(grid1.ActiveCell.Row, 6).SetFocus();

            }
            //if (grid1.ActiveCell.Col == 8)
            //{
            //    grid1.Cell(grid1.ActiveCell.Row, 8).SetFocus();

            //}
        }

        private void frmDesiganationMaster_Load(object sender, EventArgs e)
        {
            FlexNamings();
            LoadDesignation();
            LoadEmpdetails();
            LoadSalType();
            Loadtemp();
            LoadOperator();
            //LoadFloor();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            int j = 0;
            for (int i = 0; i < grid1.Rows-1; i++)
            {
                string s =(grid1.Rows - 1).ToString();
                j = i + 1;               
                UpdateEmploye(j);
                
            }
            MessageBox.Show("Updated Sucessfully");
        }
        void UpdateEmploye( int j)
        {
            string nm;           
            if (grid1.Cell(j, 7).Text == "0") 
            {
               nm = "No";

            }
            else            
            {
                nm = "YES";
            }

            SqlConnection con = new SqlConnection();           
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("",con);
            cmd.CommandText = "update Employee set  desigcode = @designation , Operatorid = @operatorid, SalTypeCode= @saltype, Statusid= @statusid ,NeedMachine= @needmachine where EmpId =@empid";
            cmd.Parameters.AddWithValue("@designation",grid1.ComboBox(3).GetItemValue(grid1.Cell(j, 3).Text).ToString());
            cmd.Parameters.AddWithValue("@operatorid", (grid1.ComboBox(4).GetItemValue(grid1.Cell(j, 4).Text).ToString()));
            cmd.Parameters.AddWithValue("@saltype", grid1.ComboBox(5).GetItemValue(grid1.Cell(j, 5).Text).ToString());
            cmd.Parameters.AddWithValue("@statusid", grid1.ComboBox(6).GetItemValue(grid1.Cell(j, 6).Text).ToString());
            cmd.Parameters.AddWithValue("@empid", (grid1.Cell(j, 1).Text).ToString());
            cmd.Parameters.AddWithValue("@needmachine", nm.ToString());
            //cmd.Parameters.AddWithValue("@floorid", grid1.ComboBox(8).GetItemValue(grid1.Cell(j, 8).Text).ToString());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid1_KeyDown(object Sender, KeyEventArgs e)
        {
            if (grid1.ActiveCell.Col == 3)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 4)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 5)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 6)
            {
                e.SuppressKeyPress = true;
            }
            //if (grid1.ActiveCell.Col == 8)
            //{
            //    e.SuppressKeyPress = true;
            //}
        }

             

    }
}
