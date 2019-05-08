using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;
using Bliss_POS.CustomControls;

namespace Bliss_POS
{
    public partial class frmCategories : Form
    {
        private List<POSCategory> categories;
        private POSSection section;
        private int newCatId; //for new categories before they are added to database

        public frmCategories(POSSection sec)
        {
            InitializeComponent();
            section = sec;
            categories = DataHelper.GetCategories(section.SectionId);
            section = sec;
            BuildTable();
            newCatId = -1; 
        }

        private void BuildTable()
        {
            string[] headers = new string[] { section.SectionName + " Categories", "Back colour", "Fore Colour", "Group",  " " };
            foreach (string header in headers)
            {
                Label lbl = new Label();
                lbl.Text = header;
                pnlCategories.Controls.Add(lbl);
            }
            foreach (POSCategory cat in categories)
            {
                BuildRow(cat);
            }
        }

        private void BuildRow(POSCategory cat)
        {
            TextBox txtName = new TextBox();
            txtName.Width = 180;
            txtName.Text = cat.CategoryName;
            txtName.MaxLength = 50;
            txtName.Tag = cat;
            pnlCategories.Controls.Add(txtName);
            txtName.TextChanged += new EventHandler(txtName_TextChanged);

            ColourButton btnBackColour = new ColourButton(cat.BackColour);
            btnBackColour.Tag = cat;
            btnBackColour.ColourChanged += new ColourButton.ColourChangedEventHandler(btnBackColour_ColourChanged);
            pnlCategories.Controls.Add(btnBackColour);

            ColourButton btnForeColour = new ColourButton(cat.ForeColour);
            btnForeColour.Tag = cat;
            btnForeColour.ColourChanged += new ColourButton.ColourChangedEventHandler(btnForeColour_ColourChanged);
            pnlCategories.Controls.Add(btnForeColour);

            GroupCombo cboGroup = new GroupCombo(cat.GroupId);
            cboGroup.Tag = cat;
            cboGroup.SelectedIndexChanged += new EventHandler(cboGroup_SelectedIndexChanged);
            pnlCategories.Controls.Add(cboGroup);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Tag = cat;
            btnDelete.Click += new EventHandler(btnDelete_Click);
            pnlCategories.Controls.Add(btnDelete);
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupCombo cbo = (GroupCombo)sender;
            POSCategory cat = (POSCategory)cbo.Tag;
            cat.GroupId = cbo.GetGroupId();
            cat.Updated = true;
        }

        private void btnForeColour_ColourChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string strColour = Convert.ToString(btn.BackColor.A) + "," +
                Convert.ToString(btn.BackColor.R) + "," +
                Convert.ToString(btn.BackColor.G) + "," +
                Convert.ToString(btn.BackColor.B);
            POSCategory cat = (POSCategory)btn.Tag;
            cat.ForeColour = strColour;
            cat.Updated = true;
        }

        private void btnBackColour_ColourChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string strColour = Convert.ToString(btn.BackColor.A) + "," +
                Convert.ToString(btn.BackColor.R) + "," +
                Convert.ToString(btn.BackColor.G) + "," +
                Convert.ToString(btn.BackColor.B);
            POSCategory cat = (POSCategory)btn.Tag;
            cat.BackColour = strColour;
            cat.Updated = true;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSCategory cat = (POSCategory)btn.Tag;
            if (cat.CategoryId > 0)
            {
                DataHelper.DeleteCategory(cat.CategoryId);
            }
            categories.Remove(cat);
            pnlCategories.Controls.Clear();
            BuildTable();
        }

        void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSCategory cat = (POSCategory)txt.Tag;
            cat.CategoryName = txt.Text;
        }
        
        //Add a new category
        private void btnAdd_Click(object sender, EventArgs e)
        {
            POSCategory cat = new POSCategory(newCatId, section.SectionId, "",
                POSCategory.defaultBackColour, POSCategory.defaultForeColour);
            categories.Add(cat);
            BuildRow(cat);
            newCatId--;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<POSCategory> updated = new List<POSCategory>();
            foreach (POSCategory cat in categories)
            {
                if (cat.CategoryId < 0) //not in database
                {
                    updated.Add(cat);
                }
                else if (cat.Updated)
                {
                    updated.Add(cat);
                }
            }
            DataHelper.SaveCategories(updated);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
