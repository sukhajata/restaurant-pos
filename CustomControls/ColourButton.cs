using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    class ColourButton : Button
    {
        public delegate void ColourChangedEventHandler(object sender, EventArgs e);
        public event ColourChangedEventHandler ColourChanged;

        public ColourButton(string Colour)
        {
            try
            {
                string[] argb = Colour.Split(',');
                this.BackColor = Color.FromArgb(Convert.ToInt16(argb[0]),
                    Convert.ToInt16(argb[1]), Convert.ToInt16(argb[2]),
                    Convert.ToInt16(argb[3]));
            }
            catch
            {
                this.BackColor = Color.White;
            }
            this.Click += new EventHandler(ColourButton_Click);
        }

        protected virtual void OnColourChanged(EventArgs e)
        {
            if (ColourChanged != null)
            {
                ColourChanged(this, e);
            }
        }

        private void ColourButton_Click(object sender, EventArgs e)
        {
            ColorDialog clrDialog = new ColorDialog();
            DialogResult result = clrDialog.ShowDialog();
            clrDialog.SolidColorOnly = true;
            clrDialog.CustomColors = null;
            if (result == DialogResult.OK)
            {
                this.BackColor = clrDialog.Color;
                OnColourChanged(EventArgs.Empty);
            }
        }

        public string GetColour()
        {
            string strColour = Convert.ToString(this.BackColor.A) + "," +
                Convert.ToString(this.BackColor.R) + "," +
                Convert.ToString(this.BackColor.G) + "," +
                Convert.ToString(this.BackColor.B);
            return strColour;
        }

    }
}
