using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSConfigItem
    {
        private int _cid;
        private string _item;
        private string _value;


        [Browsable(false)]
        public int ConfigId
        {
            get { return _cid; }
        }
        public string ItemName
        {
            get { return _item; }
            set { _item = value; }
        }
        public string ItemValue
        {
            get { return _value; }
            set { _value = value; }
        }

        public POSConfigItem(int cid, string item, string value)
        {
            _cid = cid;
            _item = item;
            _value = value;
        }

        

        
    }
}
