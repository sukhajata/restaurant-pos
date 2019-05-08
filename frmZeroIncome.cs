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
    public partial class frmZeroIncome : Form
    {
        private frmMain _parent;

        public frmZeroIncome(frmMain p)
        {
            _parent = p;
            InitializeComponent();
            BuildButtons();
            CenterToScreen();
        }

        private void BuildButtons()
        {
            List<POSZeroIncomeType> types = DataHelper.GetZeroIncomeTypes();
            foreach (POSZeroIncomeType t in types)
            {
                Button btn = new Button();
                btn.Text = t.Ztname;
                btn.Size = new Size(90, 80);
                btn.BackColor = Global.Green;
                btn.Tag = t;
                btn.Click += new EventHandler(btn_Click);
                pnlButtons.Controls.Add(btn);
            }
            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(90, 80);
            btnCancel.BackColor = Global.Yellow;
            btnCancel.Click += new EventHandler(btnCancel_Click);
            pnlButtons.Controls.Add(btnCancel);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ztid = ((POSZeroIncomeType)btn.Tag).Ztid;
            _parent.Ztid = ztid;
            this.Close();
        }

    }
}
