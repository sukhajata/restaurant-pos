using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS
{
    public class POSContext : ApplicationContext
    {
        public List<POSUser> _loggedInUsers;
        private frmMain _main;
        public bool ProductChanged;

        public frmMain Main
        {
            get { return _main; }
        }

        public POSContext()
        {
            _loggedInUsers = new List<POSUser>();
            ProductChanged = false;
            _main = new frmMain(this);
            _main.Show();
            frmLogin frm = new frmLogin(this);
            frm.ShowDialog();
            _main.SetFocus();
        }

        public void Login()
        {
            _main.UpdateMessage();
            _main.RunUserPrivileges();
        }

        public void Logout()
        {
            frmLogin frm = new frmLogin(this);
            frm.ShowDialog();
        }

        public void Quit(Form frm)
        {
            frm.Close();
            Application.Exit();
        }

        public bool IsPrePay()
        {
            return Properties.Settings.Default.Prepay;
        }

    }

}
