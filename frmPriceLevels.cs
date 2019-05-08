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
    public partial class frmPriceLevels : Form
    {
        protected frmMain parent;

        public frmPriceLevels(frmMain p)
        {
            InitializeComponent();
            CenterToScreen();
            parent = p;
            lstScope.Items.Add("Whole Order");
            lstScope.Items.Add("Selected Item");
            lstScope.SelectedIndex = 0;
            List<POSPriceLevel> priceLevels = DataHelper.GetPriceLevels();
            foreach (POSPriceLevel pl in priceLevels)
            {
                if (pl.PriceLevelId == 1)
                {
                    btn1.Text = pl.PriceLevelName;
                }
                else if (pl.PriceLevelId == 2)
                {
                    btn2.Text = pl.PriceLevelName;
                }
                else if (pl.PriceLevelId == 3)
                {
                    btn3.Text = pl.PriceLevelName;
                }
            }
        }

        private void SetPriceLevel(int priceLevel)
        {
            parent.PriceLevel = priceLevel;
            parent.PriceLevelScope = lstScope.SelectedIndex;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SetPriceLevel(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SetPriceLevel(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SetPriceLevel(3);
        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            SetPriceLevel(0);
        }
    }
}
