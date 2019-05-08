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
    public partial class frmZeroIncomeTypes : Form
    {
        private List<POSZeroIncomeType> _zeroIncomeTypes;
        
        public frmZeroIncomeTypes()
        {
            InitializeComponent();

            _zeroIncomeTypes = DataHelper.GetZeroIncomeTypes();
            dgZeroIncomeTypes.DataSource = _zeroIncomeTypes;
            CenterToScreen();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataHelper.SaveZeroIncomeTypes(_zeroIncomeTypes);
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            POSZeroIncomeType zi = new POSZeroIncomeType(-1, string.Empty);
            _zeroIncomeTypes.Add(zi);
            dgZeroIncomeTypes.DataSource = null;
            dgZeroIncomeTypes.DataSource = _zeroIncomeTypes;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgZeroIncomeTypes.SelectedRows.Count > 0)
            {
                POSZeroIncomeType zi =
                    dgZeroIncomeTypes.SelectedRows[0].DataBoundItem as POSZeroIncomeType;
                _zeroIncomeTypes.Remove(zi);
                DataHelper.DeleteZeroIncomeType(zi.Ztid);
                dgZeroIncomeTypes.DataSource = null;
                dgZeroIncomeTypes.DataSource = _zeroIncomeTypes;
            }
        }

    }
}
