using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BussinessLayer;
//using System.Windows.Forms;

namespace NewGMS
{
    public class Clserrlogr
    {
        public void write(string screen, string emethod, string errormsg)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = clsDbForReports.constrlog;
            SqlCommand cmd = new SqlCommand("",con );
            con.Open();
            cmd.CommandText = "insert  into tErrorLog(dt,UserId,screen,method,errormsg) values( @dt,@UserId,@screen,@method,@errormsg)";
            cmd.Parameters.AddWithValue("@dt",DateTime .Now );
            cmd.Parameters.AddWithValue("@UserId",clsDbForReports .userid);
            cmd.Parameters.AddWithValue("@screen",screen );
            cmd.Parameters.AddWithValue("@method",emethod);
            if (errormsg.Length <= 7000)
                cmd.Parameters.AddWithValue("@errormsg",  errormsg);
            else
                cmd.Parameters.AddWithValue("@errormsg", errormsg.Substring(1,7000));
            //MessageBox.Show(errormsg.Length.ToString()); 
            cmd.ExecuteNonQuery ();
            con.Close ();
            
        }

    }
}
