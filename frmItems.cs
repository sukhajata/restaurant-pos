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
    public partial class frmItems : Form
    {
        private List<CheckBox> checkBoxes;

        public frmItems(List<POSItemTill> items)
        {
            InitializeComponent();
            checkBoxes = new List<CheckBox>();
            foreach (POSItemTill item in items)
            {
                Button btn = new Button();
                btn.Height = 90;
                btn.BackColor = Global.Green;
                btn.Dock = DockStyle.Fill;
                btn.Text = item.Variation;
                btn.Tag = item;
                btn.Click += new EventHandler(btn_Click);
                pnlItems.Controls.Add(btn);
            }
            FillInstructions();
            CenterToScreen();
        }

        private void FillInstructions()
        {
            BindingList<POSInstruction> instructions = DataHelper.GetProductInstructions(
                Global.CurrentProduct.ProductId);
            foreach (POSInstruction pi in instructions)
            {
                CheckBox chk = new CheckBox();
                chk.Tag = pi;
                chk.Width = 20;
                checkBoxes.Add(chk);
                pnlInstructions.Controls.Add(chk);
                Label lbl = new Label();
                lbl.Text = pi.Instruction;
                lbl.Width = 400;
                lbl.Height = 35;
                lbl.Padding = new Padding(0, 0, 0, 3);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Tag = chk;
                lbl.Click += new EventHandler(lbl_Click);
                pnlInstructions.Controls.Add(lbl);

            }
            
        }

        void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            CheckBox btn = (CheckBox)lbl.Tag;
            btn.Checked = !btn.Checked;
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSItemTill item = (POSItemTill)btn.Tag;
            Global.CurrentItem = item;

            foreach (CheckBox chk in checkBoxes)
            {
                if (chk.Checked == true)
                {
                    POSInstruction pi = (POSInstruction)chk.Tag;
                    item.AddInstruction(pi);
                }
            }
            
            this.Close();
        }


    }
}
