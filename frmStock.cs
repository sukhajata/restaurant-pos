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
    public partial class frmStock : Form
    {
        private SupplierCombo _cboSupplier;
        private SectionCombo _cboSection;
        private CategoryCombo _cboCategory;
        private BindingList<POSItemStock> _stock;

        public frmStock()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _cboSupplier = new SupplierCombo();
            //_cboSupplier.SelectedIndexChanged += new EventHandler(_cboSupplier_SelectedIndexChanged);
            _cboSupplier.Leave += new EventHandler(_cboSupplier_Leave);
            _cboSupplier.SelectionChangeCommitted += new EventHandler(_cboSupplier_SelectionChangeCommitted);
            pnlFilter.Controls.Add(_cboSupplier, 1, 0);

            pnlFilter.Controls.Add(CreateLabel("Section:"));
            _cboSection = new SectionCombo(true);
            _cboSection.SelectedIndexChanged += new EventHandler(_cboSection_SelectedIndexChanged);
            pnlFilter.Controls.Add(_cboSection, 3, 0);

            pnlFilter.Controls.Add(CreateLabel("Category:"));
            _cboCategory = new CategoryCombo(true);
            _cboCategory.SelectedIndexChanged += new EventHandler(_cboCategory_SelectedIndexChanged);
            pnlFilter.Controls.Add(_cboCategory, 5, 0);

            dgStock.CellValidating += new DataGridViewCellValidatingEventHandler(dgStock_CellValidating);
            dgStock.CellEndEdit += new DataGridViewCellEventHandler(dgStock_CellEndEdit);

        }

        void _cboSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        void dgStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgStock.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        void dgStock_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
               dgStock.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Equals("StockLevel"))
            {
                try
                {
                    Convert.ToInt32(e.FormattedValue.ToString());
                }
                catch (Exception)
                {
                    dgStock.Rows[e.RowIndex].ErrorText = "Please enter an integer.";
                    e.Cancel = true;
                }
            }
            
        }

        void _cboSupplier_Leave(object sender, EventArgs e)
        {
            Filter();


            _cboSection.SelectedIndex = 0;
            
        }

        
        void _cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        void _cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            int suid = _cboSupplier.GetSupplierId();
            int sid = _cboSection.GetSectionId();
            int cid = _cboCategory.GetCategoryId();
            _stock = DataHelper.FilterStock(suid, sid, cid);
            dgStock.DataSource = null;
            dgStock.DataSource = _stock;
        }

        void _cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();

            pnlFilter.Controls.Remove(_cboCategory);
            int sid = _cboSection.GetSectionId();
            _cboCategory = new CategoryCombo(sid, 0, true);
            pnlFilter.Controls.Add(_cboCategory, 5, 0);
        }

        private static Label CreateLabel(string text)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.TextAlign = ContentAlignment.MiddleRight;
            lbl.Margin = new Padding(20, 0, 0, 0);
            return lbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (POSItemStock item in _stock)
            {
                DataHelper.SaveItemStock(item.ItemId, item.StockLevel, item.PLU, item.SupplierPLU);
            }
        }


    }
}
