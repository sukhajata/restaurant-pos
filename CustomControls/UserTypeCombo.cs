using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS.CustomControls
{
    public partial class UserTypeCombo : ComboBox
    {
        private Dictionary<int, string> userTypes;

        public UserTypeCombo(int selectedType)
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList; //disable user typing
            userTypes = DataHelper.GetUserTypes();

            int idx = 0;
            foreach (KeyValuePair<int, string> pair in userTypes)
            {
                this.Items.Add(pair.Value);
                if (pair.Key == selectedType)
                {
                    this.SelectedIndex = idx;
                }
                idx++;
            }
        }

        public int GetUserTypeId()
        {
            string usertype = this.Text;
            foreach (KeyValuePair<int, string> pair in userTypes)
            {
                if (pair.Value.Equals(usertype))
                {
                    return pair.Key;
                }
            }
            return -1;
        }
    }
}
