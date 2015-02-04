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
    public partial class frmFinishedProductsInward : Form
    {
        public frmFinishedProductsInward()
        {
            InitializeComponent();
        }
        
        double  ed1=0,ed2=0,ed3=0,ed4=0,ed5=0, etot=0;
        double d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, tot = 0;
        int intNum = 0;
        bool formLoading = false;
        int flag = 0;
        int edit = 0;
        int LR = 0,LREdit=0;

        private void frmFinishedProductsInward_Load(object sender, EventArgs e)
        {
            // grid1.Cell(grid1.ActiveCell.Row, 1).Text = "new";
            FlexNamings();
            flexnamimgedit();
            formLoading = false;
            //grid1.DateFormat=FlexCell.DateFormatEnum.DMY;
            formLoading = true;
            LoadWarehouse();
            LoadSleeve();
            LoadFit();
            LoadStyle();
            validation2(10);
            validation2(11);
            validation2(12);
            validation2(13);
            validation2(14);
            validation2(15);
            validation(16);
            loadflexgrid();
            //lockFlexgrid();

        }


        private void validation(int col)
        {
            FlexCell.Column column1 = grid1.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 2;
        }
        private void validation2(int col)
        {
            FlexCell.Column column1 = grid1.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 0;
        }
        private void flexnamimgedit()
        {
            fgridedit.DateFormat = FlexCell.DateFormatEnum.DMY;
            fgridedit.Rows = 2;
            fgridedit.Cell(0, 3).Text = "WareHouse";
            fgridedit.Cell(0, 4).Text = "Entry Date";
            fgridedit.Cell(0, 5).Text = "Style";
            fgridedit.Cell(0, 7).Text = "Fabric Code";
            fgridedit.Cell(0, 8).Text = "Sleeve";
            fgridedit.Cell(0, 9).Text = "Fit";
            fgridedit.Cell(0, 10).Text = "38";
            fgridedit.Cell(0, 11).Text = "39";
            fgridedit.Cell(0, 12).Text = "40";
            fgridedit.Cell(0, 13).Text = "42";
            fgridedit.Cell(0, 14).Text = "44";
            fgridedit.Cell(0, 15).Text = "Total";
            fgridedit.Cell(0, 16).Text = "MRP";
            fgridedit.Column(15).Locked = true;
            fgridedit.Column(6).Locked = true;
            fgridedit.Column(7).Width = 80;
            fgridedit.Column(10).Width = 40;
            fgridedit.Column(11).Width = 40;
            fgridedit.Column(12).Width = 40;
            fgridedit.Column(13).Width = 40;
            fgridedit.Column(14).Width = 40;
            fgridedit.Column(15).Width = 40;
            fgridedit.Column(9).Width = 100;
            fgridedit.Column(8).Width = 100;
            fgridedit.Column(1).Width = 50;
            fgridedit.Column(2).Width = 50;
            fgridedit.Column(17).Width = 50;
            fgridedit.Column(18).Width = 50;
            fgridedit.Column(5).Width = 100;
            fgridedit.Column(3).CellType = FlexCell.CellTypeEnum.ComboBox;
            fgridedit.Column(4).CellType = FlexCell.CellTypeEnum.Calendar;
            fgridedit.Column(5).CellType = FlexCell.CellTypeEnum.ComboBox;
            fgridedit.Column(8).CellType = FlexCell.CellTypeEnum.ComboBox;
            fgridedit.Column(9).CellType = FlexCell.CellTypeEnum.ComboBox;
            fgridedit.Column(1).CellType = FlexCell.CellTypeEnum.HyperLink;
            fgridedit.Column(2).CellType = FlexCell.CellTypeEnum.HyperLink;
            fgridedit.Column(17).CellType = FlexCell.CellTypeEnum.HyperLink;
            fgridedit.Column(18).CellType = FlexCell.CellTypeEnum.HyperLink;

        }

        private void FlexNamings()
        {
            grid1.DateFormat = FlexCell.DateFormatEnum.DMY;
            grid1.Rows = 2;
            grid1.Cell(0, 3).Text = "WareHouse";
            grid1.Cell(0, 4).Text = "Entry Date";
            grid1.Cell(0, 5).Text = "Style";
            grid1.Cell(0, 7).Text = "Fabric Code";
            grid1.Cell(0, 8).Text = "Sleeve";
            grid1.Cell(0, 9).Text = "Fit";
            grid1.Cell(0, 10).Text = "38";
            grid1.Cell(0, 11).Text = "39";
            grid1.Cell(0, 12).Text = "40";
            grid1.Cell(0, 13).Text = "42";
            grid1.Cell(0, 14).Text = "44";
            grid1.Cell(0, 15).Text = "Total";
            grid1.Cell(0, 16).Text = "MRP";
            grid1.Column(15).Locked = true;
            grid1.Column(6).Locked = true;
            grid1.Column(7).Width = 80;
            grid1.Column(10).Width = 40;
            grid1.Column(11).Width = 40;
            grid1.Column(12).Width = 40;
            grid1.Column(13).Width = 40;
            grid1.Column(14).Width = 40;
            grid1.Column(15).Width = 40;
            grid1.Column(9).Width = 100;
            grid1.Column(8).Width = 100;
            grid1.Column(1).Width = 50;
            grid1.Column(2).Width = 50;
            grid1.Column(17).Width = 50;
            grid1.Column(18).Width = 50;
            grid1.Column(5).Width = 100;
            grid1.Column(3).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(4).CellType = FlexCell.CellTypeEnum.Calendar;
            grid1.Column(5).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(8).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(9).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(1).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(2).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(17).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(18).CellType = FlexCell.CellTypeEnum.HyperLink;

        }
        
        
        private void LoadWarehouse()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select warehousecode,warehouse  from twarehouse2";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(3).DataSource = ds.Tables[0];
            grid1.ComboBox(3).DisplayMember = "warehouse";
            grid1.ComboBox(3).ValueMember = "warehousecode";
            fgridedit.ComboBox(3).DataSource = ds.Tables[0];
            fgridedit.ComboBox(3).DisplayMember = "warehouse";
            fgridedit.ComboBox(3).ValueMember = "warehousecode";
        }

        private void LoadStyle()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select stylecode  from tstyleMaster";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(5).DataSource = ds.Tables[0];
            grid1.ComboBox(5).DisplayMember = "stylecode";
            grid1.ComboBox(5).ValueMember = "stylecode";
            fgridedit.ComboBox(5).DataSource = ds.Tables[0];
            fgridedit.ComboBox(5).DisplayMember = "stylecode";
            fgridedit.ComboBox(5).ValueMember = "stylecode";

        }

        private void LoadSleeve()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select sleeveid,sleeve  from tFinishedProductSleeve";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(8).DataSource = ds.Tables[0];
            grid1.ComboBox(8).DisplayMember = "sleeve";
            grid1.ComboBox(8).ValueMember = "sleeveid";
            fgridedit.ComboBox(8).DataSource = ds.Tables[0];
            fgridedit.ComboBox(8).DisplayMember = "sleeve";
            fgridedit.ComboBox(8).ValueMember = "sleeveid";
        }

        private void LoadFit()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select fitid,fit  from tFinishedProductFit";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.ComboBox(9).DataSource = ds.Tables[0];
            grid1.ComboBox(9).DisplayMember = "fit";
            grid1.ComboBox(9).ValueMember = "fitid";
            fgridedit.ComboBox(9).DataSource = ds.Tables[0];
            fgridedit.ComboBox(9).DisplayMember = "fit";
            fgridedit.ComboBox(9).ValueMember = "fitid";
        }




        private void DeleteFpInward(int i)
        {

            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = " delete from tFinishedProductsInward where recid= @recid";
            cmd.Parameters.AddWithValue("@recid", i);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void AdjustStock()
        {

            int i = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 0).Text);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "ReducingStock";
            cmd.Parameters.AddWithValue("@recid", i);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void SaveProcess()
        {

            if (IsSpecificationsExist() == false)
            {
                insertAll();
            }

            else
            {
                updateAll();


            }
        }

        private void updateAll()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "update tFinishedStock set Q38=Q38+@Q38,Q39=Q39+@Q39,Q40=Q40+@Q40,Q42=Q42+@Q42,Q44=Q44+@Q44 where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd and mrp=@mrp";
            cmd.Parameters.AddWithValue("@Q38", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 10).Text)));
            cmd.Parameters.AddWithValue("@Q39", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text)));
            cmd.Parameters.AddWithValue("@Q40", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 12).Text)));
            cmd.Parameters.AddWithValue("@Q42", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text)));
            cmd.Parameters.AddWithValue("@Q44", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 14).Text)));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text).ToString())));
            cmd.Parameters.AddWithValue("@sc", (grid1.ComboBox(5).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 5).Text).ToString()));
            cmd.Parameters.AddWithValue("@fc", grid1.Cell(grid1.ActiveCell.Row, 7).Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text).ToString())));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(9).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 9).Text).ToString())));
            cmd.Parameters.AddWithValue("@mrp", Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 16).Text));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }

        private bool IsSpecificationsExist()
        {

            int j = grid1.ActiveCell.Row;
            bool ret = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select count(*) num  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and mrp=@mrp";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text).ToString()));
            sda.SelectCommand.Parameters.AddWithValue("@sc", grid1.ComboBox(5).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 5).Text).ToString());
            sda.SelectCommand.Parameters.AddWithValue("@fc", grid1.Cell(grid1.ActiveCell.Row, 7).Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text).ToString()));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(grid1.ComboBox(9).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 9).Text).ToString()));
            sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 16).Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) != 0)
            {
                ret = true;
            }
            return ret;
        }

        private void insertAll()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "insert tFinishedStock(storeID, stylecode,FabricCode, SleeveID,FitID,Q38,Q39,Q40,Q42,Q44,mrp) values(@stid,@sc,@fc,@sd,@fd,@Q38,@Q39,@Q40,@Q42,@Q44,@mrp)";
            cmd.Parameters.AddWithValue("@stid", (Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text).ToString())));
            cmd.Parameters.AddWithValue("@sc", (grid1.ComboBox(5).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 5).Text).ToString()));
            cmd.Parameters.AddWithValue("@fc", grid1.Cell(grid1.ActiveCell.Row, 7).Text);
            cmd.Parameters.AddWithValue("@sd", (Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text).ToString()))));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(9).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 9).Text).ToString())));
            cmd.Parameters.AddWithValue("@Q38", grid1.Cell(grid1.ActiveCell.Row, 10).Text);
            cmd.Parameters.AddWithValue("@Q39", grid1.Cell(grid1.ActiveCell.Row, 11).Text);
            cmd.Parameters.AddWithValue("@Q40", grid1.Cell(grid1.ActiveCell.Row, 12).Text);
            cmd.Parameters.AddWithValue("@Q42", grid1.Cell(grid1.ActiveCell.Row, 13).Text);
            cmd.Parameters.AddWithValue("@Q44", grid1.Cell(grid1.ActiveCell.Row, 14).Text);
            cmd.Parameters.AddWithValue("@mrp", grid1.Cell(grid1.ActiveCell.Row, 16).Text);
            cmd.ExecuteNonQuery();
        }



        private int insertFPInward()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "storeFPinward";
            cmd.CommandType = CommandType.StoredProcedure;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime dt = Convert.ToDateTime(grid1.Cell(grid1.ActiveCell.Row, 4).Text);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            cmd.Parameters.AddWithValue("@Edate", dt);
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text).ToString()));
            cmd.Parameters.AddWithValue("@sc", grid1.ComboBox(5).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 5).Text).ToString());
            cmd.Parameters.AddWithValue("@fc", grid1.Cell(grid1.ActiveCell.Row, 7).Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text).ToString())));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(9).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 9).Text).ToString())));
            cmd.Parameters.AddWithValue("@Q38", grid1.Cell(grid1.ActiveCell.Row, 10).Text);
            cmd.Parameters.AddWithValue("@Q39", grid1.Cell(grid1.ActiveCell.Row, 11).Text);
            cmd.Parameters.AddWithValue("@Q40", grid1.Cell(grid1.ActiveCell.Row, 12).Text);
            cmd.Parameters.AddWithValue("@Q42", grid1.Cell(grid1.ActiveCell.Row, 13).Text);
            cmd.Parameters.AddWithValue("@Q44", grid1.Cell(grid1.ActiveCell.Row, 14).Text);
            cmd.Parameters.AddWithValue("@mrp", grid1.Cell(grid1.ActiveCell.Row, 16).Text);
            cmd.Parameters.AddWithValue("@recid", 0).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.Parameters["@recid"].Value);
        }

        private void loadflexgrid()
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = "select * from (select Top(30) b.recid,  convert(nvarchar(10),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve, d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP ";
            string s2 = " from tWarehouse2 a join tFinishedProductsInward b on a.warehousecode= b.storeID ";
            string s3 = "join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tStyleMaster sm on sm.StyleCode =b.stylecode  join tCF f on f.CFid =sm.CFid order by b.recid  desc) z order by z.recid ";

            sda.SelectCommand.CommandText = s1 + s2 + s3;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grid1.Rows = grid1.Rows + 1;
                j = i + 1;
                grid1.Cell(j, 0).Text = ds.Tables[0].Rows[i]["recid"].ToString();
                grid1.Cell(j, 3).Text = ds.Tables[0].Rows[i]["warehouse"].ToString();
                grid1.Cell(j, 4).Text = ds.Tables[0].Rows[i]["Date"].ToString();
                grid1.Cell(j, 5).Text = ds.Tables[0].Rows[i]["stylecode"].ToString();
                grid1.Cell(j, 6).Text = ds.Tables[0].Rows[i]["CorF"].ToString();
                grid1.Cell(j, 7).Text = ds.Tables[0].Rows[i]["fabricCode"].ToString();
                grid1.Cell(j, 8).Text = ds.Tables[0].Rows[i]["sleeve"].ToString();
                grid1.Cell(j, 9).Text = ds.Tables[0].Rows[i]["fit"].ToString();
                grid1.Cell(j, 10).Text = ds.Tables[0].Rows[i]["38"].ToString();
                grid1.Cell(j, 11).Text = ds.Tables[0].Rows[i]["39"].ToString();
                grid1.Cell(j, 12).Text = ds.Tables[0].Rows[i]["40"].ToString();
                grid1.Cell(j, 13).Text = ds.Tables[0].Rows[i]["42"].ToString();
                grid1.Cell(j, 14).Text = ds.Tables[0].Rows[i]["44"].ToString();
                grid1.Cell(j, 15).Text = ds.Tables[0].Rows[i]["Total"].ToString();
                grid1.Cell(j, 16).Text = ds.Tables[0].Rows[i]["MRP"].ToString();
                grid1.Cell(j, 1).Text = "Edit";
                grid1.Cell(j, 2).Text = "Delete";
                //grid1.Cell(j, 17).Text = "update";
                //grid1.Cell(j, 18).Text = "cancel";
                lockorunlock(j, 0);
            }
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    clearflexgrid();

            //}
            grid1.Cell(j + 1, 1).Text = "new";
            grid1.Cell(j + 1, 2).Locked = true;
            lockorunlock(j + 1, 0);

        }

        private void btnShowInward_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = "select b.recid, convert(nvarchar(10),b.EntryDate,103) Date, a.warehouse  , b.stylecode, b.fabricCode,c.sleeve, d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP ";
            string s2 = " from tWarehouse2 a join tFinishedProductsInward b on a.warehousecode= b.storeID ";
            string s3 = "join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID";
            sda.SelectCommand.CommandText = s1 + s2 + s3;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvInward.DataSource = ds.Tables[0];
            dgvInward.Columns[0].Visible = false;
            dgvInward.Columns[0].Visible = false;
            dgvInward.Columns[7].Width = 40;
            dgvInward.Columns[8].Width = 40;
            dgvInward.Columns[9].Width = 40;
            dgvInward.Columns[10].Width = 40;
            dgvInward.Columns[11].Width = 40;
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        
        
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == History)
            {
                // btnSave.Enabled = false;
            }
            if (tabControl1.SelectedTab == Entry)
            {
                // btnSave.Enabled = true;
            }
        }




        private void txtFCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // txtQ38.Focus();
            }
        }
        private void StyleType(string st)
        {
            if (formLoading == true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select b.CorF from tStyleMaster a join tCF b on a.CFid=b.CFid where StyleCode=@StyleCode";
                sda.SelectCommand.Parameters.AddWithValue("@StyleCode", st);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 6).Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }
        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grid1_ComboClick(object Sender, FlexCell.Grid.ComboClickEventArgs e)
        {

            if (e.Index == 5)
            {

                string st = (grid1.ComboBox(5).GetItemValue(grid1.ActiveCell.Text).ToString());

                StyleType(st);
            }
        }

        private void grid1_LeaveCell(object Sender, FlexCell.Grid.LeaveCellEventArgs e)
        {
            try
            {
                tot = 0;
                d1 = 0;
                d2 = 0;
                d3 = 0;
                d4 = 0;
                d5 = 0;

                if (e.Col == 10 || e.Col == 11 || e.Col == 12 || e.Col == 13 || e.Col == 14)
                {
                    if (grid1.Cell(grid1.ActiveCell.Row, 10).Text.Trim().Length != 0)
                    {
                        if (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 10).Text) >= 0)
                        {

                            d1 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 10).Text);
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 10).SetFocus();
                            e.Cancel = true;
                            return;

                        }

                    }

                    if (grid1.Cell(grid1.ActiveCell.Row, 11).Text.Trim().Length != 0)
                    {

                        if (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text) >= 0)
                        {

                            d2 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 11).Text);
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 11).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }

                    if (grid1.Cell(grid1.ActiveCell.Row, 12).Text.Trim().Length != 0)
                    {

                        if (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 12).Text) >= 0)
                        {

                            d3 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 12).Text);
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 12).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }


                    if (grid1.Cell(grid1.ActiveCell.Row, 13).Text.Trim().Length != 0)
                    {
                        if (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text) >= 0)
                        {

                            d4 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 13).Text);
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 13).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }


                    if (grid1.Cell(grid1.ActiveCell.Row, 14).Text.Trim().Length != 0)
                    {
                        if (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 14).Text) >= 0)
                        {

                            d5 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 14).Text);
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 14).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }

                }
                if (e.Row > 0)
                {
                    tot = d1 + d2 + d3 + d4 + d5;
                    if (tot != 0)
                    {
                        grid1.Cell(grid1.ActiveCell.Row, 15).Text = tot.ToString();
                        //tot = 0;
                    }

                }



            }
            catch (Exception)
            {
            }
        }

        private void grid1_LeaveRow(object Sender, FlexCell.Grid.LeaveRowEventArgs e)
        {

            if (LR == 1)
            {
                e.Cancel = true;
            }


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
            if (grid1.ActiveCell.Col == 8)
            {
                grid1.Cell(grid1.ActiveCell.Row, 8).SetFocus();

            }
            if (grid1.ActiveCell.Col == 9)
            {
                grid1.Cell(grid1.ActiveCell.Row, 9).SetFocus();

            }
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
                grid1.Cell(index, 10).Locked = false;
                grid1.Cell(index, 11).Locked = false;
                grid1.Cell(index, 12).Locked = false;
                grid1.Cell(index, 13).Locked = false;
                grid1.Cell(index, 14).Locked = false;
                grid1.Cell(index, 15).Locked = false;
                grid1.Cell(index, 16).Locked = false;
                grid1.Cell(index, 17).Locked = false;
                grid1.Cell(index, 18).Locked = false;
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
                grid1.Cell(index, 12).Locked = true;
                grid1.Cell(index, 13).Locked = true;
                grid1.Cell(index, 14).Locked = true;
                grid1.Cell(index, 15).Locked = true;
                grid1.Cell(index, 16).Locked = true;
                grid1.Cell(index, 17).Locked = true;
                grid1.Cell(index, 18).Locked = true;

            }

        }

        private void lockFlexgrid()
        {
            //grid1.Column(1).Locked = true;
            //grid1.Column(2).Locked = true;
            grid1.Column(3).Locked = true;
            grid1.Column(4).Locked = true;
            grid1.Column(5).Locked = true;
            grid1.Column(6).Locked = true;
            grid1.Column(7).Locked = true;
            grid1.Column(8).Locked = true;
            grid1.Column(9).Locked = true;
            grid1.Column(10).Locked = true;
            grid1.Column(11).Locked = true;
            grid1.Column(12).Locked = true;
            grid1.Column(13).Locked = true;
            grid1.Column(14).Locked = true;
            grid1.Column(15).Locked = true;
            grid1.Column(16).Locked = true;
            grid1.Column(17).Locked = true;
            grid1.Column(18).Locked = true;
        }


        private void grid1_KeyDown(object Sender, KeyEventArgs e)
        {
            if (grid1.ActiveCell.Col == 3)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 5)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 8)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 9)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 4)
            {
                e.SuppressKeyPress = true;
            }

        }

        private void clearflexgrid()
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
            grid1.Cell(grid1.ActiveCell.Row, 12).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 13).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 14).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 15).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 16).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 17).Text = "";
            grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";
        }



        private void hypercol17()
        {
            d1 = 0;
            d2 = 0;
            d3 = 0;
            d4 = 0;
            d5 = 0;



            if (grid1.Cell(grid1.ActiveCell.Row, 3).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 4).Text.Trim().Length == 0)
            {
                // flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 4).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 5).Text.Trim().Length == 0)
            {
                // flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 5).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 6).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 6).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 7).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 7).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 8).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 8).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 9).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 9).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 10).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 10).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 11).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 11).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 12).Text.Trim().Length == 0)
            {
                // flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 12).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 13).Text.Trim().Length == 0)
            {
                // flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 13).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 14).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 14).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 15).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 15).SetFocus();

                return;
            }
            if (grid1.Cell(grid1.ActiveCell.Row, 16).Text.Trim().Length == 0)
            {
                //flag = 1;
                grid1.Cell(grid1.ActiveCell.Row, 16).SetFocus();

                return;
            }
            else
            {


                if (edit == 1)
                {
                    int i1 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 10).Text);
                    int i2 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text);
                    int i3 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 12).Text);
                    int i4 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text);
                    int i5 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 14).Text);
                    grid1.Cell(grid1.ActiveCell.Row, 15).Text = (i1 + i2 + i3 + i4 + i5).ToString();
                    AdjustStock();
                    int i = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 0).Text);
                    DeleteFpInward(i);
                    SaveProcess();
                    int value = insertFPInward();
                    grid1.Cell(grid1.ActiveCell.Row, 0).Text = value.ToString();
                    flag = 0;
                    edit = 0;
                    lockorunlock(grid1.ActiveCell.Row, 0);
                    grid1.Cell(grid1.ActiveCell.Row, 17).Text = "";
                    grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";

                }
                else
                {
                    if (grid1.Cell(grid1.ActiveCell.Row, 17).Text == "Save")
                    {
                        SaveProcess();
                        int value = insertFPInward();
                        grid1.Column(1).Width = 50;
                        grid1.Column(2).Width = 60;
                        grid1.Cell(grid1.ActiveCell.Row, 1).Text = "Edit";
                        grid1.Cell(grid1.ActiveCell.Row, 2).Text = "Delete";
                        grid1.Cell(grid1.ActiveCell.Row, 17).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 1).Locked = true;
                        grid1.Cell(grid1.ActiveCell.Row, 2).Locked = true;
                        grid1.Cell(grid1.ActiveCell.Row, 0).Text = value.ToString();
                        lockorunlock(grid1.ActiveCell.Row, 0);
                        flag = 0;
                        grid1.Rows = grid1.Rows + 1;
                        grid1.Cell(grid1.ActiveCell.Row + 1, 1).Text = "new";
                        grid1.Cell(grid1.ActiveCell.Row + 1, 1).Locked = true;

                        grid1.Cell(grid1.ActiveCell.Row + 1, 1).SetFocus();
                        //if (grid1.Rows > 30)
                        //{
                        //    grid1.Rows = 2;
                        //    loadflexgrid();
                        //}
                        lockorunlock(grid1.ActiveCell.Row, 0);
                    }

                }

            }


        }

        private void grid1_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            {
                e.URL = null;
                e.Changed = true;
                if (e.Col == 1)
                {
                    e.URL = null;
                    e.Changed = true;
                    if (grid1.Cell(grid1.ActiveCell.Row, 1).Text == "Edit")
                    {
                        int i = grid1.ActiveCell.Row;
                        lockorunlock(i, 1);
                        grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();
                        grid1.Cell(grid1.ActiveCell.Row, 17).Text = "update";
                        grid1.Cell(grid1.ActiveCell.Row, 18).Text = "cancel";
                        flag = 1;
                        edit = 1;
                        LR = 1;
                    }
                    else
                    {
                        LR = 1;
                        lockorunlock(grid1.ActiveCell.Row, 1);
                        grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();
                        grid1.Cell(grid1.ActiveCell.Row, 17).Text = "Save";
                        grid1.Cell(grid1.ActiveCell.Row, 18).Text = "Cancel";
                        grid1.Cell(grid1.ActiveCell.Row, 2).Text = "Delete";
                    }

                }
                if (e.Col == 2 & grid1.Cell(grid1.ActiveCell.Row, 1).Text == "Edit")
                {

                    e.URL = null;
                    e.Changed = true;
                    var result = MessageBox.Show("Do you want to Delete?", "Delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {


                        AdjustStock();
                        int i = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 0).Text);
                        DeleteFpInward(i);
                       
                        grid1.ActiveCell.ForeColor = Color.Red;
                        grid1.Cell(grid1.ActiveCell.Row, 2).Text = "Deleted";
                        grid1.Cell(grid1.ActiveCell.Row, 1).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 17).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";
                    }
                }
                if (e.Col == 17)
                {

                    LR = 0;
                    hypercol17();
                }

                if (e.Col == 18)
                {
                    LR = 0;
                    if (grid1.Cell(grid1.ActiveCell.Row, 1).Text == "new")
                    {
                        clearflexgrid();
                        lockorunlock(grid1.ActiveCell.Row, 0);


                    }
                    else
                    {
                        if (edit == 1)
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = clsDbForReports.constr;
                            SqlDataAdapter sda = new SqlDataAdapter("", con);
                            string s1 = "select   b.recid,convert(nvarchar(30),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve,d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP";
                            string s2 = " from tWarehouse2 a join tFinishedProductsInward b on a.warehousecode= b.storeID";
                            string s3 = " join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tStyleMaster sm on sm.StyleCode =b.stylecode join tCF f on f.CFid =sm.CFid where b.recid=@recid";
                            sda.SelectCommand.CommandText = s1 + s2 + s3;
                            sda.SelectCommand.Parameters.AddWithValue("@recid", Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 0).Text));
                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            grid1.Cell(grid1.ActiveCell.Row, 0).Text = ds.Tables[0].Rows[0]["recid"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 3).Text = ds.Tables[0].Rows[0]["warehouse"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 4).Text = ds.Tables[0].Rows[0]["Date"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 5).Text = ds.Tables[0].Rows[0]["stylecode"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 6).Text = ds.Tables[0].Rows[0]["CorF"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 7).Text = ds.Tables[0].Rows[0]["fabricCode"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 8).Text = ds.Tables[0].Rows[0]["sleeve"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 9).Text = ds.Tables[0].Rows[0]["fit"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 10).Text = ds.Tables[0].Rows[0]["38"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 11).Text = ds.Tables[0].Rows[0]["39"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 12).Text = ds.Tables[0].Rows[0]["40"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 13).Text = ds.Tables[0].Rows[0]["42"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 14).Text = ds.Tables[0].Rows[0]["44"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 15).Text = ds.Tables[0].Rows[0]["Total"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 16).Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                        }
                        grid1.Cell(grid1.ActiveCell.Row, 17).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";
                        lockorunlock(grid1.ActiveCell.Row, 0);
                        edit = 0;
                    }
                }

            }
        }



        private void lstVwStock_Click(object sender, EventArgs e)
        {

        }
        private void lstviewClick(string warehouse)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = " select b.warehouse,a.stylecode,a.FabricCode,c.sleeve,d.fit, a.Q38 [38],a.Q39 [39],a.Q40 [40],a.Q42 [42],a.Q44 [44],";
            string s2 = " cast(mrp AS decimal(18,2)) MRP from tFinishedStock a ";
            string s3 = " join tWarehouse2 b  on a.storeID= b.warehousecode  join tFinishedProductSleeve c  on a.SleeveID= c.sleeveid ";
            string s4 = " join tFinishedProductFit d on a.FitID= d.fitid where a.storeID=@storeid";

        }

        
        


        private void Entry_Click(object sender, EventArgs e)
        {

        }


        //

        private  int insertFpinwardedit()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "storeFPinward";
            cmd.CommandType = CommandType.StoredProcedure;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime dt = Convert.ToDateTime(fgridedit.Cell(fgridedit.ActiveCell.Row, 4).Text);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            cmd.Parameters.AddWithValue("@Edate", dt);
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(fgridedit.ComboBox(3).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 3).Text).ToString()));
            cmd.Parameters.AddWithValue("@sc", fgridedit.ComboBox(5).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 5).Text).ToString());
            cmd.Parameters.AddWithValue("@fc", fgridedit.Cell(fgridedit.ActiveCell.Row, 7).Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(Convert.ToInt32(fgridedit.ComboBox(8).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 8).Text).ToString())));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(fgridedit.ComboBox(9).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 9).Text).ToString())));
            cmd.Parameters.AddWithValue("@Q38", fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text);
            cmd.Parameters.AddWithValue("@Q39", fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text);
            cmd.Parameters.AddWithValue("@Q40", fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text);
            cmd.Parameters.AddWithValue("@Q42", fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text);
            cmd.Parameters.AddWithValue("@Q44", fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text);
            cmd.Parameters.AddWithValue("@mrp", fgridedit.Cell(fgridedit.ActiveCell.Row, 16).Text);
            cmd.Parameters.AddWithValue("@recid", 0).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.Parameters["@recid"].Value);
        }


         private bool IsSpecificationsExistedit()
        {
            int j = fgridedit.ActiveCell.Row;
            bool ret = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select count(*) num  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and mrp=@mrp";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(fgridedit.ComboBox(3).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 3).Text).ToString()));
            sda.SelectCommand.Parameters.AddWithValue("@sc", fgridedit.ComboBox(5).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 5).Text).ToString());
            sda.SelectCommand.Parameters.AddWithValue("@fc", fgridedit.Cell(fgridedit.ActiveCell.Row, 7).Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(fgridedit.ComboBox(8).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 8).Text).ToString()));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(fgridedit.ComboBox(9).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 9).Text).ToString()));
            sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDouble(fgridedit.Cell(fgridedit.ActiveCell.Row, 16).Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) != 0)
            {
                ret = true;
            }
            return ret;

        
        }

         void insertAlledit()
         {
             SqlConnection conWrite = new SqlConnection();
             conWrite.ConnectionString = clsDbForReports.constr;
             conWrite.Open();
             SqlCommand cmd = new SqlCommand("", conWrite);
             cmd.CommandText = "insert tFinishedStock(storeID, stylecode,FabricCode, SleeveID,FitID,Q38,Q39,Q40,Q42,Q44,mrp) values(@stid,@sc,@fc,@sd,@fd,@Q38,@Q39,@Q40,@Q42,@Q44,@mrp)";
             cmd.Parameters.AddWithValue("@stid", (Convert.ToInt32(fgridedit.ComboBox(3).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 3).Text).ToString())));
             cmd.Parameters.AddWithValue("@sc", (fgridedit.ComboBox(5).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 5).Text).ToString()));
             cmd.Parameters.AddWithValue("@fc", fgridedit.Cell(fgridedit.ActiveCell.Row, 7).Text);
             cmd.Parameters.AddWithValue("@sd", (Convert.ToInt32(Convert.ToInt32(fgridedit.ComboBox(8).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 8).Text).ToString()))));
             cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(fgridedit.ComboBox(9).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 9).Text).ToString())));
             cmd.Parameters.AddWithValue("@Q38", fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text);
             cmd.Parameters.AddWithValue("@Q39", fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text);
             cmd.Parameters.AddWithValue("@Q40", fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text);
             cmd.Parameters.AddWithValue("@Q42", fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text);
             cmd.Parameters.AddWithValue("@Q44", fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text);
             cmd.Parameters.AddWithValue("@mrp", fgridedit.Cell(fgridedit.ActiveCell.Row, 16).Text);
             cmd.ExecuteNonQuery();

         }

         void updateAlledit()
         {
             SqlConnection conWrite = new SqlConnection();
             conWrite.ConnectionString = clsDbForReports.constr;
             conWrite.Open();
             SqlCommand cmd = new SqlCommand("", conWrite);
             cmd.CommandText = "update tFinishedStock set Q38=Q38+@Q38,Q39=Q39+@Q39,Q40=Q40+@Q40,Q42=Q42+@Q42,Q44=Q44+@Q44 where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd and mrp=@mrp";
             cmd.Parameters.AddWithValue("@Q38", (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text)));
             cmd.Parameters.AddWithValue("@Q39", (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text)));
             cmd.Parameters.AddWithValue("@Q40", (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text)));
             cmd.Parameters.AddWithValue("@Q42", (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text)));
             cmd.Parameters.AddWithValue("@Q44", (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text)));
             cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(Convert.ToInt32(fgridedit.ComboBox(3).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 3).Text).ToString())));
             cmd.Parameters.AddWithValue("@sc", (fgridedit.ComboBox(5).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 5).Text).ToString()));
             cmd.Parameters.AddWithValue("@fc", fgridedit.Cell(fgridedit.ActiveCell.Row, 7).Text.Trim());
             cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(Convert.ToInt32(fgridedit.ComboBox(8).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 8).Text).ToString())));
             cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(fgridedit.ComboBox(9).GetItemValue(fgridedit.Cell(fgridedit.ActiveCell.Row, 9).Text).ToString())));
             cmd.Parameters.AddWithValue("@mrp", Convert.ToDouble(fgridedit.Cell(fgridedit.ActiveCell.Row, 16).Text));
             int i = cmd.ExecuteNonQuery();
             conWrite.Close();

         }


        void SaveProcessedit()
        {
            if (IsSpecificationsExistedit() == false)
            {
                insertAlledit();
            }

            else
            {
                updateAlledit();


            }

        }


        void Adjuststockedit()
        {
            int i = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 0).Text);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "ReducingStock";
            cmd.Parameters.AddWithValue("@recid", i);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        private void btshow_Click(object sender, EventArgs e)
        {

            fgridedit.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = "select b.recid,convert(nvarchar(10),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve, d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP ";
            string s2 = " from tWarehouse2 a join tFinishedProductsInward b on a.warehousecode= b.storeID join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tStyleMaster sm on sm.StyleCode =b.stylecode  ";
            string s3 = " join tCF f on f.CFid =sm.CFid    where b.EntryDate >=@date1 and b.EntryDate <@date2 order by b.recid desc ";
            sda.SelectCommand.CommandText = s1 + s2 + s3;
            sda.SelectCommand.Parameters.AddWithValue("@date1", Convert.ToDateTime(dtpfrom.Value.ToShortDateString()));
            sda.SelectCommand.Parameters.AddWithValue("@date2", Convert.ToDateTime(dtpto.Value.ToShortDateString()));


            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {


                int j = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    fgridedit.Rows = fgridedit.Rows + 1;
                    j = i + 1;
                    fgridedit.Cell(j, 0).Text = ds.Tables[0].Rows[i]["recid"].ToString();
                    fgridedit.Cell(j, 3).Text = ds.Tables[0].Rows[i]["warehouse"].ToString();
                    fgridedit.Cell(j, 4).Text = ds.Tables[0].Rows[i]["Date"].ToString();
                    fgridedit.Cell(j, 5).Text = ds.Tables[0].Rows[i]["stylecode"].ToString();
                    fgridedit.Cell(j, 6).Text = ds.Tables[0].Rows[i]["CorF"].ToString();
                    fgridedit.Cell(j, 7).Text = ds.Tables[0].Rows[i]["fabricCode"].ToString();
                    fgridedit.Cell(j, 8).Text = ds.Tables[0].Rows[i]["sleeve"].ToString();
                    fgridedit.Cell(j, 9).Text = ds.Tables[0].Rows[i]["fit"].ToString();
                    fgridedit.Cell(j, 10).Text = ds.Tables[0].Rows[i]["38"].ToString();
                    fgridedit.Cell(j, 11).Text = ds.Tables[0].Rows[i]["39"].ToString();
                    fgridedit.Cell(j, 12).Text = ds.Tables[0].Rows[i]["40"].ToString();
                    fgridedit.Cell(j, 13).Text = ds.Tables[0].Rows[i]["42"].ToString();
                    fgridedit.Cell(j, 14).Text = ds.Tables[0].Rows[i]["44"].ToString();
                    fgridedit.Cell(j, 15).Text = ds.Tables[0].Rows[i]["Total"].ToString();
                    fgridedit.Cell(j, 16).Text = ds.Tables[0].Rows[i]["MRP"].ToString();
                    fgridedit.Cell(j, 1).Text = "Edit";
                    fgridedit.Cell(j, 2).Text = "Delete";
                    //grid1.Cell(j, 17).Text = "update";
                    //grid1.Cell(j, 18).Text = "cancel";
                    lockorunlockedit(j, 0);
                    //lockorunlockedit(j + 1, 0);
                }
            }
            else
            {
                fgridedit.Rows = 1;
            }

        }

        private void fgridedit_Click(object Sender, EventArgs e)
        {
            if (fgridedit.ActiveCell.Col == 4)
            {
                fgridedit.Cell(fgridedit.ActiveCell.Row, 4).SetFocus();
            }
            if (fgridedit.ActiveCell.Col == 5)
            {
                fgridedit.Cell(fgridedit.ActiveCell.Row, 5).SetFocus();

            }
            if (fgridedit.ActiveCell.Col == 3)
            {
                fgridedit.Cell(fgridedit.ActiveCell.Row, 3).SetFocus();

            }
            if (fgridedit.ActiveCell.Col == 8)
            {
                fgridedit.Cell(fgridedit.ActiveCell.Row, 8).SetFocus();

            }
            if (fgridedit.ActiveCell.Col == 9)
            {
                fgridedit.Cell(fgridedit.ActiveCell.Row, 9).SetFocus();

            }

        }


        private void lockorunlockedit(int index, int check)
        {
            if (check == 1)
            {
                //grid1.Cell(index, 2).Locked = false;
               fgridedit.Cell(index, 3).Locked = false;
               fgridedit.Cell(index, 4).Locked = false;
               fgridedit.Cell(index, 5).Locked = false;
               fgridedit.Cell(index, 6).Locked = false;
               fgridedit.Cell(index, 7).Locked = false;
               fgridedit.Cell(index, 8).Locked = false;
               fgridedit.Cell(index, 9).Locked = false;
               fgridedit.Cell(index, 10).Locked = false;
                fgridedit.Cell(index, 11).Locked = false;
                fgridedit.Cell(index, 12).Locked = false;
                fgridedit.Cell(index, 13).Locked = false;
                fgridedit.Cell(index, 14).Locked = false;
                fgridedit.Cell(index, 15).Locked = false;
                fgridedit.Cell(index, 16).Locked = false;
                fgridedit.Cell(index, 17).Locked = false;
                fgridedit.Cell(index, 18).Locked = false;
            }
            else
            {
                fgridedit.Cell(index, 1).Locked = true;
                fgridedit.Cell(index, 2).Locked = true;
                fgridedit.Cell(index, 3).Locked = true;
                fgridedit.Cell(index, 4).Locked = true;
                fgridedit.Cell(index, 5).Locked = true;
                fgridedit.Cell(index, 6).Locked = true;
                fgridedit.Cell(index, 7).Locked = true;
                fgridedit.Cell(index, 8).Locked = true;
                fgridedit.Cell(index, 9).Locked = true;
                fgridedit.Cell(index, 10).Locked = true;
                fgridedit.Cell(index, 11).Locked = true;
                fgridedit.Cell(index, 12).Locked = true;
                fgridedit.Cell(index, 13).Locked = true;
                fgridedit.Cell(index, 14).Locked = true;
                fgridedit.Cell(index, 15).Locked = true;
                fgridedit.Cell(index, 16).Locked = true;
                fgridedit.Cell(index, 17).Locked = true;
                fgridedit.Cell(index, 18).Locked = true;

            }

        }

        private void fgridedit_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            e.URL = null;
            e.Changed = true;
            if (e.Col == 1)
            {
                int i = fgridedit.ActiveCell.Row;
                lockorunlockedit(i, 1);
                fgridedit.Cell(fgridedit.ActiveCell.Row, 3).SetFocus();
                fgridedit.Cell(fgridedit.ActiveCell.Row, 17).Text = "update";
                fgridedit.Cell(fgridedit.ActiveCell.Row, 18).Text = "cancel";
                LREdit = 1;

            }
            if (e.Col == 2)
            {
                e.URL = null;
                e.Changed = true;
                var result = MessageBox.Show("Do you want to Delete?", "Delete",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {


                    Adjuststockedit();
                    int i = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 0).Text);
                    DeleteFpInward(i);
                    fgridedit.ActiveCell.ForeColor = Color.Red;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 2).Text = "Deleted";
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 1).Text = "";
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 17).Text = "";
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 18).Text = "";
                }

            }
            if (e.Col == 17)
            {
                ed1 = 0;
                ed2 = 0;
                ed3 = 0;
                ed4 = 0;
                ed5 = 0;



                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 3).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 3).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 4).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 4).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 5).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 5).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 6).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 6).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 7).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 7).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 8).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 8).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 9).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 9).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 10).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 11).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 12).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 13).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 14).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 15).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 15).SetFocus();

                    return;
                }
                if (fgridedit.Cell(fgridedit.ActiveCell.Row, 16).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 16).SetFocus();

                    return;
                }
                else
                {



                    int i1 = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text);
                    int i2 = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text);
                    int i3 = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text);
                    int i4 = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text);
                    int i5 = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text);
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 15).Text = (i1 + i2 + i3 + i4 + i5).ToString();
                    Adjuststockedit();
                    int i = Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 0).Text);
                    DeleteFpInward(i);
                    SaveProcessedit();
                    int value = insertFpinwardedit();
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 0).Text = value.ToString();
                    //flag = 0;
                    //edit = 0;
                    lockorunlockedit(fgridedit.ActiveCell.Row, 0);
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 17).Text = "";
                    fgridedit.Cell(fgridedit.ActiveCell.Row, 18).Text = "";


                }
            }
            if (e.Col == 18)
            {
                SqlConnection con = new SqlConnection();
                            con.ConnectionString = clsDbForReports.constr;
                            SqlDataAdapter sda = new SqlDataAdapter("", con);
                            string s1 = "select   b.recid,convert(nvarchar(30),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve,d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP";
                            string s2 = " from tWarehouse2 a join tFinishedProductsInward b on a.warehousecode= b.storeID";
                            string s3 = " join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tStyleMaster sm on sm.StyleCode =b.stylecode join tCF f on f.CFid =sm.CFid where b.recid=@recid";
                            sda.SelectCommand.CommandText = s1 + s2 + s3;
                            sda.SelectCommand.Parameters.AddWithValue("@recid", Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 0).Text));
                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            fgridedit.Cell(fgridedit.ActiveCell.Row, 0).Text = ds.Tables[0].Rows[0]["recid"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 3).Text = ds.Tables[0].Rows[0]["warehouse"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 4).Text = ds.Tables[0].Rows[0]["Date"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 5).Text = ds.Tables[0].Rows[0]["stylecode"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 6).Text = ds.Tables[0].Rows[0]["CorF"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 7).Text = ds.Tables[0].Rows[0]["fabricCode"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 8).Text = ds.Tables[0].Rows[0]["sleeve"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 9).Text = ds.Tables[0].Rows[0]["fit"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text = ds.Tables[0].Rows[0]["38"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text = ds.Tables[0].Rows[0]["39"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text = ds.Tables[0].Rows[0]["40"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text = ds.Tables[0].Rows[0]["42"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text = ds.Tables[0].Rows[0]["44"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 15).Text = ds.Tables[0].Rows[0]["Total"].ToString();
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 16).Text = ds.Tables[0].Rows[0]["MRP"].ToString();

                            fgridedit.Cell(fgridedit.ActiveCell.Row, 17).Text = "";
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 18).Text = "";
                            lockorunlockedit(fgridedit.ActiveCell.Row, 0);
            }
        }

        private void fgridedit_LeaveCell(object Sender, FlexCell.Grid.LeaveCellEventArgs e)
        {
            try
            {
                etot = 0;
                ed1 = 0;
                ed2 = 0;
                ed3 = 0;
                ed4 = 0;
                ed5 = 0;

                if (e.Col == 10 || e.Col == 11 || e.Col == 12 || e.Col == 13 || e.Col == 14)
                {
                    if (fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text.Trim().Length != 0)
                    {
                        if (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text) >= 0)
                        {

                            ed1 = Convert.ToDouble(fgridedit.Cell(fgridedit.ActiveCell.Row, 10).Text);
                        }
                        else
                        {
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 10).SetFocus();
                            e.Cancel = true;
                            return;

                        }

                    }

                    if (fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text.Trim().Length != 0)
                    {

                        if (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text) >= 0)
                        {

                            ed2 = Convert.ToDouble(fgridedit.Cell(fgridedit.ActiveCell.Row, 11).Text);
                        }
                        else
                        {
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 11).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }

                    if (fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text.Trim().Length != 0)
                    {

                        if (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text) >= 0)
                        {

                            ed3 = Convert.ToDouble(fgridedit.Cell(fgridedit.ActiveCell.Row, 12).Text);
                        }
                        else
                        {
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 12).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }


                    if (fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text.Trim().Length != 0)
                    {
                        if (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text) >= 0)
                        {

                            ed4 = Convert.ToDouble(fgridedit.Cell(fgridedit.ActiveCell.Row, 13).Text);
                        }
                        else
                        {
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 13).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }


                    if (fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text.Trim().Length != 0)
                    {
                        if (Convert.ToInt32(fgridedit.Cell(fgridedit.ActiveCell.Row, 14).Text) >= 0)
                        {

                            ed5 = Convert.ToDouble(grid1.Cell(fgridedit.ActiveCell.Row, 14).Text);
                        }
                        else
                        {
                            fgridedit.Cell(fgridedit.ActiveCell.Row, 14).SetFocus();
                            e.Cancel = true;
                            return;

                        }
                    }

                }
                if (e.Row > 0)
                {
                    etot = ed1 + ed2 + ed3 + ed4 + ed5;
                    if (etot != 0)
                    {
                        fgridedit.Cell(fgridedit.ActiveCell.Row, 15).Text = etot.ToString();
                        //tot = 0;
                    }

                }



            }
            catch (Exception)
            {
            }

        }



    }
      
    }

