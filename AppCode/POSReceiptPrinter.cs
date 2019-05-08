using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.AppCode
{
    public class POSReceiptPrinter : PrintDocument
    {
        private Font _font;
        private string _text;
        private string _server;
        static int curChar;

        public string PrintText
        {
            get { return _text; }
            set { _text = value; }
        }

        public POSReceiptPrinter(POSOrder order, string server) : base()
        {
            _font = new Font("Consolas", 9);
            _server = server;
            this.PrinterSettings.PrinterName = DataHelper.GetReceiptPrinterName();
            //use standard print controller to suppress UI
            this.PrintController = new StandardPrintController();
            BuildOutput(order);
        }

        private void BuildOutput(POSOrder order)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine(DataHelper.GetConfigValue("Business Name"));
            output.AppendLine("GST No.: " + DataHelper.GetConfigValue("Gst Number"));
            output.AppendLine(String.Format("{0:g}", DateTime.Now));
            output.AppendLine(String.Format("You were served by {0}", _server));
            output.AppendLine();
            output.AppendLine(String.Format("{0,-20}{1,5}{2,10}", "ITEM", "QTY", "PRICE"));
            foreach (POSItemTill item in order.OrderItems)
            {
                string name = item.Name_Variation;
                if (name.Length > 20)
                {
                    name = name.Substring(0, 20);
                }
                string line = String.Format("{0,-20}{1,5}{2,10:c}",
                    name, item.Quantity, item.SalePrice * item.Quantity);
                output.AppendLine(line);
            }
            output.AppendLine();
            output.AppendLine(String.Format("{0,-20}{1,15:c}", "Total", order.Total));
            if (order.paymentType == POSOrder.PaymentType.Cash)
            {
                double total = Math.Round(order.Total, 1);
                if (total != order.Total)
                {
                    output.AppendLine(String.Format("{0,-20}{1,15:c}", "Rounded", total));
                }
                output.AppendLine(String.Format("{0,-20}{1,15:c}", "Cash", order.AmountPaid));
                output.AppendLine(String.Format("{0,-20}{1,15:c}", "Change", order.AmountPaid - total));
            }
            output.AppendLine();
            output.AppendLine(DataHelper.GetConfigValue("Footnote"));
            output.AppendLine();
            output.AppendLine("===================================");
            _text = output.ToString();
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            int printHeight;
            int printWidth;
            int leftMargin;
            int rightMargin;
            Int32 lines;
            Int32 chars;

            //Set print area size and margins
            {
                leftMargin = 2;//base.DefaultPageSettings.Margins.Left;  //X
                rightMargin = 5;// base.DefaultPageSettings.Margins.Top;  //Y
                printHeight = 1000;// base.DefaultPageSettings.PaperSize.Height - base.DefaultPageSettings.Margins.Top - base.DefaultPageSettings.Margins.Bottom;
                printWidth = base.DefaultPageSettings.PaperSize.Width - leftMargin - rightMargin;
                
                
            }

            //Check if the user selected to print in Landscape mode
            //if they did then we need to swap height/width parameters
            if (base.DefaultPageSettings.Landscape)
            {
                int tmp;
                tmp = printHeight;
                printHeight = printWidth;
                printWidth = tmp;
            }

            //Now we need to determine the total number of lines
            //we're going to be printing
            Int32 numLines = (int)printHeight / _font.Height;

            //Create a rectangle printing are for our document
            RectangleF printArea = new RectangleF(leftMargin, rightMargin, printWidth, printHeight);

            //Use the StringFormat class for the text layout of our document
            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);

            //Fit as many characters as we can into the print area      

            e.Graphics.MeasureString(_text.Substring(RemoveZeros(curChar)), _font, new SizeF(printWidth, printHeight), format, out chars, out lines);

            //Print the page
            e.Graphics.DrawString(_text.Substring(RemoveZeros(curChar)), _font, Brushes.Black, printArea, format);

            //Increase current char count
            curChar += chars;

            //Detemine if there is more text to print, if
            //there is tell the printer there is more coming
            if (curChar < _text.Length)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                curChar = 0;
            }

        }

        /// <summary>
        /// Function to replace any zeros in the size to a 1
        /// Zero's will mess up the printing area
        /// </summary>
        /// <param name=value>Value to check</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private int RemoveZeros(int value)
        {
            //Check the value passed into the function,
            //if the value is a 0 (zero) then return a 1,
            //otherwise return the value passed in
            switch (value)
            {
                case 0:
                    return 1;
                default:
                    return value;
            }
        }

    }
}
