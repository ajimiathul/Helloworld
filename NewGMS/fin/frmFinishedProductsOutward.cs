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


        private void frmFinishedProductsOutward_Load(object sender, EventArgs e)
        {
            LoadWarehouse();
            LoadSleeve();
            LoadFit();
            LoadStyle();
           
            LoadFabric();
            fillCustomer();
        }
        private void LoadWarehouse()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct(b.warehouse) ,A.storeID from tFinishedStock A join tWarehouse b on A.storeID=b.warehousecode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbWarehouse .DataSource = ds.Tables[0];
            cmbWarehouse.DisplayMember = "warehouse";
            cmbWarehouse.ValueMember = "storeID";
        }

        private void FillR38()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select  distinct(R38) from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid ";
            sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fabcode", cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(cmbFit.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbR38.DataSource = ds.Tables[0];
            cmbR38.DisplayMember = "R38";

        }

        private void FillR40()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct(R40) from tFinishedStock where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid ";
            sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fabcode", cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(cmbFit.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbR40.DataSource = ds.Tables[0];
            cmbR40.DisplayMember = "R40";

        }

        private void FillR42()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct(R42) from tFinishedStock  where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid ";
            sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fabcode", cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(cmbFit.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbR42.DataSource = ds.Tables[0];
            cmbR42.DisplayMember = "R42";

        }

        private void FillR44()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct(R44) from tFinishedStock  where  storeID= @storeid and stylecode= @stcode and FabricCode=@fabcode and SleeveID = @sleevecode  and FitID= @fitid ";
            sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@stcode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fabcode", cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(cmbFit.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbR44.DataSource = ds.Tables[0];
            cmbR44.DisplayMember = "R44";

        }


        private void fillCustomer()
        { 
        
        SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Custid,(name+','+address)name from tCustExcecutive";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbcustomer.DataSource = ds.Tables[0];
            cmbcustomer.DisplayMember = "name";
            cmbcustomer.ValueMember = "custid";
        
        }

        private void LoadStyle()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select  distinct(stylecode) from tFinishedStock";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle .DataSource = ds.Tables[0];
            cmbStyle .DisplayMember = "stylecode";
            cmbStyle .ValueMember = "stylecode";
        }


        private void LoadSleeve()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct(b.sleeve) ,A.SleeveID from tFinishedStock A join tFinishedProductSleeve b on A.SleeveID=b.sleeveid";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSleeve.DataSource = ds.Tables[0];
            cmbSleeve.DisplayMember = "sleeve";
            cmbSleeve.ValueMember = "sleeveid";
        }


        private void LoadFit()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct(b.fit) ,A.FitID from tFinishedStock A join tFinishedProductFit b on A.FitID=b.fitid";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbFit.DataSource = ds.Tables[0];
            cmbFit.DisplayMember = "fit";
            cmbFit.ValueMember = "fitid";
        }

        private void LoadFabric()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct(FabricCode) from tFinishedStock";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbfabcode.DataSource = ds.Tables[0];
            cmbfabcode.DisplayMember = "FabricCode";
       
        }
        private void btnStock_Click(object sender, EventArgs e)
        {
            StockButton();

            FillR38();
            FillR40();
            FillR42();
            FillR44();
          
        }

        private void StockButton()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "Stock";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@storeid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@stylecode", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fabric", cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sleeve", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@FitID", Convert.ToInt32(cmbFit.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvStock.DataSource = ds.Tables[0];
            dgvStock.Columns[0].Width = 80;
            dgvStock.Columns[0].DefaultCellStyle.Format = "0.00";
            dgvStock.Columns[1].Width = 80;
            dgvStock.Columns[2].Width = 80;
            dgvStock.Columns[2].DefaultCellStyle.Format = "0.00";
            dgvStock.Columns[3].Width = 80;
            dgvStock.Columns[4].Width = 80;
            dgvStock.Columns[4].DefaultCellStyle.Format = "0.00";
            dgvStock.Columns[5].Width = 80;
            dgvStock.Columns[6].Width = 80;
            dgvStock.Columns[6].DefaultCellStyle.Format = "0.00";
            dgvStock.Columns[7].Width = 80;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                if (txtQ40.Text == "0" && txtQ38.Text == "0" && txtQ42.Text == "0" && txtQ44.Text == "0")
                {
                    MessageBox.Show("Invalid Entry");

                }
                else
                {
                    SaveProcess();
                    insertFPOutward();
                    StockButton();
                }
            }
            else
            {

                deleteStock();
                DeleteFpOutward();
                if (IsSpecificationsExist() == false)
                {
                    insertAll();
                }

                else
                {
                    chkSizes();
                    PreviousUpdate38();
                    PreviousUpdate40();
                    PreviousUpdate42();
                }
                updateFpOutward();
                fillupdatedstock();
                MessageBox.Show("Update Sucessfully");
                btnSave.Text = "Save";

            }
            ClearControls();
        }
        private void ClearControls()
        {
            txtQ38.Text="0";
            txtQ40.Text = "0";
            txtQ42.Text = "0";
            txtQ44.Text = "0";
           
        }

        private void fillupdatedstock()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = " select * from tFinishedProductsOutward  where recid= @recid";
            sda.SelectCommand.Parameters.AddWithValue("@recid", txtrecid.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvStock.DataSource = ds.Tables[0];

        }

        private void updateFpOutward()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            string s1 = "update tFinishedProductsOutward set  entryDate = @Edate, storeID= @stid , stylecode= @styid , FabricCode = @fabcode, SleeveID=@sleeve, FitID= @fit,";
            string s2 = "Q38 = @q38, R38= @r38, Q40= @q40, R40= @r40,Q42=@q42,R42=@r42, Q44= @q44,R44= @r44 where recid= @recid";
            cmd.CommandText = s1 + s2;
            cmd.Parameters.AddWithValue("recid", Convert.ToInt32(txtrecid.Text));
            cmd.Parameters.AddWithValue("@Edate", dtpEntry.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@styid", cmbStyle.SelectedValue);
            cmd.Parameters.AddWithValue("@fabcode",  cmbfabcode.Text);
            cmd.Parameters.AddWithValue("@sleeve", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fit", Convert.ToInt32(cmbFit.SelectedValue));
            cmd.Parameters.AddWithValue("@q38", txtQ38.Text);
            cmd.Parameters.AddWithValue("@r38", cmbR38.Text);
            cmd.Parameters.AddWithValue("@q40", txtQ40.Text);
            cmd.Parameters.AddWithValue("@r40", cmbR40.Text);
            cmd.Parameters.AddWithValue("@q42", txtQ42.Text);
            cmd.Parameters.AddWithValue("@r42", cmbR42.Text);
            cmd.Parameters.AddWithValue("@q44", txtQ44.Text);
            cmd.Parameters.AddWithValue("@r44", cmbR44.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void DeleteFpOutward()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = " update tFinishedProductsOutward set Q38 = 0, R38= 0, Q40= 0, R40= 0,Q42=0,R42=0, Q44= 0,R44= 0  where recid= @recid";
            cmd.Parameters.AddWithValue("@recid", txtrecid.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void deleteStock()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select * from tFinishedProductsOutward where recid= @recid";
            sda.SelectCommand.Parameters.AddWithValue("@recid", txtrecid.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "ReducingStock";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@storeid", ds.Tables[0].Rows[0][2].ToString());
            cmd.Parameters.AddWithValue("@stcode", ds.Tables[0].Rows[0][3].ToString());
            cmd.Parameters.AddWithValue("@fabcode", ds.Tables[0].Rows[0][4].ToString());
            cmd.Parameters.AddWithValue("@sleevecode", Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString()));
            cmd.Parameters.AddWithValue("@fitid", Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString()));
            cmd.Parameters.AddWithValue("@q38", Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString()));
            cmd.Parameters.AddWithValue("@r38", Convert.ToDecimal(ds.Tables[0].Rows[0][8].ToString()));
            cmd.Parameters.AddWithValue("@q40", Convert.ToInt32(ds.Tables[0].Rows[0][9].ToString()));
            cmd.Parameters.AddWithValue("@r40", Convert.ToDecimal(ds.Tables[0].Rows[0][10].ToString()));
            cmd.Parameters.AddWithValue("@q42", Convert.ToInt32(ds.Tables[0].Rows[0][11].ToString()));
            cmd.Parameters.AddWithValue("@r42", Convert.ToDecimal(ds.Tables[0].Rows[0][12].ToString()));
            cmd.Parameters.AddWithValue("@q44", Convert.ToInt32(ds.Tables[0].Rows[0][13].ToString()));
            cmd.Parameters.AddWithValue("@r44", Convert.ToDecimal(ds.Tables[0].Rows[0][14].ToString()));
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void SaveProcess()
        {
            if (txtQ38.Text.Trim().Length != 0 || cmbR38.Text.Trim().Length != 0)
            {
                if (Convert.ToDecimal(cmbR38.Text) <= 0 || Convert.ToInt32(txtQ38.Text) <= 0)
                {
                    //cmbR38.Text = "0";
                    txtQ38.Text = "0";
                }
            }
            if (txtQ40.Text.Trim().Length != 0 || cmbR40.Text.Trim().Length != 0)
            {
                if (Convert.ToDecimal(cmbR40.Text) <= 0 || Convert.ToInt32(txtQ40.Text) <= 0)
                {
                   // cmbR40.Text = "0";
                    txtQ40.Text = "0";
                }
            }
            if (cmbR42.Text.Trim().Length != 0 || txtQ42.Text.Trim().Length != 0)
            {

                if (Convert.ToDecimal(cmbR42.Text) <= 0 || Convert.ToInt32(txtQ42.Text) <= 0)
                {
                   // cmbR42.Text = "0";
                    txtQ42.Text = "0";
                }

            }
            if (txtQ44.Text.Trim().Length != 0 || cmbR44.Text.Trim().Length != 0)
            {
                if (Convert.ToDecimal(cmbR44.Text) <= 0 || Convert.ToInt32(txtQ44.Text) <= 0)
                
                {
                    //cmbR44.Text = "0";
                    txtQ44.Text = "0";
                }

            }
            if (!(txtQ38.Text == "0" && txtQ40.Text == "0" && txtQ42.Text == "0" && txtQ44.Text == "0" ))
            {
                if (IsSpecificationsExist() == false)
                {
                    insertAll();
                }

                else
                {
                    chkSizes();
                    PreviousUpdate38();
                    PreviousUpdate40();
                    PreviousUpdate42();
                }
            }


        }

        private bool IsSpecificationsExist()
        {
            bool ret = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select count(*) num  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc", cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
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
            cmd.CommandText = "insert tFinishedStock(storeID, stylecode,FabricCode, SleeveID,FitID,Q38,R38,Q40,R40,Q42,R42,Q44,R44) values(@stid,@sc,@fc,@sd,@fd,@Q38,@R38,@Q40,@R40,@Q42,@R42,@Q44,@R44)";
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue);
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            cmd.Parameters.AddWithValue("@Q38", txtQ38.Text);
            cmd.Parameters.AddWithValue("@R38", cmbR38.Text);
            cmd.Parameters.AddWithValue("@Q40", txtQ40.Text);
            cmd.Parameters.AddWithValue("@R40", cmbR40.Text);
            cmd.Parameters.AddWithValue("@Q42", txtQ42.Text);
            cmd.Parameters.AddWithValue("@R42", cmbR42.Text);
            cmd.Parameters.AddWithValue("@Q44", txtQ44.Text);
            cmd.Parameters.AddWithValue("@R44", cmbR44.Text);
            cmd.ExecuteNonQuery();
        }

        private void chkSizes()
        {
            if (txtQ38.Text != "0")
            {
                Check38();
            }
            if (txtQ40.Text != "0")
            {
                Check40();
            }
            if (txtQ42.Text != "0")
            {
                Check42();
            }
            if (txtQ44.Text != "0")
            {
                Check44();
            }
        }

        private void Check38()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select count(*) num  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and (R38=@r38 or R38=0)";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r38", Convert.ToDouble(cmbR38.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                insert38();
            }
            else
            {
                FindSum38();
            }
        }


        private void insert38()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "insert tFinishedStock(storeID, stylecode,FabricCode, SleeveID,FitID,Q38,R38,Q40,R40,Q42,R42,Q44,R44) values(@stid,@sc,@fc,@sd,@fd,@Q38,@R38,@Q40,@R40,@Q42,@R42,@Q44,@R44)";
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue);
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            cmd.Parameters.AddWithValue("@Q38", Convert.ToInt32(txtQ38.Text));
            cmd.Parameters.AddWithValue("@R38", Convert.ToDouble(cmbR38.Text));
            cmd.Parameters.AddWithValue("@Q40", 0);
            cmd.Parameters.AddWithValue("@R40", 0);
            cmd.Parameters.AddWithValue("@Q42", 0);
            cmd.Parameters.AddWithValue("@R42", 0);
            cmd.Parameters.AddWithValue("@Q44", 0);
            cmd.Parameters.AddWithValue("@R44", 0);
            cmd.ExecuteNonQuery();
        }

        private void FindSum38()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select q38 sqty  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and R38=@r38 and r38!= 0";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r38", Convert.ToDouble(cmbR38.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Int32 sqty = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sqty = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            update38(sqty);
        }

        private void update38(Int32 sqty)//0 value creates issues.
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "update tFinishedStock set Q38=@Q38,r38=@R38 where storeID=@stid and rtrim(ltrim(stylecode))=@sc and rtrim(ltrim(FabricCode))=@fc and SleeveID=@sd and FitID=@fd and  (R38=@R38 or R38=0)";
            cmd.Parameters.AddWithValue("@Q38", (sqty-Convert.ToInt32(txtQ38.Text)));
            cmd.Parameters.AddWithValue("@R38", Convert.ToDouble(cmbR38.Text));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue.ToString().Trim());
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }

        //40---------------------------------------------------
        private void Check40()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select count(*) num  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and (R40=@r40 or R40=0)";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r40", Convert.ToDouble(cmbR40.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                insert40();
            }
            else
            {
                FindSum40();
            }
        }


        private void insert40()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "insert tFinishedStock(storeID, stylecode,FabricCode, SleeveID,FitID,Q38,R38,Q40,R40,Q42,R42,Q44,R44) values(@stid,@sc,@fc,@sd,@fd,@Q38,@R38,@Q40,@R40,@Q42,@R42,@Q44,@R44)";
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue);
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            cmd.Parameters.AddWithValue("@Q40", Convert.ToInt32(txtQ40.Text));
            cmd.Parameters.AddWithValue("@R40", Convert.ToDouble(cmbR40.Text));
            cmd.Parameters.AddWithValue("@Q38", 0);
            cmd.Parameters.AddWithValue("@R38", 0);
            cmd.Parameters.AddWithValue("@Q42", 0);
            cmd.Parameters.AddWithValue("@R42", 0);
            cmd.Parameters.AddWithValue("@Q44", 0);
            cmd.Parameters.AddWithValue("@R44", 0);
            cmd.ExecuteNonQuery();
        }

        private void FindSum40()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select q40 sqty  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and R40=@r40 and r40!= 0";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r40", Convert.ToDouble(cmbR40.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Int32 sqty = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sqty = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            update40(sqty);
        }

        private void update40(Int32 sqty)
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "update tFinishedStock set Q40=@Q40,r40=@R40 where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd and  (R40=@R40 or R40=0)";
            cmd.Parameters.AddWithValue("@Q40", (sqty-Convert.ToInt32(txtQ40.Text)));
            cmd.Parameters.AddWithValue("@R40", Convert.ToDouble(cmbR40.Text));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue.ToString().Trim());
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }
        //42---------------------------------------------------------------
        private void Check42()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select count(*) num  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and (R42=@r42 or R42=0)";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r42", Convert.ToDouble(cmbR42.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                insert42();
            }
            else
            {
                FindSum42();
            }
        }


        private void insert42()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "insert tFinishedStock(storeID, stylecode,FabricCode, SleeveID,FitID,Q38,R38,Q40,R40,Q42,R42,Q44,R44) values(@stid,@sc,@fc,@sd,@fd,@Q38,@R38,@Q40,@R40,@Q42,@R42,@Q44,@R44)";
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue);
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            cmd.Parameters.AddWithValue("@Q42", Convert.ToInt32(txtQ42.Text));
            cmd.Parameters.AddWithValue("@R42", Convert.ToDouble(cmbR42.Text));
            cmd.Parameters.AddWithValue("@Q40", 0);
            cmd.Parameters.AddWithValue("@R40", 0);
            cmd.Parameters.AddWithValue("@Q38", 0);
            cmd.Parameters.AddWithValue("@R38", 0);
            cmd.Parameters.AddWithValue("@Q44", 0);
            cmd.Parameters.AddWithValue("@R44", 0);
            cmd.ExecuteNonQuery();
        }

        private void FindSum42()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select q42 sqty  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and R42=@r42 and r42!= 0";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r42", Convert.ToDouble(cmbR42.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Int32 sqty = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sqty = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            update42(sqty);
        }

        private void update42(Int32 sqty)
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "update tFinishedStock set Q42=@Q42,r42=@R42 where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd and  (R42=@R42 or R42=0)";
            cmd.Parameters.AddWithValue("@Q42", (sqty-Convert.ToInt32(txtQ42.Text)));
            cmd.Parameters.AddWithValue("@R42", Convert.ToDouble(cmbR42.Text));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue.ToString().Trim());
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }
        //44---------------------------------------------------
        private void Check44()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select count(*) num  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and (R44=@r44 or R44=0)";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r44", Convert.ToDouble(cmbR44.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                insert44();
            }
            else
            {
                FindSum44();
            }
        }


        private void insert44()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "insert tFinishedStock(storeID, stylecode,FabricCode, SleeveID,FitID,Q38,R38,Q40,R40,Q42,R42,Q44,R44) values(@stid,@sc,@fc,@sd,@fd,@Q38,@R38,@Q40,@R40,@Q42,@R42,@Q44,@R44)";
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue);
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            cmd.Parameters.AddWithValue("@Q44", Convert.ToInt32(txtQ44.Text));
            cmd.Parameters.AddWithValue("@R44", Convert.ToDouble(cmbR44.Text));
            cmd.Parameters.AddWithValue("@Q40", 0);
            cmd.Parameters.AddWithValue("@R40", 0);
            cmd.Parameters.AddWithValue("@Q42", 0);
            cmd.Parameters.AddWithValue("@R42", 0);
            cmd.Parameters.AddWithValue("@Q38", 0);
            cmd.Parameters.AddWithValue("@R38", 0);
            cmd.ExecuteNonQuery();
        }

        private void FindSum44()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select q44 sqty  from tFinishedStock where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID =@sd and FitID=@fd and R44=@r44 and r44!= 0";
            sda.SelectCommand.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sc", cmbStyle.Text);
            sda.SelectCommand.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@r44", Convert.ToDouble(cmbR44.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);

            Int32 sqty = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sqty = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }

            update44(sqty);
        }

        private void update44(Int32 sqty)
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "update tFinishedStock set Q44=@Q44,r44=@R44 where storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd and  (R44=@R44 or R44=0)";
            cmd.Parameters.AddWithValue("@Q44", (sqty-Convert.ToInt32(txtQ44.Text)));
            cmd.Parameters.AddWithValue("@R44", Convert.ToDouble(cmbR44.Text));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue.ToString().Trim());
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }

        private void PreviousUpdate38()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            string s1 = " update tFinishedStock set Q38 =B.Q38,R38 = B.R38   from tFinishedStock A, ";
            string s2 = " (select distinct Q38 , R38  from tFinishedStock ";
            string s3 = "  where R38 = @R38 and R38 !=0 and storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd) B ";
            string s4 = " where  A.R38 = 0 and  A.storeID=@stid and A.stylecode=@sc and A.FabricCode=@fc and A.SleeveID=@sd and A.FitID=@fd  ";
            cmd.CommandText = s1 + s2 + s3 + s4;
            cmd.Parameters.AddWithValue("@Q38", Convert.ToInt32(txtQ38.Text));
            cmd.Parameters.AddWithValue("@R38", Convert.ToDouble(cmbR38.Text));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue.ToString().Trim());
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }

        private void PreviousUpdate40()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            string s1 = " update tFinishedStock set Q40 =B.Q40,R40 = B.R40   from tFinishedStock A, ";
            string s2 = " (select distinct Q40 , R40  from tFinishedStock ";
            string s3 = "  where R40 = @R40 and R40 !=0 and storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd) B ";
            string s4 = " where  A.R40 = 0 and  A.storeID=@stid and A.stylecode=@sc and A.FabricCode=@fc and A.SleeveID=@sd and A.FitID=@fd  ";
            cmd.CommandText = s1 + s2 + s3 + s4;
            cmd.Parameters.AddWithValue("@Q40", Convert.ToInt32(txtQ40.Text));
            cmd.Parameters.AddWithValue("@R40", Convert.ToDouble(cmbR40.Text));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue.ToString().Trim());
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }

        private void PreviousUpdate42()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            string s1 = " update tFinishedStock set Q42 =B.Q42,R42 = B.R42   from tFinishedStock A, ";
            string s2 = " (select distinct Q42 , R42  from tFinishedStock ";
            string s3 = "  where R42 = @R42 and R42 !=0 and storeID=@stid and stylecode=@sc and FabricCode=@fc and SleeveID=@sd and FitID=@fd) B ";
            string s4 = " where  A.R42 = 0 and  A.storeID=@stid and A.stylecode=@sc and A.FabricCode=@fc and A.SleeveID=@sd and A.FitID=@fd  ";
            cmd.CommandText = s1 + s2 + s3 + s4;
            cmd.Parameters.AddWithValue("@Q42", Convert.ToInt32(txtQ42.Text));
            cmd.Parameters.AddWithValue("@R42", Convert.ToDouble(cmbR42.Text));
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue.ToString().Trim());
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text.Trim());
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            int i = cmd.ExecuteNonQuery();
            conWrite.Close();
        }
        private void insertFPOutward()
        {
            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("", conWrite);
            cmd.CommandText = "insert tFinishedProductsOutward(EntryDate,storeID, stylecode,FabricCode, SleeveID,FitID,Q38,R38,Q40,R40,Q42,R42,Q44,R44,CustomerId) values(@Edate,@stid,@sc,@fc,@sd,@fd,@Q38,@R38,@Q40,@R40,@Q42,@R42,@Q44,@R44,@custid)";
            cmd.Parameters.AddWithValue("@Edate", dtpEntry.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@stid", Convert.ToInt32(cmbWarehouse.SelectedValue));
            cmd.Parameters.AddWithValue("@sc", cmbStyle.SelectedValue);
            cmd.Parameters.AddWithValue("@fc",  cmbfabcode.Text);
            cmd.Parameters.AddWithValue("@sd", Convert.ToInt32(cmbSleeve.SelectedValue));
            cmd.Parameters.AddWithValue("@fd", Convert.ToInt32(cmbFit.SelectedValue));
            cmd.Parameters.AddWithValue("@Q38", txtQ38.Text);
            cmd.Parameters.AddWithValue("@R38", cmbR38.Text);
            cmd.Parameters.AddWithValue("@Q40", txtQ40.Text);
            cmd.Parameters.AddWithValue("@R40", cmbR40.Text);
            cmd.Parameters.AddWithValue("@Q42", txtQ42.Text);
            cmd.Parameters.AddWithValue("@R42", cmbR42.Text);
            cmd.Parameters.AddWithValue("@Q44", txtQ44.Text);
            cmd.Parameters.AddWithValue("@R44", cmbR44.Text);
            cmd.Parameters.AddWithValue("@custid", cmbcustomer.SelectedValue);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved Sucessfully");
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            ClearControls();
            dgvStock.DataSource = null;
            tabControl1.SelectedTab = Entery;
            btnSave.Enabled = true;
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

       

        private void cmbR38_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, cmbR38.Text);
        }

        private void txtQ38_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtQ38.Text);
        }

        private void cmbR40_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, cmbR40.Text);
        }

        private void txtQ40_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtQ40.Text);
        }

        private void cmbR42_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, cmbR42.Text);

        }

        private void txtQ42_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtQ42.Text);
        }

        private void cmbR44_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, cmbR44.Text);
        }

        private void txtQ44_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtQ44.Text);
        }

      
        private void History_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
        }

       
        private void tabControl1_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == History)
            {

                btnSave.Enabled = false;
            }
            if (tabControl1.SelectedTab == Entery)
            {

                FillR38();
                FillR40();
                FillR42();
                FillR44();
                btnSave.Enabled = true;
            } 
        }

        private void btnstk_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString= clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("",con);
            string s1 ="select b.warehouse,a.stylecode,a.FabricCode,c.sleeve,d.fit, a.Q38,a.R38,a.Q40,a.R40,a.Q42,a.R42,a.Q44,a.R44 from tFinishedStock a ";
            string s2 = " join tWarehouse b  on a.storeID= b.warehousecode  join tFinishedProductSleeve c  on a.SleeveID= c.sleeveid ";
            string s3 = "join tFinishedProductFit d on a.FitID= d.fitid;";
            sda.SelectCommand.CommandText = s1 + s2 + s3;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvoutstock.DataSource = ds.Tables[0];

        }

        private void dgvOutward_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i > -1)
            {
                cmbWarehouse.Text = dgvOutward.Rows[i].Cells[2].Value.ToString();
                cmbStyle.Text = dgvOutward.Rows[i].Cells[3].Value.ToString();
                cmbFit.Text = dgvOutward.Rows[i].Cells[6].Value.ToString();
                cmbfabcode.Text = dgvOutward.Rows[i].Cells[4].Value.ToString();
                cmbSleeve.Text = dgvOutward.Rows[i].Cells[5].Value.ToString();
                dtpEntry.Value = Convert.ToDateTime(dgvOutward.Rows[i].Cells[1].Value);
                txtQ38.Text = dgvOutward.Rows[i].Cells[7].Value.ToString();
                cmbR38.Text = dgvOutward.Rows[i].Cells[8].Value.ToString();
                cmbR40.Text = dgvOutward.Rows[i].Cells[10].Value.ToString();
                txtQ40.Text = dgvOutward.Rows[i].Cells[9].Value.ToString();
                txtQ42.Text = dgvOutward.Rows[i].Cells[11].Value.ToString();
                cmbR42.Text = dgvOutward.Rows[i].Cells[12].Value.ToString();
                txtQ44.Text = dgvOutward.Rows[i].Cells[13].Value.ToString();
                cmbR44.Text = dgvOutward.Rows[i].Cells[14].Value.ToString();
                txtrecid.Text = dgvOutward.Rows[i].Cells[0].Value.ToString();
                cmbcustomer.Text = dgvOutward.Rows[i].Cells[15].Value.ToString();
                tabControl1.SelectedTab = Entery;
                FillR38();
                FillR40();
                FillR42();
                FillR44();
                btnSave.Enabled = true;
                btnSave.Text = "Update";
                // dgvStock.Visible = false;
            }
        }

        private void btnShowOutward_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = "select b.recid, b.EntryDate, a.warehouse  , b.stylecode, b.fabricCode,c.sleeve, d.fit, b.Q38,b.R38, b.Q40,b.R40, b.Q42,b.R42,b.Q44,b.R44,";
            string s2 = " (e.name+','+e.address)Customer  from tWarehouse a join tFinishedProductsOutward b on a.warehousecode= b.storeID ";
            string s3 = "join tFinishedProductSleeve  c on c.sleeveid= b.SleeveID join tFinishedProductFit d on d.fitid= b.FitID join tCustExcecutive e on e.custid= b.CustomerId";
            sda.SelectCommand.CommandText = s1 + s2 + s3;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvOutward.DataSource = ds.Tables[0];
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustExcecutive obj = new frmCustExcecutive();
            obj.ShowDialog();
            fillCustomer();
        }


        }
    }



  
    