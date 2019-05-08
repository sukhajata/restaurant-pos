using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;
using System.Drawing;

namespace Bliss_POS.AppCode
{
    public class ProductArranger
    {
        private static int _numRows = Properties.Settings.Default.numRows;
        private static int _numCols = Properties.Settings.Default.numCols;
        private static int _gridSpacing = Properties.Settings.Default.gridSpacing;
        private int _sid;

        public ProductArranger(int sid)
        {
            _sid = sid;
        }

        public bool Arrange()
        {
            //DataHelper.ClearProductLocations(_sid);

            POSSection section = DataHelper.GetSection(_sid);
            Queue<POSProduct> queue = new Queue<POSProduct>();

            List<POSCategory> cats = DataHelper.GetCategories(section.SectionId);
            foreach (POSCategory cat in cats)
            {
                List<POSProduct> products = DataHelper.GetProducts(cat.CategoryId);
                foreach (POSProduct prod in products)
                {
                    queue.Enqueue(prod);
                }
            }

            for (int y = 0; y < _numRows; y++)
            {
                for (int x = 0; x < _numCols; x++)
                {
                    if (queue.Count > 0)
                    {
                        POSProduct p = queue.Dequeue();
                        DataHelper.SaveProductLocation(p.ProductId, new Point(x * _gridSpacing,
                            y * _gridSpacing));
                    }

                }
            }
            if (queue.Count > 0)
            {
                return false;
            }
            return true;

        }

        public static Point FindNextAvailableRow(POSProduct product)
        {
            POSSection section = DataHelper.GetSection(product.SectionId);
            List<POSProduct> products = new List<POSProduct>();

            List<POSCategory> cats = DataHelper.GetCategories(section.SectionId);
            foreach (POSCategory cat in cats)
            {
                foreach (POSProduct prod in DataHelper.GetProducts(cat.CategoryId))
                {
                    products.Add(prod);
                }
            }

            //find greatest y value
            int yMax = 0;
            foreach (POSProduct prod in products)
            {
                if (prod.Y > yMax)
                {
                    yMax = prod.Y;
                }
            }

            Point location = new Point(0, yMax + _gridSpacing);

            return location;
        }


    }
}
