using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSTable
    {
        private int _tid;
        private string _tname;
        private int _rid;
        private int _x;
        private int _y;
        private int _hid; //hold id

        public int Tid
        {
            get { return _tid; }
        }
        public string Tname
        {
            get 
            {
                if (_tname == null) return string.Empty;
                else return _tname;
            }
            set { _tname = value; }
        }
        public int Rid
        {
            get { return _rid; }
            set { _rid = value; }
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Hid
        {
            get { return _hid; }
        }

        public POSTable(int tid, string tname, int rid, int x, int y)
        {
            _tid = tid;
            _tname = tname;
            _rid = rid;
            _x = x;
            _y = y;
            _hid = 0;
        }

        public POSTable(int tid, int hid, string tname, int rid, int x, int y)
        {
            _tid = tid;
            _hid = hid;
            _tname = tname;
            _rid = rid;
            _x = x;
            _y = y;
        }

    }
}