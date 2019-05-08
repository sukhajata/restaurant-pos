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
    public partial class Qwerty : Form
    {
        public static string DELETE = "Delete";

        public Qwerty(string text)
        {
            InitializeComponent();
            txtInput.Text = text;
            BuildButtons();
            CenterToScreen();
            txtInput.SelectAll();
        }

        private void BuildButtons()
        {
            for (int i = 1; i < 10; i++)
            {
                Button btn = BuildButton(Convert.ToString(i));
                pnlNumbers.Controls.Add(btn);
            }
            Button btn0 = BuildButton("0");
            pnlNumbers.Controls.Add(btn0);
            Button btnBackspace = new Button();
            btnBackspace.Text = "Backspace";
            btnBackspace.Size = new Size(140, 70);
            btnBackspace.BackColor = SystemColors.Control;
            btnBackspace.Click += new EventHandler(btnBackspace_Click);
            pnlNumbers.Controls.Add(btnBackspace);

            string[] firstRow = new string[] {"Q", "W", "E", "R", "T", "Y", "U", "I",
                "O", "P"};
            BuildRow(firstRow, pnlQ);
            string[] secondRow = new string[] {"A", "S", "D", "F", "G", "H", "J", "K",
                "L"};
            BuildRow(secondRow, pnlA);
            string[] thirdRow = new string[] {"Z", "X", "C", "V", "B", "N", "M", ",", 
                "." };
            BuildRow(thirdRow, pnlZ);
        }

        private void BuildRow(string[] letters, TableLayoutPanel panel)
        {
            foreach (string s in letters)
            {
                Button btn = BuildButton(s);
                panel.Controls.Add(btn);
            }
        }

        private Button BuildButton(string txt)
        {
            Button btn = new Button();
            btn.Text = txt;
            btn.Size = new Size(70, 70);
            btn.BackColor = SystemColors.Control;
            btn.Click += new EventHandler(btn_Click);
            return btn;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtInput.Text = txtInput.Text + btn.Text;
            txtInput.Focus();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length > 0)
            {
                string s = txtInput.Text;
                txtInput.Text = s.Substring(0, s.Length - 1);
            }
            txtInput.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInput.Text = txtInput.Text + " ";
            txtInput.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Global.KeyboardInput = txtInput.Text;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Global.KeyboardInput = DELETE;
            this.Close();
        }

        
    }
}
