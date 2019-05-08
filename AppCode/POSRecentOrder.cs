using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSRecentOrder
    {
        private int _oid;
        private DateTime _odate;
        private string _username;
        private int _guestCount;
        private double _total;

        [Browsable(false)]
        public int Id
        {
            get { return _oid; }
        }
        public string Time
        {
            get { return String.Format("{0:g}", _odate); }
        }
        public string Username
        {
            get { return _username; }
        }
        public int GuestCount
        {
            get { return _guestCount; }
        }
        [Browsable(false)]
        public double Total
        {
            get { return _total; }
        }
        public string Total_Sale
        {
            get { return String.Format("{0:c}", _total); }
        }

        public POSRecentOrder(int oid, DateTime odate, string username, int guestCount,
            double total)
        {
            _oid = oid;
            _odate = odate;
            _username = username;
            _guestCount = guestCount;
            _total = total;
        }

    }
}
