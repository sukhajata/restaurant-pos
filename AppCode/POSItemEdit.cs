using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSItemEdit : POSItem, ICloneable
    {

        # region Public Properties
        [Browsable(false)]
        public int ItemId
        {
            get { return _itemid; }
            set { _itemid = value; }
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

        public string Variation
        {
            get { return _variation; }
            set { _variation = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [Browsable(false)]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        public double CostPrice
        {
            get { return _costPrice; }
            set { _costPrice = value; }
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
        
        #endregion

        public POSItemEdit(): base() {}

        public POSItemEdit(int itemid, int pid, string pname, string variation, double price, 
            int quantity, string barcode, double costPrice, int stockLevel, string PLU, 
            string suPLU, int x, int y)
            : base (
            itemid, pid, pname, variation, price, quantity, barcode, 
            costPrice, stockLevel, PLU, suPLU, x, y) {}

        public object Clone()
        {
            return new POSItemEdit(
                this._itemid,
                this._pid,
                this._productName,
                this._variation,
                this._price,
                this._quantity,
                this._barcode,
                this._costPrice,
                this._stockLevel,
                this._PLU,
                this._suPLU,
                this._x,
                this._y);
        }

    }
}
