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
using Bliss_POS.Reports;
using System.Threading;


namespace Bliss_POS
{
    public partial class frmMain : Form
    {
        public static POSOrder currentOrder;
        private POSOrder lastOrder;
        public int PriceLevel; //set from external form
        public int PriceLevelScope; //set from external form
        public int Ztid;
        public Point NewLocation;
        private bool orderFinalized;
        private bool trainingMode;
        private Button btnDrag;
        private Point ptOriginal;
        private int GRID_SPACING = Properties.Settings.Default.gridSpacing;
        public object retval; //used to pass values from other forms
        private TabPage selectedTab;
        private Dictionary<int, POSUserPrivilege> userPrivileges;
        private frmSplit frmsplit;
        private POSContext context;
        private int _selectedTabIndex;

        //delegates for notification
        public delegate void TransactionCompleteEventHandler(object sender, EventArgs e);
        public event TransactionCompleteEventHandler TransactionComplete;
        
        
        public frmMain(POSContext con)
        {
            InitializeComponent();
            context = con;
            trainingMode = false;
            Setup();
            _selectedTabIndex = 0;
        }

        protected virtual void OnTransactionComplete(EventArgs e)
        {
            if (TransactionComplete != null)
            {
                TransactionComplete(this, e);
            }
        }

        public void Rebuild()
        {
            selectedTab = tbSection.SelectedTab;
            _selectedTabIndex = tbSection.SelectedIndex;
            tbSection.Controls.Clear();
            Setup();
        }

        public void Rebuild(POSSection section)
        {
            if (section.Visible == true)
            {
                //find the section to rebuild
                foreach (TabPage tp in tbSection.TabPages)
                {
                    POSSection currentSection = (POSSection)tp.Tag;
                    if (currentSection.SectionId == section.SectionId)
                    {
                        tp.Controls.Clear();
                        BuildSection(section, tp);
                        break;
                    }
                }
                
            }
        }

        public POSItemTill GetSelectedOrderItem()
        {
            if (dgOrders.SelectedRows.Count > 0)
            {
                POSItemTill prod = currentOrder.OrderItems[dgOrders.SelectedRows[0].Index];
                return prod;
            }
            return null;
        }

        private void UpdateHold()
        {
            DataHelper.UpdateHold(currentOrder);
            txtTotal.BackColor = Color.SandyBrown;
            orderFinalized = true;
            currentOrder = new POSOrder();
        }

        public void LoadCompletedOrder(int oid)
        {
            currentOrder = new POSOrder(DataHelper.GetOrder(oid, "completed"), oid, "completed");
            UpdateOrder();
            txtTotal.BackColor = Color.SandyBrown;
            lastOrder = currentOrder;
            currentOrder = new POSOrder();

            POSReceiptPrinter printer = new POSReceiptPrinter(lastOrder,
                Global.CurrentUser.Username);
            printer.Print();
        }

        public void LoadOrder(POSOrder order)
        {
            currentOrder = order;
            if (orderFinalized)
            {
                txtTotal.BackColor = Color.White;
                orderFinalized = false;
            }
            UpdateOrder();
        }

        public void AssignTable(POSTable t)
        {
            currentOrder.Table = t;
        }

        public void AssignPrevious(POSTable t)
        {
            this.lastOrder.Table = t;
        }

        public void AddOrderItem(POSItemTill prod)
        {
            if (orderFinalized)
            {
                txtTotal.BackColor = Color.White;
                orderFinalized = false;
            }
            
            currentOrder.OrderItems.Add(prod);
            UpdateOrder();
            
        }

        public void RemoveOrderItem(POSItemTill item)
        {
            currentOrder.OrderItems.Remove(item);
            if (currentOrder.OrderItems.Count == 0)
            {
                orderFinalized = true;
            }
            UpdateOrder();
        }

        public void SetFocus()
        {
            txtBarcode.Focus();
        }

        private void Setup()
        {
            currentOrder = new POSOrder();
            BuildProductButtons();
            //BuildInstructions();
            if (_selectedTabIndex < tbSection.TabCount)
            {
                tbSection.SelectedIndex = _selectedTabIndex;
            }
            orderFinalized = true;
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
                tbSection.Controls.Add(tp);
            }
          
        }

        private void BuildSection(POSSection section, TabPage tp)
        {
            //get a list of categories for this section
            List<POSCategory> cats = DataHelper.GetCategories(section.SectionId);
            //use a panel to lay out the buttons
            Panel pnlButtons = new Panel();
            pnlButtons.Dock = DockStyle.Fill;
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
                tp.Controls.Add(btn);
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

        void tlp_DragOver(object sender, DragEventArgs e)
        {
            btnDrag.Location = new Point(e.X - btnDrag.Width, e.Y - btnDrag.Height);
            btnDrag.BringToFront();
        }

        void tlp_DragDrop(object sender, DragEventArgs e)
        {
            btnDrag.BringToFront();
            Point endPoint = SnapToGrid();
            //if (endPoint == ptOriginal) //treat like click event
            //{
            //    POSProductTill prod = (POSProductTill)btnDrag.Tag;
            //    frmEditProduct frm = new frmEditProduct(prod.ConvertToPOSProductEdit(), this, frmEditProduct.ParentType.frmMain);
            //    frm.ShowDialog();
            //    POSProductEdit p = DataHelper.GetProduct(prod.ProductId);
            //    POSProductTill newProd = p.ConvertToPOSProductTill();
            //    btnDrag.Tag = newProd;
            //    btnDrag.Text = newProd.ButtonText;
                
            //}
        }

        /// <summary>
        /// Snaps the dragged button to a grid point. If this space is already
        /// occupied, the button is restored to its original location.
        /// </summary>
        private Point SnapToGrid()
        {
            Point currentLoc = btnDrag.Location;
            Point snappedLoc = new Point(
                GRID_SPACING * Convert.ToInt32( currentLoc.X/ GRID_SPACING),
                GRID_SPACING * Convert.ToInt32(currentLoc.Y / GRID_SPACING));
            POSProduct prod = (POSProduct)btnDrag.Tag;
            bool ok = DataHelper.SaveProductLocation(prod.ProductId, snappedLoc);
            if (ok)
            {
                btnDrag.Location = snappedLoc;
                prod.X = snappedLoc.X;
                prod.Y = snappedLoc.Y;
                return snappedLoc;
            }
            else
            {
                btnDrag.Location = ptOriginal;
                return ptOriginal;
            }

        }

        void btn_MouseDown(object sender, MouseEventArgs e)
        {
            btnDrag = (Button)sender;
            ptOriginal = btnDrag.Location; 
            DoDragDrop(btnDrag, DragDropEffects.Move);
        }

        void tlp_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        //not used
        private void BuildInstructions()
        {
            TabPage tp = new TabPage("Instructions");
            tp.Font = new Font("Arial", 8);
            tbSection.Controls.Add(tp);

            BuildInstructionButtons(tp);
        }

        //not used
        private void BuildInstructionButtons(TabPage tp)
        {
            //get a list of instructions
            List<POSInstruction> instructions = DataHelper.GetInstructionsGeneral();
            tp.Tag = instructions;
            //use a tablelayout panel to lay out the buttons
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = 9;
            tlp.ColumnCount = 8;
            tlp.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlp.Margin = new Padding(0);

            foreach (POSInstruction instruction in instructions)
            {
                Button btn = new Button();
                btn.Text = instruction.Instruction;
                btn.BackColor = Color.White;
                //store info in the button
                btn.Tag = instruction;
                btn.Click += new EventHandler(this.btnInstruction_Click);
                btn.Size = new Size(80, 70);
                tlp.Controls.Add(btn);
            }

            // Add TableLayoutPanel to the tab page
            tp.Controls.Add(tlp);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            POSProduct prod = (POSProduct)btn.Tag;
            List<POSItemTill> items = DataHelper.GetItemsByProduct(prod.ProductId);
            BindingList<POSInstruction> instructions =
                DataHelper.GetProductInstructions(prod.ProductId);
            if (items.Count > 1 || instructions.Count > 0)
            {
                Global.ParentForm = this;
                Global.CurrentProduct = prod;
                Global.CurrentItem = null;
                frmItems frm = new frmItems(items);
                frm.ShowDialog();
                if (Global.CurrentItem != null)
                {
                    AddOrderItem(Global.CurrentItem);
                }
            }
            else if (items.Count == 1)
            {
                AddOrderItem(items[0]);
            }

            //make the last item ordered the selected row
            if (dgOrders.Rows.Count > 0)
            {
                int idx = dgOrders.Rows.Count - 1;
                DataGridViewRow row = dgOrders.Rows[idx];
                DataGridViewCellCollection cells = row.Cells;
                dgOrders.CurrentCell = cells[0];
            }
            SetFocus();   
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            if (!orderFinalized && dgOrders.SelectedRows.Count > 0)
            {
                Button btn = (Button)sender;
                POSInstruction instruction = (POSInstruction)btn.Tag;
                foreach (DataGridViewRow row in dgOrders.Rows)
                {
                    POSItemTill item = row.DataBoundItem as POSItemTill;
                    item.AddInstruction(instruction);
                }
                
                UpdateOrder();
            }
        }

        public void UpdateOrder()
        {
            dgOrders.DataSource = null;
            dgOrders.AutoGenerateColumns = true;
            dgOrders.DataSource = currentOrder.OrderItems;
            
            UpdateTotal();
            SetFocus();

        }

        private void UpdateTotal()
        {
            double total = currentOrder.Total - currentOrder.AmountPaid;
            txtTotal.Text = String.Format("{0:c}", total);
        }

        private void btnPriceOverride_Click_1(object sender, EventArgs e)
        {
            if (!orderFinalized && dgOrders.SelectedRows.Count > 0)
            {
                Global.UserInput = -1;
                Numeric keypad = new Numeric(false, true);
                keypad.ShowDialog();

                if (Global.UserInput != -1)
                {
                    POSItemTill item = currentOrder.OrderItems[dgOrders.SelectedRows[0].Index];
                    item.SalePrice = Global.UserInput;
                    UpdateOrder();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!orderFinalized && dgOrders.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgOrders.SelectedRows)
                {
                    currentOrder.OrderItems.Remove(row.DataBoundItem as POSItemTill);

                    //currentOrder.OrderItems.RemoveAt(dgOrders.SelectedRows[0].Index);
                }
                if (currentOrder.OrderItems.Count == 0)
                {
                    currentOrder.AmountPaid = 0;
                }
                UpdateOrder();

            }
        }

        private void btnPriceLevel_Click(object sender, EventArgs e)
        {
            if (!orderFinalized && currentOrder.OrderItems.Count > 0)
            {
                //reset priceLevel
                PriceLevel = -1;
                List<POSItemTill> selectedItems = new List<POSItemTill>();
                foreach (DataGridViewRow row in dgOrders.SelectedRows)
                {
                    selectedItems.Add(row.DataBoundItem as POSItemTill);
                }


               
               
                    UpdateOrder();
                
            }

        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            if (!orderFinalized && currentOrder.OrderItems.Count > 0)
            {
                RawPrinterHelper.OpenCashDrawer1(Global.ReceiptPrinterName);
                //get cash received
                Global.UserInput = -1;//reset input
                Numeric frm = new Numeric(true, false);
                frm.ShowDialog();
                if (Global.UserInput != -1)
                {
                    if (Global.UserInput == 0)
                    {
                        CompleteTransaction(POSOrder.PaymentType.Cash);
                    }
                    else if (Global.UserInput < currentOrder.Total - currentOrder.AmountPaid)
                    {
                        currentOrder.AmountPaid += Global.UserInput;
                        double toPay = currentOrder.Total - currentOrder.AmountPaid;
                        txtTotal.Text = String.Format("{0:c}", toPay);
                    }
                    else
                    {
                        double change = Global.UserInput - currentOrder.Total - currentOrder.AmountPaid;
                        currentOrder.AmountPaid += Global.UserInput;
                        txtTotal.Text = String.Format("{0:c}", change);
                        CompleteTransaction(POSOrder.PaymentType.Cash);   
                    }
                }
            }
        }

        private void CompleteTransaction(POSOrder.PaymentType pt)
        {
            currentOrder.paymentType = pt;
            if (context.IsPrePay())//assign table number
            {
                frmTables frmt = new frmTables(frmTables.mode.assign, 
                    currentOrder);
                frmt.ShowDialog();
            }
            POSOrder order = currentOrder;
            FinalizeTransaction();

            NumberPad frm = new NumberPad("Guest Count", 1);
            frm.ShowDialog();

            Global.UserInput = 1;
            if (!trainingMode)
            {
                DataHelper.SaveOrder(Global.CurrentUser.Uid, order, Convert.ToInt32(Global.UserInput),
                    Convert.ToInt32(pt));
            }
            if (frmsplit == null || frmsplit.Visible == false)
            {
                context.Logout();
            }
            
        }

        private void FinalizeTransaction()
        {
            txtTotal.BackColor = Color.SandyBrown;
            orderFinalized = true;
            OnTransactionComplete(EventArgs.Empty);
            lastOrder = currentOrder;
            Thread printThread = new Thread(new ThreadStart(PrintDocket));
            printThread.Start();
            currentOrder = new POSOrder();
           
        }

        private void PrintDocket()
        {
            POSPrintController controller = new POSPrintController(lastOrder);
            if (DataHelper.GetConfigValue("Print to stations") == "true")
            {
                controller.PrintAll();
            }
            else
            {
                controller.PrintOne();
            }
        }

        private void btnEFTPOS_Click(object sender, EventArgs e)
        {
            if (!orderFinalized && currentOrder.OrderItems.Count > 0)
            {
                CompleteTransaction(POSOrder.PaymentType.EFTPOS);
            }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            if (!orderFinalized && currentOrder.OrderItems.Count > 0)
            {
                CompleteTransaction(POSOrder.PaymentType.Credit);
            }
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction.");
            }
            else
            {
                frmSections frm = new frmSections(this);
                frm.ShowDialog();
            }
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction.");
            }
            else
            {
                Global.ProductChanged = false;
                frmProducts frm = new frmProducts(this, frmProducts.Mode.Edit);
                frm.ShowDialog();
                if (Global.ProductChanged)
                {
                    Rebuild(DataHelper.GetSection(Global.SectionId));
                }
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction.");
            }
            else
            {
                frmUsers frm = new frmUsers();
                frm.ShowDialog();
            }
        }

        private void priceLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction.");
                
            }
            else
            {
                frmEditPriceLevels frm = new frmEditPriceLevels();
                frm.ShowDialog();
            }
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count == 0) { }
            else if (currentOrder.Hid > 0) //updating existing hold
            {
                UpdateHold();
            }
            else
            {
                frmTables frm = new frmTables(frmTables.mode.save, currentOrder);
                frm.ShowDialog();
                FinalizeTransaction();
                if (frmsplit == null || frmsplit.Visible == false)
                {
                    context.Logout();
                }
            }
        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction.");
            }
            else
            {
                frmEditTables frm = new frmEditTables();
                frm.ShowDialog();
            }
        }

        private void btnTabs_Click(object sender, EventArgs e)
        {
            frmTables frm = new frmTables(frmTables.mode.load, currentOrder);
            frm.ShowDialog();
            txtTotal.BackColor = Color.White;
            orderFinalized = false;
            UpdateOrder();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction.");
            }
            else
            {
                frmRooms frm = new frmRooms();
                frm.ShowDialog();
            }

        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            if (orderFinalized || currentOrder.OrderItems.Count == 0)
            {
                MessageBox.Show("No order to split.");
                
            }
            else
            {
                frmsplit = new frmSplit(currentOrder, this);
                orderFinalized = true;
                frmsplit.Show();
                currentOrder = new POSOrder();
                UpdateOrder();
            }
        }

        private void btnZeroIncome_Click(object sender, EventArgs e)
        {
            if (orderFinalized || currentOrder.OrderItems.Count == 0)
            {
            }
            else
            {
                Ztid = -1;
                frmZeroIncome frm = new frmZeroIncome(this);
                frm.ShowDialog();
                if (Ztid != -1)
                {
                    DataHelper.SaveZeroIncome(currentOrder.OrderItems, Ztid);
                    txtTotal.BackColor = Color.SandyBrown;
                    orderFinalized = true;
                    currentOrder = new POSOrder();
                }
            }
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            if (!orderFinalized && dgOrders.SelectedRows.Count > 0)
            {
                Global.UserInput = -1;
                NumberPad frm = new NumberPad("Enter Quantity", 2);
                frm.ShowDialog();

                if (Global.UserInput > 0)
                {
                    foreach (DataGridViewRow row in dgOrders.SelectedRows)
                    {
                        POSItemTill item = row.DataBoundItem as POSItemTill;
                        item.Quantity = Convert.ToInt32(Global.UserInput);
                    }
                    UpdateOrder();
                }
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (orderFinalized || currentOrder.OrderItems.Count == 0)
            {
                context.Logout();
            }
            else
            {
                MessageBox.Show("Please complete transaction.");
            }
        }

        private void productLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction.");
            }
            else
            {
                frmMainEdit frm = new frmMainEdit(tbSection.SelectedTab.Tag as POSSection);
                frm.ShowDialog();
                Rebuild();
            }
        }

        private void trainingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orderFinalized || currentOrder.OrderItems.Count == 0)
            {
                trainingMode = !trainingMode;
                UpdateMessage();
            }
            else
            {
                MessageBox.Show("Please complete transaction.");
            }
            
        }

        public void RunUserPrivileges()
        {
            userPrivileges = DataHelper.GetUserPrivileges(
                Global.CurrentUser.Uid);
            priceLevelsToolStripMenuItem.Enabled = 
                userPrivileges[POSPrivilege.EDIT_PRICE_LEVELS].Allowed;
            productsToolStripMenuItem.Enabled = 
                userPrivileges[POSPrivilege.EDIT_PRODUCTS].Allowed;
            roomsToolStripMenuItem.Enabled = 
                userPrivileges[POSPrivilege.EDIT_ROOMS].Allowed;
            sectionsToolStripMenuItem.Enabled = 
                userPrivileges[POSPrivilege.EDIT_SECTIONS_AND_CATEGORIES].Allowed;
            tablesToolStripMenuItem.Enabled = 
                userPrivileges[POSPrivilege.EDIT_TABLES].Allowed;
            usersToolStripMenuItem.Enabled = 
                userPrivileges[POSPrivilege.EDIT_USERS].Allowed;
            btnPriceLevel.Enabled =  
                userPrivileges[POSPrivilege.PRICE_LEVEL].Allowed;
            btnPriceOverride.Enabled =
                userPrivileges[POSPrivilege.PRICE_OVERRIDE].Allowed;
            productLayoutToolStripMenuItem.Enabled =
                userPrivileges[POSPrivilege.USE_EDIT_MODE].Allowed;
            trainingModeToolStripMenuItem.Enabled = 
                userPrivileges[POSPrivilege.USE_TRAINING_MODE].Allowed;

        }

        public void UpdateMessage()
        {
            string msg = "User: " + Global.CurrentUser.Username;
            if (trainingMode)
            {
                msg += ", Training Mode";
            }
            txtMessage.Text = msg;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (orderFinalized && currentOrder.OrderItems.Count == 0)
            {
                POSReceiptPrinter printer = new POSReceiptPrinter(lastOrder,
                    Global.CurrentUser.Username);
                printer.Print();
            }
        }

        private void autoProductLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                POSSection section = (POSSection)tbSection.SelectedTab.Tag;
                if (section != null)
                {
                    ButtonArranger arranger = new ButtonArranger(section.SectionId);
                    if (!arranger.Arrange())
                    {
                        MessageBox.Show("Too many items for this section. Please remove some or create another section.");
                    }

                    Rebuild(section);
                }
            }
            catch (Exception)
            {
                List<POSInstruction> instructions = (List<POSInstruction>)tbSection.SelectedTab.Tag;
                if (instructions != null)
                {
                    tbSection.SelectedTab.Controls.Clear();
                    BuildInstructionButtons(tbSection.SelectedTab);
                }
            }
        }

        private void printersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrinters frm = new frmPrinters();
            frm.ShowDialog();
        }

        private void btnSearchProducts_Click(object sender, EventArgs e)
        {
            retval = null;
            Global.ProductChanged = false;
            frmSearchProducts frm = new frmSearchProducts(this, frmSearchProducts.Mode.Select);
            frm.ShowDialog();
            if (retval != null)
            {
                POSProduct prod = (POSProduct)retval;
                List<POSItemTill> items = DataHelper.GetItemsByProduct(prod.ProductId);
                if (items.Count > 1)
                {
                    Global.ParentForm = this;
                    Global.CurrentProduct = prod;
                    Global.CurrentItem = null;
                    frmItems frmi = new frmItems(items);
                    frmi.ShowDialog();
                    if (Global.CurrentItem != null)
                    {
                        AddOrderItem(Global.CurrentItem);
                    }
                }
                else if (items.Count == 1)
                {
                    AddOrderItem(items[0]);
                }
                

                //make the last item ordered the selected row
                if (dgOrders.Rows.Count > 0)
                {
                    int idx = dgOrders.Rows.Count - 1;
                    DataGridViewRow row = dgOrders.Rows[idx];
                    DataGridViewCellCollection cells = row.Cells;
                    dgOrders.CurrentCell = cells[0];
                }  
            }
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.ShowDialog();
        }

        private void recentOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                MessageBox.Show("Please complete transaction");
            }
            else
            {
                frmRecentOrders frm = new frmRecentOrders(this);
                frm.ShowDialog();
            }
        }

        private void btnNoSale_Click(object sender, EventArgs e)
        {
            RawPrinterHelper.OpenCashDrawer1(Global.ReceiptPrinterName);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                POSSection section = (POSSection)tbSection.SelectedTab.Tag;
                Rebuild(section);
            }
            catch (Exception)
            {
                List<POSInstruction> instructions = (List<POSInstruction>)tbSection.SelectedTab.Tag;
                if (instructions != null)
                {
                    tbSection.SelectedTab.Controls.Clear();
                    BuildInstructionButtons(tbSection.SelectedTab);
                }
            }
        }

        private void btnDocket_Click(object sender, EventArgs e)
        {

            if (currentOrder.OrderItems.Count > 0)
            {
                POSPrintController controller = new POSPrintController(currentOrder);
                controller.PrintOne();
            }
            else if (orderFinalized && currentOrder.OrderItems.Count == 0)
            {
                POSPrintController controller = new POSPrintController(lastOrder);   
                controller.PrintOne();
            }
        }

        private void dailyTotalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalsPrinter printer = new TotalsPrinter();
            printer.Print();
        }

        private void tbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFocus();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            Global.BarcodeItem = null;
            frmBarcode frm = new frmBarcode();
            frm.ShowDialog();
            if (Global.BarcodeItem != null)
            {
                AddOrderItem(Global.BarcodeItem);
                UpdateOrder();
            }
        }

        private void dailyItemTotalsByCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyItemTotalsByCategory report = new DailyItemTotalsByCategory();
        }

        private void itemTotalsDateRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.OK = false;
            frmDateRange frm = new frmDateRange();
            frm.ShowDialog();
            if (Global.OK == true)
            {
                ItemTotalsByCategoryDateRange report = new ItemTotalsByCategoryDateRange(Global.StartDate,
                    Global.EndDate);
            }
        }

        private void zeroIncomeTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZeroIncomeTypes frm = new frmZeroIncomeTypes();
            frm.ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
            frm.ShowDialog();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgOrders.Rows)
            {
                row.Selected = true;
            }
        }


    }
}
