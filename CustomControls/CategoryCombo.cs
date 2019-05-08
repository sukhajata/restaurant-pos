using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    class CategoryCombo : ComboBox
    {
        private Dictionary<int, POSCategory> _indexToCategoryMapping;

        public CategoryCombo()
        {
            Create(1, 1, false);
        }

        public CategoryCombo(bool enableSelectAll)
        {
            Create(-1, 1, enableSelectAll);
        }

        public CategoryCombo(int sid, int selectedCategory)
        {
            Create(sid, selectedCategory, false);
        }

        public CategoryCombo(int sid, int selectedCategory, bool enableSelectAll)
        {
            Create(sid, selectedCategory, enableSelectAll);
        }

        public void Create(int sid, int selectedCategory, bool enableSelectAll)
        {
            _indexToCategoryMapping = new Dictionary<int, POSCategory>();
            this.Width = 200;
            this.Height = 40;
            if (sid == -1) //no selected section
            {
                return;
            }
            this.DropDownStyle = ComboBoxStyle.DropDownList; //disable user typing
            List<POSCategory> categories = DataHelper.GetCategories(sid);
            int idx = 0;
            if (enableSelectAll)
            {
                this.Items.Add("--- All ---");
                _indexToCategoryMapping.Add(idx, null);
                if (selectedCategory == 0)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
            foreach (POSCategory cat in categories)
            {
                this.Items.Add(cat);
                _indexToCategoryMapping.Add(idx, cat);
                if (cat.CategoryId == selectedCategory)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
        }

        public POSCategory GetCategory()
        {
            if (this.SelectedIndex >= 0)
            {
                if (_indexToCategoryMapping[this.SelectedIndex] != null)
                {
                    return _indexToCategoryMapping[this.SelectedIndex];
                }
            }

            return null;
        }

        public int GetCategoryId()
        {
            if (this.SelectedIndex >= 0)
            {
                int idx = this.SelectedIndex;
                if (_indexToCategoryMapping[idx] != null)
                {
                    return _indexToCategoryMapping[idx].SectionId;
                }
            }
            return -1;
            
        }
    }
}
