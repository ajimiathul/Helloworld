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
    public partial class frmFinishedProductsOutward : Form
    {
        public frmFinishedProductsOutward()
        {
            InitializeComponent();
        }
        int Change = 0;
        int lr = 0;
        int edit = 0;
        int flag = 0;
        double d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, tot = 0;
        int intNum;
        //int q38FromDB = 0, q39FromDB = 0, q40FromDB = 0, q42FromDB = 0, q44FromDB = 0;
        //int q38FromFront = 0, q39FromFront = 0, q40FromFront = 0, q42FromFront = 0, q44FromFront = 0;
        bool formLoading = false;
        private void frmFinishedProductsOutward_Load(object sender, EventArgs e)
        {
            EditFlexNamings();
            FlexNamings();
            formLoading = true;
            LoadWarehouse();
            LoadSleeve();
            LoadFit();
            LoadStyle();
            LoadFabric();
            fillCustomer();
            // showLastEntries();
            formLoading = false;
           // FillMRP();
            validation(10);
            validation2(11);
            validation2(12);
            validation2(13);
            validation2(14);
            validation2(15);
            validation2(16);
            validation2(17);
            validation2(18);
            validation2(19);
            validation2(20);
            loadflexgrid();
           // lockFlex();
            //FlexNamings2();
           // FlexNamings3();
            grid1.Cell(grid1.ActiveCell.Row+1, 1).Text = "new";
            EditLoadFabric();
            EditLoadFit();
            EditLoadSleeve();
            EditLoadStyle();
            EditLoadWarehouse();
            EditfillCustomer();
            //EditFillMRP();

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

        private void FlexNamings()
        {
            grid1.DateFormat = FlexCell.DateFormatEnum.DMY;
            grid1.Cell(0, 3).Text = "WareHouse";
            grid1.Cell(0, 4).Text = "Entry Date";
            grid1.Cell(0, 5).Text = "Style";
            grid1.Cell(0, 6).Text = "Fabric Code";
            grid1.Cell(0, 7).Text = "Sleeve";
            grid1.Cell(0, 8).Text = "Fit";
            grid1.Cell(0, 10).Text = "MRP";
            //grid1.Cell(0, 11).Text = "MRP";
            grid1.Cell(0, 11).Text = "38";
            grid1.Cell(0, 12).Text = "S38";
            grid1.Cell(0, 13).Text = "39";
            grid1.Cell(0, 14).Text = "S39";
            grid1.Cell(0, 15).Text = "40";
            grid1.Cell(0, 16).Text = "S40";
            grid1.Cell(0, 17).Text = "42";
            grid1.Cell(0, 18).Text = "S42";
            grid1.Cell(0, 19).Text = "44";
            grid1.Cell(0, 20).Text = "S44";
            grid1.Cell(0, 21).Text = "Total";
            grid1.Cell(0, 22).Text = "Customer";

            grid1.Column(12).Locked = true;
            grid1.Column(14).Locked = true;
            grid1.Column(16).Locked = true;
            grid1.Column(18).Locked = true;
            grid1.Column(20).Locked = true;
            grid1.Column(21).Locked = true;

            grid1.Column(11).Width = 30;
            grid1.Column(12).Width = 30;
            grid1.Column(13).Width = 30;
            grid1.Column(14).Width = 30;
            grid1.Column(15).Width = 30;
            grid1.Column(16).Width = 30;
            grid1.Column(17).Width = 30;
            grid1.Column(18).Width = 30;
            grid1.Column(19).Width = 30;
            grid1.Column(20).Width = 30;
            grid1.Column(9).Width = 40;
            grid1.Column(23).Width = 80;
            grid1.Column(24).Width = 50;
            grid1.Column(25).Width = 50;
            grid1.Column(21).Width = 40;
            grid1.Column(22).Width = 100;
            grid1.Column(26).Width = 0;
            grid1.Column(27).Width = 0;
            grid1.Column(28).Width = 0;
            grid1.Column(29).Width = 0;
            grid1.Column(30).Width = 0;



            grid1.Column(3).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(4).CellType = FlexCell.CellTypeEnum.Calendar;
            grid1.Column(5).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(6).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(7).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(8).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(10).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(9).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(25).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(22).CellType = FlexCell.CellTypeEnum.ComboBox;
            grid1.Column(1).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(2).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(23).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(24).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Column(1).Width = 40;
            grid1.Column(2).Width = 50;
        }

        



       
        private void LoadWarehouse()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select * from tWarehouse2";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.ComboBox(3).DataSource = ds.Tables[0];
                grid1.ComboBox(3).DisplayMember = "warehouse";
                grid1.ComboBox(3).ValueMember = "warehousecode";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EditLoadWarehouse()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select * from tWarehouse2";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.ComboBox(3).DataSource = ds.Tables[0];
                GridEdit.ComboBox(3).DisplayMember = "warehouse";
                GridEdit.ComboBox(3).ValueMember = "warehousecode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadSleeve()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select sleeveid,sleeve  from tFinishedProductSleeve";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.ComboBox(7).DataSource = ds.Tables[0];
                grid1.ComboBox(7).DisplayMember = "sleeve";
                grid1.ComboBox(7).ValueMember = "sleeveid";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditLoadSleeve()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select sleeveid,sleeve  from tFinishedProductSleeve";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.ComboBox(7).DataSource = ds.Tables[0];
                GridEdit.ComboBox(7).DisplayMember = "sleeve";
                GridEdit.ComboBox(7).ValueMember = "sleeveid";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void fillCustomer()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select Custid,(name+','+address)name from tCustExcecutive";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.ComboBox(22).DataSource = ds.Tables[0];
                grid1.ComboBox(22).DisplayMember = "name";
                grid1.ComboBox(22).ValueMember = "custid";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void EditfillCustomer()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select Custid,(name+','+address)name from tCustExcecutive";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.ComboBox(22).DataSource = ds.Tables[0];
                GridEdit.ComboBox(22).DisplayMember = "name";
                GridEdit.ComboBox(22).ValueMember = "custid";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        private void LoadStyle()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select StyleCode from tStyleMaster";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.ComboBox(5).DataSource = ds.Tables[0];
                grid1.ComboBox(5).DisplayMember = "stylecode";
                grid1.ComboBox(5).ValueMember = "stylecode";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditLoadStyle()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select StyleCode from tStyleMaster";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.ComboBox(5).DataSource = ds.Tables[0];
                GridEdit.ComboBox(5).DisplayMember = "stylecode";
                GridEdit.ComboBox(5).ValueMember = "stylecode";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private void LoadFit()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select fitid,fit  from tFinishedProductFit";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.ComboBox(8).DataSource = ds.Tables[0];
                grid1.ComboBox(8).DisplayMember = "fit";
                grid1.ComboBox(8).ValueMember = "fitid";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void EditLoadFit()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select fitid,fit  from tFinishedProductFit";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.ComboBox(8).DataSource = ds.Tables[0];
                GridEdit.ComboBox(8).DisplayMember = "fit";
                GridEdit.ComboBox(8).ValueMember = "fitid";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void EditLoadFabric()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select distinct(FabricCode) from tFinishedStock";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.ComboBox(6).DataSource = ds.Tables[0];
                GridEdit.ComboBox(6).DisplayMember = "FabricCode";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadFabric()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select distinct(FabricCode) from tFinishedStock";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.ComboBox(6).DataSource = ds.Tables[0];
                grid1.ComboBox(6).DisplayMember = "FabricCode";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FillMRP()
        {
            try
            {
                grid1.ComboBox(10).DataSource = null;
                grid1.ComboBox(10).Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select mrp from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid";

                sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", grid1.Cell(grid1.ActiveCell.Row, 5).Text);
                sda.SelectCommand.Parameters.AddWithValue("@fabcode", grid1.Cell(grid1.ActiveCell.Row, 6).Text);
                sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text)));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid1.ComboBox(10).DataSource = ds.Tables[0];
                    grid1.ComboBox(10).DisplayMember = "mrp";
                    grid1.ComboBox(10).ValueMember = "mrp";
                }
                else
                {
                    MessageBox.Show("No Items found");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           }


        private void EditFillMRP()
        {
            try
            {
            
            GridEdit.ComboBox(10).DataSource = null;
            GridEdit.ComboBox(10).Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select mrp from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid";

            sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(GridEdit.ComboBox(3).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text)));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", grid1.Cell(GridEdit.ActiveCell.Row, 5).Text);
            sda.SelectCommand.Parameters.AddWithValue("@fabcode", grid1.Cell(GridEdit.ActiveCell.Row, 6).Text);
            sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(GridEdit.ComboBox(7).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text)));
            sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(GridEdit.ComboBox(8).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text)));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridEdit.ComboBox(10).DataSource = ds.Tables[0];
                GridEdit.ComboBox(10).DisplayMember = "mrp";
                GridEdit.ComboBox(10).ValueMember = "mrp";
            }
            else
            {
                MessageBox.Show("No Items found");

            }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void stock()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select  Q38,Q39,Q40,Q42,Q44  from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid and mrp= @mrp";

                sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", grid1.Cell(grid1.ActiveCell.Row, 5).Text);
                sda.SelectCommand.Parameters.AddWithValue("@fabcode", grid1.Cell(grid1.ActiveCell.Row, 6).Text);
                sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDecimal(grid1.ComboBox(10).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 10).Text)));
                // sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 10).Text));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.Cell(grid1.ActiveCell.Row, 12).Text = ds.Tables[0].Rows[0]["Q38"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 14).Text = ds.Tables[0].Rows[0]["Q39"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 16).Text = ds.Tables[0].Rows[0]["Q40"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 18).Text = ds.Tables[0].Rows[0]["Q42"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 20).Text = ds.Tables[0].Rows[0]["Q44"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 26).Text = ds.Tables[0].Rows[0]["Q38"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 27).Text = ds.Tables[0].Rows[0]["Q39"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 28).Text = ds.Tables[0].Rows[0]["Q40"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 29).Text = ds.Tables[0].Rows[0]["Q42"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 30).Text = ds.Tables[0].Rows[0]["Q44"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Editstock()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select  Q38,Q39,Q40,Q42,Q44  from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid and mrp= @mrp";

                sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", grid1.Cell(grid1.ActiveCell.Row, 5).Text);
                sda.SelectCommand.Parameters.AddWithValue("@fabcode", grid1.Cell(grid1.ActiveCell.Row, 6).Text);
                sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDecimal(grid1.Cell(grid1.ActiveCell.Row, 10).Text).ToString());
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.Cell(grid1.ActiveCell.Row, 12).Text = ds.Tables[0].Rows[0]["Q38"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 14).Text = ds.Tables[0].Rows[0]["Q39"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 16).Text = ds.Tables[0].Rows[0]["Q40"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 18).Text = ds.Tables[0].Rows[0]["Q42"].ToString();
                grid1.Cell(grid1.ActiveCell.Row, 20).Text = ds.Tables[0].Rows[0]["Q44"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void editcurrentStock()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select  Q38,Q39,Q40,Q42,Q44  from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid and mrp= @mrp";

                sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", grid1.Cell(grid1.ActiveCell.Row, 5).Text);
                sda.SelectCommand.Parameters.AddWithValue("@fabcode", grid1.Cell(grid1.ActiveCell.Row, 6).Text);
                sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDecimal(grid1.Cell(grid1.ActiveCell.Row, 10).Text).ToString());
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int a = Convert.ToInt32(ds.Tables[0].Rows[0]["Q38"].ToString());
                int b = Convert.ToInt32(ds.Tables[0].Rows[0]["Q39"].ToString());
                int c = Convert.ToInt32(ds.Tables[0].Rows[0]["Q40"].ToString());
                int d = Convert.ToInt32(ds.Tables[0].Rows[0]["Q42"].ToString());
                int e = Convert.ToInt32(ds.Tables[0].Rows[0]["Q44"].ToString());
                int a1 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text);
                int b1 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text);
                int c1 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 15).Text);
                int d1 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 17).Text);
                int e1 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 19).Text);
                grid1.Cell(grid1.ActiveCell.Row, 26).Text = (a1 + a).ToString();
                grid1.Cell(grid1.ActiveCell.Row, 27).Text = (b1 + b).ToString();
                grid1.Cell(grid1.ActiveCell.Row, 28).Text = (c1 + c).ToString();
                grid1.Cell(grid1.ActiveCell.Row, 29).Text = (d1 + d).ToString();
                grid1.Cell(grid1.ActiveCell.Row, 30).Text = (e1 + e).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void UpdateFinishedStock()
        {
            try
            {
                SqlConnection conWrite = new SqlConnection();
                conWrite.ConnectionString = clsDbForReports.constr;
                conWrite.Open();
                SqlCommand cmd = new SqlCommand("", conWrite);
                cmd.CommandText = "update tFinishedStock set Q38=Q38-@Q38,Q39=Q39-@Q39,Q40=Q40-@Q40,Q42=Q42-@Q42,Q44=Q44-@Q44 where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd and mrp=@mrp";
                cmd.Parameters.AddWithValue("@Q38", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text)));
                cmd.Parameters.AddWithValue("@Q39", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text)));
                cmd.Parameters.AddWithValue("@Q40", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 15).Text)));
                cmd.Parameters.AddWithValue("@Q42", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 17).Text)));
                cmd.Parameters.AddWithValue("@Q44", (Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 19).Text)));
                cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text)));
                cmd.Parameters.AddWithValue("@sc", grid1.Cell(grid1.ActiveCell.Row, 5).Text);
                cmd.Parameters.AddWithValue("@fc", grid1.Cell(grid1.ActiveCell.Row, 6).Text);
                cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text)));
                cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text)));
                cmd.Parameters.AddWithValue("@mrp", Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 10).Text));
                int i = cmd.ExecuteNonQuery();
                conWrite.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ReverseProcUpdate()
        {
            try
            {
                int i = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 0).Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "ReverseForOutward";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recid", i);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        private int insertFPOutward()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            
            try
            {

               
                cmd.CommandText = "storeFPoutward";
                cmd.CommandType = CommandType.StoredProcedure;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                DateTime dt = Convert.ToDateTime(grid1.Cell(grid1.ActiveCell.Row, 4).Text);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                cmd.Parameters.AddWithValue("@Edate", dt);
                cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(3).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 3).Text))));
                cmd.Parameters.AddWithValue("@sc", grid1.Cell(grid1.ActiveCell.Row, 5).Text);
                cmd.Parameters.AddWithValue("@fc", grid1.Cell(grid1.ActiveCell.Row, 6).Text);
                cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(grid1.ComboBox(7).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 7).Text)));
                cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(grid1.ComboBox(8).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 8).Text))));
                cmd.Parameters.AddWithValue("@Q38", grid1.Cell(grid1.ActiveCell.Row, 11).Text);
                cmd.Parameters.AddWithValue("@Q39", grid1.Cell(grid1.ActiveCell.Row, 13).Text);
                cmd.Parameters.AddWithValue("@Q40", grid1.Cell(grid1.ActiveCell.Row, 15).Text);
                cmd.Parameters.AddWithValue("@Q42", grid1.Cell(grid1.ActiveCell.Row, 17).Text);
                cmd.Parameters.AddWithValue("@Q44", grid1.Cell(grid1.ActiveCell.Row, 19).Text);
                cmd.Parameters.AddWithValue("@mrp", grid1.Cell(grid1.ActiveCell.Row, 10).Text);
                cmd.Parameters.AddWithValue("@custid", grid1.ComboBox(22).GetItemValue(grid1.Cell(grid1.ActiveCell.Row, 22).Text));
                cmd.Parameters.AddWithValue("@recid", 0).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["@recid"].Value);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return Convert.ToInt32(cmd.Parameters["@recid"].Value);

            conWrite.Close();
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnShowOutward_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                string s1 = "select b.recid, b.EntryDate, a.warehouse , b.stylecode, b.fabricCode,c.sleeve, d.fit, b.Q38,b.Q39,b.Q40,b.Q42,b.Q44,cast(b.mrp AS decimal(18,2)) MRP, ";
                string s2 = " (e.name+','+e.address)Customer  from tWarehouse2 a join tFinishedProductsOutward b on a.warehousecode= b.storeID ";
                string s3 = " join tFinishedProductSleeve c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tCustExcecutive e on e.custid= b.CustomerId";
                sda.SelectCommand.CommandText = s1 + s2 + s3;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgvOutward.DataSource = ds.Tables[0];
                dgvOutward.Columns[0].Visible = false;
                dgvOutward.Columns[7].Width = 40;
                dgvOutward.Columns[8].Width = 40;
                dgvOutward.Columns[9].Width = 40;
                dgvOutward.Columns[10].Width = 40;
                dgvOutward.Columns[11].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustExcecutive obj = new frmCustExcecutive();
            obj.ShowDialog();
            fillCustomer();
        }



        private void grid1_Click(object Sender, EventArgs e)
        {
            try
            {

                if (grid1.ActiveCell.Col == 3)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();
                    grid1.Cell(grid1.ActiveCell.Row, 9).Text = "Stock";
                }
                if (grid1.ActiveCell.Col == 4)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 4).SetFocus();

                }

                if (grid1.ActiveCell.Col == 5)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 5).SetFocus();

                }
                if (grid1.ActiveCell.Col == 6)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 6).SetFocus();

                }
                if (grid1.ActiveCell.Col == 7)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 7).SetFocus();

                }
                if (grid1.ActiveCell.Col == 8)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 8).SetFocus();


                }

                if (grid1.ActiveCell.Col == 10)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 10).SetFocus();

                }
                if (grid1.ActiveCell.Col == 22)
                {
                    grid1.Cell(grid1.ActiveCell.Row, 22).SetFocus();
                    grid1.Cell(grid1.ActiveCell.Row, 23).Text = "New Customer";

                }
                if (grid1.ActiveCell.Col == 11)
                {
                    // Editstock();
                }
                if (grid1.ActiveCell.Col == 13)
                {
                    // Editstock();
                }

                if (grid1.ActiveCell.Col == 15)
                {
                    //Editstock();
                }

                if (grid1.ActiveCell.Col == 17)
                {
                    // Editstock();
                }

                if (grid1.ActiveCell.Col == 19)
                {
                    // Editstock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void grid1_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            try
            {

                e.URL = null;
                e.Changed = true;

                if (e.Col == 9)
                {
                    FillMRP();
                    e.URL = null;
                    e.Changed = true;
                }
                if (e.Col == 23)
                {

                    frmCustExcecutive obj = new frmCustExcecutive();
                    obj.ShowDialog();
                    fillCustomer();
                    e.URL = null;
                    e.Changed = true;
                }

                if (e.Col == 1)
                {
                    if (grid1.Cell(grid1.ActiveCell.Row, 1).Text == "Edit")
                    {
                        int i = grid1.ActiveCell.Row;
                        lockorunlock(i, 1);
                        e.URL = null;
                        e.Changed = true;
                        flag = 1;
                        edit = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 23).Text = "New Customer";
                        grid1.Cell(grid1.ActiveCell.Row, 24).Text = "update";
                        grid1.Cell(grid1.ActiveCell.Row, 25).Text = "cancel";
                        lr = 1;
                        Editstock();
                        editcurrentStock();
                    }
                    else
                    {

                        lockorunlock(grid1.ActiveCell.Row, 1);
                        grid1.Cell(grid1.ActiveCell.Row, 3).SetFocus();
                        grid1.Cell(grid1.ActiveCell.Row, 24).Text = "Save";
                        grid1.Cell(grid1.ActiveCell.Row, 25).Text = "Cancel";
                        grid1.Cell(grid1.ActiveCell.Row, 2).Text = "Delete";
                        lr = 1;
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
                        ReverseProcUpdate();
                        DeleteFpOutward();
                        grid1.Cell(grid1.ActiveCell.Row, 2).Text = "Deleted";
                        grid1.Cell(grid1.ActiveCell.Row, 1).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 23).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 24).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 25).Text = "";
                        grid1.ActiveCell.ForeColor = Color.Red;
                        //loadflexgrid();
                        lr = 0;
                    }
                }

                if (e.Col == 24)
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
                        //flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 4).SetFocus();
                        return;
                    }
                    if (grid1.Cell(grid1.ActiveCell.Row, 5).Text.Trim().Length == 0)
                    {
                        //flag = 1;
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
                        // flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 7).SetFocus();

                        return;
                    }
                    if (grid1.Cell(grid1.ActiveCell.Row, 8).Text.Trim().Length == 0)
                    {
                        // flag = 1;
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
                        // e.Cancel = true;
                        return;
                    }
                    if (grid1.Cell(grid1.ActiveCell.Row, 11).Text.Trim().Length == 0)
                    {
                        // flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 11).SetFocus();

                        return;
                    }

                    if (grid1.Cell(grid1.ActiveCell.Row, 13).Text.Trim().Length == 0)
                    {
                        // flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 13).SetFocus();

                        return;
                    }
                    if (grid1.Cell(grid1.ActiveCell.Row, 15).Text.Trim().Length == 0)
                    {
                        // flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 15).SetFocus();
                        return;
                    }
                    if (grid1.Cell(grid1.ActiveCell.Row, 17).Text.Trim().Length == 0)
                    {
                        //flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 17).SetFocus();
                        return;
                    }
                    if (grid1.Cell(grid1.ActiveCell.Row, 19).Text.Trim().Length == 0)
                    {
                        //flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 19).SetFocus();
                        return;
                    }
                    if (grid1.Cell(grid1.ActiveCell.Row, 22).Text.Trim().Length == 0)
                    {
                        // flag = 1;
                        grid1.Cell(grid1.ActiveCell.Row, 22).SetFocus();

                        return;
                    }

                    else
                    {

                        if (edit == 1)
                        {
                            //CheckValidQty();
                            int i1 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text);
                            int i2 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text);
                            int i3 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 15).Text);
                            int i4 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 17).Text);
                            int i5 = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 19).Text);
                            grid1.Cell(grid1.ActiveCell.Row, 21).Text = (i1 + i2 + i3 + i4 + i5).ToString();
                            ReverseProcUpdate();
                            UpdateFinishedStock();
                            int value = insertFPOutward();
                            grid1.Cell(grid1.ActiveCell.Row, 0).Text = value.ToString();
                            flag = 0;
                            edit = 0;
                            lockorunlock(grid1.ActiveCell.Row, 0);
                            grid1.Cell(grid1.ActiveCell.Row, 12).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 14).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 16).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 20).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 24).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 25).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 23).Text = "";
                            lr = 0;

                        }
                        else
                        {
                            if (grid1.Cell(grid1.ActiveCell.Row, 24).Text == "Save")
                            {
                                //CheckValidQty();
                                UpdateFinishedStock();
                                int value = insertFPOutward();
                                grid1.Column(1).Width = 50;
                                grid1.Column(2).Width = 60;
                                grid1.Cell(grid1.ActiveCell.Row, 1).Text = "Edit";
                                grid1.Cell(grid1.ActiveCell.Row, 2).Text = "Delete";
                                //grid1.Cell(grid1.ActiveCell.Row, 24).Text = "update";
                                grid1.Cell(grid1.ActiveCell.Row, 1).Locked = true;
                                grid1.Cell(grid1.ActiveCell.Row, 2).Locked = true;
                                grid1.Cell(grid1.ActiveCell.Row, 0).Text = value.ToString();
                                lockorunlock(grid1.ActiveCell.Row, 0);
                                flag = 0;
                                grid1.Rows = grid1.Rows + 1;
                                grid1.Cell(grid1.ActiveCell.Row + 1, 1).Text = "new";
                                grid1.Cell(grid1.ActiveCell.Row + 1, 1).Locked = true;
                                grid1.Cell(grid1.ActiveCell.Row + 1, 1).SetFocus();
                                grid1.Cell(grid1.ActiveCell.Row, 12).Text = "";
                                grid1.Cell(grid1.ActiveCell.Row, 14).Text = "";
                                grid1.Cell(grid1.ActiveCell.Row, 16).Text = "";
                                grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";
                                grid1.Cell(grid1.ActiveCell.Row, 20).Text = "";
                                grid1.Cell(grid1.ActiveCell.Row, 24).Text = "";
                                grid1.Cell(grid1.ActiveCell.Row, 25).Text = "";
                                grid1.Cell(grid1.ActiveCell.Row, 23).Text = "";
                                lr = 0;
                            }

                        }

                    }


                }
                if (e.Col == 25)
                {
                    if (grid1.Cell(grid1.ActiveCell.Row, 1).Text == "new")
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
                        grid1.Cell(grid1.ActiveCell.Row, 19).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 20).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 21).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 22).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 23).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 24).Text = "";
                        grid1.Cell(grid1.ActiveCell.Row, 25).Text = "";
                        lr = 0;
                        lockorunlock(grid1.ActiveCell.Row, 0);
                    }
                    else
                    {
                        if (edit == 1)
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = clsDbForReports.constr;
                            SqlDataAdapter sda = new SqlDataAdapter("", con);
                            string s1 = "select   b.recid,convert(nvarchar(10),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve,d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP ,";
                            string s2 = "  ce.name+','+ ce.address customer from tWarehouse2 a join tFinishedProductsOutward b on a.warehousecode= b.storeID  join tCustExcecutive ce  on b.CustomerId= ce.custid";
                            string s3 = " join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join  tStyleMaster sm on sm.StyleCode =b.stylecode join tCF f on f.CFid =sm.CFid where b.recid=@recid";
                            sda.SelectCommand.CommandText = s1 + s2 + s3;
                            sda.SelectCommand.Parameters.AddWithValue("@recid", Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 0).Text));
                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            grid1.Cell(grid1.ActiveCell.Row, 0).Text = ds.Tables[0].Rows[0]["recid"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 3).Text = ds.Tables[0].Rows[0]["warehouse"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 4).Text = ds.Tables[0].Rows[0]["Date"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 5).Text = ds.Tables[0].Rows[0]["stylecode"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 9).Text = "Stock";
                            grid1.Cell(grid1.ActiveCell.Row, 6).Text = ds.Tables[0].Rows[0]["fabricCode"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 7).Text = ds.Tables[0].Rows[0]["sleeve"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 8).Text = ds.Tables[0].Rows[0]["fit"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 11).Text = ds.Tables[0].Rows[0]["38"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 13).Text = ds.Tables[0].Rows[0]["39"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 15).Text = ds.Tables[0].Rows[0]["40"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 17).Text = ds.Tables[0].Rows[0]["42"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 19).Text = ds.Tables[0].Rows[0]["44"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 21).Text = ds.Tables[0].Rows[0]["Total"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 10).Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                            grid1.Cell(grid1.ActiveCell.Row, 22).Text = ds.Tables[0].Rows[0]["Customer"].ToString();
                            // grid1.Cell(grid1.ActiveCell.Row, 23).Text = "New Customer";
                            lockorunlock(grid1.ActiveCell.Row, 0);
                            lr = 0;
                            edit = 0;
                            grid1.Cell(grid1.ActiveCell.Row, 12).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 14).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 16).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 18).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 20).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 24).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 25).Text = "";
                            grid1.Cell(grid1.ActiveCell.Row, 23).Text = "";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lockorunlock(int index, int check)
        {
            if (check == 1)
            {
                grid1.Cell(index, 3).Locked = false;
                grid1.Cell(index, 4).Locked = false;
                grid1.Cell(index, 5).Locked = false;
                grid1.Cell(index, 6).Locked = false;
                grid1.Cell(index, 7).Locked = false;
                grid1.Cell(index, 8).Locked = false;
                grid1.Cell(index, 9).Locked = false;
                grid1.Cell(index, 10).Locked = false;
                grid1.Cell(index, 11).Locked = false;
                grid1.Cell(index, 13).Locked = false;
                grid1.Cell(index, 15).Locked = false;
                grid1.Cell(index, 17).Locked = false;
                grid1.Cell(index, 19).Locked = false;
                grid1.Cell(index, 22).Locked = false;
                grid1.Cell(index, 23).Locked = false;
                grid1.Cell(index, 24).Locked = false;
                grid1.Cell(index, 25).Locked = false;
                //grid1.Cell(index, 20).Locked = false;
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
                grid1.Cell(index, 19).Locked = true;
                grid1.Cell(index, 20).Locked = true;
                grid1.Cell(index, 21).Locked = true;
                grid1.Cell(index, 22).Locked = true;
                grid1.Cell(index, 23).Locked = true;
                grid1.Cell(index, 24).Locked = true;
                grid1.Cell(index, 25).Locked = true;
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

                if (e.Col == 10)
                {
                    stock();

                }

                if (e.Col == 15 || e.Col == 11 || e.Col == 17 || e.Col == 13 || e.Col == 19)
                {
                    if (grid1.Cell(grid1.ActiveCell.Row, 11).Text.Trim().Length != 0)
                    {
                        int a = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text);
                        int b = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 26).Text);
                        if (a <= b && Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 11).Text) >= 0)
                        {
                            d1 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 11).Text);
                            grid1.Cell(grid1.ActiveCell.Row, 12).Text = (b - a).ToString();

                        }

                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 11).SetFocus();
                            e.Cancel = true;
                            return;
                        }
                    }


                    if (grid1.Cell(grid1.ActiveCell.Row, 13).Text.Trim().Length != 0)
                    {
                        int a = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text);
                        int b = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 27).Text);
                        if (a <= b && Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 13).Text) >= 0)
                        {
                            d2 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 13).Text);
                            grid1.Cell(grid1.ActiveCell.Row, 14).Text = (b - a).ToString();
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 13).SetFocus();

                            e.Cancel = true;
                            return;
                        }
                    }


                    if (grid1.Cell(grid1.ActiveCell.Row, 15).Text.Trim().Length != 0)
                    {
                        int a = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 15).Text);
                        int b = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 28).Text);
                        if (a <= b && Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 15).Text) >= 0)
                        {
                            d3 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 15).Text);
                            grid1.Cell(grid1.ActiveCell.Row, 16).Text = (b - a).ToString();
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 15).SetFocus();

                            e.Cancel = true;
                            return;
                        }
                    }


                    if (grid1.Cell(grid1.ActiveCell.Row, 17).Text.Trim().Length != 0)
                    {
                        int a = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 17).Text);
                        int b = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 29).Text);
                        if (a <= b && Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 17).Text) >= 0)
                        {
                            d4 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 17).Text);
                            grid1.Cell(grid1.ActiveCell.Row, 18).Text = (b - a).ToString();
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 17).SetFocus();
                            e.Cancel = true;
                            return;
                        }
                    }

                    if (grid1.Cell(grid1.ActiveCell.Row, 19).Text.Trim().Length != 0)
                    {
                        int a = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 19).Text);
                        int b = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 30).Text);
                        if (a <= b && Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 19).Text) >= 0)
                        {
                            d5 = Convert.ToDouble(grid1.Cell(grid1.ActiveCell.Row, 19).Text);
                            grid1.Cell(grid1.ActiveCell.Row, 20).Text = (b - a).ToString();
                        }
                        else
                        {
                            grid1.Cell(grid1.ActiveCell.Row, 19).SetFocus();
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
                        grid1.Cell(grid1.ActiveCell.Row, 21).Text = tot.ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid1_LeaveRow(object Sender, FlexCell.Grid.LeaveRowEventArgs e)
        {
            if (lr == 1)
            {
                e.Cancel = true;
            }

        }

        private void DeleteFpOutward()
        {
            try
            {
                int i = Convert.ToInt32(grid1.Cell(grid1.ActiveCell.Row, 0).Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = " delete from tFinishedProductsOutward where recid= @recid";
                cmd.Parameters.AddWithValue("@recid", i);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void grid1_EnterRow(object Sender, FlexCell.Grid.EnterRowEventArgs e)
        {
            //grid1.Cell(e.Row, 3).SetFocus();
            //grid1.Cell(e.Row, 1).Locked = true;
            //grid1.Cell(e.Row, 2).Locked = true;

        }

        private void loadflexgrid()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                string s1 = "select * from (select top(30) b.recid,  convert(nvarchar(10),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve, d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP, ";
                string s2 = "  ce.name+','+ce.address customer from tWarehouse2 a join tFinishedProductsOutward b on a.warehousecode= b.storeID ";
                string s3 = "join tCustExcecutive ce on ce.custid= b.CustomerId join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tStyleMaster sm on sm.StyleCode =b.stylecode  join tCF f on f.CFid =sm.CFid order by b.recid  desc) z order by z.recid ";
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
                    //grid1.Cell(j, 6).Text = ds.Tables[0].Rows[i]["CorF"].ToString();
                    grid1.Cell(j, 6).Text = ds.Tables[0].Rows[i]["fabricCode"].ToString();
                    grid1.Cell(j, 7).Text = ds.Tables[0].Rows[i]["sleeve"].ToString();
                    grid1.Cell(j, 8).Text = ds.Tables[0].Rows[i]["fit"].ToString();
                    grid1.Cell(j, 11).Text = ds.Tables[0].Rows[i]["38"].ToString();
                    grid1.Cell(j, 13).Text = ds.Tables[0].Rows[i]["39"].ToString();
                    grid1.Cell(j, 15).Text = ds.Tables[0].Rows[i]["40"].ToString();
                    grid1.Cell(j, 17).Text = ds.Tables[0].Rows[i]["42"].ToString();
                    grid1.Cell(j, 19).Text = ds.Tables[0].Rows[i]["44"].ToString();
                    grid1.Cell(j, 21).Text = ds.Tables[0].Rows[i]["Total"].ToString();
                    grid1.Cell(j, 10).Text = ds.Tables[0].Rows[i]["MRP"].ToString();
                    grid1.Cell(j, 22).Text = ds.Tables[0].Rows[i]["customer"].ToString();
                    grid1.Cell(j, 1).Text = "Edit";
                    grid1.Cell(j, 2).Text = "Delete";
                    grid1.Cell(j, 9).Text = "Stock";

                    lockorunlock(j, 0);

                }
                grid1.Cell(j + 1, 1).Text = "new";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            if (grid1.ActiveCell.Col == 10)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 4)
            {
                e.SuppressKeyPress = true;
            }

            if (grid1.ActiveCell.Col == 6)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 7)
            {
                e.SuppressKeyPress = true;
            }
            if (grid1.ActiveCell.Col == 22)
            {
                e.SuppressKeyPress = true;
            }

        }

        private void grid1_Load(object sender, EventArgs e)
        {

        }

        
       
       
                

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Edit Section//


        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                string s1 = "select b.recid,convert(nvarchar(10),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve, d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP ";
                string s2 = " ,tc.name+','+tc.address customer from tWarehouse2 a join tFinishedProductsOutward b on a.warehousecode= b.storeID join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tStyleMaster sm on sm.StyleCode =b.stylecode  ";
                string s3 = " join tCF f on f.CFid =sm.CFid   join tCustExcecutive tc on tc.custid= b.CustomerId  where b.EntryDate >=@date1 and b.EntryDate <@date2 order by b.recid desc ";
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
                        GridEdit.Rows = GridEdit.Rows + 1;
                        j = i + 1;
                        GridEdit.Cell(j, 0).Text = ds.Tables[0].Rows[i]["recid"].ToString();
                        GridEdit.Cell(j, 3).Text = ds.Tables[0].Rows[i]["warehouse"].ToString();
                        GridEdit.Cell(j, 4).Text = ds.Tables[0].Rows[i]["Date"].ToString();
                        GridEdit.Cell(j, 5).Text = ds.Tables[0].Rows[i]["stylecode"].ToString();
                        //grid1.Cell(j, 6).Text = ds.Tables[0].Rows[i]["CorF"].ToString();
                        string s = ds.Tables[0].Rows[i]["fabricCode"].ToString();
                        GridEdit.Cell(j, 6).Text = ds.Tables[0].Rows[i]["fabricCode"].ToString();
                        GridEdit.Cell(j, 7).Text = ds.Tables[0].Rows[i]["sleeve"].ToString();
                        GridEdit.Cell(j, 8).Text = ds.Tables[0].Rows[i]["fit"].ToString();
                        GridEdit.Cell(j, 11).Text = ds.Tables[0].Rows[i]["38"].ToString();
                        GridEdit.Cell(j, 13).Text = ds.Tables[0].Rows[i]["39"].ToString();
                        GridEdit.Cell(j, 15).Text = ds.Tables[0].Rows[i]["40"].ToString();
                        GridEdit.Cell(j, 17).Text = ds.Tables[0].Rows[i]["42"].ToString();
                        GridEdit.Cell(j, 19).Text = ds.Tables[0].Rows[i]["44"].ToString();
                        GridEdit.Cell(j, 21).Text = ds.Tables[0].Rows[i]["Total"].ToString();
                        GridEdit.Cell(j, 10).Text = ds.Tables[0].Rows[i]["MRP"].ToString();
                        GridEdit.Cell(j, 22).Text = ds.Tables[0].Rows[i]["customer"].ToString();
                        GridEdit.Cell(j, 1).Text = "Edit";
                        GridEdit.Cell(j, 2).Text = "Delete";
                        GridEdit.Cell(j, 9).Text = "Stock";

                        lockorunlockEdit(j, 0);

                    }
                }
                else
                {
                    GridEdit.Rows = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void EditFlexNamings()
        {
            GridEdit.DateFormat = FlexCell.DateFormatEnum.DMY;
            GridEdit.Cell(0, 3).Text = "WareHouse";
            GridEdit.Cell(0, 4).Text = "Entry Date";
            GridEdit.Cell(0, 5).Text = "Style";
            GridEdit.Cell(0, 6).Text = "Fabric Code";
            GridEdit.Cell(0, 7).Text = "Sleeve";
            GridEdit.Cell(0, 8).Text = "Fit";
            GridEdit.Cell(0, 10).Text = "MRP";
            //grid1.Cell(0, 11).Text = "MRP";
            GridEdit.Cell(0, 11).Text = "38";
            GridEdit.Cell(0, 12).Text = "S38";
            GridEdit.Cell(0, 13).Text = "39";
            GridEdit.Cell(0, 14).Text = "S39";
            GridEdit.Cell(0, 15).Text = "40";
            GridEdit.Cell(0, 16).Text = "S40";
            GridEdit.Cell(0, 17).Text = "42";
            GridEdit.Cell(0, 18).Text = "S42";
            GridEdit.Cell(0, 19).Text = "44";
            GridEdit.Cell(0, 20).Text = "S44";
            GridEdit.Cell(0, 21).Text = "Total";
            GridEdit.Cell(0, 22).Text = "Customer";

            GridEdit.Column(12).Locked = true;
            GridEdit.Column(14).Locked = true;
            GridEdit.Column(16).Locked = true;
            GridEdit.Column(18).Locked = true;
            GridEdit.Column(20).Locked = true;
            GridEdit.Column(21).Locked = true;

            GridEdit.Column(11).Width = 30;
            GridEdit.Column(12).Width = 30;
            GridEdit.Column(13).Width = 30;
            GridEdit.Column(14).Width = 30;
            GridEdit.Column(15).Width = 30;
            GridEdit.Column(16).Width = 30;
            GridEdit.Column(17).Width = 30;
            GridEdit.Column(18).Width = 30;
            GridEdit.Column(19).Width = 30;
            GridEdit.Column(20).Width = 30;
            GridEdit.Column(9).Width = 40;
            GridEdit.Column(23).Width = 80;
            GridEdit.Column(24).Width = 50;
            GridEdit.Column(25).Width = 50;
            GridEdit.Column(21).Width = 40;
            GridEdit.Column(22).Width = 100;
            GridEdit.Column(26).Width = 0;
            GridEdit.Column(27).Width = 0;
            GridEdit.Column(28).Width = 0;
            GridEdit.Column(29).Width = 0;
            GridEdit.Column(30).Width = 0;



            GridEdit.Column(3).CellType = FlexCell.CellTypeEnum.ComboBox;
            GridEdit.Column(4).CellType = FlexCell.CellTypeEnum.Calendar;
            GridEdit.Column(5).CellType = FlexCell.CellTypeEnum.ComboBox;
            GridEdit.Column(6).CellType = FlexCell.CellTypeEnum.ComboBox;
            GridEdit.Column(7).CellType = FlexCell.CellTypeEnum.ComboBox;
            GridEdit.Column(8).CellType = FlexCell.CellTypeEnum.ComboBox;
            GridEdit.Column(10).CellType = FlexCell.CellTypeEnum.ComboBox;
            GridEdit.Column(9).CellType = FlexCell.CellTypeEnum.HyperLink;
            GridEdit.Column(25).CellType = FlexCell.CellTypeEnum.HyperLink;
            GridEdit.Column(22).CellType = FlexCell.CellTypeEnum.ComboBox;
            GridEdit.Column(1).CellType = FlexCell.CellTypeEnum.HyperLink;
            GridEdit.Column(2).CellType = FlexCell.CellTypeEnum.HyperLink;
            GridEdit.Column(23).CellType = FlexCell.CellTypeEnum.HyperLink;
            GridEdit.Column(24).CellType = FlexCell.CellTypeEnum.HyperLink;
            GridEdit.Column(1).Width = 40;
            GridEdit.Column(2).Width = 50;
        }

        private void lockorunlockEdit(int index, int check)
        {
            if (check == 1)
            {
                GridEdit.Cell(index, 3).Locked = false;
                GridEdit.Cell(index, 4).Locked = false;
                GridEdit.Cell(index, 5).Locked = false;
                GridEdit.Cell(index, 6).Locked = false;
                GridEdit.Cell(index, 7).Locked = false;
                GridEdit.Cell(index, 8).Locked = false;
                GridEdit.Cell(index, 9).Locked = false;
                GridEdit.Cell(index, 10).Locked = false;
                GridEdit.Cell(index, 11).Locked = false;
                GridEdit.Cell(index, 13).Locked = false;
                GridEdit.Cell(index, 15).Locked = false;
                GridEdit.Cell(index, 17).Locked = false;
                GridEdit.Cell(index, 19).Locked = false;
                GridEdit.Cell(index, 22).Locked = false;
                GridEdit.Cell(index, 23).Locked = false;
                GridEdit.Cell(index, 24).Locked = false;
                GridEdit.Cell(index, 25).Locked = false;
                //grid1.Cell(index, 20).Locked = false;
            }
            else
            {
                GridEdit.Cell(index, 2).Locked = true;
                GridEdit.Cell(index, 3).Locked = true;
                GridEdit.Cell(index, 4).Locked = true;
                GridEdit.Cell(index, 5).Locked = true;
                GridEdit.Cell(index, 6).Locked = true;
                GridEdit.Cell(index, 7).Locked = true;
                GridEdit.Cell(index, 8).Locked = true;
                GridEdit.Cell(index, 9).Locked = true;
                GridEdit.Cell(index, 10).Locked = true;
                GridEdit.Cell(index, 11).Locked = true;
                GridEdit.Cell(index, 12).Locked = true;
                GridEdit.Cell(index, 13).Locked = true;
                GridEdit.Cell(index, 14).Locked = true;
                GridEdit.Cell(index, 15).Locked = true;
                GridEdit.Cell(index, 16).Locked = true;
                GridEdit.Cell(index, 17).Locked = true;
                GridEdit.Cell(index, 18).Locked = true;
                GridEdit.Cell(index, 19).Locked = true;
                GridEdit.Cell(index, 20).Locked = true;
                GridEdit.Cell(index, 21).Locked = true;
                GridEdit.Cell(index, 22).Locked = true;
                GridEdit.Cell(index, 23).Locked = true;
                GridEdit.Cell(index, 24).Locked = true;
                GridEdit.Cell(index, 25).Locked = true;
            }

        }

        private void GridEdit_Click(object Sender, EventArgs e)
        {

            if (GridEdit.ActiveCell.Col == 3)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 3).SetFocus();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 9).Text = "Stock";
            }
            if (GridEdit.ActiveCell.Col == 4)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 4).SetFocus();

            }

            if (GridEdit.ActiveCell.Col == 5)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 5).SetFocus();

            }
            if (GridEdit.ActiveCell.Col == 6)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 6).SetFocus();

            }
            if (GridEdit.ActiveCell.Col == 7)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 7).SetFocus();

            }
            if (GridEdit.ActiveCell.Col == 8)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 8).SetFocus();


            }

            if (GridEdit.ActiveCell.Col == 10)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 10).SetFocus();

            }
            if (GridEdit.ActiveCell.Col == 22)
            {
                GridEdit.Cell(GridEdit.ActiveCell.Row, 22).SetFocus();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 23).Text = "New Customer";

            }
        }

        private void Editstockflex()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select  Q38,Q39,Q40,Q42,Q44  from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid and mrp= @mrp";

                sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(GridEdit.ComboBox(3).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", GridEdit.Cell(GridEdit.ActiveCell.Row, 5).Text);
                sda.SelectCommand.Parameters.AddWithValue("@fabcode", GridEdit.Cell(GridEdit.ActiveCell.Row, 6).Text);
                sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(GridEdit.ComboBox(7).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(GridEdit.ComboBox(8).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDecimal(GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text).ToString());
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.Cell(GridEdit.ActiveCell.Row, 12).Text = ds.Tables[0].Rows[0]["Q38"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 14).Text = ds.Tables[0].Rows[0]["Q39"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 16).Text = ds.Tables[0].Rows[0]["Q40"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 18).Text = ds.Tables[0].Rows[0]["Q42"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 20).Text = ds.Tables[0].Rows[0]["Q44"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       
        
        private void editcurrentStock1()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select  Q38,Q39,Q40,Q42,Q44  from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid and mrp= @mrp";

                sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(GridEdit.ComboBox(3).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", GridEdit.Cell(GridEdit.ActiveCell.Row, 5).Text);
                sda.SelectCommand.Parameters.AddWithValue("@fabcode", GridEdit.Cell(GridEdit.ActiveCell.Row, 6).Text);
                sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(GridEdit.ComboBox(7).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(GridEdit.ComboBox(8).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDecimal(GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text).ToString());
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int a = Convert.ToInt32(ds.Tables[0].Rows[0]["Q38"].ToString());
                int b = Convert.ToInt32(ds.Tables[0].Rows[0]["Q39"].ToString());
                int c = Convert.ToInt32(ds.Tables[0].Rows[0]["Q40"].ToString());
                int d = Convert.ToInt32(ds.Tables[0].Rows[0]["Q42"].ToString());
                int e = Convert.ToInt32(ds.Tables[0].Rows[0]["Q44"].ToString());
                int a1 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text);
                int b1 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text);
                int c1 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text);
                int d1 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text);
                int e1 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text);
                GridEdit.Cell(GridEdit.ActiveCell.Row, 26).Text = (a1 + a).ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 27).Text = (b1 + b).ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 28).Text = (c1 + c).ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 29).Text = (d1 + d).ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 30).Text = (e1 + e).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void EditDeleteFpOutward()
        {
            try
            {
                int i = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 0).Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = " delete from tFinishedProductsOutward where recid= @recid";
                cmd.Parameters.AddWithValue("@recid", i);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GridEdit_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            e.URL = null;
            e.Changed = true;
            if (e.Col == 23)
            {

                frmCustExcecutive obj = new frmCustExcecutive();
                obj.ShowDialog();
                fillCustomer();
                e.URL = null;
                e.Changed = true;
            }

            if (e.Col == 1)
            {
                int i = GridEdit.ActiveCell.Row;
                lockorunlockEdit(i, 1);
                e.URL = null;
                e.Changed = true;
                flag = 1;
                edit = 1;
                GridEdit.Cell(GridEdit.ActiveCell.Row, 23).Text = "New Customer";
                GridEdit.Cell(GridEdit.ActiveCell.Row, 24).Text = "update";
                GridEdit.Cell(GridEdit.ActiveCell.Row, 25).Text = "cancel";
                lr = 1;
                Editstockflex();
                editcurrentStock1();
            }

            if (e.Col == 2 )
            {

                e.URL = null;
                e.Changed = true;
                var result = MessageBox.Show("Do you want to Delete?", "Delete",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    EditReverseProcUpdate();
                    EditDeleteFpOutward();
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 2).Text = "Deleted";
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 1).Text = "";
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 23).Text = "";
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 24).Text = "";
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 25).Text = "";
                    GridEdit.ActiveCell.ForeColor = Color.Red;
                    //loadflexgrid();
                    lr = 0;
                }
            }

            if(e.Col==25)
            {
            
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = clsDbForReports.constr;
                        SqlDataAdapter sda = new SqlDataAdapter("", con);
                        string s1 = "select   b.recid,convert(nvarchar(10),b.EntryDate,103) Date, a.warehouse, b.stylecode,f.CorF,b.fabricCode,c.sleeve,d.fit, b.Q38 [38],b.Q39 [39],b.Q40 [40], b.Q42 [42] ,b.Q44 [44],(b.q38+b.q39+b.q40+b.q42+b.q44) Total,cast(b.mrp AS decimal(18,2)) MRP ,";
                        string s2 = "  ce.name+','+ ce.address customer from tWarehouse2 a join tFinishedProductsOutward b on a.warehousecode= b.storeID  join tCustExcecutive ce  on b.CustomerId= ce.custid";
                        string s3 = " join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join  tStyleMaster sm on sm.StyleCode =b.stylecode join tCF f on f.CFid =sm.CFid where b.recid=@recid";
                        sda.SelectCommand.CommandText = s1 + s2 + s3;
                        sda.SelectCommand.Parameters.AddWithValue("@recid", Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 0).Text));
                        DataSet ds = new DataSet();
                        sda.Fill(ds);

                        GridEdit.Cell(GridEdit.ActiveCell.Row, 0).Text = ds.Tables[0].Rows[0]["recid"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text = ds.Tables[0].Rows[0]["warehouse"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 4).Text = ds.Tables[0].Rows[0]["Date"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 5).Text = ds.Tables[0].Rows[0]["stylecode"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 9).Text = "Stock";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 6).Text = ds.Tables[0].Rows[0]["fabricCode"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text = ds.Tables[0].Rows[0]["sleeve"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text = ds.Tables[0].Rows[0]["fit"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text = ds.Tables[0].Rows[0]["38"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text = ds.Tables[0].Rows[0]["39"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text = ds.Tables[0].Rows[0]["40"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text = ds.Tables[0].Rows[0]["42"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text = ds.Tables[0].Rows[0]["44"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 21).Text = ds.Tables[0].Rows[0]["Total"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 22).Text = ds.Tables[0].Rows[0]["Customer"].ToString();
                        // GridEdit.Cell(GridEdit.ActiveCell.Row, 23).Text = "New Customer";
                        lockorunlockEdit(GridEdit.ActiveCell.Row, 0);
                        lr = 0;
                        edit = 0;
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 12).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 14).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 16).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 18).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 20).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 24).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 25).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 23).Text = "";
               }


            if (e.Col == 24)
            {
                d1 = 0;
                d2 = 0;
                d3 = 0;
                d4 = 0;
                d5 = 0;

                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 3).SetFocus();
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 4).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 4).SetFocus();
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 5).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 5).SetFocus();
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 6).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 6).SetFocus();
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 7).SetFocus();

                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 8).SetFocus();

                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 9).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 9).SetFocus();

                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 10).SetFocus();
                    // e.Cancel = true;
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 11).SetFocus();

                    return;
                }

                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 13).SetFocus();

                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 15).SetFocus();
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 17).SetFocus();
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text.Trim().Length == 0)
                {
                    //flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 19).SetFocus();
                    return;
                }
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 22).Text.Trim().Length == 0)
                {
                    // flag = 1;
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 22).SetFocus();

                    return;
                }

                else
                {

                    if (edit == 1)
                    {
                        //CheckValidQty();
                        int i1 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text);
                        int i2 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text);
                        int i3 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text);
                        int i4 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text);
                        int i5 = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text);
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 21).Text = (i1 + i2 + i3 + i4 + i5).ToString();
                        EditReverseProcUpdate();
                        EditUpdateFinishedStock();
                        int value = EditInsertFPOutward();
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 0).Text = value.ToString();
                        flag = 0;
                        edit = 0;
                        lockorunlock(GridEdit.ActiveCell.Row, 0);
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 12).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 14).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 16).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 18).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 20).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 24).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 25).Text = "";
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 23).Text = "";
                        lr = 0;

                    }
                }
            }
        }

        private void EditReverseProcUpdate()
        {
            try
            {

                int i = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 0).Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "ReverseForOutward";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recid", i);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditUpdateFinishedStock()
        {
            try
            {

                SqlConnection conWrite = new SqlConnection();
                conWrite.ConnectionString = clsDbForReports.constr;
                conWrite.Open();
                SqlCommand cmd = new SqlCommand("", conWrite);
                cmd.CommandText = "update tFinishedStock set Q38=Q38-@Q38,Q39=Q39-@Q39,Q40=Q40-@Q40,Q42=Q42-@Q42,Q44=Q44-@Q44 where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd and mrp=@mrp";
                cmd.Parameters.AddWithValue("@Q38", (Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text)));
                cmd.Parameters.AddWithValue("@Q39", (Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text)));
                cmd.Parameters.AddWithValue("@Q40", (Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text)));
                cmd.Parameters.AddWithValue("@Q42", (Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text)));
                cmd.Parameters.AddWithValue("@Q44", (Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text)));
                cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(GridEdit.ComboBox(3).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text)));
                cmd.Parameters.AddWithValue("@sc", GridEdit.Cell(GridEdit.ActiveCell.Row, 5).Text);
                cmd.Parameters.AddWithValue("@fc", GridEdit.Cell(GridEdit.ActiveCell.Row, 6).Text);
                cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(GridEdit.ComboBox(7).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text)));
                cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(GridEdit.ComboBox(8).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text)));
                cmd.Parameters.AddWithValue("@mrp", Convert.ToDouble(GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text));
                int i = cmd.ExecuteNonQuery();
                conWrite.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private int EditInsertFPOutward()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            
            try
            {

                
               
                cmd.CommandText = "storeFPoutward";
                cmd.CommandType = CommandType.StoredProcedure;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                DateTime dt = Convert.ToDateTime(GridEdit.Cell(GridEdit.ActiveCell.Row, 4).Text);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                cmd.Parameters.AddWithValue("@Edate", dt);
                cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(Convert.ToInt32(GridEdit.ComboBox(3).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text))));
                cmd.Parameters.AddWithValue("@sc", GridEdit.Cell(GridEdit.ActiveCell.Row, 5).Text);
                cmd.Parameters.AddWithValue("@fc", GridEdit.Cell(GridEdit.ActiveCell.Row, 6).Text);
                cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(GridEdit.ComboBox(7).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text)));
                cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(Convert.ToInt32(GridEdit.ComboBox(8).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text))));
                cmd.Parameters.AddWithValue("@Q38", GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text);
                cmd.Parameters.AddWithValue("@Q39", GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text);
                cmd.Parameters.AddWithValue("@Q40", GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text);
                cmd.Parameters.AddWithValue("@Q42", GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text);
                cmd.Parameters.AddWithValue("@Q44", GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text);
                cmd.Parameters.AddWithValue("@mrp", GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text);
                cmd.Parameters.AddWithValue("@custid", GridEdit.ComboBox(22).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 22).Text));
                cmd.Parameters.AddWithValue("@recid", 0).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
               
                conWrite.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conWrite.Close();
            return Convert.ToInt32(cmd.Parameters["@recid"].Value);
        }

        private void GridEdit_LeaveCell(object Sender, FlexCell.Grid.LeaveCellEventArgs e)
        {


            tot = 0;
            d1 = 0;
            d2 = 0;
            d3 = 0;
            d4 = 0;
            d5 = 0;

            if (e.Col == 10)
            {
                stockedit();

            }

            if (e.Col == 15 || e.Col == 11 || e.Col == 17 || e.Col == 13 || e.Col == 19)
            {
                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text.Trim().Length != 0)
                {
                    int a = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text);
                    int b = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 26).Text);
                    if (a <= b && Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text) >= 0)
                    {
                        d1 = Convert.ToDouble(GridEdit.Cell(GridEdit.ActiveCell.Row, 11).Text);
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 12).Text = (b - a).ToString();

                    }

                    else
                    {
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 11).SetFocus();
                        e.Cancel = true;
                        return;
                    }
                }


                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text.Trim().Length != 0)
                {
                    int a = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text);
                    int b = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 27).Text);
                    if (a <= b && Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text) >= 0)
                    {
                        d2 = Convert.ToDouble(GridEdit.Cell(GridEdit.ActiveCell.Row, 13).Text);
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 14).Text = (b - a).ToString();
                    }
                    else
                    {
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 13).SetFocus();

                        e.Cancel = true;
                        return;
                    }
                }


                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text.Trim().Length != 0)
                {
                    int a = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text);
                    int b = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 28).Text);
                    if (a <= b && Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text) >= 0)
                    {
                        d3 = Convert.ToDouble(GridEdit.Cell(GridEdit.ActiveCell.Row, 15).Text);
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 16).Text = (b - a).ToString();
                    }
                    else
                    {
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 15).SetFocus();

                        e.Cancel = true;
                        return;
                    }
                }


                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text.Trim().Length != 0)
                {
                    int a = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text);
                    int b = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 29).Text);
                    if (a <= b && Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text) >= 0)
                    {
                        d4 = Convert.ToDouble(GridEdit.Cell(GridEdit.ActiveCell.Row, 17).Text);
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 18).Text = (b - a).ToString();
                    }
                    else
                    {
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 17).SetFocus();
                        e.Cancel = true;
                        return;
                    }
                }

                if (GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text.Trim().Length != 0)
                {
                    int a = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text);
                    int b = Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 30).Text);
                    if (a <= b && Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text) >= 0)
                    {
                        d5 = Convert.ToDouble(GridEdit.Cell(GridEdit.ActiveCell.Row, 19).Text);
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 20).Text = (b - a).ToString();
                    }
                    else
                    {
                        GridEdit.Cell(GridEdit.ActiveCell.Row, 19).SetFocus();
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
                    GridEdit.Cell(GridEdit.ActiveCell.Row, 21).Text = tot.ToString();
                }

            }

        }

        private void stockedit()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select  Q38,Q39,Q40,Q42,Q44  from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid and mrp= @mrp";

                sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(GridEdit.ComboBox(3).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 3).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@stcode", GridEdit.Cell(GridEdit.ActiveCell.Row, 5).Text);
                sda.SelectCommand.Parameters.AddWithValue("@fabcode", GridEdit.Cell(GridEdit.ActiveCell.Row, 6).Text);
                sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(GridEdit.ComboBox(7).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 7).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(GridEdit.ComboBox(8).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 8).Text)));
                sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToDecimal(GridEdit.ComboBox(10).GetItemValue(GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text)));
                // sda.SelectCommand.Parameters.AddWithValue("@mrp", Convert.ToInt32(GridEdit.Cell(GridEdit.ActiveCell.Row, 10).Text));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridEdit.Cell(GridEdit.ActiveCell.Row, 12).Text = ds.Tables[0].Rows[0]["Q38"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 14).Text = ds.Tables[0].Rows[0]["Q39"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 16).Text = ds.Tables[0].Rows[0]["Q40"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 18).Text = ds.Tables[0].Rows[0]["Q42"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 20).Text = ds.Tables[0].Rows[0]["Q44"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 26).Text = ds.Tables[0].Rows[0]["Q38"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 27).Text = ds.Tables[0].Rows[0]["Q39"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 28).Text = ds.Tables[0].Rows[0]["Q40"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 29).Text = ds.Tables[0].Rows[0]["Q42"].ToString();
                GridEdit.Cell(GridEdit.ActiveCell.Row, 30).Text = ds.Tables[0].Rows[0]["Q44"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GridEdit_LeaveRow(object Sender, FlexCell.Grid.LeaveRowEventArgs e)
        {
            if (lr == 1)
            {
                e.Cancel = true;
            }

        }

        }



    }

  




  
    