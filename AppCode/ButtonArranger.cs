using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;
using System.Drawing;

namespace Bliss_POS.AppCode
{
    public class ButtonArranger
    {
        private int _sid;

        public ButtonArranger(int sid)
        {
            _sid = sid;
        }

        /// <summary>
        /// Assigns coordinates to products and instructions for a given section.
        /// </summary>
        /// <returns>true if all buttons could fit within the bounds of 
        /// designated number of columns and rows.</returns>
        public bool Arrange()
        {
            //DataHelper.ClearProductLocations(_sid);

            POSSection section = DataHelper.GetSection(_sid);
            Queue<object> queue = new Queue<object>();

            List<POSCategory> cats = DataHelper.GetCategories(section.SectionId);
            foreach (POSCategory cat in cats)
            {
                List<POSProduct> products = DataHelper.GetProducts(cat.CategoryId);
                foreach (POSProduct prod in products)
                {
                    queue.Enqueue(prod);
                }
            }

            //get instructions for this section
            List<POSInstruction> sectionInstructions =
                DataHelper.GetSectionInstructions(_sid);
            foreach (POSInstruction si in sectionInstructions)
            {
                queue.Enqueue(si);
            }

            for (int y = 0; y < Global.NumRows; y++)
            {
                for (int x = 0; x < Global.NumColumns; x++)
                {
                    if (queue.Count > 0)
                    {
                        object o = queue.Dequeue();
                        try
                        {
                            POSProduct p = (POSProduct)o;
                            DataHelper.SaveProductLocation(p.ProductId, 
                                new Point(x * Global.GridSpacing,
                                    y * Global.GridSpacing));
                        }
                        catch (Exception)
                        {
                            POSInstruction si = (POSInstruction)o;
                            DataHelper.SaveInstructionLocation(si.InstructionId,
                                x * Global.GridSpacing, y * Global.GridSpacing);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (queue.Count > 0)
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// Find the first available screen location in a given section to 
        /// display a product or instruction button
        /// </summary>
        /// <param name="sid"></param>
        /// <returns>Point</returns>
        public static Point FindNextAvailableSpace(int sid)
        {
            for (int r = 0; r < Global.NumRows; r++)
            {
                for (int c = 0; c < Global.NumColumns; c++)
                {
                    if (DataHelper.CheckLocationAvailable(c * Global.GridSpacing,
                        r * Global.GridSpacing, sid))
                    {
                        return new Point(c * Global.GridSpacing,
                            r * Global.GridSpacing);
                    }
                }
            }

            return new Point(0, 0);
            
        }


    }
}
