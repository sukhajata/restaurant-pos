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
    public partial class frmConfig : Form
    {
        private List<POSConfigItem> _items;

        public frmConfig()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            _items = DataHelper.GetConfigItems();
            dgConfig.DataSource = _items;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (POSConfigItem item in _items)
            {
                DataHelper.SaveConfig(item.ConfigId, item.ItemName, item.ItemValue);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
