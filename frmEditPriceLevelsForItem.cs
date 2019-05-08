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
    public partial class frmEditPriceLevelsForItem : Form
    {
        private POSItemEdit _item;
        private List<POSPriceLevel_Item> _priceLevels;

        public frmEditPriceLevelsForItem(POSItemEdit item)
        {
            InitializeComponent();
            CenterToScreen();
            _item = item;
            _priceLevels = DataHelper.GetPriceLevelsForItem(item.ItemId);
            dgPriceLevels.CellValidating += new DataGridViewCellValidatingEventHandler(dgPriceLevels_CellValidating);
            dgPriceLevels.CellEndEdit += new DataGridViewCellEventHandler(dgPriceLevels_CellEndEdit);
            dgPriceLevels.DataSource = _priceLevels;
            
        }

        void dgPriceLevels_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgPriceLevels.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        void dgPriceLevels_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
                dgPriceLevels.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the Rate column.
            if (!headerText.Equals("Rate")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dgPriceLevels.Rows[e.RowIndex].ErrorText =
                    "Please enter rate.";
                e.Cancel = true;
            }
            else
            {
                try
                {
                    Convert.ToDouble(e.FormattedValue.ToString());
                }
                catch (Exception)
                {
                    dgPriceLevels.Rows[e.RowIndex].ErrorText =
                        "Please enter a valid decimal.";
                    e.Cancel = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (POSPriceLevel_Item pl in _priceLevels)
            {
                DataHelper.SavePriceLevelItem(pl.PriceLevel_ItemId, pl.Rate);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
