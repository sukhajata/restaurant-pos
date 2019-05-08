using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    class POSRoom
    {
        private int _rid;
        private string _rname;

        public int Rid
        {
            get { return _rid; }
            set { _rid = value; }
        }
        public string Rname
        {
            get { return _rname; }
            set { _rname = value; }
        }

        public POSRoom(int rid, string rname)
        {
            _rid = rid;
            _rname = rname;
        }

        public bool HasHolds()
        {
            return DataHelper.RoomHasHolds(_rid);
        }

    }
}