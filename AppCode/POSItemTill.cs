using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSItemTill : POSItem, ICloneable
    {
        //Private Properties
        private int _sortOrder;

        # region Public Properties
        [Browsable(false)]
        public int ItemId
        {
            get { return _itemid; }
        }

        [Browsable(false)]
        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        
        [Browsable(false)]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [Browsable(false)]
        public string Name_Variation
        {
            get
            {
                string txt;
                if (_variation.Equals("default"))
                {
                    txt = _productName;
                }
                else
                {
                    txt = String.Format("{0}, {1}", _productName, _variation);
                }
                return txt;
            }
        }

        public string NameDisplay
        {
            get
            {
                string display;
                if (_variation.Equals("default"))
                {
                    display = _productName;
                }
                else
                {
                    display = String.Format("{0}, {1}", _productName, _variation);
                }
                if (_instructions.Count > 0)
                {
                    foreach (POSInstruction i in _instructions)
                    {
                        display += Environment.NewLine + i.Instruction;
                    }
                }
                return display;
            }
        }

        [Browsable(false)]
        public string Variation
        {
            get { return _variation; }
            set { _variation = value; }
        }

        [Browsable(false)]
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [Browsable(false)]
        public double SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = value; }
        }

        //[Browsable(false)]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string PriceDisplay
        {
            get { return string.Format("{0:c}", _salePrice * _quantity); }
        }


        [Browsable(false)]
        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        [Browsable(false)]
        public double CostPrice
        {
            get { return _costPrice; }
            set { _costPrice = value; }
        }

        [Browsable(false)]
        public int StockLevel
        {
            get { return _stockLevel; }
            set { _stockLevel = value; }
        }

        [Browsable(false)]
        public string PLU
        {
            get { return _PLU; }
            set { _PLU = value; }
        }

        [Browsable(false)]
        public string SuPLU
        {
            get { return _suPLU; }
            set { _suPLU = value; }
        }

        [Browsable(false)]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        [Browsable(false)]
        public int Y
        {   
            get { return _y; }
            set { _y = value; }
        }

        [Browsable(false)]
        public int SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }
        
        #endregion

        public POSItemTill(): base() {}

        public POSItemTill(int itemid, int pid, string pname, string variation, 
            double price, int quantity, string barcode, double costPrice, int stockLevel, 
            string PLU, string suPLU, int x, int y, int sortOrder)
            : base (
            itemid, pid, pname, variation, price, quantity, barcode, 
            costPrice, stockLevel, PLU, suPLU, x, y)
        {
            _sortOrder = sortOrder;
        }

        public object Clone()
        {
            return new POSItemTill(
                this._itemid,
                this._pid,
                this._productName,
                this._variation,
                this._price,
                1,
                this._barcode,
                this._costPrice,
                this._stockLevel,
                this._PLU,
                this._suPLU,
                this._x,
                this._y,
                this._sortOrder);
        }

    }
}
