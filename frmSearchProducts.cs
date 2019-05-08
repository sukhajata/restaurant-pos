using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;
using Bliss_POS.CustomControls;

namespace Bliss_POS
{
    public partial class frmSearchProducts : Form
    {
        private TextBox txtName;
        private frmMain parent;
        public enum Mode { Edit, Select }
        private Mode currentMode;
        private BindingList<POSProductSearchResult> _products;

        public frmSearchProducts(frmMain p, Mode m)
        {
            InitializeComponent();
            parent = p;
            currentMode = m;
            BuildFilter();
            POSKeyboard keyboard = new POSKeyboard();
            pnlKeyboard.Controls.Add(keyboard);
            keyboard.KeyboardClick += new POSKeyboard.KeyboardClickEventHandler(keyboard_KeyboardClick);
        }

        void keyboard_KeyboardClick(object sender, POSKeyboardEventArgs e)
        {
            if (e.KeyboardKeyPressed != null)
            {
                if (e.KeyboardKeyPressed.Equals("BACKSPACE"))
                {
                    if (txtName.Text.Length > 0)
                    {
                        txtName.Text = txtName.Text.Substring(0, txtName.Text.Length - 1);
                    }
                }
                else if (e.KeyboardKeyPressed.Equals("CLEAR"))
                {
                    txtName.Text = string.Empty;
                }
                else
                {
                    txtName.Text += e.KeyboardKeyPressed;
                }
            }
        }

        public void Rebuild()
        {
            RefreshProductTable();
            //refresh parent form
            parent.Rebuild();
        }

        private void BuildFilter()
        {
            txtName = new TextBox();
            txtName.Dock = DockStyle.Fill;
            txtName.Font = new Font("Candara", 12);
            txtName.MaxLength = 50;
            txtName.TextChanged += new EventHandler(txtName_TextChanged);
            pnlFilter.Controls.Add(txtName, 1, 0);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            RefreshProductTable();
        }

        private void RefreshProductTable()
        {
            string name = txtName.Text;
            _products = DataHelper.SearchProducts(name);
            dgProducts.DataSource = null;
            BuildProductTable();
        }

        private void BuildProductTable()
        {
            dgProducts.DataSource = _products;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (currentMode == Mode.Select)
            {
                if (dgProducts.SelectedRows.Count > 0)
                {
                    POSProductSearchResult prod = dgProducts.SelectedRows[0].DataBoundItem 
                        as POSProductSearchResult;
                    parent.retval = prod.ConvertToPOSProduct();
                    this.Close();
                }

            }
        }       

    }
}
