using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Bliss_POS.AppCode
{
    public static class Global
    {
        public static int GridSpacing = 85;
        public static int NumColumns = 8;
        public static int NumRows = 8;
        public static POSItemTill BarcodeItem;
        public static DateTime StartDate;
        public static DateTime EndDate;
        public static bool OK;
        public static frmMain ParentForm;
        public static POSProduct CurrentProduct;
        public static POSItemTill CurrentItem;
        public static bool ProductChanged;
        public static int SectionId;
        public static POSUser CurrentUser;
        public static Color Green = Color.FromArgb(128, 255, 128);
        public static Color Yellow = Color.FromArgb(255, 255, 128);
        public static Color Red = Color.FromArgb(255, 192, 192);
        public static string KeyboardInput = string.Empty;
        public static string ReceiptPrinterName = DataHelper.GetReceiptPrinterName();
        public static int SupplierId;
        public static double UserInput;
    }
}
