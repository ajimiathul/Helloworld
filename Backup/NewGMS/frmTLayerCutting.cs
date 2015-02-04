using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmTLayerCutting : Form
    {
        string hidStyleCode = "";
        bool ItemChkFlag = false;        
        decimal  TotOrdQty = 0;
        bool balFlag = false;
        decimal startBundleNo = 0;        
        int SubSlno = 0;
        
        string frstcode = "";
        string frstsupcode = "";
        string scndcode = "";
        string scndsupcode = "";
        string currentFabcode = "";
        string currentSupcode = "";
        string frstFabColor = "";
        string scndFabColor = "";
        string currentFabColor = "";
        decimal  stickerno = 0M;
        decimal FQty;
        int AvgTot = 0;

        public frmTLayerCutting()
        {
            InitializeComponent();
        }

        private void LoadSizeRatio()
        {
            dgvAllRatio.Rows.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select SizeCode,Size from tRatioFormatDT where RatioFormatCode in (select RatioFormatCode from tStyleMaster where stylecode = @sc) order by sizecode";
            sda.SelectCommand.Parameters.AddWithValue("@sc", txtStyleCode.Text.Trim());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int x = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvAllRatio.Rows.Add(1);
                x = dgvAllRatio.Rows.Count;
                dgvAllRatio.Rows[x - 1].Cells["colRatioCode"].Value = ds.Tables[0].Rows[i]["SizeCode"].ToString();
                dgvAllRatio.Rows[x - 1].Cells["ColRatioValue"].Value = "0";
                dgvAllRatio.Rows[x - 1].Cells["ColSize"].Value = ds.Tables[0].Rows[i]["Size"].ToString();                
            }           
        }

        private void DisableTxtSr(bool TrueFalse)
        {            
            dgvAllRatio.Enabled = TrueFalse;
            rbColorDepends.Enabled = TrueFalse;
            rbFixed.Enabled = TrueFalse;
        }

        private void calculateTotal()
        {
            decimal  tot = 0;
            for (int i = 1; i <= dgvItem.Rows.Count; i++)
            {
                tot = tot + Convert.ToDecimal(dgvItem.Rows[i - 1].Cells["ordqty"].Value);               
                txtTotPieces.Text  = tot.ToString();
            }
        }
     
        private void frmTLayerCutting_Load(object sender, EventArgs e)
        {           
            txtNofParts.Text = "0";
            balFlag = false;
            grpItems.Visible = false;
            lvItems.Visible = false;            
            lvStyle.Visible = false;
            grpFabric.Visible = true;           
            grpFabric.BringToFront();            
            grpStyle.Visible = false;            
            txtItemCode.Text = " ";            
            txtStyleCode.Text = " ";                        
            txtFabInMtr.Text = "0";
            txtPcsToMake.Text = "0";
            balFlag = true;                                  
            Merchandiser();
            txthidSubcatid.Text = "0";
            FillParts();            
            txtOrdQty.Text = "0";
            btnSave.Text = "Save";
            rbColorDepends.Enabled = true;
            rbFixed.Enabled = true;
            txtStyleCode.Focus();
            AvgTot = 0;
        }


       
        private void LoadItem()
        {

            string matcodestr = "";
            string rollstr = "";
            string qtystr = "";
            for (int j = 0; j < dgvItem.Rows.Count; j++)
            {
                matcodestr = matcodestr + dgvItem.Rows[j].Cells["matcode"].Value + ",";
                rollstr = rollstr + dgvItem.Rows[j].Cells["rollnum"].Value + ",";
                qtystr = qtystr + dgvItem.Rows[j].Cells["consumed"].Value + ",";
            }
            if (matcodestr.Trim().Length == 0)
            {
                matcodestr = "0,";
                rollstr = "0,";
                qtystr = "0,";
            }        
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "ShowFabBalInCutting";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@matcodestr", matcodestr);
            sda.SelectCommand.Parameters.AddWithValue("@rollstr", rollstr);
            sda.SelectCommand.Parameters.AddWithValue("@qtystr", qtystr);
            sda.SelectCommand.Parameters.AddWithValue("@ch", txtItemCode.Text.Trim()); 
            DataSet ds = new DataSet();
            sda.Fill(ds);     
            lvItems.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                { 
                lvItems.Items.Add (ds.Tables[0].Rows [i]["rollno"].ToString ());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["matdesc"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["itemcode"].ToString());
                lvItems.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["CuttingBalQty"].ToString());
                }
            }
         }        


        private void lvItems_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedIndices.Count > 0)
            {
                lvItemsClick();
            }
        }

        private void lvItemsClick()
        {
            grpItems.Visible = false;
            lvItems.Visible = false;
            txtFabColor.Text = "";
            txtMaterial.Text = lvItems.SelectedItems[0].SubItems[1].Text;
            txtMatCode.Text = lvItems.SelectedItems[0].SubItems[2].Text;
            txtFabInMtr.Text = lvItems.SelectedItems[0].SubItems[3].Text;
            txtItemCode.Text = lvItems.SelectedItems[0].Text;                                 
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

        private void txtStyleCode_TextChanged(object sender, EventArgs e)
        {
            LoadStyle();
        }

        private void LoadStyle()
        {
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds = new DataSet();
            ds = obj.GetSC (txtStyleCode.Text.Trim ());
            lvStyle.Items.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvStyle.Items.Add(ds.Tables[0].Rows[i]["stylecode"].ToString());
                    lvStyle.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["stylename"].ToString());
                }
            }
            else
            {
                lvStyle.Visible = false;
                grpStyle.Visible = false;
            }
        }

        private void txtStyleCode_KeyDown(object sender, KeyEventArgs e)
        {
            lvStyle .Visible = true;
            grpStyle.Visible = true;
            grpStyle.BringToFront();            
            if (e.KeyCode == Keys.Down)
            {
                if (lvStyle .Items.Count > 0)
                {
                    lvStyle .Focus();
                    lvStyle .Items[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lvStyle .Visible = false;
                grpStyle.Visible = false;
            }
            else if ((e.KeyCode == Keys.Enter) && (lvStyle.Visible == true))
            {
                lvStyle .Focus();
                lvStyle .Items[0].Selected = true;
                lvStyle_Click(sender, e);
                   
            }
        }

        
        private void lvStyleClick()
        {
            lvStyle.Visible = false;
            grpStyle.Visible = false;
            txtStyleCode.Text = lvStyle.SelectedItems[0].Text;
            hidStyleCode = txtStyleCode.Text.Trim();
            FindFromStyle();            
            FillParts();
            LoadSizeRatio(); 
        }



        private void FindSubcatIdFromStyle()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select subcategoryid from tStyleMaster where stylecode=@stcode";
            sda.SelectCommand.CommandText = SqlConstr;
            sda.SelectCommand.Parameters.AddWithValue("@stcode", hidStyleCode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txthidSubcatid.Text = ds.Tables[0].Rows[0]["subcategoryid"].ToString();
            }
            else
            {
                txthidSubcatid.Text = "0";             
            }
        }
        


        private void FindFromStyle()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select subcategoryid,bundleno,WidthSize,PcsPerBundle from tStyleMaster where stylecode=@stcode";
            sda.SelectCommand.CommandText = SqlConstr;
            sda.SelectCommand.Parameters.AddWithValue("@stcode", hidStyleCode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtStartBundleNo.Text = ds.Tables[0].Rows[0]["bundleno"].ToString();
                txtAvgConsumption.Text = ds.Tables[0].Rows[0]["widthsize"].ToString();                
                txtPcsBundle.Text = ds.Tables[0].Rows[0]["pcsperbundle"].ToString();
                txthidSubcatid.Text = ds.Tables[0].Rows[0]["subcategoryid"].ToString();
                
            }
            else
            {
                txtStartBundleNo.Text = "0";
                txtAvgConsumption.Text = "0";                
                txtPcsBundle.Text = "0";
                txthidSubcatid.Text = "0";                
                txtStyleCode.Focus();
            }
        }
                         
        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string rVal = CustomMessageBox .ShowBox();
            if (rVal == "Delete")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    if (this.dgvItem.SelectedRows.Count > 0)
                    {
                        dgvItem.Rows.RemoveAt(this.dgvItem.SelectedRows[0].Index);
                    }
                }
                if (dgvItem.Rows.Count == 0)
                {
                    DisableTxtSr(true);
                }
            }
            else if (rVal == "Edit")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    if (this.dgvItem.SelectedRows.Count > 0)
                    {
                        txtItemCode.Text = dgvItem.Rows[x].Cells["RollNum"].Value.ToString();
                        txtMaterial.Text = dgvItem.Rows[x].Cells["material"].Value.ToString();
                        txtMatCode.Text = dgvItem.Rows[x].Cells["matcode"].Value.ToString();
                        txtFabInMtr.Text = dgvItem.Rows[x].Cells["FabMtr"].Value.ToString();
                        txtOrdQty.Text = dgvItem.Rows[x].Cells["ordqty"].Value.ToString();                       
                        txtPcsToMake.Text = dgvItem.Rows[x].Cells["PCSMAKE"].Value.ToString();
                        txtConsumedFabric.Text = dgvItem.Rows[x].Cells["Consumed"].Value.ToString();
                        txtBalFabric.Text = dgvItem.Rows[x].Cells["BalanceFab"].Value.ToString();  
                        txtExraQty.Text = dgvItem.Rows[x].Cells["ExtraQty"].Value.ToString();
                        txtHidSlno.Text = dgvItem.Rows[x].Cells[0].Value.ToString();
                        btnAdd.Text = "Update " + txtHidSlno.Text;
                        dgvSelectedRatio.Rows.Clear();
                        SizeRatioCalculation();
                    }
                }  
            }            
        }

        private void btnBundle_Click(object sender, EventArgs e)
        {
            btnBundleClick();
            txtTotBundles.Text = lstBundle.Items.Count.ToString ();         
        }

        private void btnBundleClick()
        {
            if (txtStyleCode.Text.Trim().Length != 0)
            {
                if (ChkIsBundleCreation() == 1)
                {
                    startBundleNo = Convert.ToDecimal(txtStartBundleNo.Text);
                    if (rbColorDepends.Checked == true)
                    {
                        AddSameFabricCode();
                        BundleCreation2();
                    }
                    else
                    {
                        BundleCreation();                    
                    }
                }
                else
                {
                    MessageBox.Show("Next Batch  Bundle number has already generated");
                }
            }
            else
            {
                MessageBox.Show("Select a style");
            } 
        }

        private int  ChkIsBundleCreation()
        {
            int ret = 0;
            if (txtLyrBatchNo.Text.Trim().Length != 0)
            {
                ret = Convert.ToInt32(txtHidCanGenBundle.Text);
            }
            else
            {
                ret = 1;
            }
            return ret;
        }

        private void BundleCreation()
        {
            stickerno = 0;
            lstProducts.Items.Clear();
            lstBundle.Items.Clear();
            lstFindSlno.Items.Clear();
            lstBunLetter.Items.Clear();
            lstBunSubSlno.Items.Clear();
            lstBunNoWOLetter.Items.Clear();
            lstFabcolor.Items.Clear();
            lstIntBunNo.Items.Clear();
            lstBunQty.Items.Clear();
            lstBunRange.Items.Clear();
                       
            string ratioLetter = "";
            int ratioValue = 0;
            for (int j = 0; j < dgvSelectedRatio.Rows.Count; j++)
            {
                
                    SubSlno = 0;
                    FQty = 0;
                    ratioLetter = dgvSelectedRatio.Rows[j].Cells[4].Value.ToString();
                    ratioValue = Convert.ToInt32(dgvSelectedRatio.Rows[j].Cells[3].Value);             
                    CalculateQty(ratioValue);                
                    CreateBundle(ratioLetter);                
            }
        }

        private void BundleCreation2()
        {
            stickerno = 0;
            lstProducts.Items.Clear();
            lstBundle.Items.Clear();
            lstFindSlno.Items.Clear();
            lstBunLetter.Items.Clear();
            lstBunSubSlno.Items.Clear();
            lstBunNoWOLetter.Items.Clear();
            lstFabcolor.Items.Clear();
            lstIntBunNo.Items.Clear();
            lstBunQty.Items.Clear();
            lstBunRange.Items.Clear();            
            string ratioLetter = "";
            int ratioValue = 0;
            for (int j = 0; j < dgvSelectedRatio.Rows.Count; j++)
            {
                ratioLetter = dgvSelectedRatio.Rows[j].Cells[4].Value.ToString();
                ratioValue = Convert.ToInt32 ( dgvSelectedRatio.Rows[j].Cells[3].Value);
                SubSlno = 0;                
                CreateBundle2(ratioLetter);               
            }
        }

        private void CalculateQty(int RatioValue)
        {
            int loopStartno = dgvItem.Rows.Count;        
            decimal iqty = 0;
            for (int j = loopStartno; j >= 1; j--)
            {
                iqty = (Convert.ToDecimal(dgvItem.Rows[j - 1].Cells["OrdQty"].Value) / AvgTot )* RatioValue;
                FQty = FQty + iqty;
            }            
        }

        private void CreateBundle(string letter)
        {
                string supcode;
                string locFabColor = "";            
                supcode = "0";
                locFabColor = "Nil";
                decimal y1 = Math.Floor(FQty  / Convert.ToDecimal(txtPcsBundle.Text));
                decimal y2 = FQty  - (y1 * Convert.ToDecimal(txtPcsBundle.Text));
                if (FQty  != 0)
                {
                    decimal i = 0;
                    for (i = 1; i < y1 + 1; i++)
                    {
                        SubSlno = SubSlno + 1;
                        decimal startno = stickerno + 1;
                        decimal endno = stickerno + Convert.ToDecimal(txtPcsBundle.Text);
                        int localstartBundleNo = Convert.ToInt32 ( decimal.Floor(startBundleNo));
                        int localstartno= Convert.ToInt32 ( Math.Floor (startno ));
                        int localendno = Convert.ToInt32 (Math.Floor(endno));
                        lstBundle.Items.Add(letter.ToString ()+"-"+ localstartBundleNo.ToString() + "-" + txtPcsBundle.Text + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                        lstProducts.Items.Add(letter + localstartBundleNo.ToString() + "-" + txtStyleCode.Text.Trim() + "-" + supcode);
                        lstFindSlno.Items.Add("0");
                        lstBunLetter.Items.Add(letter);
                        lstBunNoWOLetter.Items.Add(localstartBundleNo.ToString() + "-" + txtPcsBundle.Text + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                        lstBunSubSlno.Items.Add(SubSlno.ToString());
                        lstFabcolor.Items.Add(locFabColor);
                        lstIntBunNo.Items.Add(localstartBundleNo.ToString());
                        lstBunQty.Items.Add(txtPcsBundle.Text);
                        lstBunRange.Items.Add(localstartno.ToString() + "To" + localendno.ToString());
                        startBundleNo = startBundleNo + 1;
                        stickerno = stickerno + Convert.ToDecimal(txtPcsBundle.Text);
                    }
                    if (y2 != 0)
                    {
                        SubSlno = SubSlno + 1;
                        decimal startno = stickerno+1;
                        decimal endno = stickerno + y2;
                        int localstartno = Convert.ToInt32 (Math.Floor(startno));
                        int localendno = Convert.ToInt32 (Math.Floor(endno));
                        int localy2 = Convert.ToInt32 (Math.Floor(y2));
                        int localstartBundleNo = Convert.ToInt32 (Math.Floor(startBundleNo));
                        lstBundle.Items.Add(letter.ToString ()+"-" + localstartBundleNo.ToString() + "-" + localy2.ToString() + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                        lstProducts.Items.Add(letter + localstartBundleNo.ToString() + "-" + txtStyleCode.Text.Trim () + "-" + supcode);
                        lstFindSlno.Items.Add("0");
                        lstBunLetter.Items.Add(letter);
                        lstBunNoWOLetter.Items.Add(localstartBundleNo.ToString() + "-" + localy2.ToString() + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                        lstBunSubSlno.Items.Add(SubSlno.ToString());
                        lstFabcolor.Items.Add(locFabColor);
                        lstIntBunNo.Items.Add(localstartBundleNo.ToString());
                        lstBunQty.Items.Add(localy2.ToString());
                        lstBunRange.Items.Add(localstartno.ToString() + "To" + localendno.ToString());
                        startBundleNo = startBundleNo + 1;
                        stickerno = stickerno + y2;
                    }               
            }
        }

        private string  FindSize(string no)
        {
            string ActualSize = "";
            for (int i = 0; i < dgvAllRatio.Rows.Count; i++)
            {
                if ((Convert.ToInt32(dgvAllRatio.Rows[i].Cells[1].Value) != 0) && (dgvAllRatio.Rows[i].Cells[1].Value) != null)
                {
                if(dgvAllRatio.Rows[i].Cells[0].Value.ToString() == no)
                {
                    ActualSize = dgvAllRatio.Rows[i].Cells[2].Value.ToString();                   
                }
                }

            }
            return ActualSize;
        }

        private void CreateBundle2(string letter)
        {
            int loopStartno = dgvDuplicate.Rows.Count;
            decimal qty = 0;            
            string locFabColor = "";
            for (int j = loopStartno; j >= 1; j--)
            {
                string letrNo = dgvDuplicate.Rows[j - 1].Cells[2].Value.ToString().Trim();
                string ActualSize = FindSize(letrNo);
                if (ActualSize.Trim() == letter.Trim())
                {
                    qty = Convert.ToDecimal(dgvDuplicate.Rows[j - 1].Cells[3].Value);
                    decimal y1 = Math.Floor(qty / Convert.ToDecimal(txtPcsBundle.Text));
                    decimal y2 = qty - (y1 * Convert.ToDecimal(txtPcsBundle.Text));
                    if (qty != 0)
                    {
                        decimal i = 0;
                        for (i = 1; i < y1 + 1; i++)
                        {
                            SubSlno = SubSlno + 1;
                            decimal startno = stickerno + 1;
                            decimal endno = stickerno + Convert.ToDecimal(txtPcsBundle.Text);
                            int localstartBundleNo = Convert.ToInt32(decimal.Floor(startBundleNo));
                            int localstartno = Convert.ToInt32(Math.Floor(startno));
                            int localendno = Convert.ToInt32(Math.Floor(endno));
                            lstBundle.Items.Add(letter.ToString ()+"-"+ localstartBundleNo.ToString() + "-" + txtPcsBundle.Text + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                            lstProducts.Items.Add(letter + localstartBundleNo.ToString() + "-" + txtStyleCode.Text.Trim () );
                            lstFindSlno.Items.Add(j.ToString());
                            lstBunLetter.Items.Add(letter);
                            lstBunNoWOLetter.Items.Add(localstartBundleNo.ToString() + "-" + txtPcsBundle.Text + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                            lstBunSubSlno.Items.Add(SubSlno.ToString());
                            lstFabcolor.Items.Add(locFabColor);
                            lstIntBunNo.Items.Add(localstartBundleNo.ToString());
                            lstBunQty.Items.Add(txtPcsBundle.Text);
                            lstBunRange.Items.Add(localstartno.ToString() + "To" + localendno.ToString());
                            startBundleNo = startBundleNo + 1;
                            stickerno = stickerno + Convert.ToDecimal(txtPcsBundle.Text);
                        }
                        if (y2 != 0)
                        {
                            SubSlno = SubSlno + 1;
                            decimal startno = stickerno + 1;
                            decimal endno = stickerno + y2;
                            int localstartno = Convert.ToInt32(Math.Floor(startno));
                            int localendno = Convert.ToInt32(Math.Floor(endno));
                            int localy2 = Convert.ToInt32(Math.Floor(y2));
                            int localstartBundleNo = Convert.ToInt32(Math.Floor(startBundleNo));
                            lstBundle.Items.Add(letter.ToString ()+"-"+ localstartBundleNo.ToString() + "-" + localy2.ToString() + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                            lstProducts.Items.Add(letter + localstartBundleNo.ToString() + "-" + txtStyleCode.Text.Trim () );
                            lstFindSlno.Items.Add(j.ToString());
                            lstBunLetter.Items.Add(letter);
                            lstBunNoWOLetter.Items.Add(localstartBundleNo.ToString() + "-" + localy2.ToString() + "(" + localstartno.ToString() + "To" + localendno.ToString() + ")");
                            lstBunSubSlno.Items.Add(SubSlno.ToString());
                            lstFabcolor.Items.Add(locFabColor);
                            lstIntBunNo.Items.Add(localstartBundleNo.ToString());
                            lstBunQty.Items.Add(localy2.ToString());
                            lstBunRange.Items.Add(localstartno.ToString() + "To" + localendno.ToString());
                            startBundleNo = startBundleNo + 1;
                            stickerno = stickerno + y2;
                        }
                    }
                }
            }
        }
             

        private void txtStyleCode_TextChanged_1(object sender, EventArgs e)
        {
            LoadStyle();
        }

        

        private void txtStyleCode_KeyDown_1(object sender, KeyEventArgs e)
        {
            lvStyle.Visible = true;
            grpStyle.Visible = true;
            grpStyle.BringToFront();
            if (e.KeyCode == Keys.Down)
            {
                if (lvStyle.Items.Count > 0)
                {
                    lvStyle.Focus();
                    lvStyle.Items[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lvStyle.Visible = false; 
                grpStyle.Visible = false;
            }
            else if ((e.KeyCode == Keys.Enter) && (lvStyle.Visible == true))
            {
                lvStyle.Focus();
                if (lvStyle.SelectedItems.Count != 0)
                {
                    lvStyle.Items[0].Selected = true;
                    lvStyle_Click(sender, e);
                }
                else
                {
                    lvStyle.Visible = false;
                    grpStyle.Visible = false;
                    if (txtStyleCode.Text.Trim().Length != 0)
                    {
                        hidStyleCode  = txtStyleCode.Text.Trim();
                        FindFromStyle();
                        FillParts();
                        LoadSizeRatio(); 
                    }
                }
            }
        }              
       

        private void lvStyle_Click(object sender, EventArgs e)
        {
            lvStyleClick();
        }

        private void lvStyle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lvStyle.Items.Count > 0)
                {
                    lvStyleClick();
                }
            }
        }

        
        private void  SizeRatioCalculation()
        {
            AvgTot = 0;               
            for (int i = 0; i < dgvAllRatio.Rows.Count; i++)
            {
                if ((Convert.ToInt32(dgvAllRatio.Rows[i].Cells[1].Value) != 0)&& (dgvAllRatio.Rows[i].Cells[1].Value) != null )
                {
                    AvgTot = AvgTot + Convert.ToInt32(dgvAllRatio.Rows[i].Cells[1].Value);
                }
                 
            }
            
            TotOrdQty = Convert.ToDecimal (txtOrdQty.Text);
            if (AvgTot != 0)
            {
                decimal avg = TotOrdQty / AvgTot;
                decimal avg1 = decimal.Floor(avg);
                if (avg != avg1)
                {
                    MessageBox.Show("Ratio can  not generate proper propotion because of Order Qty");
                }
                else
                {
                  
                    int num = 0;
                    for (int i = 0; i < dgvAllRatio.Rows.Count; i++)
                    {
                        if ((Convert.ToInt32(dgvAllRatio.Rows[i].Cells[1].Value) != 0) && (dgvAllRatio.Rows[i].Cells[1].Value) != null)
                        {
                            dgvSelectedRatio.Rows.Add(1);
                            num = dgvSelectedRatio.Rows.Count;
                            dgvSelectedRatio.Rows[num - 1].Cells[0].Value = dgvAllRatio.Rows[i].Cells[0].Value;
                            dgvSelectedRatio.Rows[num - 1].Cells[1].Value = (Convert.ToInt32 ( dgvAllRatio.Rows[i].Cells[1].Value) * avg).ToString () ;
                            dgvSelectedRatio.Rows[num - 1].Cells[3].Value = dgvAllRatio.Rows[i].Cells[1].Value;
                            dgvSelectedRatio.Rows[num - 1].Cells[4].Value = dgvAllRatio.Rows[i].Cells[2].Value;
                        }
                    }
               }
            }                   
        }
        
       

        private void Balfabric()
        {
            if (balFlag == true)
            {
                if (txtPcsToMake.Text.Trim().Length != 0 && txtFabInMtr.Text.Trim ().Length !=0)
                {
                txtPcsToMake.Text = (Convert.ToDecimal(txtFabInMtr.Text) / Convert.ToDecimal(txtAvgConsumption.Text)).ToString();                
                decimal x = Convert.ToDecimal(txtFabInMtr.Text);
                decimal y = Convert.ToDecimal(txtOrdQty.Text);
                decimal z = Convert.ToDecimal(txtAvgConsumption.Text);
                txtBalFabric.Text = (x - (y * z)).ToString();
                txtConsumedFabric.Text = (y * z).ToString();            
                }
            }
        }        

       

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            LoadItem();
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
       {
           grpItems.Visible = true;
            lvItems.Visible = true;
            
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
                grpItems.Visible = false;
                lvItems.Visible = false;
                
            }
            else if ((e.KeyCode == Keys.Enter) && (lvItems.Visible == true))
            {
                lvItems.Focus();
                lvItems.Items[0].Selected = true;
                lvItems_Click(sender, e);

            }
        }

        private void txtFabInMtr_TextChanged(object sender, EventArgs e)
        {
            Balfabric();
        }

        private void btnRatio_Click(object sender, EventArgs e)
        {
            dgvSelectedRatio.Rows.Clear();
            if (txtOrdQty.Text.Length != 0)
            {                
                SizeRatioCalculation();
                Balfabric();                
            }
        }

       
        private bool  OrderChk()
        {
            dgvOrderChk.Rows.Clear();
            bool ret = true;
            if (dgvItem.Rows.Count > 0)
            {
                string frstcode = dgvItem.Rows[0].Cells["RollNum"].Value.ToString();
                string scndcode = "";
                int y = 0;
                int frstStart = 1;
                int i = 1;
                int pos = 0;
                for (i = 1; i < dgvItem.Rows.Count+1; i++)
                {
                    scndcode = dgvItem.Rows[i - 1].Cells["RollNum"].Value.ToString();
                    if (frstcode == scndcode)
                    {
                        y = y + 1;
                        if (i == dgvItem.Rows.Count)
                        {
                            dgvOrderChk.Rows.Add(1);
                            pos = dgvOrderChk.Rows.Count;
                            dgvOrderChk.Rows[pos-1].Cells[0].Value = frstcode;
                            dgvOrderChk.Rows[pos - 1].Cells[1].Value = frstStart.ToString();
                            dgvOrderChk.Rows[pos - 1].Cells[2].Value = i.ToString();
                            dgvOrderChk.Rows[pos - 1].Cells[3].Value = y.ToString();
                            frstStart = i;
                            y = 1;
                        }
                    }
                    else
                    {
                        int j = i;
                        dgvOrderChk.Rows.Add(1);
                        pos = dgvOrderChk.Rows.Count;
                        dgvOrderChk.Rows[pos - 1].Cells[0].Value = frstcode;
                        dgvOrderChk.Rows[pos - 1].Cells[1].Value = frstStart.ToString();
                        dgvOrderChk.Rows[pos - 1].Cells[2].Value = (i-1).ToString();
                        dgvOrderChk.Rows[pos - 1].Cells[3].Value = y.ToString();
                        frstStart = i;
                        y = 1;
                        frstcode = scndcode;
                        if (j == dgvItem.Rows.Count)
                        {
                            dgvOrderChk.Rows.Add(1);
                            pos = dgvOrderChk.Rows.Count;
                            dgvOrderChk.Rows[pos - 1].Cells[0].Value = scndcode;
                            dgvOrderChk.Rows[pos - 1].Cells[1].Value = j.ToString();
                            dgvOrderChk.Rows[pos - 1].Cells[2].Value = j.ToString();
                            dgvOrderChk.Rows[pos - 1].Cells[3].Value = "1";                            
                        }
        
                    }
                }

                if (btnAdd.Text == "Add")
                {
                    for (int j = 0; j < dgvOrderChk.Rows.Count; j++)
                    {
                        if (dgvOrderChk.Rows[j].Cells[0].Value.ToString() == txtItemCode.Text)
                        {
                            dgvOrderChk.Rows[j].Cells[2].Value = (dgvItem.Rows.Count + 1);
                            dgvOrderChk.Rows[j].Cells[3].Value = (Convert.ToInt32(dgvOrderChk.Rows[j].Cells[3].Value) + 1).ToString();
                        }
                    }


                    for (int j = 0; j < dgvOrderChk.Rows.Count; j++)
                    {
                        int st = Convert.ToInt32(dgvOrderChk.Rows[j].Cells[1].Value);
                        int end = Convert.ToInt32(dgvOrderChk.Rows[j].Cells[2].Value);
                        int cnt = Convert.ToInt32(dgvOrderChk.Rows[j].Cells[3].Value);
                        if (cnt != ((end - st) + 1))
                        {
                            ret = false;
                        }
                    }

                }
                else
                {
                    for (int j = 0; j < dgvOrderChk.Rows.Count; j++)
                    {
                        if (dgvOrderChk.Rows[j].Cells[0].Value.ToString() == txtItemCode.Text)
                        {
                            int modvalSt= Convert.ToInt32 ( dgvOrderChk.Rows[j].Cells[1].Value );
                            int modvalEnd = Convert.ToInt32(dgvOrderChk.Rows[j].Cells[2].Value);
                           int  x = Convert.ToInt32(txtHidSlno.Text);
                            if (x >= modvalSt - 1 && x <= modvalEnd + 1)
                            {

                            }
                            else
                            {
                                ret = false;
                            }
                        }
                    }                
                }
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        private void dupInitialize()
        {
            for (int j = 0; j <= dgvSelectedRatio.Rows.Count-1; j++)
            {
                dgvSelectedRatio.Rows[j].Cells[2].Value = "0";                          
            }
            
        }

        private void Assign1()
        {
            int pos=0;      
            for (int j = 0; j <= dgvSelectedRatio.Rows.Count-1; j++)
            {
                dgvDuplicate.Rows.Add(1);
                pos = dgvDuplicate.Rows.Count;                            
                dgvDuplicate.Rows[pos - 1].Cells["dupItemCode"].Value = currentFabcode;
                dgvDuplicate.Rows[pos - 1].Cells["colRatioName"].Value = dgvSelectedRatio.Rows[j].Cells["Ratiocode"].Value;             
                dgvDuplicate.Rows[pos - 1].Cells["ColDupQty"].Value = dgvSelectedRatio.Rows[j].Cells[2].Value;                
            }
            
        }

        private void Assign2(int i)
        {
            for (int j = 0; j <= dgvSelectedRatio.Rows.Count-1; j++)
            {
                dgvSelectedRatio.Rows[j].Cells[2].Value = Convert.ToInt32 ( dgvSelectedRatio.Rows[j].Cells[2].Value) + ((Convert.ToDecimal(dgvItem.Rows[i - 1].Cells["OrdQty"].Value) / AvgTot) * Convert.ToInt32 ( dgvSelectedRatio.Rows[j].Cells[3].Value));          
                         
            }
        }

        

        private void AddSameFabricCode()
        {
            dgvDuplicate .Rows.Clear();
            if (dgvItem.Rows.Count > 0)
            {
                frstcode = dgvItem.Rows[0].Cells["RollNum"].Value.ToString();
                frstsupcode = dgvItem.Rows[0].Cells["matcode"].Value.ToString();
                frstFabColor = dgvItem.Rows[0].Cells["FabColor"].Value.ToString();
                scndcode = "";
                scndsupcode = "";
                scndFabColor = "";
                int i = 1;
                dupInitialize();
                for (i = 1; i < dgvItem.Rows.Count + 1; i++)
                {
                    scndcode = dgvItem.Rows[i - 1].Cells["RollNum"].Value.ToString();
                    scndsupcode = dgvItem.Rows[i-1].Cells["matcode"].Value.ToString();
                    scndFabColor = dgvItem.Rows[i - 1].Cells["FabColor"].Value.ToString();
                    if (frstcode == scndcode)
                    {
                        if (i == dgvItem.Rows.Count)
                        {
                            currentFabcode = dgvItem.Rows[i - 1].Cells["RollNum"].Value.ToString();
                            currentSupcode = dgvItem.Rows[i - 1].Cells["matcode"].Value.ToString();
                            currentFabColor = dgvItem.Rows[i - 1].Cells["FabColor"].Value.ToString(); 
                            Assign2(i);
                            Assign1();                                                    
                        }
                        else
                        {
                            Assign2(i);
                        }
                    }
                    else
                    {
                        currentFabcode = frstcode;
                        currentSupcode = frstsupcode;
                        currentFabColor = frstFabColor;
                        Assign1();            
                        frstcode = scndcode;
                        frstsupcode = scndsupcode;
                        frstFabColor = scndFabColor;
                        dupInitialize();
                        if (i == dgvItem.Rows.Count)
                        {
                            currentFabcode = frstcode;
                            currentSupcode = frstsupcode;
                            currentFabColor = frstFabColor;                           
                            Assign2(i);
                            Assign1();
                        }
                        else
                        {
                            Assign2(i);
                        }
                    }
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
                if (ChkIsBundleCreation() == 1)
                {
                    if (txtItemCode.Text.Trim().Length != 0)
                    {
                        if(rbColorDepends .Checked == true )
                        {
                            if (OrderChk() == true)
                            {         
                                AddToDgvItems();
                                calculateTotal();
                                DisableTxtSr(false);
                            }
                            else
                            {
                                MessageBox.Show("not in Order");
                            }
                        }
                        else
                        {
                            AddToDgvItems();
                            calculateTotal();
                            DisableTxtSr(false);                        
                        }
                    }
                    else
                    {
                        MessageBox.Show ("Not allowed empty itemcode");
                    }
                }
                else
                {
                    MessageBox.Show("Next Batch  Bundle number has already generated");
                }
        }
            
        

        private void AddToDgvItems()
        {
            int x = 0;
            if (btnAdd.Text == "Add")
            {
                dgvItem.Rows.Add(1);
                x = dgvItem.Rows.Count;
            }
            else
            {
                x = Convert.ToInt32(txtHidSlno.Text);
                btnAdd.Text = "Add";
            }
            dgvItem.Rows[x - 1].Cells["slno"].Value = x.ToString();
            dgvItem.Rows[x - 1].Cells["RollNum"].Value = txtItemCode.Text;
            dgvItem.Rows[x - 1].Cells["material"].Value = txtMaterial.Text;
            dgvItem.Rows[x - 1].Cells["FabColor"].Value = txtFabColor.Text;
            dgvItem.Rows[x - 1].Cells["FabMtr"].Value = txtFabInMtr.Text;
            dgvItem.Rows[x - 1].Cells["ordqty"].Value = txtOrdQty.Text;           
            dgvItem.Rows[x - 1].Cells["PCSMAKE"].Value = txtPcsToMake.Text;
            dgvItem.Rows[x - 1].Cells["Consumed"].Value = txtConsumedFabric.Text;
            dgvItem.Rows[x - 1].Cells["BalanceFab"].Value = txtBalFabric.Text;                  
            dgvItem.Rows[x - 1].Cells["matcode"].Value = txtMatCode.Text ;            
            dgvItem.Rows[x - 1].Cells["ExtraQty"].Value = txtExraQty.Text;                    
        }

        private void Merchandiser()
        {
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds1 = new DataSet();
            cmbMerch.DataSource  = obj.sMerchandiser().Tables[0];
            cmbMerch.DisplayMember = "employeename";
            cmbMerch.ValueMember = "empid";
            cmbQC.DataSource = obj.sQC().Tables[0];
            cmbQC.DisplayMember = "employeename";
            cmbQC.ValueMember = "empid";
            cmbLMaster.DataSource = obj.sCutting().Tables[0];
            cmbLMaster.DisplayMember = "employeename";
            cmbLMaster.ValueMember = "empid";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tStyleMaster set Lotno=Lotno+1 where stylecode=@sc";
            scmd.Parameters.AddWithValue("@sc", txtStyleCode.Text.Trim () );
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
            scmd.CommandText = "select lotno from tStyleMaster  where stylecode=@sc";
            scmd.Parameters.AddWithValue("@sc", txtStyleCode.Text.Trim());
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void DelBundleParts()
        { 
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete from tLayerCutParts  where LayerBatchNo=@lbno and stylecode =@stcode";
            scmd.Parameters.AddWithValue("@lbno",  Convert.ToInt32 (txtLyrBatchNo.Text));
            scmd.Parameters.AddWithValue("@stcode", txtStyleCode.Text.Trim ());
            int i = scmd.ExecuteNonQuery();
            sc.Close();

        }

        private void InsertBundleParts()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            for (int k = 0; k < dgvParts.Rows.Count; k++)
            {
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.Parameters.Clear();
                scmd.CommandText = "insert into tLayerCutParts(LayerBatchNo,cutdate,slno,partsname,partscode,stylecode) values(@LayerBatchNo,@cutdate,@slno,@partsname,@partscode,@stcode)";
                scmd.Parameters.AddWithValue("@LayerBatchNo", Convert.ToInt32(txtLyrBatchNo.Text));
                scmd.Parameters.AddWithValue("@cutdate", dtpLyrDate.Value );
                scmd.Parameters.AddWithValue("@slno", k+1);
                scmd.Parameters.AddWithValue("@partsname",dgvParts.Rows [k].Cells [1].Value .ToString ());
                scmd.Parameters.AddWithValue("@partscode", dgvParts.Rows[k].Cells[0].Value);
                scmd.Parameters.AddWithValue("@stcode", txtStyleCode.Text.Trim() );                
                int i = scmd.ExecuteNonQuery();
            }
            sc.Close();        
        }

        private void RatioDelete()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.Parameters.Clear();
                scmd.CommandText = "delete tLayerCutFabRatio  where stylecode=@stylecode and LayerBatchNo=@LayerBatchNo";
                scmd.Parameters.AddWithValue("@stylecode", txtStyleCode.Text.Trim());
                scmd.Parameters.AddWithValue("@LayerBatchNo", Convert.ToInt32(txtLyrBatchNo.Text));
                int i = scmd.ExecuteNonQuery();            
            sc.Close();
        }



        private void RatioSave()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            for (int k = 0; k < dgvSelectedRatio.Rows.Count; k++)
            {
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.Parameters.Clear();
                scmd.CommandText = "insert tLayerCutFabRatio (stylecode ,LayerBatchNo,subslno,sizecode,RatioValue,size ) values(@stylecode ,@LayerBatchNo,@subslno,@sizecode,@RatioValue,@size)";
                scmd.Parameters.AddWithValue("@stylecode", txtStyleCode.Text.Trim());
                scmd.Parameters.AddWithValue("@LayerBatchNo", Convert.ToInt32(txtLyrBatchNo.Text));
                scmd.Parameters.AddWithValue("@subslno", k);               
                scmd.Parameters.AddWithValue("@sizecode", dgvSelectedRatio.Rows[k].Cells[0].Value.ToString());
                scmd.Parameters.AddWithValue("@RatioValue", dgvSelectedRatio.Rows[k].Cells[3].Value);
                scmd.Parameters.AddWithValue("@size", dgvSelectedRatio.Rows[k].Cells["colSelSize"].Value);
                int i = scmd.ExecuteNonQuery();
            }
            sc.Close();
        }

        private void AdjustfabCutting(string Operation)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "AdjustfabCutting";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@stylecode", txtStyleCode.Text.Trim());
            scmd.Parameters.AddWithValue("@LayerBatchNo", Convert.ToInt32(txtLyrBatchNo.Text));
            scmd.Parameters.AddWithValue("@operation", Operation);
            int i = scmd.ExecuteNonQuery();            
        }



        private void btnSave_Click(object sender, EventArgs e)
        {   
            if (txtStyleCode.Text.Trim().Length != 0 && dgvParts.Rows.Count !=0)
            {
                if (btnSave.Text == "Save")
                {
                    if (dgvItem.Rows.Count != 0)
                    {
                        txtLyrBatchNo.Text = ReadLastNum().ToString ();
                        txtHidCanGenBundle.Text = "1";
                        SaveLayCutHD();
                        SaveLayCutDTL();
                        DelBundleParts();
                        InsertBundleParts();
                        RatioSave();
                        AdjustfabCutting("ADD");
                    }
                    if (lstBundle.Items.Count != 0)
                    {
                        SaveLayCutBundle();
                        SaveLastBundleNumber();
                        UpdateBundleStatus();
                        SetStartEndBundleNo();
                        CreateBundleActivites();
                    }
                    btnSave.Enabled = false;
                }
                else
                {
                    
                    if (ChkIsBundleCreation() == 1)
                    {
                        if (dgvItem.Rows.Count != 0)
                        {
                            AdjustfabCutting("REVERSE");
                            UpdateLayCutHD();
                            DelLayCutDTL();
                            SaveLayCutDTL();
                            DelBundleParts();
                            InsertBundleParts();
                            RatioDelete();
                            RatioSave();
                            AdjustfabCutting("ADD");
                        }
                        if (lstBundle.Items.Count != 0)
                        {
                            DelLauCutBundle();
                            SaveLayCutBundle();
                            SaveLastBundleNumber();
                            UpdateBundleStatus();
                            SetStartEndBundleNo();
                            CreateBundleActivites();
                        }
                        btnSave.Enabled = false;
                    }
                }
            }
            else
            {
               if( txtStyleCode.Text.Trim().Length == 0 )
               {
               MessageBox.Show("Please Enter Style Code");
               }
               else if (dgvParts.Rows.Count == 0)
               {
                   MessageBox.Show("Please Add  Parts");               
               }                
            }
        }

        private void CreateBundleActivites()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "ilaycutbunact";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@lbno",Convert.ToInt32 (txtLyrBatchNo.Text));
            scmd.Parameters.AddWithValue("@stcode",txtStyleCode.Text.Trim() );            
            int i = scmd.ExecuteNonQuery();
            sc.Close();        
        }

        private void UpdateLayCutHD()
        {
            clsLayerCutting obj = new clsLayerCutting();
            obj.compcode = 1;
            obj.loccode = 1;
            obj.LayerBatchNo = Convert.ToInt32(txtLyrBatchNo.Text);
            obj.CutDate = dtpLyrDate.Value;
            obj.JobOrderNo = txtJobOrder.Text;
            obj.StyleCode = txtStyleCode.Text.Trim();
            obj.AVGConsumption = Convert.ToDecimal(txtAvgConsumption.Text);
            obj.PCSPerBundle = Convert.ToInt32(txtPcsBundle.Text);
            obj.MerchandiserCode = Convert.ToInt32(cmbMerch.SelectedValue.ToString());
            obj.CuttingMasterCode = Convert.ToInt32(cmbLMaster.SelectedValue.ToString());
            obj.QCHeadCode = Convert.ToInt32(cmbQC.SelectedValue.ToString());
            obj.BundleStartNo = Convert.ToInt32(txtStartBundleNo.Text );
            if (startBundleNo == 0)
            {
                obj.BundleEndNo = 0;
            }
            else
            {
                obj.BundleEndNo = startBundleNo -1;
            }
            obj.modifiedby = 1;
            obj.modifiedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            obj.TransferFlag = "N";
            obj.DeletedSataus = "N";
            obj.UpdateLayCutHD();
        }

        private void DelLayCutDTL()
        {
            clsLayerCutting obj = new clsLayerCutting();
            obj.DelLayDTL(Convert.ToInt32(txtLyrBatchNo.Text), txtStyleCode.Text.Trim());
        }

        private void DelLauCutBundle()
        {
            clsLayerCutting obj = new clsLayerCutting();
            obj.DelLayBundle(Convert.ToInt32(txtLyrBatchNo.Text), txtStyleCode.Text.Trim());
        }

        private void UpdateBundleStatus()
        {
            clsLayerCutting obj = new clsLayerCutting();
            obj.UpdateBundleFlagStatus (Convert.ToInt32 (txtLyrBatchNo.Text),txtStyleCode.Text.Trim ());
        }

        private void SaveLastBundleNumber()
        {
            clsLayerCutting obj = new clsLayerCutting();
            decimal EndNumberAlso = startBundleNo;
            string serCode = txtStyleCode.Text.Trim();
            obj.UpdateLastBundleNumber(EndNumberAlso,serCode);        
        }

        private void SaveLayCutHD()
        {
            clsLayerCutting obj = new clsLayerCutting();
            obj.compcode = 1;
            obj.loccode = 1;
            obj.LayerBatchNo = Convert.ToInt32(txtLyrBatchNo.Text);
            if (rbFixed.Checked == true)
            {
                obj.BunNoMethod = "fxd";
            }
            else
            {
                obj.BunNoMethod = "clr";
            }
            obj.CutDate = Convert.ToDateTime ( dtpLyrDate.Value.ToShortDateString ());
            obj.JobOrderNo = txtJobOrder.Text;
            obj.StyleCode = txtStyleCode.Text.Trim ();
            obj.AVGConsumption = Convert.ToDecimal(txtAvgConsumption.Text);
            obj.PCSPerBundle = Convert.ToInt32(txtPcsBundle.Text);
            obj.MerchandiserCode = Convert.ToInt32(cmbMerch.SelectedValue.ToString());
            obj.CuttingMasterCode = Convert.ToInt32(cmbLMaster.SelectedValue.ToString());
            obj.QCHeadCode = Convert.ToInt32(cmbQC.SelectedValue.ToString());
            obj.BundleStartNo = Convert.ToInt32(txtStartBundleNo.Text );
            if (startBundleNo == 0)
            {
                obj.BundleEndNo = 0;
            }
            else
            {
                obj.BundleEndNo = startBundleNo - 1;
            }
           
            obj.createdby = 1;
            obj.modifiedby = 1;
            obj.createdDate = Convert.ToDateTime ( DateTime.Now.ToShortDateString ());
            obj.modifiedDate =Convert.ToDateTime ( DateTime.Now.ToShortDateString());
            obj.TransferFlag = "N";
            obj.DeletedSataus = "N";
            obj.CanGenerateBundle = 1;
            obj.BundleCreated = 0;
            obj.InsertLayCutHD();
        }

        private void SaveLayCutDTL()
        {
            clsLayerCutting obj = new clsLayerCutting();                
            int  loopEndNo = dgvItem.Rows.Count;
            for (int x = 1; x <= loopEndNo; x++)
            {
                obj.compcode = 1;
                obj.loccode = 1;
                obj.LayerBatchNo = Convert.ToInt32 (txtLyrBatchNo.Text);
                obj.CutDate =  Convert.ToDateTime(dtpLyrDate.Value.ToShortDateString());
                obj.SlNo = Convert.ToInt32 ( dgvItem.Rows[x - 1].Cells["slno"].Value);
                obj.RollNumber = dgvItem.Rows[x - 1].Cells["RollNum"].Value.ToString();
                obj.FabricCode  = Convert.ToInt32 ( dgvItem.Rows[x - 1].Cells["matcode"].Value);
                obj.FabColor = dgvItem.Rows[x - 1].Cells["FabColor"].Value.ToString();
                obj.FabricInMTR = Convert.ToDecimal (dgvItem.Rows[x - 1].Cells["FabMtr"].Value);
                obj.PcsToMake= Convert.ToDecimal ( dgvItem.Rows[x - 1].Cells["PCSMAKE"].Value);
                obj.OrdQty = Convert.ToDecimal  ( dgvItem.Rows[x - 1].Cells["ordqty"].Value);   
                obj.ConsumedFabric =Convert.ToDecimal ( dgvItem.Rows[x - 1].Cells["Consumed"].Value);
                obj.BalanceFabric = Convert.ToDecimal ( dgvItem.Rows[x - 1].Cells["BalanceFab"].Value);                                  
                obj.createdby = 1;
                obj.modifiedby = 1;
                obj.createdDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                obj.modifiedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                obj.TransferFlag = "N";
                obj.StyleCode = txtStyleCode.Text.Trim ();
                obj.InsertLayCutDTL();
            }

        }

        private void SaveLayCutBundle()
        {
            clsLayerCutting obj = new clsLayerCutting();                
            for (int j = 1; j <=lstBundle.Items.Count  ; j++)
            {
                obj.compcode = 1;
                obj.loccode = 1;
                obj.LayerBatchNo = Convert.ToInt32(txtLyrBatchNo.Text);
                obj.CutDate = Convert.ToDateTime(dtpLyrDate.Value.ToShortDateString());
                obj.DTLSlno = Convert.ToInt32 ( lstFindSlno.Items[j-1].ToString());
                obj.BunSubSlno = Convert.ToInt32 (lstBunSubSlno.Items[j - 1].ToString()); 
                obj.BunLetter = lstBunLetter.Items[j - 1].ToString();
                obj.BunNoWoletter = lstBunNoWOLetter.Items[j - 1].ToString();
                obj.BundleSlno = j;
                obj.BundleNo = lstBundle.Items[j-1].ToString();
                obj.ProductNo = " ";
                obj.StyleCode = txtStyleCode.Text.Trim();
                obj.FabColor = lstFabcolor.Items[j - 1].ToString(); 
                obj.bunIntNo =  Convert.ToInt32(lstIntBunNo.Items[j - 1].ToString());
                obj.bunQty = Convert.ToInt32(lstBunQty.Items[j - 1].ToString());
                obj.bunRange = lstBunRange.Items[j - 1].ToString();
                obj.createdby = 1;
                obj.modifiedby = 1;
                obj.createdDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                obj.modifiedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                obj.TransferFlag = "N";
                obj.InsertLayCutBundle();
            }
        }

       
       
        private void btnFindShow_Click(object sender, EventArgs e)
        {
            clsLayerCutting obj = new clsLayerCutting();
            dgvFindShow.DataSource = obj.GetLayerInfo().Tables [0];
            dgvFindShow.Columns[0].Width = 140;
        }

        private void LoadRatioForEdit()
        {
            dgvSelectedRatio.Rows.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select SizeCode,RatioValue from tLayerCutFabRatio where stylecode = @stylecode and LayerBatchNo = @LayerBatchNo order by sizecode";
            sda.SelectCommand.Parameters.AddWithValue("@stylecode",txtStyleCode.Text.Trim());
            sda.SelectCommand.Parameters.AddWithValue("@LayerBatchNo",txtLyrBatchNo.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            string tabRatValue = "";
            string dgvRatValue = "";
            int num = 0;
            AvgTot = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int x = 0; x < dgvAllRatio.Rows.Count; x++)
                {
                    tabRatValue = ds.Tables[0].Rows[i]["SizeCode"].ToString();
                    dgvRatValue = dgvAllRatio.Rows[x].Cells[0].Value.ToString();
                    if (tabRatValue == dgvRatValue)
                    {
                        dgvAllRatio.Rows[x].Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();
                    }
                }
            }
            for (int x = 0; x < dgvAllRatio.Rows.Count; x++)
            {
                if ((Convert.ToInt32(dgvAllRatio.Rows[x].Cells[1].Value) != 0) && (dgvAllRatio.Rows[x].Cells[1].Value) != null)
                {
                    dgvSelectedRatio.Rows.Add(1);
                    num = dgvSelectedRatio.Rows.Count;
                    dgvSelectedRatio.Rows[num - 1].Cells[0].Value = dgvAllRatio.Rows[x].Cells[0].Value;
                    dgvSelectedRatio.Rows[num - 1].Cells[3].Value = dgvAllRatio.Rows[x].Cells[1].Value;
                    dgvSelectedRatio.Rows[num - 1].Cells[4].Value = dgvAllRatio.Rows[x].Cells[2].Value;
                    AvgTot = AvgTot + Convert.ToInt32(dgvAllRatio.Rows[x].Cells[1].Value);
                }
            }
        }

        private void dgvFindShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex;
            if (x != -1)
            {
                if (this.dgvFindShow.Rows.Count > 0)
                {
                    if (this.dgvFindShow.SelectedRows.Count > 0)
                    {
                        int y = Convert.ToInt32(dgvFindShow.Rows[x].Cells[1].Value.ToString());
                        string scy = dgvFindShow.Rows[x].Cells[0].Value.ToString();                        
                        LoadAndFillHDData(y, scy);
                        LoadSizeRatio();
                        GetLayDTLData(y, scy);
                        GetLayBundleData(y, scy);
                        FindSubcatIdFromStyle();
                        LoadRatioForEdit();
                        int num = FillParts();
                        LoadPartsInForm(num, y, scy);
                        tabControl1.SelectedTab = tabPage3;
                        tabControl1.SelectedTab = tabPage1;
                        txtTotBundles.Text = lstBundle.Items.Count.ToString();
                        int p = dgvItem.Rows.Count;
                        calculateTotal();                        
                    }
                }
            }
            
         }


        private void LoadPartsInForm(Int32  num, Int32  LayerBatchNo, string StyleNo)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select partscode from tLayerCutParts where LayerBatchNo=@lbno  and StyleCode=@sc";
            sda.SelectCommand.CommandText = SqlConstr;
            sda.SelectCommand.Parameters.AddWithValue("@lbno", LayerBatchNo);
            sda.SelectCommand.Parameters.AddWithValue("@sc", StyleNo);
            DataSet ds = new DataSet();
            sda.Fill(ds);            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (lstParts .Items[j].Text == ds.Tables[0].Rows[i]["partscode"].ToString())
                    {
                        lstParts.Items[j].Checked = true;
                        j = num;
                    }
                }
            }            
        }


        private void LoadAndFillHDData(Int32  LayBatNo,string StyleNo)
        {
            txtNofParts.Text = "0";
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds = new DataSet();
            ds = obj.GetLayHeaderData(LayBatNo, StyleNo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnSave.Text = "Update";
                btnSave.Enabled = true;
                txtLyrBatchNo.Text = ds.Tables[0].Rows[0]["LayerBatchNo"].ToString();
                if (ds.Tables[0].Rows[0]["BunNoMethod"].ToString() == "fxd")
                {
                    rbFixed.Checked = true;
                }
                else
                {
                    rbColorDepends.Checked = true;
                }
                rbFixed.Enabled = false;
                rbColorDepends.Enabled = false;
                dtpLyrDate.Value =Convert.ToDateTime ( ds.Tables[0].Rows[0]["CutDate"].ToString());
                txtJobOrder.Text = ds.Tables[0].Rows[0]["JobOrderNo"].ToString();
                txtStyleCode.Text = ds.Tables[0].Rows[0]["StyleCode"].ToString();
                hidStyleCode = txtStyleCode.Text.Trim ();
                txtAvgConsumption.Text = ds.Tables[0].Rows[0]["AVGConsumption"].ToString();
                txtPcsBundle.Text = ds.Tables[0].Rows[0]["PCSPerBundle"].ToString();
                cmbMerch.SelectedValue = ds.Tables[0].Rows[0]["MerchandiserCode"].ToString();
                cmbLMaster.SelectedValue = ds.Tables[0].Rows[0]["CuttingMasterCode"].ToString();
                cmbQC.SelectedValue = ds.Tables[0].Rows[0]["QCHeadCode"].ToString();
                txtStartBundleNo.Text  = ds.Tables[0].Rows[0]["BundleStartNo"].ToString();
                txtHidCanGenBundle.Text = ds.Tables[0].Rows[0]["CanGenerateBundle"].ToString();
                txtHidBundleCreated.Text = ds.Tables[0].Rows[0]["BundleCreated"].ToString();
                txtBunEndNo.Text = ds.Tables[0].Rows[0]["BundleEndNo"].ToString();
            }        
        }

        private void GetLayDTLData(Int32 LayBatNo, string  StyleNo)
        {
            dgvItem.Rows.Clear();        
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds = new DataSet();
            ds = obj.GetLayDTLData (LayBatNo,StyleNo);
            for (int x=1;x<= ds.Tables[0].Rows.Count;x++)
            {
                dgvItem.Rows.Add(1);
                x = dgvItem.Rows.Count;               
                dgvItem.Rows[x -1 ].Cells["slno"].Value = ds.Tables[0].Rows[x-1]["SlNo"].ToString();
                dgvItem.Rows[x - 1].Cells["RollNum"].Value = ds.Tables[0].Rows[x - 1]["RollNumber"].ToString();
                dgvItem.Rows[x - 1].Cells["matcode"].Value = ds.Tables[0].Rows[x - 1]["FabricCode"].ToString();
                dgvItem.Rows[x - 1].Cells["material"].Value = ds.Tables[0].Rows[x - 1]["FabricDesc"].ToString();
                dgvItem.Rows[x - 1].Cells["FabColor"].Value = ds.Tables[0].Rows[x - 1]["FabColor"].ToString();
                dgvItem.Rows[x - 1].Cells["FabMtr"].Value = ds.Tables[0].Rows[x-1]["FabricInMTR"].ToString();
                dgvItem.Rows[x - 1].Cells["ordqty"].Value = ds.Tables[0].Rows[x-1]["OrdQty"].ToString();                        
                dgvItem.Rows[x - 1].Cells["PCSMAKE"].Value = ds.Tables[0].Rows[x-1]["PcsToMake"].ToString();
                dgvItem.Rows[x - 1].Cells["Consumed"].Value = ds.Tables[0].Rows[x-1]["ConsumedFabric"].ToString();
                dgvItem.Rows[x - 1].Cells["BalanceFab"].Value = ds.Tables[0].Rows[x-1]["BalanceFabric"].ToString();                
                dgvItem.Rows[x - 1].Cells["Average"].Value = ds.Tables[0].Rows[x-1]["Average"].ToString();
                dgvItem.Rows[x - 1].Cells["ExtraQty"].Value = ds.Tables[0].Rows[x-1]["ExtraQty"].ToString();
                DisableTxtSr(false);
                            
            }
        }

        
        
        private void GetLayBundleData(Int32 LayBatNo, string  StyleNo)
        {
            lstBundle.Items.Clear();
            lstFindSlno.Items.Clear();
            lstProducts.Items.Clear();
            lstBunLetter.Items.Clear();
            lstBunNoWOLetter.Items.Clear();
            lstBunSubSlno.Items.Clear();
            lstFabcolor.Items.Clear();
            lstIntBunNo.Items.Clear();
            lstBunQty.Items.Clear();
            lstBunRange.Items.Clear();

            //new list, you can replace list with list view
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds = new DataSet();
            ds = obj.GetLayBundleData(LayBatNo, StyleNo);
            for (int i = 1;i <= ds.Tables[0].Rows.Count;i++)
            {
                lstBundle.Items.Add ( ds.Tables[0].Rows[i-1]["BundleNo"].ToString());
                lstProducts.Items.Add ( ds.Tables[0].Rows[i-1]["ProductNo"].ToString());
                lstFindSlno.Items.Add(ds.Tables[0].Rows[i - 1]["DTLSlno"].ToString());
                lstBunLetter.Items.Add(ds.Tables[0].Rows[i - 1]["BunLetter"].ToString());
                lstBunNoWOLetter.Items.Add(ds.Tables[0].Rows[i - 1]["BunNoWOLetter"].ToString());
                lstBunSubSlno.Items.Add(ds.Tables[0].Rows[i - 1]["BunSubSlno"].ToString());
                lstFabcolor.Items.Add(ds.Tables[0].Rows[i - 1]["FabColor"].ToString());
                lstIntBunNo.Items.Add(ds.Tables[0].Rows[i - 1]["bunIntNo"].ToString());
                lstBunQty.Items.Add(ds.Tables[0].Rows[i - 1]["bunQty"].ToString());
                lstBunRange.Items.Add(ds.Tables[0].Rows[i - 1]["bunRange"].ToString());
            }
            startBundleNo = Convert.ToDecimal(txtBunEndNo.Text) + 1;
        }


        

        private void SetStartEndBundleNo()
        {
            if (txtLyrBatchNo.Text.Trim ().Length  != 0)
            {
                clsLayerCutting obj = new clsLayerCutting();
                string stcode = txtStyleCode.Text.Trim () ;
                decimal BundleEndNo = startBundleNo;
                obj.SetStartEndBundleNumberForSeries(BundleEndNo, stcode);
            }
        }
         
        
        private Int32  FillParts()
        {
            ItemChkFlag = false;
            lstParts.Items.Clear();
            dgvParts.Rows.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select partscode,partsName from  tBundleParts where SubCategoryId = @subcode ";
            sda.SelectCommand.CommandText = SqlConstr;
            sda.SelectCommand.Parameters.AddWithValue("@subcode", Convert.ToInt32(txthidSubcatid.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lstParts.Items.Add(ds.Tables[0].Rows[i]["partscode"].ToString());
                lstParts.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["partsName"].ToString());
            }
            ItemChkFlag = true;
            return ds.Tables[0].Rows.Count;
        }

        private void lstParts_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (ItemChkFlag == true)
            {
                if ((ChkDuplicatePartsCode(e.Item.Text) == false) && e.Item.Checked == true)
                {
                    int x = 0;
                    dgvParts.Rows.Add(1);
                    x = dgvParts.Rows.Count;
                    dgvParts.Rows[x - 1].Cells["dgvColPartCode"].Value = e.Item.Text;
                    dgvParts.Rows[x - 1].Cells["dgvColPartName"].Value = e.Item.SubItems[1].Text;
                }
                if ((ChkDuplicatePartsCode(e.Item.Text) == true) && e.Item.Checked == false)
                {
                    MarkAndDeleteRow(e.Item.Text);                    
                }
            }
            txtNofParts.Text = dgvParts.Rows.Count.ToString();
        }

        private void MarkAndDeleteRow(string code)
        {
            for (int i = 0; i < dgvParts.Rows.Count; i++)
            {
                if (code == dgvParts.Rows[i].Cells["dgvColPartCode"].Value.ToString())
                {
                    dgvParts.Rows.RemoveAt(i);
                }
            }
        }

        private bool ChkDuplicatePartsCode(string code)
        {
            bool ret = false;
            for (int i = 0; i < dgvParts.Rows.Count; i++)
            {
                if (code == dgvParts.Rows[i].Cells["dgvColPartCode"].Value.ToString())
                {
                    ret = true;
                }
            }
            return ret;
        }

        private void txtLayerQty_TextChanged(object sender, EventArgs e)
        {
            CalculateOrdQty();
        }

        private void CalculateOrdQty()
        {
            if (txtLayerQty.Text != null && txtLayerSize.Text != null)
            {
                if (txtLayerQty.Text.Trim().Length != 0 && txtLayerSize.Text.Trim().Length != 0)
                {
                    txtOrdQty.Text = (Convert.ToInt32(txtLayerQty.Text) * Convert.ToInt32(txtLayerSize.Text)).ToString();
                }
            }
        }

        private void txtLayerSize_TextChanged(object sender, EventArgs e)
        {
            CalculateOrdQty();
        }

       

        private void frmTLayerCutting_Shown(object sender, EventArgs e)
        {
            txtStyleCode.Focus();
        }
 

    }
}
 