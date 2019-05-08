using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSItem
    {
        #region Protected Properties

        protected int _itemid;
        protected int _pid;
        protected string _productName;
        protected string _variation;
        protected double _price;
        protected int _quantity;
        protected double _salePrice;
        protected string _barcode;
        protected double _costPrice;
        protected int _stockLevel;
        protected string _PLU;
        protected string _suPLU;
        protected int _x;
        protected int _y;
        protected List<POSInstruction> _instructions;

        #endregion

        public POSItem()
        {
            _itemid = -1;
            _pid = -1;
            _variation = string.Empty;
            _price = 0;
            _salePrice = 0;
            _barcode = string.Empty;
            _costPrice = 0;
            _stockLevel = 0;
            _PLU = string.Empty;
            _suPLU = string.Empty;
            _x = 0;
            _y = 0;

            _instructions = new List<POSInstruction>();
        }

        public POSItem(int itemid, int pid, string pname, string variation, double price, 
            int quantity, string barcode, double costPrice, int stockLevel, string PLU, 
            string suPLU, int x, int y)
        {
            _itemid = itemid;
            _pid = pid;
            _productName = pname;
            _variation = variation;
            _price = price;
            _quantity = quantity;
            _salePrice = price;
            _barcode = barcode;
            _costPrice = costPrice;
            _stockLevel = stockLevel;
            _PLU = PLU;
            _suPLU = suPLU;
            _x = x;
            _y = y;

            _instructions = new List<POSInstruction>();
        }

        public void AddInstruction(POSInstruction i)
        {
            _instructions.Add(i);
        }

        public List<POSInstruction> GetInstructions()
        {
            return _instructions;
        }
    }
}
