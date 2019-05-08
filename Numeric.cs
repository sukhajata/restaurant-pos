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
    public partial class Numeric : Form
    {
        protected decimal price;
        protected PriceDisplay priceDisplay;

        public Numeric(bool showNotes, bool showKeys)
        {
            InitializeComponent();
            CenterToScreen();
            if (showNotes)
            {
                BuildNoteButtons();
            }
            if (showKeys)
            {
                BuildNumericButtons();
            }
            priceDisplay = new PriceDisplay();
            txtDisplay.Text = priceDisplay.getPriceString();
        }

        private void BuildNoteButtons()
        {
            Dictionary<string, double> values = new Dictionary<string, double>();
            values.Add("$100", 100.0);
            values.Add("$50", 50.0);
            values.Add("$20", 20.0);
            values.Add("$10", 10.0);
            values.Add("$5", 5.0);
            values.Add("$2", 2.0);
            values.Add("$1", 1.0);
            values.Add("50c", 0.5);
            values.Add("20c", 0.2);

            foreach (KeyValuePair<string, double> pair in values)
            {
                BuildNoteButton(pair.Key, pair.Value);
            }

        }

        private void BuildNoteButton(string txt, double num)
        {
            Button btn = new Button();
            btn.Dock = DockStyle.Fill;
            btn.Text = txt;
            btn.Tag = num;
            btn.Click += new EventHandler(btnNote_Click);
            pnlNotes.Controls.Add(btn);
        }

        void btnNote_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double value = (double)btn.Tag;
            priceDisplay.addNote(value);
            txtDisplay.Text = priceDisplay.getPriceString();
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
                BuildNumericButton(Convert.ToString(num), num, (num - 1) % 3, (num - 1) / 3);
            }
            //00 
            BuildNumericButton("00", -1, 1, 3);            
            //C - removes last digit
            BuildNumericButton("C", -2, 2, 3);

        }

        private void BuildNumericButton(string txt, int num, int col, int row)
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
            int num = (int)btn.Tag;
            priceDisplay.add(num);
            txtDisplay.Text = priceDisplay.getPriceString();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            Global.UserInput = 0;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double price = priceDisplay.getPrice();
            Global.UserInput = price;
            this.Close();
        }

    }
}
