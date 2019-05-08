using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSItemStock : POSItem
    {
        #region Private Properties
        private string _category;
        private string _section;
        private string _supplier;
        #endregion

        #region Public Properties

        [Browsable(false)]
        public int ItemId
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        public string ProductName
        {
            get { return _productName; }
        }

        public string Variation
        {
            get { return _variation; }
        }

        public string Price
        {
            get { return string.Format("{0:c}", _price); }
        }

        public string Supplier
        {
            get { return _supplier; }
        }

        public string Section
        {
            get { return _section; }
        }

        public string Category
        {
            get { return _category; }
        }

        public int StockLevel
        {
            get { return _stockLevel; }
            set { _stockLevel = value; }
        }

        public string PLU
        {
            get { return _PLU; }
            set { _PLU = value; }
        }

        public string SupplierPLU
        {
            get { return _suPLU; }
            set { _suPLU = value; }
        }

        #endregion

        public POSItemStock(): base() {}

        public POSItemStock(int itemid, int pid, string pname, string variation,
            string supplier, double price, string category, string section,
            string barcode, double costPrice, int stockLevel, string PLU, string suPLU)
            : base 
            (itemid, pid, pname, variation, price, 0, barcode,  
             costPrice, stockLevel, PLU, suPLU, 0, 0) 
        {
            _category = category;
            _section = section;
            _supplier = supplier;
            
        }

    }
}
