using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;
using Bliss_POS.CustomControls;

namespace Bliss_POS
{
    public partial class frmUsers : Form
    {
        private List<POSUser> users;

        public frmUsers()
        {
            InitializeComponent();
            users = DataHelper.GetUsers();
            BuildTable();
        }

        private void BuildTable()
        {
            foreach (POSUser user in users)
            {
                TextBox txtFirstName = new TextBox();
                txtFirstName.Text = user.Firstname;
                txtFirstName.Width = 140;
                txtFirstName.MaxLength = 50;
                txtFirstName.Tag = user;
                txtFirstName.TextChanged += new EventHandler(txtFirstName_TextChanged);
                pnlUsers.Controls.Add(txtFirstName);

                TextBox txtLastName = new TextBox();
                txtLastName.Text = user.Lastname;
                txtFirstName.Width = 140;
                txtFirstName.MaxLength = 50;
                txtLastName.Tag = user;
                txtLastName.TextChanged += new EventHandler(txtLastName_TextChanged);
                pnlUsers.Controls.Add(txtLastName);

                TextBox txtUsername = new TextBox();
                txtUsername.Text = user.Username;
                txtFirstName.Width = 140;
                txtFirstName.MaxLength = 20;
                txtUsername.Tag = user;
                txtUsername.TextChanged += new EventHandler(txtUsername_TextChanged);
                pnlUsers.Controls.Add(txtUsername);

                TextBox txtPassword = new TextBox();
                txtPassword.Text = user.Password;
                txtFirstName.Width = 140;
                txtFirstName.MaxLength = 10;
                txtPassword.Tag = user;
                txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);
                pnlUsers.Controls.Add(txtPassword);

                UserTypeCombo cboUserType = new UserTypeCombo(user.UserTypeId);
                cboUserType.Tag = user;
                cboUserType.SelectedIndexChanged += new EventHandler(cboUserType_SelectedIndexChanged);
                pnlUsers.Controls.Add(cboUserType);

                Button btnPrivileges = new Button();
                btnPrivileges.Text = "Privileges";
                btnPrivileges.Dock = DockStyle.Fill;
                btnPrivileges.Tag = user;
                btnPrivileges.Click += new EventHandler(btnPrivileges_Click);
                pnlUsers.Controls.Add(btnPrivileges);

                Button btnDelete = new Button();
                btnDelete.Text = "Delete";
                btnDelete.Dock = DockStyle.Fill;
                btnDelete.Tag = user;
                btnDelete.Click += new EventHandler(btnDelete_Click);
                pnlUsers.Controls.Add(btnDelete);
            }
        }

        void btnPrivileges_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSUser user = (POSUser)btn.Tag;
            if (user.Uid == -1)
            {
                int newid = DataHelper.InsertUser(user);
                user.Uid = newid;
            }
            frmPrivileges frm = new frmPrivileges(user);
            frm.ShowDialog();
        }

        void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserTypeCombo cbo = (UserTypeCombo)sender;
            POSUser user = (POSUser)cbo.Tag;
            user.UserTypeId = cbo.GetUserTypeId();
        }

        void txtPassword_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSUser user = (POSUser)txt.Tag;
            user.Password = txt.Text;
        }

        void txtUsername_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSUser user = (POSUser)txt.Tag;
            user.Username = txt.Text;
        }

        void txtLastName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSUser user = (POSUser)txt.Tag;
            user.Lastname = txt.Text;
        }

        void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSUser user = (POSUser)txt.Tag;
            user.Firstname = txt.Text;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("User will be deleted", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Button btn = (Button)sender;
                POSUser user = (POSUser)btn.Tag;
                users.Remove(user);
                if (user.Uid > 0)
                {
                    DataHelper.DeleteUser(user.Uid);
                }
                pnlUsers.Controls.Clear();
                BuildTable();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            POSUser newUser = new POSUser(-1, string.Empty, string.Empty, string.Empty,
                string.Empty, 1);
            users.Add(newUser);
            pnlUsers.Controls.Clear();
            BuildTable();
        }

        private bool ValidateUsers()
        {
            foreach (POSUser user in users)
            {
                if (user.Firstname.Equals(""))
                {
                    return false;
                }
                if (user.Lastname.Equals(""))
                {
                    return false;
                }
                if (user.Username.Equals(""))
                {
                    return false;
                }
                if (user.Password.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUsers())
            {
                DataHelper.SaveUsers(users);
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields are required.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
