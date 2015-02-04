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
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;



namespace NewGMS
{
    public partial class frmMaterialRequisition : Form
    {
        public frmMaterialRequisition()
        {
            InitializeComponent();
        }
        string stock;
        int HDid = 0;
        int HDRowIndex = 0;
        int DtlRowIndex = -1;       
        bool unitFlag = false;
        bool UnitQtyFlag = false;
        double dou;
        string newMode = "New", editMode = "Edit", del = "Delete"; 
            //cancel = "Cancel";
        string empnameid=null;
        int flagformail = 0;
        private void fillgridcolumn()
        {
            grid1.Cell(0, 1).Text = "Req. NO.";
            grid1.Cell(0, 2).Text = "Dept.";
            grid1.Cell(0, 3).Text = "Manager";
            grid1.Cell(0, 4).Text = "Status";
            grid1.Cell(0, 5).Text = "Resend";
            grid1.Column(5).CellType = FlexCell.CellTypeEnum.CheckBox;
            grid1.Column(2).Width = 100;
            grid1.Column(3).Width = 150;


        }

        private void frmMaterialRequisition_Load(object sender, EventArgs e)
        {
            fillgridcolumn();
            dgvSanction.Enabled = false;
            NewEntry();
            DepCombo();
            MaterialCombo();
            unitFlag = true;
            showUnit();
            UnitQtyFlag = true;
            ShowConversionQty();
            FindStock();
            LoadManagers();
            btnRequest.Enabled = false;
            showspfstatus("pending");
        }

        private void LoadManagers()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select b.employeename from tSanction a,employee b  where a.screen='MatRequest' and a.empid=b.empid";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvManagers.DataSource = ds.Tables[0] ;
            dgvManagers.Columns[0].Width = 200;
        }

        private void NewEntry()
        {
            txtMode.Text = newMode;
            MainEnableTrue();
            MatReqCode();
        }
        private void MaterialCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select MatDesc,MatCode from tMaterial";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbMaterial.DataSource = ds.Tables[0];
            cmbMaterial.DisplayMember = "MatDesc";
            cmbMaterial.ValueMember = "MatCode";
        }

        private void DepCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select department,DepId from department";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbDep.DataSource = ds.Tables[0];
            cmbDep.DisplayMember = "department";
            cmbDep.ValueMember = "DepId";
        }

        private void FindStock()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select closingStock from tWarehouseMatStock where Matcode=@Mc";
            sda.SelectCommand.Parameters.AddWithValue("@Mc", Convert.ToInt32 ( cmbMaterial.SelectedValue) );
            DataSet ds = new DataSet();
            sda.Fill(ds);
            stock = ds.Tables[0].Rows[0]["closingStock"].ToString();
        }

        private void MatReqDtlAddInGrid()
        {
            bool check = false;
            dgvMain.Rows.Add(1);
            int x = dgvMain.Rows.Count;
            if (!double.TryParse(txtReqQty.Text, out dou))
            {
                txtReqQty.Text = "0.00";
            }
            if (x == 1)
            {
                dgvMain.Rows[x - 1].Cells["slno"].Value = x.ToString ();
                dgvMain.Rows[x - 1].Cells["material"].Value = cmbMaterial.Text;               
                dgvMain.Rows[x - 1].Cells["rqty"].Value = (Convert.ToDouble ( txtReqQty.Text)/ Convert.ToDouble (txtConversion.Text )).ToString () ;
                dgvMain.Rows[x - 1].Cells["colstock"].Value = stock;
                dgvMain.Rows[x - 1].Cells["colUnit"].Value = cmbUnit.Text;
                dgvMain.Rows[x - 1].Cells["colUnitID"].Value = cmbUnit.SelectedValue;
                dgvMain.Rows[x - 1].Cells["colConversion"].Value = txtConversion.Text;
                dgvMain.Rows[x - 1].Cells["matcode"].Value = cmbMaterial.SelectedValue;
                dgvMain.Rows[x - 1].Cells["colLargeUnit"].Value = txtMCLU.Text;  
            }
            else
            {
                for (int i = 0; i < x - 1; i++)
                {
                    if (dgvMain.Rows[i].Cells["matcode"].Value.ToString() == cmbMaterial.SelectedValue.ToString())
                    {
                        check = true;
                    }
                }
                if (check == false)
                {
                    dgvMain.Rows[x - 1].Cells["slno"].Value = x.ToString();
                    dgvMain.Rows[x - 1].Cells["material"].Value = cmbMaterial.Text;
                    dgvMain.Rows[x - 1].Cells["rqty"].Value = (Convert.ToDouble(txtReqQty.Text) / Convert.ToDouble(txtConversion.Text)).ToString();
                    dgvMain.Rows[x - 1].Cells["colstock"].Value = stock;
                    dgvMain.Rows[x - 1].Cells["colUnit"].Value = cmbUnit.Text;
                    dgvMain.Rows[x - 1].Cells["colUnitID"].Value = cmbUnit.SelectedValue;
                    dgvMain.Rows[x - 1].Cells["colConversion"].Value = txtConversion.Text;
                    dgvMain.Rows[x - 1].Cells["matcode"].Value = cmbMaterial.SelectedValue;
                    dgvMain.Rows[x - 1].Cells["colLargeUnit"].Value = txtMCLU.Text;
                }
                else
                {
                    MessageBox.Show("Data Already Exist");
                    dgvMain.Rows.RemoveAt(x - 1);
                }
            }
        }

        private void MatReqDtlReplaceInGrid()
        {
            bool check = false;
            for (int i = 0; i < dgvMain.Rows.Count; i++)
            {
                if (dgvMain.Rows[i].Cells["matcode"].Value.ToString() == cmbMaterial.SelectedValue.ToString())
                {

                    if (txtHidSlNo.Text == (i + 1).ToString())
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
            }
            if (check == false)
            {
                if (!double.TryParse(txtReqQty.Text, out dou))
                {
                    txtReqQty.Text = "0.00";
                }
                dgvMain.Rows[DtlRowIndex].Cells["material"].Value = cmbMaterial.Text;
                dgvMain.Rows[DtlRowIndex].Cells["rqty"].Value = (Convert.ToDouble(txtReqQty.Text) / Convert.ToDouble(txtConversion.Text)).ToString();
                dgvMain.Rows[DtlRowIndex].Cells["colstock"].Value = stock;
                dgvMain.Rows[DtlRowIndex].Cells["colUnit"].Value = cmbUnit.Text;
                dgvMain.Rows[DtlRowIndex].Cells["colUnitID"].Value = cmbUnit.SelectedValue;
                dgvMain.Rows[DtlRowIndex].Cells["colConversion"].Value = txtConversion.Text;
                dgvMain.Rows[DtlRowIndex].Cells["matcode"].Value = cmbMaterial.SelectedValue;
                dgvMain.Rows[DtlRowIndex].Cells["colLargeUnit"].Value = txtMCLU.Text;
            }
            else
            {
                MessageBox.Show("Data Already Exist");
            }
        }


        private void UpdateMatReqHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMatReqHD set matreqDate=@dt,depid=@depid where matreqCode = @mrqcd";        
            cmd.Parameters.AddWithValue("@dt", Convert.ToDateTime(dtpMReq.Value.ToShortDateString()));
            cmd.Parameters.AddWithValue("@depid", cmbDep.SelectedValue);
            cmd.Parameters.AddWithValue("@mrqcd", Convert.ToInt32(txtMatReqCode.Text) );
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void SaveInMatReqHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "CreateMatRequest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@scr", "MatRequest");
            cmd.Parameters.AddWithValue("@dt", Convert.ToDateTime(dtpMReq.Value.ToShortDateString())  );
            cmd.Parameters.AddWithValue("@depid", cmbDep.SelectedValue);
            cmd.Parameters.AddWithValue("@matreqcode", 0).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            con.Close();
            if (txtMatReqCode.Text != cmd.Parameters["@matreqcode"].Value.ToString())
            {
                txtMatReqCode.Text = cmd.Parameters["@matreqcode"].Value.ToString();
                MessageBox.Show("MatReqCode is changed");
            }
        }

        private void SaveInMatReqDtl()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tMatReqDtl(matreqCode,matcode,qty,unitdesc,unitid,conversion,status,IssuedStatus,QtRqNo,SuppliedQty,BalQty)values(@matreccode,@matcode,@qty,@unitdesc,@unitid,@conversion,'PEN','N',0,0,@qty)";
            for (int i = 0; i < dgvMain.Rows.Count; i++)
            {
                cmd.Parameters.AddWithValue("@matcode", dgvMain.Rows[i].Cells["matcode"].Value);
                cmd.Parameters.AddWithValue("@qty", dgvMain.Rows[i].Cells["rqty"].Value);
                cmd.Parameters.AddWithValue("@matreccode", Convert.ToInt32(txtMatReqCode.Text));
                cmd.Parameters.AddWithValue("@unitdesc", dgvMain.Rows[i].Cells["colUnit"].Value);
                cmd.Parameters.AddWithValue("@unitid", dgvMain.Rows[i].Cells["colUnitID"].Value);
                cmd.Parameters.AddWithValue("@conversion", dgvMain.Rows[i].Cells["colConversion"].Value);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
             }
            con.Close();
        }
        
        private void CellDoubleClickDtl(int i)
        {
            txtReqQty.Focus();
            txtHidSlNo.Text = dgvMain.Rows[i].Cells["slno"].Value.ToString();
            cmbMaterial.Text = dgvMain.Rows[i].Cells["material"].Value.ToString();
            txtReqQty.Text = (Convert.ToDouble(dgvMain.Rows[i].Cells["rqty"].Value.ToString()) * Convert.ToDouble(dgvMain.Rows[i].Cells["colConversion"].Value.ToString())).ToString ();
            txtConversion.Text = dgvMain.Rows[i].Cells["colConversion"].Value.ToString();         
            cmbUnit.SelectedValue = dgvMain.Rows[i].Cells["colUnitID"].Value.ToString ()  ;        
        }

        //private void Typetxt()
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = clsDbForReports.constr;
        //    SqlDataAdapter sda = new SqlDataAdapter("", con);
        //    sda.SelectCommand.CommandText = "select closingStock from tWarehouseMatStock where warehousecode in (1,2) and MatCode=@id  ";
        //    sda.SelectCommand.Parameters.AddWithValue("@id", cmbMaterial.SelectedValue);
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    stock = ds.Tables[0].Rows[0]["closingStock"].ToString();
        //}

        private void cmbMaterial_DropDownClosed(object sender, EventArgs e)
        {
            FindStock();
            txtReqQty.Focus();
        }

        private void cmbColor_DropDownClosed(object sender, EventArgs e)
        {
            MaterialCombo();
        }

        

        private void txtReqQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterClick();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            EnterClick();
        }

        private void EnterClick()
        {
            if (txtReqQty.Text.Trim() != "")
            {
                FindStock();
                if (DtlRowIndex==-1)
                {
                    MatReqDtlAddInGrid();
                }
                else
                {
                    MatReqDtlReplaceInGrid();
                }
                txtReqQty.Clear();
                DtlRowIndex = -1;
                btnEnter.Text="Add";
                cmbMaterial.Focus();
            }
            else
            {
                MessageBox.Show("Data not entered");
                txtReqQty.Focus();
            }
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            MatReqHDShowInGrid();
        }

        private void MatReqHDShowInGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select matreqCode,B.Department,CONVERT(NVARCHAR(10),matreqDate,103) matreqDate, SendForSanction,SendForSanctionDate,SendForSupplier,CanModify from tMatReqHD A inner join department B on A.depid=B.DepId order by matreqCode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvHeadView.DataSource = ds.Tables[0];
        }

        private void dgvHeadView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HDRowIndex = e.RowIndex;
            if (HDRowIndex != -1)
            {
                CellDoubleClickHD(HDRowIndex);
            }
        }

        private void CellDoubleClickHD(int i)
        {
            btnRequest.Text = "Request Status : Pending, Click for Send Request";
            btnRequest.Enabled = true;                    
            lblDate.Text = "";
            dgvMain.Rows.Clear();
            HDid = Convert.ToInt32(dgvHeadView.Rows[i].Cells[0].Value);
            cmbDep.Text = dgvHeadView.Rows[i].Cells[1].Value.ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dtpMReq.Value = Convert.ToDateTime(dgvHeadView.Rows[i].Cells[2].Value.ToString());          
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                      
            lblDate.Text = dgvHeadView.Rows[i].Cells[4].Value.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);            
            string s1=" select B.MatDesc , A.qty,A.unitid ,A.unitDesc,A.conversion,C.closingStock as stock, A.matcode, D.Unit as LargeUnit ";
            string s2=" from tMatReqDtl A,tMaterial B,tWarehouseMatStock C,UnitMaster D ";
            string s3=" where A.matcode = B.MatCode and A.matcode = C.matcode and D.UnitId = B.unitCode and ";
            string s4 = " A.matreqCode=@matreqcode and C.warehousecode in (1,2) ";            
            sda.SelectCommand.CommandText = s1+s2+s3+s4 ;
            sda.SelectCommand.Parameters.AddWithValue("@matreqcode", HDid);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                dgvMain.Rows.Add(1);
                int x = dgvMain.Rows.Count;
                dgvMain.Rows[x - 1].Cells["slno"].Value = (j + 1).ToString();
                dgvMain.Rows[x - 1].Cells["material"].Value = ds.Tables[0].Rows[j]["MatDesc"].ToString();
                dgvMain.Rows[x - 1].Cells["rqty"].Value = ds.Tables[0].Rows[j]["qty"].ToString();
                dgvMain.Rows[x - 1].Cells["colstock"].Value = ds.Tables[0].Rows[j]["stock"].ToString();
                dgvMain.Rows[x - 1].Cells["colUnit"].Value = ds.Tables[0].Rows[j]["unitdesc"].ToString();
                dgvMain.Rows[x - 1].Cells["colUnitID"].Value = ds.Tables[0].Rows[j]["unitid"].ToString();
                dgvMain.Rows[x - 1].Cells["colConversion"].Value = ds.Tables[0].Rows[j]["conversion"].ToString();
                dgvMain.Rows[x - 1].Cells["matcode"].Value = ds.Tables[0].Rows[j]["MatCode"].ToString();
                dgvMain.Rows[x - 1].Cells["colLargeUnit"].Value = ds.Tables[0].Rows[j]["LargeUnit"].ToString();
            }
            txtMode.Text = editMode;
            txtMatReqCode.Text = HDid.ToString();
            SanctionRequestInGrid();
            btnSave.Text = "Update";
            tbMatRequest.SelectedTab = tbMain;
            dgvMain.ClearSelection();
            if (CanModify() == false  )
            {
             MainEnableTrue();
            }
            
            else
            {
               
                MainEnableFalse();
            }            
        }

        private bool RequestForSanction()
        {
            bool check = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select SendForSanction from tMatReqHD where matreqCode=@matreqCode";
            sda.SelectCommand.Parameters.AddWithValue("@matreqCode", HDid);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows[0]["SendForSanction"].ToString() == "Y")
            {
                check = true;
            }

            return check;
        }

        private bool SendToSupplier()
        {
            bool check = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select SendForSupplier from tMatReqHD where matreqCode=@matreqCode";
            sda.SelectCommand.Parameters.AddWithValue("@matreqCode", Convert.ToInt32(txtMatReqCode.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows[0]["SendForSupplier"].ToString() == "Y")
            {
                check = true;
            }
            return check;
        }

        private bool CanModify()
        {
            bool check = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select CanModify from tMatReqHD where matreqCode=@matreqCode";
            sda.SelectCommand.Parameters.AddWithValue("@matreqCode", Convert.ToInt32(txtMatReqCode.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows[0][0].ToString().Trim() == "No")
            {
                check = true;
            }
            else
            {
                check = false;
            
            }
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMode.Text == newMode)
            {
                if (dgvMain.Rows.Count != 0)
                {
                    SaveInMatReqHD();
                    SaveInMatReqDtl();
                    btnRequest.Text = "Request Status : Pending, Click for Send Request";
                    btnRequest.Enabled = true;
                    MessageBox.Show("Material Selection Saved");
                    btnSave.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Data is Not Entered");
                }
            }
            else if (txtMode.Text == editMode)
            {
                UpdateMatReqHD();
                UpdateDBMatDtl();                
                MessageBox.Show("Material Selection Updated");
            }
        }

        private void NewClick()
        {
            txtReqQty.Clear();
            DtlRowIndex = -1;
        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewClick();
        }

        private void MatReqCode()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select lastNum from tnumbers where screen=@scr";
            sda.SelectCommand.Parameters.AddWithValue("@scr", "MatRequest");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            txtMatReqCode.Text = (1 + Convert.ToInt32(ds.Tables[0].Rows[0]["lastNum"])).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDBMatDtl()
        {
            DeleteFromDtl();
            SaveInMatReqDtl();
        }

        private void DeleteFromDtl()
        {
            SqlConnection conDel = new SqlConnection();
            conDel.ConnectionString = clsDbForReports.constr;
            conDel.Open();
            SqlCommand cmdDel = new SqlCommand("", conDel);
            cmdDel.CommandText = "delete from tMatReqDtl where matreqCode=@reqcode";
            cmdDel.Parameters.AddWithValue("@reqcode", Convert.ToInt32(txtMatReqCode.Text));
            cmdDel.ExecuteNonQuery();
            conDel.Close();
        }

        private void HeadNewClick()
        {
            dgvMain.Rows.Clear();
            dgvSanction.Rows.Clear();
            txtReqQty.Clear();
            NewEntry();
            tbMatRequest.SelectedTab = tbMain;
            DtlRowIndex = -1;
            lblDate.Text = "";
            btnSave.Text = "Save";
            btnSave.Enabled = true;
        }

        private void btnHeadNew_Click(object sender, EventArgs e)
        {
            HeadNewClick();   
        }

        private void btnDelHead_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete ?", "Deletion", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                DeleteFromHD();
            }
        }

        private void DeleteFromHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete from tMatReqHD where matreqCode=@matreqcode";
            cmd.Parameters.AddWithValue("@matreqcode", Convert.ToInt32(txtMatReqCode.Text));
            int i= cmd.ExecuteNonQuery();
            if (i == 1)
            {
                HeadNewClick();
                MatReqHDShowInGrid();
            }
            con.Close();
        }

        private void cmbMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReqQty.Focus();
            }
        }

        private void SanctionRequest()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "SanctionRequest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@matreqcode", Convert.ToInt32(txtMatReqCode.Text));
            cmd.Parameters.AddWithValue("@sanctionedOrNot", "N");
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);
            cmd.Parameters.AddWithValue("@screen", "MatRequest");
            cmd.Parameters.AddWithValue("@emailstat","Send");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void SanctionRequestInGrid()
        {
            dgvSanction.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string str1 = "select B.EmployeeName,A.sanctionedOrNot,A.sanctionedDate,A.remarks from tSanctionStatus A inner join Employee B on B.EmpId=A.empid where A.reccode=@matreqcode and screen='MatRequest'";
            sda.SelectCommand.CommandText = str1 ;
            sda.SelectCommand.Parameters.AddWithValue("@matreqcode", Convert.ToInt32(txtMatReqCode.Text));
            sda.SelectCommand.Parameters.AddWithValue("@screen", "MatRequest");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                dgvSanction.Rows.Add(1);
                int k = dgvSanction.Rows.Count;
                dgvSanction.Rows[k - 1].Cells["colEmName"].Value = ds.Tables[0].Rows[j]["EmployeeName"];
                dgvSanction.Rows[k - 1].Cells["colSanctionStatus"].Value = ds.Tables[0].Rows[j]["sanctionedOrNot"];
                dgvSanction.Rows[k - 1].Cells["colSanctionDate"].Value = ds.Tables[0].Rows[j]["sanctionedDate"];
                dgvSanction.Rows[k - 1].Cells["colRemarks"].Value = ds.Tables[0].Rows[j]["remarks"];
            }
            if (ds.Tables[0].Rows.Count != 0)
            {
                lblDate.Visible = true;
                btnRequest.Text = "Request Status : Sent";
                btnRequest.Enabled = false;
            }
        }

        private void sendmailtoapprove()
        {
        
        
            //CrystalReport1 oRpt = new CrystalReport1();            
            //SetDBLogonForReport(oRpt);
            //oRpt.ExportToDisk(ExportFormatType.PortableDocFormat, "e:\\a.pdf");            
            

        }
        
        
        private void btnRequest_Click(object sender, EventArgs e)
        {
            btnRequest.Text = "Please Wait";
            SanctionRequest();
            SanctionRequestInGrid();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            lblDate.Text = DateTime.Now.ToString();          
            lblDate.Visible = true;
            btnRequest.Enabled = false;
            MainEnableFalse();
            btnRequest.Text = "Request Status : Sent";

        }

        

        private void SendMsgFirstTime()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "MatSendMessage2";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Process obj = new Process();
            string machinename = " ";
            string msg = " ";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                obj.StartInfo.FileName = "net.exe";
                obj.StartInfo.CreateNoWindow = true;
                machinename = ds.Tables[0].Rows[i][1].ToString();
                msg = ds.Tables[0].Rows[i][2].ToString();
                obj.StartInfo.Arguments = " send " + machinename + " " + msg;
                obj.StartInfo.UseShellExecute = false;
                obj.Start();
                obj.WaitForExit();
            }
        }

        private void MatSupplierHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMatReqHD set SendForSupplier=@SendForSupplier where matreqCode=@matreqCode";
            cmd.Parameters.AddWithValue("@SendForSupplier", "Y");
            cmd.Parameters.AddWithValue("@matreqCode", Convert.ToInt32(txtMatReqCode.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void MainEnableTrue()
        {
            cmbMaterial.Enabled = true;
            txtReqQty.Enabled = true;
            btnEnter.Enabled = true;
            btnSave.Enabled = true;
            dgvMain.Enabled = true;
            cmbUnit.Enabled = true;
            txtConversion.Enabled = true;
        
        }

        private void MainEnableFalse()
        {
            cmbMaterial.Enabled = false;
            txtReqQty.Enabled = false;
            btnEnter.Enabled = false;
            btnSave.Enabled = false;
            cmbUnit.Enabled = false;
            txtConversion.Enabled = false;
        
           
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            showUnit();
            LargeUnit();
        }

        private void LargeUnit()
        {
            if (unitFlag == true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select B.Unit  from tMaterial A,UnitMaster  B where A.unitCode = B.UnitId and  A.MatCode = @mc";
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@mc", Convert.ToInt32(cmbMaterial.SelectedValue));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                txtMCLU.Text = ds.Tables[0].Rows[0][0].ToString();    
            }        
        }

        private void showUnit()
        {
            if (unitFlag == true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "FindConversionUnits";
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@mc", Convert.ToInt32(cmbMaterial.SelectedValue));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmbUnit.DataSource = ds.Tables[0];
                cmbUnit.DisplayMember = "unitdesc";
                cmbUnit.ValueMember = "unitid";
            }         
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowConversionQty();
        }

        private void ShowConversionQty()
        {
            if (UnitQtyFlag == true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "FindConversionQty";
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@mc", Convert.ToInt32(cmbMaterial.SelectedValue));
                sda.SelectCommand.Parameters.AddWithValue("@InputSUnitId", Convert.ToInt32(cmbUnit.SelectedValue));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                txtConversion.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

       private void dgvMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvMain, new Point(e.X, e.Y));
            }
        }

       private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {
           if (e.ClickedItem.Text == newMode)
           {
               DtlRowIndex = -1;
               btnEnter.Text = "Add";
               txtReqQty.Clear();
           }
           else
           {
               if (DtlRowIndex != -1)
               {
                   if (e.ClickedItem.Text == editMode)
                   {
                       CellDoubleClickDtl(DtlRowIndex);
                       btnEnter.Text = "Replace";
                   }
                   else if (e.ClickedItem.Text == del)
                   {
                       dgvMain.Rows.RemoveAt(DtlRowIndex);
                       DtlRowIndex = -1;
                   }
               }
           }
       }
       

       private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           DtlRowIndex = e.RowIndex;
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
       private void txtReqQty_KeyPress(object sender, KeyPressEventArgs e)
       {
           e.KeyChar = OnlyDecimalNum(e.KeyChar, txtReqQty.Text);
       }

       
        
        private void tbApprovalstatus_Click(object sender, EventArgs e)
       {
          
       }

        void showall()
        {
            grid1.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "approvestatus";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                grid1.Rows = ds.Tables[0].Rows.Count + 1;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grid1.Cell(i + 1, 1).Text = ds.Tables[0].Rows[i][0].ToString();
                    grid1.Cell(i + 1, 2).Text = ds.Tables[0].Rows[i][1].ToString();
                    grid1.Cell(i + 1, 3).Text = ds.Tables[0].Rows[i][2].ToString();
                    grid1.Cell(i + 1, 4).Text = ds.Tables[0].Rows[i][3].ToString();

                    if (grid1.Cell(i + 1, 4).Text.Trim() == "Send")
                    {
                        grid1.Cell(i + 1, 5).Locked = true;

                    }


                }
            }

        }
        void showspfstatus(string stat)
        {
            grid1.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "approvestatusspf";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@stat", stat);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                grid1.Rows = ds.Tables[0].Rows.Count + 1;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grid1.Cell(i + 1, 1).Text = ds.Tables[0].Rows[i][0].ToString();
                    grid1.Cell(i + 1, 2).Text = ds.Tables[0].Rows[i][1].ToString();
                    grid1.Cell(i + 1, 3).Text = ds.Tables[0].Rows[i][2].ToString();
                    grid1.Cell(i + 1, 4).Text = ds.Tables[0].Rows[i][3].ToString();

                    if (grid1.Cell(i + 1, 4).Text.Trim() == "Send")
                    {
                        grid1.Cell(i + 1, 5).Locked = true;

                    }
                }
            }
        }
        private void btappshow_Click(object sender, EventArgs e)
        {
            
                


        }
        private void mailstatusPending()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd= new SqlCommand("", con);
            cmd.CommandText = "update tsanctionstatus set emailstatus='Pending'where empid=@empid and reccode=@matid";
            cmd.Parameters.AddWithValue("@empid",Convert.ToInt32(empnameid));
            cmd.Parameters.AddWithValue("@matid", Convert.ToInt32(txtMatReqCode.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        
        }

        void mailsend(int matreq)
        {
            

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sdaa = new SqlDataAdapter("", con);
            sdaa.SelectCommand.CommandText = "select (PageUrl+PageName)  UrlName from  tWebPages where recid=3";
            DataSet dsweb = new DataSet();
            sdaa.Fill(dsweb);
            string url = dsweb.Tables[0].Rows[0][0].ToString();
            
            sdaa.SelectCommand.CommandText = "select (PageUrl+PageName)  UrlName from  tWebPages where recid=1";
            DataSet dsweb1 = new DataSet();
            sdaa.Fill(dsweb1);
            string url1 = dsweb1.Tables[0].Rows[0][0].ToString();
            

            DataSet dscomp = new DataSet();
            sdaa.SelectCommand.CommandText = "select PortAdress,ClientId,Password,Port from tCompanyMailInfo";
            sdaa.Fill(dscomp);
            string s1 = dscomp.Tables[0].Rows[0][0].ToString();
            string s2 = dscomp.Tables[0].Rows[0][1].ToString();
            string s3 = dscomp.Tables[0].Rows[0][2].ToString();
            int s4 = Convert.ToInt32(dscomp.Tables[0].Rows[0][3].ToString());


            sdaa.SelectCommand.CommandText = "select b.empid, b.email from tSanction a,employee b  where a.screen='MatRequest' and a.empid=b.empid";

            DataSet dss = new DataSet();
            sdaa.Fill(dss);
            int a = dss.Tables[0].Rows.Count;
            for (int j = 0; j < a; j++)
            {
                flagformail = 0;
                empnameid = dss.Tables[0].Rows[j][0].ToString();
                string apphead = "<html><body><table cellpadding=10><tr>";
                //recid=3,default3.aspx
            //    string apps1 = "<td><a href=\""+url+"?manid=" + dss.Tables[0].Rows[j][0].ToString() + "&matreqid=" + txtMatReqCode.Text + "\"> Login </a></td>";
                string apps1 = "<td><a href=\"" + url + "?manid=" + dss.Tables[0].Rows[j][0].ToString() + "&matreqid=" + matreq.ToString()  + "\"> Login </a></td>";



                //recid=1,default.aspx
               // string apps2 = "<td><a href=\"" + url1 + "?manid=" + dss.Tables[0].Rows[j][0].ToString() + "&matreqid=" + txtMatReqCode.Text + "\"> senderUpdation </a></td>";
                string apps2 = "<td><a href=\"" + url1 + "?manid=" + dss.Tables[0].Rows[j][0].ToString() + "&matreqid=" + matreq.ToString () + "\"> senderUpdation </a></td>";

                string appstail = "</tr></table></body></html>";

                string appstatus = apphead + apps1 + apps2+ appstail;

                
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                lblDate.Text = DateTime.Now.ToString();
                lblDate.Visible = true;
                btnRequest.Enabled = false;
                MainEnableFalse();
                btnRequest.Text = "Request Status : Sent";


                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select mt.MatDesc , m.qty ,mt.Rate from tMatReqDtl m join tMaterial mt on m.matcode=mt.MatCode where matreqCode= @matreqCode";
                sda.SelectCommand.Parameters.AddWithValue("@matreqCode", matreq);


                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataSet ds2 = new DataSet();
                sda.SelectCommand.CommandText = "select matreqCode,d.Department ,convert(nvarchar(10),m.matreqDate ,103) matreqDate from tMatReqHD m inner join department d on m.depid =d.DepId where matreqCode= @matreqCode1";
                sda.SelectCommand.Parameters.AddWithValue("@matreqCode1", matreq);
                sda.Fill(ds2);



                int d1 = ds.Tables[0].Rows.Count;
                int d2 = ds2.Tables[0].Rows.Count;
               

                if (d1 > 0 & d2 > 0)
                {


                    MailMessage mail = new MailMessage();
                    //string str1 = "nair.tusha@gmail.com";
                    string st2 = dss.Tables[0].Rows[j][1].ToString();
                    //mail.From = new MailAddress("tusha12eeitsol@gmail.com");

                    mail.From = new MailAddress(s2); //add by sk

                    mail.To.Add(st2);
                    mail.Subject = "Approval";

                    //for table1

                    string t1x1 = "<html><body><table border=1 cellspacing=0 cellpadding=10><tr><th>Material</th><th>Quantity</th><th>Rate</th></tr>";
                    string t1yy = null;
                    for (int i = 0; i < d1; i++)
                    {
                        string t1y = "<tr><td>" + ds.Tables[0].Rows[i][0].ToString() + "</td><td>" + ds.Tables[0].Rows[i][1].ToString() + "</td><td>" + ds.Tables[0].Rows[i][2].ToString() + "</td></tr>";
                        t1yy = t1yy + t1y;
                    }
                    string t1x2 = "</table></body></html>";

                    string send = t1x1 + t1yy + t1x2;

                    //for table2
                   
                    
                    string t2x1 = "<html><body><table border=1 cellspacing=0 cellpadding=10><tr><th>Matreqno</th><th>Dept</th><th>Date</th></tr>";
                    string t2yy = null;
                    for (int i = 0; i < d2; i++)
                    {
                        string strdate = ds2.Tables[0].Rows[i][2].ToString();
                        string t2y = "<tr><td>" + ds2.Tables[0].Rows[i][0].ToString() + "</td><td>" + ds2.Tables[0].Rows[i][1].ToString() + "</td><td>" + strdate + "</td></tr>";
                        t2yy = t2yy + t2y;
                    }
                    string t2x2 = "</table></body></html>";
                    string send2 = t2x1 + t2yy + t2x2;


                    mail.Body = send2 + "<br>" + send + "<b>" + appstatus;


                    AlternateView planview = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable tby those clients that don't support html");
                    AlternateView htmlview = AlternateView.CreateAlternateViewFromString("<b>This is bold text and viewable by those mail clients that support html<b>");
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    SmtpClient smtp = new SmtpClient(s1,s4); //s1 smtp address,s4 port no
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential(s2,s3);   //source id & password
                   

                    try
                    {
                        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                        mail.Sender = new MailAddress(s2, "Sam1");                  // don't know is it necessary

                        smtp.Send(mail);


                    }

                    catch 
                    {
                        flagformail = 1;
                       
                    }

                    if (flagformail == 1)
                    {
                        mailstatusPending();
                        flagformail = 0;
                    }


                }
            }
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
           
            SanctionRequest();
            mailsend(Convert.ToInt32 (txtMatReqCode.Text));
            SanctionRequestInGrid();
         
            }
      
        


        private void dgvHeadView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       private void resendstatus(string emailstat,int empid,int matid)
       { 
           SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
             cmd.CommandText = "update tsanctionstatus set emailstatus='Send'where empid=@empid and reccode=@matid";
                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@matid", matid);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    con.Close();
       }


       private void SendButton()
       {
           int matreq;
           int empid;
           SqlConnection con = new SqlConnection();
           con.ConnectionString = clsDbForReports.constr;
           con.Open();
           SqlCommand cmd = new SqlCommand("", con);

           try
           {

               int rowid = grid1.Rows;
               for (int i = 1; i <= rowid - 1; i++)
               {
                   if (grid1.Cell(i, 5).Text.Trim().Length == 0)
                   {
                       grid1.Cell(i, 5).Text = "0";
                   }

                   if (grid1.Cell(i, 5).Text == "1")
                   {
                       matreq = Convert.ToInt32(grid1.Cell(i, 1).Text);
                       string strname = grid1.Cell(i, 3).Text;

                       SqlDataAdapter sda = new SqlDataAdapter("", con);
                       sda.SelectCommand.CommandText = "select empid from employee where employeename=@empname";
                       sda.SelectCommand.CommandType = CommandType.Text;
                       sda.SelectCommand.Parameters.AddWithValue("@empname", strname);
                       DataSet ds = new DataSet();
                       sda.Fill(ds);
                       empid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                       resendstatus("Send", empid, matreq);
                       try
                       {
                           mailsend(matreq);
                       }
                       catch
                       {
                           resendstatus("Pending", empid, matreq);
                           MessageBox.Show(" Network Connection Failure");

                       }

                       showspfstatus("pending");
                       con.Close();
                   }
               }
           }
           catch
           {

           }
          }

       private void button1_Click(object sender, EventArgs e)
       {
           SendButton();
          
          
       }

       
      


        private void rbsend_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbfailure_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rbpend_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rball_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rball_Click(object sender, EventArgs e)
        {
            showall();
        }

        private void rbsend_Click(object sender, EventArgs e)
        {
            showspfstatus("send");
        }

        private void rbpend_Click(object sender, EventArgs e)
        {
            showspfstatus("pending");
        }

        private void rbfailure_Click(object sender, EventArgs e)
        {
            showspfstatus("failure");
        } 
      

    }  
  
}
