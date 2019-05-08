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
    public partial class frmProducts : Form
    {
        private TextBox txtName;
        private SectionCombo cboSection;
        private CategoryCombo cboCategory;
        private SupplierCombo cboSupplier;
        private frmMain parent;
        public enum Mode { Edit, Select }
        private Mode currentMode;
        private BindingList<POSProductView> _products;

        public frmProducts(frmMain p, Mode m)
        {
            InitializeComponent();
            parent = p;
            currentMode = m;
            BuildFilter();
            RunPrivileges();
        }

        private void RunPrivileges()
        {
            Dictionary<int, POSUserPrivilege> userPrivileges =
                DataHelper.GetUserPrivileges(Global.CurrentUser.Uid);
            if (userPrivileges[POSPrivilege.EDIT_PRODUCTS].Allowed == false)
            {
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnNew.Visible = false;
            }
        }

        public void Rebuild()
        {
            RefreshProductTable();
            //refresh parent form
            parent.Rebuild();
        }

        private void BuildFilter()
        {
            txtName = new TextBox();
            txtName.Dock = DockStyle.Fill;
            txtName.Font = new Font("Candara", 12);
            txtName.MaxLength = 50;
            txtName.TextChanged += new EventHandler(txtName_TextChanged);
            pnlFilter.Controls.Add(txtName, 1, 0);

            cboSupplier = new SupplierCombo();
            cboSupplier.SelectedIndexChanged += new EventHandler(cboSupplier_SelectedIndexChanged);
            cboSupplier.TextChanged += new EventHandler(cboSupplier_TextChanged);
            pnlFilter.Controls.Add(cboSupplier, 1, 1);

            cboSection = new SectionCombo(true);
            cboSection.SelectedIndexChanged += new EventHandler(cboSection_SelectedIndexChanged);
            pnlFilter.Controls.Add(cboSection, 1, 2);

            cboCategory = new CategoryCombo(true);
            cboCategory.SelectedIndexChanged += new EventHandler(cboCategory_SelectedIndexChanged);
            pnlFilter.Controls.Add(cboCategory, 1, 3);

        }

        void cboSupplier_TextChanged(object sender, EventArgs e)
        {
            RefreshProductTable();
        }

        void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProductTable();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            RefreshProductTable();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProductTable();
        }

        private void RefreshProductTable()
        {
            string name = txtName.Text;
            int supplierId = cboSupplier.GetSupplierId();
            int sectionId = cboSection.GetSectionId();
            int categoryId = cboCategory.GetCategoryId();
            _products = DataHelper.FilterProducts(name, supplierId, sectionId, 
                categoryId);
            dgProducts.DataSource = null;
            BuildProductTable();
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFilter.Controls.Remove(cboCategory);
            cboCategory = new CategoryCombo(cboSection.GetSectionId(), 0, true);
            cboCategory.Height = 50;
            cboCategory.Font = new Font("Candara", 12);
            cboCategory.SelectedIndexChanged += new EventHandler(cboCategory_SelectedIndexChanged);
            pnlFilter.Controls.Add(cboCategory, 1, 3);
            RefreshProductTable();
        }

        private void BuildProductTable()
        {
            dgProducts.DataSource = _products;
          
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgProducts.SelectedRows.Count > 0)
            {
                POSProductView prodView = dgProducts.SelectedRows[0].DataBoundItem as POSProductView;
                Global.ProductChanged = false;
                frmEditProduct frm = new frmEditProduct(prodView.ConvertToPOSProduct());
                frm.ShowDialog();
                if (Global.ProductChanged)
                {
                    RefreshProductTable();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Global.ProductChanged = false;
            frmEditProduct frm = new frmEditProduct(new POSProduct());
            frm.ShowDialog();
            if (Global.ProductChanged)
            {
                RefreshProductTable();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            POSProduct prod = dgProducts.SelectedRows[0].DataBoundItem as POSProduct;
            if (MessageBox.Show(prod.Product + " will be deleted.", "Confirm", MessageBoxButtons.OKCancel) 
                == DialogResult.OK)
            {
                DataHelper.DeleteProduct(prod.ProductId);
                Global.ProductChanged = true;
                Global.SectionId = prod.SectionId;
                RefreshProductTable();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (currentMode == Mode.Select)
            {
                if (dgProducts.SelectedRows.Count > 0)
                {
                    POSProductView prodView = dgProducts.SelectedRows[0].DataBoundItem as POSProductView;
                    parent.retval = prodView.ConvertToPOSProduct();
                    this.Close();
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (POSProduct prod in _products)
            {
                DataHelper.SaveProductVisible(prod);
            }
            int sid = cboSection.GetSectionId();
            if (sid > 0)
            {
                Global.ProductChanged = true;
                Global.SectionId = cboSection.GetSectionId();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            List<POSProduct> toEdit = new List<POSProduct>();
            foreach (POSProductView prod in _products)
            {
                if (prod.Selected)
                {
                    toEdit.Add(prod.ConvertToPOSProduct());
                }
            }

            if (toEdit.Count == 1)
            {
                frmEditProduct frm = new frmEditProduct(toEdit[0]);
                frm.ShowDialog();
            }
            else if (toEdit.Count > 1)
            {
                frmEditProduct frm = new frmEditProduct(toEdit);
                frm.ShowDialog();
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (POSProductView prodView in _products)
            {
                prodView.Selected = false;
            }
            dgProducts.DataSource = null;
            dgProducts.DataSource = _products;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (POSProduct prod in _products)
            {
                prod.Selected = true;
            }
            dgProducts.DataSource = null;
            dgProducts.DataSource = _products;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Selected products will be deleted",
                "Confirm", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (POSProductView prodView in _products)
                {
                    if (prodView.Selected)
                    {
                        DataHelper.DeleteProduct(prodView.ProductId);
                    }
                }
                Rebuild();
            }
        }

       

       

    }
}
