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
    public partial class frmSections : Form
    {
        private List<POSSection> sections;
        private frmMain parent;

        public frmSections(frmMain p)
        {
            InitializeComponent();
            parent = p;
            sections = DataHelper.GetSections();
            BuildTable();
        }

        private void BuildTable()
        {
            foreach (POSSection section in sections)
            {
                BuildSectionRow(section);
            }
        }

        private void BuildSectionRow(POSSection section)
        {
            TextBox txtName = new TextBox();
            txtName.Width = 180;
            txtName.MaxLength = 50;
            txtName.Text = section.SectionName;
            txtName.Tag = section;
            txtName.TextChanged += new EventHandler(txtName_TextChanged);
            pnlSections.Controls.Add(txtName);

            TextBox txtDesciption = new TextBox();
            txtDesciption.Multiline = true;
            txtDesciption.Height = 60;
            txtDesciption.MaxLength = 100;
            txtDesciption.ScrollBars = ScrollBars.Vertical;
            txtDesciption.Width = 240;
            txtDesciption.Text = section.Description;
            txtDesciption.Tag = section;
            txtDesciption.TextChanged += new EventHandler(txtDesciption_TextChanged);
            pnlSections.Controls.Add(txtDesciption);

            CheckBox chkVisible = new CheckBox();
            chkVisible.Checked = section.Visible;
            chkVisible.Tag = section;
            chkVisible.Padding = new Padding(15, 0, 0, 0);
            chkVisible.CheckedChanged += new EventHandler(chkVisible_CheckedChanged);
            pnlSections.Controls.Add(chkVisible);

            TextBox txtSortOrder = new TextBox();
            txtSortOrder.Text = section.SortOrder.ToString();
            txtSortOrder.Width = 50;
            txtSortOrder.Dock = DockStyle.Fill;
            txtSortOrder.TextAlign = HorizontalAlignment.Right;
            txtSortOrder.Tag = section;
            txtSortOrder.TextChanged += new EventHandler(txtSortOrder_TextChanged);
            pnlSections.Controls.Add(txtSortOrder);

            Button btnCategories = new Button();
            btnCategories.Text = "Categories";
            btnCategories.Tag = section;
            btnCategories.BackColor = Color.YellowGreen;
            btnCategories.Dock = DockStyle.Fill;
            btnCategories.Click += new EventHandler(btnCategories_Click);
            pnlSections.Controls.Add(btnCategories);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Tag = section;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.BackColor = Color.SandyBrown;
            btnDelete.Click += new EventHandler(btnDelete_Click);
            pnlSections.Controls.Add(btnDelete);


            
        }

        void txtSortOrder_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSSection section = (POSSection)txt.Tag;
            if (!txt.Text.Equals(string.Empty))
            {
                try
                {
                    section.SortOrder = Convert.ToInt32(txt.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a valid number for sort order.");
                    txt.Focus();
                }
            }
            else
            {
                section.SortOrder = 100;
            }
        }

        void btnCategories_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSSection section = (POSSection)btn.Tag;
            frmCategories frmCat = new frmCategories(section);
            frmCat.ShowDialog();
        }

        void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSSection section = (POSSection)txt.Tag;
            section.SectionName = txt.Text;
        }

        void chkVisible_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            POSSection section = (POSSection)chk.Tag;
            section.Visible = chk.Checked;
        }

        void txtDesciption_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSSection section = (POSSection)txt.Tag;
            section.Description = txt.Text;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSSection section = (POSSection)btn.Tag;
            if (section.SectionId != -1)
            {
                DialogResult result = MessageBox.Show("Section will be permanently removed", "Confirm",
                    MessageBoxButtons.OKCancel);
                if (result.Equals(DialogResult.OK))
                {
                    DataHelper.DeleteSection(section.SectionId);
                    sections.Remove(section);
                    pnlSections.Controls.Clear();
                    BuildTable();
                }
            }
            else //not yet in the database
            {
                sections.Remove(section);
                pnlSections.Controls.Clear();
                BuildTable();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            POSSection newSection = new POSSection(-1, "", "", true, 100);
            sections.Add(newSection);
            BuildSectionRow(newSection);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataHelper.SaveSections(sections);
            parent.Rebuild();
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
