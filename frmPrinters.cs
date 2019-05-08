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
    public partial class frmPrinters : Form
    {
        private List<POSPrinter> printers;
        private frmEditProduct _frmEditProduct;

        public frmPrinters()
        {
            Setup();
        }

        public frmPrinters(frmEditProduct frm)
        {
            _frmEditProduct = frm;
            Setup();
        }

        private void Setup()
        {
            InitializeComponent();
            printers = DataHelper.GetPrinters();
            dgPrinters.DataSource = printers;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string printer = dlg.PrinterSettings.PrinterName;
                printers.Add(new POSPrinter(-1, string.Empty, printer, false));
                dgPrinters.DataSource = null;
                dgPrinters.DataSource = printers;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (POSPrinter printer in printers)
            {
                printer.Save();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgPrinters.SelectedRows.Count > 0)
            {
                POSPrinter p = dgPrinters.SelectedRows[0].DataBoundItem as POSPrinter;
                printers.Remove(p);
                p.Delete();
                dgPrinters.DataSource = null;
                dgPrinters.DataSource = printers;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_frmEditProduct != null)
            {
                if (dgPrinters.SelectedRows.Count > 0)
                {
                    POSPrinter p = dgPrinters.SelectedRows[0].DataBoundItem as POSPrinter;
                    _frmEditProduct.AddPrinter(p);
                }
            }
            this.Close();
        }
    }
}
