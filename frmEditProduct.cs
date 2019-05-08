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
    public partial class frmEditProduct : Form
    {
        private SectionCombo cboSec;
        private CategoryCombo cboCat;
        private SupplierCombo cboSupplier;
        public enum ParentType { frmMain, frmProducts }
        private POSProduct _product;
        private List<POSProduct> _products;
        private BindingList<POSItemEdit> _items;
        private BindingList<POSInstruction> _instructions;
        private BindingList<POSPrinter> _printers;

        public frmEditProduct(POSProduct prod)
        {
            InitializeComponent();
            _product = prod;
            BuildCustomControls();
            FillFields();
            BuildItems();
            GetProductInstructions();
            GetPrinters();
            btnExit.Visible = false;
        }

        public frmEditProduct(List<POSProduct> prods)
        {
            InitializeComponent();
            _products = prods;
            _printers = DataHelper.GetCommonProductPrinters(_products);
            lstPrinters.DataSource = _printers;

            txtName.Enabled = false;
            txtButtonText.Enabled = false;
            txtDescription.Enabled = false;
            txtCode.Enabled = false;
            btnAddItem.Enabled = false;
            btnDelete.Enabled = false;
            btnDeleteInstruction.Enabled = false;
            btnPriceLevels.Enabled = false;
            btnAddSupplier.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        private void GetProductInstructions()
        {
            _instructions = DataHelper.GetProductInstructions(_product.ProductId);
            dgProductInstructions.DataSource = _instructions;
        }

        public void AddPrinter(POSPrinter p)
        {
            _printers.Add(p);
            lstPrinters.DataSource = null;
            lstPrinters.DataSource = _printers;
            
            if (_products != null)
            {
                foreach (POSProduct prod in _products)
                {
                    DataHelper.InsertProductPrinter(prod.ProductId, p.PrinterId);
                }
            }
            else
            {
                DataHelper.InsertProductPrinter(_product.ProductId, p.PrinterId);
            }
        }
       
        private void BuildCustomControls()
        {
            cboSec = new SectionCombo(_product.SectionId);
            cboSec.TabIndex = 5;
            cboSec.SelectedIndexChanged += new EventHandler(cboSec_SelectedIndexChanged);
            pnlDetails.Controls.Add(cboSec, 1, 3);

            cboCat = new CategoryCombo(_product.SectionId, _product.CategoryId);
            cboCat.SelectedIndexChanged += new EventHandler(cboCat_SelectedIndexChanged);
            cboCat.TabIndex = 6;
            pnlDetails.Controls.Add(cboCat, 1, 4);

            cboSupplier = new SupplierCombo(_product.SupplierId);
            cboSupplier.TabIndex = 18;
            pnlDetails.Controls.Add(cboSupplier, 1, 8);

        }

        private void BuildItems()
        {
            if (_product.ProductId == -1)
            {
                _items = new BindingList<POSItemEdit>();
            }
            else
            {
                _items = DataHelper.GetItemsEditByProduct(_product.ProductId);
            }
            dgItems.DataSource = _items;
        }

        private void cboCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catid = cboCat.GetCategoryId();
            int y = DataHelper.GetNextLocationRow(catid);
            _product.X = 0;
            _product.Y = y;
        }

        private void GetPrinters()
        {
            _printers = DataHelper.GetPrinters(_product.ProductId);
            lstPrinters.DataSource = _printers;
        }

        //When the section combo box changes we need to replace the categories
        //in the category combo box
        void cboSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sid = cboSec.GetSectionId();
            pnlDetails.Controls.Remove(cboCat);
            cboCat = new CategoryCombo(sid, DataHelper.GetFirstCategory(sid));
            pnlDetails.Controls.Add(cboCat, 1, 4);

        }

        private void FillFields()
        {
            txtName.Text = _product.Product;
            txtButtonText.Text = _product.ButtonText;
            txtDescription.Text = _product.Description;
            txtCode.Text = _product.Code;
            chkVisible.Checked = _product.Visible;
        }

        private bool ValidateForm()
        {
            if (txtName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please enter a name.");
                return false;
            }
       
            
            return true;
        }

        private bool ValidateDouble(string value)
        {
            try
            {
                Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool ValidateInt(string value)
        {
            try
            {
                Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {

            //find space to display new product
            if (_product.ProductId < 0)
            {
                Point location = ButtonArranger.FindNextAvailableSpace(_product.SectionId);
                _product.X = location.X;
                _product.Y = location.Y;
            }
            POSProduct newProd = new POSProduct(_product.ProductId, txtName.Text,
                txtButtonText.Text, txtDescription.Text, cboCat.GetCategoryId(),
                txtCode.Text, chkVisible.Checked,
                DataHelper.GetSuid(cboSupplier.GetSupplierName()), _product.X,
                _product.Y);
            int pid = DataHelper.SaveProduct(newProd);
            
            //if this is a new product update the local variables with pid from database
            if (_product.ProductId != pid)
            {
                _product.ProductId = pid;
                foreach (POSItemEdit item in _items)
                {
                    item.Pid = pid;
                }
                foreach (POSInstruction pi in _instructions)
                {
                    pi.ProductId = pid;
                }
            }
            foreach (POSInstruction i in _instructions)
            {
                DataHelper.SaveInstruction(i);
            }
            foreach (POSItemEdit item in _items)
            {
                DataHelper.SaveItem(_product.ProductId, item);
            }
            Global.ProductChanged = true;
            Global.SectionId = _product.SectionId;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPrinter_Click(object sender, EventArgs e)
        {
            frmPrinters frm = new frmPrinters(this);
            frm.ShowDialog();
        }

        private void btnRemovePrinter_Click(object sender, EventArgs e)
        {
            if (lstPrinters.SelectedIndex >= 0)
            {
                POSPrinter printer = lstPrinters.SelectedItem as POSPrinter;
                if (_products != null)
                {
                    foreach (POSProduct prod in _products)
                    {
                        DataHelper.DeleteProductPrinter(prod.ProductId, printer.PrinterId);
                    }
                }
                else
                {
                    DataHelper.DeleteProductPrinter(_product.ProductId, printer.PrinterId);
                }
                _printers.Remove(printer);
                lstPrinters.DataSource = null;
                lstPrinters.DataSource = _printers;
            }
        }

        //private void txtPrice_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double price = Convert.ToDouble(txtPrice.Text);
        //        txtPriceLevel1.Text = CurrencyFormat(POSPriceLevel.PriceLevel1 / 100.0 * price);
        //        txtPriceLevel2.Text = CurrencyFormat(POSPriceLevel.PriceLevel2 / 100.0 * price);
        //        txtPriceLevel3.Text = CurrencyFormat(POSPriceLevel.PriceLevel3 / 100.0 * price);
        //    }
        //    catch (Exception) { }
        //}

        private string CurrencyFormat(double price)
        {
            return String.Format("{0:c}", price).TrimStart('$');
                
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Save();

                POSItemEdit item = new POSItemEdit(-1, _product.ProductId, _product.Product,
                    "default", 0, 0, string.Empty, 0, 0, string.Empty, string.Empty,
                    0, 0);
                int itemid = DataHelper.SaveItem(_product.ProductId, item);
                item.ItemId = itemid;
                _items.Add(item);
                dgItems.DataSource = null;
                dgItems.DataSource = _items;
            }
                     
        }

        private void btnPriceLevels_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count > 0)
            {
                POSItemEdit item = dgItems.SelectedRows[0].DataBoundItem 
                    as POSItemEdit;
                frmEditPriceLevelsForItem frm =
                    new frmEditPriceLevelsForItem(item);
                frm.ShowDialog();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count > 0)
            {
                POSItemEdit item = dgItems.SelectedRows[0].DataBoundItem as POSItemEdit;
                _items.Remove(item);
                DataHelper.DeleteItem(item.ItemId);
                dgItems.DataSource = null;
                dgItems.DataSource = _items;
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Global.SupplierId = -1;
            frmSupplier frm = new frmSupplier();
            frm.ShowDialog();
            if (Global.SupplierId > 0)
            {
                pnlDetails.Controls.Remove(cboSupplier);
                cboSupplier = new SupplierCombo(Global.SupplierId);
                cboSupplier.TabIndex = 18;
                pnlDetails.Controls.Add(cboSupplier, 1, 8);
            }

        }

        private void btnAddInstruction_Click(object sender, EventArgs e)
        {
            POSInstruction instruction = null;
            if (_products != null)
            {
                foreach (POSProduct prod in _products)
                {
                    instruction = new POSInstruction(
                        -1, string.Empty, prod.ProductId);
                    int id = DataHelper.SaveInstruction(instruction);
                    instruction.InstructionId = id;
                }
            }
            else
            {
                instruction = new POSInstruction(-1, string.Empty, _product.ProductId);
                int id = DataHelper.SaveInstruction(instruction);
                instruction.InstructionId = id;
            }
            _instructions.Add(instruction);
        }

        private void btnDeleteInstruction_Click(object sender, EventArgs e)
        {
            if (dgProductInstructions.SelectedRows.Count > 0)
            {
                POSInstruction pi = dgProductInstructions.SelectedRows[0].DataBoundItem
                    as POSInstruction;
                DataHelper.DeleteInstruction(pi.InstructionId);
                _instructions.Remove(pi);
                dgProductInstructions.DataSource = null;
                dgProductInstructions.DataSource = _instructions;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
