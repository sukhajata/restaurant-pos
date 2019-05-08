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
    public partial class frmBrowser : Form
    {
        public frmBrowser(string url)
        {
            InitializeComponent();
            webBrowser1.Navigate(url);
        }

        public frmBrowser()
        {
            InitializeComponent();
        }

        public void Navigate(string url)
        {
            webBrowser1.Navigate(url);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

    }
}
