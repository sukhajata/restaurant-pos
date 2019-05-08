using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSPrinter
    {
        private int _prid;
        private string _location;
        private string _prname;
        private bool _isReceiptPrinter;

        [Browsable(false)]
        public int PrinterId
        {
            get { return _prid; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string PrinterName
        {
            get { return _prname; }
            set { _prname = value.Substring(0, 50); }
        }
        public bool IsReceiptPrinter
        {
            get { return _isReceiptPrinter; }
            set { _isReceiptPrinter = value; }
        }

        public POSPrinter(int prid, string location, string prname, bool isReceiptPrint)
        {
            _prid = prid;
            _location = location;
            _prname = prname;
            _isReceiptPrinter = isReceiptPrint;
        }

        public void Save()
        {
            if (_prid == -1)
            {
                _prid = DataHelper.InsertPrinter(this);
            }
            else
            {
                DataHelper.UpdatePrinter(this);
            }
        }


        public void Delete()
        {
            if (_prid > 0)
            {
                DataHelper.DeletePrinter(_prid);
            }
        }

        public override string ToString()
        {
            return _location;
        }
    }
}
