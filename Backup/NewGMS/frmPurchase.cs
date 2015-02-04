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
    public partial class frmPurchase : Form
    {
        public frmPurchase()
        {
            InitializeComponent();
        }
        bool listFlag = false;
        bool checkflag = false;
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
            FillUnitCombo();
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
            cmbSupplier.ValueMember = "Suppliercode";
        }
        private void FillUnitCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Unit,UnitId from UnitMaster";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbUnit.DataSource = ds.Tables[0];
            cmbUnit.DisplayMember = "Unit";
            cmbUnit.ValueMember = "UnitId";
        }
        private void ItemList()
        {
            lvItems.Items.Clear();
            lvItems.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con); 
            string s1 = "select a.AccName,a.AccCode,c.AccName groupName,b.Address,a.bal  from tAccountMaster a ";
            string s2 = " left join tSupplier b on a.SCEOcode = b.Suppliercode and a.SupCusEmpOth ='SUP' ";
            string s3 = " left join tAccountMaster c on c.AccCode = a.Groupno ";
            string s4 = " where a.GrpOrAcc ='A' and a.AccName   like @ch+'%' ";
            sda.SelectCommand.CommandText = s1 + s2 + s3 + s4;
            sda.SelectCommand.Parameters.AddWithValue("@ch", txtItem.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvItems.Items.Add(ds.Tables[0].Rows[i]["AccName"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["AccCode"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Groupname"].ToString());
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
            sda.SelectCommand.CommandText = "select AccCode from tAccountMaster where AccName=@nm";
            sda.SelectCommand.Parameters.AddWithValue("@nm", txtItem.Text.Trim());
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
            txtItemCode.Text = lvItems.SelectedItems[0].SubItems[1].Text;
            txtItem.Text = lvItems.SelectedItems[0].Text;
            lvItems.Visible = false;
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
                    txtAmt.Text = (Convert.ToDecimal(txtUnitRate.Text) * Convert.ToDecimal(txtQty.Text)).ToString();
                    txtAmt.Focus();
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
            dgvPurchaseDetail.Rows[x - 1].Cells["ColAmt"].Value = txtAmt.Text;
            dgvPurchaseDetail.Rows[x - 1].Cells["ColItemCode"].Value = txtItemCode.Text;
            totAmtFromGrid = totAmtFromGrid + Convert.ToDecimal(txtAmt.Text);
            Calculations();
        }
        private void Calculations()
        {            
            if (txtDiscountPer.Text.Trim() != zeroAmt || txtDiscountPer.Text.Trim() !="")
            {
                discount = totAmtFromGrid * (Convert.ToDecimal(txtDiscountPer.Text) / 100);                
                txtDicountRupee.Text = discount.ToString();
            }
            else if (txtDicountRupee.Text.Trim() != zeroAmt || txtDicountRupee.Text.Trim() !="")
            {
                discount = Convert.ToDecimal(txtDicountRupee.Text);
            }
            if (txtExDutyPer.Text.Trim() != zeroAmt || txtExDutyPer.Text.Trim() !="")
            {
                exduty = totAmtFromGrid * (Convert.ToDecimal(txtExDutyPer.Text) / 100);
                txtExDutyRupee.Text = exduty.ToString();
            }
            else if (txtExDutyRupee.Text.Trim() != zeroAmt || txtExDutyRupee.Text.Trim() !="")
            {
                exduty = Convert.ToDecimal(txtExDutyRupee.Text);
            }
            if (txtVatPer.Text.Trim() != zeroAmt || txtVatPer.Text.Trim() !="")
            {
                vat = totAmtFromGrid * (Convert.ToDecimal(txtVatPer.Text) / 100);
                txtVatRupee.Text = vat.ToString();
            }
            else if (txtVatRupee.Text.Trim() != zeroAmt)
            {
                vat = Convert.ToDecimal(txtVatRupee.Text);
            }
            totAmt = totAmtFromGrid - discount + exduty + vat;
            txtTotAmt.Text = totAmt.ToString();
        }
        private void FnClear()
        {
            listFlag = true;
            txtItem.Clear();
            listFlag = false;
            txtUnitRate.Clear();
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
                    if (dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value.ToString() == txtItemCode.Text)
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
            totAmtFromGrid = totAmtFromGrid - amt;
            totAmtFromGrid = totAmtFromGrid + Convert.ToDecimal(txtAmt.Text);
            Calculations();
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
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "InsertIntoPurchasHD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromGIRN", "N");
            cmd.Parameters.AddWithValue("@PJVDate", dtpPjvDate.Value);
            cmd.Parameters.AddWithValue("@InvoiceNo", Convert.ToInt32(txtInvoiceNo.Text));
            cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value);
            cmd.Parameters.AddWithValue("@VAT", vat);
            cmd.Parameters.AddWithValue("@Exciseduty", exduty);
            cmd.Parameters.AddWithValue("@Discount", discount);
            cmd.Parameters.AddWithValue("@InvoiceAmt", totAmt);
            cmd.Parameters.AddWithValue("@amountPaid", 0);
            cmd.Parameters.AddWithValue("@dueAmt", totAmt);
            cmd.Parameters.AddWithValue("@debitNote", 0);
            cmd.Parameters.AddWithValue("@supcode", cmbSupplier.SelectedValue);
            cmd.Parameters.AddWithValue("@scn", "Purchase");
            cmd.Parameters.AddWithValue("@lnum", 0).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            pjv = Convert.ToInt32(cmd.Parameters["@lnum"].Value);
            txtPjvNo.Text = pjv.ToString();
            con.Close();
            return pjv;
        }
        private void InsertIntoPurchaseDtl(int pjv)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tPurchaseDt(pjv,pjvdate,ItemCode,Qty,PurchaseRate,Amt,unit) values(@pjv,@pjvdate,@ItemCode,@Qty,@PurchaseRate,@Amt,@unit)";
            for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
            {
                cmd.Parameters.AddWithValue("@pjv", pjv);
                cmd.Parameters.AddWithValue("@pjvdate", dtpPjvDate.Value);
                cmd.Parameters.AddWithValue("@ItemCode", dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value);
                cmd.Parameters.AddWithValue("@Qty", dgvPurchaseDetail.Rows[i].Cells["ColQty"].Value);
                cmd.Parameters.AddWithValue("@PurchaseRate", dgvPurchaseDetail.Rows[i].Cells["ColUnitRate"].Value);
                cmd.Parameters.AddWithValue("@Amt", dgvPurchaseDetail.Rows[i].Cells["ColAmt"].Value);
                cmd.Parameters.AddWithValue("@unit", Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells["ColUnitCode"].Value));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }        
        private void DeleteFromLedger()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "DeleteLedgerFromGIRN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@voucherno", Convert.ToInt32(txtPjvNo.Text));
            cmd.Parameters.AddWithValue("@vtype", "PUR");
            cmd.Parameters.AddWithValue("@vdate", dtpPjvDate.Value.ToShortDateString());
            cmd.ExecuteNonQuery();
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
            cmd.Parameters.AddWithValue("@vtype", "PUR");
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
                cmd.Parameters.AddWithValue("@amt", dgvPurchaseDetail.Rows[i].Cells["ColAmt"].Value);
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
            sda.SelectCommand.Parameters.AddWithValue("@vtyp", "PUR");
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
            if (c == '-')
            {
                sign = sign * -1;
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
            else if (CheckValidInvoiceNum() == true)
            {
                MessageBox.Show("The Invoice number is already selected");
            }
            else if (dgvPurchaseDetail.Rows.Count == 0)
            {
                MessageBox.Show("Data Not Entered");
            }
            else
            {
                if (txtMode.Text == newMode)
                {
                    SaveBtnClick(newMode);
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
                FillGridWithParents();
                UpdDailyAccMaster(plus);
                UpdClosOpenBal(plus);
            }
            else if (s == editMode)
            {
                EditPurchase();//delete purchase + add to HD
                FillGridForDailyAccMaster();
                FillGridWithParents();
                UpdDailyAccMaster(minus);
                UpdClosOpenBal(minus);
                DeleteFromLedger();
                pjv = Convert.ToInt32(txtPjvNo.Text);
                InsertIntoPurchaseDtl(pjv);
                InsLedgerFromPurch();
                FillGridForDailyAccMaster();
                FillGridWithParents();
                UpdDailyAccMaster(plus);
                UpdClosOpenBal(plus);
            }
            btnSave.Enabled = false;
        }
        private void EditPurchase()
        {
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
            cmd.Parameters.AddWithValue("@InvoiceAmt", totAmt);
            cmd.Parameters.AddWithValue("@amountPaid", 0);
            cmd.Parameters.AddWithValue("@dueAmt", totAmt);
            cmd.Parameters.AddWithValue("@debitNote", 0);
            cmd.Parameters.AddWithValue("@supcode", cmbSupplier.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtPjvNo.Clear();
            txtMode.Text = newMode;
            btnSave.Enabled = true;
            dgvPurchaseDetail.Rows.Clear();
            txtInvoiceNo.Clear();
            dtpPjvDate.Value = DateTime.Now;
            dtpInvoiceDate.Value = DateTime.Now;
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
            if (txtDiscountPer.Text != "" && txtDiscountPer.Text != "." && checkflag==false)
            {                
                Calculations();
            }
        }
        private void txtExDutyPer_TextChanged_1(object sender, EventArgs e)
        {
            if (txtExDutyPer.Text != "" && txtExDutyPer.Text!=".")
            {
                Calculations();
            }
        }
        private void txtVatPer_TextChanged_1(object sender, EventArgs e)
        {
            if (txtVatPer.Text != "" && txtVatPer.Text!=".")
            {
                Calculations();
            }
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
            sda.SelectCommand.CommandText = "select PJV,convert(nvarchar(10), PJVDate,103) PJVDate,InvoiceNo,convert(nvarchar(10), InvoiceDate,103) InvoiceDate,InvoiceAmt,amountPaid,dueAmt,Discount,Exciseduty,VAT from tPurchase  where FromGIRN=@Y";
            sda.SelectCommand.Parameters.AddWithValue("@Y", "N");
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
            totAmtFromGrid = 0;
            txtMode.Text = editMode;
            btnSave.Enabled = true;
            dgvPurchaseDetail.Rows.Clear();
            int pjvno = Convert.ToInt32(dgvGirnHead.Rows[i].Cells["ColPJVNo"].Value);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "fillPurchaseDetails2";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@pjvno", pjvno);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                dgvPurchaseDetail.Rows.Add(1);
                int x=dgvPurchaseDetail.Rows.Count;
                dgvPurchaseDetail.Rows[x - 1].Cells["ColSlNo"].Value = x;      
                dgvPurchaseDetail.Rows[x - 1].Cells["ColItem"].Value = ds.Tables[0].Rows[j]["AccName"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitRate"].Value = ds.Tables[0].Rows[j]["PurchaseRate"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColUnit"].Value = ds.Tables[0].Rows[j]["unitname"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColQty"].Value = ds.Tables[0].Rows[j]["Qty"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColAmt"].Value = ds.Tables[0].Rows[j]["Amt"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColItemCode"].Value = ds.Tables[0].Rows[j]["ItemCode"];
                dgvPurchaseDetail.Rows[x - 1].Cells["ColUnitCode"].Value = ds.Tables[0].Rows[j]["unit"];
                totAmtFromGrid = totAmtFromGrid + Convert.ToDecimal(dgvPurchaseDetail.Rows[x - 1].Cells["ColAmt"].Value);
            }
            txtPjvNo.Text=pjvno.ToString();
            txtInvoiceNo.Text = dgvGirnHead.Rows[i].Cells["ColInvoiceNo"].Value.ToString();
            txtDicountRupee.Text = dgvGirnHead.Rows[i].Cells["ColDiscount"].Value.ToString();
            txtExDutyRupee.Text = dgvGirnHead.Rows[i].Cells["ColExDuty"].Value.ToString();
            txtVatRupee.Text = dgvGirnHead.Rows[i].Cells["ColVat"].Value.ToString();
            txtTotAmt.Text = dgvGirnHead.Rows[i].Cells["ColInvoAmt"].Value.ToString();           
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
            cmbUnit.Text = dgvPurchaseDetail.Rows[i].Cells["ColUnit"].Value.ToString();
            txtQty.Text = dgvPurchaseDetail.Rows[i].Cells["ColQty"].Value.ToString();
            txtAmt.Text = dgvPurchaseDetail.Rows[i].Cells["ColAmt"].Value.ToString();
            txtItemCode.Text = dgvPurchaseDetail.Rows[i].Cells["ColItemCode"].Value.ToString();
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
            cmd.Parameters.AddWithValue("@vtyp", "PUR");
            cmd.Parameters.AddWithValue("@vdate", dtpPjvDate.Value.ToShortDateString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void DelPurchase()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "DelPurchase";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pjv", Convert.ToInt32(txtPjvNo.Text));
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
                    dtpPjvDate.Value = DateTime.Now;
                    txtMode.Text = newMode;
                    FillGirnGrid();
                }
            }
        }
    }
}
