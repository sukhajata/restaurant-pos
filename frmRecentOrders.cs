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
    public partial class frmRecentOrders : Form
    {
        private List<POSRecentOrder> _orders;
        private frmMain _parent;

        public frmRecentOrders(frmMain p)
        {
            InitializeComponent();
            _parent = p;
            _orders = DataHelper.GetRecentOrders();
            dgRecentOrders.DataSource = _orders;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgRecentOrders.SelectedRows.Count > 0)
            {
                POSRecentOrder order = dgRecentOrders.SelectedRows[0].DataBoundItem as POSRecentOrder;
                _parent.LoadCompletedOrder(order.Id);
                this.Close();
            }
        }
    }
}
