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
    public partial class frmMainEdit : Form
    {
        public POSSection CurrentSection;
        public TabPage SelectedTab;
        private List<POSCategory> _categories;
        private frmEditProductPanel _editProductPanel;
        private frmEditInstructionPanel _editInstructionPanel;
        private const int _PANELWIDTH = 680;
        private const int _PANELHEIGHT = 680;

        public frmMainEdit(POSSection selectedSection)
        {
            InitializeComponent();
            pnlCategories.Controls.Clear();
            string[] headers = new string[] { "Category", "Back", "Fore", " " };
            foreach (string header in headers)
            {
                Label lbl = new Label();
                lbl.Text = header;
                pnlCategories.Controls.Add(lbl);
            }
            Setup();
            foreach (TabPage tp in tbSection.TabPages)
            {
                POSSection section = tp.Tag as POSSection;
                if (section.SectionId == selectedSection.SectionId)
                {
                    tbSection.SelectedTab = tp;
                }
            }
        }

        public void MoveButton(Button btn, int addX, int addY)
        {
            Point loc = btn.Location;
            int x = loc.X + addX;
            if (x > (_PANELWIDTH - Global.GridSpacing))
            {
                x = _PANELWIDTH - Global.GridSpacing;
            }
            else if (x < 0)
            {
                x = 0;
            }
            int y = loc.Y + addY;
            if (y > (_PANELHEIGHT - Global.GridSpacing))
            {
                y = _PANELHEIGHT - Global.GridSpacing;
            }
            else if (y < 0)
            {
                y = 0;
            }
            btn.Location = new Point(x, y);
            try
            {
                POSProduct prod = (POSProduct)btn.Tag;
                DataHelper.SaveProductLocation(prod.ProductId, btn.Location);
            }
            catch (Exception)
            {
                POSInstruction instruction = (POSInstruction)btn.Tag;
                instruction.X = x;
                instruction.Y = y;
                DataHelper.SaveInstruction(instruction);
            }

        }

        public void Setup()
        {
            tbSection.Controls.Clear();
            BuildProductButtons();
            try
            {
                CurrentSection = tbSection.SelectedTab.Tag as POSSection;
                BuildSectionEditPanel(CurrentSection);
                _categories = DataHelper.GetCategories(CurrentSection.SectionId);
                BuildCategoryTable();
                SelectedTab = tbSection.SelectedTab;
            }
            catch(Exception){}
        }

        private void BuildProductButtons()
        {
            //get sections
            List<POSSection> sections = DataHelper.GetSectionsVisible();
            //create a tab page for each section
            foreach (POSSection section in sections)
            {
                TabPage tp = new TabPage(section.SectionName);
                tp.Font = new Font("Arial", 8);
                tp.Tag = section;
                BuildSection(section, tp);
                //Add tab page to the tab panel
                tbSection.Controls.Add(tp);
            }
            tbSection.SelectedIndexChanged += new EventHandler(tbSection_SelectedIndexChanged);

        }

        void tbSection_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tbSection.SelectedTab != null)
            {
                CurrentSection = tbSection.SelectedTab.Tag as POSSection;
                if (_editProductPanel != null && _editProductPanel.Visible)
                {
                    _editProductPanel.Close();
                }
                if (_editInstructionPanel != null && _editInstructionPanel.Visible)
                {
                    _editInstructionPanel.Dispose();
                }
                _categories = DataHelper.GetCategories(CurrentSection.SectionId);
                BuildSectionEditPanel(CurrentSection);
                BuildCategoryTable();
            }
        }

        public void BuildSection(POSSection section, TabPage tp)
        {
            tp.Controls.Clear();
            //get a list of categories for this section
            List<POSCategory> cats = DataHelper.GetCategories(section.SectionId);
            //use a panel to lay out the buttons
            Panel pnlButtons = new Panel();
            pnlButtons.Width = _PANELWIDTH;
            pnlButtons.Height = _PANELHEIGHT;
            pnlButtons.Tag = section.SectionId;

            //get the products for each category and create buttons for them
            foreach (POSCategory cat in cats)
            {
                List<POSProduct> prods = DataHelper.GetProducts(cat.CategoryId);
                foreach (POSProduct prod in prods)
                {
                    BuildProductButton(pnlButtons, prod, cat.BackColour, cat.ForeColour);
                }
            }

            //add instructions for this section
            List<POSInstruction> sectionInstructions =
                DataHelper.GetSectionInstructions(section.SectionId);
            foreach (POSInstruction si in sectionInstructions)
            {
                Button btn = new Button();
                btn.Text = si.Instruction;
                btn.BackColor = Color.White;
                //store info in the button
                btn.Tag = si;
                btn.Click += new EventHandler(this.btnInstruction_Click);
                btn.Size = new Size(85, 85);
                pnlButtons.Controls.Add(btn);
                btn.Location = new Point(si.X, si.Y);
            }

            // Add Panel to the tab page
            tp.Controls.Add(pnlButtons);

        }

        private void BuildProductButton(Panel pnl, POSProduct prod, string backcolour,
           string forecolour)
        {
            Button btn = new Button();
            btn.Text = prod.ButtonText;
            try
            {
                string[] argb_back = backcolour.Split(',');
                btn.BackColor = Color.FromArgb(Convert.ToInt16(argb_back[0]),
                    Convert.ToInt16(argb_back[1]), Convert.ToInt16(argb_back[2]),
                    Convert.ToInt16(argb_back[3]));
            }
            catch
            {
                string[] argb_back = POSCategory.defaultBackColour.Split(',');
                btn.BackColor = Color.FromArgb(Convert.ToInt16(argb_back[0]),
                    Convert.ToInt16(argb_back[1]), Convert.ToInt16(argb_back[2]),
                    Convert.ToInt16(argb_back[3]));
            }
            try
            {
                string[] argb_fore = forecolour.Split(',');
                btn.ForeColor = Color.FromArgb(Convert.ToInt16(argb_fore[0]),
                    Convert.ToInt16(argb_fore[1]), Convert.ToInt16(argb_fore[2]),
                    Convert.ToInt16(argb_fore[3]));
            }
            catch
            {
                string[] argb_fore = POSCategory.defaultForeColour.Split(',');
                btn.ForeColor = Color.FromArgb(Convert.ToInt16(argb_fore[0]),
                    Convert.ToInt16(argb_fore[1]), Convert.ToInt16(argb_fore[2]),
                    Convert.ToInt16(argb_fore[3]));
            }
            //store product info in the button
            btn.Tag = prod;
            btn.Click += new EventHandler(this.btnProduct_Click);
            btn.Size = new Size(85, 85);
            pnl.Controls.Add(btn);
            btn.Location = new Point(prod.X, prod.Y);
            

        }

        void btnProduct_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_editProductPanel != null && _editProductPanel.Visible)
            {
                _editProductPanel.Close();
            }
            if (_editInstructionPanel != null && _editInstructionPanel.Visible)
            {
                _editInstructionPanel.Dispose();
            }
            _editProductPanel = new frmEditProductPanel(btn, this);
            _editProductPanel.Show();
            
        }

        void btnInstruction_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_editProductPanel != null && _editProductPanel.Visible)
            {
                _editProductPanel.Close();
            }
            if (_editInstructionPanel != null && _editInstructionPanel.Visible)
            {
                _editInstructionPanel.Dispose();
            }
            _editInstructionPanel = new frmEditInstructionPanel(btn,
                this);
            _editInstructionPanel.Show();
        }

        private void BuildSectionEditPanel(POSSection section)
        {
            txtSectionName.Text = section.SectionName;
            chkSectionVisible.Checked = section.Visible;
            txtSectionOrder.Text = section.SortOrder.ToString();
        }

        private void BuildCategoryTable()
        {
            pnlCategoriesContent.Controls.Clear();
            foreach (POSCategory cat in _categories)
            {
                BuildCategoryRow(cat);
            }
        }

        private void BuildCategoryRow(POSCategory cat)
        {
            TextBox txtName = new TextBox();
            txtName.Width = 180;
            txtName.Text = cat.CategoryName;
            txtName.MaxLength = 50;
            txtName.Tag = cat;
            pnlCategoriesContent.Controls.Add(txtName);
            txtName.TextChanged += new EventHandler(txtCategoryName_TextChanged);

            ColourButton btnBackColour = new ColourButton(cat.BackColour);
            btnBackColour.Tag = cat;
            btnBackColour.ColourChanged += new ColourButton.ColourChangedEventHandler(btnCategoryBackColour_ColourChanged);
            pnlCategoriesContent.Controls.Add(btnBackColour);

            ColourButton btnForeColour = new ColourButton(cat.ForeColour);
            btnForeColour.Tag = cat;
            btnForeColour.ColourChanged += new ColourButton.ColourChangedEventHandler(btnCategoryForeColour_ColourChanged);
            pnlCategoriesContent.Controls.Add(btnForeColour);

            Button btnDelete = new Button();
            btnDelete.Text = "X";
            btnDelete.Font = new Font("Candara", 12);
            btnDelete.ForeColor = Color.Red;
            btnDelete.Height = 27;
            btnDelete.Tag = cat;
            btnDelete.Click += new EventHandler(btnDeleteCategory_Click);
            pnlCategoriesContent.Controls.Add(btnDelete);
        }

        void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            POSCategory cat = (POSCategory)txt.Tag;
            cat.CategoryName = txt.Text;
            cat.Updated = true;
        }

        void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSCategory cat = (POSCategory)btn.Tag;
            DialogResult result = MessageBox.Show(cat.CategoryName +
                " and all of its contents will be removed", "Confirm",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (cat.CategoryId > 0)
                {
                    DataHelper.DeleteCategory(cat.CategoryId);
                }
                _categories.Remove(cat);
                pnlCategoriesContent.Controls.Clear();
                BuildCategoryTable();
            }
        }

        void btnCategoryBackColour_ColourChanged(object sender, EventArgs e)
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

        void btnCategoryForeColour_ColourChanged(object sender, EventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This section and all of its contents will be deleted",
                "Confirm", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                POSSection currentSection = tbSection.SelectedTab.Tag as POSSection;
                DataHelper.DeleteSection(currentSection.SectionId);
                tbSection.SelectedTab.Controls.Clear();
                tbSection.SelectedTab.Dispose();
            }
            
        }

        private void btnSaveSection_Click(object sender, EventArgs e)
        {
            if (txtSectionName.Text.Length == 0)
            {
                MessageBox.Show("Please enter a section name");
                return;
            }
            POSSection currentSection = tbSection.SelectedTab.Tag as POSSection;
            currentSection.SectionName = txtSectionName.Text;
            try
            {
                currentSection.SortOrder = Convert.ToInt32(txtSectionOrder.Text);
            }
            catch (Exception)
            {
                currentSection.SortOrder = 100;
            }
            currentSection.Visible = chkSectionVisible.Checked;
            DataHelper.SaveSection(currentSection);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            POSCategory cat = new POSCategory(-1, CurrentSection.SectionId,
                string.Empty, POSCategory.defaultBackColour, POSCategory.defaultForeColour);
            _categories.Add(cat);
            BuildCategoryTable();
        }

        private void btnSaveCategories_Click(object sender, EventArgs e)
        {
            List<POSCategory> updatedCategories = new List<POSCategory>();
            foreach (POSCategory cat in _categories)
            {
                if (cat.Updated)
                {
                    updatedCategories.Add(cat);
                }
            }
            DataHelper.SaveCategories(updatedCategories);
            BuildCategoryTable();
            BuildSection(CurrentSection, tbSection.SelectedTab);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (_editProductPanel != null && _editProductPanel.Visible)
            {
                _editProductPanel.Close();
            }
            if (_editInstructionPanel != null && _editInstructionPanel.Visible)
            {
                _editInstructionPanel.Dispose();
            }
            this.Close();
        }

        private void btnAutoLayout_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonArranger arranger = new ButtonArranger(CurrentSection.SectionId);
                if (!arranger.Arrange())
                {
                    MessageBox.Show("Too many items for this section. Please remove some or create another section.");
                }
                BuildSection(CurrentSection, tbSection.SelectedTab);
            }
            catch (Exception)
            {
                List<POSInstruction> instructions = (List<POSInstruction>)tbSection.SelectedTab.Tag;
                if (instructions != null)
                {
                    tbSection.SelectedTab.Controls.Clear();
                    //BuildInstructionButtons(tbSection.SelectedTab);
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            POSProduct newProd;
            if (_categories.Count == 0)
            {
                newProd = new POSProduct();
            }
            else
            {
                newProd = new POSProduct(-1, string.Empty, string.Empty,
                    string.Empty, _categories[0].CategoryId, _categories[0].CategoryName,
                    CurrentSection.SectionId, CurrentSection.SectionName, string.Empty,
                    true, 0, string.Empty, 0, 0);
            }
            frmEditProduct frm = new frmEditProduct(newProd);
            frm.ShowDialog();
            BuildSection(CurrentSection, tbSection.SelectedTab);
        }

        private void btnAddInstruction_Click(object sender, EventArgs e)
        {
            Point location = ButtonArranger.FindNextAvailableSpace(CurrentSection.SectionId);
            POSInstruction instruction = new POSInstruction(-1, string.Empty,
                CurrentSection.SectionId, location.X, location.Y);
            frmInstruction frm = new frmInstruction(instruction);
            frm.ShowDialog();
            BuildSection(CurrentSection, tbSection.SelectedTab);
        }




    }
}
