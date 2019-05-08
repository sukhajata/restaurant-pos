using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSUser
    {
        private int _uid;
        private string _firstname;
        private string _lastname;
        private string _username;
        private string _password;
        private int _userTypeId;
        private int _index; //position on the login screen

        [Browsable(false)]
        public int Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public int UserTypeId
        {
            get { return _userTypeId; }
            set { _userTypeId = value; }
        }
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public POSUser (int uid, string firstname, string lastname, string username, 
            string password, int utid)
        {
            _uid = uid;
            _firstname = firstname;
            _lastname = lastname;
            _username = username;
            _password = password;
            _userTypeId = utid;
        }

    }
}
