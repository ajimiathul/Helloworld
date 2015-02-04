using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessLayer;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Mail;
using System.IO;


namespace NewGMS
{
    public partial class frmQuotationRequest : Form
    {
        public frmQuotationRequest()
        {
            InitializeComponent();
        }
        string suppcode = "";
        string PublicMat = "";
        string supCod = "";
            int p=-1,q=-1;
        bool t = false;
        bool matselect = false,del = false,back=false;
        bool comboFlag = false;
        bool ViewMode = false;
        private void frmQuotationRequest_Load(object sender, EventArgs e)
        {
            LoadMethod();
            rbNew.Checked = true;
            cmbQtNo.Visible = false;
            btnDelete.Enabled = false;
            grid1.Column(2).CellType = FlexCell.CellTypeEnum.CheckBox;
            grid1.Column(5).CellType = FlexCell.CellTypeEnum.HyperLink;
            grid1.Cell(0, 1).Text = "SupplierName";
            grid1.Cell(0, 2).Text = "With Out Quotation";
            grid1.Cell(0, 3).Text = "Mail Status";
            grid1.Cell(0, 4).Text = "SuppCode";
            grid1.Column(1).Width =160;
            grid1.Column(2).Width = 120;
            grid1.Column(3).Width = 90;
            grid1.Column(4).Width = 0;
        }

        private void LoadMethod()
        {
            SupplierChkdListFill();
            lvMatReqCodeFill();
            QuotReqCode();        
        }
        
        private void QuotReqCode()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select lastNum from tnumbers where screen=@scr";
            sda.SelectCommand.Parameters.AddWithValue("@scr", "QuotRequest");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            txtQtRqNo.Text = (1 + Convert.ToInt32(ds.Tables[0].Rows[0]["lastNum"])).ToString();
        }

        private void lvMatReqCodeFill()
        {
            lvMatReqCode.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select convert(varchar(30),A.matreqDate,103) dt,A.matreqCode,B.Department from tMatReqHD A inner join department B on A.depid=B.DepId where A.Status ='PEN'";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvMatReqCode.Items.Add(ds.Tables[0].Rows[i]["matreqCode"].ToString());
                lvMatReqCode.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Department"].ToString());
                lvMatReqCode.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["dt"].ToString());
            }
        }  

        private void SupplierChkdListFill()
        {
            clbSupplier.Items.Clear();
            lbSupplier.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select SupplierName,Suppliercode from tSupplier";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                clbSupplier.Items.Add(ds.Tables[0].Rows[i]["SupplierName"].ToString());
                lbSupplier.Items.Add(ds.Tables[0].Rows[i]["Suppliercode"].ToString());
            }
        }

        private string SelectMatReqCode()
        {
            string s = ",";
            for (int i = 0; i < lvMatReqCode.Items.Count; i++)
            {
                if (lvMatReqCode.Items[i].Checked == true)
                {
                    s = s + lvMatReqCode.Items[i].Text + ",";
                }
            }
            return s;
        }

        private void FillFlexgrid1()
        {
            grid1.Rows = 1;
            bool present=false;
            for (int i = 0; i < dgvSelectedItems.Rows.Count; i++)
            {
                for (int j = 1; j < grid1.Rows; j++)
                {
                    if (Convert.ToInt32(grid1.Cell(j, 4).Text) == Convert.ToInt32(dgvSelectedItems.Rows[i].Cells["ColSupCod"].Value))
                    {
                        present = true;
                        break;
                    }
                }
                if (present == false)
                {
                    grid1.Rows = grid1.Rows + 1;                   
                    grid1.Cell(grid1.Rows-1, 1).Text = dgvSelectedItems.Rows[i].Cells["ColSup"].Value.ToString();
                    grid1.Cell(grid1.Rows-1, 3).Text = "Not Send";
                    grid1.Cell(grid1.Rows-1, 4).Text = dgvSelectedItems.Rows[i].Cells["ColSupCod"].Value.ToString();
                    grid1.Cell(grid1.Rows - 1, 5).Locked = true;
                }
                present = false;
            }        
        }
      
        private void FilllvMaterial(string s)
        {
            lvMaterial.Items.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "MatReqNoSelect";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@s", s);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvMaterial.Items.Add(ds.Tables[0].Rows[i]["matdesc"].ToString());
                lvMaterial.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["qty"].ToString());
                lvMaterial.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["matcode"].ToString());
            }
        }

        private void FilldgvMatSelectGrid( string s)
        {
            dgvMatSelect.Rows.Clear();
            SqlConnection con = new SqlConnection();            
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "MaterialsShow";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@s", s);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvMatSelect.Rows.Add(1);
                int k=dgvMatSelect.Rows.Count;
                dgvMatSelect.Rows[k-1].Cells["ColM"].Value=ds.Tables[0].Rows[i]["matcode"];
                dgvMatSelect.Rows[k - 1].Cells["ColMatReqNo"].Value = ds.Tables[0].Rows[i]["matreqCode"];
                dgvMatSelect.Rows[k - 1].Cells["ColMname"].Value = ds.Tables[0].Rows[i]["MatDesc"];
                dgvMatSelect.Rows[k - 1].Cells["ColQ"].Value = ds.Tables[0].Rows[i]["qty"];
                dgvMatSelect.Rows[k - 1].Cells["ColStatus"].Value = ds.Tables[0].Rows[i]["status"];
            }
        }

        private void lvMatReqCode_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == true && ViewMode==false)
            {
                FilllvMaterial(SelectMatReqCode());
                FilldgvMatSelectGrid(SelectMatReqCode());
                t = true;
            }
            else if (t == true)
            {
                FilllvMaterial(SelectMatReqCode());
                FilldgvMatSelectGrid(SelectMatReqCode());
            }
        }

        private void lvMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lvMaterial.Items.Count; i++)
            {
                if (lvMaterial.Items[i].Selected == true)
                {
                    txtReQtySupplier.Text = lvMaterial.SelectedItems[0].SubItems[1].Text;
                    txtReQty.Text = lvMaterial.SelectedItems[0].SubItems[1].Text;
                    matselect = true;
                }
            }
        }

        private void ClearCheckMark()
        {
            for (int i = 0; i < clbSupplier.Items.Count; i++)
            {
                clbSupplier.SetItemChecked(i, false);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtReQtySupplier.Text == "")
            {
                MessageBox.Show("No Data Entered");
                txtReQtySupplier.Focus();
            }
            else if (matselect == true)
            {
                if (lvMaterial.SelectedItems[0].Checked == false)
                {
                    FilldgvSelectedItems();
                    FillFlexgrid1();
                }
                else
                {
                    MessageBox.Show("No");
                }
            }
            else
            {
                MessageBox.Show("Not Selected");
            }
        }
        
        private void FilldgvSelectedItems()
        {
            string sel = "";
            for (int i = 0; i < clbSupplier.Items.Count; i++)
            {
                if (clbSupplier.GetItemChecked(i) == true)
                {
                    supCod = lbSupplier.Items[i].ToString();
                    for (int j = 0; j < lvMaterial.Items.Count; j++)
                    {
                        if (lvMaterial.Items[j].Selected == true)
                        {
                            sel = lvMaterial.Items[j].Text;                         
                        }
                    }
                    dgvSelectedItems.Rows.Add(1);
                    int x = dgvSelectedItems.Rows.Count;
                    dgvSelectedItems.Rows[x - 1].Cells["ColMat"].Value = sel;
                    dgvSelectedItems.Rows[x - 1].Cells["ColQty"].Value = txtReQty.Text;
                    dgvSelectedItems.Rows[x - 1].Cells["ColNewQty"].Value = txtReQtySupplier.Text;
                    dgvSelectedItems.Rows[x - 1].Cells["ColSup"].Value = clbSupplier.Items[i].ToString();
                    dgvSelectedItems.Rows[x - 1].Cells["ColSupCod"].Value = lbSupplier.Items[i].ToString();
                    dgvSelectedItems.Rows[x - 1].Cells["ColMatCod"].Value = lvMaterial.SelectedItems[0].SubItems[2].Text;
                    lvMatReqCode.Enabled = false;
                    for (int j = 0; j < lvMaterial.Items.Count; j++)
                    {
                        if (lvMaterial.Items[j].Selected == true)
                        {
                             lvMaterial.Items[j].Checked = true; // should not change this line to other position.
                        }
                    }
                }
            }
        }

        private int MatCount()
        {
            string sel = "";
            int k = 0;
            for (int j = 0; j < lvMaterial.Items.Count; j++)
            {

                if (lvMaterial.Items[j].Selected == true)
                {
                    sel = lvMaterial.Items[j].Text;
                }
            }
            for (int i = 0; i < dgvSelectedItems.Rows.Count; i++)
            {
                if (dgvSelectedItems.Rows[i].Cells[0].Value.ToString() == sel)
                {
                    k++;
                }
            }
            if (PublicMat != sel)
            {
                k = 0;
            }
            return k;
        }

        
        private void lvMaterial_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            PublicMat = lvMaterial.Items[e.Index].Text;
            if (back == true)
            {
                e.NewValue = CheckState.Unchecked;
                back = false;
            }
            else if (MatCount() != 0)
            {
                e.NewValue = CheckState.Checked;
            }
            else if (del == true)
            {
                e.NewValue = CheckState.Checked;
                del = false;
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Checked;
            }
            else
            {
                e.NewValue = CheckState.Unchecked;
            }
        }        

        private void dgvSelectedItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            p = e.RowIndex;           
        }
        private bool CheckForPresent(string mat)
        {
            bool present = false;
            for (int i = 0; i < dgvSelectedItems.Rows.Count; i++)
            {
                if (dgvSelectedItems.Rows[i].Cells["ColMat"].Value.ToString() == mat)
                {
                    present = true;
                }
            }
            return present;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (dgvSelectedItems.Rows.Count == 0)
            {
                MessageBox.Show("Empty");
            }
            else if (p != -1 )
            {
                string mat = dgvSelectedItems.Rows[p].Cells["ColMat"].Value.ToString();
                dgvSelectedItems.Rows.RemoveAt(p);
                FillFlexgrid1();
                if (CheckForPresent(mat) == false)
                {
                    for (int i = 0; i < lvMaterial.Items.Count; i++)
                    {
                        if (lvMaterial.Items[i].Text == mat)
                        {
                            back = true;
                            lvMaterial.Items[i].Checked = false;
                        }
                    }
                }
                p = -1;
            }
            else
            {
                MessageBox.Show("Must select data");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (lvMaterial.SelectedItems.Count > 0)
            {
                if (lvMaterial.SelectedItems[0].Checked == false)
                {
                    lvMatReqCode.Enabled = false;
                    dgvRemovedItems.Rows.Add(1);
                    int x = dgvRemovedItems.Rows.Count;
                    dgvRemovedItems.Rows[x - 1].Cells["ColMate"].Value = lvMaterial.SelectedItems[0].Text;
                    dgvRemovedItems.Rows[x - 1].Cells["ColMCo"].Value = lvMaterial.SelectedItems[0].SubItems[2].Text;
                    del = true;
                    lvMaterial.SelectedItems[0].Checked = true;
                    lvMaterial.SelectedItems[0].Font = new Font(lvMaterial.SelectedItems[0].Font,lvMaterial.SelectedItems[0].Font.Style | FontStyle.Strikeout);  
                }
                else
                {
                    MessageBox.Show("Cannot delete");
                }
                ClearCheckMark();
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveItemsFromMatReqDtl()
        {
            String whereCondtion = "";
            for (int i = 0; i < lvMatReqCode.Items.Count  ; i++)
            {
                if (lvMatReqCode.Items[i].Checked == true)
                {
                    whereCondtion = whereCondtion + lvMatReqCode.Items[i].Text + ",";
                }
            }            
            if (whereCondtion.Trim().Length >= 1)
            {
                int len = whereCondtion.Trim().Length;
                whereCondtion = whereCondtion.Trim().Substring(0, len - 1);
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            string cmdString = "";
            for (int i = 0; i < dgvRemovedItems.Rows.Count; i++)
            {
                cmdString = "update tMatReqDtl set status='REM',QtRqNo=@QtRqNo where matcode=@mcode and matreqCode in (" + whereCondtion + ")";
                cmd.CommandText = cmdString;
                cmd.Parameters.AddWithValue("@mcode", Convert.ToInt32(dgvRemovedItems.Rows[i].Cells["ColMCo"].Value));
                cmd.Parameters.AddWithValue("@QtRqNo", Convert.ToInt32(txtQtRqNo.Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }


        
        private void SaveProcess(string WithOrNot)
        {
            if ((dgvRemovedItems.Rows.Count > 0) ||  (dgvSelectedItems.Rows.Count > 0))
            {
                UpdateLastNum();
                
                if (ReadLastNum().ToString() != txtQtRqNo.Text)
                {
                    MessageBox.Show("Quotation request Number is changed");
                    txtQtRqNo.Text = ReadLastNum().ToString();
                }
                RemoveItemsFromMatReqDtl();           
                int QtRqNo = Convert.ToInt32(txtQtRqNo.Text);
                SaveInMaterialVsSupplier(QtRqNo);
                SavInMatRqVsQtRqNo(QtRqNo);
                MarkSelStatusInMatReqDtl();
            
            MarkInMatReqHd();
            QtSupplierInsert(Convert.ToInt32(txtQtRqNo.Text), WithOrNot);
            btnSave.Enabled = false;
           
            GridSupplierSend();
            }
        }

        private void GridSupplierSend()
        {
           SqlConnection con = new SqlConnection();            
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select B.SupplierName,A.suppliercode from tQuotReqVsSupplier A inner join tSupplier B on A.suppliercode=B.Suppliercode  where QtRqNo=@qtRqNum";
            sda.SelectCommand.Parameters.AddWithValue("@qtRqNum", Convert.ToInt32(txtQtRqNo.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQtRqNo.Text != "")
            {
                SaveProcess("WQ");
                SetQtnWithOrNot();
                NextlevelStatus();
                SaveWoutPriceList();
                createPDF();
                markPreviewStatus();
            }
            else
            {
                MessageBox.Show("No Data");
                txtQtRqNo.Focus();
            }
        }

        private void markPreviewStatus()
        {
                for (int j = 1; j < grid1.Rows; j++)
                {
                    if (grid1.Cell(j, 2).Text == "1")
                    {
                        grid1.Cell(j, 5).Locked = true;
                        grid1.Cell(j, 5).Text = "";

                    }
                    else
                    {
                        grid1.Cell(j, 5).Locked = false;
                        grid1.Cell(j, 5).Text = "Preview";                        
                    }
                }
        }

        private void SetQtnWithOrNot()
        {
            string EStatus = "NOST";
            string withOrNot = "WQ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int h = 1; h < grid1.Rows; h++)
            {
                cmd.CommandText = "update tQuotReqVsSupplier set NeedQuotation=@withOrNot,EmailStatus=@Estatus where QtRqNo=@qtNum and suppliercode=@subCod";
                if (grid1.Cell(h, 2).Text == "1")
                {
                    withOrNot = "WOQ";
                    EStatus = "NOTR";
                }
                else
                {
                    withOrNot = "WQ";
                    EStatus = "NOST";
                }
                cmd.Parameters.AddWithValue("@withOrNot", withOrNot);
                cmd.Parameters.AddWithValue("@EStatus", EStatus);
                cmd.Parameters.AddWithValue("@qtNum", Convert.ToInt32(txtQtRqNo.Text));
                cmd.Parameters.AddWithValue("@subCod", Convert.ToInt32(grid1.Cell(h, 4).Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }


        
        private void MarkInMatReqHd()
        {
            int inum = 0;
            String whereCondtion = "";
            for (int i = 0; i < lvMatReqCode.Items.Count; i++)
            {
                if (lvMatReqCode.Items[i].Checked == true)
                {
                    whereCondtion = whereCondtion + lvMatReqCode.Items[i].Text + ",";
                    inum++;
                }
            }

            if (inum != 0)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "StausChangeInMatReqHd";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@whereCondition", whereCondtion);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void QtSupplierInsert(int QtRqNo, string needYesNo)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "iquotReqVsSupplier";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QtReqNo", QtRqNo);
            cmd.Parameters.AddWithValue("@WithOrNot", needYesNo);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void MarkSelStatusInMatReqDtl()
        {
            String whereCondtion = "";
            for (int i = 0; i < lvMatReqCode.Items.Count; i++)
            {
                if (lvMatReqCode.Items[i].Checked == true)
                {
                    whereCondtion = whereCondtion + lvMatReqCode.Items[i].Text + ",";
                }
            }
            if (whereCondtion.Trim().Length >= 1)
            {
                int len = whereCondtion.Trim().Length;
                whereCondtion = whereCondtion.Trim().Substring(0, len - 1);
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            string cmdString = "";
            for (int i = 0; i < dgvSelectedItems.Rows.Count; i++)
            {
                cmdString = "update tMatReqDtl set status='SEL',QtRqNo=@QtRqNo where matcode=@mcode and matreqCode in (" + whereCondtion + ")";
                cmd.CommandText = cmdString;
                cmd.Parameters.AddWithValue("@mcode", Convert.ToInt32(dgvSelectedItems.Rows[i].Cells["ColMatCod"].Value));
                cmd.Parameters.AddWithValue("@QtRqNo", Convert.ToInt32(txtQtRqNo.Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }

        private int ReadLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "select lastnum from tNumbers where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "QuotRequest");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "QuotRequest");
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void SaveInMaterialVsSupplier(int QtRqNo)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < dgvSelectedItems.Rows.Count; i++)
            {                                                                                                                                                                                                                                                           
                cmd.CommandText = "insert into tMaterialVsSupplier(suppliercode,matcode,QtRqNo,DocRate,QtURate,QtyRate,MaterialBlocked,MReqQty,QReqQty,QtQty,PReqQty,PerInvReqQty,colorChanged)values(@supcode,@matcode,@QtRqNo,@DocRate,@Urate,@QtyRate,@MaterialBlocked,@qty,@newqty,@newqty,@newqty,@newqty,'N')";
                cmd.Parameters.AddWithValue("@supcode", Convert.ToInt32(dgvSelectedItems.Rows[i].Cells["ColSupCod"].Value));
                cmd.Parameters.AddWithValue("@matcode", Convert.ToInt32(dgvSelectedItems.Rows[i].Cells["ColMatCod"].Value));
                cmd.Parameters.AddWithValue("@QtRqNo", QtRqNo);
                cmd.Parameters.AddWithValue("@qty", Convert.ToDecimal (dgvSelectedItems.Rows[i].Cells["ColQty"].Value));
                cmd.Parameters.AddWithValue("@newqty", Convert.ToDecimal(dgvSelectedItems.Rows[i].Cells["ColNewQty"].Value));
                cmd.Parameters.AddWithValue("DocRate", 0.0);
                cmd.Parameters.AddWithValue("URate", 0.0);
                cmd.Parameters.AddWithValue("QtyRate", 0.0);
                cmd.Parameters.AddWithValue("@MaterialBlocked", "N");
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }


        private void SavInMatRqVsQtRqNo(int QtRqNo)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int i = 0; i < lvMatReqCode.Items.Count; i++)
            {
                if (lvMatReqCode.Items[i].Checked == true)
                {
                    cmd.CommandText = "insert into tMatRqVsQtRqNo(QtRqNo,MatReqCode)values(@QtRqNo,@MatReqCode)";
                    cmd.Parameters.AddWithValue("@QtRqNo",QtRqNo);
                    cmd.Parameters.AddWithValue("@MatReqCode", Convert.ToInt32(lvMatReqCode.Items[i].Text));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }

        private void dgvRemovedItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            q = e.RowIndex;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (dgvRemovedItems.Rows.Count == 0)
            {
                MessageBox.Show("Empty");
            }
           else if (q != -1)
            {
                for (int i = 0; i < lvMaterial.Items.Count; i++)
                {
                    if (lvMaterial.Items[i].Text == dgvRemovedItems.Rows[q].Cells["ColMate"].Value.ToString())
                    {
                        back = true;
                        lvMaterial.Items[i].Checked = false;
                        lvMaterial.Items[i].Font = new Font(lvMaterial.SelectedItems[0].Font,FontStyle.Regular);   

                    }
                }
                dgvRemovedItems.Rows.RemoveAt(q);
                q = -1;
            }
            else
            {
                MessageBox.Show("Must select data");
            }
        }

        private void lvMaterial_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                ClearCheckMark();
                matselect = true;
            }
            else matselect = false;
        }
        
        private void txtQtRqNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
            }
            else if (char.IsDigit(e.KeyChar) == false)
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        private void txtReQtySupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)8)
            //{
            //}
            //else if (char.IsDigit(e.KeyChar) == false)
            //{
            //    e.KeyChar = Convert.ToChar(Keys.None);
            //}
        }

        //private void btnSaveWORequest_Click(object sender, EventArgs e)
        //{
        //    if (txtQtRqNo.Text != "")
        //    {
        //        DialogResult result = MessageBox.Show("Save With out Price List Request ", "Yes or No", MessageBoxButtons.YesNo);
        //        if (result == DialogResult.Yes)
        //        {
        //            SaveProcess("WOQ");
        //            SaveWoutPriceList();
        //            NextlevelStatus();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Data");
        //        txtQtRqNo.Focus();
        //    }
        //}

        private void SaveWoutPriceList()
        {
            int supC = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            for (int t = 1; t < grid1.Rows; t++)
            {
                if (grid1.Cell(t, 2).Text == "1")
                {
                    supC = Convert.ToInt32(grid1.Cell(t, 4).Text);
                    for (int i = 0; i < dgvSelectedItems.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dgvSelectedItems.Rows[i].Cells["ColSupCod"].Value) == supC)
                        {
                            cmd.CommandText = "QtWithOutPriceList";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@supcode", Convert.ToInt32(dgvSelectedItems.Rows[i].Cells["ColSupCod"].Value));
                            cmd.Parameters.AddWithValue("@matcode", Convert.ToInt32(dgvSelectedItems.Rows[i].Cells["ColMatCod"].Value));
                            cmd.Parameters.AddWithValue("@qrno", Convert.ToInt32(txtQtRqNo.Text));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }
            }
            con.Close();
        }
        private void NewMethod()
        {
            rbNew.Checked = true;
            ViewMode = false;
            cmbQtNo.DataSource = null;
            cmbQtNo.Visible = false;
            btnSave.Enabled = true;
            
            button1.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            lvMatReqCode.Items.Clear();
            LoadMethod();
            lvMatReqCode.Enabled = true;
            dgvSelectedItems.Rows.Clear();
            dgvRemovedItems.Rows.Clear();
            txtReQtySupplier.Clear();
            btnSave.Enabled = true;
            
            btnDelete.Enabled = false;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void dgvSelectedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            p = e.RowIndex;
        }       
        private void NextlevelStatus()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            for (int i = 0; i < lvMatReqCode.Items.Count; i++)
            {
                if (lvMatReqCode.Items[i].Checked == true)
                {
                    int matreqcode = Convert.ToInt32(lvMatReqCode.Items[i].Text);
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandText = "update tMatReqHD set CanModify = 'No' where matreqCode=@mrqcd and exists (select * from tMatReqDtl  where  matreqCode = @mrqcd and Status in ('SEL','PEN'))";
                    cmd.Parameters.AddWithValue("@mrqcd", matreqcode);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    SqlCommand cmd1 = new SqlCommand("", con);
                    cmd1.CommandText = "update tMatReqHD set CanModify = 'Yes' where matreqCode=@mrqcd and not exists (select * from tMatReqDtl  where  matreqCode = @mrqcd and Status in ('SEL','PEN'))";
                    cmd1.Parameters.AddWithValue("@mrqcd", matreqcode);
                    cmd1.ExecuteNonQuery();
                    cmd1.Parameters.Clear();
                }
            }
            con.Close();
        }
        private void FillComboQtNum()
        {
           SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "select distinct QtRqNo from tMatRqVsQtRqNo";
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbQtNo.DataSource = ds.Tables[0];
                    cmbQtNo.DisplayMember = "QtRqNo";
                    cmbQtNo.ValueMember = "QtRqNo";
                }
                else
                {
                    cmbQtNo.DataSource = null;
                }
            
        }
        private void rbViewOrDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (rbViewOrDelete.Checked == true)
            {
                ViewMode = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;
                
                button1.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
                button18.Enabled = false;
                cmbQtNo.Visible = true;
                comboFlag = false;
                 FillComboQtNum();
                 comboFlag = true;
                 FillComboQtNum();
            }
            else
            {
                comboFlag = false;
                NewMethod();
                comboFlag = true;
                grid1.Locked = false;
            }
        }
        private void FillSelectedItemsGrid()
        {
            dgvSelectedItems.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select B.MatDesc,A.matcode,C.SupplierName,A.suppliercode,A.MReqQty,A.QReqQty from tMaterialVsSupplier A left join tMaterial B on A.matcode=B.MatCode left join tSupplier C on C.Suppliercode=A.suppliercode where QtRqNo=@qtNum";
            sda.SelectCommand.Parameters.AddWithValue("@qtNum",cmbQtNo.SelectedValue);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvSelectedItems.Rows.Add(1);
                int x = dgvSelectedItems.Rows.Count;
                dgvSelectedItems.Rows[x - 1].Cells["ColMat"].Value = ds.Tables[0].Rows[i]["MatDesc"];
                dgvSelectedItems.Rows[x - 1].Cells["ColQty"].Value = ds.Tables[0].Rows[i]["MReqQty"];
                dgvSelectedItems.Rows[x - 1].Cells["ColSup"].Value = ds.Tables[0].Rows[i]["SupplierName"];
                dgvSelectedItems.Rows[x - 1].Cells["ColSupCod"].Value = ds.Tables[0].Rows[i]["suppliercode"];
                dgvSelectedItems.Rows[x - 1].Cells["ColMatCod"].Value = ds.Tables[0].Rows[i]["matcode"];
                dgvSelectedItems.Rows[x - 1].Cells["ColNewQty"].Value = ds.Tables[0].Rows[i]["QReqQty"];
            }
        }
        private void CheckStatusInFlex()
        {
            grid1.Locked = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select suppliercode,NeedQuotation from tQuotReqVsSupplier where QtRqNo=@qtNum";
            sda.SelectCommand.Parameters.AddWithValue("@qtNum", cmbQtNo.SelectedValue);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int u = 1; u < grid1.Rows; u++)
            {
                for (int w = 0; w < ds.Tables[0].Rows.Count; w++)
                {
                    if (ds.Tables[0].Rows[w]["suppliercode"].ToString() == grid1.Cell(u, 4).Text.Trim())
                    {
                        if (ds.Tables[0].Rows[w]["NeedQuotation"].ToString() == "WOQ")
                        {
                            grid1.Cell(u, 2).Text = "1";
                        }
                    }
                }
            }
        }
        private void FillRemovedItemsGrid()
        {
            dgvRemovedItems.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select B.MatDesc,A.matcode from tMatReqDtl A inner join tMaterial B on B.MatCode=A.matcode where A.QtRqNo=@qtNum and A.Status='REM'";
            sda.SelectCommand.Parameters.AddWithValue("@qtNum",cmbQtNo.SelectedValue);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvRemovedItems.Rows.Add(1);
                int x = dgvRemovedItems.Rows.Count;
                dgvRemovedItems.Rows[x - 1].Cells["ColMate"].Value = ds.Tables[0].Rows[i]["MatDesc"];
                dgvRemovedItems.Rows[x - 1].Cells["ColMCo"].Value = ds.Tables[0].Rows[i]["matcode"];

            }
}
        private void FillListViewMatReqCode()
        {
            lvMatReqCode.Items.Clear();
           SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.matreqCode,B.Department,convert(varchar(30),A.matreqDate,103) dt from tMatReqHD A inner join department B on A.depid=B.DepId inner join tMatRqVsQtRqNo C on C.MatReqCode=A.matreqCode where QtRqNo=@qtnum";
            sda.SelectCommand.Parameters.AddWithValue("@qtnum", cmbQtNo.SelectedValue);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lvMatReqCode.Items.Add(ds.Tables[0].Rows[i]["matreqCode"].ToString());
                lvMatReqCode.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Department"].ToString());
                lvMatReqCode.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["dt"].ToString());
            }
          }

        private void cmbQtNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFlag == true)
            {
                FillRemovedItemsGrid();
                FillListViewMatReqCode();
                FillSelectedItemsGrid();
                FillFlexgrid1();
                CheckStatusInFlex();
                txtQtRqNo.Text = cmbQtNo.SelectedValue.ToString ();
                ShowMailStatusInGrid1();
            }
        }

       private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbQtNo.DataSource != null)
            {
                string qtNum = cmbQtNo.SelectedValue.ToString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "RemoveQtReqNum";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qtNum", cmbQtNo.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Quotation Request Number: "+qtNum + "  is Deleted");
                comboFlag = false;
                FillComboQtNum();
                comboFlag = true;
            }
        }      

       private void grid1_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
       {
           if (e.Col == 2)
           {
               if (grid1.Cell(e.Row, 2).Text == "1")
               {
                   grid1.Cell(e.Row, 3).Text = "Not Applicable";                   
                   grid1.Cell(e.Row, 5).Locked = true; 
               }
               else
               {
                   grid1.Cell(e.Row, 3).Text = "Not Send";                   
                   grid1.Cell(e.Row, 5).Locked = false;
               }
           }
       }
       
        private void pdfdelete()
       {
           try
           {
               string sourceDir = @"e:\";
               string[] txtList = Directory.GetFiles(sourceDir, "*.PDF");
               foreach (string f in txtList)
               {
                   File.Delete(f);
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
       }

        private void createPDF()
        {
            //pdfdelete();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.suppliercode,B.Email  from tQuotReqVsSupplier A,tSupplier B where A.suppliercode = B.Suppliercode and A.EmailStatus in ('NOST','UNDL','FAIL') and A.QtRqNo = @qtnum";
            sda.SelectCommand.Parameters.AddWithValue("@qtnum", Convert.ToInt32(txtQtRqNo.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {              
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                     PrintMatReq(Convert.ToInt32(ds.Tables[0].Rows[i]["suppliercode"].ToString()), Convert.ToInt32(txtQtRqNo.Text));
                }
           } 
        }

        private void MailSend()
        {
            string FilePath = clsDbForReports.QuotationPdfDirectory;
            Int32 locSupcode=0;        
            //pdfdelete();
            
            string MailStatus = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.suppliercode,B.Email  from tQuotReqVsSupplier A,tSupplier B where A.suppliercode = B.Suppliercode and A.EmailStatus in ('NOST','UNDL','FAIL') and A.QtRqNo = @qtnum";
            sda.SelectCommand.Parameters.AddWithValue("@qtnum", Convert.ToInt32(txtQtRqNo.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    locSupcode = Convert.ToInt32(ds.Tables[0].Rows[i]["suppliercode"].ToString());
                    suppcode = ds.Tables[0].Rows[i]["suppliercode"].ToString();
                    string Filename = @FilePath + "QR" + txtQtRqNo.Text.Trim() + "S" + locSupcode.ToString () + ".pdf"; 
                    MailStatus = MailCode(ds.Tables[0].Rows[i]["Email"].ToString(), Filename);
                    UpdateSentStatus(locSupcode.ToString(), MailStatus);
                }
                ShowMailStatusInGrid1();
            }        
        }


       private void btnSend_Click(object sender, EventArgs e)
       {
           MailSend();
       }

       private string MailCode(string SuplrEmailAdr,string PDFFileName)
       {
           SqlConnection con = new SqlConnection();
           con.ConnectionString = clsDbForReports.constr;
           SqlDataAdapter sdaa = new SqlDataAdapter("", con);
           sdaa.SelectCommand.CommandText = "select (PageUrl+PageName)  UrlName from  tWebPages where recid=2";
           DataSet dsweb = new DataSet();
           sdaa.Fill(dsweb);
           string url = dsweb.Tables[0].Rows[0][0].ToString();


           DataSet dscomp = new DataSet();
           sdaa.SelectCommand.CommandText = "select * from tCompanyMailInfo";
           sdaa.Fill(dscomp);
           string s1 = dscomp.Tables[0].Rows[0][0].ToString();
           string s2 = dscomp.Tables[0].Rows[0][1].ToString();
           string s3 = dscomp.Tables[0].Rows[0][2].ToString();
           int s4 = Convert.ToInt32(dscomp.Tables[0].Rows[0][3].ToString());

           
           string qtno =(txtQtRqNo.Text).ToString();
           string status = "";
           int flag = 0;
           MailMessage mail = new MailMessage();
           string apphead = "<html><head><h1>VEESIX GARMENTS FACTORY</h1></head><body>Hello <p> Please see the attached pdf<p><a href=\""+url+"?supcode="+suppcode+"&qtno="+qtno+"\">SenderUpdation </body></html>";
         //  mail.From = new MailAddress("tusha12eeitsol@gmail.com");
           mail.From = new MailAddress(s2);

           mail.To.Add(SuplrEmailAdr);
           mail.Subject = "Quatation Request";
           mail.Body = apphead;
           AlternateView planview = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable tby those clients that don't support html");
           AlternateView htmlview = AlternateView.CreateAlternateViewFromString("<b>This is bold text and viewable by those mail clients that support html<b>");
           mail.IsBodyHtml = true;
           mail.Priority = MailPriority.High;
           System.Net.Mail.Attachment jil = new System.Net.Mail.Attachment(PDFFileName);
           mail.Attachments.Add(jil);
           SmtpClient smtp = new SmtpClient(s1,s4);
           smtp.EnableSsl = true;
           smtp.Credentials = new System.Net.NetworkCredential(s2, s3);
           try
           {
               smtp.Send(mail);
               
           }

           catch
           {
               flag = 1;
               
           }

           if (flag == 1)
           {
               status = "UNDL";
               flag = 0;
           }
           else
           {
               status = "SENT";
           }

        
           return status;
       }

       private void UpdateSentStatus(string Supcode,String MailStatus)
       {
           string qtNum = txtQtRqNo.Text;
           SqlConnection con = new SqlConnection();
           con.ConnectionString = clsDbForReports.constr;
           con.Open();
           SqlCommand cmd = new SqlCommand("", con);
           cmd.CommandText = "update tQuotReqVsSupplier set EmailStatus=@MStatus where QtRqNo = @qtnum and suppliercode =@supcode";
           cmd.CommandType = CommandType.Text;
           cmd.Parameters.AddWithValue("@qtNum", Convert.ToInt32 ( txtQtRqNo.Text));
           cmd.Parameters.AddWithValue("@supcode", Convert.ToInt32(Supcode));
           cmd.Parameters.AddWithValue("@MStatus", MailStatus);
           cmd.ExecuteNonQuery();
           con.Close();       
       }

       private void ShowMailStatusInGrid1()
       {
           string EStatus = "";
           grid1.Rows = 1;
           SqlConnection con = new SqlConnection();
           con.ConnectionString = clsDbForReports.constr;
           SqlDataAdapter sda = new SqlDataAdapter("", con);
           sda.SelectCommand.CommandText = "select B.SupplierName,A.NeedQuotation,A.EmailStatus, A.suppliercode  from tQuotReqVsSupplier A,tSupplier B where A.suppliercode = B.Suppliercode and A.QtRqNo = @qtnum order by B.SupplierName ";
           sda.SelectCommand.Parameters.AddWithValue("@qtnum",Convert.ToInt32 ( txtQtRqNo.Text));
           DataSet ds = new DataSet();
           sda.Fill(ds);
           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           {
               grid1.Rows = grid1.Rows + 1;
               grid1.Cell(grid1.Rows - 1, 1).Text = ds.Tables[0].Rows[i]["SupplierName"].ToString();
               if ((ds.Tables[0].Rows[i]["NeedQuotation"].ToString().Trim ()) == "WOQ")
               {
                   grid1.Cell(grid1.Rows - 1, 2).Text = "1";
                   grid1.Cell(grid1.Rows - 1, 5).Text = "";
                   grid1.Cell(grid1.Rows - 1, 5).Locked = true;
               }
               else
               {
                   grid1.Cell(grid1.Rows - 1, 5).Locked = false;
                   grid1.Cell(grid1.Rows - 1, 2).Text = "0";
                   grid1.Cell(grid1.Rows - 1, 5).Text = "Preview";
               }
               if(ds.Tables[0].Rows[i]["EmailStatus"].ToString().Trim ()=="NOTR")
               {
                   EStatus = "Not Applicable";               
               }
               if(ds.Tables[0].Rows[i]["EmailStatus"].ToString().Trim ()=="SENT")
               {
                   EStatus = "Send";               
               }
                if(ds.Tables[0].Rows[i]["EmailStatus"].ToString().Trim ()=="FAIL")
               {
                   EStatus = "Fail";               
               }
               if(ds.Tables[0].Rows[i]["EmailStatus"].ToString().Trim ()=="NOST")
               {
                   EStatus = "Not Send";               
               }
                if(ds.Tables[0].Rows[i]["EmailStatus"].ToString().Trim ()=="UNDL")
               {
                   EStatus = "Un Delivered";               
               }
               grid1.Cell(grid1.Rows - 1, 3).Text =  EStatus ;
               grid1.Cell(grid1.Rows - 1, 4).Text = ds.Tables[0].Rows[i]["suppliercode"].ToString();
           }      
       }


       public void SetDBLogonForReport(ReportDocument myrep)
       {
           ConnectionInfo myConnectionInfo = new ConnectionInfo();
           myConnectionInfo.ServerName = clsDbForReports.server;
           myConnectionInfo.DatabaseName = clsDbForReports.db;
           myConnectionInfo.UserID = clsDbForReports.uid;
           myConnectionInfo.Password = clsDbForReports.pwd;
           myConnectionInfo.IntegratedSecurity = false;

           Tables tbs = myrep.Database.Tables;
           foreach (CrystalDecisions.CrystalReports.Engine.Table t in tbs)
           {
               TableLogOnInfo tbl = t.LogOnInfo;
               tbl.ConnectionInfo = myConnectionInfo;
               t.ApplyLogOnInfo(tbl);
           }
       }

       private string  PrintMatReq(Int32 Supcode,Int32 QtReqNo) 
       {
           crystalreportforpdf  oRpt = new crystalreportforpdf();
           SetDBLogonForReport(oRpt);
           oRpt.SetParameterValue(0, Supcode);
           oRpt.SetParameterValue(1, QtReqNo);
           string FilePath = clsDbForReports.QuotationPdfDirectory;
           string pdfFileName = FilePath + "QR" + QtReqNo.ToString().Trim() + "S" + Supcode.ToString().Trim() + ".pdf";
           try
           {
               oRpt.ExportToDisk(ExportFormatType.PortableDocFormat, @pdfFileName);
           }
           catch(Exception ex)
           {
               MessageBox.Show(ex.Message.ToString ());
           }
            return pdfFileName;
       }

       private void grid1_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
       {
           try
           {
               string PdfExePath = clsDbForReports.PdfExeWithPath;
               string FilePath = clsDbForReports.QuotationPdfDirectory;
               string Filename = @FilePath  + "QR" + txtQtRqNo.Text.Trim() + "S" + grid1.Cell(e.Row, 4).Text.Trim() + ".pdf";
               System.Diagnostics.Process.Start(@PdfExePath , Filename);
               e.URL = null;
               e.Changed = true;
           }
           catch 
           {
           MessageBox.Show ("File Error");
           }
       }
        

    }
}