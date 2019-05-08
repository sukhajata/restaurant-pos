using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSSupplier
    {
        private int _suid;
        private string _supplier;
        private string _phone;
        private string _address;
        private double _markup;
        private double _rate;
        private int _type;

        public int Suid
        {
            get { return _suid; }
        }
        public string Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public double Markup
        {
            get { return _markup; }
            set { _markup = value; }
        }
        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public POSSupplier(int suid, string sname)
        {
            _suid = suid;
            _supplier = sname;
        }

        public POSSupplier(int suid, string sname, string phone, string address,
            double markup, double rate, int type)
        {
            _suid = suid;
            _supplier = sname;
            _phone = phone;
            _address = address;
            _markup = markup;
            _rate = rate;
            _type = type;
        }

        public override string ToString()
        {
            return _supplier;
        }
    }
}
