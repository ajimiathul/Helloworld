using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BussinessLayer;

namespace NewGMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {              
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new frmLogin());
             if (clsDbForReports.LogStatus == true)
             {
                 Application.Run(new frmMain());
             }            
        }
    }
}
