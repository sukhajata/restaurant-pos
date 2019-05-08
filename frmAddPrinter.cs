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
    public partial class frmAddPrinter : Form
    {
        private List<POSPrinter> printers;
        
        public frmAddPrinter()
        {
            InitializeComponent();
            printers = DataHelper.GetPrinters();
            dgPrinters.DataSource = printers;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgPrinters.SelectedRows.Count > 0)
            {
                POSPrinter p = dgPrinters.SelectedRows[0].DataBoundItem as POSPrinter;

            }
        }
    }
}
