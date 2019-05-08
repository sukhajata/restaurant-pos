using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    public class GroupCombo : ComboBox
    {
        private Dictionary<int, int> indexToIdMapping;

        public GroupCombo(int gid)
        {
            indexToIdMapping = new Dictionary<int, int>();
            this.Width = 200;
            this.Height = 40;
            this.Font = new System.Drawing.Font("Candara", 10);
            this.DropDownStyle = ComboBoxStyle.DropDownList; //disable user typing
            List<POSGroup> groups = DataHelper.GetGroups();
            int idx = 0;
            foreach (POSGroup group in groups)
            {
                this.Items.Add(group);
                indexToIdMapping.Add(idx, group.GroupId);
                if (group.GroupId == gid)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
        }

        public int GetGroupId()
        {
            int idx = this.SelectedIndex;
            return indexToIdMapping[idx];

        }

    }
}
