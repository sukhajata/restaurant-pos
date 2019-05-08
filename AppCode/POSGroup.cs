using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSGroup
    {
        private int _gid;
        private string _gname;

        public int GroupId
        {
            get { return _gid; }
            set { _gid = value; }
        }
        public string GroupName
        {
            get { return _gname; }
            set { _gname = value; }
        }

        public POSGroup(int gid, string gname)
        {
            _gid = gid;
            _gname = gname;
        }

        public override string ToString()
        {
            return _gname;
        }

    }
}
