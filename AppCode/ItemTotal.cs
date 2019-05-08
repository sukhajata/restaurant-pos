using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class ItemTotal
    {
        private int _pid;
        private int _itemid;
        private string _pname;
        private string _variation;
        private int _quantity;
        private double _totalSales;

        public int ProductId
        {
            get { return _pid; }
        }
        public int ItemId
        {
            get { return _itemid; }
        }
        public string ProductName
        {
            get { return _pname; }
        }
        public string Variation
        {
            get { return _variation; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }
        public double TotalSales
        {
            get { return _totalSales; }
        }

        public ItemTotal(int pid, int itemid, string pname, string variation, 
            int quantity, double totalSales)
        {
            _pid = pid;
            _itemid = itemid;
            _pname = pname;
            _variation = variation;
            _quantity = quantity;
            _totalSales = totalSales;
        }
    }
}
