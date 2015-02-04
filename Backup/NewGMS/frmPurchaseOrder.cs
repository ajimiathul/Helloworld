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
    public partial class frmPurchaseOrder : Form
    {
        bool flagSuplr = false;
        bool flagQRno = false;
        bool flexFilling = false;
        decimal dec = 0;
        string scr = "PurchaseOrder";

        public frmPurchaseOrder()
        {
            InitializeComponent();
        }
        
        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            flagSuplr = false;
            ShowSupplr();
            flagSuplr = true;
            flagQRno = false;
            ShowQtReq();
            flagQRno = true;
            FlexGridActions();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FlexGridActions()
        {
            AddColumnFlexGrid();
           FillFlexGrid();
        }
        private void AddColumnFlexGrid()
        {
            grid1.Cell(0, 1).Text = "Material";
            grid1.Cell(0, 2).Text = "Performa Inv Date";
            grid1.Cell(0, 3).Text = "PInv Number";
            grid1.Cell(0, 4).Text = "Rate";
            grid1.Cell(0, 5).Text = "Qty";
            grid1.Cell(0, 6).Text = "Tax Percent";
            grid1.Cell(0, 7).Text = "Tax";
            grid1.Cell(0, 8).Text = "Discount";
            grid1.Cell(0, 9).Text = "Amount";
            grid1.Cell(0, 10).Text = "MatCode";
            grid1.Cell(0, 11).Text = "RecId";
            grid1.Column(10).Width = 0; 
            grid1.Column(11).Width = 0;
            grid1.Column(1).Width = 180;
            grid1.Column(2).Width = 110;
            grid1.Column(3).Width = 110;
            grid1.Column(1).Locked = true;
            grid1.Column(2).Locked = true;
            grid1.Column(3).Locked = true;
            grid1.Column(4).Locked = true;
            grid1.Column(7).Locked = true;
            //grid1.Column(8).Locked = true;
            grid1.Column(9).Locked = true;
            grid1.Column(10).Locked = true;
            grid1.Column(3).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            grid1.Column(4).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            grid1.Column(5).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            grid1.Column(6).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            grid1.Column(7).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            grid1.Column(8).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            grid1.Column(9).Alignment = FlexCell.AlignmentEnum.CenterCenter;
            validation(5);
            validation(6);
        }
        private void validation(int col)
        {
            FlexCell.Column column1 = grid1.Column(col);
            column1.Mask = FlexCell.MaskEnum.Numeric;
            column1.DecimalLength = 2;
            
        
        }
        private void FillFlexGrid()
        {
            flexFilling = true;
            grid1.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 = " select A.matcode,B.MatDesc ,A.PINVdate ,A.PINVNo ,A.PIQty ,A.PIRate,A.recid   from tPerformaDTL A,tMaterial B ";
            string s2 = " where A.matcode = B.MatCode and A.QtRqNo =@q1 and A.suppliercode =@s1 and A.status='N' ";
            sda.SelectCommand.CommandText = s1 + s2;
            sda.SelectCommand.Parameters.AddWithValue("@q1", Convert.ToInt32(cmbQtReqNo.SelectedValue));
            sda.SelectCommand.Parameters.AddWithValue("@s1", Convert.ToInt32(cmbSupplr.SelectedValue));  
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grid1.Rows = ds.Tables[0].Rows.Count + 1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grid1.Cell(i + 1, 1).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                if (ds.Tables[0].Rows[i]["PINVdate"] != DBNull.Value)
                {
                    grid1.Cell(i + 1, 2).Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["PINVdate"]).ToShortDateString();
                }
                grid1.Cell(i + 1, 3).Text = ds.Tables[0].Rows[i]["PINVNo"].ToString();
                grid1.Cell(i + 1, 4).Text = ds.Tables[0].Rows[i]["PIRate"].ToString();
                grid1.Cell(i + 1, 5).Text = ds.Tables[0].Rows[i]["PIQty"].ToString();
                grid1.Cell(i + 1, 6).Text = "0";
                grid1.Cell(i + 1, 7).Text = "0";
                grid1.Cell(i + 1, 8).Text = "0";
                grid1.Cell(i + 1, 9).Text = "0";
                grid1.Cell(i + 1, 10).Text = ds.Tables[0].Rows[i]["matcode"].ToString();
                grid1.Cell(i + 1, 11).Text = ds.Tables[0].Rows[i]["recid"].ToString();
            }
            flexFilling = false;
            for (int k = 1; k < grid1.Rows; k++)
            {
                FlexGridEdit(k);
            }
        }
        private void UpInPurchaseOrderHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPurchOrdHD set podate=@dt,POAmt=@POAmt where pono=@pono";
            cmd.Parameters.AddWithValue("@dt", dtpPODate.Value);
            cmd.Parameters.AddWithValue("@pono", txtPurchaseOrderNo.Text);
            cmd.Parameters.AddWithValue("@POAmt", txtInvAmt.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void SaveInPurchaseOrderHD()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tPurchOrdHD(pono,podate,Suppliercode,POAmt,QtReqNo)values(@pono,@podate,@Suppliercode,@POAmt,@QtReqNo)";
            cmd.Parameters.AddWithValue("@pono", txtPurchaseOrderNo.Text);
            cmd.Parameters.AddWithValue("@podate", dtpPODate.Value);
            cmd.Parameters.AddWithValue("@Suppliercode", cmbSupplr.SelectedValue);
            cmd.Parameters.AddWithValue("@POAmt", txtInvAmt.Text );
            cmd.Parameters.AddWithValue("@QtReqNo", cmbQtReqNo.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdInPurchaseOrderDtl()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPurchOrdDtl set qty=@qty,tax=@tax,taxpercent=@taxper,discount=@discount,amount=@amt,balQty=@qty where pono=@pono and matcode=@matcode";
            for (int i = 1; i < grid1.Rows; i++)
            {
                cmd.Parameters.AddWithValue("@pono", txtPurchaseOrderNo.Text);
                cmd.Parameters.AddWithValue("@matcode", Convert.ToInt32(grid1.Cell(i, 10).Text));
                cmd.Parameters.AddWithValue("@Rate", Convert.ToDouble(grid1.Cell(i, 4).Text));
                cmd.Parameters.AddWithValue("@qty", Convert.ToDouble(grid1.Cell(i, 5).Text));
                cmd.Parameters.AddWithValue("@tax", Convert.ToDouble(grid1.Cell(i, 7).Text));
                cmd.Parameters.AddWithValue("@taxper", Convert.ToDouble(grid1.Cell(i, 6).Text));
                cmd.Parameters.AddWithValue("@discount", Convert.ToDouble(grid1.Cell(i, 8).Text));
                cmd.Parameters.AddWithValue("@amt", Convert.ToDouble(grid1.Cell(i, 9).Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
        }

        private void SaveInPurchaseOrderDtl()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert into tPurchOrdDtl(pono,slno,matcode,Rate,qty,tax,taxpercent,discount,amount,QtReqNo,balQty,invQty) values(@pono,@slno,@matcode,@Rate,@qty,@tax,@taxpercent,@discount,@amount,@QtReqNo,@qty,0.00)";
            int j = 1;
            for (int i = 1; i < grid1.Rows; i++)
            {
                cmd.Parameters.AddWithValue("@pono", txtPurchaseOrderNo.Text);
                cmd.Parameters.AddWithValue("@slno", j);
                cmd.Parameters.AddWithValue("@matcode", Convert.ToInt32(grid1.Cell(i, 10).Text));
                cmd.Parameters.AddWithValue("@Rate", Convert.ToDouble(grid1.Cell(i, 4).Text));
                cmd.Parameters.AddWithValue("@qty", Convert.ToDouble(grid1.Cell(i, 5).Text));
                cmd.Parameters.AddWithValue("@tax", Convert.ToDouble(grid1.Cell(i, 7).Text));
                cmd.Parameters.AddWithValue("@taxpercent", Convert.ToDouble(grid1.Cell(i, 6).Text));
                cmd.Parameters.AddWithValue("@discount", Convert.ToDouble(grid1.Cell(i, 8).Text));
                cmd.Parameters.AddWithValue("@amount", Convert.ToDouble(grid1.Cell(i, 9).Text));
                cmd.Parameters.AddWithValue("@QtReqNo", cmbQtReqNo.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                j++;
            }
        }

        private void UpdateLastNum()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "update tNumbers set lastnum=lastnum+1 where screen=@scr";
            scmd.Parameters.AddWithValue("@scr", scr );
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
            scmd.Parameters.AddWithValue("@scr",scr);
            int lnum = Convert.ToInt32(scmd.ExecuteScalar());
            sc.Close();
            return lnum;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                
                if (Convert.ToDouble(txtInvAmt.Text) != 0.0)
                {
                    txtPurchaseOrderNo.Text = ReadLastNum().ToString();
                    SaveInPurchaseOrderHD();
                    SaveInPurchaseOrderDtl();
                    UpdatePerforma();
                    btnSave.Enabled = false;
                    SaveProcess1();
                    DelProcess();
                    SaveProcess2();
                
                    MessageBox.Show("Data Saved");
                }
            }
            else
            {
                UpInPurchaseOrderHD();
                UpdInPurchaseOrderDtl();
                btnSave.Enabled = false;
                MessageBox.Show("Data Updated");
            }
        }

        private void UpdatePerforma()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tPerformaDTL set status = 'Y' where recid = @recid";
            for (int i = 1; i < grid1.Rows; i++)
            {
                cmd.Parameters.AddWithValue("@recid", Convert.ToDouble(grid1.Cell(i, 11).Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        private void ShowQtReq()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct A.QtReqNo  from tPerformaInvoiceHD A where supcode = @supcode  order by QtReqNo desc";
            sda.SelectCommand.Parameters.AddWithValue("@supcode", Convert.ToInt32(cmbSupplr.SelectedValue));
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbQtReqNo.DataSource = ds.Tables[0];
            cmbQtReqNo.DisplayMember = "QtReqNo";
            cmbQtReqNo.ValueMember = "QtReqNo";
        }

        private void ShowSupplr()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select distinct A.supcode,B.SupplierName  from tPerformaInvoiceHD A,tSupplier B where A.supcode = B.Suppliercode ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSupplr.DataSource = ds.Tables[0];
            cmbSupplr.DisplayMember = "SupplierName";
            cmbSupplr.ValueMember = "supcode";
        }

        private void cmbSupplr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagSuplr == true)
            {
                ShowQtReq();                
            }
        }

        private void cmbQtReqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagQRno == true)
            {
                FillFlexGrid();
            }
        }

        private void CalculateTotal()
        {
            double InvAmt = 0.0;
            for (int i = 1; i < grid1.Rows; i++)
            {
                InvAmt = InvAmt + Convert.ToDouble(grid1.Cell(i, 9).Text);
            }
            txtInvAmt.Text = InvAmt.ToString();
        }        

        private void showPOList()
        {
            dgvPO.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.pono,convert(nvarchar(10), A.podate,103) podate,B.SupplierName,A.Suppliercode,A.POAmt,A.QtReqNo from tPurchOrdHD A,tSupplier B where A.Suppliercode =B.Suppliercode order by pono desc  ";             
            DataSet ds = new DataSet();
            sda.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvPO.Rows.Add(1);
                int k = dgvPO.Rows.Count;
                dgvPO.Rows[k-1].Cells["pono"].Value = ds.Tables[0].Rows[i]["pono"];
                dgvPO.Rows[k - 1].Cells["podate"].Value =ds.Tables[0].Rows[i]["podate"];
                dgvPO.Rows[k - 1].Cells["supnm"].Value = ds.Tables[0].Rows[i]["SupplierName"];
                dgvPO.Rows[k - 1].Cells["supcod"].Value = ds.Tables[0].Rows[i]["Suppliercode"];
                dgvPO.Rows[k - 1].Cells["poamt"].Value = ds.Tables[0].Rows[i]["POAmt"];
                dgvPO.Rows[k - 1].Cells["qtnum"].Value = ds.Tables[0].Rows[i]["QtReqNo"];
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showPOList();
        }

        private void defOther()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter("", sc);
            SqlDataAdapter sda1 = new SqlDataAdapter("", sc);
            sda.SelectCommand.CommandText = "select ourref,delivery,payment from POdefaultdetail";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtref.Text = ds.Tables[0].Rows[0]["ourref"].ToString();

                txtdelivery.Text = ds.Tables[0].Rows[0]["delivery"].ToString();
                txtpayment.Text = ds.Tables[0].Rows[0]["payment"].ToString();


            }
            sc.Close();
        }

        //private void btrestoredefault_Click(object sender, EventArgs e)
        //{

        //    SqlConnection sc = new SqlConnection();
        //    sc.ConnectionString = clsDbForReports.constr;
        //    sc.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter("", sc);
        //    SqlDataAdapter sda1 = new SqlDataAdapter("", sc);
        //    sda.SelectCommand.CommandText = "select ourref,delivery,payment from POdefaultdetail";
        //    sda1.SelectCommand.CommandText = "select CONDITIONS from tdefPOcondition";
        //    DataSet ds1 = new DataSet();
        //    sda1.Fill(ds1);
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        txtref.Text = ds.Tables[0].Rows[0]["ourref"].ToString();

        //        txtdelivery.Text = ds.Tables[0].Rows[0]["delivery"].ToString();
        //        txtpayment.Text = ds.Tables[0].Rows[0]["payment"].ToString();


        //    }
        //    if (ds1.Tables[0].Rows.Count > 0)
        //    {
        //        dataGridView1.DataSource = ds1.Tables[0];
        //    }
        //    dataGridView1.Columns[0].Width = 600;
        //}     

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    SaveProcess1();
        //    DelProcess();
        //    SaveProcess2();
        //}

        private void DelProcess()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "delete tpocondition where pono=@pono";
            scmd.CommandType = CommandType.Text;
            scmd.Parameters.AddWithValue("@pono", txtPurchaseOrderNo.Text);
            scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void SaveProcess2()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "insert into tpocondition values(@pono,@cond)";
            scmd.CommandType = CommandType.Text;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Length != 0)
                {
                    scmd.Parameters.AddWithValue("@pono", txtPurchaseOrderNo.Text);
                    string str = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    scmd.Parameters.AddWithValue("@cond", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    scmd.ExecuteNonQuery();
                    scmd.Parameters.Clear();
                }
            }
            sc.Close();
        }

        private void SaveProcess1()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = clsDbForReports.constr;
            sc.Open();
            SqlCommand scmd = new SqlCommand("", sc);
            scmd.CommandText = "defaultdetailPurchaseorder";
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@ourref", txtref.Text);
            scmd.Parameters.AddWithValue("@delivery", txtdelivery.Text);
            scmd.Parameters.AddWithValue("@payment", txtpayment.Text);
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{

            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        string value = cell.Value.ToString();
            //        scmd.Parameters.AddWithValue("@cond", txtref.Text);
            //    }
            //}
            scmd.Parameters.AddWithValue("@pono1", txtPurchaseOrderNo.Text);
            int i = scmd.ExecuteNonQuery();
            sc.Close();
        }

        private void FlexGridEdit(int row)
        {
            if (row != 0 && flexFilling == false)
            {
                if (decimal.TryParse(grid1.Cell(row, 5).Text, out dec) != true)
                {
                    grid1.Cell(row, 5).Text = "0";
                }
                if (decimal.TryParse(grid1.Cell(row, 4).Text, out dec) != true)
                {
                    grid1.Cell(row, 4).Text = "0";
                }
                if (decimal.TryParse(grid1.Cell(row, 6).Text, out dec) != true)
                {
                    grid1.Cell(row, 6).Text = "0";
                }
                double amt0 = (Convert.ToDouble(grid1.Cell(row, 5).Text) * Convert.ToDouble(grid1.Cell(row, 4).Text));
                double tx = amt0 * (Convert.ToDouble(grid1.Cell(row, 6).Text) / 100);
                grid1.Cell(row, 7).Text = tx.ToString();
                grid1.Cell(row, 9).Text = ((amt0 + tx) - Convert.ToDouble(grid1.Cell(row, 8).Text)).ToString ();
                CalculateTotal();
            }
        }

        private void grid1_CellChange(object Sender, FlexCell.Grid.CellChangeEventArgs e)
        {
            FlexGridEdit(e.Row);
        }

        private void dgvPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                flexFilling = true;
                CellDoubleClick(e.RowIndex);
                flexFilling = false;
                CalculateTotal();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dtpPODate.Value = Convert.ToDateTime(dgvPO.Rows[e.RowIndex].Cells[1].Value.ToString());
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");                
            }
        }

        private void CellDoubleClick(int rowNum)
        {
            grid1.Rows = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            string s1="select C.suppliercode,A.matcode,convert(nvarchar(10),C.PINVdate,103) pinvdate ,C.PINVNo,B.MatDesc,A.Rate,qty,taxpercent,tax,discount,amount ";
            string s2="from tPurchOrdDtl A ";
            string s3="inner join tMaterial B on A.matcode=B.MatCode ";
            string s4="inner join tPerformaDTL C on C.QtRqNo=A.QtReqNo and C.matcode=A.matcode ";
            string s5 = "where pono=@pono and C.QtRqNo=@QtRqNo and C.suppliercode=@supcod ";
            SqlDataAdapter sda = new SqlDataAdapter("",con);
            sda.SelectCommand.CommandText = s1 + s2 + s3 + s4 + s5;
            sda.SelectCommand.Parameters.AddWithValue("@pono", dgvPO.Rows[rowNum].Cells["pono"].Value);
            sda.SelectCommand.Parameters.AddWithValue("@QtRqNo", dgvPO.Rows[rowNum].Cells["qtnum"].Value);
            sda.SelectCommand.Parameters.AddWithValue("@supcod", dgvPO.Rows[rowNum].Cells["supcod"].Value);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSupplr.Visible = false;
            cmbQtReqNo.Visible = false;
            txtPurchaseOrderNo.Text=dgvPO.Rows[rowNum].Cells["pono"].Value.ToString();
            txtReqNo.Text=dgvPO.Rows[rowNum].Cells["qtnum"].Value.ToString();
            txtSupplier.Text = dgvPO.Rows[rowNum].Cells["supnm"].Value.ToString();
            grid1.Rows = ds.Tables[0].Rows.Count+1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                grid1.Cell(i + 1, 1).Text = ds.Tables[0].Rows[i]["MatDesc"].ToString();
                grid1.Cell(i + 1, 2).Text =Convert.ToDateTime(ds.Tables[0].Rows[i]["PINVdate"]).ToShortDateString();
                grid1.Cell(i + 1, 3).Text = ds.Tables[0].Rows[i]["PINVNo"].ToString();
                grid1.Cell(i + 1, 4).Text = ds.Tables[0].Rows[i]["Rate"].ToString();
                grid1.Cell(i + 1, 5).Text = ds.Tables[0].Rows[i]["qty"].ToString();
                grid1.Cell(i + 1, 6).Text = ds.Tables[0].Rows[i]["taxpercent"].ToString();
                grid1.Cell(i + 1, 7).Text = ds.Tables[0].Rows[i]["tax"].ToString();
                grid1.Cell(i + 1, 8).Text = ds.Tables[0].Rows[i]["discount"].ToString();
                grid1.Cell(i + 1, 9).Text = ds.Tables[0].Rows[i]["amount"].ToString();
                grid1.Cell(i + 1, 10).Text = ds.Tables[0].Rows[i]["MatCode"].ToString();
            }
            tabControl1.SelectedTab = MatInfo;
            btnSave.Text = "Update";
        }
        private void ClearAll()
        {
            btnSave.Text = "Save";
            cmbQtReqNo.Visible = true;
            cmbSupplr.Visible = true;
            txtPurchaseOrderNo.Clear();
            grid1.Rows = 1;
            txtInvAmt.Clear();
            ShowSupplr();
            ShowQtReq();
            FlexGridActions();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
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
        private void txtInvAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = OnlyDecimalNum(e.KeyChar, txtInvAmt.Text);
        }

        private void PrintInfo_Click(object sender, EventArgs e)
        {

        }

        private void lnllbldefcond_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            frmdefcondition obj = new frmdefcondition();
            obj.ShowDialog();
            Filldatagridconditions();
            defOther();
        }
        private void Filldatagridconditions()
        {
           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Conditions from tdefPoCondTemp";
           
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                //dataGridView1.DataSource = ds.Tables[0];
            }
            
        }

        private void btrestoredefault_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
