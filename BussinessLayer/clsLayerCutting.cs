using System;
using System.Collections;
using System.Data;
using DataAccessLayer;

namespace BussinessLayer
{
   public class clsLayerCutting
    {
        public int compcode ;
        public int loccode ;
        public decimal LayerBatchNo;
        public DateTime CutDate  ;
        public string JobOrderNo ;
        public string StyleCode ;
        public decimal AVGConsumption;
        public int PCSPerBundle;
        public int MerchandiserCode ;
        public int CuttingMasterCode ;
        public int QCHeadCode ;
       
        public decimal RatioExtraPercentage;
        public int createdby ;
        public int modifiedby;
        public DateTime createdDate  ;
        public DateTime modifiedDate  ;
        public string TransferFlag ;
        public string DeletedSataus;
        public Int16  CanGenerateBundle;
        public Int16 BundleCreated;

       public decimal  BundleStartNo ;
       public decimal  BundleEndNo ;

        public int SlNo;
        public int FabricCode;
        public string RollNumber;
        public decimal FabricInMTR;
        public decimal PcsToMake;
        public decimal OrdQty;
        public decimal Average;
        public decimal ExtraQty;      
        public decimal ConsumedFabric;
        public decimal BalanceFabric;
           
        public int DTLSlno;
        public int BundleSlno;
        public string BundleNo;
        public string ProductNo;
        public string BunLetter;
        public string BunNoWoletter;
        public int BunSubSlno;
        public string FabColor;
        public int bunIntNo;
        public int bunQty;
        public string bunRange;
        public string BunNoMethod;

        public DataSet GetIC(string ic)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add ("@ic",ic);
                ds = obj.GetData("sItemsFCLike", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetICSuplr(string icode)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@ic", icode);
                ds = obj.GetData("sSuplrFC", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetSC(string sc)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@sc", sc);
                ds = obj.GetData("sStyleFC", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

       

        public DataSet sBundleNumberFC()
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            try
            {                
                ds = obj.GetData("sBundleNumberFC", null);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetCategory()
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            try
            {
                ds = obj.GetData("scategoryFC", null);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetSubCategory(string cid)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@cid", cid);
                ds = obj.GetData("sSubcategoryFC", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetSizeType(string sid)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@sid", sid);
                ds = obj.GetData("sSizetypeFC", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetFabWidth(string szid)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@szid", szid);
                ds = obj.GetData("sFabwidthFC", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetSelectedFabWidth(string fid)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@fid", fid);
                ds = obj.GetData("sFabwidthFT", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet GetSubCategoryForPcsPerBundle(string sid)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@sid", sid);
                ds = obj.GetData("sSubcategorySelection", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet sQC()
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            try
            {
                ds = obj.GetData("sMerchandiser", null);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet sMerchandiser()
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            try
            {
                ds = obj.GetData("sMerchandiser", null);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        public DataSet sCutting()
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            try
            {
                ds = obj.GetData("sMerchandiser", null);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }

        

        public DataSet ShowLastBundleNo(string scode)
        {
            clsDB obj = new clsDB();
            string errMsg = "";
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("@scode", scode);
                ds = obj.GetData("sSeriesCode", ht);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
            return ds;
        }


        public void   InsertLayCutHD()
        {      
            string errMsg = "";
            clsDB obj = new clsDB();
            SortedList sl = new SortedList();
            Int32 i = 0;
            try
            {
                sl.Add("@LayerBatchNo", LayerBatchNo);
                sl.Add("@compcode", compcode);
                sl.Add("@loccode", loccode);
                sl.Add("@BunNoMethod", BunNoMethod);
                sl.Add("@CutDate", CutDate);
                sl.Add("@JobOrderNo",  JobOrderNo);
                sl.Add("@StyleCode", StyleCode);
                sl.Add("@AVGConsumption", AVGConsumption);
                sl.Add("@PCSPerBundle", PCSPerBundle);
                sl.Add("@MerchandiserCode", MerchandiserCode);
                sl.Add("@CuttingMasterCode", CuttingMasterCode);
                sl.Add("@QCHeadCode", QCHeadCode);                
                sl.Add("@BundleStartNo", BundleStartNo);
                sl.Add("@BundleEndNo", BundleEndNo);                         
                sl.Add("@createdby", createdby);
                sl.Add("@modifiedby", modifiedby);
                sl.Add("@createdDate", createdDate);
                sl.Add("@modifiedDate", modifiedDate);
                sl.Add("@TransferFlag", TransferFlag);
                sl.Add("@DeletedSataus", DeletedSataus);
                sl.Add("@CanGenerateBundle", CanGenerateBundle);
                sl.Add("@BundleCreated", BundleCreated);
                i = obj.ExecuteNonQuery("iLayerCutHD", sl);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }            
        }


       public void InsertLayCutDTL()
        {      
            string errMsg = "";
            clsDB obj = new clsDB();
            SortedList sl = new SortedList();
            Int32 i = 0;
            try
            {   
                sl.Add("@compcode", compcode);
                sl.Add("@loccode", loccode);
                sl.Add("@LayerBatchNo", LayerBatchNo);
                sl.Add("@CutDate", CutDate);
                sl.Add("@SlNo", SlNo);
                sl.Add("@FabricCode", FabricCode);
                sl.Add("@RollNumber", RollNumber);
                sl.Add("@FabColor", FabColor);
                sl.Add("@FabricInMTR", FabricInMTR);
                sl.Add("@PcsToMake", PcsToMake);
                sl.Add("@OrdQty", OrdQty);
                sl.Add("@Average", Average);
                sl.Add("@ExtraQty", ExtraQty);               
                sl.Add("@ConsumedFabric", ConsumedFabric);
                sl.Add("@BalanceFabric", BalanceFabric);                           
                sl.Add("@createdby", createdby);
                sl.Add("@modifiedby", modifiedby);
                sl.Add("@createdDate", createdDate);
                sl.Add("@modifiedDate", modifiedDate);
                sl.Add("@TransferFlag", TransferFlag);
                sl.Add("@sc",StyleCode); 
                i = obj.ExecuteNonQuery("iLayerCutDTL", sl);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                obj = null;
            }
        }

       
       public void InsertLayCutBundle()
       {
           string errMsg = "";
           clsDB obj = new clsDB();
           SortedList sl = new SortedList();
           Int32 i = 0;
           try
           {
               sl.Add("@compcode", compcode);
               sl.Add("@loccode", loccode);
               sl.Add("@LayerBatchNo", LayerBatchNo);
               sl.Add("@CutDate", CutDate);
               sl.Add("@DTLSlno", DTLSlno);
               sl.Add("@BundleSlno", BundleSlno);
               sl.Add("@BunSubSlno", BunSubSlno);
               sl.Add("@BunLetter", BunLetter);
               sl.Add("@BunNoWOLetter", BunNoWoletter);
               sl.Add("@BundleNo", BundleNo);
               sl.Add("@ProductNo", ProductNo);
               sl.Add("@StyleCode", StyleCode);
               sl.Add("@FabColor", FabColor);
               sl.Add("@bunIntno", bunIntNo );
               sl.Add("@bunqty", bunQty);
               sl.Add("@bunRange", bunRange);
               sl.Add("@createdby", createdby);
               sl.Add("@modifiedby", modifiedby);
               sl.Add("@createdDate", createdDate);
               sl.Add("@modifiedDate", modifiedDate);
               sl.Add("@TransferFlag", TransferFlag);
               i = obj.ExecuteNonQuery("iLayerCutBundle", sl);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
       }

       public void UpdateLastBundleNumber(decimal LBNumber, string stcode)
       {
           string errMsg = "";
           clsDB obj = new clsDB();
           SortedList sl = new SortedList();           
           try
           {
               sl.Add("@bunNo", LBNumber);
               sl.Add("@scode", stcode);
               obj.ExecuteNonQuery("uBundlebySerCode", sl);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
       }

      
       public void UpdateBundleFlagStatus(Int32  LayBNumber,string stylecode)
       {
           string errMsg = "";
           clsDB obj = new clsDB();
           SortedList sl = new SortedList();
           try
           {
               sl.Add("@LBno", LayBNumber);
               sl.Add("@sc", stylecode);
               obj.ExecuteNonQuery("uBundleFlagStatus", sl);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
       }


       public DataSet GetLayerInfo()
       {
           clsDB obj = new clsDB();
           string errMsg = "";
           DataSet ds = new DataSet();           
           try
           {
               ds = obj.GetData("sLayInfo", null );
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
           return ds;
       }

       public DataSet GetCanGenBundleNo(int LayBatchNo)
       {
           clsDB obj = new clsDB();
           string errMsg = "";
           DataSet ds = new DataSet();
           Hashtable ht = new Hashtable();
           try
           {
               ht.Add("@LBno", LayBatchNo);
               ds = obj.GetData("GetStatusGenBundleNo",ht);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
           return ds;
       }

       public DataSet GetLayHeaderData(int LayBatchNo, string  StyleCode)
       {
           clsDB obj = new clsDB();
           string errMsg = "";
           DataSet ds = new DataSet();
           Hashtable ht = new Hashtable();
           try
           {
               ht.Add("@LayBatNo", LayBatchNo);
               ht.Add("@styleCode", StyleCode);               
               ds = obj.GetData("sLayHD", ht);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
           return ds;
       }

       public DataSet GetLayDTLData(int LayBatchNo, string StyleCode)
       {
           clsDB obj = new clsDB();
           string errMsg = "";
           DataSet ds = new DataSet();
           Hashtable ht = new Hashtable();
           try
           {
               ht.Add("@LayBatNo", LayBatchNo);
               ht.Add("@styleCode", StyleCode);
               ds = obj.GetData("sLayDTL", ht);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
           return ds;
       }

       public DataSet GetLayBundleData(int LayBatchNo, string StyleCode)
       {
           clsDB obj = new clsDB();
           string errMsg = "";
           DataSet ds = new DataSet();
           Hashtable ht = new Hashtable();
           try
           {
               ht.Add("@LayBatNo", LayBatchNo);
               ht.Add("@styleCode", StyleCode);
               ds = obj.GetData("sLayBundleData", ht);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
           return ds;
       }

       public Int32 UpdateLayCutHD()
       {
           string errMsg = "";
           clsDB obj = new clsDB();
           SortedList sl = new SortedList();
           Int32 i = 0;
           try
           {
               sl.Add("@LayerBatchNo", LayerBatchNo);
               sl.Add("@compcode", compcode);
               sl.Add("@loccode", loccode);
               sl.Add("@CutDate", CutDate);
               sl.Add("@JobOrderNo", JobOrderNo);
               sl.Add("@StyleCode", StyleCode);
               sl.Add("@AVGConsumption", AVGConsumption);
               sl.Add("@PCSPerBundle", PCSPerBundle);
               sl.Add("@MerchandiserCode", MerchandiserCode);
               sl.Add("@CuttingMasterCode", CuttingMasterCode);
               sl.Add("@QCHeadCode", QCHeadCode);                             
               sl.Add("@BundleStartNo", BundleStartNo);
               sl.Add("@BundleEndNo", BundleEndNo);
               sl.Add("@modifiedby", modifiedby);
               sl.Add("@modifiedDate", modifiedDate);
               sl.Add("@TransferFlag", TransferFlag);
               sl.Add("@DeletedSataus", DeletedSataus);
               i = obj.ExecuteNonQuery("uLayerCutHD", sl);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
           return i;       
       }


       public void DelLayDTL(int LayBatNo, string StyleCode)
       {
           string errMsg = "";
           clsDB obj = new clsDB();
           SortedList sl = new SortedList();      
           try
           {
               sl.Add("@StyleCode", StyleCode);
               sl.Add("@LayerBatchNo", LayBatNo);
               obj.ExecuteNonQuery("dLayerCutDTL", sl);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
       }

       public void DelLayBundle(int LayBatNo, string StyleCode)
       {
           string errMsg = "";
           clsDB obj = new clsDB();
           SortedList sl = new SortedList();
           try
           {
               sl.Add("@StyleCode", StyleCode);
               sl.Add("@LayerBatchNo", LayBatNo);
               obj.ExecuteNonQuery("dLayerCutBundle", sl);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
       }

       public void SetStartEndBundleNumberForSeries(decimal BundleEndNo , string stcode)
       {
           string errMsg = "";
           clsDB obj = new clsDB();
           SortedList sl = new SortedList();
           try
           {
               sl.Add("@BundleEndNo", BundleEndNo);
               sl.Add("@sercode", stcode);
               obj.ExecuteNonQuery("uLayerCutHDStartNo", sl);
           }
           catch (Exception ex)
           {
               errMsg = ex.Message;
           }
           finally
           {
               obj = null;
           }
       }
    }
}
