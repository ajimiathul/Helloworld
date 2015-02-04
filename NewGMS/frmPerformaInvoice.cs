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
    public partial class frmPerformaInvoice : Form
    {
        bool flagSuplr = false;
        bool flagQRno = false;
        int subNumber = 0;
        decimal dec;
        bool flexLoading = false;
        public frmPerformaInvoice()
        {
            InitializeComponent();
        }

        private void flexAddnChargesLoad()
        {            
            fgAddnCharges.Cell(0, 1).Text = "Additional Charges";
            fgAddnCharges.Cell(0, 2).Text = "Value";
            fgAddnCharges.Column(1).Width = 600;
            fgAddnCharges.Column(1).MaxLength = 1000;
            validation2(2);
        }

        private void FillflexAddnCharges()
        {
            fgAddnCharges.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select description,Value from tPIAddnChrgeValues where QtSubReqNo=@QtSubReqNo and supcode = @supcode";
            sda.SelectCommand.Parameters.AddWithValue("@QtSubReqNo", cmbQtReqNo.Text);
            sda.SelectCommand.Parameters.AddWithValue("@supcode", Convert.ToInt32(cmbSupplr.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            fgAddnCharges.Rows = ds.Tables[0].Rows.Count+10;
            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
            {                
                fgAddnCharges.Cell(m + 1, 1).Text = ds.Tables[0].Rows[m]["description"].ToString();
                fgAddnCharges.Cell(m + 1, 2).Text = ds.Tables[0].Rows[m]["Value"].ToString();
            }
        }

        private void SaveAddnChargeValues()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int j = 1; j < fgAddnCharges.Rows; j++)
            {
                if (fgAddnCharges.Cell(j, 2).Text.Trim().Length != 0)
                {
                    cmd.CommandText = "insert into tPIAddnChrgeValues(QtSubReqNo,Supcode,description,Value) values(@QtSubReqNo,@Supcode,@description,@Value)";
                    cmd.Parameters.AddWithValue("@QtSubReqNo", cmbQtReqNo.Text);
                    cmd.Parameters.AddWithValue("@supcode", Convert.ToInt32(cmbSupplr.SelectedValue));
                    cmd.Parameters.AddWithValue("@description", fgAddnCharges.Cell(j, 1).Text);
                    cmd.Parameters.AddWithValue("@Value", Convert.ToDecimal(fgAddnCharges.Cell(j, 2).Text));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }

        private void FillflexAddnCharges2()
        {
            fgAddnCharges.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select chrgDesc from tPIAddnChargesTemp where reqsubno=@reqsubno and supcode=@supcode";
            sda.SelectCommand.Parameters.AddWithValue("@reqsubno", cmbQtReqNo.Text);
            sda.SelectCommand.Parameters.AddWithValue("@supcode", Convert.ToInt32(cmbSupplr.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            fgAddnCharges.Rows = ds.Tables[0].Rows.Count+10;
            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
            {             
                fgAddnCharges.Cell(m + 1, 1).Text = ds.Tables[0].Rows[m]["chrgDesc"].ToString();
                fgAddnCharges.Cell(m + 1, 2).Text = "0.00";           
            }
        }

        private void validation2(int col)
        {
            FlexCell.Column column1 = fgAddnCharges.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 2;
        }
        private void frmPerformaInvoice_Load(object sender, EventArgs e)
        {
            flexLoading = true;
            flagSuplr = false;
            ShowSupplr();
            flagSuplr = true ;
            flagQRno = false;
            ShowQtReq();
            flagQRno = true ;
            if (cmbQtReqNo.DataSource != null)
            {
                string xyz = cmbQtReqNo.Text;
                int zyx = xyz.IndexOf('-');
                subNumber = Convert.ToInt32(xyz.Substring(zyx + 1, (xyz.Trim().Length - (zyx + 1))));
                FillMaterials();
            }
            //gridPerforma.DateFormat = FlexCell.DateFormatEnum.DMY;
            //gridPerforma.Column(4).DecimalLength=3;
            gridPerforma.Cell(0, 1).Text = "MatCode";
            gridPerforma.Cell(0, 2).Text = "MatDesc";
            gridPerforma.Cell(0, 3).Text = "ReqQty";
            gridPerforma.Cell(0, 4).Text = "Quot Rate";
            gridPerforma.Cell(0, 5).Text = "Qty";
            gridPerforma.Cell(0,6).Text = "Rate";
            gridPerforma.Cell(0, 7).Text = "Amount";
            gridPerforma.Column(1).Width = 0;
            gridPerforma.Column(2).Width = 150;
            gridPerforma.Column(2).Locked = true;
            gridPerforma.Column(3).Locked = true;
            gridPerforma.Column(4).Locked = true;
            gridPerforma.Column(7).Locked = true;
            validation(3);
            validation(4);
            validation(5);
            validation(6);
            validation(7);
            flexAddnChargesLoad();
            FillflexAddnCharges();
            FillCondition();
            flexLoading = false;
           txtTotal.Text = TotalAmount().ToString();
        }

        private void ShowQtReq()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.QtReqNo ,(LTRIM (RTRIM (str(A.QtReqNo)))+'-'+LTRIM (RTRIM (STR( sup_subno )))) as dispno from tPerformaInvoiceHD A where supcode = @supcode and PINeed<>'No'  order by QtReqNo desc";
            sda.SelectCommand.Parameters.AddWithValue ("@supcode",Convert.ToInt32 (cmbSupplr.SelectedValue) );
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbQtReqNo.DataSource = ds.Tables[0];
                cmbQtReqNo.DisplayMember = "dispno";
                cmbQtReqNo.ValueMember = "QtReqNo";
            }
            else
            {
                cmbQtReqNo.DataSource = null;
            }
        }

        private void ShowSupplr()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct A.supcode,B.SupplierName  from tPerformaInvoiceHD A,tSupplier B where A.supcode = B.Suppliercode and PINeed <>'No'";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSupplr.DataSource = ds.Tables[0];
            cmbSupplr.DisplayMember = "SupplierName";
            cmbSupplr.ValueMember = "supcode";
        }

        private void cmbQtReqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagQRno == true)
            {
                string xyz = cmbQtReqNo.Text;    
                int zyx = xyz.IndexOf('-');
                subNumber = Convert.ToInt32 ( xyz.Substring(zyx+1, (xyz.Trim().Length - (zyx + 1))));
                FillMaterials();
            }
        }

        private void cmbSupplr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagSuplr == true)
            {
                ShowQtReq();
            }
        }


        private void FillCondition()
        {           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Conditon from tPerformaInvoiceHD where supcode=@supcode and reqsubno = @reqsubno";
            sda.SelectCommand.Parameters.AddWithValue("@supcode", Convert.ToInt32(cmbSupplr.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@reqsubno", cmbQtReqNo.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCond.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

        private void FillMaterials()
        {
            gridPerforma.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "performaMaterial";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@q1", Convert.ToInt32(cmbQtReqNo.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@s1", Convert.ToInt32(cmbSupplr.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@sn1", subNumber );
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridPerforma.Rows = ds.Tables[0].Rows.Count+1;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridPerforma.Cell(i+1,1).Text=ds.Tables[0].Rows[i]["matcode"].ToString();
                gridPerforma.Cell(i+1, 2).Text = (ds.Tables[0].Rows[i]["MatDesc"].ToString());
                gridPerforma.Cell(i+1, 3).Text = (ds.Tables[0].Rows[i]["PIReqQty"].ToString());
                gridPerforma.Cell(i+1, 4).Text = (ds.Tables[0].Rows[i]["URate"].ToString());
                gridPerforma.Cell(i+1, 5).Text = (ds.Tables[0].Rows[i]["PIQty"].ToString());
                gridPerforma.Cell(i+1,6).Text = (ds.Tables[0].Rows[i]["PIRate"].ToString());
                gridPerforma.Cell(i+1,7).Text = (ds.Tables[0].Rows[i]["Amount"].ToString());
            }
            if (ds.Tables[0].Rows[0]["PINVNo"] != DBNull.Value)
            {
                txtPiNumber.Text = ds.Tables[0].Rows[0]["PINVNo"].ToString();
                dtpPiDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["PINVdate"]);
                btnSave.Text = "Update";
            }
            else
            {
                txtPiNumber.Clear();
                btnSave.Text = "Save";
            }
        }

       private void DelAddnChargeValues()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete from tPIAddnChrgeValues where QtSubReqNo=@QtSubReqNo and Supcode=@Supcode";
            cmd.Parameters.AddWithValue("@QtSubReqNo", cmbQtReqNo.Text);
            cmd.Parameters.AddWithValue("@supcode", Convert.ToInt32(cmbSupplr.SelectedValue));
            cmd.ExecuteNonQuery();
            con.Close();
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPiNumber.Text != "")
            {
                if (cmbQtReqNo.DataSource != null)
                {
                    SaveMethod();
                }
                else
                {
                    MessageBox.Show("No Data");
                }
            }
            else
            {
                MessageBox.Show("Enter PI Number");
                txtPiNumber.Focus();
            }
        }

        private void SetNoModify()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPurReqHD set CanModify='No' where QtReqNo=@qtNum and supcode=@supC and sup_subno=@subno";
            cmd.Parameters.AddWithValue("@qtNum", cmbQtReqNo.SelectedValue);
            cmd.Parameters.AddWithValue("@supC", cmbSupplr.SelectedValue);
            cmd.Parameters.AddWithValue("@subno", subNumber);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void SaveMethod()
        {
            for (int i = 1; i < gridPerforma.Rows; i++)
            {
                int mc = Convert.ToInt32(gridPerforma.Cell(i, 1).Text);
                if (decimal.TryParse(gridPerforma.Cell(i, 5).Text, out dec) == false)
                {
                    gridPerforma.Cell(i, 5).Text = "0.00";
                }
                if (decimal.TryParse(gridPerforma.Cell(i, 6).Text, out dec) == false)
                {
                    gridPerforma.Cell(i, 6).Text = "0.00";
                }
                double varqty = Convert.ToDouble(gridPerforma.Cell(i, 5).Text);
                double varRate = Convert.ToDouble(gridPerforma.Cell(i, 6).Text);
                UpdateStatus(mc, varqty, varRate);
            }
            if (btnSave.Text == "Save")
            {
                SetNoModify();
                SaveAddnChargeValues();
                UpdateHDCondition();
                MessageBox.Show("Saved Sucessfully");
            }
            else
            {
                DelAddnChargeValues();
                SaveAddnChargeValues();
                UpdateHDCondition();
                MessageBox.Show("Update Sucessfully");
            }
        }

        private void UpdateHDCondition()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPerformaInvoiceHD set Conditon=@cond where reqsubno=@reqsubno and supcode=@supcode";
            cmd.Parameters.AddWithValue("@cond", txtCond.Text.Trim ());
            cmd.Parameters.AddWithValue("@reqsubno", cmbQtReqNo.Text);
            cmd.Parameters.AddWithValue("@supcode", Convert.ToInt32(cmbSupplr.SelectedValue));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void UpdateStatus(int mcode,double varqty, double varRate)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "uNullPerformaInvDate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@q1", Convert.ToInt32(cmbQtReqNo.SelectedValue));
            cmd.Parameters.AddWithValue("@s1", Convert.ToInt32(cmbSupplr.SelectedValue));
            cmd.Parameters.AddWithValue("@sn1", subNumber);
            cmd.Parameters.AddWithValue("@mcode", mcode);
            cmd.Parameters.AddWithValue("@pid", dtpPiDate.Value);           
            cmd.Parameters.AddWithValue("@pinno", txtPiNumber.Text);
            cmd.Parameters.AddWithValue("@varqty", varqty);
            cmd.Parameters.AddWithValue("@varRate", varRate);
            cmd.ExecuteNonQuery();
            con.Close();
        }        

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void validation(int col)
        {
            FlexCell.Column column1 = gridPerforma.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 2;
        }
        private void AmountCalculations(int rowNum)
        {
            if (decimal.TryParse(gridPerforma.Cell(rowNum, 5).Text, out dec) == false)
            {
                gridPerforma.Cell(rowNum, 5).Text = "0.00";
            }
            if (decimal.TryParse(gridPerforma.Cell(rowNum, 6).Text, out dec) == false)
            {
                gridPerforma.Cell(rowNum, 6).Text = "0.00";
            }
            decimal qty =Convert.ToDecimal(gridPerforma.Cell(rowNum, 5).Text);
            decimal rate =Convert.ToDecimal(gridPerforma.Cell(rowNum, 6).Text);
            decimal amt = qty * rate;
            gridPerforma.Cell(rowNum, 7).Text = amt.ToString();
        }
        private void gridPerforma_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            if (e.Row != 0)
            {
                AmountCalculations(e.Row);
                if (flexLoading == false)
                {
                    txtTotal.Text = TotalAmount().ToString();
                }
            }
        }
        private void fgAddnCharges_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            txtTotal.Text = TotalAmount().ToString();
        }
        private decimal TotalAmount()
        {
            decimal totAmt = 0,totAddChgs=0;
            for (int i = 1; i < gridPerforma.Rows; i++)
            {
                if (decimal.TryParse(gridPerforma.Cell(i, 7).Text, out dec))
                {
                    totAmt = totAmt + Convert.ToDecimal(gridPerforma.Cell(i, 7).Text);
                }
            }
            for (int j = 1; j < fgAddnCharges.Rows; j++)
            {
                if (decimal.TryParse(fgAddnCharges.Cell(j, 2).Text, out dec))
                {
                    totAddChgs = totAddChgs + Convert.ToDecimal(fgAddnCharges.Cell(j, 2).Text);
                }
            }
            return totAmt + totAddChgs;
        }
        private void llNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsDbForReports.PIReqSubno = cmbQtReqNo.Text;
            clsDbForReports.PIRSupplier = cmbSupplr.Text;
            clsDbForReports.PIRSupplierCode = Convert.ToInt32 ( cmbSupplr.SelectedValue) ;
            frmPIAddChargeSelections obj = new frmPIAddChargeSelections();
            obj.ShowDialog();
            FillflexAddnCharges2();
            DeleteACharges();
        }

        private void DeleteACharges()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete tPIAddnChargesTemp where reqsubno=@reqsubno and supcode=@supcode";
            cmd.Parameters.AddWithValue("@reqsubno", cmbQtReqNo.Text);
            cmd.Parameters.AddWithValue("@supcode", Convert.ToInt32 ( cmbSupplr.SelectedValue));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        

    }
}
 