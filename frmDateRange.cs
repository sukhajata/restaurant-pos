using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS
{
    public partial class frmDateRange : Form
    {
        public frmDateRange()
        {
            InitializeComponent();
            CenterToScreen();
            txtStart.Text = String.Format("{0:yyyy-M-d}", DateTime.Now.AddDays(- 7));
            txtEnd.Text = String.Format("{0:yyyy-M-d}", DateTime.Now);
            txtStart.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Global.StartDate = DateTime.ParseExact(txtStart.Text, "yyyy-M-d", null);
                Global.EndDate = DateTime.ParseExact(txtEnd.Text, "yyyy-M-d", null);
                Global.OK = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please use date format yyyy-M-d");
            }
            this.Close();
        }
    }
}
