using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    /// <summary>
    /// Sets up the printing of an order at the various work stations.
    /// Enumerates the items in an order and assigns them to one or more printers,
    /// then initiates printing at all the printers.
    /// </summary>
    public class POSPrintController
    {
        private POSOrder _order;

        public POSPrintController(POSOrder order)
        {
            _order = order;
        }

        //print one docket on the receipt printer
        public void PrintOne()
        {
            POSPrinter printer = DataHelper.GetReceiptPrinter();
            if (printer != null)
            {
                POSOrderPrinter orderPrinter = new POSOrderPrinter(printer, _order);
                string output = orderPrinter.BuildOutput();
                orderPrinter.Print();
            }
        }

        public void PrintAll()
        {
            List<POSPrinter> printers = new List<POSPrinter>();
            try
            {
                foreach (POSItemTill item in _order.OrderItems)
                {
                    //get the printers that this product is associated with
                    BindingList<POSPrinter> productPrinters = DataHelper.GetPrinters(item.Pid);
                    foreach (POSPrinter p in productPrinters)
                    {
                        if (!printers.Contains(p))
                        {
                            printers.Add(p);
                        }
                    }
                }
                List<POSOrderPrinter> orderPrinters = new List<POSOrderPrinter>();
                foreach (POSPrinter p in printers)
                {
                    POSOrderPrinter op = new POSOrderPrinter(p, _order);
                    orderPrinters.Add(op);
                }
                //Print to the various printers
                foreach (POSOrderPrinter op in orderPrinters)
                {
                    MessageBox.Show(op.BuildOutput());
                    op.Print();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }
    }
}
