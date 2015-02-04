using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewGMS
{
    public partial class frmCustomMsgBox2 : Form
    {
        public static string rVal = "Edit";
        static frmCustomMsgBox2 objMsgBox;

        public frmCustomMsgBox2()
        {
            InitializeComponent();
        }

        public static string ShowBox()
        {
            objMsgBox = new frmCustomMsgBox2();
            objMsgBox .ShowDialog();
            return rVal;
        }

        private void frmCustomMsgBox2_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            rVal = "Edit";
            objMsgBox.Dispose();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            rVal = "New";
            objMsgBox.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            rVal = "Delete";
            objMsgBox.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            rVal = "Cancel";
            objMsgBox.Dispose();
        }
    }
}
