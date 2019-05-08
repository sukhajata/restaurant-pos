using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSZeroIncomeType
    {
        private int _ztid;
        private string _ztname;

        [Browsable(false)]
        public int Ztid
        {
            get { return _ztid; }
        }
        public string Ztname
        {
            get { return _ztname; }
            set { _ztname = value; }
        }

        public POSZeroIncomeType(int ztid, string ztname)
        {
            _ztid = ztid;
            _ztname = ztname;
        }
    }
}
