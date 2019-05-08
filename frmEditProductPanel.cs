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
    public partial class frmEditProductPanel : Form
    {
        private POSProduct _product;
        private frmMainEdit _parent;
        private Button _productButton;

        public frmEditProductPanel(Button btn, frmMainEdit parent)
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.Location = new Point(r.Width - this.Width, 35);
            this.TopMost = true;
            _product = (POSProduct)btn.Tag;
            _parent = parent;
            _productButton = btn;
            Setup();
        }

        private void Setup()
        {
            txtProductName.Text = _product.Product;
            txtButtonText.Text = _product.ButtonText;
        }

        private void btnProductDetails_Click(object sender, EventArgs e)
        {
            frmEditProduct frm = new frmEditProduct(_product);
            frm.ShowDialog();
            _product = DataHelper.GetProduct(_product.ProductId);
            Setup();
            _parent.Setup();
            this.Close();
        }

        private void btnUpUp_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, 0, -8 * Global.GridSpacing);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, 0, -1 * Global.GridSpacing);                
            
        }

        private void btnLeftLeft_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, -8 * Global.GridSpacing , 0);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, -1 * Global.GridSpacing, 0);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, 0, Global.GridSpacing);
        }

        private void btnDownDown_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, 0, 8 * Global.GridSpacing);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, Global.GridSpacing, 0);
        }

        private void btnRightRight_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_productButton, 8 * Global.GridSpacing, 0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This product will be completely removed",
                "Confirm", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                DataHelper.DeleteProduct(_product.ProductId);
            }
            _parent.BuildSection(_parent.CurrentSection, _parent.SelectedTab);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _product.Product = txtProductName.Text;
            if (!txtButtonText.Equals(string.Empty))
            {
                _product.ButtonText = txtButtonText.Text;
            }
            DataHelper.SaveProduct(_product);
            _parent.BuildSection(_parent.CurrentSection, _parent.SelectedTab);
            this.Close();
        }

    }
}
