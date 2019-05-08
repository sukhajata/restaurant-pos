using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    public class SupplierCombo : ComboBox
    {
        private List<POSSupplier> _suppliers;
        private Dictionary<int, POSSupplier> _indextoSupplierMapping;

        public SupplierCombo()
        {
            Create();
            int idx = 0;
            foreach (POSSupplier s in _suppliers)
            {
                this.Items.Add(s);
                _indextoSupplierMapping.Add(idx, s);
                idx++;
            }
        }

        public SupplierCombo(int suid)
        {
            Create();
            int idx = 0;
            foreach (POSSupplier s in _suppliers)
            {
                this.Items.Add(s);
                _indextoSupplierMapping.Add(idx, s);
                if (s.Suid == suid)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
        }

        private void Create()
        {
            _suppliers = DataHelper.GetSuppliers();
            _indextoSupplierMapping = new Dictionary<int, POSSupplier>();
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.Width = 200;
            this.Height = 40;
            this.TextChanged += new EventHandler(SupplierCombo_TextChanged);
        }

        void SupplierCombo_TextChanged(object sender, EventArgs e)
        {
            string txt = this.Text;
            int idx = this.FindString(txt);
            this.DroppedDown = true;
            if (idx >= 0)
            {
                this.SelectedIndex = idx;
            }
            this.Text = txt;
            this.SelectionStart = txt.Length;
            //this.SelectionLength = this.Text.Length - txt.Length;
            
        }

        public string GetSupplierName()
        {
            return this.Text;
        }

        public POSSupplier GetSupplier()
        {
            if (this.SelectedIndex > 0)
            {
                return _indextoSupplierMapping[this.SelectedIndex];
            }
            return null;
        }

        public int GetSupplierId()
        {
            int idx = this.SelectedIndex;
            if (idx >= 0)
            {
                return _indextoSupplierMapping[idx].Suid;
            }

            return -1;
        }

    }
}
