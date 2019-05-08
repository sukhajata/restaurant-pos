using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bliss_POS.AppCode
{
    public class POSPriceLevel_Item
    {
        private int _id;
        private int _plid;
        private string _plname;
        private int _itemid;
        private int _priceLevelException_id;
        private double _rate;

        [Browsable(false)]
        public int PriceLevel_ItemId
        {
            get { return _id; }
            set { _id = value; }
        }

        [Browsable(false)]
        public int PriceLevelId
        {
            get { return _plid; }
            set { _plid = value; }
        }

        public string PriceLevel
        {
            get { return _plname; }
        }

        [Browsable(false)]
        public int ItemId
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        [Browsable(false)]
        public int PriceLevelExceptionId
        {
            get { return _priceLevelException_id; }
        }

        public double Rate
        {
            get { return _rate; }
            set {_rate = value; }
        }

        public POSPriceLevel_Item (int id, int plid, string plname, int itemid, 
            int priceLevelException_id, double rate)
        {
            _id = id;
            _plid = plid;
            _plname = plname;
            _itemid = itemid;
            _priceLevelException_id = priceLevelException_id;
            _rate = rate;
        }
    }
}
