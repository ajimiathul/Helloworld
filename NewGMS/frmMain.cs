using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStyle obj = new frmStyle();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        

        

        

        private void ActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActivity obj = new frmActivity();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void partsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBundleParts obj = new frmBundleParts();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void layerCutReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLayerCutReports obj = new frmLayerCutReports();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //masterToolStripMenuItem.DropDown.Items[1].Visible = false;
        }


        private void DisableMenu()
        {
            for (int i = 0; i < masterToolStripMenuItem.DropDown.Items.Count; i++)
            {
                masterToolStripMenuItem.DropDown.Items[i].Visible = false;
            }

            for (int i = 0; i < transactionToolStripMenuItem.DropDown.Items.Count; i++)
            {
                transactionToolStripMenuItem.DropDown.Items[i].Visible = false;
            }

            for (int i = 0; i < toolsToolStripMenuItem.DropDown.Items.Count; i++)
            {
                toolsToolStripMenuItem.DropDown.Items[i].Visible = false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Locknumber()) <= 660)
            {
                DisableMenu();
                toolStripLabel1.Text = clsDbForReports.username;
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                sda.SelectCommand.CommandText = "select a.menuName,a.menuSubName,a.menuSubIndexNo  from tmenu a,tusermenu b where a.menuid=b.menuid and b.userid=@uid order by a.menuName";
                sda.SelectCommand.Parameters.AddWithValue("@uid", clsDbForReports.userid);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    int x = Convert.ToInt32(ds.Tables[0].Rows[j]["menuSubIndexNo"].ToString());
                    if (ds.Tables[0].Rows[j]["menuName"].ToString() == "masterToolStripMenuItem")
                    {
                        masterToolStripMenuItem.DropDown.Items[x].Visible = true;
                    }

                    if (ds.Tables[0].Rows[j]["menuName"].ToString() == "transactionToolStripMenuItem")
                    {
                        transactionToolStripMenuItem.DropDown.Items[x].Visible = true;
                    }

                    if (ds.Tables[0].Rows[j]["menuName"].ToString() == "toolsToolStripMenuItem")
                    {
                        toolsToolStripMenuItem.DropDown.Items[x].Visible = true;
                    }
                }
            }
            else
            {
                DisableMenu();
            }
        }

        private string  Locknumber()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select count(*) from employee ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0].Rows[0][0].ToString();            
        }

        

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword obj = new frmChangePassword();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        

        private void DepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment obj = new frmDepartment();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void DesignationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesignation obj = new frmDesignation();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmployee obj = new frmEmployee();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void productionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionReports obj = new frmProductionReports();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void employeeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEmpReports obj = new frmEmpReports();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        

       

        private void bundleStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBundleView obj = new frmBundleView();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void employeeProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeProductionView obj = new frmEmployeeProductionView();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();


        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendanceReports obj = new frmAttendanceReports();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void attendanceDailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendanceDaily obj = new frmAttendanceDaily();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void CategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory obj = new frmCategory();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void SubCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubCategory obj = new frmSubCategory();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

       

        private void layerCutDeleteOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLayerCutDelete obj = new frmLayerCutDelete();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }
        
        private void userMenuSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserMenuSelect obj = new frmUserMenuSelect();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }        

       
        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendanceReport obj = new frmAttendanceReport();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }
     

        

       
        private void transStoreMatReq_Click(object sender, EventArgs e)
        {
            frmMaterialRequisition obj = new frmMaterialRequisition();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void transStoreMatReqApproval_Click(object sender, EventArgs e)
        {
            frmMaterialRequestApproval obj = new frmMaterialRequestApproval();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        

        private void transStoreQuot_Click(object sender, EventArgs e)
        {
            frmQuotation2 obj = new frmQuotation2();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void leaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLeaveApplication obj = new frmLeaveApplication();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void manualRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManualRegAttendance obj = new frmManualRegAttendance();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void purchaseOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPurchaseOrder obj = new frmPurchaseOrder();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }       

        private void transStoreQutReq_Click(object sender, EventArgs e)
        {
            frmQuotationRequest obj = new frmQuotationRequest();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show(); 
        }

        private void transStorePurReq_Click(object sender, EventArgs e)
        {
            frmPurchaseRequest obj = new frmPurchaseRequest();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase obj = new frmPurchase(); 
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void bankReceiptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBank obj = new frmBank();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void cashReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCash obj = new frmCash();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void journalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournal obj = new frmJournal();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void debitNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDebitNote obj = new frmDebitNote();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void creditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreditNote obj = new frmCreditNote();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

       

        private void gIRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGIRN obj = new frmGIRN();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }
        

        private void performaInvoiceRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerformaInvoiceRequest obj = new frmPerformaInvoiceRequest();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void performaInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerformaInvoice obj = new frmPerformaInvoice();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaterialProperty obj = new frmMaterialProperty();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void propertyValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPropertyValue obj = new frmPropertyValue();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();


        }

        private void baseMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaseMaterial obj = new frmBaseMaterial();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void materialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMaterial obj = new frmMaterial();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void ledgerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLedgerReport obj = new frmLedgerReport();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void bankLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBankLedger obj = new frmBankLedger();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformationAccountLedger obj = new frmInformationAccountLedger();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void combinedLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCombinedLedgerReport obj = new frmCombinedLedgerReport();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformationAndSpecificAccountLedger obj = new frmInformationAndSpecificAccountLedger();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void materialIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaterialIssue obj = new frmMaterialIssue();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnit obj = new frmUnit();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        

        

       

        private void inwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinishedProductsInward obj = new frmFinishedProductsInward();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void outWardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinishedProductsOutward obj = new frmFinishedProductsOutward();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void finishedStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptFPStock obj = new frmRptFPStock();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void holidaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HolidayEntry obj = new HolidayEntry();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void defaultPerformaInvoiceAdditionalChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       

       

        private void trailBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrialBalance obj = new frmTrialBalance();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRPTPurchaseorder obj = new frmRPTPurchaseorder();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void purchaseRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreportpurchaserequest obj = new frmreportpurchaserequest();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void attendanceStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendanceFlagEntry obj = new frmAttendanceFlagEntry();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BACKUP ob = new BACKUP();
            ob.MdiParent = this;
            ob.StartPosition = FormStartPosition.CenterScreen;
            ob.Show();
        }

        private void operatorTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpOperator obj = new EmpOperator();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

       

        

        private void MachinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMachine obj = new frmMachine();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void machineEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpMachine obj = new frmEmpMachine();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void finishedStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmFinishedStock obj = new FrmFinishedStock();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesiganationMaster obj = new frmDesiganationMaster();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void styleProcessActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmprocessActivity obj = new frmprocessActivity();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void activityOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStyleActOperator obj = new frmStyleActOperator();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void dataTransferFromFingerPrintDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewTransfer obj = new frmNewTransfer();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void supplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSupplier obj = new frmSupplier();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void pOConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Defaultdetailpo obj = new Defaultdetailpo();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void pIAdditionalChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPIAddnChargesEntry obj = new frmPIAddnChargesEntry();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void buyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer obj = new frmCustomer();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void ledgerHeadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccMaster obj = new frmAccMaster();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void productionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductionUpdate obj = new frmProductionUpdate();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        private void cuttingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTLayerCutting obj = new frmTLayerCutting();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();

        }

        private void testToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        
           
     }
}
