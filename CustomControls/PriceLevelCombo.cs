using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    public class PriceLevelCombo : ComboBox
    {
        private Dictionary<int, POSPriceLevel> _idxToPriceLevelMapping;
        private List<POSPriceLevel> _priceLevels;

        public PriceLevelCombo()
        {
            _priceLevels = DataHelper.GetPriceLevels();
            _idxToPriceLevelMapping = new Dictionary<int, POSPriceLevel>();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Width = 200;
            int idx = 0;
            foreach (POSPriceLevel pl in _priceLevels)
            {
                this.Items.Add(pl);
                _idxToPriceLevelMapping.Add(idx, pl);
                idx++;
            }
        }

        public PriceLevelCombo(int plid)
        {
            _priceLevels = DataHelper.GetPriceLevels();
            _idxToPriceLevelMapping = new Dictionary<int, POSPriceLevel>();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Width = 200;
            int idx = 0;
            foreach (POSPriceLevel pl in _priceLevels)
            {
                this.Items.Add(pl);
                _idxToPriceLevelMapping.Add(idx, pl);
                if (pl.PriceLevelId == plid)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
        }

        public POSPriceLevel GetSelectedPriceLevel()
        {
            if (this.SelectedIndex >= 0)
            {
                return _idxToPriceLevelMapping[this.SelectedIndex];
            }
            return null;
        }

    }
}
