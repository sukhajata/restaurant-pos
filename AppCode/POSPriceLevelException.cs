using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSPriceLevelException
    {
        private int _id;
        private int _plid;
        private int _suid;
        private string _supplier;
        private int _sid;
        private string _section;
        private int _cid;
        private string _category;
        private double _rate;

        [Browsable(false)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Browsable(false)]
        public int PriceLevelId
        {
            get { return _plid; }
        }

        [Browsable(false)]
        public int SupplierId
        {
            get { return _suid; }
            set { _suid = value; }
        }


        public string Supplier
        {
            get { return _supplier; }
        }

        [Browsable(false)]
        public int SectionId
        {
            get { return _sid; }
            set { _sid = value; }
        }

        public string Section
        {
            get { return _section; }
        }

        [Browsable(false)]
        public int CategoryId
        {
            get { return _cid; }
            set { _cid = value; }
        }


        public string Category
        {
            get { return _category; }
        }

        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public POSPriceLevelException(int id, int plid, int suid, string supplier, int sid, 
            string section, int cid, string category, double rate)
        {
            _id = id;
            _plid = plid;
            _suid = suid;
            _supplier = supplier;
            _sid = sid;
            _section = section;
            _cid = cid;
            _category = category;
            _rate = rate;
        }

    }
}
