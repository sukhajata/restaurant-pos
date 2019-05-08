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
    public partial class frmAddPriceLevelException : Form
    {
        private BindingList<POSSupplier> _suppliers;
        private BindingList<POSSection> _sections;
        private BindingList<POSCategory> _categories;
        private POSPriceLevel _priceLevel;

        public frmAddPriceLevelException(POSPriceLevel priceLevel)
        {
            InitializeComponent();
            _priceLevel = priceLevel;
            Reset();
            lblName.Text = lblName.Text + _priceLevel.PriceLevelName;
            cboSection.SelectedIndexChanged += new EventHandler(cboSection_SelectedIndexChanged);
        }

        void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlCategory.Controls.Remove(cboCategory);
            int sid = cboSection.GetSectionId();
            cboCategory = new Bliss_POS.CustomControls.CategoryCombo(sid,
                DataHelper.GetFirstCategory(sid), false);
            pnlCategory.Controls.Add(cboCategory, 0, 0);
        }

        private void Reset()
        {
            _suppliers = new BindingList<POSSupplier>();
            lstSuppliers.DataSource = _suppliers;
            _sections = new BindingList<POSSection>();
            lstSections.DataSource = _sections;
            _categories = new BindingList<POSCategory>();
            lstCategories.DataSource = _categories;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            POSSupplier supplier = cboSupplier.GetSupplier();
            if (supplier != null)
            {
                _suppliers.Add(supplier);
                lstSuppliers.DataSource = _suppliers;
            }
        }

        private void btnRemoveSupplier_Click(object sender, EventArgs e)
        {
            if (lstSuppliers.SelectedIndex >= 0)
            {
                POSSupplier supplier = lstSuppliers.SelectedItem as POSSupplier;
                _suppliers.Remove(supplier);
            }
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            POSSection section = cboSection.GetSection();
            if (section != null)
            {
                _sections.Add(section);
                lstSections.DataSource = _sections;
            }
        }

        private void btnRemoveSection_Click(object sender, EventArgs e)
        {
            if (lstSections.SelectedIndex >= 0)
            {
                POSSection section = lstSections.SelectedItem as POSSection;
                _sections.Remove(section);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            POSCategory cat = cboCategory.GetCategory();
            if (cat != null)
            {
                _categories.Add(cat);
                lstCategories.DataSource = _categories;
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex >= 0)
            {
                POSCategory cat = lstCategories.SelectedItem as POSCategory;
                _categories.Remove(cat);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            double rate = 0;
            try
            {
                rate = Convert.ToDouble(txtRate.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid rate for this exception.");
                txtRate.Focus();
                return;
            }
            if (_suppliers.Count > 0)
            {
                foreach (POSSupplier supplier in _suppliers)
                {
                    if (_sections.Count > 0)
                    {
                        foreach (POSSection section in _sections)
                        {
                            if (_categories.Count > 0)
                            {
                                foreach (POSCategory cat in _categories)
                                {
                                    //suppliers, sections and categories
                                    DataHelper.InsertPriceLevelException(_priceLevel.PriceLevelId, supplier.Suid,
                                        section.SectionId, cat.CategoryId, rate);

                                }
                            }
                            else //suppliers, sections but no categories
                            {
                                DataHelper.InsertPriceLevelException(_priceLevel.PriceLevelId, supplier.Suid,
                                    section.SectionId, 0, rate);
                            }
                        }
                    }
                    else //suppliers but no sections
                    {
                        DataHelper.InsertPriceLevelException(_priceLevel.PriceLevelId, supplier.Suid,
                            0, 0, rate);
                    }
                }
            }
            else //no suppliers chosen
            {
                if (_sections.Count > 0)
                {
                    foreach (POSSection section in _sections)
                    {
                        if (_categories.Count > 0) //no suppliers, sections, categories
                        {
                            foreach (POSCategory category in _categories)
                            {
                                DataHelper.InsertPriceLevelException(_priceLevel.PriceLevelId, 0,
                                    section.SectionId, category.CategoryId, rate);
                            }
                        }
                        else //no suppliers, sections, no categories
                        {
                            DataHelper.InsertPriceLevelException(_priceLevel.PriceLevelId, 0, section.SectionId,
                                0, rate);
                        }
                    }
                }
                else //no suppliers, no sections
                {
                    MessageBox.Show("Please select a supplier or section for this exception. To apply a price level for all products create a new price level.");
                }
            }
            

            Reset();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
