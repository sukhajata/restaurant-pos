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
    public partial class frmSplit : Form
    {
        private POSOrder orderLeft;
        private POSOrder orderRight;
        private frmMain parent;

        public frmSplit(POSOrder order, frmMain p)
        {
            InitializeComponent();
            orderLeft = order;
            orderRight = new POSOrder();
            parent = p;
            parent.TransactionComplete += new frmMain.TransactionCompleteEventHandler(parent_TransactionComplete);
            UpdateDgLeft();
            UpdateTotal();
        }

        private void parent_TransactionComplete(object sender, EventArgs e)
        {
            orderRight = new POSOrder();
        }

        private void btnRightToLeft_Click(object sender, EventArgs e)
        {
            POSItemTill item = parent.GetSelectedOrderItem();
            if (item != null)
            {
                orderLeft.OrderItems.Add(item);
                UpdateDgLeft();
                orderRight.OrderItems.Remove(item);
                parent.RemoveOrderItem(item);
                UpdateTotal();
            }
        }

        private void btnLeftToRight_Click(object sender, EventArgs e)
        {
            if (dgLeft.SelectedRows.Count > 0)
            {
                POSItemTill item = orderLeft.OrderItems[dgLeft.SelectedRows[0].Index];
                orderRight.OrderItems.Add(item);
                orderLeft.OrderItems.Remove(item);
                parent.LoadOrder(orderRight);
                UpdateDgLeft();
                UpdateTotal();
                if (orderLeft.OrderItems.Count == 0)
                {
                    this.Close();
                }
               
                
            }
        }

        private void UpdateDgLeft()
        {
            dgLeft.DataSource = null;
            dgLeft.DataSource = orderLeft.OrderItems;

        }

        private void UpdateTotal()
        {
            double total = 0;
            foreach (POSItemTill item in orderLeft.OrderItems)
            {
                total = total + item.SalePrice * item.Quantity;
            }
            txtTotal.Text = String.Format("{0:c}", total);
        }


        private void btnAllLeftToRight_Click(object sender, EventArgs e)
        {
            if (dgLeft.SelectedRows.Count > 0)
            {
                foreach (POSItemTill item in orderLeft.OrderItems)
                {
                    orderRight.OrderItems.Add(item);
                }
                orderLeft.OrderItems.Clear();
                parent.LoadOrder(orderRight);
               
                this.Close();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmTables frm = new frmTables(frmTables.mode.save, orderLeft);
            frm.ShowDialog();
            this.Close();
        }



    }
}
