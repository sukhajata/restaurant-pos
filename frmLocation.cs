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
    public partial class frmLocation : Form
    {
        private frmMain _parent;

        public frmLocation(frmMain p, int x, int y)
        {
            InitializeComponent(); 
            txtX.Text = Convert.ToString(x / Properties.Settings.Default.gridSpacing);
            txtY.Text = Convert.ToString(y / Properties.Settings.Default.gridSpacing);
            _parent = p;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = false;
            int x = 0;
            int y = 0;
            try
            {
                x = Convert.ToInt32(txtX.Text);
                y = Convert.ToInt32(txtY.Text);
                if (x >= 0 && x < Properties.Settings.Default.numCols && y >= 0
                    && y < Properties.Settings.Default.numRows)
                {
                    valid = true;
                }
            }
            catch (Exception)
            {
            }
            if (valid)
            {
                _parent.NewLocation = new Point(x * Properties.Settings.Default.gridSpacing,
                    y * Properties.Settings.Default.gridSpacing);
            }
            this.Close();
        }
    }
}
