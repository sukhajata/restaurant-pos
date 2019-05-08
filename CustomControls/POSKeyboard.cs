using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bliss_POS.CustomControls
{
    public partial class POSKeyboard : UserControl
    {
        public POSKeyboard()
        {
            InitializeComponent();
            BuildButtons();
        }

        public delegate void KeyboardClickEventHandler(object sender, POSKeyboardEventArgs e);
        public event KeyboardClickEventHandler KeyboardClick;

        protected virtual void OnKeyBoardClick(POSKeyboardEventArgs e)
        {
            if (KeyboardClick != null)
            {
                KeyboardClick(this, e);
            }
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
            btn.Click += new EventHandler(btn_Click);
            return btn;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OnKeyBoardClick(new POSKeyboardEventArgs(btn.Text));
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            OnKeyBoardClick(new POSKeyboardEventArgs("BACKSPACE"));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            OnKeyBoardClick(new POSKeyboardEventArgs("CLEAR"));
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            OnKeyBoardClick(new POSKeyboardEventArgs(" "));
        }

    }

    public class POSKeyboardEventArgs : EventArgs
    {
        private readonly string pvtKeyboardKeyPressed;

        public POSKeyboardEventArgs(string KeyboardKeyPressed)
        {
            this.pvtKeyboardKeyPressed = KeyboardKeyPressed;
        }

        public string KeyboardKeyPressed
        {
            get
            {
                return pvtKeyboardKeyPressed;
            }
        }
    }
}
