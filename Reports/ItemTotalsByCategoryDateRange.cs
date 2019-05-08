using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Bliss_POS.AppCode;
using System.Windows.Forms;

namespace Bliss_POS.Reports
{
    public class ItemTotalsByCategoryDateRange
    {
        public ItemTotalsByCategoryDateRange(DateTime start, DateTime end)
        {

            string path = "C:\\ItemTotals.html";
            FileStream stream =new FileStream(path, FileMode.Create);
            try
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("<html><head><title>Item Totals</title></head><body>");
                List<POSSection> sections = DataHelper.GetSections();
                writer.WriteLine(String.Format("<h2>{0:d/M/yyyy} to {1:d/M/yyyy}</h2>", start, end));
                writer.WriteLine("<table cellpadding=\"3px\">");
                writer.WriteLine("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td width=\"50px\">&nbsp;</td><td width=\"120px\">&nbsp;</td></tr>");
                foreach (POSSection section in sections)
                {
                    writer.WriteLine("<tr><td colspan=\"5\" bgcolor=\"#99CCFF\"><strong>" + section.SectionName + "</strong></td></tr>");
                    List<POSCategory> categories = DataHelper.GetCategories(section.SectionId);
                    foreach (POSCategory category in categories)
                    {
                        List<ItemTotal> totals = DataHelper.GetItemTotals(category.CategoryId, start, end);
                        if (totals.Count > 0)
                        {
                            writer.WriteLine("<tr><td colspan=\"5\">&nbsp;<strong>" + category.CategoryName + "</strong></td></tr>");
                            //writer.WriteLine("<tr><th>&nbsp;</th><th align=\"left\">Product</th><th align=\"left\">Variation</th><th>Quantity</th><th>Total Sales</th></tr>");
                            double catTotal = 0.0;
                            foreach (ItemTotal dit in totals)
                            {
                                writer.WriteLine("<tr><td>&nbsp;</td><td>" + dit.ProductName +
                                    "</td><td>" + (dit.Variation.Equals("default") ? string.Empty : dit.Variation) + "</td><td align=\"right\">" + dit.Quantity +
                                    "</td><td align=\"right\">" + String.Format("{0:c}", dit.TotalSales) + "</td></tr>");
                                catTotal += dit.TotalSales;
                            }
                            writer.WriteLine(String.Format("<tr><td colspan=5 align=\"right\"><strong>{0:c}</strong></td></tr>",
                                catTotal));
                        }
                    }
                    
                }
                writer.WriteLine("</table><p/><p/>");
                writer.WriteLine("</body></html>");
                writer.Flush();
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                stream.Close();
            }

            frmBrowser browser = new frmBrowser("file:///C:/ItemTotals.html");
            browser.Show();
            
            

        }
    }
}
