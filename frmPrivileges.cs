using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS
{
    public partial class frmPrivileges : Form
    {
        private POSUser user;
        private List<POSUserPrivilege> userPrivileges;

        public frmPrivileges(POSUser u)
        {
            InitializeComponent();
            user = u;
            txtMessage.Text = "Privileges for " + user.Username;
            userPrivileges = new List<POSUserPrivilege>();
            foreach (KeyValuePair<int, POSUserPrivilege> pair in DataHelper.GetUserPrivileges(user.Uid))
            {
                userPrivileges.Add(pair.Value);
            }
            dgUserPrivileges.DataSource = userPrivileges;
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataHelper.SaveUserPrivileges(user.Uid, userPrivileges);
            this.Close();
        }
    }
}
