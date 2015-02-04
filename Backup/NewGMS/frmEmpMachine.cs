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
    public partial class frmEmpMachine : Form
    {
        public frmEmpMachine()
        {
            InitializeComponent();
        }
        bool formLoading = false;
        private void frmEmpMachine_Load(object sender, EventArgs e)
        {
            flexNamings(); 
            LoadEmployee();
            LoadmachineDetails();

            formLoading = true;

        }

        private void flexNamings()
        {
            grid1.Cell(0, 1).Text = "MachineId";
            grid1.Cell(0, 2).Text = "Machine Name";
            grid1.Cell(0, 3).Text = "Machine No:";
            grid1.Cell(0, 4).Text = "Employee";
            grid1.Cell(0, 5).Text = "EmpID";
            grid1.Column(4).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(5).Width = 60;
            grid1.Column(1).Width = 0;
            grid1.Column(2).Width = 125;
            grid1.Column(3).Width = 100;
            grid1.Column(4).Width = 150;

            grid1.Column(1).Locked = true;
            grid1.Column(2).Locked = true;
            grid1.Column(3).Locked = true;
            grid1.Column(5).Locked = true;


   
//            grid1.Cell(0, 6).Text = "";
            
        }


        void LoadmachineDetails()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = "select  m.machineid, m.MachineNo,   m.MachineName, e.EmployeeName,lm.empid from  tMachine m ";
            string s2 = " join tLastMachineEmployee lm on m.machineid= lm.machineid join Employee e  on e.EmpId= lm.empid";
            sda.SelectCommand.CommandText =s1+s2;
            DataSet ds = new DataSet();
            sda.Fill(ds); 
            grid1.Rows =1;
            for (int i = 0; i< ds.Tables[0].Rows.Count; i++)
            {
                grid1.Rows = grid1.Rows + 1;
                int j = i + 1;
                grid1.Cell(j, 1).Text = ds.Tables[0].Rows[i]["machineid"].ToString();
                grid1.Cell(j, 3).Text = ds.Tables[0].Rows[i]["MachineNo"].ToString();
                grid1.Cell(j, 2).Text = ds.Tables[0].Rows[i]["MachineName"].ToString();
                grid1.Cell(j, 4).Text = ds.Tables[0].Rows[i]["EmployeeName"].ToString();
                grid1.Cell(j, 5).Text = ds.Tables[0].Rows[i]["EmpId"].ToString();
               //grid1.Cell(grid1.ActiveCell.Row, 1).Text = ds.Tables[0].Rows[i]["machineid"].ToString();
                //grid1.Cell(i, 5).Text = i.ToString ();
            }        
        }

        void LoadEmployee()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "ActiveEmplistWithNA";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds= new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {                 
                grid1.ComboBox(4).DataSource = ds.Tables[0];
                grid1.ComboBox(4).DisplayMember = "EmployeeName";
                grid1.ComboBox(4).ValueMember = "empid";
            }
        
        }
        private void Empid(string emp)
        {
            if (formLoading == true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select EmpId,EmployeeName from  Employee where EmpId= @empid";
                sda.SelectCommand.Parameters.AddWithValue("@empid", emp);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 5).Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 1; i < grid1.Rows; i++)
            {
                str = str +  grid1.Cell(i,5).Text + ",";
            }            
            if (str.Trim().Length == 0)
            {
                str = ",";
            }
 
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "ChkMachAndEmp";
            sda.SelectCommand.Parameters.AddWithValue("@empidStr", str);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    grid1.Cell(Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString ()), 5).ForeColor = Color.Red;                    
                }
                MessageBox.Show("Please Change Duplicates.");
            }
            else
            {
                for (int i = 1; i < grid1.Rows; i++)
                {
                    SaveProcess(i);
                    
                
                }
                MessageBox.Show("Updated Sucessfully");
            }

        }

        private void SaveProcess( int i)

        {
            grid1.Cell(i, 5).ForeColor = Color.Black;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand cmd = new SqlCommand("", sc);
            cmd.CommandText = "update tLastMachineEmployee set empid= @empid where machineid= @machineid";
            cmd.Parameters.AddWithValue("@empid", Convert.ToInt32(grid1.Cell(i, 5).Text));
            cmd.Parameters.AddWithValue("@machineid", Convert.ToInt32(grid1.Cell(i, 1).Text));
            cmd.ExecuteNonQuery();
            sc.Close();

        
        }
        private void grid1_Click(object Sender, EventArgs e)
        {
            if (grid1.ActiveCell.Col == 4)
            {
                grid1.Cell(grid1.ActiveCell.Row,4).SetFocus();
            }

        }

        private void grid1_ComboClick(object Sender, FlexCell.Grid.ComboClickEventArgs e)
        {
            if (e.Index == 4)
            {
                string str =grid1.ActiveCell.Text.Trim ();
                if (grid1.ComboBox(4).FindItem(str, str.Length, true) != -1)
                {
                    string emp = (grid1.ComboBox(4).GetItemValue(grid1.ActiveCell.Text).ToString());
                    Empid(emp);
                }
                else
                {
                    Empid("0");                
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            //grid1.Cell(3, 4).Text =  grid1.ComboBox(4).FindItem("GOPALAKRISHNAN NAIRp",20,true).ToString();
           this.Close();            
        }

        private void grid1_KeyDown(object Sender, KeyEventArgs e)
        {
            if (grid1.ActiveCell.Col == 4)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
