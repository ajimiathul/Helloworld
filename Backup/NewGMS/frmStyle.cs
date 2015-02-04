using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    public partial class frmStyle : Form
    {

        string newedit = "New";
        int sid = 0;
        bool  ItemChkFlag =false;
        int flagNumber = 1;
        bool totalFlag = false ;
        bool fabsize = false;

        public frmStyle()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {              
            if (newedit == "New")
            {
                if (InsertChk() == true)
                {
                    InsertStyle();
                    ActivityUpdate();
                    DoProcess();
                    DoProcessVsStyle();
                    btnOk.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Style already exists");
                }
            }
            else
            {
                if (UpdateChk() == true)
                {
                    UpdateStyle();
                    ActivityUpdate();
                    DoProcess();
                    btnOk.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Style already exists for another id");
                }
            }            
            ViewInGrid();
        }

        private void ViewInGrid()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "";
            cmdstr = " select a.styleid,convert(nvarchar(10),a.DesigDate,103) DesigDate, a.stylecode,a.stylename,b.EmployeeName Designer,c.SubCategory ,a.ProductionCost,a.SalesRate  ";
            cmdstr = cmdstr + " from tStyleMaster a left join  Employee b on  b.EmpId = a.DesignerId left join tSubCategory c on c.SubCategoryId = a.SubCategoryId  order by styleid desc";                      
            sda.SelectCommand.CommandText = cmdstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvStyles.DataSource = ds.Tables[0];            
        }

        private bool InsertChk()
        {
            bool ret = true;           
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr =  "select stylecode from tStyleMaster where stylecode=@sc";
            sda.SelectCommand.CommandText = cmdstr;
            sda.SelectCommand.Parameters.AddWithValue("sc", txtStyleCode.Text);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if(ds.Tables[0].Rows.Count > 0)
            {
            ret = false;
            }
            return ret;
        }

        private bool UpdateChk()
        {
            bool ret = true;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string cmdstr = "select stylecode from tStyleMaster where stylecode=@sc and styleid!=@sid";
            sda.SelectCommand.CommandText = cmdstr;
            sda.SelectCommand.Parameters.AddWithValue("sc", txtStyleCode.Text);
            sda.SelectCommand.Parameters.AddWithValue("sid",sid);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ret = false;
            }
            return ret;
        }

        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "StyleMaster");
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
            scmd.Parameters.AddWithValue("@scr", "StyleMaster");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        

        private void InsertStyle()
        {
            sid = ReadLastNum();
            clsStyle obj = new clsStyle();
            obj.pubStyleID = sid;
            obj.desdate = dtpDate.Value;
            obj.sc =  txtStyleCode.Text;
            obj.sn = txtStyleDescription.Text;
            obj.dsgid = Convert.ToInt32(cmbDesignerID.SelectedValue);
            obj.catid = Convert.ToInt32(cmbCategory.SelectedValue);
            obj.subcId = Convert.ToInt32(cmbSubCatID.SelectedValue);
            obj.pcost = Convert.ToDecimal ( txtProductionCost.Text);
            obj.srate = Convert.ToDecimal(txtSalesRate.Text);
            obj.prodInstr = txtProdInstructions.Text;
            obj.mfbk = txtMarketFeedBack.Text;
            obj.subcattype  = Convert.ToInt32(cmbSubCatType.SelectedValue);
            obj.fabwidthid = Convert.ToInt32(cmbFabDesc .SelectedValue);
            obj.fabsize = Convert.ToDecimal (txtFabConsumption.Text);
            obj.pcsperbundle = Convert.ToInt32(txtPcsPerBundle.Text);
            obj.RatioFormatCode = Convert.ToInt32(cmbRatioFormat.SelectedValue );
            obj.CFid = Convert.ToInt32(cmbCorF.SelectedValue );
            obj.cusid = Convert.ToInt32(cmbCustomer.SelectedValue);
            obj.CusPoNo = txtPONO.Text;
            obj.OrderQty = Convert.ToInt32(txtOrdQty.Text);
            obj.ShippingTargetDate = dtpExpShipment.Value;
            obj.InsertStyle();
            label3.Text = sid.ToString();
        }

        
        private void UpdateStyle()
        {
            if (sid != 0)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                string SqlString1 = "";
                string SqlString2 = "";
                string SqlString3 = "";
                string SqlString4 = "";
                string SqlString5 = "";
                SqlString1 = " update tstylemaster set desigdate=@desdate,stylecode=@sc,styleName=@sn,designerid=@dsgid,CategoryId=@CategoryId,subcategoryid=@subcid, ";
                SqlString2 = " productioncost=@pcost,salesrate=@srate,ProductionInstructions=@prodInstr,MarketFeedBack=@mfbk,LotNo=@LotNo,BundleNo=@BundleNo,   ";
                SqlString3 = " SizeTypeID=@SizeTypeID,FabWidthId=@FabWidthId,WidthSize=@WidthSize,PcsPerBundle=@PcsPerBundle,RatioFormatCode=@RatioFormatCode,CFid=@CFid,  ";
                SqlString4 = " cusid=@cusid ,CusPoNo=@CusPoNo ,OrderQty=@OrderQty ,ShippingTargetDate=@ShippingTargetDate ";
                SqlString5 = " where styleid=@sid";
                scmd.CommandText = SqlString1 + SqlString2 + SqlString3 + SqlString4 + SqlString5 ;
                scmd.Parameters.AddWithValue("@desdate", dtpDate.Value);
                scmd.Parameters.AddWithValue("@sc", txtStyleCode.Text);
                scmd.Parameters.AddWithValue("@sn", txtStyleDescription.Text);
                scmd.Parameters.AddWithValue("@dsgid", Convert.ToInt32(cmbDesignerID.SelectedValue));
                scmd.Parameters.AddWithValue("@CategoryId", Convert.ToInt32(cmbCategory.SelectedValue));                
                scmd.Parameters.AddWithValue("@subcid", Convert.ToInt32(cmbSubCatID.SelectedValue));
                scmd.Parameters.AddWithValue("@pcost", Convert.ToDecimal(txtProductionCost.Text));
                scmd.Parameters.AddWithValue("@srate", Convert.ToDecimal(txtSalesRate.Text));
                scmd.Parameters.AddWithValue("@prodInstr", txtProdInstructions.Text);
                scmd.Parameters.AddWithValue("@mfbk", txtMarketFeedBack.Text);
                scmd.Parameters.AddWithValue("@LotNo", Convert.ToInt32 (txtBatchNo.Text) );
                scmd.Parameters.AddWithValue("@BundleNo", Convert.ToInt32(txtBundleNo.Text));
                scmd.Parameters.AddWithValue("@SizeTypeID", Convert.ToInt32(cmbSubCatType.SelectedValue));
                scmd.Parameters.AddWithValue("@FabWidthId", Convert.ToInt32(cmbFabDesc.SelectedValue));
                scmd.Parameters.AddWithValue("@WidthSize", Convert.ToDecimal(txtFabConsumption.Text));
                scmd.Parameters.AddWithValue("@PcsPerBundle", Convert.ToInt32(txtPcsPerBundle.Text));
                scmd.Parameters.AddWithValue("@RatioFormatCode", Convert.ToInt32(cmbRatioFormat.SelectedValue));
                scmd.Parameters.AddWithValue("@CFid", Convert.ToInt32(cmbCorF.SelectedValue ));
                scmd.Parameters.AddWithValue("@cusid", Convert.ToInt32(cmbCustomer.SelectedValue));
                scmd.Parameters.AddWithValue("CusPoNo", txtPONO.Text);
                scmd.Parameters.AddWithValue("OrderQty",Convert.ToInt32(txtOrdQty.Text));
                scmd.Parameters.AddWithValue("ShippingTargetDate",dtpExpShipment.Value);
                scmd.Parameters.AddWithValue("@sid", sid);
                int i = scmd.ExecuteNonQuery();
                sc.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newedit = "New";
            label4.Text = "New Mode";
            sid = 0;
            label3.Text = sid.ToString();
            txtStyleCode.ReadOnly = false ;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            newedit = "Edit";
            label4.Text = "Edit Mode";
            sid = 0;
            label3.Text = sid.ToString();
            txtStyleCode.ReadOnly = true;
        }

       

        private void LoadFormData()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select styleid,DesigDate,stylecode,stylename,DesignerId,CategoryId,SubCategoryId ,ProductionCost,SalesRate,ProductionInstructions,MarketFeedBack,SizeTypeID,FabWidthId,WidthSize,PcsPerBundle,RatioFormatCode,LotNo,BundleNo,CFID,cusid,CusPoNo,OrderQty,ShippingTargetDate ";
            SqlConstr = SqlConstr + " from tstylemaster where styleid=@sid";
            sda.SelectCommand.CommandText = SqlConstr;                
            sda.SelectCommand.Parameters.AddWithValue("@sid", sid);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dtpDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Desigdate"].ToString());
            txtStyleCode.Text = ds.Tables[0].Rows[0]["stylecode"].ToString();
            txtStyleDescription.Text = ds.Tables[0].Rows[0]["stylename"].ToString();
            cmbDesignerID.SelectedValue = ds.Tables[0].Rows[0]["DesignerId"].ToString();
            cmbCategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryId"].ToString();
            cmbSubCatID.SelectedValue =  ds.Tables[0].Rows[0]["SubCategoryId"].ToString();
            txtProductionCost.Text = ds.Tables[0].Rows[0]["ProductionCost"].ToString();
            txtSalesRate.Text = ds.Tables[0].Rows[0]["SalesRate"].ToString();
            txtProdInstructions.Text =ds.Tables[0].Rows[0]["ProductionInstructions"].ToString();
            txtMarketFeedBack.Text =ds.Tables[0].Rows[0]["MarketFeedBack"].ToString();           
            cmbSubCatType.SelectedValue = ds.Tables[0].Rows[0]["SizeTypeID"].ToString();
            cmbFabDesc.SelectedValue = ds.Tables[0].Rows[0]["FabWidthId"].ToString();
            txtFabConsumption.Text = ds.Tables[0].Rows[0]["WidthSize"].ToString();
            txtPcsPerBundle.Text = ds.Tables[0].Rows[0]["PcsPerBundle"].ToString();
            cmbRatioFormat.SelectedValue = ds.Tables[0].Rows[0]["RatioFormatCode"].ToString();
            txtBatchNo.Text = ds.Tables[0].Rows[0]["LotNo"].ToString ();
            txtBundleNo.Text =  ds.Tables[0].Rows[0]["BundleNo"].ToString();
            cmbCorF.SelectedValue = ds.Tables[0].Rows[0]["CFID"].ToString();
            cmbCustomer.SelectedValue = ds.Tables[0].Rows[0]["cusid"].ToString();
            txtPONO.Text = ds.Tables[0].Rows[0]["CusPoNo"].ToString();
            txtOrdQty.Text = ds.Tables[0].Rows[0]["OrderQty"].ToString();
            dtpExpShipment.Value = Convert.ToDateTime ( ds.Tables[0].Rows[0]["ShippingTargetDate"].ToString());           
            label3.Text = sid.ToString();
        }


        private void DoProcess()
        {
            var result = MessageBox.Show("Do you want to add Activities?", "Add Activities",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "AddActivitesToExistingBundles";
                scmd.Parameters.AddWithValue("@StCode", txtStyleCode.Text.Trim());
                scmd.CommandType = CommandType.StoredProcedure;
                int i = scmd.ExecuteNonQuery();
                sc.Close();                
            }
        }


        private void DoProcessVsStyle()
        {            
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                scmd.CommandText = "ProcessVsStyleNew";
                scmd.Parameters.AddWithValue("@SC", txtStyleCode.Text.Trim());
                scmd.CommandType = CommandType.StoredProcedure;
                int i = scmd.ExecuteNonQuery();
                sc.Close();            
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            totalFlag = false;
            label3.Text = "0";
            label4.Text = "New Mode";
            CategoryShow();
            SubCategoryShow();
            ShowDesigner();
            LoadRatioFormatRange();
            flagNumber = 1;
            totalFlag = true;
            ActionForActivites();
            fabsize = false;
            LoadSubCatType();
            LoadFabType();
            LoadCorF();
            LoadCustomer();
            fabsize = true;
            txtNofActivites.Text = dgvActivities.Rows.Count.ToString();            
        }

        private void LoadRatioFormatRange()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select RatioFormatCode,RatioFormatRange from tRatioFormatHD";
            sda.SelectCommand.CommandText = SqlConstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbRatioFormat.DataSource = ds.Tables[0];
            cmbRatioFormat.DisplayMember = "RatioFormatRange";
            cmbRatioFormat.ValueMember = "RatioFormatCode";
        }


        private void LoadCustomer()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select customerName,cuscode  from tCustomer";
            sda.SelectCommand.CommandText = SqlConstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCustomer .DataSource = ds.Tables[0];
            cmbCustomer .DisplayMember = "customerName";
            cmbCustomer .ValueMember = "cuscode";
        }


        private void LoadCorF()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select CFid,CorF from tCF";
            sda.SelectCommand.CommandText = SqlConstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCorF .DataSource = ds.Tables[0];
            cmbCorF.DisplayMember = "CorF";
            cmbCorF.ValueMember = "CFid";
        }

        private void CategoryShow()
        {
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds = new DataSet();
            cmbCategory.DataSource = obj.GetCategory().Tables[0];
            cmbCategory.DisplayMember = "category";
            cmbCategory.ValueMember = "categoryid";
        }

        private void ShowDesigner()
        {
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds1 = new DataSet();
            cmbDesignerID.DataSource = obj.sMerchandiser().Tables[0];
            cmbDesignerID.DisplayMember = "employeename";
            cmbDesignerID.ValueMember = "empid";            
        }

        private void SubCategoryShow()
        {
            clsLayerCutting obj = new clsLayerCutting();
            DataSet ds = new DataSet();
            cmbSubCatID.DataSource = obj.GetSubCategory(cmbCategory.SelectedValue.ToString ()).Tables[0];
            cmbSubCatID.DisplayMember = "subcategory";
            cmbSubCatID.ValueMember = "subcategoryid";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStyles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newedit == "Edit")
            {
                int x = e.RowIndex;
                if (x != -1)
                {
                    sid = Convert.ToInt32(dgvStyles.Rows[x].Cells[0].Value.ToString());
                    LoadFormData();
                    lstActivities.Items.Clear();
                    dgvActivities.Rows.Clear();
                    flagNumber = 2;
                    AllAndSelectedActivityInListView();
                    flagNumber = 1;                   
                }
            }
            else
            {
                MessageBox.Show("Not in Edit Mode");
            }
            tabControl1.SelectedTab = tabPage2;
            tabControl1.SelectedTab = tabPage1;
            txtNofActivites.Text = dgvActivities.Rows.Count.ToString(); 
        }


        private void LoadSubCatType()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select sizetypeid,sizetype from tsizetype";
            sda.SelectCommand.CommandText = SqlConstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSubCatType.DataSource = ds.Tables[0];
            cmbSubCatType.DisplayMember = "sizetype";
            cmbSubCatType.ValueMember = "sizetypeid";
        }
        
        private void LoadFabType()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select fabwidthid,fabwidthname from tfabwidth";
            sda.SelectCommand.CommandText = SqlConstr;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbFabDesc .DataSource = ds.Tables[0];
            cmbFabDesc .DisplayMember = "fabwidthname";
            cmbFabDesc .ValueMember = "fabwidthid";
        }

        private void AllAndSelectedActivityInListView()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string s1 = " select a.activitycode,a.ActivityName,a.UnitPrice,a.ORDERNO ,  ";
            string s2 = " isnull(b.UnitRate,a.unitprice) UnitRate, isnull(b.OrderNo,a.ORDERNO) orno, ";
            string s3 = " isnull(b.ActivityCode,0) notexist   ";
            string s4 = " from tActivity a ";
            string s5 = " left join tStyleActivities b on a.ActivityCode = b.ActivityCode ";
            string s6 = " and b.StyleCode=@StyleCode where a.SubCategoryId = @SubCatID order by a.ORDERNO ";
            string SqlConstr = s1 + s2 + s3 + s4 + s5 + s6;
            sda.SelectCommand.CommandText = SqlConstr;
            sda.SelectCommand.Parameters.AddWithValue("@StyleCode", txtStyleCode.Text);
            sda.SelectCommand.Parameters.AddWithValue("@SubCatID",Convert.ToInt32 (cmbSubCatID.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                    lstActivities.Items.Add(ds.Tables[0].Rows[i]["activitycode"].ToString());
                    lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["ActivityName"].ToString());
                    lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["UnitPrice"].ToString());
                    lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Orderno"].ToString());
                    lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["UnitRate"].ToString());
                    lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["orno"].ToString());
                    if (ds.Tables[0].Rows[i]["notexist"].ToString()!="0")
                    {
                        lstActivities.Items[i].Checked = true;                        
                    }                                     
            }            
        }

        private void ActionForActivites()
        {
            flagNumber = 1;
            FillAllActivities();
            dgvActivities.Rows.Clear();
        }

        private void  FillAllActivities()
        {
            ItemChkFlag = false;
            lstActivities.Items.Clear();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            string SqlConstr = "select activitycode,ActivityName,UnitPrice,orderno   from tactivity where SubCategoryId = @subcode order by orderno ";
            sda.SelectCommand.CommandText = SqlConstr;
            sda.SelectCommand.Parameters.AddWithValue("@subcode", Convert.ToInt32(cmbSubCatID.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lstActivities.Items.Add(ds.Tables[0].Rows[i]["activitycode"].ToString());
                lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["ActivityName"].ToString());
                lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["UnitPrice"].ToString());
                lstActivities.Items[i].SubItems.Add(ds.Tables[0].Rows[i]["Orderno"].ToString());
            }
            ItemChkFlag = true;            
        }

       

        private void lstActivities_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == true)
            {
                int x = 0;
                dgvActivities.Rows.Add(1);
                x = dgvActivities.Rows.Count;
                dgvActivities.Rows[x - 1].Cells["dgvColActivityCode"].Value = e.Item.Text;
                dgvActivities.Rows[x - 1].Cells["dgvColActivityName"].Value = e.Item.SubItems[1].Text;
                if (flagNumber == 1)
                {
                    dgvActivities.Rows[x - 1].Cells["dgvColRate"].Value = e.Item.SubItems[2].Text;
                    dgvActivities.Rows[x - 1].Cells["dgvColOrder"].Value = e.Item.SubItems[3].Text;
                }
                else
                {
                    dgvActivities.Rows[x - 1].Cells["dgvColRate"].Value = e.Item.SubItems[4].Text;
                    dgvActivities.Rows[x - 1].Cells["dgvColOrder"].Value = e.Item.SubItems[5].Text;
                }
            }
            else
            {
                DeleteRow(e.Item.Text);
            }           
        }

        private void DeleteRow(string code)
        {
            for (int i = 0; i < dgvActivities.Rows.Count; i++)
            {
                if (code == dgvActivities.Rows[i].Cells["dgvColActivityCode"].Value.ToString ())
                {
                    dgvActivities.Rows.RemoveAt(i);
                }
            }
        }
        

        private void ActivityUpdate()
        {
            if (label3.Text.Length != 0)
            {
                if (newedit != "New")
                {
                    SqlConnection sc1 = new SqlConnection();
                    sc1.ConnectionString = clsDbForReports.constr;
                    sc1.Open();
                    SqlCommand scmd1 = new SqlCommand("", sc1);
                    string sqlString1 = " delete from tStyleActivities where StyleCode=@StyleCode ";
                    scmd1.CommandText = sqlString1;
                    scmd1.Parameters.AddWithValue("@StyleCode", txtStyleCode.Text);
                    int jj = scmd1.ExecuteNonQuery();
                }

                int actcode = 0;
                string actname = "";
                decimal rate = 0.00M;
                int ActOrder = 0;
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                sc.Open();
                SqlCommand scmd = new SqlCommand("", sc);
                for (int i = 0; i < dgvActivities.Rows.Count; i++)
                {
                    scmd.Parameters.Clear();
                    actcode = Convert.ToInt32(dgvActivities.Rows[i].Cells["dgvColActivityCode"].Value);
                    actname = dgvActivities.Rows[i].Cells["dgvColActivityName"].Value.ToString();
                    rate = Convert.ToDecimal(dgvActivities.Rows[i].Cells["dgvColRate"].Value);
                    ActOrder = Convert.ToInt32(dgvActivities.Rows[i].Cells["dgvColOrder"].Value);
                    string sqlString = " insert tStyleActivities (StyleCode ,ActivityCode ,OrderNo,UnitRate ) values(@StyleCode ,@ActivityCode ,@OrderNo,@UnitRate) ";
                    scmd.CommandText = sqlString;
                    scmd.Parameters.AddWithValue("@StyleCode", txtStyleCode.Text);
                    scmd.Parameters.AddWithValue("@ActivityCode", actcode);
                    scmd.Parameters.AddWithValue("@OrderNo", ActOrder);
                    scmd.Parameters.AddWithValue("@UnitRate", rate);
                    int j = scmd.ExecuteNonQuery();
                }
                sc.Close();
            }

        
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (totalFlag == true)
            {
                SubCategoryShow();
            }
        }

        private void cmbSubCatID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (totalFlag == true)
            {
                ActionForActivites();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ViewInGrid();
            
        }

        private void txtMarketFeedBack_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFabDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fabsize == true)
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                string SqlConstr = "select widthsize from tfabwidth where fabwidthid=@fid";
                sda.SelectCommand.CommandText = SqlConstr;
                sda.SelectCommand.Parameters.AddWithValue("@fid", Convert.ToInt32(cmbFabDesc.SelectedValue.ToString()));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                txtFabConsumption.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

        private void lstActivities_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                txtNofActivites.Text = dgvActivities.Rows.Count.ToString();
            }
        }
    }
}
