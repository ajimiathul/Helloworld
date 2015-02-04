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
    public partial class frmMachine : Form
    {
        public frmMachine()
        {
            InitializeComponent();
        }
        int edit = 0; 
        int lr= 0;
        private void FlexNamings()
        {
            grid1.DateFormat = FlexCell.DateFormatEnum.DMY;
           // grid1.Rows = 2;
            grid1.Cell(0, 2).Text = "MachineId";
            grid1.Cell(0, 3).Text = "Machine Name";
            grid1.Cell(0, 4).Text = "Machine No:";
            grid1.Cell(0, 5).Text = "Purchase Date";
            grid1.Cell(0, 6).Text = "Floor";
            grid1.Cell(0, 7).Text = "Line";
            grid1.Cell(0, 8).Text = "Manufacture Name";
            grid1.Cell(0, 9).Text = "Type";
            
             grid1.Column(1).Width = 40;
             grid1.Column(2).Width = 80;
             grid1.Column(3).Width = 150;
             grid1.Column(4).Width = 80;
             grid1.Column(5).Width = 100;
             grid1.Column(6).Width = 100;
             grid1.Column(7).Width = 100;
             grid1.Column(8).Width = 100;
             grid1.Column(9).Width = 100;
             grid1.Column(10).Width = 50;
             grid1.Column(11).Width = 50;


             grid1.Column(2).Locked = true;
             grid1.Column(11).Locked = true;
             grid1.Column(10).Locked = true;
             grid1.Column(1).Locked = true;
             

            grid1.Column(5).CellType = FlexCell.CellTypeEnum.Calendar;
            grid1.Column(6).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(7).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(8).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(10).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(9).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(1).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(11).CellType = FlexCell.CellTypeEnum.HyperLink;

        }
        void LoadMake()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Makeid ,Make from tMake";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(8).DataSource = ds.Tables[0];
            grid1.ComboBox(8).ValueMember = "Makeid";
            grid1.ComboBox(8).DisplayMember = "Make";
       
        }
        void LoadType()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select  Mtype,MtypeID from tMachineType";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(9).DataSource = ds.Tables[0];
            grid1.ComboBox(9).ValueMember = "MtypeID";
            grid1.ComboBox(9).DisplayMember = "Mtype";


        }
        void LoadFloor()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select floorid ,floor from tfloor";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(6).DataSource = ds.Tables[0];
            grid1.ComboBox(6).ValueMember = "floorid";
            grid1.ComboBox(6).DisplayMember = "floor";

        
        }

        void LoadLine()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Lineid,LineDesc from tLine";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(7).DataSource = ds.Tables[0];
            grid1.ComboBox(7).ValueMember = "Lineid";
            grid1.ComboBox(7).DisplayMember = "LineDesc";

        
        }


        private int ReadLastNum()
        {
            UpdateLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "select lastnum from tNumbers where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "Machine");
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
            scmd.Parameters.AddWithValue("@scr", "Machine");
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        void loadFlexGrid()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;            
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = "select  m.machineid,m.MachineName,m.MachineNo,f.floor,convert(nvarchar(10),m.puchasedate,103)Date,l.LineDesc,mk.Make, tm.Mtype from tMachine m left join tfloor f on m.floorid= f.floorid ";
            string s2 = " left join tMake mk on mk.Makeid= m.makeid left join tLine l on l.Lineid= m.lineid left join tMachineType tm on tm.MtypeID= m.MtypeId where m.machineid <> 0 ";
            sda.SelectCommand.CommandText = s1+s2;
            DataSet ds = new DataSet();
            sda.Fill(ds);
             int j=0;
             for (int i =0; i< ds.Tables[0].Rows.Count;i++)
              {
                grid1.Rows= grid1.Rows+1;
                j=i+1;        
                grid1.Cell(j, 2).Text = ds.Tables[0].Rows[i]["machineid"].ToString();
                grid1.Cell(j, 3).Text = ds.Tables[0].Rows[i]["MachineName"].ToString();
                grid1.Cell(j, 4).Text = ds.Tables[0].Rows[i]["MachineNo"].ToString();
                grid1.Cell(j, 5).Text = ds.Tables[0].Rows[i]["Date"].ToString();
                grid1.Cell(j, 6).Text = ds.Tables[0].Rows[i]["floor"].ToString();
                grid1.Cell(j, 7).Text = ds.Tables[0].Rows[i]["LineDesc"].ToString();
                grid1.Cell(j, 8).Text = ds.Tables[0].Rows[i]["Make"].ToString();
                grid1.Cell(j, 9).Text = ds.Tables[0].Rows[i]["Mtype"].ToString();
                grid1.Cell(j, 1).Text = "Edit";
                lockorunlock(j, 0);
              }
              grid1.Cell(j + 1, 1).Text ="New";
              lockorunlock(j+1, 0);
        
        }
        void Insertmachine()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand cmd = new SqlCommand("", sc);
            cmd.CommandText = "insert into tMachine (machineid , MachineName,MachineNo,floorid,puchasedate, lineid,makeid,Mtypeid) values( @Mid, @Mname,@Mno,@fid,@pdate,@Lid,@makeid ,@mtypeid)";
            cmd.Parameters.AddWithValue("@Mid", Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row,2).Text).ToString());
            cmd.Parameters.AddWithValue("@Mname", grid1.Cell(grid1.ActiveCell.Row, 3).Text.ToString());
            cmd.Parameters.AddWithValue("@Mno", (grid1.Cell(grid1.ActiveCell.Row, 4).Text).ToString());
            cmd.Parameters.AddWithValue("@fid", Convert.ToInt32(grid1.ComboBox(6).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 6).Text).ToString()));
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime dt = Convert.ToDateTime(grid1.Cell(grid1.ActiveCell.Row, 5).Text);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            cmd.Parameters.AddWithValue("@pdate",dt);
            cmd.Parameters.AddWithValue("@Lid", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text).ToString()));
            cmd.Parameters.AddWithValue("@makeid", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text).ToString()));
            //cmd.Parameters.AddWithValue("@makeid", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text).ToString()));
            cmd.Parameters.AddWithValue("@mtypeid", Convert.ToInt32(grid1.ComboBox(9).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 9).Text).ToString()));
            cmd.ExecuteNonQuery();
            sc.Close();
            grid1.Cell(grid1.ActiveCell.Row, 11).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 10).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 1).Text = "Edit";
            grid1.Rows= grid1.Rows + 1;
            grid1.Cell(grid1.ActiveCell.Row +1, 1).Text = "New";
            lockorunlock(grid1.ActiveCell.Row + 1, 0);
           

        }
        void InsertlastMachneemp()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand cmd = new SqlCommand("", sc);
            cmd.CommandText = "insert into  tLastMachineEmployee (machineid, empid ) values(@machineid, 0)";
            cmd.Parameters.AddWithValue("@machineid", Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 2).Text).ToString());
            cmd.ExecuteNonQuery();
            sc.Close();
        }
        void UpdateMachine()
        {

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand cmd = new SqlCommand("", sc);
            cmd.CommandText = "update tMachine set MachineName= @Mname ,MachineNo=@Mno, floorid= @floor,lineid= @lineid,makeid= @makeid, puchasedate= @pdate,MtypeId = @mtypeid where machineid= @machineid";
            cmd.Parameters.AddWithValue("@machineid", Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 2).Text).ToString());
            cmd.Parameters.AddWithValue("@Mname", grid1.Cell(grid1.ActiveCell.Row, 3).Text.ToString());
            cmd.Parameters.AddWithValue("@Mno", (grid1.Cell(grid1.ActiveCell.Row, 4).Text).ToString());
            cmd.Parameters.AddWithValue("@floor", Convert.ToInt32(grid1.ComboBox(6).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 6).Text).ToString()));
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime dt = Convert.ToDateTime(grid1.Cell(grid1.ActiveCell.Row, 5).Text);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");            
            cmd.Parameters.AddWithValue("@pdate", dt);
            cmd.Parameters.AddWithValue("@lineid", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text).ToString()));
            cmd.Parameters.AddWithValue("@makeid", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text).ToString()));
            cmd.Parameters.AddWithValue("@mtypeid", Convert.ToInt32(grid1.ComboBox(9).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 9).Text).ToString()));
            cmd.ExecuteNonQuery();
            sc.Close();
            grid1.Cell(grid1.ActiveCell.Row, 11).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 10).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 1).Text = "Edit";
        }
         private void lockorunlock(int index, int check)
        {
            if (check == 1)
            {
                //grid1.Cell(index, 2).Locked = false;
                grid1.Cell(index, 3).Locked = false;
                grid1.Cell(index, 4).Locked = false;
                grid1.Cell(index, 5).Locked = false;
                grid1.Cell(index, 6).Locked = false;
                grid1.Cell(index, 7).Locked = false;
                grid1.Cell(index, 8).Locked = false;
                grid1.Cell(index, 9).Locked = false;
               // grid1.Cell(index, 10).Locked = false;

            }
            else
            {
                grid1.Cell(index, 2).Locked = true;
                grid1.Cell(index, 3).Locked = true;
                grid1.Cell(index, 4).Locked = true;
                grid1.Cell(index, 5).Locked = true;
                grid1.Cell(index, 6).Locked = true;
                grid1.Cell(index, 7).Locked = true;
                grid1.Cell(index, 8).Locked = true;
                grid1.Cell(index, 9).Locked = true;
                grid1.Cell(index, 10).Locked = true;
                grid1.Cell(index, 11).Locked = true;
            }
         }

        private void frmMachine_Load(object sender, EventArgs e)
        {
            FlexNamings();
            LoadFloor();
            LoadMake();
            LoadLine();
            loadFlexGrid();
            LoadType();
            
        }

        private void grid1_Click(object Sender, EventArgs e)
        {
            if (grid1.ActiveCell.Col == 7)
            {
                grid1.Cell(grid1.ActiveCell.Row, 7).SetFocus();
            }
            if (grid1.ActiveCell.Col == 5)
            {
                grid1.Cell(grid1.ActiveCell.Row, 5).SetFocus();

            }
            
            if (grid1.ActiveCell.Col == 8)
            {
                grid1.Cell(grid1.ActiveCell.Row, 8).SetFocus();

            }
            if (grid1.ActiveCell.Col == 6)
            {
                grid1.Cell(grid1.ActiveCell.Row, 6).SetFocus();

            }
            if (grid1.ActiveCell.Col == 9)
            {
                grid1.Cell(grid1.ActiveCell.Row, 9).SetFocus();

            }
        }

        private void grid1_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            try
            {
                e.URL = null;
                e.Changed = true;
                if (e.Col == 1)
                {
                    if (grid1.Cell(grid1.ActiveCell.Row, 1).Text == "New")
                    {
                        lr = 1;
                        e.URL = null;
                        e.Changed = true;
                        lockorunlock(grid1.ActiveCell.Row, 1);
                        grid1.Cell(grid1.ActiveCell.Row, 10).Text = "Save";
                        grid1.Cell(grid1.ActiveCell.Row, 11).Text = "Cancel";
                        grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();
                        int id = ReadLastNum();
                        grid1.Cell(grid1.ActiveCell.Row, 2).Text = id.ToString();
                        
                    }

                    else
                    {
                        lockorunlock(grid1.ActiveCell.Row, 1);
                        grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();
                        grid1.Cell(grid1.ActiveCell.Row, 10).Text = "update";
                        grid1.Cell(grid1.ActiveCell.Row, 11).Text = "Cancel";
                        edit = 1;
                        lr = 1;

                    }
                }

                if (e.Col == 10)
                {
                    lr = 0;
                    if (grid1.Cell(grid1.ActiveCell.Row, 10).Text == "Save")
                    {
                        if (grid1.Cell(grid1.ActiveCell.Row, 3).Text.Trim().Length == 0)
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();
                            return;
                        }
                        if (grid1.Cell(grid1.ActiveCell.Row, 4).Text.Trim().Length == 0)
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 4).SetFocus();
                            return;
                        }
                        if (grid1.Cell(grid1.ActiveCell.Row, 5).Text.Trim().Length == 0)
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 5).SetFocus();
                            return;
                        }
                        if (grid1.Cell(grid1.ActiveCell.Row, 6).Text.Trim().Length == 0)
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 6).SetFocus();
                            return;
                        }
                        if (grid1.Cell(grid1.ActiveCell.Row, 7).Text.Trim().Length == 0)
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 7).SetFocus();
                            return;
                        }
                        if (grid1.Cell(grid1.ActiveCell.Row, 8).Text.Trim().Length == 0)
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 8).SetFocus();
                            return;
                        }
                        Insertmachine();
                        InsertlastMachneemp();
                        string s = (grid1.ActiveCell.Row).ToString();
                        grid1.Cell(grid1.ActiveCell.Row + 1, 1).Text = "New";
                    }
                    else
                    {
                        if (edit == 1)
                        {
                            UpdateMachine();
                            grid1.Cell(grid1.ActiveCell.Row, 11).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 10).Text = "";

                        }

                    }
                }
                if (e.Col == 11)
                {
                    lr = 0;
                    if (grid1.Cell(grid1.ActiveCell.Row, 1).Text == "New")
                    {
                        cleargrid();
                        lockorunlock(grid1.ActiveCell.Row, 0);
                    }
                    else
                    {
                        if (edit == 1)
                        {
                            EditCancelMachine();
                            lockorunlock(grid1.ActiveCell.Row, 0);
                            edit = 0;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Machine No already exits");
                cleargrid();
                lockorunlock(grid1.ActiveCell.Row, 0);
            }

        }

        void cleargrid()
        {
            grid1.Cell(grid1.ActiveCell.Row, 2).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 3).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 4).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 5).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 6).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 7).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 8).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 9).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 10).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 11).Text = "";

        
        }
        void EditCancelMachine()
        { 
         SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;            
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = "select  m.machineid,m.MachineName,m.MachineNo,f.floor,convert(nvarchar(10),m.puchasedate,103)Date,l.LineDesc,mk.Make,tm.Mtype from tMachine m join tfloor f on m.floorid= f.floorid ";
            string s2 = "join tMake mk on mk.Makeid= m.makeid join tLine l on l.Lineid= m.lineid join tMachineType tm on tm.MtypeID= m.MtypeId where m.machineid=@machineid";
            sda.SelectCommand.CommandText = s1+s2;
            sda.SelectCommand.Parameters.AddWithValue("@machineid", Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 2).Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);           
                
                 grid1.Cell(grid1.ActiveCell.Row, 2).Text = ds.Tables[0].Rows[0]["machineid"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 3).Text = ds.Tables[0].Rows[0]["MachineName"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 4).Text = ds.Tables[0].Rows[0]["MachineNo"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 5).Text = ds.Tables[0].Rows[0]["Date"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 6).Text = ds.Tables[0].Rows[0]["floor"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 7).Text = ds.Tables[0].Rows[0]["LineDesc"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 8).Text = ds.Tables[0].Rows[0]["Make"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 9).Text = ds.Tables[0].Rows[0]["Mtype"].ToString();
                 grid1.Cell(grid1.ActiveCell.Row, 1).Text = "Edit";
                 grid1.Cell(grid1.ActiveCell.Row, 11).Text = "";
                 grid1.Cell(grid1.ActiveCell.Row, 10).Text = "";
             
        
        }

        private void grid1_LeaveCell(object Sender, FlexCell.Grid.LeaveCellEventArgs e)
        {
           
        }

        private void grid1_KeyDown(object Sender, KeyEventArgs e)
        {
            if (grid1.ActiveCell.Col == 6)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 7)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 8)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 5)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 9)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void grid1_LeaveRow(object Sender, FlexCell.Grid.LeaveRowEventArgs e)
        {
            if (lr == 1)
            {
                e.Cancel = true;
            }
        }

        private void grid1_KeyPress(object Sender, KeyPressEventArgs e)
        {

        }

        private void grid1_KeyUp(object Sender, KeyEventArgs e)
        {
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid1_Load(object sender, EventArgs e)
        {

        }
    }
}
