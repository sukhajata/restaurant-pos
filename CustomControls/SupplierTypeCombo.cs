using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    public class SupplierTypeCombo : ComboBox 
    {
        private Dictionary<int, int> _idxToIdMapping;

        public SupplierTypeCombo(int type)
        {
            List<POSSupplierType> types = DataHelper.GetSupplierTypes();
            Create();
            int idx = 0;
            foreach (POSSupplierType st in types)
            {
                this.Items.Add(st);
                _idxToIdMapping.Add(idx, st.SupplierTypeId);
                if (st.SupplierTypeId == type)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
        }

        private void Create()
        {
            _idxToIdMapping = new Dictionary<int, int>();
            this.Width = 200;
        }

        public SupplierTypeCombo()
        {
            List<POSSupplierType> types = DataHelper.GetSupplierTypes();
            Create();
            int idx = 0;
            foreach (POSSupplierType st in types)
            {
                this.Items.Add(st);
                _idxToIdMapping.Add(idx, st.SupplierTypeId);
                this.SelectedIndex = idx;
                idx++;
            }
            if (types.Count > 0)
            {
                this.SelectedIndex = 0;
            }
        }

        public int GetSupplierType()
        {
            return _idxToIdMapping[this.SelectedIndex];            
        }

    }
}
