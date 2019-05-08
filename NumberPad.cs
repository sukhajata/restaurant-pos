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
    public partial class NumberPad : Form
    {
        protected int total;

        public NumberPad(string title, int initialAmount)
        {
            InitializeComponent();
            CenterToScreen();
            this.Text = title;
            BuildNumericButtons();
            txtDisplay.Text = Convert.ToString(initialAmount);
            txtDisplay.SelectAll();
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
            btn.Click += new EventHandler(btnNumeric_Click);
            pnlNumeric.Controls.Add(btn, col, row);
        }

        private void btnNumeric_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (txtDisplay.SelectedText.Equals(string.Empty))
            {
            }
            else
            {
                txtDisplay.Text = txtDisplay.SelectedText.Remove(0);
            }
            txtDisplay.Text = txtDisplay.Text + btn.Tag;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double amount;
            try
            {
                amount = Convert.ToDouble(txtDisplay.Text);
            }
            catch (Exception)
            {
                amount = 0;
            }
            Global.UserInput = amount;
            this.Close();
        }
    }
}
