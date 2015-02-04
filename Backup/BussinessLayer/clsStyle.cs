using System;
using System.Collections;
using System.Linq;
using System.Text;
using DataAccessLayer;


namespace BussinessLayer
{
    public class clsStyle
    {
      public int pubStyleID;
      public int   compcode ;
      public int loccode;
      public DateTime   desdate;
      public string   sc;
      public string   sn;
      public int   dsgid;
      public int catid;
      public int  subcId;
      public decimal    pcost;
      public decimal   srate;
      public string   prodInstr;
      public string   mfbk;
      public int subcattype;
      public int fabwidthid;
      public decimal fabsize;
      public int pcsperbundle;
      public int RatioFormatCode;
      public int CFid;

      public int cusid;
      public string  CusPoNo ;
      public int OrderQty ;
      public DateTime   ShippingTargetDate ;


      public void  InsertStyle()
      {
          string errMsg = "";
          clsDB obj = new clsDB();
          SortedList sl = new SortedList();
          Int32 i = 0;
          try
          {
              sl.Add("@pubStyleID", pubStyleID);              
              sl.Add("@desdate", desdate);
              sl.Add("@sc", sc);
              sl.Add("@sn", sn);
              sl.Add("@dsgid", dsgid);
              sl.Add("@catid", catid);
              sl.Add("@subcId", subcId);
              sl.Add("@pcost", pcost);
              sl.Add("@srate", srate);
              sl.Add("@prodInstr", prodInstr);
              sl.Add("@mfbk", mfbk);
              sl.Add("@SizeTypeID", subcattype);
              sl.Add ("@FabWidthId",fabwidthid );
              sl.Add("@WidthSize", fabsize);
              sl.Add("@PcsPerBundle", pcsperbundle);
              sl.Add("@RatioFormatCode", RatioFormatCode);
              sl.Add("@CFid", CFid);               
              sl.Add("@cusid",cusid );
              sl.Add("@CusPoNo",CusPoNo) ;
              sl.Add("@OrderQty",OrderQty) ;
              sl.Add("@ShippingTargetDate",ShippingTargetDate) ;
              i = obj.ExecuteNonQuery("iStyle", sl);
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
