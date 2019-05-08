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
    public partial class frmLogin : Form
    {
        private string password;
        private POSContext context;

        public frmLogin(POSContext con)
        {
            InitializeComponent();
            context = con;
            password = string.Empty;
            CenterToScreen();
            this.ControlBox = false;
            BuildNumericButtons();
            BuildLoginButtons();
            LoadUsers();
        }


        private void BuildNumericButtons()
        {
            //1-9 plus 0
            for (int i = 1; i <= 10; i++)
            {
                int num;
                if (i == 10)
                {
                    num = 0;
                }
                else
                {
                    num = i;
                }
                BuildButton(Convert.ToString(num), num, (num - 1) % 3, (num - 1) / 3);
            }
            

        }

        private void BuildButton(string txt, int num, int col, int row)
        {
            Button btn = new Button();
            btn.Dock = DockStyle.Fill;
            btn.Text = txt;
            btn.Tag = num;
            btn.BackColor = SystemColors.Control;
            btn.Click += new EventHandler(btnNumeric_Click);
            pnlNumeric.Controls.Add(btn, col, row);
        }

        private void LoadUsers()
        {
            foreach (POSUser user in context._loggedInUsers)
            {
                Button btn = (Button)pnlLogins.Controls[user.Index];
                btn.Text = user.Username;
            }
        }

        private void btnNumeric_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int num = (int)btn.Tag;
            password = password + Convert.ToString(num);
        }

        private void BuildLoginButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                Button btnLogin = BuildLoginButton();
                btnLogin.Tag = i;
                pnlLogins.Controls.Add(btnLogin, i, 0);
            }
            for (int i = 0; i < 5; i++)
            {
                Button btnLogin = BuildLoginButton();
                btnLogin.Tag = i + 5;
                pnlLogins.Controls.Add(btnLogin, i, 1);
            }
        }

        private Button BuildLoginButton()
        {
            Button btnLogin = new Button();
            btnLogin.Dock = DockStyle.Fill;
            btnLogin.BackColor = SystemColors.Control;
            btnLogin.Click += new EventHandler(btnLogin_Click);
            return btnLogin;
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text.Equals(string.Empty)) //no user allocated to this button
            {
                bool match = false;
                if (password.Equals(string.Empty))
                {
                    return;
                }
                POSUser user = DataHelper.GetUser(password);
                if (user != null)
                {
                    match = true;
                    bool loggedIn = false;
                    foreach (POSUser loggedInUser in context._loggedInUsers)
                    {
                        if (loggedInUser.Username.Equals(user.Username))
                        {
                            loggedIn = true;
                            break;
                        }
                    }
                    if (!loggedIn)
                    {
                        btn.Text = user.Username;
                        user.Index = (int)btn.Tag;
                        context._loggedInUsers.Add(user);
                    }
                    Global.CurrentUser = user;
                }

               
                if (match)
                {
                    context.Login();
                    this.Close();
                }
                else
                {
                    password = string.Empty; //login failed. Reset password.
                    MessageBox.Show("Invalid password.");
                }
            }
            else //clicking on allocated button
            {
                foreach (POSUser user in context._loggedInUsers)
                {
                    if (user.Username.Equals(btn.Text))
                    {
                        Global.CurrentUser = user;
                        break;
                    }
                }
                context.Login();
                this.Close();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            context.Quit(this);
        }
    }
}
