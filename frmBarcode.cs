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
    public partial class frmBarcode : Form
    {

        public frmBarcode()
        {
            InitializeComponent();
            CenterToScreen();
            txtBarcode.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length >= 3)
            {
                POSItemTill item = DataHelper.GetItemByBarcode(txtBarcode.Text);
                if (item != null)
                {
                    Global.BarcodeItem = item;
                    this.Close();
                }
            }
        }
    }
}
