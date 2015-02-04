using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmProductionUpdate : Form
    {
      
        bool nameFlag = false;
        int loopFlag = 0;       

        public frmProductionUpdate()
        {
            InitializeComponent();
        }



        private void BundleShow()
        {
            string sstr = "";
            for (int j = 0; j <= clbStyle.Items.Count - 1; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    sstr = sstr + clbStyle.Items[j].ToString() + ",";
                }
            }
            if (sstr.Trim().Length == 0)
            {
                sstr = ",";
            }

            string lstr = "";
            for (int j = 0; j <= clbLot.Items.Count - 1; j++)
            {
                if (clbLot.GetItemChecked(j) == true)
                {
                    lstr = lstr + clbDupLot.Items[j].ToString() + ",";
                }
            }
            if (lstr.Trim().Length == 0)
            {
                lstr = ",";
            }


            txtPrdQty.Text = "0";
            btnUpdate.Enabled = true;
            txtPndPcs.Text = "0";
            txtCmpltdPCS.Text = "0";
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.Parameters.Clear();
            sda.SelectCommand.CommandText = "ProductionBundleShow";
            sda.SelectCommand.Parameters.AddWithValue("@styleString",sstr);
            sda.SelectCommand.Parameters.AddWithValue("@LotNoString", lstr);
            sda.SelectCommand.Parameters.AddWithValue("@actCode", Convert.ToInt32(cmbActivity.SelectedValue.ToString()));
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lvBundle.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        lvBundle.Items.Add(ds.Tables[0].Rows[i]["bunIntno"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["stylecode"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["LayerBatchNo"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Qty"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["CmpQty"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["pndqty"].ToString());
                        //lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["styleid"].ToString());
                        lvBundle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["activitycode"].ToString());
                        if (ds.Tables[0].Rows[i]["pndqty"].ToString() == "0")
                        {
                            lvBundle.Items[i].Checked = true;
                            lvBundle.Items[i].ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    lvBundle.Items[0].Selected = true;                                
            }
        
        }

        private void PieceShow()
        {
            if (txtBunNo.Text.Trim().Length == 0)
            {
                txtBunNo.Text = "0";
            }
            string sstr = "";
            for (int j = 0; j <= clbStyle.Items.Count - 1; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    sstr = sstr + clbStyle.Items[j].ToString() + ",";
                }
            }
            if (sstr.Trim().Length == 0)
            {
                sstr = ",";
            }

            string lstr = "";
            for (int j = 0; j <= clbLot.Items.Count - 1; j++)
            {
                if (clbLot.GetItemChecked(j) == true)
                {
                    lstr = lstr + clbDupLot.Items[j].ToString() + ",";
                }
            }
            if (lstr.Trim().Length == 0)
            {
                lstr = ",";
            }
            txtPrdQty.Text = "0";
            btnUpdate.Enabled = true;
            txtPndPcs.Text = "0";
            txtCmpltdPCS.Text = "0";
            txthidStyle.Text = "0";
            txthidLot.Text = "0";
            txthidBunFromDB.Text = "0";
            txthidAct.Text = "0";
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.Parameters.Clear();
            sda.SelectCommand.CommandText = "ProductionBundleShow2";
            sda.SelectCommand.Parameters.AddWithValue("@styleString", sstr);
            sda.SelectCommand.Parameters.AddWithValue("@LotNoString", lstr);
            sda.SelectCommand.Parameters.AddWithValue("@actCode", Convert.ToInt32(cmbActivity.SelectedValue.ToString()));
            sda.SelectCommand.Parameters.AddWithValue("@bunno", Convert.ToInt32(txtBunNo.Text));
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lvBundle.Items.Clear();
            txtPrdQty.Enabled = true;
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtQty.Text = ds.Tables[0].Rows[0]["qty"].ToString();
                txtPndPcs.Text = ds.Tables[0].Rows[0]["pndqty"].ToString();
                txtCmpltdPCS.Text = ds.Tables[0].Rows[0]["CmpQty"].ToString();                
                txthidStyle.Text = ds.Tables[0].Rows[0]["stylecode"].ToString();
                txthidLot.Text = ds.Tables[0].Rows[0]["LayerBatchNo"].ToString();
                txthidBunFromDB.Text = ds.Tables[0].Rows[0]["bunIntNo"].ToString();
                txthidAct.Text = ds.Tables[0].Rows[0]["activitycode"].ToString();
                if (txtPndPcs.Text == "0")
                {
                    txtPrdQty.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
        }

        private bool ChkMinCount()
        {
            bool ret = true;
            btnShow.Enabled = true;
            int x = 0;
            for (int j = 0; j <= clbStyle.Items.Count - 1; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    x++;
                }
            }
            if (x == 0)
            {
                MessageBox.Show("Select Minimum One Style");
                btnShow.Enabled = false;
                ret = false;
            }
            x = 0;
            for (int j = 0; j <= clbLot.Items.Count - 1; j++)
            {
                if (clbLot.GetItemChecked(j) == true)
                {
                    x++;
                  
                }
            }
            if (x == 0)
            {
                MessageBox.Show("Select Minimum One Lot Number");
                btnShow.Enabled = false;
                ret = false;
            }
            return ret;
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShowClick();
            btnReverse.Enabled = true;
        }

        private void btnShowClick()
        {
            lvBundle.Items.Clear();
            lvBundle2.Items.Clear();
            btnUpdate.Enabled = true;
            txtPrdQty.Enabled = true;
            if (ChkMinCount() == true)
            {
                if (rbBundle.Checked == true)
                {
                    BundleShow();
                    if (chbDeletion.Checked == true)
                    {
                        showBundleForDeletion();
                    }
                }
                else
                {
                    PieceShow();
                    if (chbDeletion.Checked == true)
                    {
                        ShowPieceForDeletion();
                    }
                }
            }            
        }

        private void showBundleForDeletion()
        {
            string sstr = "";
            for (int j = 0; j <= clbStyle.Items.Count - 1; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    sstr = sstr + clbStyle.Items[j].ToString() + ",";
                }
            }
            if (sstr.Trim().Length == 0)
            {
                sstr = ",";
            }

            string lstr = "";
            for (int j = 0; j <= clbLot.Items.Count - 1; j++)
            {
                if (clbLot.GetItemChecked(j) == true)
                {
                    lstr = lstr + clbDupLot.Items[j].ToString() + ",";
                }
            }
            if (lstr.Trim().Length == 0)
            {
                lstr = ",";
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.Parameters.Clear();
            sda.SelectCommand.CommandText = "ProductionEditBundleShow";
            sda.SelectCommand.Parameters.AddWithValue("@styleString", sstr);
            sda.SelectCommand.Parameters.AddWithValue("@LotNoString", lstr);
            sda.SelectCommand.Parameters.AddWithValue("@actCode", Convert.ToInt32(cmbActivity.SelectedValue.ToString()));
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lvBundle2.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvBundle2.Items.Add(ds.Tables[0].Rows[i]["Name"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["ID"].ToString());                    
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["bunintno"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["layerbatchno"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["stylecode"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Date"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Time"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Qty"].ToString());                    
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["recid"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["activitycode"].ToString());
                }
            }                  
        }


        private void ShowPieceForDeletion()
        {
            if (txtBunNo.Text.Trim().Length == 0)
            {
                txtBunNo.Text = "0";
            }
            string sstr = "";
            for (int j = 0; j <= clbStyle.Items.Count - 1; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    sstr = sstr + clbStyle.Items[j].ToString() + ",";
                }
            }
            if (sstr.Trim().Length == 0)
            {
                sstr = ",";
            }

            string lstr = "";
            for (int j = 0; j <= clbLot.Items.Count - 1; j++)
            {
                if (clbLot.GetItemChecked(j) == true)
                {
                    lstr = lstr + clbDupLot.Items[j].ToString() + ",";
                }
            }
            if (lstr.Trim().Length == 0)
            {
                lstr = ",";
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.Parameters.Clear();
            sda.SelectCommand.CommandText = "ProductionEditBundleShow2";
            sda.SelectCommand.Parameters.AddWithValue("@styleString", sstr);
            sda.SelectCommand.Parameters.AddWithValue("@LotNoString", lstr);
            sda.SelectCommand.Parameters.AddWithValue("@actCode", Convert.ToInt32(cmbActivity.SelectedValue.ToString()));            
            sda.SelectCommand.Parameters.AddWithValue("@bunno", Convert.ToInt32(txtBunNo.Text));
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lvBundle2.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvBundle2.Items.Add(ds.Tables[0].Rows[i]["Name"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["ID"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["bunintno"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["layerbatchno"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["stylecode"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Date"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Time"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Qty"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["recid"].ToString());
                    lvBundle2.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["activitycode"].ToString());
                }
            }
        }


        private void frmProductionUpdate_Load(object sender, EventArgs e)
        {
            txtBunNo.Visible = false;
            lblBundleNo.Visible = false;
            rbBundle.Checked = false;
            rbBundle.Checked = true;           
            LoadStyleCode();          
            LoadLayBNo();          
            LoadActivities();
            LoadTime();
            nameFlag = false;
            LoadEmployee();
            nameFlag = true;
            txtID.Text = "10";
            LoadMachine();
            FindMachine(10);
        }

        private void LoadMachine()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "MachineNumberWithNA";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbMachine.DataSource = ds.Tables[0];
            cmbMachine.DisplayMember = "MachineNo";
            cmbMachine.ValueMember = "machineid";
        }
       
        private void LoadStyleCode()
        {
            clbStyle.Items.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select styleCode from tStyleMaster order by styleCode desc";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                clbStyle.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }


        private void LoadLayBNo()
        {
            clbLot.Items.Clear();
            clbDupLot.Items.Clear();
            string str="";
            for (int j = 0; j <=clbStyle.Items.Count -1 ; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    str = str + clbStyle.Items[j].ToString()+",";   
                }
            }
            if (str.Trim().Length == 0)
            {
                str = ",";
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "showStyleLotNumber";
            sda.SelectCommand.Parameters.AddWithValue("@styleString", str);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                clbLot.Items.Add(ds.Tables[0].Rows[i]["num"].ToString());
                clbDupLot.Items.Add(ds.Tables[0].Rows[i]["layerbatchno"].ToString());
            }
        
        }



        private void rbBundle_CheckedChanged(object sender, EventArgs e)
        {
            rbBunPieces();
            btnShow.Enabled = true;
        }

        private void rbPiece_CheckedChanged(object sender, EventArgs e)
        {
            rbBunPieces();
        }

        private void rbBunPieces()
        {
            txtPndPcs.Enabled = false;
            txtCmpltdPCS.Enabled = false;
            txtQty.Enabled = false;
            txtQty.Text = "0";
            txtCmpltdPCS.Text = "0";
            txtPndPcs.Text = "0";
            txtPrdQty.Text = "0";
            if (rbBundle.Checked == true)
            {
                lvBundle.Items.Clear();
                lvBundle.Enabled = true;
                txtPrdQty.Enabled = false;
                txtBunNo.Visible = false;
                lblBundleNo.Visible = false;
            }
            else
            {
                lvBundle.Items.Clear();
                lvBundle.Enabled = false;
                txtPrdQty.Enabled = true;
                txtBunNo.Visible = true;
                lblBundleNo.Visible = true;
                PieceValidation();
            }
            btnUpdate.Enabled = true;
        }


        private void PieceValidation()
        {
            for (int j = 0; j <= clbStyle.Items.Count - 1; j++)
            {
                clbStyle.SetItemChecked(j, false);                
            }
            for (int j = 0; j <= clbLot.Items.Count - 1; j++)
            {
                clbLot.SetItemChecked(j, false);
            }
        }

        private void LoadActivities()
        {
            string ord = "Num";
            if (rbAlphabatical.Checked == true)
            {
                ord = "Alp";
            }
            string str="";
            for (int j = 0; j <=clbStyle.Items.Count -1 ; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    str = str + clbStyle.Items[j].ToString()+",";   
                }
            }
            if (str.Trim().Length == 0)
            {
                str = ",";
            }

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "sCBProdActivities";
            sda.SelectCommand.Parameters.AddWithValue("@styleString", str);
            sda.SelectCommand.Parameters.AddWithValue("@ord", ord);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbActivity.DataSource = ds.Tables[0];
            cmbActivity.DisplayMember = "activityname";
            cmbActivity.ValueMember = "activitycode";
        }

        private void LoadTime()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select timecode,timedescription from tTimecode";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbTime.DataSource = ds.Tables[0];
            cmbTime.DisplayMember = "timedescription";
            cmbTime.ValueMember = "timecode";
        }

        private void LoadEmployee()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select empid,employeename from employee where activeorresigned='A'   order by employeename";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbName.DataSource = ds.Tables[0];
            cmbName.DisplayMember = "employeename";
            cmbName.ValueMember = "empid";                
        }

        private void FindMachine(int id)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select machineid  from tLastMachineEmployee where empid = @eid";
            sda.SelectCommand.Parameters.AddWithValue("@eid", id);          
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbMachine.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                cmbMachine.SelectedValue = "0";
            }
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loopFlag = loopFlag + 1;            
            if (loopFlag == 1)
            {
                if (nameFlag == true)
                {
                    txtID.Text = cmbName.SelectedValue.ToString();
                    FindMachine(Convert.ToInt32(txtID.Text));
                }
            }
            loopFlag = 0;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            loopFlag = loopFlag + 1;
            if ((txtID.Text.Trim().Length != 0) && (txtID.Text != null)&& (loopFlag == 1))
            {                
                cmbName.SelectedValue = txtID.Text;
                FindMachine(Convert.ToInt32(txtID.Text));
            }
            loopFlag = 0;
        }

       
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
         
            if (dtpDate.Value < Convert.ToDateTime ( "09/30/2013"))
            {
                if (cmbName.Text.Trim().Length != 0)
                {
                    if (rbBundle.Checked == true)
                    {
                        BundleUpdateProcess();
                    }
                    else
                    {
                        PieceUpdateProcess();
                    }

                    btnUpdate.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Select an employee");
                }
            }
            else
            {
                MessageBox.Show("Please update latest version");
            }
        }

        private void PieceUpdateProcess()
        {
            int bno = Convert.ToInt32(txthidBunFromDB.Text);
            int qty = Convert.ToInt32(txtQty.Text);
            int cmltd = Convert.ToInt32(txtCmpltdPCS.Text);
            int pno = Convert.ToInt32(txtPndPcs.Text);
            int prdQty = Convert.ToInt32(txtPrdQty.Text);
            string stycode = txthidStyle.Text;
            int lotno = Convert.ToInt32(txthidLot.Text );           
            int actcode = Convert.ToInt32(txthidAct.Text);            
            if (pno != 0)
            {
                if (prdQty <= pno)
                {
                    PieceUpdate(bno, prdQty,lotno,stycode ,actcode );
                    ProductionActInsert(bno, prdQty, "P",stycode, lotno,  actcode);
                }
                else
                {
                    MessageBox.Show("Not Possible");
                }                
            }                      
        }

        private void PieceUpdate(int bno, int ProdQty,int lotno,string stycode ,int actcode)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tLayCutBunAct set cmpQty = cmpqty+@ProdQty,PndQty=PndQty-@ProdQty where LayerBatchNo=@lbno and BunIntNo=@bunno and activitycode=@actcode and stylecode=@scode";
            scmd.Parameters.AddWithValue("@bunno", bno);
            scmd.Parameters.AddWithValue("@lbno", lotno );
            scmd.Parameters.AddWithValue("@ProdQty", ProdQty);
            scmd.Parameters.AddWithValue("@scode", stycode);
            scmd.Parameters.AddWithValue("@actcode", actcode);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void BundleUpdateProcess()
        {
            int bno = 0;
            int cmltd = 0;
            int pno = 0;
            string stycode = "";
            int lotno = 0;           
            int actcode = 0;
            for (int i = 0; i < lvBundle.Items.Count; i++)
            {
                if (lvBundle.Items[i].Checked == true)
                {
                    bno = Convert.ToInt32(lvBundle.Items[i].Text);
                    cmltd = Convert.ToInt32(lvBundle.Items[i].SubItems[4].Text);
                    pno = Convert.ToInt32(lvBundle.Items[i].SubItems[5].Text);
                    stycode=lvBundle.Items[i].SubItems[1].Text;
                    lotno=Convert.ToInt32(lvBundle.Items[i].SubItems[2].Text);
                    actcode = Convert.ToInt32(lvBundle.Items[i].SubItems[6].Text);
                    if (pno != 0)
                    {
                        if (cmltd == 0)
                        {
                            BundleUpdate(bno, "Yes",stycode,lotno, actcode);
                        }
                        else
                        {
                            BundleUpdate(bno, "No", stycode, lotno, actcode);
                        }
                        ProductionActInsert(bno, pno, "B",stycode, lotno,  actcode);
                    }
                }
            }        
        }

        private void BundleUpdate(int bno,string czero,string stycode,int lotno,int actcode)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            if (czero == "Yes")
            {
                scmd.CommandText = "update tLayCutBunAct set cmpQty = Pndqty,PndQty=0 where stylecode=@styc and LayerBatchNo=@lbno and BunIntNo=@bunno and activitycode=@acode";
            }
            else
            {
                scmd.CommandText = "update tLayCutBunAct set cmpQty = Qty,PndQty=0 where stylecode=@styc and  LayerBatchNo=@lbno and BunIntNo=@bunno and activitycode=@acode";
            }
            scmd.Parameters.AddWithValue("@styc", stycode );
            scmd.Parameters.AddWithValue("@bunno", bno);
            scmd.Parameters.AddWithValue("@lbno", lotno);
            scmd.Parameters.AddWithValue("acode",actcode);
            int i = scmd.ExecuteNonQuery();
            sc.Close();        
        }

        private void ProductionActInsert(int bunno, int qty, string BorP, string stycode, int lotno, int actcode)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "iProdActivites";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@LayerBatchNo",lotno );
            scmd.Parameters.AddWithValue("@BunNo", bunno);
            scmd.Parameters.AddWithValue("@Activitycode", actcode );
            scmd.Parameters.AddWithValue("@ActivityName", cmbActivity.Text );
            scmd.Parameters.AddWithValue("@Qty", qty);        
            scmd.Parameters.AddWithValue("@Stylecode", stycode);
            scmd.Parameters.AddWithValue("@ProdDate",Convert.ToDateTime ( dtpDate.Value.ToShortDateString ()) );
            scmd.Parameters.AddWithValue("@TimeCode",Convert.ToInt32(cmbTime.SelectedValue .ToString ()));
            scmd.Parameters.AddWithValue("@EmpID", Convert.ToInt32 (txtID.Text));
            scmd.Parameters.AddWithValue("@BunOrPieces", BorP );
            scmd.Parameters.AddWithValue("@machineid", Convert.ToInt32(cmbMachine.SelectedValue.ToString ()));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
            Machineupdation();
        }


        private void Machineupdation( )
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tLastMachineEmployee set empid = @EmpID where machineid =@machineid ";
            scmd.Parameters.AddWithValue("@EmpID", Convert.ToInt32(txtID.Text));
            scmd.Parameters.AddWithValue("@machineid", Convert.ToInt32(cmbMachine.SelectedValue.ToString()));
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }
        
        private void lvBundle_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked && lvBundle.Items[e.Index].SubItems[3].Text =="0")
            {
                e.NewValue = CheckState.Checked;
           }
        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void clbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLayBNo();
            LoadActivities();
            PieceCount();
        }

        private void rbNumber_CheckedChanged(object sender, EventArgs e)
        {
            LoadActivities();
        }

        private void rbAlphabatical_CheckedChanged(object sender, EventArgs e)
        {
            LoadActivities();
        }

        private void clbLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            PieceCount();
        }

        private void PieceCount()
        {
            btnShow.Enabled = true;
            if(rbPiece.Checked == true )
            {
            int s = 0;
            int l = 0;
            for (int j = 0; j <= clbStyle.Items.Count - 1; j++)
            {
                if (clbStyle.GetItemChecked(j) == true)
                {
                    s = s + 1;
                }
            }
            for (int j = 0; j <= clbLot.Items.Count - 1; j++)
            {
                if (clbLot.GetItemChecked(j) == true)
                {
                    l = l + 1;
                }
            }
            if (s > 1)
            {
                MessageBox.Show("Can not select more than one style in Piece Option");
                btnShow.Enabled = false;
            }
            if (l > 1)
            {
                MessageBox.Show("Can not select more than one Lot Number in Piece Option");
                btnShow.Enabled = false;
            }
           }

        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
                if (chbDeletion.Checked == true)
                {
                    ReverseProcess();
                }
                else
                {
                    MessageBox.Show("Since Deletion check box unchecked, can not delete");
                }
                btnShowClick();
                btnReverse.Enabled = false;
            
            
        }

        private void ReverseProcess()
        {
            for (int i = 0; i < lvBundle2.Items.Count; i++)
            {
                if (lvBundle2.Items[i].Checked == true)
                {
                    int qty2 = Convert.ToInt32(lvBundle2.Items[i].SubItems[7].Text);
                    int bunno = Convert.ToInt32(lvBundle2.Items[i].SubItems[2].Text);
                    int LotNo = Convert.ToInt32(lvBundle2.Items[i].SubItems[3].Text);
                    string StCode = lvBundle2.Items[i].SubItems[4].Text;
                    int recid = Convert.ToInt32(lvBundle2.Items[i].SubItems[8].Text);
                    int actid = Convert.ToInt32(lvBundle2.Items[i].SubItems[9].Text);
                    ChangeInBunAct(qty2, bunno, LotNo, StCode, actid);
                    InsertIntoLog(bunno);
                    DeleteInProdAct(recid);
                }
            }
        }


        private void ChangeInBunAct(int qty2, int bunno, int LotNo, string StCode, int actid)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tLayCutBunAct set cmpqty=cmpqty-@qty2,pndqty=pndqty+@qty2 where LayerBatchNo=@lno and BunIntNo = @bno and StyleCode=@stcode and ActivityCode=@acode";
            scmd.Parameters.AddWithValue("@qty2", qty2);
            scmd.Parameters.AddWithValue("@lno", LotNo);
            scmd.Parameters.AddWithValue("@bno", bunno);
            scmd.Parameters.AddWithValue("@StCode", StCode);
            scmd.Parameters.AddWithValue("@acode", actid);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void DeleteInProdAct(int recid)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete tProdActivites where recid=@recid";
            scmd.Parameters.AddWithValue("@recid", recid);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void InsertIntoLog(int recid)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert into tProdActivitesDelLog select * from tProdActivites where recid=@recid";
            scmd.Parameters.AddWithValue("@recid", recid);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }



     }
}
