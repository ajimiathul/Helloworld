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
    public partial class frmCreditNote : Form
    {
        public frmCreditNote()
        {
            InitializeComponent();
        }        
        bool listFlag = false,saved=false;
        bool comboDateForEdit = false;
        int RowIndex = -1;
        char plus = '+', minus = '-';
        string newMode = "New", editMode = "Edit";
        string zeroAmt = "0.00";
        private void AccountNameList() 
        {
            lvAccounts.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);            
             string s1=  "select a.AccName,a.AccCode,c.AccName groupName,b.Address,a.bal  from tAccountMaster a ";
             string s2=  " left join tSupplier b on a.SCEOcode = b.Suppliercode and a.SupCusEmpOth ='SUP' ";
             string s3=  " left join tAccountMaster c on c.AccCode = a.Groupno ";
             string s4=  " where a.GrpOrAcc ='A' and a.AccName   like @ch+'%' ";
             sda.SelectCommand.CommandText = s1 + s2 + s3 + s4;
             sda.SelectCommand.Parameters.AddWithValue("@ch", txtAccount.Text.Trim());
             DataSet ds = new DataSet();
             sda.Fill(ds);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 lvAccounts.Visible = true;
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                     lvAccounts.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                     lvAccounts.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["AccCode"].ToString());
                     lvAccounts.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Groupname"].ToString());
                     lvAccounts.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Address"].ToString());
                     lvAccounts.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["bal"].ToString());
                 }
             }
             else
             {
                 lvAccounts.Visible = false;
             }
        }
        private bool CheckValidAccName()
        {
            bool Valid;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "CheckValidAccName";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@acc", txtAccount.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtHidAccCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                txtMsg.Visible = false;
                Valid = true;
                DateCombo();   
            }
            else
            {
                txtMsg.Visible = true;
                txtMsg.Text = "Enter Valid Account Name";
                Valid = false;
                cmbRefDocNo.DataSource = null;
            }
            return Valid;
        }        
        private void DateCombo()
        { 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            if (comboDateForEdit == false)
            {
                sda.SelectCommand.CommandText = "select convert(nvarchar(10),InvoiceDate,103) as InvoiceDate,InvoiceDate as InvoiceDateid from tSales where acccode=@acc and InvoiceAmt<>amountPaid union select null InvoiceDate,null InvoiceDateid ";
            }
            else
            {
                sda.SelectCommand.CommandText = "select convert(nvarchar(10),InvoiceDate,103) as InvoiceDate,InvoiceDate as InvoiceDateid from tSales where acccode=@acc union select null InvoiceDate,null InvoiceDateid ";
            }
            sda.SelectCommand.Parameters.AddWithValue("@acc", Convert.ToInt32(txtHidAccCode.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbRefDocDate.DataSource = ds.Tables[0];
                cmbRefDocDate.DisplayMember = "InvoiceDate";
                cmbRefDocDate.ValueMember = "InvoiceDateid";
            }
        }
        private void NumCombo()
        {
            if (cmbRefDocDate.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select InvoiceNo,PJV from tSales where acccode=@acc and InvoiceDate=@dt";
                sda.SelectCommand.Parameters.AddWithValue("@acc", Convert.ToInt32(txtHidAccCode.Text));
                sda.SelectCommand.Parameters.AddWithValue("@dt", cmbRefDocDate.SelectedValue);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbRefDocNo.DataSource = ds.Tables[0];
                    cmbRefDocNo.DisplayMember = "InvoiceNo";
                    cmbRefDocNo.ValueMember = "PJV";
                }
            }
            else
            {
                cmbRefDocNo.DataSource = null;
            }
        }       
        
        
       private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtAccount.Text == "")
            {
                lvAccounts.Visible = false;
            }
            if (listFlag == false)
            {
                AccountNameList();
            }
        }
        private void lvAccountsClick()
        {
            txtHidAccCode.Text = lvAccounts.SelectedItems[0].SubItems[1].Text;           
            txtAccount.Text = lvAccounts.SelectedItems[0].Text;
            lvAccounts.Visible = false; 
            txtMsg.Visible = false;
            DateCombo();
            txtDebit.Text = zeroAmt;
            txtCredit.Text = zeroAmt;
            txtCostCentre.Text = "0";
            cmbRefDocDate.Focus();
        }
        private void lvAccounts_Click(object sender, EventArgs e)
        {
            lvAccountsClick();                   
        }
        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Down)
            {
                if (lvAccounts.Items.Count > 0)
                {
                    lvAccounts.Focus();
                    lvAccounts.Items[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lvAccounts.Visible = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (CheckValidAccName() == true)
                {
                    if (lvAccounts.Visible == true)
                    {
                        lvAccounts.Focus();
                        lvAccounts.Items[0].Selected = true;
                        lvAccounts_Click(sender, e);
                    }
                    cmbRefDocDate.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                cmbRefDocDate.Focus();
            } 
        }        
        private void frmBankPaymentVoucher_Click(object sender, EventArgs e)
        {
            lvAccounts.Visible = false;
        }
        private void dgvBankPaymentVoucher_Click(object sender, EventArgs e)
        {
            lvAccounts.Visible = false;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            lvAccounts.Visible = false;
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            lvAccounts.Visible = false;
        }
        private void enterData()
        {
            dgvBankPaymentVoucher.Rows.Add(1);
            int x = dgvBankPaymentVoucher.Rows.Count;
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column1"].Value = x;
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column2"].Value = txtAccount.Text.Trim();
            if (cmbRefDocDate.Text == "")
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column3"].Value = null;
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column4"].Value = null;
            }
            else
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column3"].Value = cmbRefDocDate.Text;
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column4"].Value = cmbRefDocNo.Text;
            }
            if (txtDebit.Text != "")
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column6"].Value = txtDebit.Text;
            }
            else
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column6"].Value = zeroAmt;
            }
            if (txtCredit.Text != "")
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column7"].Value = txtCredit.Text;
            }
            else
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column7"].Value = zeroAmt;
            }
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column5"].Value =txtNarration.Text;
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column8"].Value = txtCostCentre.Text;
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column10"].Value = txtHidAccCode.Text;            
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            txtDebitTotal.Text = zeroAmt;
            txtCreditTotal.Text = zeroAmt;
            decimal db = 0.0M;
            decimal cr = 0.0M;
            for (int i = 0; i < dgvBankPaymentVoucher.Rows.Count; i++)
            {
                db = Convert.ToDecimal(dgvBankPaymentVoucher.Rows[i].Cells["Column6"].Value);
                cr = Convert.ToDecimal(dgvBankPaymentVoucher.Rows[i].Cells["Column7"].Value);
                txtDebitTotal.Text = (Convert.ToDecimal(txtDebitTotal.Text) + Convert.ToDecimal(db)).ToString();
                txtCreditTotal.Text = (Convert.ToDecimal(txtCreditTotal.Text) + Convert.ToDecimal(cr)).ToString();
            }        
        }
        private void frmBankPaymentVoucher_Shown(object sender, EventArgs e)
        {
            txtAccount.Focus();
        }
        private void lvAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                if (lvAccounts.Items.Count > 0)
                {                  
                    lvAccountsClick();                   
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lvAccounts.Visible = false;
                txtAccount.Focus();
            }
        }              
        private void dgvBankPaymentVoucher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
            fnClear();
            gbMaterialDetails.Visible = false;
            if (RowIndex != -1)
            {
                string val = CustomMessageBox.ShowBox();
                if (val == "Edit")
                {
                    dgvBankPaymentVoucherEdit(RowIndex);
                    FillMaterialDetails();
                    CalculateTotal();
                }
                else if (val == "Delete")
                {
                    dgvBankPaymentVoucherDelete(RowIndex);
                    RowIndex = -1;
                    CalculateTotal();
                }
                else if (val == "Cancel")
                {
                    RowIndex = -1;
                }
            }
        }
        private void dgvBankPaymentVoucherEdit(int i)
        {
            listFlag = true;
            txtAccount.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column2"].Value.ToString();
            txtHidAccCode.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column10"].Value.ToString();
            DateCombo();
            if (dgvBankPaymentVoucher.Rows[i].Cells["Column3"].Value != null)
            {
                cmbRefDocDate.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column3"].Value.ToString();
                NumCombo();
                cmbRefDocNo.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column4"].Value.ToString();
            }            
            txtDebit.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column6"].Value.ToString();
            txtCredit.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column7"].Value.ToString();
            txtNarration.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column5"].Value.ToString();
            txtCostCentre.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column8"].Value.ToString();
            listFlag = false;
        }
        private void dgvBankPaymentVoucherDelete(int i)
        {
            dgvBankPaymentVoucher.Rows.RemoveAt(i);
        }
        private void AllClear()
        {
            txtVoucherNo.Clear();
            txtAccount.Clear();
        }
        private void cmbRefDocDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NumCombo();
                cmbRefDocNo.Focus();
            }
        }
        private void ClearPurchaseDetails()
        {
            txtInvoiceNo.Clear();
            txtInvoiceDate.Clear();
            lvMaterialDetail.Items.Clear();
        }
        private void FillMaterialDetails()
        {
            if (cmbRefDocDate.Text != "")
            {
                lvMaterialDetail.Items.Clear();
                txtInvoiceNo.Text = cmbRefDocNo.Text;
                txtInvoiceDate.Text = cmbRefDocDate.Text;
                gbMaterialDetails.Visible = true;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select B.MatDesc,A.Qty,A.PurchaseRate,A.Amt from tPurchaseDt A left join tMaterial B on A.ItemCode=B.MatCode where pjv=@pjv";
                sda.SelectCommand.Parameters.AddWithValue("@pjv", cmbRefDocNo.SelectedValue);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvMaterialDetail.Items.Add(ds.Tables[0].Rows[i]["MatDesc"].ToString());
                    lvMaterialDetail.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Qty"].ToString());
                    lvMaterialDetail.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["PurchaseRate"].ToString());
                    string db = ds.Tables[0].Rows[i]["Amt"].ToString();
                    db = db.Substring(0, db.Length - 2);
                    lvMaterialDetail.Items[i].SubItems.Add(db);
                }
            }
            else
            {
                gbMaterialDetails.Visible = false;
            }
        }
        private void cmbRefDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillMaterialDetails();
                txtDebit.Focus();
            }
        }        
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMsg.Visible = false;
                txtCostCentre.Focus();
            }
        }
        private void txtDebit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCredit.Focus();
            }
        }
        private bool DbCrChk()
        {
            bool dbcrflag = true;
            if (txtDebit.Text.Trim() == "" || txtCredit.Text.Trim()=="")
            {                
            }
            else if ((txtDebit.Text.Trim().Length  == 0) && (txtCredit.Text.Trim ().Length  == 0))
            {
                txtDebit.Focus();
                txtMsg.Visible = true;
                txtMsg.Text = "Both Debit and Credit should not be empty";
                dbcrflag = false;
            }
            else if (Convert.ToDecimal(txtDebit.Text.Trim()) == 0 && Convert.ToDecimal(txtCredit.Text.Trim()) == 0)
            {
                txtDebit.Focus();
                txtMsg.Visible = true;
                txtMsg.Text = "Both Debit and Credit should not be zero";
                dbcrflag = false;
            }
           else if (Convert.ToDecimal(txtDebit.Text.Trim())!= 0 && Convert.ToDecimal(txtCredit.Text.Trim())!= 0)
            {
                txtDebit.Focus();
                txtMsg.Visible = true;
                txtMsg.Text = "Either Debit or Credit should be zero";
                dbcrflag = false;
            }
            return dbcrflag;
        }
        private void DbCr()
        {
            if (DbCrChk() == true)
            {
                txtMsg.Visible = false;
                txtNarration.Focus();
            }                            
        }
        private void txtCredit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DbCr();
            }
        }
        private bool CheckDupForNew()
        {
            bool dup=false;
            for (int i = 0; i < dgvBankPaymentVoucher.Rows.Count; i++)
            {
                if (txtAccount.Text == dgvBankPaymentVoucher.Rows[i].Cells["Column2"].Value.ToString())
                {
                    dup = true;
                    break;
                }                
            }
            if (dup == true)
            {
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Data Already Entered";
                }
            }
            else
            {
                txtMsg.Visible = false;
            }
            return dup;
        }
        private bool CheckDupForEdit()
        {
            bool dup = false;
            for (int i = 0; i < dgvBankPaymentVoucher.Rows.Count; i++)
            {
                if (dgvBankPaymentVoucher.Rows[i].Cells["Column2"].Value.ToString() == txtAccount.Text && i != RowIndex)
                {
                    dup = true;
                    MessageBox.Show("Data Already Exist");
                    txtAccount.Focus();
                    break;
                }
            }
            return dup;
        }
        private void EditData()
        {
            if (RowIndex != -1)
            {
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column2"].Value = txtAccount.Text;
                if (cmbRefDocDate.Text == "")
                {
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column3"].Value = null;
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column4"].Value = null;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column3"].Value = cmbRefDocDate.Text;
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column4"].Value = cmbRefDocNo.Text;
                }                
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column6"].Value = txtDebit.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column7"].Value = txtCredit.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column5"].Value = txtNarration.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column8"].Value = txtCostCentre.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column10"].Value = txtHidAccCode.Text;
                CalculateTotal();
            }
            else
            {
                enterData();
            }
            txtAccount.Focus();
        }
        private void txtCostCentre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {              
                    if (dataEntryCheck() == true)
                    {
                        //txtMode.Text == "New"
                        /* at new mode row index is -1*/
                        if (RowIndex==-1)
                        {
                            if (CheckDupForNew() == false)
                            {
                                enterData();
                                fnClear();
                            }
                            txtAccount.Focus();
                        }
                            //txtMode.Text == "Edit"                        
                        else if (RowIndex!=-1)
                        {
                            if (CheckDupForEdit() == false)
                            {
                                EditData();
                                RowIndex = -1;
                                fnClear();
                            }
                        }
                    }
            }
        }
        private void cmbRefDocDate_DropDownClosed(object sender, EventArgs e)
        {
            NumCombo();
            FillMaterialDetails();
        }
        private void cmbRefDocNo_DropDownClosed(object sender, EventArgs e)
        {
            FillMaterialDetails();
        }
        private void fnClear()
        {
            listFlag = true;
            txtAccount.Clear();
            txtNarration.Clear();
            txtHidEmpAcode.Clear();
            txtDebit.Clear();
            txtCredit.Clear();;
            txtCostCentre.Clear();
            cmbRefDocDate.DataSource = null;
            cmbRefDocNo.DataSource = null;
            listFlag = false;
            gbMaterialDetails.Visible = false;
        }        
        private bool dataEntryCheck()
        {
            txtMsg.Text = "";
            bool dataflag = false;
            if (txtAccount.Text.Trim() == "" || txtDebit.Text.Trim() == "" || txtCredit.Text.Trim() == "" || txtNarration.Text.Trim() == "" || txtCostCentre.Text.Trim() == "")
            {                             
                if (txtAccount.Text.Trim() == "")
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Should enter Account";
                    txtAccount.Focus();
                }
                else if (DbCrChk() == false)
                {

                }
                else if (DbCrChk() == false)
                {

                }
                else if (txtNarration.Text.Trim() == "")
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Enter Narration";
                    txtNarration.Focus();
                }
                else if (txtCostCentre.Text.Trim() == "")
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Enter Cost Centre";
                    txtCostCentre.Focus();
                }
                else
                {
                    txtMsg.Visible = false;
                    dataflag = true;
                }
            }
            else
            {
                txtMsg.Visible = false;
                dataflag = true;
            }
            return dataflag;
        }
        private bool ChkVoucherNo()
        {
            bool val = true ;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select voucherno from tLedgerHD where voucherno = @vno and vouchertype=@vtyp ";
            sda.SelectCommand.Parameters.AddWithValue("@vno",Convert.ToInt32 (txtVoucherNo.Text));
            sda.SelectCommand.Parameters.AddWithValue("@vtyp","CN");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                val = false;
            }
            return val;        
        }
        private void AllClearFn()
        {
            RowIndex = -1;
            txtMode.Text = newMode;
            dgvBankPaymentVoucher.Rows.Clear();
            txtVoucherNo.Clear();
            dtpVoucherDate.Value = DateTime.Now;
            fnClear();
            txtMsg.Visible = false;
            gbMaterialDetails.Visible = false;
            txtVoucherNo.Enabled = true;
            btnSave.Enabled = true;
            txtCreditTotal.Clear();
            txtDebitTotal.Clear();
        }
        private void SaveChanges()
        {
            var result = MessageBox.Show("Data Entered is Not Saved. Do you want to Save?", "Save Changes",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                btnSave.PerformClick();
            }
            else if (result == DialogResult.No)
            {
                AllClearFn();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvBankPaymentVoucher.Rows.Count > 0 && btnSave.Enabled == true)
            {
                SaveChanges();
            }
            if (saved == true)
            {
                AllClearFn();
            }
        }        
        private void DeleteLedgerDTL()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete from tLedgerDTL where voucherno=@voucherno and vouchertype=@vtype";
            cmd.Parameters.AddWithValue("@voucherno",Convert.ToInt32(txtVoucherNo.Text));
            cmd.Parameters.AddWithValue("@vtype", "CN");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void FillGridForDailyAccMaster()
        {
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select acccode,db,cr from tLedgerDTL where voucherno=@no and vouchertype=@vtyp";
            sda.SelectCommand.Parameters.AddWithValue("@no", Convert.ToInt32(txtVoucherNo.Text));
            sda.SelectCommand.Parameters.AddWithValue("@vtyp", "CN");
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
                cmd.Parameters.AddWithValue("@dt", dtpVoucherDate.Value.ToShortDateString());
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
                cmd.Parameters.AddWithValue("@dt", dtpVoucherDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@acc", Convert.ToInt32(dataGridView1.Rows[i].Cells["ColAcc"].Value));
                cmd.Parameters.AddWithValue("@debit", Convert.ToDecimal(dataGridView1.Rows[i].Cells["colDeb"].Value) * sign);
                cmd.Parameters.AddWithValue("@credit", Convert.ToDecimal(dataGridView1.Rows[i].Cells["ColCre"].Value) * sign);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }  
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtMsg.Visible = false; 
            if (txtMode.Text ==newMode)
            {
                if (txtVoucherNo.Text.Trim().Length != 0)
                {
                    if (ChkVoucherNo() == true)
                    {
                        if (dgvBankPaymentVoucher.Rows.Count != 0)
                        {
                            if ((Convert.ToDecimal(txtCreditTotal.Text) ==Convert.ToDecimal(txtDebitTotal.Text)) && (Convert.ToDecimal(txtDebitTotal.Text) != 0))
                            {
                                InsertLedgerDTL();
                                InsertLedgerHD();
                                FillGridForDailyAccMaster();
                                FillGridWithParents();
                                UpdDailyAccMaster(plus);
                                UpdClosOpenBal(plus);
                                MessageBox.Show("Data Successfully Entered");
                                saved = true;
                                btnSave.Enabled = false;
                                dgvBankPayHD.Rows.Clear();
                                tLedgerHDInGrid();
                            }
                            else
                            {
                                MessageBox.Show("Debit and Credit should be equal");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data Is Not Entered");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Voucher number already exist");
                    }
                }
                else
                {
                    MessageBox.Show("Voucher number should not be empty");
                }
            }
            else if (txtMode.Text == editMode)
            {
                if (dgvBankPaymentVoucher.Rows.Count != 0)
                {
                    if (Convert.ToDecimal(txtCreditTotal.Text) == Convert.ToDecimal(txtDebitTotal.Text) && (Convert.ToDecimal(txtDebitTotal.Text) != 0))
                    {
                        ReverseAmtInPurchase();
                        FillGridForDailyAccMaster();
                        FillGridWithParents();
                        UpdDailyAccMaster(minus);
                        UpdClosOpenBal(minus);
                        DeleteLedgerDTL();
                        InsertLedgerDTL();
                        UpdateLedgerHD();
                        FillGridForDailyAccMaster();
                        FillGridWithParents();
                        UpdDailyAccMaster(plus);
                        UpdClosOpenBal(plus);
                        MessageBox.Show("Data Successfully Updated ");
                        saved = true;
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Debit and Credit should be equal");
                    }
                }
                else
                {
                    MessageBox.Show("Data Is Not Entered");
                }
            }
            RowIndex = -1;
        }
        private void InsertLedgerDTL()
        {
            bool datepresent;
            DateTime dt1=DateTime.Now;
            int rno=0;
            decimal credit,debit;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dgvBankPaymentVoucher.Rows.Count; i++)
            {
                cmd.CommandText = "InsertLedgerDtl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vno", txtVoucherNo.Text);
                cmd.Parameters.AddWithValue("@vtyp", "CN");
                cmd.Parameters.AddWithValue("@Cleared", "N");
                cmd.Parameters.AddWithValue("@vdt", Convert.ToDateTime(dtpVoucherDate.Value.ToShortDateString()));
                cmd.Parameters.AddWithValue("@sno", i + 1);
                int a = Convert.ToInt32(dgvBankPaymentVoucher.Rows[i].Cells["Column10"].Value);
                cmd.Parameters.AddWithValue("@acode", a);
                if (dgvBankPaymentVoucher.Rows[i].Cells["Column3"].Value != null)
                {
                    datepresent = true;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                    dt1 = Convert.ToDateTime(dgvBankPaymentVoucher.Rows[i].Cells["Column3"].Value);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    cmd.Parameters.AddWithValue("@rdt", dt1);
                    rno = Convert.ToInt32(dgvBankPaymentVoucher.Rows[i].Cells["Column4"].Value);
                    cmd.Parameters.AddWithValue("@rno", rno);
                }
                else
                {
                    datepresent = false;
                    cmd.Parameters.AddWithValue("@rdt", DBNull.Value);
                    cmd.Parameters.AddWithValue("@rno", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@cqno", DBNull.Value);
                cmd.Parameters.AddWithValue("@cqdt", DBNull.Value);
                cmd.Parameters.AddWithValue("@nar", dgvBankPaymentVoucher.Rows[i].Cells["Column5"].Value.ToString());
                debit = Convert.ToDecimal(dgvBankPaymentVoucher.Rows[i].Cells["Column6"].Value);
                cmd.Parameters.AddWithValue("@db", debit);
                credit = Convert.ToDecimal(dgvBankPaymentVoucher.Rows[i].Cells["Column7"].Value);
                cmd.Parameters.AddWithValue("@cr", credit);
                cmd.Parameters.AddWithValue("@cc", Convert.ToInt32(dgvBankPaymentVoucher.Rows[i].Cells["Column8"].Value));
                cmd.Parameters.AddWithValue("@InfoAcc", DBNull.Value);
                if (datepresent == true)
                {
                    UpdatePurchase1(debit, credit, dt1, rno, a);
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }
        private void InsertLedgerHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tLedgerHD(voucherno,vouchertype,voucherdate,Amount) values(@vno,@type,@vdt,@amt)";
            cmd.Parameters.AddWithValue("@vno",Convert.ToInt32(txtVoucherNo.Text));
            cmd.Parameters.AddWithValue("@type", "CN");
            cmd.Parameters.AddWithValue("@vdt", dtpVoucherDate.Value);
            cmd.Parameters.AddWithValue("@amt", Convert.ToDecimal(txtCreditTotal.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdatePurchase1(decimal debit, decimal credit, DateTime invoDt, int invoNo, int a)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UpdateSalesForCreditNote";
            cmd.CommandType = CommandType.StoredProcedure;
            if (debit != 0)
            {
                cmd.Parameters.AddWithValue("@value", debit);
                cmd.Parameters.AddWithValue("@debitOrCredit", "d");
            }
            else if (credit != 0)
            {
                cmd.Parameters.AddWithValue("@value", credit);
                cmd.Parameters.AddWithValue("@debitOrCredit", "c");
            }
            cmd.Parameters.AddWithValue("@dt", invoDt);
            cmd.Parameters.AddWithValue("@no", invoNo);
            cmd.Parameters.AddWithValue("@ac", a);
            cmd.ExecuteNonQuery();
            con.Close();
        } 
        private void UpdateLedgerHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tLedgerHD set Amount=@Amount where voucherno=@voucherno and vouchertype=@vtype";
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtCreditTotal.Text));
            cmd.Parameters.AddWithValue("@voucherno", Convert.ToInt32(txtVoucherNo.Text));
            cmd.Parameters.AddWithValue("@vtype", "CN");
            cmd.ExecuteNonQuery();
            con.Close();
        }                    
        private void txtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar=OnlyDigit(e.KeyChar);
        }
        private void txtCostCentre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDigit(e.KeyChar);
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
        private void tLedgerHDInGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select voucherno,convert(nvarchar(10),voucherdate,103) voucherdate,Amount from tLedgerHD where vouchertype=@vtype";
            sda.SelectCommand.Parameters.AddWithValue("@vtype", "CN");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvBankPayHD.Rows.Add(1);
                int k = dgvBankPayHD.Rows.Count;
                dgvBankPayHD.Rows[i].Cells["ColVNo"].Value=ds.Tables[0].Rows[i]["voucherno"];
                dgvBankPayHD.Rows[i].Cells["ColDt"].Value = ds.Tables[0].Rows[i]["voucherdate"];
                dgvBankPayHD.Rows[i].Cells["ColAmt"].Value = ds.Tables[0].Rows[i]["Amount"];
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            dgvBankPayHD.Rows.Clear();
            tLedgerHDInGrid();
        }
        public void CallFromDailyAccMaster(int vno)
        {
            int rowNo = 0;
            tLedgerHDInGrid();
            for (int i = 0; i < dgvBankPayHD.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvBankPayHD.Rows[i].Cells["ColVNo"].Value) == vno)
                {
                    rowNo = i;
                    break;
                }
            }
            CellDoubleClick(rowNo);
            txtMode.Visible = false;
            label7.Visible = false;
            tabControl1.Enabled = false;
        }
        private void CellDoubleClick(int k)
        {
            DateTime d;
            txtMode.Text = editMode;
            if (k != -1)
            {
                int no = Convert.ToInt32(dgvBankPayHD.Rows[k].Cells["ColVNo"].Value);
                dgvBankPaymentVoucherFillFromDB(no);
                txtVoucherNo.Text = dgvBankPayHD.Rows[k].Cells["ColVNo"].Value.ToString();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                d = Convert.ToDateTime(dgvBankPayHD.Rows[k].Cells["ColDt"].Value);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dtpVoucherDate.Value = d;
                comboDateForEdit = true;
                txtVoucherNo.Enabled = false;
                CalculateTotal();
            }
        }
        private void dgvBankPayHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CellDoubleClick(e.RowIndex);
        }
        private void dgvBankPaymentVoucherFillFromDB(int no)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.slno,B.AccName acc, convert(nvarchar(10),A.refDate,103) rdt,A.refNo,A.db,A.cr,A.narration,A.costcentrecode,A.acccode accode from tLedgerDTL A left join tAccountMaster B on B.AccCode=A.acccode where voucherno=@voucherno and vouchertype=@vtype";
            sda.SelectCommand.Parameters.AddWithValue("@voucherno", no);
            sda.SelectCommand.Parameters.AddWithValue("@vtype", "CN");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvBankPaymentVoucher.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvBankPaymentVoucher.Rows.Add(1);
                int k = dgvBankPaymentVoucher.Rows.Count;
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column1"].Value = ds.Tables[0].Rows[i]["slno"];
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column2"].Value = ds.Tables[0].Rows[i]["acc"];
                if (ds.Tables[0].Rows[i]["rdt"] == DBNull.Value)
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column3"].Value = null;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column3"].Value = ds.Tables[0].Rows[i]["rdt"];
                }
                if (ds.Tables[0].Rows[i]["refNo"] == DBNull.Value)
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column4"].Value = null;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column4"].Value = ds.Tables[0].Rows[i]["refNo"];
                }
                string db = ds.Tables[0].Rows[i]["db"].ToString();
                db = db.Substring(0, db.Length - 2);
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column6"].Value = db;
                string cr = ds.Tables[0].Rows[i]["cr"].ToString();
                cr = cr.Substring(0, cr.Length - 2);
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column7"].Value = cr;
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column5"].Value = ds.Tables[0].Rows[i]["narration"];
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column8"].Value = ds.Tables[0].Rows[i]["costcentrecode"];
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column10"].Value = ds.Tables[0].Rows[i]["accode"];
                
            }
            tabControl1.SelectedTab = tabPage1;
            btnSave.Enabled = true;
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
        private void txtDebit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar,txtDebit.Text);
        }
        private void txtCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtCredit.Text);
        }
        private void frmBankPaymentVoucher_Load(object sender, EventArgs e)
        {
        
            gbMaterialDetails.Visible = false;
            txtMsg.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvBankPaymentVoucher.Rows.Count > 0 && btnSave.Enabled == true)
            {
                var result = MessageBox.Show("Data Entered is Not Saved. Do you want to Save?", "Save Changes",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }           
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
                    ReverseAmtInPurchase();
                    FillGridForDailyAccMaster();
                    FillGridWithParents();
                    UpdDailyAccMaster(minus);
                    UpdClosOpenBal(minus);
                    DelVoucherNo();
                    dgvBankPaymentVoucher.Rows.Clear();
                    txtVoucherNo.Enabled = true;
                    txtVoucherNo.Clear();
                    dtpVoucherDate.Value = DateTime.Now;
                    fnClear();
                    txtDebitTotal.Clear();
                    txtCreditTotal.Clear();
                    txtMsg.Visible = false;
                    gbMaterialDetails.Visible = false;
                    dgvBankPayHD.Rows.Clear();
                    tLedgerHDInGrid();
                    txtMode.Text = "New";
                }
            }
        }        
        private void DelVoucherNo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("",con);
            cmd.CommandText = "DelVoucherNo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vno", Convert.ToInt32(txtVoucherNo.Text));
            cmd.Parameters.AddWithValue("@vtyp", "CN");
            cmd.Parameters.AddWithValue("@vdate", dtpVoucherDate.Value.ToShortDateString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void ReverseAmtInPurchase()
        {
            SqlConnection conRead = new SqlConnection();
            conRead.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", conRead);
            sda.SelectCommand.CommandText = "select refDate,refNo,acccode,db,cr from tLedgerDTL where voucherno=@voucherno and vouchertype=@vtyp";
            sda.SelectCommand.Parameters.AddWithValue("@voucherno", Convert.ToInt32(txtVoucherNo.Text));
            sda.SelectCommand.Parameters.AddWithValue("@vtyp", "CN");
            DataSet ds = new DataSet();
            sda.Fill(ds);

            SqlConnection conWrite = new SqlConnection();
            conWrite.ConnectionString = clsDbForReports.constr;
            conWrite.Open();
            SqlCommand cmd = new SqlCommand("",conWrite);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["refDate"] != DBNull.Value)
                {
                    cmd.CommandText = "RevSalesForCreditNote";
                    cmd.Parameters.AddWithValue("@dt", ds.Tables[0].Rows[i]["refDate"]);
                    cmd.Parameters.AddWithValue("@no", Convert.ToInt32(ds.Tables[0].Rows[i]["refNo"]));
                    cmd.Parameters.AddWithValue("@ac", Convert.ToInt32(ds.Tables[0].Rows[i]["acccode"]));
                    if (Convert.ToDecimal(ds.Tables[0].Rows[i]["db"]) != 0)
                    {                        
                        cmd.Parameters.AddWithValue("@debitOrCredit", "d");
                        cmd.Parameters.AddWithValue("@value", Convert.ToDecimal(ds.Tables[0].Rows[i]["db"]));                        
                    }
                    else if (Convert.ToDecimal(ds.Tables[0].Rows[i]["cr"]) != 0)
                    {
                        cmd.Parameters.AddWithValue("@debitOrCredit", "c");
                        cmd.Parameters.AddWithValue("@value", Convert.ToDecimal(ds.Tables[0].Rows[i]["cr"]));
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            conWrite.Close();
        }
            
    }
}