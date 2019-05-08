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
    public partial class frmEditPriceLevels : Form
    {
        private POSPriceLevel _priceLevel;
        private TextBox _txtName;

        public frmEditPriceLevels()
        {
            InitializeComponent();

        }

        void cboPriceLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            _priceLevel = cboPriceLevel.GetSelectedPriceLevel();
            txtRate.Text = _priceLevel.PriceLevelRate.ToString();
            txtDescription.Text = _priceLevel.PriceLevelDescription;

            BindingList<POSPriceLevelException> exceptions =
                DataHelper.GetPriceLevelExceptions(_priceLevel.PriceLevelId);

            dgRules.DataSource = exceptions;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddException_Click(object sender, EventArgs e)
        {
            frmAddPriceLevelException frm = new frmAddPriceLevelException(_priceLevel);
            frm.ShowDialog();

            BindingList<POSPriceLevelException> rules =
               DataHelper.GetPriceLevelExceptions(_priceLevel.PriceLevelId);

            dgRules.DataSource = rules;
        }

        private void btnRemoveException_Click(object sender, EventArgs e)
        {
            if (dgRules.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgRules.SelectedRows)
                {
                    POSPriceLevelException exception =
                        row.DataBoundItem as POSPriceLevelException;
                    DataHelper.DeletePriceLevelException(exception);
                }
                dgRules.DataSource = null;
                dgRules.DataSource = DataHelper.GetPriceLevelExceptions(_priceLevel.PriceLevelId);
            }
            else
            {
                MessageBox.Show("Please select entire row to remove.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_txtName != null && _txtName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please enter a name for this price level.");
                _txtName.Focus();
                return;
            }
            try
            {
                Convert.ToDouble(txtRate.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid rate.");
                txtRate.Focus();
                return;
            }

            if (_txtName != null)
            {
                _priceLevel.PriceLevelName = _txtName.Text;
            }
            _priceLevel.PriceLevelDescription = txtDescription.Text;
            _priceLevel.PriceLevelRate = Convert.ToDouble(txtRate.Text);
            int plid = DataHelper.SavePriceLevel(_priceLevel);

            if (_txtName != null)
            {
                pnlName.Controls.Remove(_txtName);
                cboPriceLevel = new PriceLevelCombo(plid);
                cboPriceLevel.SelectedIndexChanged += new EventHandler(cboPriceLevel_SelectedIndexChanged);
                pnlName.Controls.Add(cboPriceLevel, 1,0);

            }

        }

        private void btnAddPriceLevel_Click(object sender, EventArgs e)
        {
            _priceLevel = new POSPriceLevel(-1, string.Empty, string.Empty, 1);
            txtRate.Text = _priceLevel.PriceLevelRate.ToString();
            txtDescription.Text = _priceLevel.PriceLevelDescription;

            pnlName.Controls.Remove(cboPriceLevel);
            _txtName = new TextBox();
            _txtName.MaxLength = 50;
            pnlName.Controls.Add(_txtName, 1, 0);

            dgRules.DataSource = null;
        }


       
        
    }
}
