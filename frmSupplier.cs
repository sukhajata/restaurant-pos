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
    public partial class frmSupplier : Form
    {
        private SupplierTypeCombo cboType;

        public frmSupplier()
        {
            InitializeComponent();
            CenterToScreen();
            cboType = new SupplierTypeCombo();
            pnlSupplier.Controls.Add(cboType, 1, 5);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                POSSupplier supplier = new POSSupplier(-1, txtName.Text,
                    txtPhone.Text, txtAddress.Text, Convert.ToDouble(txtMarkup.Text),
                    Convert.ToDouble(txtRate.Text), cboType.GetSupplierType());
                int id = DataHelper.SaveSupplier(supplier);
                Global.SupplierId = id;
                this.Close();
            }
        }

        private bool IsValid()
        {
            try
            {
                Convert.ToDouble(txtMarkup.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Markup");
                return false;
            }
            try
            {
                Convert.ToDouble(txtRate.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid rate");
                return false;
            }
            return true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
