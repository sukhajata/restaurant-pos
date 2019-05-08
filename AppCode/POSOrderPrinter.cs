using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSOrderPrinter : PrintDocument
    {
        private Font _font;
        private string _text;
        private static int _curChar;
        private string _tableName;
        private string _server;
        private BindingList<POSItemTill> _items;
        //private int _printHeight;
        //private int _printWidth;
        //private int _leftMargin;
        //private int _rightMargin;
        //private RectangleF _printArea;
        private StringFormat _format;

        public POSPrinter Printer;

        public string PrintText
        {
            get { return _text; }
            set { _text = value; }
        }
        public BindingList<POSItemTill> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public POSOrderPrinter(POSPrinter pr, POSOrder order)
            : base()
        {
            _tableName = string.Empty;
            if (order.Table != null)
            {
                _tableName = order.Table.Tname;
            }
            _server = Global.CurrentUser.Username;
            Printer = pr;
            _font = new Font("Consolas", 10);
            this.PrinterSettings.PrinterName = Printer.PrinterName;

            //use standard print controller to suppress information dialog
            this.PrintController = new StandardPrintController();
            _items = order.OrderItems;

            //Set print area size and margins
            //{
            //    _leftMargin = 1;//base.DefaultPageSettings.Margins.Left;  //X
            //    _rightMargin = 1;// base.DefaultPageSettings.Margins.Top;  //Y
            //    _printHeight = 2000;// base.DefaultPageSettings.PaperSize.Height - base.DefaultPageSettings.Margins.Top - base.DefaultPageSettings.Margins.Bottom;
            //    _printWidth = base.DefaultPageSettings.PaperSize.Width - _leftMargin - _rightMargin;
            //}

            ////Create a rectangle printing area for our document
            //_printArea = new RectangleF(_leftMargin, _rightMargin, _printWidth, _printHeight);

            //Use the StringFormat class for the text layout of our document
            _format = new StringFormat(StringFormatFlags.LineLimit);

        }

        public string BuildOutput()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();//leave some space at the top for order rack
            output.AppendLine();
            output.AppendLine();
            output.AppendLine();
            output.AppendLine(string.Format("{0,-28}{1,-5}", "ITEM", "QTY"));
            output.AppendLine();
            IOrderedEnumerable<POSItemTill> sortedItems = _items.OrderBy(item => item.SortOrder);
            foreach (POSItemTill item in sortedItems)
            {
                string name = item.ProductName;
                if (name.Length > 28)
                {
                    name = name.Substring(0, 28);
                }
                output.AppendLine(String.Format("{0,-28}{1,-5}", name, 
                    item.Quantity > 0 ? item.Quantity.ToString() : string.Empty));
                if (!item.Variation.Equals("default"))
                {
                    output.AppendLine(String.Format("   {0}", item.Variation));
                }
                foreach (POSInstruction i in item.GetInstructions())
                {
                    output.AppendLine(String.Format("   {0}", i.Instruction));
                }
                output.AppendLine("-------------------------");
            }
            output.AppendLine();
            output.AppendLine();
            output.AppendLine(String.Format("Table: {0}", _tableName));
            output.AppendLine(String.Format("Server: {0}", _server));
            output.AppendLine(String.Format("Time: {0:t}", DateTime.Now));
            _text = output.ToString();
            return _text;
            
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            //Int32 lines;
            //Int32 chars;

            //Check if the user selected to print in Landscape mode
            //if they did then we need to swap height/width parameters
            //if (base.DefaultPageSettings.Landscape)
            //{
            //    int tmp;
            //    tmp = printHeight;
            //    printHeight = printWidth;
            //    printWidth = tmp;
            //}

            //Now we need to determine the total number of lines
            //we're going to be printing
            //Int32 numLines = (int)printHeight / _font.Height;


            //Fit as many characters as we can into the print area      
            //e.Graphics.MeasureString(_text.Substring(RemoveZeros(_curChar)), _font, new SizeF(_printWidth, _printHeight), _format, out chars, out lines);
            
            //Print the page
            //e.Graphics.DrawString(_text.Substring(RemoveZeros(_curChar)), _font, Brushes.Black, _printArea, _format);
            //e.Graphics.DrawString(_text.Substring(RemoveZeros(_curChar)), _font, Brushes.Black, 1, 2, _format);
            e.Graphics.DrawString(_text, _font, Brushes.Black, new PointF(1, 2));

            //Increase current char count
            //_curChar += chars;

            ////Detemine if there is more text to print, if
            ////there is tell the printer there is more coming
            //if (_curChar < _text.Length)
            //{
            //    e.HasMorePages = true;
            //}
            //else
            //{
            //    e.HasMorePages = false;
            //    _curChar = 0;
            //}

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
