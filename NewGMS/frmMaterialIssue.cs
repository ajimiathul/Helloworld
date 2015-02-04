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
    public partial class frmMaterialIssue : Form
    {
        bool MatReqCmbFlag = false;
        int colFlag = 1;

        Dictionary<string, string> dictionary;

        public frmMaterialIssue()
        {
            InitializeComponent();
        }
        

        private void frmMaterialIssue_Load(object sender, EventArgs e)
        {
            txtMatReqNo.Visible = false;
            cmbMatReq.Visible = true;
            gridMainSettings();
            FillMatReqCmb();
            MatReqCmbFlag = true;
            FillDataForNewIssue();
            validation(6);
        }

        private void gridMainSettings()
        {
            gridEntry.Cell(0, 1).Text = "SL.No.";
            gridEntry.Cell(0, 2).Text = "Material";
            gridEntry.Cell(0, 3).Text = "Unit";
            gridEntry.Cell(0, 4).Text = "Req.Qty.";
            gridEntry.Cell(0, 5).Text = "Issued Qty";
            gridEntry.Cell(0, 6).Text = "Issue Qty";
            gridEntry.Cell(0, 7).Text = "Bal. Qty";
            gridEntry.Cell(0, 8).Text = "matcode";
            gridEntry.Cell(0, 9).Text = "unitcode";
            gridEntry.Column(10).CellType = FlexCell.CellTypeEnum.CheckBox; 

            gridEntry.Column(1).Width = 40;
            gridEntry.Column(2).Width = 300;
            gridEntry.Column(3).Width = 80;
            gridEntry.Column(4).Width = 80;
            gridEntry.Column(5).Width = 80;
            gridEntry.Column(6).Width = 80;
            gridEntry.Column(7).Width = 80;
            gridEntry.Column(8).Width = 0;
            gridEntry.Column(9).Width = 0;


            gridEntry.Column(1).Locked = true;
            gridEntry.Column(2).Locked = true;
            gridEntry.Column(3).Locked = true;
            gridEntry.Column(4).Locked = true;
            gridEntry.Column(5).Locked = true;
            gridEntry.Column(7).Locked = true;
        }


        private void validation(int col)
        {
            FlexCell.Column column1 = gridEntry.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 2;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MatReqCmbFlag == true)
            {
                FillDataForNewIssue();
            }
        }

        private void FillDataForNewIssue()
        {
            try
            {

                gridEntry.Rows = 1;
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", sc);
                sda.SelectCommand.CommandText = "IssueForEntry";
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@mreqcode", Convert.ToInt32(cmbMatReq.SelectedValue));
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int j = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    gridEntry.Rows = gridEntry.Rows + 1;
                    j = i + 1;
                    gridEntry.Cell(j, 1).Text = ds.Tables[0].Rows[i]["slno"].ToString();
                    gridEntry.Cell(j, 2).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                    gridEntry.Cell(j, 3).Text = ds.Tables[0].Rows[i]["unitDesc"].ToString();
                    gridEntry.Cell(j, 4).Text = ds.Tables[0].Rows[i]["qty"].ToString();
                    gridEntry.Cell(j, 5).Text = ds.Tables[0].Rows[i]["SuppliedQty"].ToString();
                    gridEntry.Cell(j, 6).Text = "0";
                    gridEntry.Cell(j, 7).Text = ds.Tables[0].Rows[i]["BalQty"].ToString();
                    gridEntry.Cell(j, 8).Text = ds.Tables[0].Rows[i]["matcode"].ToString();
                    gridEntry.Cell(j, 9).Text = ds.Tables[0].Rows[i]["unitid"].ToString();
                    gridEntry.Cell(j, 10).Text = "0";
                }
            }
            catch 
            {
            
            
            
            
            }
        }

        private void FillMatReqCmb()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select top 100 matreqCode,matreqDate  from tMatReqHD  order by matreqCode desc";
            sda.SelectCommand.CommandType = CommandType.Text;            
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbMatReq.DataSource = ds.Tables[0];
            cmbMatReq.DisplayMember = "matreqCode";
            cmbMatReq.ValueMember = "matreqCode";
            dictionary = new Dictionary<string, string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dictionary.Add(ds.Tables[0].Rows[i]["matreqCode"].ToString(), ds.Tables[0].Rows[i]["matreqDate"].ToString());
            }

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
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", "MatIssue");
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
            scmd.Parameters.AddWithValue("@scr", "MatIssue");
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            if (btnSave.Text == "Save")
            {
                if (ChkForSave() == true)
                {
                    int IssNo = ReadLastNum();
                    txtIssueNo.Text = IssNo.ToString();
                    SaveInMatIssueDTL(IssNo);
                    SaveInMatIssueHD(IssNo);
                    SaveInMatReq("Yes");
                    btnSave.Enabled = false;
                }
                else
                {
                    MessageBox.Show("All materials issue quantity should not zero");
                }
            }
            else
            {
                Int32  IssNo = Convert.ToInt32(txtIssueNo.Text);
                DeleteMatIssueDtl(IssNo);
                SaveInMatIssueDTL(IssNo);
                UpdateMatIssueHD();
                SaveInMatReq("No");
                btnSave.Enabled = false;
            }
        }

        private void UpdateMatIssueHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMatIssueHD set IssueDate = @IssueDate where IssueNo = @IssueNo";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@IssueNo",Convert.ToInt32 (txtIssueNo.Text ));
            cmd.Parameters.AddWithValue("@IssueDate", dtpIssue.Value);
            cmd.ExecuteNonQuery();
            con.Close();                    
        }

        private void DeleteMatIssueDtl(int issno)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete from  tMatIssueDTL   where IssueNo = @issno";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@issno", Convert.ToInt32(txtIssueNo.Text));
            cmd.ExecuteNonQuery();
            con.Close();                            
        }

        private bool ChkForSave()
        {
            bool ret = false;
            for (int i = 1; i < gridEntry.Rows ; i++)
            {
                if (Convert.ToDouble ( gridEntry.Cell(i, 6).Text) > 0)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }


        private void SaveInMatIssueHD(int issno)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "MatIssueInsertHD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IssueNo", issno);
            cmd.Parameters.AddWithValue("@IssueDate", dtpIssue.Value );
            cmd.Parameters.AddWithValue("@MatReqCode", Convert.ToInt32 (cmbMatReq.SelectedValue ));
            cmd.Parameters.AddWithValue("@ReqDate",dictionary[cmbMatReq.SelectedValue.ToString ()]);
            cmd.ExecuteNonQuery();
            con.Close();            
        }

        private void SaveInMatIssueDTL(int issno)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "MatIssueInsertDTL";
            cmd.CommandType = CommandType.StoredProcedure;                
            for (int i = 1; i < gridEntry.Rows ; i++)
            {
                cmd.Parameters.AddWithValue("@IssueNo", issno);
                cmd.Parameters.AddWithValue("@MatCode", Convert.ToInt32(gridEntry.Cell(i,8).Text));
                cmd.Parameters.AddWithValue("@UnitCode",Convert.ToInt32(gridEntry.Cell(i,9).Text));
                cmd.Parameters.AddWithValue("@ReqQty", Convert.ToDouble (gridEntry.Cell(i,4).Text));
                cmd.Parameters.AddWithValue("@IssuedQty",Convert.ToDouble (gridEntry.Cell(i,5).Text));
                cmd.Parameters.AddWithValue("@IssueQty",Convert.ToDouble (gridEntry.Cell(i,6).Text));
                cmd.Parameters.AddWithValue("@BalQty",Convert.ToDouble (gridEntry.Cell(i,7).Text));                
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();           
        }

        private void SaveInMatReq(string ModeNew)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "UpdateBalQtyInMatReqDtl";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mreqcode", Convert.ToInt32(cmbMatReq.SelectedValue));
            cmd.Parameters.AddWithValue("@ModeNew", ModeNew);
            cmd.ExecuteNonQuery();
            con.Close();             
        }




        private void gridEntry_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            if (e.Row != 0)
            {
                    if (e.Col == 6)
                    {
                        if (colFlag == 1)
                        {
                            colFlag = colFlag * (-1);


                            if (Convert.ToDouble(gridEntry.Cell(e.Row, 6).Text) < 0)
                            {
                                gridEntry.Cell(e.Row, 6).Text = "0";
                            
                            }
                            if (gridEntry.Cell(e.Row, 6).Text.Trim().Length != 0)
                            {
                              
                                    double qr = Convert.ToDouble(gridEntry.Cell(e.Row, 4).Text);
                                    double qisd = Convert.ToDouble(gridEntry.Cell(e.Row, 5).Text);
                                    double qis = Convert.ToDouble(gridEntry.Cell(e.Row, 6).Text);
                                    if (qr < qisd + qis)
                                    {
                                        gridEntry.Cell(e.Row, 6).Text = "0";
                                        gridEntry.Cell(e.Row, 10).Text = "0";
                                        gridEntry.Cell(e.Row, 6).SetFocus();
                                    }
                                    else
                                    {
                                        gridEntry.Cell(e.Row, 7).Text = (qr - (qisd + qis)).ToString();
                                        if (gridEntry.Cell(e.Row, 7).Text == "0")
                                        {
                                            gridEntry.Cell(e.Row, 10).Text = "1";
                                        }
                                        else
                                        {
                                            gridEntry.Cell(e.Row, 10).Text = "0";
                                        }
                                    }
                                
                            }
                            else
                            {
                                gridEntry.Cell(e.Row, 6).Text = "0";
                                gridEntry.Cell(e.Row, 6).SetFocus();
                            }
                        colFlag = colFlag * (-1);

                    }
                }

                    if (e.Col == 10)
                    {
                        if (colFlag == 1)
                        {
                            colFlag = colFlag * (-1);

                            double qr = Convert.ToDouble(gridEntry.Cell(e.Row, 4).Text);
                            double qisd = Convert.ToDouble(gridEntry.Cell(e.Row, 5).Text);
                            double qis = qr - qisd;
                            if (gridEntry.Cell(e.Row, 10).Text == "1")
                            {
                                gridEntry.Cell(e.Row, 6).Text = qis.ToString();
                                gridEntry.Cell(e.Row, 7).Text = "0";
                            }
                            else
                            {
                                gridEntry.Cell(e.Row, 6).Text = "0";
                                gridEntry.Cell(e.Row, 7).Text = qis.ToString();
                            }
                            colFlag = colFlag * (-1);
                        }
                    }
            }
        }


        private void btnShowIssHistory_Click(object sender, EventArgs e)
        {
            gridIssueHDSettings();
            IssueHistoryHD();
            gridIssueDTLSettings();
        }

        private void gridIssueHDSettings()
        {
            gridIssueHistoryHD.Cell(0, 1).Text = "Issue No.";
            gridIssueHistoryHD.Cell(0, 2).Text = "Issue Date";
            gridIssueHistoryHD.Cell(0, 3).Text = "Department";
            gridIssueHistoryHD.Cell(0, 4).Text = "Request No.";
            gridIssueHistoryHD.Cell(0, 5).Text = "Request Date";
            gridIssueHistoryHD.Cell(0, 6).Text = "Can Edit";
            gridIssueHistoryHD.Cell(0, 7).Text = "Sub No.";
            gridIssueHistoryHD.Column(1).CellType = FlexCell.CellTypeEnum.HyperLink;

            gridIssueHistoryHD.Column(1).Width = 60;
            gridIssueHistoryHD.Column(2).Width = 80;
            gridIssueHistoryHD.Column(3).Width = 140;
            gridIssueHistoryHD.Column(4).Width = 70;
            gridIssueHistoryHD.Column(5).Width = 80;
            gridIssueHistoryHD.Column(6).Width = 80;

            gridIssueHistoryHD.Column(1).Locked = true;
            gridIssueHistoryHD.Column(2).Locked = true;
            gridIssueHistoryHD.Column(3).Locked = true;
            gridIssueHistoryHD.Column(4).Locked = true;
            gridIssueHistoryHD.Column(5).Locked = true;
            gridIssueHistoryHD.Column(6).Locked = true;
        }

        private void gridIssueDTLSettings()
        {
            gridIssueHistoryDTL.Cell(0, 1).Text = "SL. No.";
            gridIssueHistoryDTL.Cell(0, 2).Text = "Material ";
            gridIssueHistoryDTL.Cell(0, 3).Text = "Issue Qty";

            gridIssueHistoryDTL.Column(1).Width = 40;
            gridIssueHistoryDTL.Column(2).Width = 200;
            gridIssueHistoryDTL.Column(3).Width = 100;

            gridIssueHistoryDTL.Column(1).Locked = true;
            gridIssueHistoryDTL.Column(2).Locked = true;
            gridIssueHistoryDTL.Column(3).Locked = true;
        }

        private void IssueHistoryHD()
        {
            gridIssueHistoryHD.Rows = 1;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select top 100 A.IssueNo,convert(nvarchar(10),A.IssueDate,103) IssueDate ,C.Department,A.MatReqCode,convert(nvarchar(10),A.ReqDate,103) ReqDate,A.CanEdit,A.IssueSubNo    from tMatIssueHD A,tMatReqHD B,department C where A.MatReqCode = B.matreqCode and B.depid = C.DepId  order by A.IssueNo desc";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridIssueHistoryHD.Rows = gridIssueHistoryHD.Rows + 1;
                j = i + 1;
                gridIssueHistoryHD.Cell(j, 1).Text = ds.Tables[0].Rows[i]["IssueNo"].ToString();
                gridIssueHistoryHD.Cell(j, 2).Text = ds.Tables[0].Rows[i]["IssueDate"].ToString();
                gridIssueHistoryHD.Cell(j, 3).Text = ds.Tables[0].Rows[i]["Department"].ToString();
                gridIssueHistoryHD.Cell(j, 4).Text = ds.Tables[0].Rows[i]["MatReqCode"].ToString();
                gridIssueHistoryHD.Cell(j, 5).Text = ds.Tables[0].Rows[i]["ReqDate"].ToString();
                gridIssueHistoryHD.Cell(j, 6).Text = ds.Tables[0].Rows[i]["CanEdit"].ToString();
                gridIssueHistoryHD.Cell(j, 7).Text = ds.Tables[0].Rows[i]["IssueSubNo"].ToString();                
            }
        }

        private void IssueHistoryDTL(int isno)
        {
            gridIssueHistoryDTL.Rows = 1;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select  row_number() over(order by MatDesc)  slno,B.MatDesc,A.IssueQty  from tMatIssueDTL A,tMaterial B where A.MatCode = B.MatCode and A.IssueNo =@isno and A.IssueQty <> 0";
            sda.SelectCommand.Parameters.AddWithValue("@isno", isno );            
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridIssueHistoryDTL.Rows = gridIssueHistoryDTL.Rows + 1;
                j = i + 1;
                gridIssueHistoryDTL.Cell(j, 1).Text = ds.Tables[0].Rows[i]["slno"].ToString();
                gridIssueHistoryDTL.Cell(j, 2).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                gridIssueHistoryDTL.Cell(j, 3).Text = ds.Tables[0].Rows[i]["IssueQty"].ToString();

            }
        }

        private void gridIssueHistoryHD_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            e.URL = null;
            e.Changed = true;
            int isno = Convert.ToInt32  (gridIssueHistoryHD.Cell(e.Row,e.Col).Text );
            IssueHistoryDTL(isno);
        }

        private void gridIssueHistoryHD_MouseDown(object Sender, MouseEventArgs e)
        {
          
            if (e.Button == MouseButtons.Right)
            {
                if (gridIssueHistoryHD.ActiveCell.Row != 0)
                {
                    contextMenuStrip1.Items[0].Text = "Issue No: " + gridIssueHistoryHD.Cell(gridIssueHistoryHD.ActiveCell.Row, 1).Text ;
                    contextMenuStrip1.Show(gridIssueHistoryHD, new Point(e.X, e.Y));
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string str = e.ClickedItem.Text;
            Int32 issno = Convert.ToInt32(gridIssueHistoryHD.Cell(gridIssueHistoryHD.ActiveCell.Row, 1).Text);
            String canEdit = gridIssueHistoryHD.Cell(gridIssueHistoryHD.ActiveCell.Row, 6).Text.Trim();
            switch (str)
            {
                case  "Edit" :
                    IssueEditHD(issno);
                    IssueEditDTL(issno,canEdit);
                    break;
                case "Delete":
                    if (canEdit  == "No")
                    {
                        MessageBox.Show("can not delete");
                    }
                    else
                    { 
                    
                    }
                    break;
                default :
                    
                    break;
            }
                            
        }

        private void IssueEditHD(Int32 isno)
        {
            txtMatReqNo.Visible = true; ;
            cmbMatReq.Visible = false ;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select IssueDate,MatReqCode  from tMatIssueHD where IssueNo = @issno";
            sda.SelectCommand.Parameters.AddWithValue("@issno", isno);
            DataSet ds = new DataSet();
            sda.Fill(ds);            
            dtpIssue.Value  = Convert.ToDateTime ( ds.Tables[0].Rows[0]["IssueDate"].ToString());
            txtMatReqNo.Text  = ds.Tables[0].Rows[0]["MatReqCode"].ToString();
            txtIssueNo.Text = isno.ToString();
            btnSave.Text = "Update";
        }


        private void IssueEditDTL(Int32 isno,string canedit)
        {            
            gridEntry.Rows = 1;
            if (canedit.Trim() == "No")
            {
                gridEntry.Column(7).Locked = true;
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                gridEntry.Column(7).Locked = false;
            }
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "sIssueDtlFEdit";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@issno", Convert.ToInt32(txtIssueNo.Text));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridEntry.Rows = gridEntry.Rows + 1;
                j = i + 1;
                gridEntry.Cell(j, 1).Text = ds.Tables[0].Rows[i]["slno"].ToString();
                gridEntry.Cell(j, 2).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                gridEntry.Cell(j, 3).Text = ds.Tables[0].Rows[i]["unitDesc"].ToString();
                gridEntry.Cell(j, 4).Text = ds.Tables[0].Rows[i]["qty"].ToString();
                gridEntry.Cell(j, 5).Text = ds.Tables[0].Rows[i]["SuppliedQty"].ToString();
                gridEntry.Cell(j, 6).Text = ds.Tables[0].Rows[i]["Issueqty"].ToString();
                gridEntry.Cell(j, 7).Text = ds.Tables[0].Rows[i]["BalQty"].ToString();
                gridEntry.Cell(j, 8).Text = ds.Tables[0].Rows[i]["matcode"].ToString();
                gridEntry.Cell(j, 9).Text = ds.Tables[0].Rows[i]["unitid"].ToString();
                if (Convert.ToDouble(ds.Tables[0].Rows[i]["BalQty"]) == 0)
                {
                    gridEntry.Cell(j, 10).Text = "1";
                }
                else
                {
                    gridEntry.Cell(j, 10).Text = "0";
                }                
            }            
            tabMain.SelectedTab = tabEntry;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            tabMain.SelectedTab = tabEntry;
            txtMatReqNo.Visible = false;
            cmbMatReq.Visible = true;
            gridEntry.Rows = 1;
            btnSave.Text = "Save";
            btnSave.Enabled = true;
            txtIssueNo.Text = "";


        }

        private void btnShowReq_Click(object sender, EventArgs e)
        {
            gridReqHisHDSettings();
            gridReqHisMatDTLSettings();
            gridReqHisIssSumSettings();
            gridReqHisIssDetailsSettings();
            gridReqHisHDShow();
        }

        private void gridReqHisHDSettings()
        {
            gridReqHisHD.Cell(0, 1).Text = "Request No.";
            gridReqHisHD.Cell(0, 2).Text = "Date";
            gridReqHisHD.Cell(0, 3).Text = "Department";
            gridReqHisHD.Cell(0, 4).Text = "Issued Fully";
            gridReqHisHD.Column(1).CellType = FlexCell.CellTypeEnum.HyperLink ;

            gridReqHisHD.Column(1).Width = 80;
            gridReqHisHD.Column(2).Width = 80;
            gridReqHisHD.Column(3).Width = 120;
            gridReqHisHD.Column(4).Width = 80;

            gridReqHisHD.Column(1).Locked = true;
            gridReqHisHD.Column(2).Locked = true;
            gridReqHisHD.Column(3).Locked = true;
            gridReqHisHD.Column(4).Locked = true;
        }


        private void gridReqHisMatDTLSettings()
        {
            gridReqHisMatDTL.Cell(0, 1).Text = "Sl. No.";
            gridReqHisMatDTL.Cell(0, 2).Text = "Material";
            gridReqHisMatDTL.Cell(0, 3).Text = "Unit";
            gridReqHisMatDTL.Cell(0, 4).Text = "Req. Qty";
            gridReqHisMatDTL.Cell(0, 5).Text = "Bal. Qty";
            
            gridReqHisMatDTL.Column(1).Width = 80;
            gridReqHisMatDTL.Column(2).Width = 200;
            gridReqHisMatDTL.Column(3).Width = 80;
            gridReqHisMatDTL.Column(4).Width = 80;
            gridReqHisMatDTL.Column(5).Width = 80;

            gridReqHisMatDTL.Column(1).Locked = true;
            gridReqHisMatDTL.Column(2).Locked = true;
            gridReqHisMatDTL.Column(3).Locked = true;
            gridReqHisMatDTL.Column(4).Locked = true;
            gridReqHisMatDTL.Column(5).Locked = true;
        }

        private void gridReqHisIssSumSettings()
        {
            gridReqHisIssSum.Cell(0, 1).Text = "Issue No.";
            gridReqHisIssSum.Cell(0, 2).Text = "Issue Date";
            gridReqHisIssSum.Cell(0, 3).Text = "Sub No.";
            
            gridReqHisIssSum.Column(1).Width = 80;
            gridReqHisIssSum.Column(2).Width = 80;
            gridReqHisIssSum.Column(3).Width = 80;
            
            gridReqHisIssSum.Column(1).Locked = true;
            gridReqHisIssSum.Column(2).Locked = true;
            gridReqHisIssSum.Column(3).Locked = true;
  
        }

        private void gridReqHisIssDetailsSettings()
        {
            gridReqHisIssDetails.Cell(0, 1).Text = "Issue No.";
            gridReqHisIssDetails.Cell(0, 2).Text = "Material";
            gridReqHisIssDetails.Cell(0, 3).Text = "Qty.";

            gridReqHisIssDetails.Column(1).Width = 80;
            gridReqHisIssDetails.Column(2).Width = 200;
            gridReqHisIssDetails.Column(3).Width = 80;

            gridReqHisIssDetails.Column(1).Locked = true;
            gridReqHisIssDetails.Column(2).Locked = true;
            gridReqHisIssDetails.Column(3).Locked = true;

        }


        private void gridReqHisHDShow()
        {
            gridReqHisHD.Rows = 1;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select A.matreqCode,CONVERT(nvarchar(10), A.matreqDate,103) matreqDate,B.Department,IssuedFully  from tMatReqHD A , department B where A.DepId = B.DepId order by A.matreqCode desc";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridReqHisHD.Rows = gridReqHisHD.Rows + 1;
                j = i + 1;
                gridReqHisHD.Cell(j, 1).Text = ds.Tables[0].Rows[i]["matreqCode"].ToString();
                gridReqHisHD.Cell(j, 2).Text = ds.Tables[0].Rows[i]["matreqDate"].ToString();
                gridReqHisHD.Cell(j, 3).Text = ds.Tables[0].Rows[i]["Department"].ToString();
                gridReqHisHD.Cell(j, 4).Text = ds.Tables[0].Rows[i]["IssuedFully"].ToString();
            }        
        }

        private void gridReqHisHD_HyperLinkClick(object Sender, FlexCell.Grid.HyperLinkClickEventArgs e)
        {
            e.URL = null;
            e.Changed = true;
            int reqno = Convert.ToInt32(gridReqHisHD.Cell(e.Row, e.Col).Text);
            gridReqHisMatDTLShow(reqno);
            IssueHistorySummary(reqno);
            IssueHistoryDetails(reqno);
            txtDisplayMatReqNo.Text = reqno.ToString();
            if (chbMreq.Checked == true)
            {
                cmbMatReq.SelectedValue = reqno;
                txtMatReqNo.Text = reqno.ToString();
            }
        }

        private void gridReqHisMatDTLShow(Int32 reqno)
        {
            gridReqHisMatDTL.Rows = 1;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "IssueForEntryWithAll";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@mreqcode", reqno);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridReqHisMatDTL.Rows = gridReqHisMatDTL.Rows + 1;
                j = i + 1;
                gridReqHisMatDTL.Cell(j, 1).Text = ds.Tables[0].Rows[i]["slno"].ToString();
                gridReqHisMatDTL.Cell(j, 2).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                gridReqHisMatDTL.Cell(j, 3).Text = ds.Tables[0].Rows[i]["unitDesc"].ToString();
                gridReqHisMatDTL.Cell(j, 4).Text = ds.Tables[0].Rows[i]["qty"].ToString();
                gridReqHisMatDTL.Cell(j, 5).Text = ds.Tables[0].Rows[i]["BalQty"].ToString();
            }     
        }

        private void IssueHistorySummary(Int32 mreqcode)
        {
            gridReqHisIssSum.Rows = 1;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select  A.IssueNo,convert(nvarchar(10),A.IssueDate,103) IssueDate ,A.IssueSubNo  from tMatIssueHD A,tMatReqHD B where A.MatReqCode = B.matreqCode and A.MatReqCode=@mrqno order by IssueSubNo desc";
            sda.SelectCommand.Parameters.AddWithValue("@mrqno", mreqcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridReqHisIssSum.Rows = gridReqHisIssSum.Rows + 1;
                j = i + 1;
                gridReqHisIssSum.Cell(j, 1).Text = ds.Tables[0].Rows[i]["IssueNo"].ToString();
                gridReqHisIssSum.Cell(j, 2).Text = ds.Tables[0].Rows[i]["IssueDate"].ToString();
                gridReqHisIssSum.Cell(j, 3).Text = ds.Tables[0].Rows[i]["IssueSubNo"].ToString();
            }
        }

        private void IssueHistoryDetails(Int32 mreqcode)
        {
            gridReqHisIssDetails.Rows = 1;
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "sHistoryIssDtl";
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@mreqcode", mreqcode);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int j = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gridReqHisIssDetails.Rows = gridReqHisIssDetails.Rows + 1;
                j = i + 1;
                gridReqHisIssDetails.Cell(j, 1).Text = ds.Tables[0].Rows[i]["IssueNo"].ToString();
                gridReqHisIssDetails.Cell(j, 2).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                gridReqHisIssDetails.Cell(j, 3).Text = ds.Tables[0].Rows[i]["IssueQty"].ToString();
            }
        }

        private void tabMain_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabIssueHistory)
            {
                btnSave.Enabled = false;

                          
            }
            if (tabMain.SelectedTab == tabRequestHistory)
            {
                btnSave.Enabled = false;


            }

        }

        private void tabEntry_Click(object sender, EventArgs e)
        {

        }

       
        

    }
}
