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
    public partial class frmQuotation2 : Form
    {
        bool MaterialFlag = false;
        bool MaterialGridFlag = false;
        bool sup = false;
        bool flexLoad = false;
        int supCode = 0;
        decimal dec;
        DateTime dt;
        public frmQuotation2()
        {
            InitializeComponent();
        }

        private void ShowQtReq()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct QtRqNo  from tQuotReqVsSupplier order by QtRqNo desc";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbQtReqNo.DataSource = ds.Tables[0];
                cmbQtReqNo.DisplayMember = "QtRqNo";
                cmbQtReqNo.ValueMember = "QtRqNo";
            }
            else
            {
                cmbQtReqNo.DataSource = null;
            }
        }

        private void AddColumnFlexGrid()
        {
            fgQuotation.Column(8).CellType = FlexCell.CellTypeEnum.Calendar;
            fgQuotation.DateFormat = FlexCell.DateFormatEnum.DMY;
            fgQuotation.Cell(0, 1).Text = "Supplier Name";
            fgQuotation.Cell(0, 2).Text = "Material";
            fgQuotation.Cell(0, 3).Text = "Qty";
            fgQuotation.Cell(0, 4).Text = "New Qty";
            fgQuotation.Cell(0, 5).Text = "Unit Rate";
            fgQuotation.Cell(0, 6).Text = "Value";
            fgQuotation.Cell(0, 7).Text = "Ref.No:";
            fgQuotation.Cell(0, 8).Text = "Ref.Date";
            fgQuotation.Cell(0, 9).Text = "Remarks";
            fgQuotation.Cell(0, 10).Text = "MatCode";
            fgQuotation.Cell(0, 11).Text = "supCode";
            fgQuotation.Cell(0, 12).Text = "Qtn";
            fgQuotation.Column(1).Width = 140;
            fgQuotation.Column(2).Width = 140;
            fgQuotation.Column(8).Width = 100;
            fgQuotation.Column(9).Width = 170;
            fgQuotation.Column(11).Width = 0;
            fgQuotation.Column(10).Width = 0;
            fgQuotation.Column(12).Width =50;
            fgQuotation.Column(1).Locked = true;
            fgQuotation.Column(2).Locked = true;
            fgQuotation.Column(3).Locked = true;
            fgQuotation.Column(6).Locked = true;
            fgQuotation.Column(11).Locked = true;
            fgQuotation.Column(12).Locked = true;
            fgQuotation.Column(3).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            fgQuotation.Column(4).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            fgQuotation.Column(5).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            fgQuotation.Column(6).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            fgQuotation.Column(12).Alignment = FlexCell.AlignmentEnum.CenterCenter;
        }

        private void FillFlexGrid()
        {
            if (cmbQtReqNo.DataSource != null)
            {
                sup = false;
                fgQuotation.Rows = 1;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "QuotationFill";
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@qtNum", cmbQtReqNo.SelectedValue);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                fgQuotation.Rows = ds.Tables[0].Rows.Count + 1;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (sup == false)
                    {
                        fgQuotation.Cell(i + 1, 1).Text = ds.Tables[0].Rows[i]["SupplierName"].ToString();  
                        supCode = Convert.ToInt32(ds.Tables[0].Rows[i]["Suppliercode"]);
                    }
                    else
                    {
                        fgQuotation.Cell(i + 1, 1).Text = "";
                    }
                    fgQuotation.Cell(i + 1, 2).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                    fgQuotation.Cell(i + 1, 3).Text = ds.Tables[0].Rows[i]["QReqQty"].ToString();
                    fgQuotation.Cell(i + 1, 4).Text = ds.Tables[0].Rows[i]["QtQty"].ToString();
                    fgQuotation.Cell(i + 1, 5).Text = ds.Tables[0].Rows[i]["QtURate"].ToString();
                    fgQuotation.Cell(i + 1, 7).Text = ds.Tables[0].Rows[i]["RefNum"].ToString();
                    Calculation(i + 1);
                    if (ds.Tables[0].Rows[i]["RefDate"] != DBNull.Value)
                    {
                        fgQuotation.Cell(i + 1, 8).Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["RefDate"]).ToShortDateString();
                    }
                    fgQuotation.Cell(i + 1, 9).Text = ds.Tables[0].Rows[i]["Remarks"].ToString();
                    fgQuotation.Cell(i + 1, 10).Text = ds.Tables[0].Rows[i]["MatCode"].ToString();
                    fgQuotation.Cell(i + 1, 11).Text = ds.Tables[0].Rows[i]["Suppliercode"].ToString();
                    fgQuotation.Cell(i + 1, 12).Text = ds.Tables[0].Rows[i]["NeedQuotation"].ToString();
                    if (fgQuotation.Cell(i + 1, 12).Text.Trim() == "WOQ")
                    {
                        fgQuotation.Row(i + 1).Locked = true;
                    }
                    if (i + 1 != ds.Tables[0].Rows.Count)
                    {
                        if (supCode == Convert.ToInt32(ds.Tables[0].Rows[i + 1]["Suppliercode"]))
                        {
                            sup = true;
                        }
                        else
                        {
                            sup = false;
                        }
                    }
                }
            }
        }
       private void frmQuotation2_Load(object sender, EventArgs e)
        {
            ShowQtReq();
            MaterialFlag = false;
            MaterialFlag = true;
            MaterialGridFlag = false;
            MaterialGridFlag = true;
            flexLoad = false;
            AddColumnFlexGrid();
            FillFlexGrid();
            flexLoad = true;
            validation(4);
            validation(5);
        }
        private void validation(int col)
        {
            FlexCell.Column column1 = fgQuotation.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 2;
        }
        private void cmbQtReqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MaterialFlag == true)
            {
                flexLoad = false;
                FillFlexGrid();
                flexLoad = true;
            }
        }        

        private void Calculation(int rownumber)
        {
            if (rownumber != 0)
            {
                if (Decimal.TryParse(fgQuotation.Cell(rownumber, 4).Text, out dec) != true)
                {
                    fgQuotation.Cell(rownumber, 4).Text = "0.00";
                }
                else if (Decimal.TryParse(fgQuotation.Cell(rownumber, 5).Text, out dec) != true)
                {
                    fgQuotation.Cell(rownumber, 5).Text = "0.00";
                }
                decimal d=Convert.ToDecimal(fgQuotation.Cell(rownumber, 4).Text) * Convert.ToDecimal(fgQuotation.Cell(rownumber, 5).Text);
                d=decimal.Round(d,2);
                fgQuotation.Cell(rownumber, 6).Text = d.ToString();
            }
        }        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            BtnSave();
            BtnSaveHD();
            MessageBox.Show("Update Successfully");
        }

        private void BtnSave()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 1; i < fgQuotation.Rows; i++)
            {
                cmd.CommandText = "update tMaterialVsSupplier set MReqQty=@qreqQty,QtURate=@urate,QtQty=@sqty,PReqQty=@sqty,PerInvReqQty=@sqty where suppliercode=@scode and QtRqNo=@QtRqNo and matcode=@mcode";
                cmd.Parameters.AddWithValue("@qreqQty", Convert.ToDecimal(fgQuotation.Cell(i,3).Text));
                cmd.Parameters.AddWithValue("@sqty", Convert.ToDecimal(fgQuotation.Cell(i, 4).Text));
                cmd.Parameters.AddWithValue("@urate", Convert.ToDecimal(fgQuotation.Cell(i, 5).Text));
                cmd.Parameters.AddWithValue("@scode", Convert.ToInt32(fgQuotation.Cell(i, 11).Text));
                cmd.Parameters.AddWithValue("@QtRqNo", Convert.ToInt32(cmbQtReqNo.SelectedValue));
                cmd.Parameters.AddWithValue("@mcode", Convert.ToInt32(fgQuotation.Cell(i, 10).Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }

        private void BtnSaveHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 1; i < fgQuotation.Rows; i++)
            {
                cmd.CommandText = "update tQuotReqVsSupplier set RefDate=@dt,Remarks=@rmks,RefNum=@RefNum where suppliercode=@scode and QtRqNo=@QtRqNo ";
                cmd.Parameters.AddWithValue("@scode", Convert.ToInt32(fgQuotation.Cell(i, 11).Text));
                cmd.Parameters.AddWithValue("@QtRqNo", Convert.ToInt32(cmbQtReqNo.SelectedValue));                
                if (DateTime.TryParse(fgQuotation.Cell(i, 8).Text,out dt)==true)
                {
                    cmd.Parameters.AddWithValue("@dt", Convert.ToDateTime(fgQuotation.Cell(i, 8).Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@rmks", (fgQuotation.Cell(i, 9).Text));
                cmd.Parameters.AddWithValue("@RefNum", (fgQuotation.Cell(i, 7).Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }
        private void DateFillInFlex(int supNum,DateTime d,bool isNull)
        {
            for (int j = 1; j < fgQuotation.Rows; j++)
            {
                if (Convert.ToInt32(fgQuotation.Cell(j, 11).Text) == supNum)
                {
                    if (isNull == false)
                    {
                        fgQuotation.Cell(j, 8).Text = d.ToShortDateString();
                    }
                    else
                    {
                        fgQuotation.Cell(j, 8).Text = null;
                    }
                }
            }
        }
        private void RemarkFillInFlex(int supNum,string rmks)
        {
            for (int j = 1; j < fgQuotation.Rows; j++)
            {
                if (Convert.ToInt32(fgQuotation.Cell(j, 11).Text) == supNum)
                {
                    fgQuotation.Cell(j, 9).Text = rmks;
                }
            }
        }
        private void RefNumFillInFlex(int supNum, string refNum)
        {
            for (int j = 1; j < fgQuotation.Rows; j++)
            {
                if (Convert.ToInt32(fgQuotation.Cell(j, 11).Text) == supNum)
                {
                    fgQuotation.Cell(j, 7).Text = refNum;
                }
            }
        }
        private void fgQuotation_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            if (flexLoad==true)
            {
                int supNum = Convert.ToInt32(fgQuotation.Cell(e.Row, 11).Text);
                Calculation(e.Row);
                if (e.Col == 9)
                {
                    RemarkFillInFlex(supNum, fgQuotation.Cell(e.Row, 9).Text);
                }
                if (e.Col == 8)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                    if (DateTime.TryParse(fgQuotation.Cell(e.Row, 8).Text, out dt) == true)
                    {
                        DateTime date = Convert.ToDateTime(fgQuotation.Cell(e.Row, 8).Text);
                        DateFillInFlex(supNum, date, false);
                    }
                    else
                    {
                        DateFillInFlex(supNum, DateTime.Now, true);
                    }
                }
                if (e.Col == 7)
                {
                    RefNumFillInFlex(supNum, fgQuotation.Cell(e.Row, 7).Text);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}