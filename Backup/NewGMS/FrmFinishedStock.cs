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
    public partial class FrmFinishedStock : Form
    {
        public FrmFinishedStock()
        {
            InitializeComponent();
        }

        string selflds1 = "";
        string selflds2 = "";
        string selflds3 = "";
        string selflds4 = "";
        string selflds5 = "";
        string selflds6 = "";
        string selflds7 = "";

        int a1 = 0;
        int a2 = 0;
        int a3 = 0;
        int a4 = 0;
        int a5 = 0;
        int a6 = 0;
        int a7 = 0;

        private void FrmFinishedStock_Load(object sender, EventArgs e)
        {
            
            
            LoadWarehouse();
            LoadStyle();
            LoadSleeve();
            LoadFit();
            Loadcasform();
            Loadmrp();
            loadfabric();
            cmbwarehouse.Enabled = false;
            chkwarehouse.Checked = true;
            cmbStyle.Enabled = false;
            chkStyle.Checked = true;
            cmbfit.Enabled = false;
            chkfit.Checked  = true;
            cmbsleeve.Enabled = false;
            chkSleeve.Checked = true;
            cmbmrp.Enabled = false;
            chkmrp.Checked = true;
            cmbcasform.Enabled = false;
            ckbcasform.Checked = true;
            cmbfabric.Enabled = false;
            chbfabric.Checked = true;
            //cmbmrp.Text = "";
           
          

        }

        private void LoadWarehouse()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select warehousecode,warehouse  from twarehouse2 union select 0,'' ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
           cmbwarehouse .DataSource = ds.Tables[0];
           cmbwarehouse.DisplayMember = "warehouse";
           cmbwarehouse.ValueMember = "warehousecode";
           con.Close();
        }

        private void LoadStyle()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select stylecode  from tstyleMaster union select ''";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbStyle  .DataSource = ds.Tables[0];
            cmbStyle.DisplayMember = "stylecode";
            cmbStyle.ValueMember = "stylecode";
            con.Close();
         
        }

        private void LoadSleeve()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select sleeveid,sleeve  from tFinishedProductSleeve union select 0,''";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbsleeve.DataSource = ds.Tables[0];
            cmbsleeve.DisplayMember = "sleeve";
            cmbsleeve.ValueMember = "sleeveid";
            con.Close();
        }        
        
       
        private void LoadFit()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select fitid,fit  from tFinishedProductFit union select 0,''";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbfit .DataSource = ds.Tables[0];
            cmbfit.DisplayMember = "fit";
            cmbfit.ValueMember = "fitid";
            con.Close();
        }

        private void Loadcasform()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand .CommandText ="select CFid ,CorF  from tCF union select 0,''";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbcasform.DataSource = ds.Tables[0];
            cmbcasform.DisplayMember = "CorF";
            cmbcasform.ValueMember = "CFid";
            con.Close();
        }
        private void Loadmrp()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct str(mrp,6,2)mrp from tFinishedProductsInward union select ''";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbmrp.DataSource = ds.Tables[0];
            cmbmrp.DisplayMember = "mrp";
            cmbmrp.ValueMember = "mrp";
            con.Close();
        }
        private void loadfabric()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct FabricCode from tFinishedProductsInward union select ''";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbfabric.DataSource = ds.Tables[0];
            cmbfabric.DisplayMember = "FabricCode";
            cmbfabric.ValueMember = "FabricCode";
            con.Close();

        }



        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();

           
            string where1 = "";
            string where2 = "";
            string where3 = "";
            string where4 = "";
            string where5 = "";
            string where6 = "";
            string where7 = "";
            int sflds = 0;            
           

            string selfldtot1 = "";
            string selfldtot5 = "";
            string selfldtot2 = "";
            string selfldtot3 = "";
            string selfldtot4 = "";
            string selfldtot6 = "";
            string selfldtot7 = "";

            //1
            if (chkwarehouse.Checked == true)
            {
                selflds1 = "B.warehouse";
                selfldtot1 = "''";
                sflds = sflds + 1;
                a1 = sflds;
            }
            else
            {
                if (cmbwarehouse.Text.Trim().Length != 0)
                {
                    selflds1 = "B.warehouse";
                    selfldtot1 = "''";
                    where1 = " and A.storeid=" + cmbwarehouse.SelectedValue;
                    sflds = sflds + 1;
                    a1 = sflds;
                }
                else
                {
                    where1 = " ";
                    selflds1 = " ";
                     selfldtot1 = "";
                }
            }
            //2
            if (chkStyle.Checked == true)
            {
                if (sflds != 0)
                {
                    selflds2 = ",A.stylecode";
                    selfldtot2 = ",''";
                }
                else
                {
                    selflds2 = "A.stylecode";
                    selfldtot2 = "''";
                }
                sflds = sflds + 1;
                a2 = sflds;
            }
            else
            {
                if (cmbStyle.Text.Trim().Length != 0)
                {
                    if (sflds != 0)
                    {
                        selflds2 = ",A.stylecode";
                        selfldtot2 = ",''";
                    }
                    else
                    {
                        selflds2 = "A.stylecode";
                        selfldtot2 = "''";
                    }
                    sflds = sflds + 1;
                    a2 = sflds;
                    where2 = " and A.stylecode ='" + cmbStyle.Text + "'";
                }
                else
                {
                    where2 = " ";
                    selflds2 = " ";
                    selfldtot2 = " ";
                }
            }

            //3
            if (chkSleeve.Checked == true)
            {
                if (sflds != 0)
                {
                    selflds3 = ",C.sleeve";
                    selfldtot3 = ",''";
                }
                else
                {
                    selflds3 = "C.sleeve";
                    selfldtot3 = "''";
                }
                sflds = sflds + 1;
                a3 = sflds;
            }
            else
            {
                if (cmbsleeve.Text.Trim().Length != 0)
                {
                    if (sflds != 0)
                    {
                        selflds3 = ",C.sleeve";
                        selfldtot3 = ",''";
                    }
                    else
                    {
                        selflds3 = "C.sleeve";
                        selfldtot3 = "''";
                    }
                    sflds = sflds + 1;
                    a3 = sflds;
                    where3 = " and A.SleeveID =" + cmbsleeve.SelectedValue;
                }
                else
                {
                    where3 = " ";
                    selflds3 = " ";
                    selfldtot3 = " ";
                }
            }
            //4
            if (chkfit.Checked == true)
            {
                if (sflds != 0)
                {
                    selflds4 = ",fit";
                    selfldtot4 = ",''";
                }
                else
                {
                    selflds4 = "fit";
                    selfldtot4 = "''";
                }
                sflds = sflds + 1;
                a4 = sflds;
            }
            else
            {
                if (cmbfit.Text.Trim().Length != 0)
                {
                    if (sflds != 0)
                    {
                        selflds4 = ",D.fit";
                        selfldtot4 = ",''";
                    }
                    else
                    {
                        selflds4 = "D.fit";
                        selfldtot4 = "''";
                    }
                    sflds = sflds + 1;
                    a4 = sflds;
                    where4 = " and A.FitID =" + cmbfit.SelectedValue ;
                }
                else
                {
                    where4 = " ";
                    selflds4 = " ";
                    selfldtot4 = " ";
                }
            }
            //5
            string gpsel = "";
            if (chkmrp.Checked == true)
            {
                
                if (sflds != 0)
                {
                    selflds5 = ",str(mrp,6,2) mrp";
                     gpsel = ",mrp";
                    selfldtot5 = ",''";
                }
                else
                {
                    selflds5 = "str(mrp,6,2) mrp";
                    gpsel = "mrp";
                    selfldtot5 = "''";
                }
                sflds = sflds + 1;
                a5 = sflds;
            }
            else
            {
                if (cmbmrp.Text.Trim().Length != 0)
                {
                    if (sflds != 0)
                    {
                        gpsel = ",mrp";
                        selflds5 = ",str(mrp,6,2) mrp";
                        selfldtot5 = ",''";
                    }
                    else
                    {
                        selflds5 = "str(mrp,6,2) mrp";
                        gpsel = "mrp";
                        selfldtot5 = "''";
                    }
                    sflds = sflds + 1;
                    a5 = sflds;
                    where5 = " and A.mrp ='" + cmbmrp.Text + "'";
                }
                else
                {

                    where5 = " ";
                    selflds5 = " ";
                    selfldtot5 = "";

                }
            }

            //6
            if (chbfabric.Checked == true)
            {
                if (sflds != 0)
                {
                    selflds6 = ",A.FabricCode";
                    selfldtot6 = ",''";
                }
                else
                {
                    selflds6 = "A.FabricCode";
                    selfldtot6 = "''";
                }
                sflds = sflds + 1;
                a6 = sflds;
            }
            else
            {
                if (cmbfabric.Text.Trim().Length != 0)
                {
                    if (sflds != 0)
                    {
                        selflds6 = ",A.FabricCode";
                        selfldtot6 = ",''";
                    }
                    else
                    {
                        selflds6 = "A.FabricCode";
                        selfldtot6 = "''";
                    }
                    sflds = sflds + 1;
                    a6 = sflds;
                    where6 = " and A.FabricCode ='" + cmbfabric.Text + "'";
                }
                else
                {

                    where6 = " ";
                    selflds6 = " ";
                    selfldtot6 = " ";

                }
            }
            //7

            if (ckbcasform.Checked == true)
            {
                if (sflds != 0)
                {
                    selflds7 = ",cf.CorF";
                    selfldtot7 = ",''";
                }
                else
                {
                    selflds7 = "cf.CorF";
                    selfldtot7 = "''";
                }
                sflds = sflds + 1;
                a7 = sflds;
            }
            else
            {
                if (cmbcasform.Text.Trim().Length != 0)
                {
                    if (sflds != 0)
                    {
                        selflds7 = ",cf.CorF";
                        selfldtot7 = ",''";
                    }
                    else
                    {
                        selflds7 = "cf.CorF";
                        selfldtot7 = "''";
                    }
                    sflds = sflds + 1;
                    a7 = sflds;
                    where7 = " and sm.CFid =" + cmbcasform.SelectedValue;
                }
                else
                {

                    where7 = " ";
                    selflds7 = " ";
                    selfldtot7 = " ";

                }
            }

            
            //--
            string chkString = selflds1 + selflds2 + selflds3 + selflds4+ selfldtot5 + selfldtot6 + selfldtot7 ;
            if (chkString.Trim().Length != 0)
            {
                string sumString = " ,sum(q38) [38],sum(q39) [39], sum(q40) [40], sum(q42) [42], sum(q44) [44],(sum(q38)+sum(q39)+ sum(q40) + sum(q42)+ sum(q44))TOTAL ,(sum(mrp*q38)+sum(mrp*q39)+sum(mrp*q40)+sum(mrp*q42)+sum(mrp*q44)) Amount";
                string sqlString = "select * from (select 'View' viewdetails ," + selflds1 + selflds2 + selflds3 + selflds4 + selflds5 + selflds6 + selflds7 + sumString + " ,0 as ord " + "  from tFinishedStock A ,twarehouse2 B,tFinishedProductSleeve C,tFinishedProductFit D ,tStyleMaster sm ,tCF cf  where A.recid <> 0  " + where1 + where2 + where3 + where4 + where5 + where6 + where7 + " and A.storeID = B.warehousecode and A.SleeveID=C.sleeveid and A.FitID=D.fitid and sm.StyleCode =A.stylecode and sm.CFid=cf.CFid  group by " + selflds1 + selflds2 + selflds3 + selflds4 + gpsel + selflds6 + selflds7;
                string sqlstring2 = "  union select 'Total', " + selfldtot1 + selfldtot2 + selfldtot3 + selfldtot4 + selfldtot5 + selfldtot6 + selfldtot7 + sumString + " ,1 as ord " + " from tFinishedStock A ,twarehouse2 B,tFinishedProductSleeve C,tFinishedProductFit D ,tStyleMaster sm ,tCF cf  where A.recid <> 0  " + where1 + where2 + where3 + where4 + where5 + where6 + where7 + " and A.storeID = B.warehousecode and A.SleeveID=C.sleeveid and A.FitID=D.fitid and sm.StyleCode =A.stylecode and sm.CFid=cf.CFid ) x order by ord ";
                string sqlcmd = sqlString + sqlstring2;
               // textBox1.Text = sqlcmd;
                
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = sqlcmd;
                DataSet ds = new DataSet();
                sda.Fill(ds);                
                grid1.DataSource = ds.Tables[0];
                grid1.Cell(1, 0).CellType = FlexCell.CellTypeEnum.HyperLink;
                grid1.Cell(0, 1).Text = "";
                int rowcount = grid1.Rows;
                int colcunt = grid1.Cols;
                
                   Fillgridview(rowcount, colcunt);
                   con.Close();
                
            }
            else
            {
                string st = " select  sum(q38) [38],sum(q39) [39], sum(q40) [40], sum(q42) [42], sum(q44) [44],(sum(q38)+sum(q39)+ sum(q40) + sum(q42)+ sum(q44)) Total   from tFinishedStock A ,twarehouse2 B,tFinishedProductSleeve C,tFinishedProductFit D ,tStyleMaster sm ,tCF cf  where A.recid <> 0 and A.storeID = B.warehousecode and A.SleeveID=C.sleeveid and A.FitID=D.fitid and sm.StyleCode =A.stylecode and sm.CFid=cf.CFid ";
                
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = st ;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grid1.DataSource = ds.Tables[0];
            
            }

            con.Close();
        }


        void Fillgridview(int rowcount,int colcunt)
        {
           
           
            for (int i = 1; i < rowcount; i++)
            {
                if (i < rowcount - 2)
                {
                    grid1.Cell(i, 1).CellType = FlexCell.CellTypeEnum.HyperLink;
                }
                
                grid1.Row(i).Locked = true;

            }
            grid1.Column(colcunt-1).Width = 0;  
            

        }
        private void chkwarehouse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkwarehouse.Checked == true )
            {
                cmbwarehouse.Enabled = false;
            }
            else
            {
                cmbwarehouse.Enabled = true;
            }
        }

        private void chkStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStyle.Checked == true)
            {
                cmbStyle.Enabled = false;
            }
            else
            {
                cmbStyle.Enabled = true;
            }
        }

        private void chkSleeve_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSleeve.Checked == true)
            {
                cmbsleeve.Enabled = false;
            }
            else
            {
                cmbsleeve.Enabled = true;
            }
        }

        private void chkfit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfit.Checked == true)
            {
                cmbfit.Enabled = false;
            }
            else
            {
                cmbfit.Enabled = true;
            }
        }

        private void cmbmrp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkmrp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmrp.Checked == true)
            {
                cmbmrp.Enabled = false;
            }
            else
            {
                cmbmrp.Enabled = true ;
            }
        }

        private void ckbcasform_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbcasform.Checked == true)
            {
                cmbcasform.Enabled = false;
            }
            else
            {
                cmbcasform.Enabled = true;
            }
        }

        private void chbfabric_CheckedChanged(object sender, EventArgs e)
        {
            if (chbfabric.Checked == true)
            {
                cmbfabric.Enabled = false;
            }
            else
            {
                cmbfabric.Enabled = true;
            }
        }


        void filldetailsgrid(int r,int colct)
        {
           // int selwhere1 = 0;
            string w1 = "";
            string w2 = "";
            string w3 = "";
            string w4 = "";
            string w5 = "";
            string w6 = "";
            string w7 = "";

            if (selflds1.Trim().Length != 0)
            {


                w1 = " and B.warehouse= '"+grid1.Cell(r, a1 + 1).Text.ToString()+ "'";
               
               
                
            }
            if (selflds2.Trim().Length != 0)
            {
                
                
                    w2 = " and A.stylecode = '"+grid1.Cell(r, a2+1).Text.ToString()+"'";
                
            }
            if (selflds3.Trim().Length != 0)
            {


                w3 = " and C.sleeve = '" +grid1.Cell(r, a3 + 1).Text.ToString() + "'";
              
            }
            if (selflds4.Trim().Length != 0)
            {


                w4 = " and D.fit = '" + grid1.Cell(r, a4 + 1).Text.ToString()+ "'";

            }
            if (selflds5.Trim().Length != 0)
            {


                w5 = " and A.mrp = '" + grid1.Cell(r, a5+1).Text.ToString()+"'";

            }
            if (selflds6.Trim().Length != 0)
            {


                w6 = " and A.FabricCode = '" + grid1.Cell(r, a6+1).Text.ToString() +"'";

            }
            if (selflds7.Trim().Length != 0)
            {


                w7 = " and cf.CorF = '" + grid1.Cell(r, a7 + 1).Text.ToString() +"'";

            }

            string st1 = " select * from( select B.warehouse,A.stylecode,C.sleeve,fit,str(mrp,6,2) mrp,A.FabricCode,cf.CorF ,(q38) [38],(q39) [39], (q40) [40],(q42) [42], (q44) [44],((q38)+(q39)+ (q40) + (q42)+ (q44))TOTAL ,((mrp*q38)+(mrp*q39)+(mrp*q40)+(mrp*q42)+(mrp*q44))Amount ,0 as ord  ";
            string st2 = "  from tFinishedStock A left join tWarehouse2 B on A.storeID = B.warehousecode left join tFinishedProductSleeve C on A.SleeveID=C.sleeveid  left join tFinishedProductFit D on A.FitID=D.fitid left join tStyleMaster sm on sm.StyleCode =A.stylecode left join tCF cf on  sm.CFid=cf.CFid where A.recid <> 0 ";
            string st3 = w1 + w2 + w3 + w4 + w5 + w6 + w7;
            string st4 = "union select 'Total', '','','','','','',sum(q38) [38],sum(q39) [39], sum(q40) [40], sum(q42) [42],  sum(q44) [44],(sum(q38)+sum(q39)+ sum(q40) + sum(q42)+ sum(q44))TOTAL,(sum(mrp*q38)+ sum(mrp*q39)+sum(mrp*q40) +sum(mrp*q42) +sum(mrp*q44))Amount,1 as ord ";  
            string st5= "from tFinishedStock A ,twarehouse2 B,tFinishedProductSleeve C,tFinishedProductFit D ,tStyleMaster sm ,tCF cf  ";
            string st6 = "where A.recid <> 0   and A.storeID = B.warehousecode and A.SleeveID=C.sleeveid and A.FitID=D.fitid and sm.StyleCode =A.stylecode  and sm.CFid=cf.CFid " + w1 + w2 + w3 + w4 + w5 + w6 + w7  + ") temp order by ord";
            string sqlcmd = st1 + st2 + st3 + st4+ st5+ st6;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = sqlcmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);

            //textBox2.Text = sqlcmd;
            int i = grid2.Cols;
            
                     
            
            grid2.DataSource = ds.Tables[0];

            grid2.Column((grid2.Cols)-1).Width = 0;
            
            
        }


        private void grid1_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            e.Changed = true;
            e.URL = "";
            if (grid1.Cell(e.Row, e.Col).Text == "View")
            {
              filldetailsgrid(e.Row,grid1.Cols);  
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            grid1.ExportToExcel("c:\\v6\\stock.xls", true, true);
            MessageBox.Show ("exported to C:\\V6\\Stock.xls");
        }

        

    }
}
