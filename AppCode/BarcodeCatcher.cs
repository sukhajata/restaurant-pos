using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bliss_POS.AppCode
{
    public class BarcodeCatcher : IMessageFilter
    {
        public const int WM_KEYDOWN=0x0100;
        private string barcode = string.Empty;
        
        public bool PreFilterMessage(ref Message m) 
        {
            if (Application.OpenForms.Count == 1)//only apply when main form is in focus
            {
                if (m.Msg == WM_KEYDOWN)
                {
                    //if (m.WParam.ToInt32() == (int)Keys.Tab)
                    //{
                    //    MessageBox.Show("Tab Key was pressed");
                    //}
                    MessageBox.Show(m.WParam.ToInt32().ToString());
                    int num = (int)Keys.NumPad0;
                    MessageBox.Show(num.ToString());
                    int digit = -1;
                    switch (m.WParam.ToInt32())
                    {
                        case((int)Keys.NumPad0):
                            digit = 0;
                            break;
                        case((int)Keys.NumPad1):
                            digit = 1;
                            break;
                        case ((int)Keys.NumPad2):
                            digit = 2;
                            break;
                        case ((int)Keys.NumPad3):
                            digit = 3;
                            break;
                        case ((int)Keys.NumPad4):
                            digit = 4;
                            break;
                        case ((int)Keys.NumPad5):
                            digit = 5;
                            break;
                        case ((int)Keys.NumPad6):
                            digit = 6;
                            break;
                        case ((int)Keys.NumPad7):
                            digit = 7;
                            break;
                        default:
                            break;
                    }
                    if (digit > 0)
                    {
                        barcode += digit.ToString();
                    }
                    if (barcode.Length >= 3)
                    {
                        POSItemTill item = DataHelper.GetItemByBarcode(barcode);
                        if (item != null)
                        {
                            MessageBox.Show(item.ProductName);
                            barcode = string.Empty;
                        }
                    }
                }
            }
            return false;
        }


    }
}
