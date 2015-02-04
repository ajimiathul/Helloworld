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
    public partial class frmGIRN : Form
    {
        public frmGIRN()
        {
            InitializeComponent();
        }
        bool listFlag = false;
        bool RupeeEntry = false,PerEntry=false;
        decimal discount = 0.0M;
        decimal exduty = 0.0M;
        decimal vat = 0.0M;
        decimal totAmtFromGrid = 0.0M;
        decimal totAmt = 0.0M;
        int pjv = 0,row=-1;
        string zeroAmt="0.00";
        string newMode="New",editMode="Edit";
        char plus = '+', minus = '-';

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            FillSupplierCombo();
            rbDirectEntry.Checked = true;
            
        }
        private void frmPurchase_Shown(object sender, EventArgs e)
        {
            txtItem.Focus();
        }

        private void FillSupplierCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select SupplierName,Suppliercode,acccode from tSupplier where SupplierName<>''";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSupplier.DataSource = ds.Tables[0];
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "acccode";
        }

        private void FillUnitCombo(int mc)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select unitid,unit from unitmaster where unitid in (select unitcode from tmaterial where matcode=@mc)";
            sda.SelectCommand.Parameters.AddWithValue("@mc",mc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUnit.DataSource = ds.Tables[0];
            cmbUnit.DisplayMember = "Unit";
            cmbUnit.ValueMember = "UnitId";
        }

        private void ForFromPO()
        {
            if (rbFromPuchaseOrder.Checked == true)
            {
                FillPuchaseOrderCombo();
                dgvPurchaseDetail.Rows.Clear();
                txtTotAmt.Text = zeroAmt;
                totAmt = 0;
                totAmtFromGrid = 0;
            }
            else
            {
                cmbPoNo.DataSource = null;
                dgvPurchaseDetail.Rows.Clear();
                txtTotAmt.Text = zeroAmt;
                totAmt = 0;
                totAmtFromGrid = 0;
            }        
        }

        private void rbFromPuchaseOrder_CheckedChanged_1(object sender, EventArgs e)
        {
            ForFromPO();
        }

        private void FillPuchaseOrderCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select pono,POAmt from tPurchOrdHD";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbPoNo.DataSource = ds.Tables[0];
            cmbPoNo.DisplayMember = "pono";
            cmbPoNo.ValueMember = "POAmt";
        }
        private void FillGridFromPO()
        {
            totAmtFromGrid = 0.00M;
            txtTotAmt.Text = zeroAmt;
            if (cmbPoNo.Text != "")
            {
                dgvPurchaseDetail.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                string s1 = " select B.MatDesc,A.Rate,A.amount,A.matcode,'' rollno,B.ToCuttingDept,c.unit,c.unitid,A.balqty,B.IsRollNumberRequired from tPurchOrdDtl A ";
                string s2  = "  left join tMaterial B on A.matcode=B.MatCode left join unitmaster C on B.unitcode= C.unitid where pono=@pono";
                sda.SelectCommand.CommandText = s1 + s2;
                sda.SelectCommand.Parameters.AddWithValue("@pono", Convert.ToInt32(cmbPoNo.Text));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if( Convert.ToDouble (ds.Tables[0].Rows[i]["balqty"])!=0)
                    {
                    dgvPurchaseDetail.Rows.Add(1);
                    int x = dgvPurchaseDetail.Rows.Count;
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColSlNo"].Value = x;
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColItem"].Value = ds.Tables[0].Rows[i]["MatDesc"];
                    string unitrate = ds.Tables[0].Rows[i]["Rate"].ToString();
                    unitrate = unitrate.Substring(0, unitrate.Length - 2);
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitRate"].Value = unitrate;
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColUnit"].Value = ds.Tables[0].Rows[i]["unit"];
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColQty"].Value = ds.Tables[0].Rows[i]["balqty"];
                    string amt = ds.Tables[0].Rows[i]["amount"].ToString();
                    amt = amt.Substring(0, amt.Length - 2);
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColAmt"].Value = amt;
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColItemCode"].Value = ds.Tables[0].Rows[i]["matcode"];
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitCode"].Value = ds.Tables[0].Rows[i]["unitid"];
                    totAmtFromGrid = totAmtFromGrid + Convert.ToDecimal(amt);                   
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColRollNo"].Value = ds.Tables[0].Rows[i]["rollno"];
                    dgvPurchaseDetail.Rows[x - 1].Cells["colISCutting"].Value = ds.Tables[0].Rows[i]["ToCuttingDept"];
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColIsRollNumberRequired"].Value = ds.Tables[0].Rows[i]["IsRollNumberRequired"];        
                    }
                }
                txtTotAmt.Text = totAmtFromGrid.ToString();
            }
        }


        private void cmbPoNo_DropDownClosed_1(object sender, EventArgs e)
        {
            FillGridFromPO();
        }
        private void cmbPoNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillGridFromPO();
            }
        }
        private void ItemList()
        {
            lvItems.Items.Clear();
            lvItems.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.MatDesc,A.MatCode,A.Rate,A.IsRollNumberRequired ,A.ToCuttingDept  from tMaterial A  where A.MatDesc like @ch+'%'";
            sda.SelectCommand.Parameters.AddWithValue("@ch", txtItem.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvItems.Items.Add(ds.Tables[0].Rows[i]["MatDesc"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["MatCode"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Rate"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["ToCuttingDept"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["IsRollNumberRequired"].ToString());
            }
        }

        private void txtItem_TextChanged_1(object sender, EventArgs e)
        {
            if (listFlag == false)
            {
                ItemList();
            }
        }
        private void txtItem_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lvItems.Items.Count > 0)
                {
                    lvItems.Focus();
                    lvItems.Items[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lvItems.Visible = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (CheckValidItem() == true)
                {
                    if (lvItems.Visible == true)
                    {
                        lvItems.Focus();
                        lvItems.Items[0].Selected = true;
                        lvItems_Click(sender, e);
                    }
                }
            }
        }
        private bool CheckValidItem()
        {
            bool present = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select MatCode from tMaterial where MatDesc=@mat";
            sda.SelectCommand.Parameters.AddWithValue("@mat", txtItem.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                present = true;
            }
            else
            {
                txtErrMsg.Visible = true;
                txtErrMsg.Text = "Enter a  valid Item";
                txtItem.Focus();
            }
            return present;
        }

        private void lvItemsClick()
        {
            decimal unitRate = Convert.ToDecimal(lvItems.SelectedItems[0].SubItems[2].Text);
            unitRate = decimal.Round(unitRate, 2);
            txtUnitRate.Text = unitRate.ToString();
            txtItemCode.Text = lvItems.SelectedItems[0].SubItems[1].Text;
            txtIsRollNoReq.Text = lvItems.SelectedItems[0].SubItems[4].Text;
            txtIsCutting.Text = lvItems.SelectedItems[0].SubItems[3].Text;
            txtItem.Text = lvItems.SelectedItems[0].Text;
            lvItems.Visible = false;
            FillUnitCombo(Convert.ToInt32 (txtItemCode.Text));
            txtUnitRate.Focus();
        }


        private void lvItems_Click(object sender, EventArgs e)
        {
            lvItemsClick();
        }
        private void lvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lvItems.Items.Count > 0)
                {
                    lvItemsClick();
                }
            }
        }
        private bool CheckUnitRateTextbox()
        {
            bool check = false;
            if (txtUnitRate.Text == "")
            {
                check = true;
                txtErrMsg.Visible = true;
                txtErrMsg.Text = "Enter Unit Rate";
                txtUnitRate.Focus();
            }
            return check;
        }
        private bool CheckQtyTextBox()
        {
            bool check = false;
            if (txtQty.Text == "")
            {
                check = true;
                txtErrMsg.Visible = true;
                txtErrMsg.Text = "Enter Qty";
                txtQty.Focus();
            }
            return check;
        }
        private bool checkAmtTextBox()
        {
            bool check = false;
            if (txtAmt.Text == "")
            {
                check = true;
                txtErrMsg.Visible = true;
                txtErrMsg.Text = "Enter Amount";
                txtAmt.Focus();
            }
            return check;

        }
        private void txtUnitRate_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckUnitRateTextbox() == true)
                {
                }
                else
                {
                    txtErrMsg.Visible = false;
                    cmbUnit.Focus();
                }
            }
        }
        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }
        private void txtQty_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckQtyTextBox() == true)
                {
                }
                else
                {
                    txtErrMsg.Visible = false;
                    if (txtIsRollNoReq.Text == "Y")
                    {
                        txtRollNo.Focus();
                    }
                    else
                    {
                        txtAmt.Text = (decimal.Round(Convert.ToDecimal(txtUnitRate.Text) * Convert.ToDecimal(txtQty.Text), 2)).ToString();
                        txtAmt.Focus();
                    }
                }
            }
        }


        private void EnterData()
        {
            dgvPurchaseDetail.Rows.Add(1);
            int x = dgvPurchaseDetail.Rows.Count;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColSlNo"].Value = x;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColItem"].Value = txtItem.Text;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitRate"].Value = txtUnitRate.Text;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColUnit"].Value = cmbUnit.Text;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitCode"].Value = cmbUnit.SelectedValue;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColQty"].Value = txtQty.Text;
            if (txtIsRollNoReq.Text == "Y")
            {
                dgvPurchaseDetail.Rows[x - 1].Cells["ColRollNo"].Value = txtRollNo.Text;
                dgvPurchaseDetail.Rows[x - 1].Cells["ColIsRollNumberRequired"].Value = txtIsRollNoReq.Text;
            }
            else
            {
                dgvPurchaseDetail.Rows[x - 1].Cells["ColRollNo"].Value = null;
                dgvPurchaseDetail.Rows[x - 1].Cells["ColIsRollNumberRequired"].Value = txtIsRollNoReq.Text;
            }
            
            dgvPurchaseDetail.Rows[x - 1].Cells["ColAmt"].Value = txtAmt.Text;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColItemCode"].Value = txtItemCode.Text;
            if (txtIsCutting.Text == "Y")
            {
                dgvPurchaseDetail.Rows[x - 1].Cells["colISCutting"].Value = txtIsCutting.Text;
            }
            else
            {
                dgvPurchaseDetail.Rows[x - 1].Cells["colISCutting"].Value = txtIsCutting.Text;
            }
            totAmtFromGrid = totAmtFromGrid + Convert.ToDecimal(txtAmt.Text);
            Calculations();
        }

        private void Calculations()
        {            
            if (txtDiscountPer.Text.Trim() !="")
            {
                discount = totAmtFromGrid * (Convert.ToDecimal(txtDiscountPer.Text) / 100);
                discount = decimal.Round(discount, 2);
                txtDicountRupee.Text = discount.ToString();
            }
            if (txtExDutyPer.Text.Trim() !="")
            {
                exduty = totAmtFromGrid * (Convert.ToDecimal(txtExDutyPer.Text) / 100);
                exduty = decimal.Round(exduty, 2);
                txtExDutyRupee.Text = exduty.ToString();
            }
            if (txtVatPer.Text.Trim() !="")
            {
                vat = totAmtFromGrid * (Convert.ToDecimal(txtVatPer.Text) / 100);
                vat = decimal.Round(vat, 2);
                txtVatRupee.Text = vat.ToString();
            }
            totAmt = totAmtFromGrid - discount + exduty + vat;
            totAmt = decimal.Round(totAmt, 2);
            txtTotAmt.Text = totAmt.ToString();
        }
        private void FnClear()
        {
            listFlag = true;
            txtItem.Clear();
            listFlag = false;
            txtUnitRate.Clear();
            txtRollNo.Clear();
            txtQty.Clear();
            txtAmt.Clear();
        }

        private bool CheckDupItem(string s)
        {

            bool dup = false;
            if (s == newMode)
            {
                for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                {
                    if (dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value.ToString() == txtItemCode.Text && dgvPurchaseDetail.Rows[i].Cells["ColRollNo"].Value.ToString() == txtRollNo.Text.Trim())
                    {                       
                        dup = true;
                        MessageBox.Show("Data Already Entered");
                    }
                }
                return dup;
            }
            else
            {
                for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                {
                    if (dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value.ToString() == txtItemCode.Text && i != row)
                    {
                        dup = true;
                        MessageBox.Show("Data Already Exist");
                        break;
                    }
                }
                return dup;
            }
        }

        private void EditData()
        {
            decimal amt = 0.0M;
            dgvPurchaseDetail.Rows[row].Cells["ColItem"].Value = txtItem.Text;
            dgvPurchaseDetail.Rows[row].Cells["ColUnitRate"].Value = txtUnitRate.Text;
            dgvPurchaseDetail.Rows[row].Cells["ColUnit"].Value = cmbUnit.Text;
            dgvPurchaseDetail.Rows[row].Cells["ColUnitCode"].Value = cmbUnit.SelectedValue;
            dgvPurchaseDetail.Rows[row].Cells["ColQty"].Value = txtQty.Text;
            amt = Convert.ToDecimal(dgvPurchaseDetail.Rows[row].Cells["ColAmt"].Value);
            dgvPurchaseDetail.Rows[row].Cells["ColAmt"].Value = txtAmt.Text;
            dgvPurchaseDetail.Rows[row].Cells["ColItemCode"].Value = txtItemCode.Text;
            if (txtIsRollNoReq.Text == "Y")
            {
                dgvPurchaseDetail.Rows[row].Cells["ColIsRollNumberRequired"].Value = txtIsRollNoReq.Text;
                dgvPurchaseDetail.Rows[row].Cells["ColRollNo"].Value = txtRollNo.Text;
            }
            else
            {
                dgvPurchaseDetail.Rows[row].Cells["ColIsRollNumberRequired"].Value = txtIsRollNoReq.Text;
                dgvPurchaseDetail.Rows[row].Cells["ColRollNo"].Value = null;
            }            
            if (txtIsCutting.Text == "Y")
            {
                dgvPurchaseDetail.Rows[row].Cells["colISCutting"].Value = txtIsCutting.Text;
            }
            else
            {
                dgvPurchaseDetail.Rows[row].Cells["colISCutting"].Value = txtIsCutting.Text;
            }
            totAmtFromGrid = totAmtFromGrid - amt;
            totAmtFromGrid = totAmtFromGrid + Convert.ToDecimal(txtAmt.Text);
            Calculations();
        }

        private bool chechRollNoRequired()
        {
            bool check = false;
            if (txtIsRollNoReq.Text == "Y" && txtRollNo.Text == "")
            {
                check = true;
                txtErrMsg.Visible = true;
                txtErrMsg.Text = "Enter Roll No";
                txtRollNo.Focus();
            }
           return check;
        }
        private void txtAmt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckValidItem() == false)
                {
                }
                else if (CheckUnitRateTextbox() == true)
                {
                }
                else if (CheckQtyTextBox() == true)
                {
                }
                else if (chechRollNoRequired() == true)
                {
                }
                else if (checkAmtTextBox() == true)
                {
                }
                else
                {
                    if (row == -1)
                    {
                        if (CheckDupItem(newMode) == false)
                        {
                            EnterData();
                        }
                    }
                    else
                    {
                        if (CheckDupItem(editMode) == false)
                        {
                            EditData();
                            row = -1;
                        }
                    }
                    txtErrMsg.Visible = false;
                    FnClear();
                    txtItem.Focus();
                }
            }
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
        private void txtUnitRate_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtUnitRate.Text);
        }
        private void txtQty_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtQty.Text);
        }
        private void txtAmt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtAmt.Text);
        }
        private char OnlyDigit(char c)
        {
            if (c == (char)8)
            {
            }
            else if (char.IsDigit(c) == false)
            {
                c = Convert.ToChar(Keys.None);
            }
            return c;
        }
        private void txtInvoiceNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDigit(e.KeyChar);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckValidInvoiceNum()
        {
            bool dup = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select COUNT(*) from tPurchase where InvoiceNo=@no and acccode=@ac";
            sda.SelectCommand.Parameters.AddWithValue("@no", Convert.ToInt32(txtInvoiceNo.Text));
            sda.SelectCommand.Parameters.AddWithValue("@ac", cmbSupplier.SelectedValue);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) != 0)
            {
                dup = true;
            }
            return dup;
        }
        private int InsertIntoPurchasHD()
        {
            int localPO = 0;
            string FromPO = "N";
            if (rbFromPuchaseOrder.Checked == true)
            {                
                localPO = Convert.ToInt32 ( cmbPoNo.Text);
                FromPO = "Y";
            }
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "InsertIntoPurchasHD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromGIRN", "Y");
            cmd.Parameters.AddWithValue("@PJVDate", dtpPjvDate.Value);
            cmd.Parameters.AddWithValue("@InvoiceNo", Convert.ToInt32(txtInvoiceNo.Text));
            cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value);
            cmd.Parameters.AddWithValue("@VAT", vat);
            cmd.Parameters.AddWithValue("@Exciseduty", exduty);
            cmd.Parameters.AddWithValue("@Discount", discount);
            cmd.Parameters.AddWithValue("@InvoiceAmt", Convert.ToDouble ( txtTotAmt.Text));
            cmd.Parameters.AddWithValue("@amountPaid", 0);
            cmd.Parameters.AddWithValue("@dueAmt", Convert.ToDouble(txtTotAmt.Text));
            cmd.Parameters.AddWithValue("@debitNote", 0);
            cmd.Parameters.AddWithValue("@acCode", cmbSupplier.SelectedValue);
            cmd.Parameters.AddWithValue("@scn", "Purchase");
            cmd.Parameters.AddWithValue("@disPer", Convert.ToDecimal(txtDiscountPer.Text));
            cmd.Parameters.AddWithValue("@ExDutyPer", Convert.ToDecimal(txtExDutyPer.Text));
            cmd.Parameters.AddWithValue("@VatPer", Convert.ToDecimal(txtVatPer.Text));
            cmd.Parameters.AddWithValue("@FromPO",FromPO);
            cmd.Parameters.AddWithValue("@PONO", localPO);
            cmd.Parameters.AddWithValue("@lnum", 0).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            pjv = Convert.ToInt32(cmd.Parameters["@lnum"].Value);
            txtPjvNo.Text = pjv.ToString();
            con.Close();
            return pjv;
        }

        private void InsertIntoPurchaseDtl(int pjv)
        {
            int localPO = 0;            
            if (rbFromPuchaseOrder.Checked == true)
            {
                localPO = Convert.ToInt32(cmbPoNo.Text);                
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tPurchaseDt(pjv,pjvdate,ItemCode,Qty,PurchaseRate,Amt,unit,rollNo,CuttingQty,CuttingBalQty,PONO) values(@pjv,@pjvdate,@ItemCode,@Qty,@PurchaseRate,@Amt,@unit,@rollNo,0,@Qty,@pono)";
            for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
            {
                cmd.Parameters.AddWithValue("@pjv", pjv);
                cmd.Parameters.AddWithValue("@pjvdate", dtpPjvDate.Value);
                cmd.Parameters.AddWithValue("@ItemCode", dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value);
                cmd.Parameters.AddWithValue("@Qty", dgvPurchaseDetail.Rows[i].Cells["ColQty"].Value);
                cmd.Parameters.AddWithValue("@PurchaseRate", dgvPurchaseDetail.Rows[i].Cells["ColUnitRate"].Value);
                if (dgvPurchaseDetail.Rows[i].Cells["ColIsRollNumberRequired"].Value.ToString () == "Y")
                {
                    cmd.Parameters.AddWithValue("@rollNo", dgvPurchaseDetail.Rows[i].Cells["ColRollNo"].Value);
                    
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rollNo", DBNull.Value);
                }
                decimal amt=Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells["ColAmt"].Value);
                cmd.Parameters.AddWithValue("@Amt",amt);
                cmd.Parameters.AddWithValue("@unit", Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells["ColUnitCode"].Value));
                cmd.Parameters.AddWithValue("@pono", localPO);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }   
     
        private void InsLedgerFromPurch()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "InsLedgerFromPurch";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pjv", pjv);
            cmd.Parameters.AddWithValue("@comcode", 0);
            cmd.Parameters.AddWithValue("@ofcode", 0);
            cmd.Parameters.AddWithValue("@vtype", "GIR");
            cmd.Parameters.AddWithValue("@Cleared", "N");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void UpdateInMaterial()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "UpdateMaterialPurchase";
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
            {
                cmd.Parameters.AddWithValue("@mtcode", dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value);
                cmd.Parameters.AddWithValue("@inward", dgvPurchaseDetail.Rows[i].Cells["ColQty"].Value);
                cmd.Parameters.AddWithValue("@isCutting", dgvPurchaseDetail.Rows[i].Cells["colISCutting"].Value);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();            
        } 
       
        private void FillGridForDailyAccMaster()
        {
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select acccode,db,cr from tLedgerDTL where voucherno=@no and vouchertype=@vtyp";
            sda.SelectCommand.Parameters.AddWithValue("@no", Convert.ToInt32(txtPjvNo.Text));
            sda.SelectCommand.Parameters.AddWithValue("@vtyp", "GIR");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(1);
                int x = dataGridView1.Rows.Count;
                dataGridView1.Rows[x - 1].Cells["ColAcc"].Value = ds.Tables[0].Rows[i]["acccode"];
                dataGridView1.Rows[x - 1].Cells["colDeb"].Value = ds.Tables[0].Rows[i]["db"];
                dataGridView1.Rows[x - 1].Cells["ColCre"].Value = ds.Tables[0].Rows[i]["cr"];
            }
        }
        private void FillGridWithParents()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select AccCode,Groupno from tAccountMaster";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells["ColAcc"].Value) == Convert.ToInt32(ds.Tables[0].Rows[j]["AccCode"]) && Convert.ToInt32(ds.Tables[0].Rows[j]["Groupno"]) != 0)
                    {
                        dataGridView1.Rows.Add(1);
                        int x = dataGridView1.Rows.Count;
                        dataGridView1.Rows[x - 1].Cells["ColAcc"].Value = ds.Tables[0].Rows[j]["Groupno"];
                        dataGridView1.Rows[x - 1].Cells["colDeb"].Value = dataGridView1.Rows[i].Cells["colDeb"].Value;
                        dataGridView1.Rows[x - 1].Cells["ColCre"].Value = dataGridView1.Rows[i].Cells["ColCre"].Value;
                        break;
                    }
                }
            }
        }
        private void UpdDailyAccMaster(char c)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            if (c == plus)
            {
                cmd.CommandText = "update tDailyAccountMaster set db=db+@db,cr=cr+@cr where accCode=@code and dt=@dt";
            }
            else if (c == minus)
            {
                cmd.CommandText = "update tDailyAccountMaster set db=db-@db,cr=cr-@cr where accCode=@code and dt=@dt";
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                cmd.Parameters.AddWithValue("@db", dataGridView1.Rows[i].Cells["colDeb"].Value);
                cmd.Parameters.AddWithValue("@cr", dataGridView1.Rows[i].Cells["ColCre"].Value);
                cmd.Parameters.AddWithValue("@code", dataGridView1.Rows[i].Cells["ColAcc"].Value);
                cmd.Parameters.AddWithValue("@dt", dtpPjvDate.Value.ToShortDateString());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }
        private void UpdClosOpenBal(char c)
        {
            int sign = 1;
            if (c == minus)
            {
                sign = -1;
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UpdClosOpenBal";
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                cmd.Parameters.AddWithValue("@dt", dtpPjvDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@acc", Convert.ToInt32(dataGridView1.Rows[i].Cells["ColAcc"].Value));
                cmd.Parameters.AddWithValue("@debit", Convert.ToDecimal(dataGridView1.Rows[i].Cells["colDeb"].Value) * sign);
                cmd.Parameters.AddWithValue("@credit", Convert.ToDecimal(dataGridView1.Rows[i].Cells["ColCre"].Value) * sign);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Enter Invoice Number");
                txtInvoiceNo.Focus();
            }            
            else if (dgvPurchaseDetail.Rows.Count == 0)
            {
                MessageBox.Show("Data Not Entered");
            }
            else
            {
                btnSave.Enabled = false;
                if (txtMode.Text == newMode)
                {
                    if (CheckValidInvoiceNum() == true)
                    {
                        MessageBox.Show("The Invoice number is already selected");
                    }
                    else
                    {
                        SaveBtnClick(newMode);
                    }
                }
                else if (txtMode.Text == editMode)
                {
                    SaveBtnClick(editMode);
                }
            }
            FillGirnGrid();
        }


        private void SaveBtnClick(string s)
        {            
            if (s == newMode)
            {                
                InsertIntoPurchaseDtl(InsertIntoPurchasHD());
                InsLedgerFromPurch();
                UpdateInMaterial();
                FillGridForDailyAccMaster();
                //FillGridWithParents();
               // UpdDailyAccMaster(plus);
               // UpdClosOpenBal(plus);
            }
            else if (s == editMode)
            {
                //ReverseWarehouseStock();
                //EditPurchase();//delete purchase + add to HD
                //FillGridForDailyAccMaster();
                //FillGridWithParents();
                //UpdDailyAccMaster(minus);
                //UpdClosOpenBal(minus);
                //DelVoucherNo();
                //pjv = Convert.ToInt32(txtPjvNo.Text);
                //InsertIntoPurchaseDtl(pjv);
                //InsLedgerFromPurch();
                //FillGridForDailyAccMaster();
                //FillGridWithParents();
                //UpdDailyAccMaster(plus);
                //UpdClosOpenBal(plus);
                //UpdateInMaterial();
                //FindRollNumberBasedStock();
            }
            AdjustPOQty();
        }

        private void AdjustPOQty()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "AdjustPOQty";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmbPoNo.Text.Trim().Length == 0)
            {
                cmd.Parameters.AddWithValue("@pono", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@pono", Convert.ToInt32(cmbPoNo.Text));
            }
            cmd.ExecuteNonQuery();
            con.Close();        
        }


        private void ReverseWarehouseStock()
        { 

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select ItemCode,Qty   from tPurchaseDt where pjv=@pjvno";
            sda.SelectCommand.Parameters.AddWithValue("@pjvno", Convert.ToInt32(txtPjvNo.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ReverseStock(Convert.ToInt32(ds.Tables[0].Rows[i]["ItemCode"]),Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]));
            }
        }

        private void ReverseStock(int mc,double qty)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "update tWarehouseMatStock set closingStock = closingStock - @qty where matcode = @mc and warehousecode in (1,2)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mc",mc);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.ExecuteNonQuery();
            con.Close();
        }
                   

        private void FindRollNumberBasedStock()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "FindRollNumberBasedStock";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pjvno", Convert.ToInt32(txtPjvNo.Text));
            cmd.ExecuteNonQuery();
            con.Close();       
        }


        private void EditPurchase()
        {
            int localPO = 0;
            string FromPO = "N";
            if (rbFromPuchaseOrder.Checked == true)
            {
                localPO = Convert.ToInt32(cmbPoNo.Text);
                FromPO = "Y";
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "EditPurchase";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromGIRN", "Y");
            cmd.Parameters.AddWithValue("@pjv", Convert.ToInt32(txtPjvNo.Text));
            cmd.Parameters.AddWithValue("@PJVDate", dtpPjvDate.Value);
            cmd.Parameters.AddWithValue("@InvoiceNo", Convert.ToInt32(txtInvoiceNo.Text));
            cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value);
            cmd.Parameters.AddWithValue("@VAT", vat);
            cmd.Parameters.AddWithValue("@Exciseduty", exduty);
            cmd.Parameters.AddWithValue("@Discount", discount);
            cmd.Parameters.AddWithValue("@InvoiceAmt", Convert.ToDouble(txtTotAmt.Text));
            cmd.Parameters.AddWithValue("@amountPaid", 0);
            cmd.Parameters.AddWithValue("@dueAmt", Convert.ToDouble(txtTotAmt.Text));
            cmd.Parameters.AddWithValue("@debitNote", 0);
            cmd.Parameters.AddWithValue("@acccode", cmbSupplier.SelectedValue);
            cmd.Parameters.AddWithValue("@FromPO", FromPO);
            cmd.Parameters.AddWithValue("@PONO", localPO);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            gpDirectOrPO.Enabled = true;
            txtPjvNo.Clear();
            txtMode.Text = newMode;
            btnSave.Enabled = true;
            dgvPurchaseDetail.Rows.Clear();
            txtInvoiceNo.Clear();
            dtpPjvDate.Value = DateTime.Now;
            dtpInvoiceDate.Value = DateTime.Now;
            rbDirectEntry.Checked = true;
            FillSupplierCombo();
            listFlag = true;
            txtItem.Clear();
            listFlag = false;
            txtUnitRate.Clear();
            txtQty.Clear();
            txtAmt.Clear();
            txtDiscountPer.Text = zeroAmt;
            txtDicountRupee.Text = zeroAmt;
            txtExDutyPer.Text = zeroAmt;
            txtExDutyRupee.Text = zeroAmt;
            txtVatPer.Text = zeroAmt;
            txtVatRupee.Text = zeroAmt;
            txtTotAmt.Text = zeroAmt;
            txtErrMsg.Visible = false;
            totAmtFromGrid = 0;
            totAmt = 0;
            discount = 0;   
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtDiscountPer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtDiscountPer.Text);           
        }
        private void txtDicountRupee_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtDicountRupee.Text);
           
        }
        private void txtExDutyPer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtExDutyPer.Text);
        }
        private void txtExDutyRupee_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtExDutyRupee.Text);
        }
        private void txtVatPer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtVatPer.Text);
        }
        private void txtVatRupee_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtVatRupee.Text);
        }               
        private void txtDiscountPer_TextChanged_1(object sender, EventArgs e)
        {
            if (txtDiscountPer.Text != "" && txtDiscountPer.Text != "." && RupeeEntry == false)
            {
                PerEntry = true;
                Calculations();
                PerEntry = false;
            }
        }
        private void txtExDutyPer_TextChanged_1(object sender, EventArgs e)
        {
            if (txtExDutyPer.Text != "" && txtExDutyPer.Text != "." && RupeeEntry == false)
            {
                PerEntry = true;
                Calculations(); 
                PerEntry = false;
            }
        }
        private void txtVatPer_TextChanged_1(object sender, EventArgs e)
        {
            if (txtVatPer.Text != "" && txtVatPer.Text!="." && RupeeEntry == false)
            {
                PerEntry = true;
                Calculations();
                PerEntry = false;
            }
        }
        public void CallFromDailyAccMaster(int vno)
        {
            int rowNo = 0;
            FillGirnGrid();
            for (int i = 0; i < dgvGirnHead.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvGirnHead.Rows[i].Cells["ColPJVNo"].Value) == vno)
                {
                    rowNo = i;
                    break;
                }
            }
            CellDoubleClick(rowNo);
            txtMode.Visible = false;
            label25.Visible = false;
            tabControl1.Enabled = false;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            FillGirnGrid();
        }
        private void FillGirnGrid()
        {
            dgvGirnHead.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select PJV,convert(nvarchar(10), PJVDate,103) PJVDate,InvoiceNo,convert(nvarchar(10), InvoiceDate,103) InvoiceDate,InvoiceAmt,amountPaid,dueAmt,Discount,Exciseduty,VAT,acccode,frompo,pono from tPurchase  where FromGIRN=@Y";
            sda.SelectCommand.Parameters.AddWithValue("@Y", "Y");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvGirnHead.Rows.Add(1);
                int x = dgvGirnHead.Rows.Count;
                dgvGirnHead.Rows[x - 1].Cells["ColPJVNo"].Value = ds.Tables[0].Rows[i]["PJV"];
                dgvGirnHead.Rows[x - 1].Cells["ColPjvDate"].Value = ds.Tables[0].Rows[i]["PJVDate"];
                dgvGirnHead.Rows[x - 1].Cells["ColInvoiceNo"].Value = ds.Tables[0].Rows[i]["InvoiceNo"];
                dgvGirnHead.Rows[x - 1].Cells["ColInvoiceDate"].Value = ds.Tables[0].Rows[i]["InvoiceDate"];
                dgvGirnHead.Rows[x - 1].Cells["ColInvoAmt"].Value = ds.Tables[0].Rows[i]["InvoiceAmt"];
                dgvGirnHead.Rows[x - 1].Cells["ColPaid"].Value = ds.Tables[0].Rows[i]["amountPaid"];
                dgvGirnHead.Rows[x - 1].Cells["ColDue"].Value = ds.Tables[0].Rows[i]["dueAmt"];
                dgvGirnHead.Rows[x - 1].Cells["ColDiscount"].Value = ds.Tables[0].Rows[i]["Discount"];
                dgvGirnHead.Rows[x - 1].Cells["ColExDuty"].Value = ds.Tables[0].Rows[i]["Exciseduty"];
                dgvGirnHead.Rows[x - 1].Cells["ColVat"].Value = ds.Tables[0].Rows[i]["VAT"];
                dgvGirnHead.Rows[x - 1].Cells["ColAccSupCode"].Value = ds.Tables[0].Rows[i]["acccode"];
                dgvGirnHead.Rows[x - 1].Cells["ColFromPO"].Value = ds.Tables[0].Rows[i]["FromPO"];
                dgvGirnHead.Rows[x - 1].Cells["ColPono"].Value = ds.Tables[0].Rows[i]["PONO"];
            }
        }


        private void dgvGirnHead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i != -1)
            {
                CellDoubleClick(i);
            }
        }

        private void CellDoubleClick(int i)
        {
            if (dgvGirnHead.Rows[i].Cells["ColFromPO"].Value.ToString() == "Y")
            {
                rbFromPuchaseOrder.Checked = true;
                cmbPoNo.Text = dgvGirnHead.Rows[i].Cells["ColPono"].Value.ToString();
            }
            totAmtFromGrid = 0;
            gpDirectOrPO.Enabled = false;
            txtMode.Text = editMode;
            btnSave.Enabled = true;
            dgvPurchaseDetail.Rows.Clear();
            int pjvno = Convert.ToInt32(dgvGirnHead.Rows[i].Cells["ColPJVNo"].Value);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "fillPurchaseDetails";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@pjv",pjvno);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                dgvPurchaseDetail.Rows.Add(1);
                int x=dgvPurchaseDetail.Rows.Count;
                dgvPurchaseDetail.Rows[x - 1].Cells["ColSlNo"].Value = x;      
                dgvPurchaseDetail.Rows[x - 1].Cells["ColItem"].Value = ds.Tables[0].Rows[j]["MatDesc"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitRate"].Value = ds.Tables[0].Rows[j]["PurchaseRate"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColUnit"].Value = ds.Tables[0].Rows[j]["Unit"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColQty"].Value = ds.Tables[0].Rows[j]["Qty"];
                if (ds.Tables[0].Rows[j]["rollNo"] == DBNull.Value)
                {
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColRollNo"].Value = null;
                }
                else
                {
                    dgvPurchaseDetail.Rows[x - 1].Cells["ColRollNo"].Value = ds.Tables[0].Rows[j]["rollNo"];
                }
                dgvPurchaseDetail.Rows[x - 1].Cells["ColAmt"].Value = ds.Tables[0].Rows[j]["Amt"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColItemCode"].Value = ds.Tables[0].Rows[j]["MatCode"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitCode"].Value = ds.Tables[0].Rows[j]["unitcode"];
                dgvPurchaseDetail.Rows[x - 1].Cells["colISCutting"].Value = ds.Tables[0].Rows[j]["ToCuttingDept"];               
                totAmtFromGrid = totAmtFromGrid + Convert.ToDecimal(dgvPurchaseDetail.Rows[x - 1].Cells["ColAmt"].Value);
                dgvPurchaseDetail.Rows[x - 1].Cells["ColIsRollNumberRequired"].Value = ds.Tables[0].Rows[j]["IsRollNumberRequired"];               
            }
            txtPjvNo.Text=pjvno.ToString();
            txtInvoiceNo.Text = dgvGirnHead.Rows[i].Cells["ColInvoiceNo"].Value.ToString();
            txtDicountRupee.Text = dgvGirnHead.Rows[i].Cells["ColDiscount"].Value.ToString();
            txtExDutyRupee.Text = dgvGirnHead.Rows[i].Cells["ColExDuty"].Value.ToString();
            txtVatRupee.Text = dgvGirnHead.Rows[i].Cells["ColVat"].Value.ToString();
            txtTotAmt.Text = dgvGirnHead.Rows[i].Cells["ColInvoAmt"].Value.ToString();
            cmbSupplier.SelectedValue = dgvGirnHead.Rows[i].Cells["ColAccSupCode"].Value;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dtpPjvDate.Value = Convert.ToDateTime(dgvGirnHead.Rows[i].Cells["ColPjvDate"].Value);
            dtpInvoiceDate.Value = Convert.ToDateTime(dgvGirnHead.Rows[i].Cells["ColInvoiceDate"].Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            
            tabControl1.SelectedTab = tabPage1;
        }

        private void txtDiscountPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                if (txtDiscountPer.Text.Trim() == zeroAmt || txtDiscountPer.Text.Trim() == "")
                {
                    txtDicountRupee.Focus();
                }
                else
                {
                    txtExDutyPer.Focus();
                }
            }
        }

        private void txtExDutyPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                if (txtExDutyPer.Text.Trim() == zeroAmt || txtExDutyPer.Text == "")
                {
                    txtExDutyRupee.Focus();
                }
                else
                {
                    txtVatPer.Focus();
                }
            }
        }

        private void txtDicountRupee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtExDutyPer.Focus();
            }
        }

        private void txtExDutyRupee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtVatPer.Focus();
            }
        }

        private void FillGridForEdit(int i)
        {
            listFlag = true;
            txtItem.Text = dgvPurchaseDetail.Rows[i].Cells["ColItem"].Value.ToString();
            listFlag = false;
            txtUnitRate.Text = dgvPurchaseDetail.Rows[i].Cells["ColUnitRate"].Value.ToString();           
            txtQty.Text = dgvPurchaseDetail.Rows[i].Cells["ColQty"].Value.ToString();
            if (dgvPurchaseDetail.Rows[i].Cells["ColRollNo"].Value != null)
            {
                txtRollNo.Text = dgvPurchaseDetail.Rows[i].Cells["ColRollNo"].Value.ToString();
            }
            else
            {
                txtRollNo.Text = "";
            }
            txtAmt.Text = dgvPurchaseDetail.Rows[i].Cells["ColAmt"].Value.ToString();
            txtItemCode.Text = dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value.ToString();
            FillUnitCombo(Convert.ToInt32(txtItemCode.Text));
            cmbUnit.Text = dgvPurchaseDetail.Rows[i].Cells["ColUnit"].Value.ToString();
            txtIsRollNoReq.Text = dgvPurchaseDetail.Rows[i].Cells["ColIsRollNumberRequired"].Value.ToString(); 
        }

        private void dgvPurchaseDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if (row != -1)
            {
                string val = CustomMessageBox.ShowBox();
                if (val == "Edit")
                {
                    FillGridForEdit(row);
                }
                else if (val == "Delete")
                {
                    totAmtFromGrid = totAmtFromGrid - Convert.ToDecimal(dgvPurchaseDetail.Rows[row].Cells["ColAmt"].Value);
                    Calculations();
                    dgvPurchaseDetail.Rows.RemoveAt(row);
                    row = -1;
                }
                else if (val == "Cancel")
                {
                    row = -1;
                }
            }
        }

        private void DelVoucherNo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "DelVoucherNo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vno", Convert.ToInt32(txtPjvNo.Text));
            cmd.Parameters.AddWithValue("@vtyp", "GIR");
            cmd.Parameters.AddWithValue("@vdate", dtpPjvDate.Value.ToShortDateString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void DelPurchase()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("",con);
            cmd.CommandText = "DelPurchase";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pjv",Convert.ToInt32(txtPjvNo.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMode.Text != editMode)
            {
                MessageBox.Show("Select Voucher No");
            }
            else
            {
                var result = MessageBox.Show("Do you sure want to Delete?", "Delete",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FillGridForDailyAccMaster();
                    FillGridWithParents();
                    UpdDailyAccMaster(minus);
                    UpdClosOpenBal(minus);
                    DelVoucherNo();
                    DelPurchase();
                    dgvPurchaseDetail.Rows.Clear();
                    txtPjvNo.Clear();
                    txtInvoiceNo.Clear();
                    dtpPjvDate.Value = DateTime.Now;
                    txtMode.Text = newMode;
                    FillGirnGrid();
                }
            }
        }
        private string EntryForRupees(char c)
        {
            decimal disRupee = Convert.ToDecimal(txtDicountRupee.Text);
            decimal ExRupee = Convert.ToDecimal(txtExDutyRupee.Text);
            decimal vatRupee = Convert.ToDecimal(txtVatRupee.Text);
            string value="";
            txtTotAmt.Text = (totAmtFromGrid - disRupee + ExRupee + vatRupee).ToString();
            if (totAmtFromGrid != 0)
            {
                if (c == 'd')
                {
                    value = (disRupee * 100 / totAmtFromGrid).ToString();
                }
                else if (c == 'e')
                {
                    value = (ExRupee * 100 / totAmtFromGrid).ToString();
                }
                else if (c == 'v')
                {
                    value = (vatRupee * 100 / totAmtFromGrid).ToString();
                }
            }
            return value;        
        }
        private void txtDicountRupee_TextChanged(object sender, EventArgs e)
        {
            if (PerEntry == false)
            {
                RupeeEntry = true;
                if (txtDicountRupee.Text != "")
                {
                    txtDiscountPer.Text = EntryForRupees('d');
                }
                RupeeEntry = false;
            }
        }

        private void txtExDutyRupee_TextChanged(object sender, EventArgs e)
        {
            if (PerEntry == false)
            {
                RupeeEntry = true;
                if (txtExDutyRupee.Text != "")
                {
                    txtExDutyPer.Text = EntryForRupees('e');
                }
                RupeeEntry = false;
            }
        }

        private void txtVatRupee_TextChanged(object sender, EventArgs e)
        {
            if (PerEntry == false)
            {
                RupeeEntry = true;
                if (txtVatRupee.Text != "")
                {
                    txtVatPer.Text = EntryForRupees('v');
                }
                RupeeEntry = false;
            }
        }

        private void txtRollNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtIsRollNoReq.Text != "")
                {
                    txtErrMsg.Visible = false;
                    txtAmt.Text = (decimal.Round(Convert.ToDecimal(txtUnitRate.Text) * Convert.ToDecimal(txtQty.Text), 2)).ToString();
                    txtAmt.Focus();
                }
                else
                {
                    txtRollNo.Focus();
                    txtErrMsg.Visible = true;
                    txtErrMsg.Text = "Enter Roll No";
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmbPoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ForFromPO();
        }        
    }
}
