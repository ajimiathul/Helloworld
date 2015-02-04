using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient ;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmEmployee : Form
    {
        string  newEdit;
        int ecode=0;
        public frmEmployee()
        {
            InitializeComponent();
        }

        
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            newEdit = "New";
            lblNewEdit.Text = "New Entry Mode";        
            LoadLocation();
            LoadDepartment();
            LoadDesignation();
            LoadSalType();
            LoadOperator();
            LoadEmpStatus();           
            cmbneedmachine.Text = "Yes";
        }

        
        private void LoadLocation()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select loccode,location  from location where compcode=@cd order by disporder ";
            sda.SelectCommand.Parameters.AddWithValue ("@cd",clsDbForReports.companycode ); 
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbLocation .DataSource = ds.Tables[0];
            cmbLocation .DisplayMember = "location";
            cmbLocation .ValueMember = "loccode";
        }

        private void LoadDepartment()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select depid,department  from department   order by disporder ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbDepartment.DataSource = ds.Tables[0];
            cmbDepartment.DisplayMember = "department";
            cmbDepartment.ValueMember = "depid";
        }


        

        private void LoadOperator()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select operatorid,operator from toperatortype order by OrderNo";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmboperator.DataSource = ds.Tables[0];
            cmboperator.DisplayMember = "operator";
            cmboperator.ValueMember = "operatorid";
        }

        private void LoadEmpStatus()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select id,Empstatus from TEmpstatus";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbempstatus.DataSource = ds.Tables[0];
            cmbempstatus.DisplayMember = "Empstatus";
            cmbempstatus.ValueMember = "id";

        }

        
        private void LoadDesignation()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select DesignationID,Designation  from Designation order by disporder ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbDesignation .DataSource = ds.Tables[0];
            cmbDesignation.DisplayMember = "Designation";
            cmbDesignation.ValueMember = "DesignationID";
        }

        private void LoadSalType()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select saltypecode,saltype  from saltype order by saltypecode ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbType.DataSource = ds.Tables[0];
            cmbType.DisplayMember = "saltype";
            cmbType.ValueMember = "saltypecode";
        }


        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int GetMappedAccCode()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select EqtAccHeadCode from tEmployeeType where EmpTypeCode=@code";
            sda.SelectCommand.Parameters.AddWithValue("@code", 1);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int x = Convert.ToInt32(ds.Tables[0].Rows[0]["EqtAccHeadCode"]);
            return x;
        }
        private void SaveInAccMaster()
        {
            int x = GetMappedAccCode();
            string GA = "A";
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "CreateAccount";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@acnUnder", x);
            scmd.Parameters.AddWithValue("@acname", txtEmpName.Text.Trim());
            scmd.Parameters.AddWithValue("@GAflag", GA);
            scmd.Parameters.AddWithValue("@sceoflag", "EMP");
            scmd.Parameters.AddWithValue("@opbal", 0);
            scmd.Parameters.AddWithValue("@scr", "AccMaster");
            scmd.Parameters.AddWithValue("@sceono", Convert.ToInt32 (txtEmpCode.Text));
            scmd.Parameters.AddWithValue("@db", 0);
            scmd.Parameters.AddWithValue("@cr", 0);
            scmd.Parameters.AddWithValue("@bal", 0);
            scmd.Parameters.AddWithValue("@nonentry", "N");
            scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void UpdateInAccMaster()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UpdateAccountForEmployee";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", txtEmpName.Text.Trim());
            cmd.Parameters.AddWithValue("@emtype", 1);
            cmd.Parameters.AddWithValue("@emid", ecode);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdateAccCode()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "update Employee set accode = B.AccCode from Employee A, tAccountMaster B where B.SCEOcode=@sceocode and B.SupCusEmpOth=@emp and A.EmpId = B.SCEOcode";
            cmd.Parameters.AddWithValue("@sceocode", Convert.ToInt32(txtEmpCode.Text));
            cmd.Parameters.AddWithValue("@emp", "EMP");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private bool DupCheckNew()
        {
            bool dup = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select EmpId from Employee where EmployeeName=@nm";
            sda.SelectCommand.Parameters.AddWithValue("@nm", txtEmpName.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Already Exist");
                dup = true;
                txtEmpName.Clear();
            }
            return dup;
        }
        private bool DupCheckEdit()
        {
            bool dup = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select EmpId from Employee where EmployeeName=@nm and EmpId<>@empid";
            sda.SelectCommand.Parameters.AddWithValue("@nm",txtEmpName.Text.Trim());
            sda.SelectCommand.Parameters.AddWithValue("@empid", Convert.ToInt32(txtEmpCode.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dup = true;
                MessageBox.Show("Data Already Exist");
                txtEmpName.Clear();
            }
            return dup;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmpName.Text.Trim().Length != 0)
            {
                if (newEdit == "New")
                {
                    if (DupCheckNew() == false)
                    {
                        InsertEmployee();
                        SaveInAccMaster();
                        UpdateAccCode();
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    if (DupCheckEdit() == false)
                    {
                        UpdateEmployee();
                        UpdateInAccMaster();
                        btnSave.Enabled = false;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Employee Name should not empty");
            }
        }        
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            newEdit = "New";
            lblNewEdit.Text = "New Entry Mode";
            txtEmpCode.Text = "";
            txtEmpName.Text = "";
            btnSave.Enabled = true;
            rbActive.Checked = true;            
        }

        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            if (clsDbForReports.companycode  == 1)
            {
                scmd.Parameters.AddWithValue("@scr", "Employee-v6");
            }
            else
            {
                scmd.Parameters.AddWithValue("@scr", "Employee-Mth");
            }
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private int ReadLastNum()
        {
            UpdateLastNum();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "select lastnum from tNumbers where screen=@scr";
            if (clsDbForReports.companycode  == 1)
            {
                scmd.Parameters.AddWithValue("@scr", "Employee-v6");
            }
            else
            {
                scmd.Parameters.AddWithValue("@scr", "Employee-Mth");
            }
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }


        private void InsertEmployee()
        {
            ecode = ReadLastNum();
            txtEmpCode.Text = ecode.ToString();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "iEmployee";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@EmpId", ecode);
            scmd.Parameters.AddWithValue("@compCode", clsDbForReports.companycode );
            scmd.Parameters.AddWithValue("@loccode", Convert.ToInt32 (cmbLocation.SelectedValue.ToString ()));
            scmd.Parameters.AddWithValue("@EmployeeName", txtEmpName.Text.Trim());
            string gen = "Male";
            if (rbFemale.Checked == true)
            {
                gen = "Female";
            }
            scmd.Parameters.AddWithValue("@Gender", gen);
            scmd.Parameters.AddWithValue("@Experience", 0);
            scmd.Parameters.AddWithValue("@DOB", dtpDOB.Value);
            scmd.Parameters.AddWithValue("@JoinDate", dtpDOJ.Value);
            int athYesNo = 0;
            if (rbAuthorityYes.Checked == true)
            {
                athYesNo = 1;
            }
            scmd.Parameters.AddWithValue("@AuthorityToSign", athYesNo);
            scmd.Parameters.AddWithValue("@Address", txtAdr.Text);
            scmd.Parameters.AddWithValue("@Phone", txtPhone.Text );
            scmd.Parameters.AddWithValue("@Mobile", txtMobile.Text );
            scmd.Parameters.AddWithValue("@Email", txtMail.Text);
            scmd.Parameters.AddWithValue("@UserId", clsDbForReports.userid);
            scmd.Parameters.AddWithValue("@desigcode", Convert.ToInt32 (cmbDesignation.SelectedValue.ToString () ) );
            scmd.Parameters.AddWithValue("@depCode", Convert.ToInt32 (cmbDepartment.SelectedValue.ToString ()));
            string ActRes = "A";
            if (rbResigned.Checked == true)
            {
                ActRes = "R";
            }
            scmd.Parameters.AddWithValue("@ActiveOrResigned", ActRes);
            scmd.Parameters.AddWithValue("@SalTypeCode", Convert.ToInt32 (cmbType.SelectedValue.ToString ()));
            string onLv = "N";
            if (rbYesLeave.Checked == true)
            {
                onLv = "Y";
            }
            scmd.Parameters.AddWithValue("@OnLeave", onLv);
            scmd.Parameters.AddWithValue("@operatorid", cmboperator.SelectedValue.ToString ());
            scmd.Parameters.AddWithValue("@statusid", cmbempstatus.SelectedValue.ToString ());           
            scmd.Parameters.AddWithValue("@needmachine",cmbneedmachine.Text); 
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }



        private void UpdateEmployee()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);         
            scmd.CommandText = "uEmployee";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@compCode", clsDbForReports.companycode);
            scmd.Parameters.AddWithValue("@loccode", Convert.ToInt32(cmbLocation.SelectedValue.ToString()));
            scmd.Parameters.AddWithValue("@EmpId", ecode);
            scmd.Parameters.AddWithValue("@EmployeeName", txtEmpName.Text);
            string gen = "Male";
            if (rbFemale.Checked == true)
            {
                gen = "Female";
            }
            scmd.Parameters.AddWithValue("@Gender", gen);
            scmd.Parameters.AddWithValue("@DOB", dtpDOB.Value);
            scmd.Parameters.AddWithValue("@JoinDate", dtpDOJ.Value);
            bool  athYesNo = false ;
            if (rbAuthorityYes.Checked == true)
            {
                athYesNo = true;
            }
            else
            {
                athYesNo = false ;
            }
            scmd.Parameters.AddWithValue("@AuthorityToSign", athYesNo);
            scmd.Parameters.AddWithValue("@Address", txtAdr.Text);
            scmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            scmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
            scmd.Parameters.AddWithValue("@Email", txtMail.Text);
            scmd.Parameters.AddWithValue("@desigcode", Convert.ToInt32(cmbDesignation.SelectedValue.ToString()));
            scmd.Parameters.AddWithValue("@depCode", Convert.ToInt32(cmbDepartment.SelectedValue.ToString()));
            string ActRes = "A";
            if (rbResigned.Checked == true)
            {
                ActRes = "R";
            }
            scmd.Parameters.AddWithValue("@ActiveOrResigned", ActRes);
            scmd.Parameters.AddWithValue("@SalTypeCode", Convert.ToInt32(cmbType.SelectedValue.ToString()));
            string onLv = "N";
            if (rbYesLeave.Checked == true)
            {
                onLv = "Y";
            }
            scmd.Parameters.AddWithValue("@OnLeave", onLv);
            scmd.Parameters.AddWithValue("@DOR", dtpDOR.Value);
            scmd.Parameters.AddWithValue("@operatorid", cmboperator.SelectedValue.ToString());
            scmd.Parameters.AddWithValue("@statusid", cmbempstatus.SelectedValue.ToString());            
            scmd.Parameters.AddWithValue("@needmachine", cmbneedmachine.Text);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }



        private void rbNoLeave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchByTls_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "sEmployeeSearchByDtls";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@ccode", clsDbForReports.companycode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvSearchDtls.DataSource = ds.Tables[0];
            dgvSearchDtls.Columns[0].Width = 160;
        }

        private void tabMaster_Click(object sender, EventArgs e)
        {

        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

        }

        private void dgvSearchDtls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex;
            if (x != -1)
            {
                if (this.dgvSearchDtls.Rows.Count  > 0)
                {
                    if (this.dgvSearchDtls.SelectedRows.Count > 0)
                    {
                        int y = Convert.ToInt32(dgvSearchDtls.Rows[x].Cells[1].Value.ToString());
                        LoadEmployeeData(y,clsDbForReports.companycode );
                    }
                }
            }
        }

        private void LoadEmployeeData(int eid, int ccd)
        {
            newEdit = "Edit";
            lblNewEdit.Text = "Entry Mode : Edit";
            ecode = eid;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "sEmployee";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@empid", eid );
            sda.SelectCommand.Parameters.AddWithValue("@ccode", ccd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtEmpCode.Text = eid.ToString();
                txtEmpName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                  cmbLocation.SelectedValue = ds.Tables[0].Rows[0]["loccode"].ToString();
                  cmbDepartment.SelectedValue = ds.Tables[0].Rows[0]["depcode"].ToString();
                  cmbDesignation.SelectedValue = ds.Tables[0].Rows[0]["desigcode"].ToString();
                  dtpDOB.Value = Convert.ToDateTime ( ds.Tables[0].Rows[0]["dob"].ToString());
                  dtpDOJ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["JoinDate"].ToString());
                  string gen = ds.Tables[0].Rows[0]["gender"].ToString();
                  string st = ds.Tables[0].Rows[0]["operatorid"].ToString();
                  string s3t = ds.Tables[0].Rows[0]["NeedMachine"].ToString();
                  cmbneedmachine.Text = s3t.Trim();                 
                  

                if (st.Length != 0)
                  {
                      cmboperator.SelectedValue = ds.Tables[0].Rows[0]["operatorid"].ToString();

                  }
                  

                  string st1 = ds.Tables[0].Rows[0]["statusid"].ToString();
                  if (st1.Length != 0)
                  {
                      cmbempstatus.SelectedValue = ds.Tables[0].Rows[0]["statusid"].ToString();
                  }
                  if (gen == "Male")
                  {
                      rbMale.Checked = true;
                  }
                  else
                  {
                      rbFemale.Checked = true;
                  }
                  txtAdr.Text = ds.Tables[0].Rows[0]["address"].ToString();
                  txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                  txtMobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                  txtMail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                  cmbType.SelectedValue  = ds.Tables[0].Rows[0]["saltypecode"].ToString();
                  string status = ds.Tables[0].Rows[0]["ActiveOrResigned"].ToString();
                  if (status == "A")
                  {
                      rbActive.Checked = true;
                  }
                  else
                  {
                      rbResigned.Checked = true;
                      dtpDOR.Enabled = false;
                  }
                  string sLv = ds.Tables[0].Rows[0]["onLeave"].ToString();
                  if (sLv == "Y")
                  {
                      rbYesLeave.Checked = true;
                  }
                  else
                  {
                      rbNoLeave.Checked = true;
                  }
                  bool ath = Convert.ToBoolean  ( ds.Tables[0].Rows[0]["AuthorityToSign"].ToString());
                  if (ath == true )
                  {
                      rbAuthorityYes.Checked = true;
                  }
                  else
                  {
                      rbAuthorityNo.Checked = true;
                  }
            }
            tabControl1.SelectedTab = tabMaster;
            btnSave.Enabled = true;           
        }

        private void rbResigned_CheckedChanged(object sender, EventArgs e)
        {
            if (rbResigned.Checked == true)
            {
                dtpDOR.Enabled = true;
            }
            else
            {
                dtpDOR.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cmbneedmachine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
