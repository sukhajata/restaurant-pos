using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    class SectionCombo : ComboBox
    {
        private Dictionary<int, POSSection> _indexToSectionMapping;

        public SectionCombo()
        {
            Create(0, false);
        }

        public SectionCombo(bool enableSelectAll)
        {
            Create(-1, enableSelectAll);
        }

        public SectionCombo(int selectedSection)
        {
            Create(selectedSection, false);
        }

        public SectionCombo(int selectedSection, bool enableSelectAll)
        {
            Create(selectedSection, enableSelectAll);
        }


        public void Create(int selectedSection, bool enableSelectAll)
        {
            _indexToSectionMapping = new Dictionary<int, POSSection>();
            this.Width = 200;
            this.Height = 40;
            this.DropDownStyle = ComboBoxStyle.DropDownList; //disable user typing
            List<POSSection> sections = DataHelper.GetSections();
            int idx = 0;
            if (enableSelectAll)
            {
                this.Items.Add("--- All ---");
                _indexToSectionMapping.Add(idx, null);
                this.SelectedIndex = idx;
                idx++;
            }
            foreach (POSSection sec in sections)
            {
                this.Items.Add(sec);
                _indexToSectionMapping.Add(idx, sec);
                if (sec.SectionId == selectedSection)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
        }

        public POSSection GetSection()
        {
            if (this.SelectedIndex >= 0)
            {
                return _indexToSectionMapping[this.SelectedIndex];
            }
            return null;
        }

        public int GetSectionId()
        {
            int idx = this.SelectedIndex;
            if (idx >= 0)
            {
                if(_indexToSectionMapping[idx] != null)
                {
                    return _indexToSectionMapping[idx].SectionId;
                }
            }

            return -1;
            
        }
    }
}
