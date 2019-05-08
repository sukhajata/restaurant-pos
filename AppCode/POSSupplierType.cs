using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    class POSSupplierType
    {
        private int _id;
        private string _type;

        public int SupplierTypeId
        {
            get { return _id; }
            set { _id = value; }
        }
        public string SupplierType
        {
            get { return _type; }
            set { _type = value; }
        }

        public POSSupplierType(int id, string type)
        {
            _id = id;
            _type = type;
        }

        public override string ToString()
        {
            return _type;
        }

    }
}
