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
    public class TotalsPrinter : PrintDocument
    {
        private Font _font;
        private string _text;
        static int curChar;

        public string PrintText
        {
            get { return _text; }
            set { _text = value; }
        }

        public TotalsPrinter()
        {
            _font = new Font("Courier New", 9);
            this.PrinterSettings.PrinterName = DataHelper.GetReceiptPrinterName();
            BuildOutput();
        }

        private void BuildOutput()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine(String.Format("{0:g}", DateTime.Now));
            output.AppendLine();
            Dictionary<string, double> paymentTotals = DataHelper.GetDailyPaymentTypeTotals();
            double grandTotal = 0;
            foreach (KeyValuePair<string, double> total in paymentTotals)
            {
                output.AppendLine(string.Format("{0,-10}{1,10:c}", total.Key, total.Value));
                grandTotal += total.Value;
            }
            output.AppendLine("===================================");
            output.AppendLine(string.Format("{0,-10}{1,10:c}", "Total", grandTotal));
            output.AppendLine();
            output.AppendLine();
            output.AppendLine("Customers");
            Dictionary<string, int> customerTotals = DataHelper.GetDailyCustomerTotal();
            int customerTotal = 0;
            foreach (KeyValuePair<string, int> total in customerTotals)
            {
                output.AppendLine(string.Format("{0,-10}{1,10}", total.Key, total.Value));
                customerTotal += total.Value;
            }
            output.AppendLine(string.Format("{0,-10}{1,10}", "Total", customerTotal));
            output.AppendLine();
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
