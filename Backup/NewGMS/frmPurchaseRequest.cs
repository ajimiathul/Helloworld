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
    public partial class frmPurchaseRequest : Form
    {
        bool flagSupMat = false;
        decimal dec;
        bool checking = false;
        int supCol = 0, matCol = 0;
        string orderBy = " order by SupplierName,Subnumber ";
        public frmPurchaseRequest()
        {
            InitializeComponent();
        }

        private void frmPurchaseRequest_Load(object sender, EventArgs e)
        {
            flagSupMat = false ;
            ShowQtReq();
            flagSupMat = true;
            supCol = 2;
            matCol = 3;
            validation(6);
            FlexGridActions();
        }
        private void FlexGridActions()
        {
            AddColumnFlexGrid();
            FillFlexGrid();
        }
        private void validation(int col)
        {
            FlexCell.Column column1 = fgMaterials.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 2;
        }
        private void AddColumnFlexGrid()
        {
            fgMaterials.Column(1).CellType = FlexCell.CellTypeEnum.CheckBox;
            fgMaterials.Cell(0, supCol).Text = "Supplier";
            fgMaterials.Cell(0, matCol).Text = "Material";
            fgMaterials.Cell(0, 4).Text = "Qty";
            fgMaterials.Cell(0, 5).Text = "New Qty";
            fgMaterials.Cell(0, 6).Text = "Rate";
            fgMaterials.Cell(0, 7).Text = "Remarks";
            fgMaterials.Cell(0, 8).Text = "Sub. No.";
            fgMaterials.Cell(0, 9).Text = "No. of Materials";
            fgMaterials.Cell(0, 10).Text = "Material Blocked";
            fgMaterials.Cell(0, 11).Text = "Color";
            fgMaterials.Cell(0, 12).Text = "SupCod";
            fgMaterials.Cell(0, 13).Text = "matCod";
            fgMaterials.Cell(0, 14).Text = "selected";
            fgMaterials.Column(1).Width = 30;
            fgMaterials.Column(8).Width = 100;
            fgMaterials.Column(7).Width = 170;
            fgMaterials.Column(2).Width = 130;
            fgMaterials.Column(3).Width = 130;
            fgMaterials.Column(4).Width = 75;
            fgMaterials.Column(5).Width = 75;
            fgMaterials.Column(6).Width = 75;
            fgMaterials.Column(8).Width = 75;
            fgMaterials.Column(9).Width = 75;
            fgMaterials.Column(10).Width = 0;
            fgMaterials.Column(11).Width = 0;
            fgMaterials.Column(14).Width = 0;
            fgMaterials.Column(12).Width = 0;
            fgMaterials.Column(13).Width = 0;
            fgMaterials.Column(2).Locked = true;
            fgMaterials.Column(3).Locked = true;
            fgMaterials.Column(4).Locked = true;
            fgMaterials.Column(6).Locked = true;
            fgMaterials.Column(8).Locked = true;
            fgMaterials.Column(9).Locked = true;
            fgMaterials.Column(10).Locked = true;
            fgMaterials.Column(11).Locked = true;
            fgMaterials.Column(12).Locked = true;
            fgMaterials.Column(13).Locked = true;
            fgMaterials.Column(14).Locked = true;              
        }

        private void FillFlexGrid()
        {
            fgMaterials.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select C.SupplierName ,A.MaterialBlocked,B.MatDesc ,QtQty ,A.QtURate,selected,A.remarks,A.suppliercode ,A.matcode ,A.PReqQty,A.colorChanged,A.SubNumber,D.nofMaterials from tMaterialVsSupplier A left join tMaterial B on A.matcode = B.MatCode left join tSupplier C on C.Suppliercode = A.suppliercode left join tPurReqHD D on D.QtReqNo = A.QtRqNo and D.supcode = A.suppliercode and D.sup_subno = A.SubNumber where A.QtRqNo =@q1 " + orderBy;
            sda.SelectCommand.Parameters.AddWithValue("@q1", Convert.ToInt32(cmbQtReqNo.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            fgMaterials.Rows = ds.Tables[0].Rows.Count + 1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["selected"].ToString() == "Yes")
                {
                    fgMaterials.Cell(i + 1, 1).Text = "1";
                }
                if (ds.Tables[0].Rows[i]["MaterialBlocked"].ToString() == "Y")
                {                   
                    fgMaterials.Row(i + 1).Locked = true;
                    for (int k = 1; k < fgMaterials.Cols; k++)
                    {
                        fgMaterials.Cell(i + 1, k).BackColor = System.Drawing.Color.LightGray;
                    }
                }                
               fgMaterials.Cell(i + 1, supCol).Text = ds.Tables[0].Rows[i]["SupplierName"].ToString();
               fgMaterials.Cell(i + 1, matCol).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
               fgMaterials.Cell(i + 1, 4).Text = ds.Tables[0].Rows[i]["QtQty"].ToString();
               fgMaterials.Cell(i + 1, 6).Text = ds.Tables[0].Rows[i]["QtURate"].ToString();
               fgMaterials.Cell(i + 1, 7).Text = ds.Tables[0].Rows[i]["remarks"].ToString();
               fgMaterials.Cell(i + 1, 5).Text = ds.Tables[0].Rows[i]["PReqQty"].ToString();
               fgMaterials.Cell(i + 1, 8).Text = ds.Tables[0].Rows[i]["SubNumber"].ToString();
               fgMaterials.Cell(i + 1, 9).Text = ds.Tables[0].Rows[i]["nofMaterials"].ToString();
               fgMaterials.Cell(i + 1, 10).Text = ds.Tables[0].Rows[i]["MaterialBlocked"].ToString();
               fgMaterials.Cell(i + 1, 11).Text = ds.Tables[0].Rows[i]["colorChanged"].ToString();
               fgMaterials.Cell(i + 1, 12).Text = ds.Tables[0].Rows[i]["suppliercode"].ToString();
               fgMaterials.Cell(i + 1, 13).Text = ds.Tables[0].Rows[i]["matcode"].ToString();
               fgMaterials.Cell(i + 1, 14).Text = ds.Tables[0].Rows[i]["selected"].ToString();
               if (ds.Tables[0].Rows[i]["colorChanged"].ToString() == "Y" && ds.Tables[0].Rows[i]["MaterialBlocked"].ToString() == "N")
               {
                   for (int k = 1; k < fgMaterials.Cols; k++)
                   {
                       fgMaterials.Cell(i + 1, k).ForeColor = System.Drawing.Color.Red;
                   }
               }               
            }
        }

        private void ShowQtReq()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct QtRqNo  from tQuotReqVsSupplier order by QtRqNo desc";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbQtReqNo.DataSource = ds.Tables[0];
            cmbQtReqNo.DisplayMember = "QtRqNo";
            cmbQtReqNo.ValueMember = "QtRqNo";
        }

        private void cmbQtReqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagSupMat == true)
            {
                FillFlexGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProcess();
            MessageBox.Show("Update Successfully");
        }

        private void SaveProcess()
        {
            double pqty = 0.00;
            string rem = "";
            RemoveAll();
            for (int i = 1; i < fgMaterials.Rows; i++)
            {
                int sCod = Convert.ToInt32(fgMaterials.Cell(i, 12).Text);
                int mCod = Convert.ToInt32(fgMaterials.Cell(i, 13).Text);
                if (fgMaterials.Cell(i,1).Text=="1" && fgMaterials.Cell(i,10).Text=="N")
                {
                    AddStatus(sCod, mCod);                         
                }
                rem = fgMaterials.Cell(i,7).Text.Trim();

                if (decimal.TryParse(fgMaterials.Cell(i,5).Text,out dec)==true)
                {
                    pqty = Convert.ToDouble(fgMaterials.Cell(i, 5).Text);
                }
                else
                { 
                    pqty = 0.0;
                }
                AddRemarks(sCod,mCod,rem,pqty);             
            }
            InsertPurReqHD();
        }

        private void InsertPurReqHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "iPurReqHdMain";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QtReqNo", Convert.ToInt32(cmbQtReqNo.SelectedValue));
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        private void RemoveAll()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMaterialVsSupplier set selected='No' where  QtRqNo=@QtRqNo and MaterialBlocked ='N'";
            cmd.Parameters.AddWithValue("@QtRqNo", Convert.ToInt32(cmbQtReqNo.SelectedValue));                
            cmd.ExecuteNonQuery();                
            con.Close();
        }

        private void AddStatus(int scode,int mcode)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMaterialVsSupplier set selected='Yes' where  suppliercode=@scode and QtRqNo=@QtRqNo and matcode=@mcode ";
            cmd.Parameters.AddWithValue("@scode", scode);
            cmd.Parameters.AddWithValue("@QtRqNo", Convert.ToInt32(cmbQtReqNo.SelectedValue));
            cmd.Parameters.AddWithValue("@mcode", mcode);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void AddRemarks(int scode, int mcode,string rem,double pqty)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMaterialVsSupplier set remarks=@rem,PReqQty=@pqty,PerInvReqQty=@pqty where  suppliercode=@scode and QtRqNo=@QtRqNo and matcode=@mcode ";
            cmd.Parameters.AddWithValue("@rem", rem);
            cmd.Parameters.AddWithValue("@pqty", pqty);
            cmd.Parameters.AddWithValue("@scode", scode);
            cmd.Parameters.AddWithValue("@QtRqNo", Convert.ToInt32(cmbQtReqNo.SelectedValue));
            cmd.Parameters.AddWithValue("@mcode", mcode);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        private void rbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaterial.Checked == true)
            {
                orderBy = " order by MatDesc,Subnumber ";
                supCol = 3;
                matCol = 2;
            }
            else
            {
                orderBy = " order by SupplierName,Subnumber ";
                supCol = 2;
                matCol = 3;
            }
            FlexGridActions();
        }        

        private void fgMaterials_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            if (rbOneSupplier.Checked == true && checking==false)
            {
                checking = true;
                if (fgMaterials.Cell(e.Row, 1).Text == "1" && fgMaterials.Cell(e.Row,10).Text!="Y")
                {
                    for (int i = 1; i < fgMaterials.Rows; i++)
                    {
                        if (fgMaterials.Cell(e.Row, 13).Text == fgMaterials.Cell(i, 13).Text && fgMaterials.Cell(i, 10).Text != "Y")
                        {
                            fgMaterials.Cell(i, 1).Text = "0";
                        }
                    }
                    fgMaterials.Cell(e.Row, 1).Text = "1";
                }
                checking = false;
            }
        }
        private void CheckClear()
        {
            checking = true;
            for (int i = 1; i < fgMaterials.Rows; i++)
            {
                if (fgMaterials.Cell(i, 10).Text != "Y")
                {
                    fgMaterials.Cell(i, 1).Text = "0";
                }
            }
            checking = false;
        }
        private void rbManySupplier_CheckedChanged(object sender, EventArgs e)
        {
            CheckClear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
