using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSOrder
    {
        public enum PaymentType { Cash = 1, EFTPOS = 2, Credit = 3 }

        private int _oid;
        private int _hid; //used if the order is being held

        public int OrderId
        {
            get { return _oid; }
        }
        public BindingList<POSItemTill> OrderItems;
        public POSTable Table; //table number used when orders are prepaid
        public PaymentType paymentType;
        public double AmountPaid;
        public int Hid
        {
            get { return _hid; }
            set { _hid = value; }
        }
        public double Total
        {
            get
            {
                double total = 0;
                foreach (POSItemTill p in OrderItems)
                {
                    total = total + p.SalePrice * p.Quantity;
                }
                return total;
            }
        }
        
        public POSOrder()
        {
            OrderItems = new BindingList<POSItemTill>();
            _hid = 0;
            AmountPaid = 0;
        }

        public POSOrder(BindingList<POSItemTill> items, int id, string type)
        {
            OrderItems = items;
            if (type.Equals("hold"))
            {
                _hid = id;
            }
            else
            {
                _oid = id;
            }
        }

        public IOrderedEnumerable<POSItemTill> SortItems()
        {
            return OrderItems.OrderBy(item => item.SortOrder);
        }

       
    }
}
