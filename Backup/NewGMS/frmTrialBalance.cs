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
    public partial class frmTrialBalance : Form
    {
        public frmTrialBalance()
        {
            InitializeComponent();
        }
        ListViewItem ItemSelected1, ItemSelected2,ItemSelected3,ItemSelected4;
        bool flag = false;
        string s1, s2, s3, s4, s5;
        private void frmTrialBalance_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(520, 619);
        }

        private void MainAccount(int grp)
        {
           SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.AccName,A.AccCode,B.closBal,B.cr,B.db,B.opBal,A.GrpOrAcc,A.Levelno from tAccountMaster A inner join tDailyAccountMaster B on A.AccCode=B.accCode where B.dt=@dt and A.Groupno=@grp";
            sda.SelectCommand.Parameters.AddWithValue("@grp", grp);
            sda.SelectCommand.Parameters.AddWithValue("@dt", dtpAsOnDate.Value.ToShortDateString());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lvMainAcc.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvMainAcc.Items.Add(ds.Tables[0].Rows[i]["AccName"].ToString());
                    lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["AccCode"].ToString());
                    lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["GrpOrAcc"].ToString());
                    lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Levelno"].ToString());
                    lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["opBal"].ToString());
                    lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["db"].ToString());
                    lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cr"].ToString());
                    lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["closBal"].ToString());
                }
            }
            else if(flag==true)
            {
                lvMainAcc.Items.Clear();
            }
        }
        private void MonthlyAccount(int ac)
        {
            lvMonthlyAcc.Items.Clear();
            lvMonthlyAcc.Visible = true;
            lvDayAcc.Visible = false;
            this.Size = new System.Drawing.Size(520, 619);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "MonthlyAccount";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@ac", ac);
            sda.SelectCommand.Parameters.AddWithValue("@dt", dtpAsOnDate.Value.ToShortDateString());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvMonthlyAcc.Items.Add(ds.Tables[0].Rows[i]["month"].ToString());
                lvMonthlyAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["MonthCode"].ToString());
                lvMonthlyAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["opBal"].ToString());
                lvMonthlyAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["db"].ToString());
                lvMonthlyAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cr"].ToString());
                lvMonthlyAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["closBal"].ToString());
            }
        }
        private void DayAccount(int ac,int mon)
        {
            lvDayAcc.Visible = true;
            lvDayAcc.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select convert(varchar(30),A.dt,103) day,A.opBal ,A.db , A.cr , A.closBal  from tDailyAccountMaster A inner join tAccountMaster B on A.accCode=B.AccCode where A.accCode =@ac and MONTH(A.dt)=@mon and A.dt<=@dt order by dt";
            sda.SelectCommand.Parameters.AddWithValue("@ac", ac);
            sda.SelectCommand.Parameters.AddWithValue("@dt", dtpAsOnDate.Value.ToShortDateString());
            sda.SelectCommand.Parameters.AddWithValue("@mon", mon);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvDayAcc.Items.Add(ds.Tables[0].Rows[i]["day"].ToString());
                lvDayAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["opBal"].ToString());
                lvDayAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["db"].ToString());
                lvDayAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cr"].ToString());
                lvDayAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["closBal"].ToString());                
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            flag = true;
            MainAccount(0);
            flag = false;
            lvMonthlyAcc.Visible = false;
            lvDayAcc.Visible = false;
            this.Size = new System.Drawing.Size(520, 619);
            lblLevel.Text = "";
        }
        private void LevelInfoAdd(string s, int lev)
        {
            lblLevel.Visible = true;
            if (lev == 1)
            {
                lblLevel.Text = s;
                s1 = s;
            }
            else if (lev == 2)
            {
                lblLevel.Text = s1 + " >> " + s;
                s2 = lblLevel.Text;
            }
            else if (lev == 3)
            {
                lblLevel.Text = s2 + " >> " + s;
                s3 = lblLevel.Text;
            }
            else if (lev == 4)
            {
                lblLevel.Text = s3 + " >> " + s;
                s4 = lblLevel.Text;
            }
            else if (lev == 5)
            {
                lblLevel.Text = s4 + " >> " + s;
                s5 = lblLevel.Text;
            }
        }
        private void LevelInfoMinus()
        {
            if (lblLevel.Text == s5)
            {
                lblLevel.Text = s4;
            }
            else if (lblLevel.Text == s4)
            {
                lblLevel.Text = s3;
            }
            else if (lblLevel.Text == s3)
            {
                lblLevel.Text = s2;
            }
            else if (lblLevel.Text == s2)
            {
                lblLevel.Text = s1;
            }
            else if (lblLevel.Text == s1)
            {
                lblLevel.Text = "";
            }
        }
        private void lvTrialMain_MouseDown(object sender, MouseEventArgs e)
        {
            ItemSelected1 = lvMainAcc.GetItemAt(e.X, e.Y);
            if (ItemSelected1 != null)
            {
                int grpno = Convert.ToInt32(ItemSelected1.SubItems[1].Text);
                LevelInfoAdd(ItemSelected1.Text, Convert.ToInt32(ItemSelected1.SubItems[3].Text));
                if (ItemSelected1.SubItems[2].Text == "G")
                {                    
                   MainAccount(grpno);
                }
                else
                {
                    MonthlyAccount(grpno);
                }
            }
        }
        private void lvMonthlyAcc_MouseDown(object sender, MouseEventArgs e)
        {
            ItemSelected2 = lvMonthlyAcc.GetItemAt(e.X, e.Y);
            if (ItemSelected2 != null)
            {
                int month = Convert.ToInt32(ItemSelected2.SubItems[1].Text);
                int accode = Convert.ToInt32(ItemSelected1.SubItems[1].Text);
                DayAccount(accode, month);
            }
        }
        private void Back(int ac)
        {
            lvMainAcc.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select B.AccName,A.accCode,B.GrpOrAcc,A.opBal,A.db,A.cr,A.closBal,B.Levelno from tDailyAccountMaster A inner join tAccountMaster B on A.accCode=B.AccCode where A.dt=@dt and B.Groupno in (select groupno from tAccountMaster where AccCode in(select Groupno from tAccountMaster where AccCode=@ac))";
            sda.SelectCommand.Parameters.AddWithValue("@dt", dtpAsOnDate.Value.ToShortDateString());
            sda.SelectCommand.Parameters.AddWithValue("@ac", ac);
            DataSet ds = new DataSet();
            sda.Fill(ds); 
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvMainAcc.Items.Add(ds.Tables[0].Rows[i]["AccName"].ToString());
                lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["AccCode"].ToString());
                lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["GrpOrAcc"].ToString());
                lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Levelno"].ToString());
                lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["opBal"].ToString());
                lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["db"].ToString());
                lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cr"].ToString());
                lvMainAcc.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["closBal"].ToString());
            }

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lvMainAcc.Items.Count > 0)
            {
                LevelInfoMinus();
                if (Convert.ToInt32(lvMainAcc.Items[0].SubItems[3].Text) > 1)
                {
                    int code = Convert.ToInt32(lvMainAcc.Items[0].SubItems[1].Text);
                    int lev= Convert.ToInt32(lvMainAcc.Items[0].SubItems[3].Text);
                    if (lvMonthlyAcc.Visible == true)
                    {
                        lvMonthlyAcc.Visible = false;
                        lvDayAcc.Visible = false;
                        this.Size = new System.Drawing.Size(520, 619);
                    }
                    else
                    {
                        Back(code);
                    }
                }
            }
        }
        private void LedgerDetails()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select voucherno,vouchertype,db,cr from tLedgerDTL where acccode=@ac and voucherdate=@dt";
            sda.SelectCommand.Parameters.AddWithValue("@ac",Convert.ToInt32(ItemSelected1.SubItems[1].Text));
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            sda.SelectCommand.Parameters.AddWithValue("@dt", Convert.ToDateTime(ItemSelected3.Text));
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");  
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lvLedgerDetails.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvLedgerDetails.Items.Add(ds.Tables[0].Rows[i]["voucherno"].ToString());
                lvLedgerDetails.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["vouchertype"].ToString());
                lvLedgerDetails.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["db"].ToString());
                lvLedgerDetails.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["cr"].ToString());
            }
        }
        private void lvDayAcc_MouseDown(object sender, MouseEventArgs e)
        {
            ItemSelected3 = lvDayAcc.GetItemAt(e.X, e.Y);
            if (ItemSelected3 != null)
            {                
                LedgerDetails();
                if (lvLedgerDetails.Items.Count > 0)
                {
                    this.Size = new System.Drawing.Size(902, 619);
                }
            }
        }
        private void GirnScreen(int vno)
        {
            frmGIRN obj = new frmGIRN();
            obj.MdiParent = this.MdiParent;
            obj.CallFromDailyAccMaster(vno);
            obj.Show();
        }
        private void PurchaseScreen(int vno)
        {
            frmPurchase obj = new frmPurchase();
            obj.MdiParent = this.MdiParent;
            obj.CallFromDailyAccMaster(vno);
            obj.Show();
        }
        private void BankScreen(int vno)
        {
            frmBank obj = new frmBank();
            obj.MdiParent = this.MdiParent;
            obj.CallFromDailyAccMaster(vno);
            obj.Show();
        }
        private void CashScreen(int vno)
        {
            frmCash obj = new frmCash();
            obj.MdiParent = this.MdiParent;
            obj.CallFromDailyAccMaster(vno);
            obj.Show();
        }
        private void JournalScreen(int vno)
        {
            frmJournal obj = new frmJournal();            
            obj.MdiParent = this.MdiParent;
            obj.CallFromDailyAccMaster(vno);
            obj.Show();
        }
        private void DebitNoteScreen(int vno)
        {
            frmDebitNote obj = new frmDebitNote();                      
            obj.MdiParent = this.MdiParent;
            obj.CallFromDailyAccMaster(vno);
            obj.Show();
        }
        private void CreditNoteScreen(int vno)
        {
            frmCreditNote obj = new frmCreditNote();                     
            obj.MdiParent = this.MdiParent;
            obj.CallFromDailyAccMaster(vno);
            obj.Show();
        }
        private void lvLedgerDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ItemSelected4 = lvLedgerDetails.GetItemAt(e.X, e.Y);
            if (ItemSelected4 != null)
            {
                string vtyp = ItemSelected4.SubItems[1].Text;
                vtyp = vtyp.Trim();
                int vno = Convert.ToInt32(ItemSelected4.Text);
                if (vtyp == "GIR")
                {
                    GirnScreen(vno);
                }
                else if (vtyp == "PUR")
                {
                    PurchaseScreen(vno);
                }
                else if (vtyp == "BP" || vtyp == "BR")
                {
                    BankScreen(vno);
                }
                else if (vtyp == "CP" || vtyp == "CR")
                {
                    CashScreen(vno);
                }
                else if (vtyp == "JRL")
                {
                    JournalScreen(vno);
                }
                else if (vtyp == "DN")
                {
                    DebitNoteScreen(vno);
                }
                else if (vtyp == "CN")
                {
                    CreditNoteScreen(vno);
                }
            }  
        }
    }
}
