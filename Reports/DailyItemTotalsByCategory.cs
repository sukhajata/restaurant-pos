using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bliss_POS.AppCode;
using System.IO;
using System.Windows.Forms;

namespace Bliss_POS.Reports
{
    public class DailyItemTotalsByCategory
    {
        
        public DailyItemTotalsByCategory()
        {

            string path = "C:\\DailyTotals.html";
            FileStream stream = new FileStream(path, FileMode.Create);
            try
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("<html><head><title>Daily Totals</title></head><body>");
                writer.WriteLine(String.Format("<h2>Totals {0:d/M/yyyy}</h2>", DateTime.Now));
                writer.WriteLine("<table cellpadding=\"3px\">");
                writer.WriteLine("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td width=\"50px\">&nbsp;</td><td width=\"120px\">&nbsp;</td></tr>");
                List<POSSection> sections = DataHelper.GetSections();
                foreach (POSSection section in sections)
                {
                    writer.WriteLine("<tr><td colspan=\"5\" bgcolor=\"#99CCFF\"><strong>" + section.SectionName + "</strong></td></tr>");
                    List<POSCategory> categories = DataHelper.GetCategories(section.SectionId);
                    foreach (POSCategory category in categories)
                    {
                        List<ItemTotal> totals = DataHelper.GetDailyItemTotals(category.CategoryId, DateTime.Now);
                        if (totals.Count > 0)
                        {
                            writer.WriteLine("<tr><td colspan=\"5\">&nbsp;<strong>" + category.CategoryName + "</strong></td></tr>");                            
                            foreach (ItemTotal dit in totals)
                            {
                                writer.WriteLine("<tr><td>&nbsp;</td><td>" + dit.ProductName +
                                    "</td><td>" + (dit.Variation.Equals("default") ? string.Empty : dit.Variation) + "</td><td>" + dit.Quantity + "</td><td>" +
                                    String.Format("{0:c}", dit.TotalSales) + "</td></tr>");
                            }
                        }
                    }
                }
                writer.WriteLine("</table>");
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

            frmBrowser browser = new frmBrowser("file:///C:/DailyTotals.html");
            browser.Show();
            
        }
    }
}
