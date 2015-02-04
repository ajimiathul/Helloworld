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
    public partial class frmMaterial : Form
    {
        public frmMaterial()
        {
            InitializeComponent();
        }

        bool unitflag = false;
        string mode = "new";
        string MainMode = "new";
        bool ProValflag = false;
        Int32 Xvalue = 0;
        Int32 GMatCode = 0;

        private void frmMaterial_Load(object sender, EventArgs e)
        {
            ProValflag = false;
            BaseMatCmb();
            PropertyCmb();
            ProValflag = true ;
            ProValCmb();
            UnitCombo();
            unitflag = true;
            ShowInGrid();
            mode = "new";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MainMode == "new")
            {
                if ((CheckDupNew() == 0) && dgvProperties.Rows.Count > 0)
                {
                    SaveInMaterial();
                    GMatCode = ReadGMatCode();
                    CreateInStructureLoop();
                }
                else
                {
                    MessageBox.Show("Data Already Exist");
                }
            }
            else
            {
                if ((CheckDupNew() == GMatCode || CheckDupNew() == 0) && dgvProperties.Rows.Count > 0)
                {
                    UpdateInMaterial();
                    UpdateInMaterialInWareHouse();
                    DeleteInStructure();
                    CreateInStructureLoop();
                }
                else
                {
                    MessageBox.Show("Another Data Already Exist");
                }
            }
            btnSave.Text = ">>";
            cmbBM.Enabled = true;
            dgvProperties.Rows.Clear();
            MainMode = "new";
            ShowInGrid();
        }

        private void CreateInStructureLoop()
        {            
             Int32 lsno = 0;
             Int32 lpc = 0;
             Int32 lvc = 0;
             for (int i = 0; i < dgvProperties.Rows.Count; i++)
             {
                 lsno = Convert.ToInt32(dgvProperties.Rows[i].Cells["colnum"].Value);
                 lpc = Convert.ToInt32(dgvProperties.Rows[i].Cells["colProCode"].Value);
                 lvc = Convert.ToInt32(dgvProperties.Rows[i].Cells["colValCode"].Value);
                 CreateStructure(lsno, lpc, lvc);
             }
        }

        private void CreateStructure(Int32 lsno,Int32 lpc,Int32 lvc)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "insert  tMaterialStructure(slno,MaterialCode,BaseMaterialCode,PropertyCode,ValueCode,stCode) values(@sno,@mc,@bmc,@pc,@vc,@sc) ";
            cmd.Parameters.AddWithValue("@sno", lsno );
            cmd.Parameters.AddWithValue("@mc",GMatCode  );
            cmd.Parameters.AddWithValue("@bmc",Convert.ToInt32 (cmbBM.SelectedValue ) );
            cmd.Parameters.AddWithValue("@pc",lpc  );
            cmd.Parameters.AddWithValue("@vc",lvc  );
            string SC = cmbBM.SelectedValue + "-" + lpc.ToString() + "-" + lvc.ToString();
            cmd.Parameters.AddWithValue("@sc", SC);
            cmd.ExecuteNonQuery();
            con.Close();                
        }

        private void DeleteInStructure()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "delete tMaterialStructure where MaterialCode=@id";
            cmd.Parameters.AddWithValue("@id", GMatCode);
            cmd.ExecuteNonQuery();
            con.Close();        
        }

        private Int32  ReadGMatCode()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select lastnum from tNumbers where screen = 'Material'";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return  Convert.ToInt32 (ds.Tables[0].Rows[0][0].ToString());    
        }


        private void UnitCombo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Unit,UnitId from UnitMaster order by unit";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbLUUnit.DataSource = ds.Tables[0];
            cmbLUUnit.DisplayMember = "Unit";
            cmbLUUnit.ValueMember = "UnitId";
        }


        private void BaseMatCmb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select BaseMaterial,BaseMaterialCode from tBaseMaterial order by BaseMaterial";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbBM .DataSource = ds.Tables[0];
            cmbBM .DisplayMember = "BaseMaterial";
            cmbBM .ValueMember = "BaseMaterialCode";
        }

        private void PropertyCmb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select Property,PropertyCode from tMaterialProperty order by Property";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbPro .DataSource = ds.Tables[0];
            cmbPro .DisplayMember = "Property";
            cmbPro .ValueMember = "PropertyCode";
        }


        private void ProValCmb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select PropertyValueCode,PropertyValue from tMaterialPropertyValue where PropertyCode =@pc order by PropertyValue";
            sda.SelectCommand.Parameters.AddWithValue("@pc",Convert.ToInt32 ( cmbPro.SelectedValue) );
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbVal .DataSource = ds.Tables[0];
            cmbVal .DisplayMember = "PropertyValue";
            cmbVal .ValueMember = "PropertyValueCode";
        }


     
       
        private void SaveInMaterial()
        {           
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = "CreateMaterial";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@scr", "Material");
                cmd.Parameters.AddWithValue("@bmc", Convert.ToInt32(cmbBM.SelectedValue));
                cmd.Parameters.AddWithValue("@matdes", txtMaterial.Text);
                cmd.Parameters.AddWithValue("@unit", cmbLUUnit.SelectedValue);
                cmd.Parameters.AddWithValue("@rate", Convert.ToDouble(txtRate.Text));
                cmd.Parameters.AddWithValue("@opstock", Convert.ToDouble(txtOpeningStock.Text));
                cmd.Parameters.AddWithValue("@level", Convert.ToDouble(txtReorderLevel.Text));
                cmd.ExecuteNonQuery();
                con.Close();            
        }


        private void ReverseStock()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tWarehouseMatStock set closingStock=closingStock-OpStock, OpStock=0 where MatCode=@id";
            cmd.Parameters.AddWithValue("@id", GMatCode);
            cmd.Parameters.AddWithValue("@stock", txtOpeningStock.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
        private void UpdateInMaterialInWareHouse()
        {
            ReverseStock();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tWarehouseMatStock set OpStock=@stock,closingStock=closingStock+@stock where MatCode=@id";
            cmd.Parameters.AddWithValue("@id", GMatCode);
            cmd.Parameters.AddWithValue("@stock", txtOpeningStock.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        private void UpdateInMaterial()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            con.Open();
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandText = "update tMaterial set MatDesc=@mname,unitCode=@unit,Rate=@rate,ReorderLevel=@level where MatCode=@id";
            cmd.Parameters.AddWithValue("@id", GMatCode );
            cmd.Parameters.AddWithValue("@mname", txtMaterial.Text);           
            cmd.Parameters.AddWithValue("@unit", cmbLUUnit.SelectedValue);           
            cmd.Parameters.AddWithValue("@rate", txtRate.Text);                        
            cmd.Parameters.AddWithValue("@level", txtReorderLevel.Text);            
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private int CheckDupNew()
        {          
            Int32 dup = 0;
            if (dgvProperties.Rows.Count > 0)
            {
                string CodeString = "";               
                for (int i = 0; i < dgvProperties.Rows.Count; i++)
                {
                    CodeString = CodeString + cmbBM.SelectedValue + "-"+  dgvProperties.Rows[i].Cells["colProCode"].Value + "-" + dgvProperties.Rows[i].Cells["colValCode"].Value + ",";
                }
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = clsDbForReports.constr;
                SqlDataAdapter sda = new SqlDataAdapter("", con);
                sda.SelectCommand.CommandText = "MatNewChk";
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;                
                sda.SelectCommand.Parameters.AddWithValue("@CodeString", CodeString);        
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dup = Convert.ToInt32(ds.Tables[0].Rows[0]["MaterialCode"].ToString());                    
                }
                else
                {
                    dup = 0;
                }
            }
            return dup;
        }

        private void ShowInGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select A.MatCode,A.MatDesc, A.Rate,C.opstock ,A.ReorderLevel, B.unit,A.unitcode,A.BaseMatCode,c.closingStock from tMaterial A,UnitMaster B,tWarehouseMatStock C where A.unitcode=B.unitid and A.MatCode = C.matcode and C.warehousecode in (1,2) order by A.matcode desc ";
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgvMaterial.DataSource = ds.Tables[0];
            dgvMaterial.Columns[0].Visible = false;
            dgvMaterial.Columns[1].Width = 220;
            dgvMaterial.Columns[2].Width = 70;
            dgvMaterial.Columns[3].Width = 70;
            dgvMaterial.Columns[4].Width = 70;
            dgvMaterial.Columns[5].Width = 70;
            dgvMaterial.Columns[6].Visible = false;
            dgvMaterial.Columns[7].Visible = false;
            dgvMaterial.Columns[8].Width = 70;
        }

        private void EditPropertiesGrid(Int32 lmc)
        {
            cmbPro.Text = "";
            cmbVal.Text = "";
            dgvProperties.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            string s1 ="select A.slno,A.PropertyCode,B.Property,A.ValueCode,C.PropertyValue from tMaterialStructure A,tMaterialProperty B,tMaterialPropertyValue C ";
            string s2 = " where A.PropertyCode = B.PropertyCode and A.ValueCode = C.PropertyValueCode and A.MaterialCode = @mc order by slno";
            sda.SelectCommand.CommandText = s1 + s2;
            sda.SelectCommand.Parameters.AddWithValue("@mc", lmc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int x = 0;
            for (int i = 0; i < ds.Tables [0].Rows.Count  ; i++)
            {
                dgvProperties.Rows.Add(1);
                x = dgvProperties.Rows.Count;
                dgvProperties.Rows[x-1].Cells["colnum"].Value = ds.Tables[0].Rows[i]["slno"];
                dgvProperties.Rows[x-1].Cells["colProCode"].Value = ds.Tables[0].Rows[i]["PropertyCode"];
                dgvProperties.Rows[x-1].Cells["colProperty"].Value = ds.Tables[0].Rows[i]["Property"];
                dgvProperties.Rows[x-1].Cells["colValCode"].Value = ds.Tables[0].Rows[i]["ValueCode"];
                dgvProperties.Rows[x-1].Cells["colVal"].Value = ds.Tables[0].Rows[i]["PropertyValue"];
                cmbPro.SelectedValue = ds.Tables[0].Rows[i]["PropertyCode"];
                cmbVal.SelectedValue = ds.Tables[0].Rows[i]["ValueCode"];
            }        
        }

        private void dgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaterial.Rows.Count >= 1)
            {
                string rVal = frmCustomMsgBox2.ShowBox();
                if (rVal == "New")
                {
                   MainMode  = "new";
                   btnSave.Text = ">>";
                   cmbBM.Enabled = true;
                   dgvProperties.Rows.Clear();
                }
                else if (rVal == "Edit")
                {
                    if (e.RowIndex  != -1)
                    {
                        cmbBM.Enabled = false;
                        MainMode  = "edit";
                        GMatCode = Convert.ToInt32 (dgvMaterial.Rows[e.RowIndex].Cells["MatCode"].Value);
                        cmbBM.SelectedValue = dgvMaterial.Rows[e.RowIndex].Cells[7].Value.ToString();
                        txtMaterial.Text = dgvMaterial.Rows[e.RowIndex].Cells[1].Value.ToString ();
                        txtRate.Text = dgvMaterial.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtOpeningStock.Text = dgvMaterial.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtReorderLevel.Text = dgvMaterial.Rows[e.RowIndex].Cells[4].Value.ToString();
                        cmbLUUnit.SelectedValue = dgvMaterial.Rows[e.RowIndex].Cells[6].Value.ToString();
                        EditPropertiesGrid(GMatCode);
                        btnSave.Text = "Update";
                    }
                }
                else if (rVal == "Delete")
                {
                    MessageBox.Show("Not allowed");
                    MainMode = "new";
                    btnSave.Text = ">>";
                    cmbBM.Enabled = true;
                    dgvProperties.Rows.Clear();

                }
                else
                {
                    MainMode = "new";
                    btnSave.Text = ">>";
                    cmbBM.Enabled = true;
                    dgvProperties.Rows.Clear();

                }
            } 
        }

            

        private bool CheckDupEdit()
        {
            bool dup = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constr;
            SqlDataAdapter sda = new SqlDataAdapter("", con);
            sda.SelectCommand.CommandText = "select MatCode from tMaterial where MatDesc=@mat and MatCode<>@id";
            sda.SelectCommand.Parameters.AddWithValue("@mat", txtMaterial.Text);
            sda.SelectCommand.Parameters.AddWithValue("@id", GMatCode );
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dup = true;
                MessageBox.Show("Data Already Exist");
            }
            return dup;
        }

        

        private void cmbPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProValflag == true)
            {
                ProValCmb();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mode == "new")
            {
                Add();
                CreateName();
            }
            else
            {
                UpdateGrid();
                CreateName();
            }
            btnAdd.Text = ">>";
            mode = "new";
        }

        private void CreateName()
        {
            txtMaterial.Text = cmbBM.Text;
            for (int i = 0; i < dgvProperties.Rows.Count; i++)
            {
                txtMaterial.Text = txtMaterial.Text + " " + dgvProperties.Rows[i].Cells["colVal"].Value.ToString();                
            }        
        }

        private void Add()
        {
            if (NewDup() == false)
            {
                dgvProperties.Rows.Add(1);
                int x = dgvProperties.Rows.Count;
                if (x >= 1)
                {
                    cmbBM.Enabled = false;
                }
                else
                {
                    cmbBM.Enabled = true;
                }
                dgvProperties.Rows[x - 1].Cells["colnum"].Value = x.ToString();                
                dgvProperties.Rows[x - 1].Cells["colProCode"].Value = cmbPro.SelectedValue;
                dgvProperties.Rows[x - 1].Cells["colProperty"].Value = cmbPro.Text;
                dgvProperties.Rows[x - 1].Cells["colValCode"].Value = cmbVal.SelectedValue;
                dgvProperties.Rows[x - 1].Cells["colVal"].Value = cmbVal.Text;
            }
            else
            {
                MessageBox.Show("Already Exist");
            }
        
        }

        private void UpdateGrid()
        { 
            if (EditDup() == false)
            {
                dgvProperties.Rows[Xvalue-1].Cells["colProCode"].Value = cmbPro.SelectedValue;
                dgvProperties.Rows[Xvalue-1].Cells["colProperty"].Value = cmbPro.Text;
                dgvProperties.Rows[Xvalue-1].Cells["colValCode"].Value = cmbVal.SelectedValue;
                dgvProperties.Rows[Xvalue-1].Cells["colVal"].Value = cmbVal.Text;
            }
            else
            {
                MessageBox.Show("Already Exist for another property");
            }

        }

                                
        private bool NewDup()
        {
            bool ret = false;
            for (int i = 0; i < dgvProperties.Rows.Count; i++)
            {
                if (dgvProperties.Rows[i].Cells["colProCode"].Value.ToString() == cmbPro.SelectedValue.ToString() && dgvProperties.Rows[i].Cells["colValCode"].Value.ToString() == cmbVal.SelectedValue.ToString())
                {
                    ret = true;
                }
                else
                {
                    if (dgvProperties.Rows[i].Cells["colProCode"].Value.ToString() == cmbPro.SelectedValue.ToString())
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        
        private bool EditDup()
        {
            bool ret = false;
            for (int i = 0; i < dgvProperties.Rows.Count; i++)
            {
                if (dgvProperties.Rows[i].Cells["colProCode"].Value.ToString() == cmbPro.SelectedValue.ToString() && dgvProperties.Rows[i].Cells["colValCode"].Value.ToString() == cmbVal.SelectedValue.ToString())
                {

                    if (dgvProperties.Rows[i].Cells["colnum"].Value.ToString() != Xvalue.ToString())
                    {
                        ret = true;
                    }
                }
                else
                {
                    if (dgvProperties.Rows[i].Cells["colProCode"].Value.ToString() == cmbPro.SelectedValue.ToString())
                    {
                        if (dgvProperties.Rows[i].Cells["colnum"].Value.ToString() != Xvalue.ToString())
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }


        private void dgvProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProperties .Rows.Count >= 1)
            {
                string rVal = frmCustomMsgBox2.ShowBox();
                int DtlRowIndex = e.RowIndex;
                if (rVal == "New")
                {
                    mode = "new";
                    btnAdd.Text = ">>";
                }
                else if (rVal == "Edit")
                {
                    if (DtlRowIndex != -1)
                    {                        
                        mode = "edit";
                        Xvalue = Convert.ToInt32 ( dgvProperties.Rows[DtlRowIndex].Cells["colnum"].Value) ;
                        cmbPro.SelectedValue = dgvProperties.Rows[DtlRowIndex].Cells["colProCode"].Value ;                     
                        cmbVal.SelectedValue = dgvProperties.Rows[DtlRowIndex].Cells["colValCode"].Value ;
                        btnAdd.Text = "Update";
                    }
                }
                else if (rVal == "Delete")
                {
                    dgvProperties.Rows.RemoveAt(e.RowIndex);
                    int x = dgvProperties.Rows.Count;
                    if (x >= 1)
                    {
                        cmbBM.Enabled = false;
                    }
                    else
                    {
                        cmbBM.Enabled = true;
                    }
                    mode = "new";
                    btnAdd.Text = ">>";
                }
                else
                {
                    mode = "new";
                    btnAdd.Text = ">>";
                }
            }
        }

        
    }
}
