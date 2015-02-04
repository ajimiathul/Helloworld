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
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public static string rVal = "Edit";
        static CustomMessageBox newCustomMessageBox;

        public static string ShowBox()
        {
            newCustomMessageBox = new CustomMessageBox();
            newCustomMessageBox.ShowDialog();
            return rVal;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            rVal = "Edit";
            newCustomMessageBox.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            rVal = "Delete";
            newCustomMessageBox.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            rVal = "Cancel";
            newCustomMessageBox.Dispose();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }

    }
}
