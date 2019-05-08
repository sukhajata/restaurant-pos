using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSPriceLevel
    {
        private int _priceLevelId;
        private string _name;
        private string _description;
        private double _rate;

        public int PriceLevelId
        {
            get { return _priceLevelId; }
        }
        public string PriceLevelName
        {
            get { return _name; }
            set { _name = value; }
        }
        public string PriceLevelDescription
        {
            get { return _description; }
            set { _description = value; }
        }
        public double PriceLevelRate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public POSPriceLevel(int plid, string plname, string pldescription,
            double plrate)
        {
            _priceLevelId = plid;
            _name = plname;
            _description = pldescription;
            _rate = plrate;
        }

        public override string ToString()
        {
            return this.PriceLevelName;
        }
    }
}
