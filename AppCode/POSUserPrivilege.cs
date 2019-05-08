using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSUserPrivilege
    {
        private int _prid;
        private string _prname;
        private bool _allowed;

        public int PrivilegeId
        {
            get { return _prid; }
        }
        public string PrivilegeName
        {
            get { return _prname; }
        }
        public bool Allowed
        {
            get { return _allowed; }
            set { _allowed = value; }
        }

        public POSUserPrivilege(int prid, string prname, bool allowed)
        {
            _prid = prid;
            _prname = prname;
            _allowed = allowed;
        }


    }
}
