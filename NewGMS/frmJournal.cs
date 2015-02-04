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
    public partial class frmJournal : Form
    {
        public frmJournal()
        {
            InitializeComponent();
        }        
        bool listFlag = false,  EmplistFlag=false ,saved=false;
        string chqdt = "";
        bool comboDateForEdit = false;
        int RowIndex = -1;
        string journal = "JRL";
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
        private bool CheckValidEmpName()
        {
            bool valid = false;
            if (txtInfoAcc.Text.Trim() != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "CheckValidEmpName";
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@emp", txtInfoAcc.Text.Trim());
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtHidEmpAcode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                    valid = true;
                }
                else
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Enter Valid Account Information Name";
                    valid = false;
                    txtInfoAcc.Focus();
                }
            }
            else
            {
                txtNarration.Focus();
            }
            return valid;
        }
        private void DateCombo()
        { 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            if (comboDateForEdit == false)
            {
                sda.SelectCommand.CommandText = "select convert(nvarchar(10),InvoiceDate,103) as InvoiceDate,InvoiceDate as InvoiceDateid from tPurchase where acccode=@acc and InvoiceAmt<>amountPaid union select null InvoiceDate,null InvoiceDateid ";
            }
            else
            {
                sda.SelectCommand.CommandText = "select convert(nvarchar(10),InvoiceDate,103) as InvoiceDate,InvoiceDate as InvoiceDateid from tPurchase where acccode=@acc union select null InvoiceDate,null InvoiceDateid ";
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
                sda.SelectCommand.CommandText = "select InvoiceNo from tPurchase where acccode=@acc and InvoiceDate=@dt";
                sda.SelectCommand.Parameters.AddWithValue("@acc", Convert.ToInt32(txtHidAccCode.Text));
                sda.SelectCommand.Parameters.AddWithValue("@dt", cmbRefDocDate.SelectedValue);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbRefDocNo.DataSource = ds.Tables[0];
                    cmbRefDocNo.DisplayMember = "InvoiceNo";
                    cmbRefDocNo.ValueMember = "InvoiceNo";
                }
            }
            else
            {
                cmbRefDocNo.DataSource = null;
            }
        }        
        private void FillListViewPurDtl(DateTime d,int no,int ac)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select voucherno,convert(nvarchar(10), voucherdate,103) dt,db,cr from tLedgerDTL where refDate=@refDate and refNo=@refNo and acccode=@acc";
            sda.SelectCommand.Parameters.AddWithValue("@refDate", d);
            sda.SelectCommand.Parameters.AddWithValue("@refNo", no);
            sda.SelectCommand.Parameters.AddWithValue("@acc", ac);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lvInvoiceDetail.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvInvoiceDetail.Items.Add(ds.Tables[0].Rows[i]["voucherno"].ToString());
                lvInvoiceDetail.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["dt"].ToString());
                lvInvoiceDetail.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["db"].ToString());
                lvInvoiceDetail.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cr"].ToString());
            }
        }
        private void FillTextBoxPurDtl(DateTime d, int no, int ac)
        {
            txtInvoiceNo.Text = cmbRefDocNo.Text;
            txtInvoiceDate.Text = cmbRefDocDate.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select InvoiceAmt,amountPaid,dueAmt from tPurchase where acccode=@acc and InvoiceNo=@InvoiceNo and InvoiceDate=@InvoiceDate";
            sda.SelectCommand.Parameters.AddWithValue("@acc", ac);
            sda.SelectCommand.Parameters.AddWithValue("@InvoiceNo", no);
            sda.SelectCommand.Parameters.AddWithValue("@InvoiceDate", d);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtInvoAmt.Text = ds.Tables[0].Rows[0]["InvoiceAmt"].ToString();
                txtInvoPaid.Text = ds.Tables[0].Rows[0]["amountPaid"].ToString();
                txtInvoDue.Text = ds.Tables[0].Rows[0]["dueAmt"].ToString();
            }
        }
        private void FillPurchaseDetails()
        {
            if (cmbRefDocDate.Text != "" && cmbRefDocNo.Text != "")
            {
                gbPurchaseDetails.Visible = true;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                DateTime d = Convert.ToDateTime(cmbRefDocDate.Text);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                int no = Convert.ToInt32(cmbRefDocNo.Text);
                int ac = Convert.ToInt32(txtHidAccCode.Text);

                FillTextBoxPurDtl(d, no, ac);
                FillListViewPurDtl(d, no, ac);
            }
            else
            {
                gbPurchaseDetails.Visible = false;
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
            lvEmployee.Visible = false;
        }
        private void dgvBankPaymentVoucher_Click(object sender, EventArgs e)
        {
            lvAccounts.Visible = false;
            lvEmployee.Visible = false;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            lvAccounts.Visible = false;
            lvEmployee.Visible = false;
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            lvAccounts.Visible = false;
            lvEmployee.Visible = false;
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
            if (chqdt == "")
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column13"].Value = null;
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column14"].Value = null;
            }
            else
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column13"].Value = chqdt;
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column14"].Value = txtChequeNo.Text.Trim();
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
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column11"].Value = txtInfoAcc.Text.Trim();
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column5"].Value =txtNarration.Text;
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column8"].Value = txtCostCentre.Text;
            dgvBankPaymentVoucher.Rows[x - 1].Cells["Column10"].Value = txtHidAccCode.Text;
            if (txtHidEmpAcode.Text != "")
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column12"].Value = txtHidEmpAcode.Text;
            }
            else
            {
                dgvBankPaymentVoucher.Rows[x - 1].Cells["Column12"].Value = null ;
            }
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
            gbPurchaseDetails.Visible = false;
            if (RowIndex != -1)
            {
                string val = CustomMessageBox.ShowBox();
                if (val == "Edit")
                {
                    dgvBankPaymentVoucherEdit(RowIndex);
                    FillPurchaseDetails();
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
            EmplistFlag = true;
            txtAccount.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column2"].Value.ToString();
            txtHidAccCode.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column10"].Value.ToString();
            DateCombo();
            if (dgvBankPaymentVoucher.Rows[i].Cells["Column3"].Value != null)
            {
                cmbRefDocDate.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column3"].Value.ToString();
                NumCombo();
                cmbRefDocNo.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column4"].Value.ToString();
            }            
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            if (dgvBankPaymentVoucher.Rows[i].Cells["Column13"].Value!=null)
            {
                DateTime ds = Convert.ToDateTime(dgvBankPaymentVoucher.Rows[i].Cells["Column13"].Value.ToString());
                txtChqDtDD.Text = ds.Day.ToString();
                txtChqDtMM.Text = ds.Month.ToString(); 
                txtChqDtYYYY.Text = ds.Year.ToString();
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            if (dgvBankPaymentVoucher.Rows[i].Cells["Column14"].Value != null)
            {
                txtChequeNo.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column14"].Value.ToString();
            }
            txtDebit.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column6"].Value.ToString();
            txtCredit.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column7"].Value.ToString();
            txtInfoAcc.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column11"].Value.ToString();
            txtNarration.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column5"].Value.ToString();
            txtCostCentre.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column8"].Value.ToString();
            if (dgvBankPaymentVoucher.Rows[i].Cells["Column12"].Value != null)
            {
                txtHidEmpAcode.Text = dgvBankPaymentVoucher.Rows[i].Cells["Column12"].Value.ToString();
            }
            listFlag = false;
            EmplistFlag = false;
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
        private void cmbRefDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillPurchaseDetails();
                txtChqDtDD.Focus();
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
                txtInfoAcc.Focus();
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
                if (chqdt == "")
                {
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column13"].Value = null;
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column14"].Value = null;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column13"].Value = chqdt;
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column14"].Value = txtChequeNo.Text;
                }
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column6"].Value = txtDebit.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column7"].Value = txtCredit.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column11"].Value = txtInfoAcc.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column5"].Value = txtNarration.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column8"].Value = txtCostCentre.Text;
                dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column10"].Value = txtHidAccCode.Text;
                if (txtHidEmpAcode.Text != "")
                {
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column12"].Value = txtHidEmpAcode.Text;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[RowIndex].Cells["Column12"].Value = null;
                }
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
                if (txtInfoAcc.Text == "")
                {
                    txtHidEmpAcode.Clear();
                }
                    
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
            FillPurchaseDetails();
        }
        private void cmbRefDocNo_DropDownClosed(object sender, EventArgs e)
        {
            FillPurchaseDetails();
        }
        private void fnClear()
        {
            listFlag = true;
            EmplistFlag = true;
            txtAccount.Clear();
            txtNarration.Clear();
            txtHidEmpAcode.Clear();
            txtDebit.Clear();
            txtCredit.Clear();
            txtChequeNo.Clear();
            txtChqDtDD.Clear();
            txtChqDtMM.Clear();
            txtChqDtYYYY.Clear();
            txtCostCentre.Clear();
            cmbRefDocDate.DataSource = null;
            cmbRefDocNo.DataSource = null;
            txtInfoAcc.Clear();
            listFlag = false;
            EmplistFlag = false;
            gbPurchaseDetails.Visible = false;
            lvEmployee.Visible = false;
        }        
        private bool dataEntryCheck()
        {
            txtMsg.Text = "";
            bool dataflag = false;
            if (txtAccount.Text.Trim() == "" || cmbRefDocNo.Text.Trim()=="" || chqdt.Trim()=="" || txtChequeNo.Text.Trim() =="" || txtDebit.Text.Trim() == "" || txtCredit.Text.Trim() == "" || txtNarration.Text.Trim() == "" || txtCostCentre.Text.Trim() == "")
            {                             
                if (txtAccount.Text.Trim() == "")
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Should enter Account";
                    txtAccount.Focus();
                }                
                else if (ForChqDtYYYY()  == false)
                {                                
                }                
                else if (ForChequeNo() == false)
                {

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
            sda.SelectCommand.Parameters.AddWithValue("@vtyp", journal);
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
            txtMode.Text = "New";
            dgvBankPaymentVoucher.Rows.Clear();
            txtVoucherNo.Clear();
            dtpVoucherDate.Value = DateTime.Now;
            fnClear();
            txtMsg.Visible = false;
            gbPurchaseDetails.Visible = false;
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
        private void ClearPurchDtl()
        {
            txtInvoiceNo.Clear();
            txtInvoiceDate.Clear();
            txtInvoAmt.Clear();
            txtInvoPaid.Clear();
            txtInvoDue.Clear();
            lvInvoiceDetail.Items.Clear();
        }
        private void DeleteLedgerDTL()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete from tLedgerDTL where voucherno=@voucherno and vouchertype=@vtype";
            cmd.Parameters.AddWithValue("@voucherno",Convert.ToInt32(txtVoucherNo.Text));
            cmd.Parameters.AddWithValue("@vtype", journal);
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
            sda.SelectCommand.Parameters.AddWithValue("@vtyp", journal);
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
            if (txtMode.Text == newMode)
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
                                MessageBox.Show("Data Successfully Entered");
                                FillGridForDailyAccMaster();
                                FillGridWithParents();
                                UpdDailyAccMaster(plus);
                                UpdClosOpenBal(plus);
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
                        txtVoucherNo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Voucher number should not be empty");
                    txtVoucherNo.Focus();
                }
            }
            else if (txtMode.Text ==editMode)
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
            DateTime dt2;
            Int32? eid;
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
                cmd.Parameters.AddWithValue("@vtyp", journal);
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
                if (dgvBankPaymentVoucher.Rows[i].Cells["Column13"].Value != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                    dt2 = Convert.ToDateTime(dgvBankPaymentVoucher.Rows[i].Cells["Column13"].Value);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    cmd.Parameters.AddWithValue("@cqdt", dt2);
                    cmd.Parameters.AddWithValue("@cqno", dgvBankPaymentVoucher.Rows[i].Cells["Column14"].Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cqno", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cqdt", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@nar", dgvBankPaymentVoucher.Rows[i].Cells["Column5"].Value.ToString());
                debit = Convert.ToDecimal(dgvBankPaymentVoucher.Rows[i].Cells["Column6"].Value);
                cmd.Parameters.AddWithValue("@db", debit);
                credit = Convert.ToDecimal(dgvBankPaymentVoucher.Rows[i].Cells["Column7"].Value);
                cmd.Parameters.AddWithValue("@cr", credit);
                cmd.Parameters.AddWithValue("@cc", Convert.ToInt32(dgvBankPaymentVoucher.Rows[i].Cells["Column8"].Value));
                if (dgvBankPaymentVoucher.Rows[i].Cells["Column12"].Value != null)
                {
                    eid = Convert.ToInt32(dgvBankPaymentVoucher.Rows[i].Cells["Column12"].Value);
                    cmd.Parameters.AddWithValue("@InfoAcc", eid);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@InfoAcc", DBNull.Value);
                }
                if (datepresent == true)
                {
                    UpdatePurchase1(debit, credit, dt1, rno, a);
                }
                else if (datepresent == false)
                {
                    //UpdatePurchase2(debit, credit, a);
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
            cmd.Parameters.AddWithValue("@type",journal);
            cmd.Parameters.AddWithValue("@vdt", dtpVoucherDate.Value);
            cmd.Parameters.AddWithValue("@amt", Convert.ToDecimal(txtCreditTotal.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        }
        /*Update purchase table - Date Known*/
        private void UpdatePurchase1(decimal debit, decimal credit, DateTime invoDt, int invoNo, int a)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            if (debit != 0)
            {
                cmd.CommandText = "update tPurchase set amountPaid =amountPaid+@debit,dueAmt=dueAmt-@debit where InvoiceDate=@InvoiceDate and InvoiceNo=@InvoiceNo and acccode=@acc";
            }
            else if (credit != 0)
            {
                cmd.CommandText = "update tPurchase set amountPaid =amountPaid-@credit,dueAmt=dueAmt+@credit where InvoiceDate=@InvoiceDate and InvoiceNo=@InvoiceNo and acccode=@acc";
            }
            cmd.Parameters.AddWithValue("@debit", debit);
            cmd.Parameters.AddWithValue("@credit", credit);
            cmd.Parameters.AddWithValue("@InvoiceDate", invoDt);
            cmd.Parameters.AddWithValue("@InvoiceNo", invoNo);
            cmd.Parameters.AddWithValue("@acc", a);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        /*Update purchase table - Date Unknown*/
        private void UpdatePurchase2(decimal debit, decimal credit,int a)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            if (debit != 0)
            {
                cmd.CommandText = "update tPurchase set amountPaid=amountPaid+@debit,dueAmt=dueAmt-@debit where InvoiceNo in (select top 1 InvoiceNo from tPurchase where acccode=@acc)";
            }
            else if (credit != 0)
            {
                cmd.CommandText = "update tPurchase set amountPaid =amountPaid-@credit,dueAmt=dueAmt+@credit where InvoiceNo in (select top 1 InvoiceNo from tPurchase where acccode=@acc)";
            }
            cmd.Parameters.AddWithValue("@debit", debit);
            cmd.Parameters.AddWithValue("@credit", credit);
            cmd.Parameters.AddWithValue("@acc", a);
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
            cmd.Parameters.AddWithValue("@vtype",journal);
            cmd.ExecuteNonQuery();
            con.Close();
        }    
        private bool UnMatchedChqNoWODate()
        {
            bool val = false;
            if (chqdt.Trim().Length == 0 && txtChequeNo.Text.Trim().Length != 0)
            {
                val = true;
            }
            return val;
        }
        private bool UnMatchedChqNo()
        {
            bool ret = false;

            if (chqdt.Trim().Length != 0 && txtChequeNo.Text.Trim().Length == 0)
            {
                ret = true;
            }
            return ret;
        }
        private bool  ForChequeNo()
        {
            bool val = false;
            if (UnMatchedChqNoWODate() == false)
            {
                if (UnMatchedChqNo() == true)
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Enter Cheque Number";
                    val = false;
                    txtChequeNo.Focus();
                }
                else
                {
                    txtMsg.Visible = false;
                    txtMsg.Text = "";
                    val = true;
                    txtDebit.Focus();
                }
            }
            else
            {
                txtMsg.Visible = true;
                txtMsg.Text = "Enter Cheque Date";
                val = false;
                txtChqDtDD.Focus();
            }
            return val;
        }
        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ForChequeNo();      
            }
        } 
        private void txtChqDtDD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ChkDate() == true)
                {
                    txtChqDtMM.Focus();
                }
                else
                {
                    txtChqDtDD.Focus();
                }
            }
        }
        private bool ChkDate()
        {
            bool val = false;
            if (txtChqDtDD.Text.Trim().Length == 0)
            {
                val = true;
            }            
               if (txtChqDtDD.Text.Trim().Length != 0)
                {
                    if ((Convert.ToInt32(txtChqDtDD .Text)) >= 1 && (Convert.ToInt32(txtChqDtDD .Text )) <= 31)
                    {
                        val = true;
                    }
                    else
                    {
                        val = false;
                    }
                }                       
            return val;        
        }
        private void txtChqDtMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ChkMonth() == true)
                {                    
                    if ((txtChqDtMM.Text.Trim().Length != 0) && (txtChqDtDD.Text.Trim().Length != 0))
                    {
                        txtChqDtYYYY.Text = DateTime.Now.Year.ToString();
                    }
                    txtMsg.Visible = false;
                    txtChqDtYYYY.Focus();
                }
                else
                {
                    txtMsg.Visible = true;
                    txtMsg.Text = "Enter valid Month";
                    txtChqDtMM.Focus();
                }
            }
        }
        private bool ChkMonth()
        {
            bool val = false;
            if ((txtChqDtMM.Text.Trim().Length == 0) && (txtChqDtDD.Text.Trim().Length == 0))
            {
                val = true;
            }
            if (txtChqDtMM.Text.Trim().Length != 0)
            {
                if (txtChqDtDD.Text.Trim().Length != 0)
                {
                    if ((Convert.ToInt32(txtChqDtMM.Text)) >= 1 && (Convert.ToInt32(txtChqDtMM.Text)) <= 12)
                    {
                        val = true;
                    }
                    else
                    {
                        val = false;
                    }
                }
                else
                {
                    val = false;
                }
            }
            else if(txtChqDtDD.Text.Trim().Length !=0)
            {
                val = false;
            }
            return val;
        }
        private bool ForChqDtYYYY()
        {
            bool val = false;
            if ((txtChqDtMM.Text.Trim().Length != 0) || (txtChqDtDD.Text.Trim().Length != 0) || (txtChqDtYYYY.Text.Trim().Length != 0))
            {
                if (IsDate() == true )
                {
                    val = true;                   
                   txtChequeNo.Focus();
                }
                else
                {
                    val = false;
                    txtMsg.Visible = true;
                    txtMsg.Text = "Enter valid date";
                    txtChqDtDD.Focus();
                }
                if (CheckValidYear() == true)
                {
                    txtMsg.Visible = false;
                    txtChequeNo.Focus();
                }
            }
            else
            {
                val = true; 
                chqdt = "";
                txtChequeNo.Focus();
            }
            return val;
        }
        private bool CheckValidYear()
        {
            bool valid = false;
            if (txtChqDtYYYY.Text != "")
            {
                if (Convert.ToInt32(txtChqDtYYYY.Text) < 2000 || Convert.ToInt32(txtChqDtYYYY.Text) > 3000)
                {
                    valid = false;
                    txtMsg.Visible = true;
                    txtMsg.Text = "Enter valid year";
                    txtChqDtYYYY.Focus();
                }
                else
                {
                    valid = true;
                    txtMsg.Visible = false;
                }
            }            
            return valid;
        } 
        private void txtChqDtYYYY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ForChqDtYYYY();
            }
        }
        private bool IsDate()
        {
            bool val = false;
            if ((txtChqDtMM.Text.Trim().Length != 0) && (txtChqDtDD.Text.Trim().Length != 0) && (txtChqDtYYYY.Text.Trim().Length != 0))
            {
                string sdt = txtChqDtMM.Text.Trim() + "/" + txtChqDtDD.Text.Trim() + "/" + txtChqDtYYYY.Text.Trim();
                DateTime value;
                if (DateTime.TryParse(sdt, out value))
                {
                    chqdt = txtChqDtDD.Text.Trim() + "/" +txtChqDtMM.Text.Trim() + "/" + txtChqDtYYYY.Text.Trim();
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
            return val;
        }
        private void txtEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lvEmployee .Items.Count > 0)
                {
                    lvEmployee.Focus();
                    lvEmployee.Items[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lvEmployee.Visible = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (CheckValidEmpName() == true)
                {
                    if (lvEmployee.Visible == true)
                    {
                        lvEmployee.Focus();
                        lvEmployee.Items[0].Selected = true;
                        lvEmployee_Click(sender, e);
                    }
                    txtMsg.Visible = false;
                    txtNarration.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                txtNarration.Focus();
            }            
        }
        private void EmployeeNameList()
        {
            lvEmployee .Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = "select a.AccName,a.AccCode,b.empid,a.SupCusEmpOth  from tAccountMaster a ";
            string s2 = " left join employee b on a.SCEOcode = b.empid  ";
            string s3 = "  where a.GrpOrAcc ='A' and a.SupCusEmpOth <>'OTH' and a.AccName like @ch+'%' ";
            sda.SelectCommand.CommandText = s1 + s2 + s3 ;
            sda.SelectCommand.Parameters.AddWithValue("@ch", txtInfoAcc.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lvEmployee .Visible = true;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvEmployee.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    lvEmployee.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["SupCusEmpOth"].ToString());               
                    lvEmployee .Items[i].SubItems.Add(ds.Tables[0].Rows[i]["AccCode"].ToString());
                    lvEmployee .Items[i].SubItems.Add(ds.Tables[0].Rows[i]["empid"].ToString());                    
                }
            }
            else
                lvEmployee .Visible = false;

        }
        private void txtEmp_TextChanged(object sender, EventArgs e)
        {

            if (txtInfoAcc.Text == "")
            {
                lvEmployee.Visible = false;
            }
            if (EmplistFlag == false)
            {
                EmployeeNameList();
            }
        }
        private void lvEmpClick()
        {
            txtHidEmpAcode.Text = lvEmployee .SelectedItems[0].SubItems[2].Text;
            txtInfoAcc.Text = lvEmployee.SelectedItems[0].Text;
            lvEmployee.Visible = false;
            txtNarration.Focus();   
        }
        private void lvEmployee_Click(object sender, EventArgs e)
        {
            lvEmpClick();
        }
        private void lvEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            txtMsg.Visible = false;
            if (e.KeyCode == Keys.Enter)
            {
                if (lvEmployee.Items.Count > 0)
                {
                    lvEmpClick();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lvEmployee .Visible = false;
                txtInfoAcc.Focus();
            }
        }
        private void txtDueAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChqDtDD.Focus();
            }
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
        private void txtChqDtDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = IsDate(e.KeyChar);
        }
        private void txtChqDtMM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = IsDate(e.KeyChar);
        }
        private void txtChqDtYYYY_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = IsDate(e.KeyChar);
        }
        private char IsDate(char c)
        {
            if (char.IsControl(c))
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
            sda.SelectCommand.Parameters.AddWithValue("@vtype", journal);
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
            sda.SelectCommand.CommandText = "select A.slno,B.AccName acc, convert(nvarchar(10),A.refDate,103) rdt,A.refNo,convert(nvarchar(10),A.chequedate,103) cdt,A.chequeno,A.db,A.cr,E.AccName InfoAccName,A.narration,A.costcentrecode,A.acccode accode,A.InformationAccount,A.vouchertype from tLedgerDTL A left join tAccountMaster B on B.AccCode=A.acccode left join tAccountMaster E on E.AccCode=A.InformationAccount where voucherno=@voucherno and vouchertype=@vtype";
            sda.SelectCommand.Parameters.AddWithValue("@voucherno", no);
            sda.SelectCommand.Parameters.AddWithValue("@vtype", journal);
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
                if (ds.Tables[0].Rows[i]["cdt"] == DBNull.Value)
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column13"].Value = null;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column13"].Value = ds.Tables[0].Rows[i]["cdt"];
                }
                if (ds.Tables[0].Rows[i]["chequeno"] == DBNull.Value)
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column14"].Value = null;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column14"].Value = ds.Tables[0].Rows[i]["chequeno"];
                }
                string db = ds.Tables[0].Rows[i]["db"].ToString();
                db = db.Substring(0, db.Length - 2);
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column6"].Value = db;
                string cr = ds.Tables[0].Rows[i]["cr"].ToString();
                cr = cr.Substring(0, cr.Length - 2);
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column7"].Value = cr;
                if (ds.Tables[0].Rows[i]["InfoAccName"] == DBNull.Value)
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column11"].Value = "";
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column11"].Value = ds.Tables[0].Rows[i]["InfoAccName"];
                }
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column5"].Value = ds.Tables[0].Rows[i]["narration"];
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column8"].Value = ds.Tables[0].Rows[i]["costcentrecode"];
                dgvBankPaymentVoucher.Rows[k - 1].Cells["Column10"].Value = ds.Tables[0].Rows[i]["accode"];
                if (ds.Tables[0].Rows[i]["InformationAccount"] == DBNull.Value)
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column12"].Value = null;
                }
                else
                {
                    dgvBankPaymentVoucher.Rows[k - 1].Cells["Column12"].Value = ds.Tables[0].Rows[i]["InformationAccount"];
                }
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
            //txtMsg.BackColor = Color.SeaShell;
            gbPurchaseDetails.Visible = false;
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
                    gbPurchaseDetails.Visible = false;
                    dgvBankPayHD.Rows.Clear();
                    tLedgerHDInGrid();
                    txtMode.Text = newMode;
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
            cmd.Parameters.AddWithValue("@vtyp", journal);
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
            sda.SelectCommand.Parameters.AddWithValue("@vtyp", journal);
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
                    if (Convert.ToDecimal(ds.Tables[0].Rows[i]["db"]) != 0)
                    {
                        cmd.CommandText = "update tPurchase set amountPaid =amountPaid-@debit,dueAmt=dueAmt+@debit where InvoiceDate=@InvoiceDate and InvoiceNo=@InvoiceNo and acccode=@acc";
                        cmd.Parameters.AddWithValue("@debit", Convert.ToDecimal(ds.Tables[0].Rows[i]["db"]));
                        cmd.Parameters.AddWithValue("@InvoiceDate", ds.Tables[0].Rows[i]["refDate"]);
                        cmd.Parameters.AddWithValue("@InvoiceNo", Convert.ToInt32(ds.Tables[0].Rows[i]["refNo"]));
                        cmd.Parameters.AddWithValue("@acc", Convert.ToInt32(ds.Tables[0].Rows[i]["acccode"]));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    else if (Convert.ToDecimal(ds.Tables[0].Rows[i]["cr"]) != 0)
                    {
                        cmd.CommandText = "update tPurchase set amountPaid =amountPaid+@credit,dueAmt=dueAmt-@credit where InvoiceDate=@InvoiceDate and InvoiceNo=@InvoiceNo and acccode=@acc";
                        cmd.Parameters.AddWithValue("@credit", Convert.ToDecimal(ds.Tables[0].Rows[i]["cr"]));
                        cmd.Parameters.AddWithValue("@InvoiceDate", ds.Tables[0].Rows[i]["refDate"]);
                        cmd.Parameters.AddWithValue("@InvoiceNo", Convert.ToInt32(ds.Tables[0].Rows[i]["refNo"]));
                        cmd.Parameters.AddWithValue("@acc", Convert.ToInt32(ds.Tables[0].Rows[i]["acccode"]));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
            }
            conWrite.Close();
        }
            
    }
}