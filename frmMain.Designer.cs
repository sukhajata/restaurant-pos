using Bliss_POS.CustomControls;

namespace Bliss_POS
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRight = new System.Windows.Forms.FlowLayoutPanel();
            this.dgOrders = new System.Windows.Forms.DataGridView();
            this.pnlFunctions = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCredit = new System.Windows.Forms.Button();
            this.btnEFTPOS = new System.Windows.Forms.Button();
            this.btnPriceOverride = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPriceLevel = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.btnTabs = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnQuantity = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.btnNoSale = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.pnlButtonsLower = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearchProducts = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnDocket = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.tbSection = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoProductLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyTotalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyItemTotalsByCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTotalsDateRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).BeginInit();
            this.pnlFunctions.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlButtonsLower.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnlRight.Controls.Add(this.dgOrders);
            this.pnlRight.Controls.Add(this.pnlFunctions);
            this.pnlRight.Controls.Add(this.pnlTotal);
            this.pnlRight.Controls.Add(this.pnlButtonsLower);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(682, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(310, 778);
            this.pnlRight.TabIndex = 2;
            // 
            // dgOrders
            // 
            this.dgOrders.AllowUserToAddRows = false;
            this.dgOrders.AllowUserToDeleteRows = false;
            this.dgOrders.AllowUserToResizeColumns = false;
            this.dgOrders.AllowUserToResizeRows = false;
            this.dgOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgOrders.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgOrders.Location = new System.Drawing.Point(3, 3);
            this.dgOrders.Name = "dgOrders";
            this.dgOrders.ReadOnly = true;
            this.dgOrders.RowHeadersVisible = false;
            this.dgOrders.RowTemplate.Height = 30;
            this.dgOrders.RowTemplate.ReadOnly = true;
            this.dgOrders.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrders.Size = new System.Drawing.Size(300, 330);
            this.dgOrders.TabIndex = 0;
            // 
            // pnlFunctions
            // 
            this.pnlFunctions.ColumnCount = 3;
            this.pnlFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlFunctions.Controls.Add(this.btnSelectAll, 0, 0);
            this.pnlFunctions.Controls.Add(this.btnCredit, 0, 2);
            this.pnlFunctions.Controls.Add(this.btnEFTPOS, 0, 2);
            this.pnlFunctions.Controls.Add(this.btnPriceOverride, 2, 1);
            this.pnlFunctions.Controls.Add(this.btnDelete, 2, 0);
            this.pnlFunctions.Controls.Add(this.btnPriceLevel, 1, 1);
            this.pnlFunctions.Controls.Add(this.btnCash, 0, 2);
            this.pnlFunctions.Controls.Add(this.btnHold, 0, 3);
            this.pnlFunctions.Controls.Add(this.btnTabs, 2, 3);
            this.pnlFunctions.Controls.Add(this.btnSplit, 1, 3);
            this.pnlFunctions.Controls.Add(this.btnQuantity, 1, 0);
            this.pnlFunctions.Controls.Add(this.btnBarcode, 0, 1);
            this.pnlFunctions.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFunctions.Location = new System.Drawing.Point(3, 339);
            this.pnlFunctions.Name = "pnlFunctions";
            this.pnlFunctions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFunctions.RowCount = 4;
            this.pnlFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlFunctions.Size = new System.Drawing.Size(305, 280);
            this.pnlFunctions.TabIndex = 4;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectAll.Location = new System.Drawing.Point(8, 8);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(92, 61);
            this.btnSelectAll.TabIndex = 14;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCredit
            // 
            this.btnCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCredit.Location = new System.Drawing.Point(8, 142);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(92, 61);
            this.btnCredit.TabIndex = 5;
            this.btnCredit.Text = "Credit";
            this.btnCredit.UseVisualStyleBackColor = false;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // btnEFTPOS
            // 
            this.btnEFTPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEFTPOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEFTPOS.Location = new System.Drawing.Point(106, 142);
            this.btnEFTPOS.Name = "btnEFTPOS";
            this.btnEFTPOS.Size = new System.Drawing.Size(92, 61);
            this.btnEFTPOS.TabIndex = 4;
            this.btnEFTPOS.Text = "EFTPOS";
            this.btnEFTPOS.UseVisualStyleBackColor = false;
            this.btnEFTPOS.Click += new System.EventHandler(this.btnEFTPOS_Click);
            // 
            // btnPriceOverride
            // 
            this.btnPriceOverride.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPriceOverride.Location = new System.Drawing.Point(204, 75);
            this.btnPriceOverride.Name = "btnPriceOverride";
            this.btnPriceOverride.Size = new System.Drawing.Size(93, 61);
            this.btnPriceOverride.TabIndex = 0;
            this.btnPriceOverride.Text = "Price Override";
            this.btnPriceOverride.UseVisualStyleBackColor = true;
            this.btnPriceOverride.Click += new System.EventHandler(this.btnPriceOverride_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(204, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 61);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPriceLevel
            // 
            this.btnPriceLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPriceLevel.Location = new System.Drawing.Point(106, 75);
            this.btnPriceLevel.Name = "btnPriceLevel";
            this.btnPriceLevel.Size = new System.Drawing.Size(92, 61);
            this.btnPriceLevel.TabIndex = 2;
            this.btnPriceLevel.Text = "Price Level";
            this.btnPriceLevel.UseVisualStyleBackColor = true;
            this.btnPriceLevel.Click += new System.EventHandler(this.btnPriceLevel_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCash.Location = new System.Drawing.Point(204, 142);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(93, 61);
            this.btnCash.TabIndex = 3;
            this.btnCash.Text = "Cash";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnHold
            // 
            this.btnHold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHold.Location = new System.Drawing.Point(8, 209);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(92, 63);
            this.btnHold.TabIndex = 7;
            this.btnHold.Text = "Save";
            this.btnHold.UseVisualStyleBackColor = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnTabs
            // 
            this.btnTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTabs.Location = new System.Drawing.Point(204, 209);
            this.btnTabs.Name = "btnTabs";
            this.btnTabs.Size = new System.Drawing.Size(93, 63);
            this.btnTabs.TabIndex = 8;
            this.btnTabs.Text = "Tabs";
            this.btnTabs.UseVisualStyleBackColor = true;
            this.btnTabs.Click += new System.EventHandler(this.btnTabs_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSplit.Location = new System.Drawing.Point(106, 209);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(92, 63);
            this.btnSplit.TabIndex = 10;
            this.btnSplit.Text = "Split Bill";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnQuantity
            // 
            this.btnQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuantity.Location = new System.Drawing.Point(106, 8);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.Size = new System.Drawing.Size(92, 61);
            this.btnQuantity.TabIndex = 12;
            this.btnQuantity.Text = "Quantity";
            this.btnQuantity.UseVisualStyleBackColor = true;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBarcode.Location = new System.Drawing.Point(8, 75);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(92, 61);
            this.btnBarcode.TabIndex = 13;
            this.btnBarcode.Text = "Barcode";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.btnNoSale);
            this.pnlTotal.Controls.Add(this.txtTotal);
            this.pnlTotal.Location = new System.Drawing.Point(3, 625);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(305, 70);
            this.pnlTotal.TabIndex = 5;
            // 
            // btnNoSale
            // 
            this.btnNoSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNoSale.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoSale.Location = new System.Drawing.Point(5, 3);
            this.btnNoSale.Name = "btnNoSale";
            this.btnNoSale.Size = new System.Drawing.Size(94, 63);
            this.btnNoSale.TabIndex = 2;
            this.btnNoSale.Text = "No Sale";
            this.btnNoSale.UseVisualStyleBackColor = false;
            this.btnNoSale.Click += new System.EventHandler(this.btnNoSale_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Arial", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(105, 0);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(200, 68);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.Text = "$0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlButtonsLower
            // 
            this.pnlButtonsLower.ColumnCount = 3;
            this.pnlButtonsLower.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlButtonsLower.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlButtonsLower.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlButtonsLower.Controls.Add(this.btnLogout, 2, 0);
            this.pnlButtonsLower.Controls.Add(this.btnPrint, 0, 0);
            this.pnlButtonsLower.Controls.Add(this.btnSearchProducts, 1, 0);
            this.pnlButtonsLower.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlButtonsLower.Location = new System.Drawing.Point(3, 701);
            this.pnlButtonsLower.Name = "pnlButtonsLower";
            this.pnlButtonsLower.Padding = new System.Windows.Forms.Padding(2);
            this.pnlButtonsLower.RowCount = 1;
            this.pnlButtonsLower.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlButtonsLower.Size = new System.Drawing.Size(305, 73);
            this.pnlButtonsLower.TabIndex = 6;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Location = new System.Drawing.Point(205, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(95, 63);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrint.Location = new System.Drawing.Point(5, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 63);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Receipt";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearchProducts
            // 
            this.btnSearchProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchProducts.Location = new System.Drawing.Point(105, 5);
            this.btnSearchProducts.Name = "btnSearchProducts";
            this.btnSearchProducts.Size = new System.Drawing.Size(94, 63);
            this.btnSearchProducts.TabIndex = 2;
            this.btnSearchProducts.Text = "Search Products";
            this.btnSearchProducts.UseVisualStyleBackColor = true;
            this.btnSearchProducts.Click += new System.EventHandler(this.btnSearchProducts_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.txtBarcode);
            this.pnlLeft.Controls.Add(this.btnDocket);
            this.pnlLeft.Controls.Add(this.txtMessage);
            this.pnlLeft.Controls.Add(this.tbSection);
            this.pnlLeft.Controls.Add(this.menuStrip1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(682, 778);
            this.pnlLeft.TabIndex = 3;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(608, 5);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(73, 23);
            this.txtBarcode.TabIndex = 1;
            // 
            // btnDocket
            // 
            this.btnDocket.Location = new System.Drawing.Point(527, 0);
            this.btnDocket.Name = "btnDocket";
            this.btnDocket.Size = new System.Drawing.Size(75, 30);
            this.btnDocket.TabIndex = 3;
            this.btnDocket.Text = "Docket";
            this.btnDocket.UseVisualStyleBackColor = true;
            this.btnDocket.Click += new System.EventHandler(this.btnDocket_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.txtMessage.Location = new System.Drawing.Point(120, 3);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(401, 26);
            this.txtMessage.TabIndex = 2;
            // 
            // tbSection
            // 
            this.tbSection.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSection.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSection.ItemSize = new System.Drawing.Size(150, 60);
            this.tbSection.Location = new System.Drawing.Point(0, 34);
            this.tbSection.Multiline = true;
            this.tbSection.Name = "tbSection";
            this.tbSection.Padding = new System.Drawing.Point(10, 3);
            this.tbSection.SelectedIndex = 0;
            this.tbSection.Size = new System.Drawing.Size(682, 744);
            this.tbSection.TabIndex = 1;
            this.tbSection.SelectedIndexChanged += new System.EventHandler(this.tbSection_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 34);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.autoProductLayoutToolStripMenuItem,
            this.configToolStripMenuItem,
            this.dailyTotalsToolStripMenuItem,
            this.productLayoutToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.priceLevelsToolStripMenuItem,
            this.printersToolStripMenuItem,
            this.recentOrdersToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.roomsToolStripMenuItem,
            this.sectionsToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.trainingModeToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(82, 30);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // autoProductLayoutToolStripMenuItem
            // 
            this.autoProductLayoutToolStripMenuItem.Name = "autoProductLayoutToolStripMenuItem";
            this.autoProductLayoutToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.autoProductLayoutToolStripMenuItem.Text = "Auto Product Layout";
            this.autoProductLayoutToolStripMenuItem.Click += new System.EventHandler(this.autoProductLayoutToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // dailyTotalsToolStripMenuItem
            // 
            this.dailyTotalsToolStripMenuItem.Name = "dailyTotalsToolStripMenuItem";
            this.dailyTotalsToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.dailyTotalsToolStripMenuItem.Text = "Daily Totals";
            this.dailyTotalsToolStripMenuItem.Click += new System.EventHandler(this.dailyTotalsToolStripMenuItem_Click);
            // 
            // productLayoutToolStripMenuItem
            // 
            this.productLayoutToolStripMenuItem.Name = "productLayoutToolStripMenuItem";
            this.productLayoutToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.productLayoutToolStripMenuItem.Text = "Edit Mode";
            this.productLayoutToolStripMenuItem.Click += new System.EventHandler(this.productLayoutToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // priceLevelsToolStripMenuItem
            // 
            this.priceLevelsToolStripMenuItem.Name = "priceLevelsToolStripMenuItem";
            this.priceLevelsToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.priceLevelsToolStripMenuItem.Text = "Price Levels";
            this.priceLevelsToolStripMenuItem.Click += new System.EventHandler(this.priceLevelsToolStripMenuItem_Click);
            // 
            // printersToolStripMenuItem
            // 
            this.printersToolStripMenuItem.Name = "printersToolStripMenuItem";
            this.printersToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.printersToolStripMenuItem.Text = "Printers";
            this.printersToolStripMenuItem.Click += new System.EventHandler(this.printersToolStripMenuItem_Click);
            // 
            // recentOrdersToolStripMenuItem
            // 
            this.recentOrdersToolStripMenuItem.Name = "recentOrdersToolStripMenuItem";
            this.recentOrdersToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.recentOrdersToolStripMenuItem.Text = "Recent Orders";
            this.recentOrdersToolStripMenuItem.Click += new System.EventHandler(this.recentOrdersToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyItemTotalsByCategoryToolStripMenuItem,
            this.itemTotalsDateRangeToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // dailyItemTotalsByCategoryToolStripMenuItem
            // 
            this.dailyItemTotalsByCategoryToolStripMenuItem.Name = "dailyItemTotalsByCategoryToolStripMenuItem";
            this.dailyItemTotalsByCategoryToolStripMenuItem.Size = new System.Drawing.Size(347, 30);
            this.dailyItemTotalsByCategoryToolStripMenuItem.Text = "Daily Item Totals By Category";
            this.dailyItemTotalsByCategoryToolStripMenuItem.Click += new System.EventHandler(this.dailyItemTotalsByCategoryToolStripMenuItem_Click);
            // 
            // itemTotalsDateRangeToolStripMenuItem
            // 
            this.itemTotalsDateRangeToolStripMenuItem.Name = "itemTotalsDateRangeToolStripMenuItem";
            this.itemTotalsDateRangeToolStripMenuItem.Size = new System.Drawing.Size(347, 30);
            this.itemTotalsDateRangeToolStripMenuItem.Text = "Item Totals Date Range";
            this.itemTotalsDateRangeToolStripMenuItem.Click += new System.EventHandler(this.itemTotalsDateRangeToolStripMenuItem_Click);
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.roomsToolStripMenuItem.Text = "Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // sectionsToolStripMenuItem
            // 
            this.sectionsToolStripMenuItem.Name = "sectionsToolStripMenuItem";
            this.sectionsToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.sectionsToolStripMenuItem.Text = "Sections and Categories";
            this.sectionsToolStripMenuItem.Click += new System.EventHandler(this.sectionsToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.tablesToolStripMenuItem.Text = "Tables";
            this.tablesToolStripMenuItem.Click += new System.EventHandler(this.tablesToolStripMenuItem_Click);
            // 
            // trainingModeToolStripMenuItem
            // 
            this.trainingModeToolStripMenuItem.Name = "trainingModeToolStripMenuItem";
            this.trainingModeToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.trainingModeToolStripMenuItem.Text = "Training Mode";
            this.trainingModeToolStripMenuItem.Click += new System.EventHandler(this.trainingModeToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 778);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).EndInit();
            this.pnlFunctions.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlButtonsLower.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlRight;
        private System.Windows.Forms.DataGridView dgOrders;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TabControl tbSection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel pnlFunctions;
        private System.Windows.Forms.Button btnPriceOverride;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPriceLevel;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.Button btnEFTPOS;
        private System.Windows.Forms.ToolStripMenuItem sectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceLevelsToolStripMenuItem;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.Button btnTabs;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnQuantity;
        private System.Windows.Forms.TableLayoutPanel pnlButtonsLower;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolStripMenuItem productLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingModeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ToolStripMenuItem autoProductLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printersToolStripMenuItem;
        private System.Windows.Forms.Button btnSearchProducts;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentOrdersToolStripMenuItem;
        private System.Windows.Forms.Button btnNoSale;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button btnDocket;
        private System.Windows.Forms.ToolStripMenuItem dailyTotalsToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyItemTotalsByCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemTotalsDateRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.Button btnSelectAll;


    }
}

