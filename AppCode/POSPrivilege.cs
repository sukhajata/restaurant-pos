using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSPrivilege
    {
        private int _prid;
        private string _prname;
        private List<int> _usertypes;
        public static int PRICE_OVERRIDE = 1;
        public static int PRICE_LEVEL = 2;
        public static int ZERO_INCOME = 3;
        public static int EDIT_SECTIONS_AND_CATEGORIES = 4;
        public static int EDIT_PRODUCTS = 5;
        public static int USE_EDIT_MODE = 6;
        public static int EDIT_USERS = 7;
        public static int EDIT_PRICE_LEVELS = 8;
        public static int EDIT_TABLES = 9;
        public static int EDIT_ROOMS = 10;
        public static int USE_TRAINING_MODE = 11;
        public static int VIEW_REPORTS = 12;

        public int PrivilegeId
        {
            get { return _prid; }
        }
        public string PrivilegeName
        {
            get { return _prname; }
        }
        public List<int> UserTypes
        {
            get { return _usertypes; }
        }

        public POSPrivilege(int prid, string prname, List<int> usertypes)
        {
            _prid = prid;
            _prname = prname;
            _usertypes = usertypes;
        }
    }
}
