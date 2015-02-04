using System;
using System.Configuration;
using DataAccessLayer;

namespace BussinessLayer
{
    public static  class clsDbForReports
    {
        public static string server = ConfigurationSettings.AppSettings["server"];
        public static string db = ConfigurationSettings.AppSettings["db"];
        public static string uid = ConfigurationSettings.AppSettings["uid"];
        public static string pwd = ConfigurationSettings.AppSettings["pwd"];
        public static string constr = "Data Source='" + server + "';Initial Catalog='" + db + "';uid=sa;pwd='" + pwd + "'";

        public static string serverlog = ConfigurationSettings.AppSettings["serverlog"];
        public static string dblog = ConfigurationSettings.AppSettings["dblog"];
        public static string uidlog = ConfigurationSettings.AppSettings["uidlog"];
        public static string pwdlog = ConfigurationSettings.AppSettings["pwdlog"];
        public static string constrlog = "Data Source='" + serverlog + "';Initial Catalog='" + dblog + "';uid=sa;pwd='" + pwdlog + "'";

        public static Int32 pubLayBatNo = 1;
        public static DateTime pubCutDate = Convert.ToDateTime("01/01/2011");
        public static string username = "";
        public static int userid = 0;
        public static bool LogStatus = false;
        public static int admin = 0;
        public static int companycode = 0;
        public static int officecode = 0;
        public static string PIReqSubno = "";
        public static string PIRSupplier = "";
        public static int PIRSupplierCode = 0;

        public static string PdfExeWithPath = ConfigurationSettings.AppSettings["PdfExeWithPath"];
        public static string QuotationPdfDirectory = ConfigurationSettings.AppSettings["QuotationPdfDirectory"];

        
        public static string FPConStr()
        {
            string FPServer = ConfigurationSettings.AppSettings["FPserver"].ToString();
            string FPdatabase = ConfigurationSettings.AppSettings["FPdatabase"].ToString();
            string pwd = ConfigurationSettings.AppSettings["FPSrvrPwd"].ToString();
            string FP = "Data Source='" + FPServer + "';Initial Catalog='" + FPdatabase + "';uid=sa;pwd='" + pwd + "'";
            return FP;
        }
    }    
}
