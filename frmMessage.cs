using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bliss_POS
{
    public partial class frmMessage : Form
    {
        public frmMessage(string msg)
        {
            InitializeComponent();
            //txtMessage.Text = msg;
            //txtMessage.Enabled = false;
            CenterToScreen();
        }
    }
}
