using Bliss_POS.CustomControls;

namespace Bliss_POS
{
    partial class frmProducts
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
            this.pnlFilter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSelectButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlSelectButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFilter.ColumnCount = 2;
            this.pnlFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.pnlFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.pnlFilter.Controls.Add(this.label5, 0, 3);
            this.pnlFilter.Controls.Add(this.label4, 0, 2);
            this.pnlFilter.Controls.Add(this.label3, 0, 1);
            this.pnlFilter.Controls.Add(this.label2, 0, 0);
            this.pnlFilter.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFilter.Location = new System.Drawing.Point(27, 35);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.RowCount = 4;
            this.pnlFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlFilter.Size = new System.Drawing.Size(555, 145);
            this.pnlFilter.TabIndex = 1;
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.dgProducts);
            this.pnlProducts.Location = new System.Drawing.Point(26, 214);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(776, 324);
            this.pnlProducts.TabIndex = 2;
            // 
            // dgProducts
            // 
            this.dgProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgProducts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProducts.Location = new System.Drawing.Point(0, 0);
            this.dgProducts.MultiSelect = false;
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProducts.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.dgProducts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgProducts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgProducts.RowTemplate.Height = 35;
            this.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducts.Size = new System.Drawing.Size(776, 324);
            this.dgProducts.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.ColumnCount = 4;
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlButtons.Controls.Add(this.btnExit, 3, 0);
            this.pnlButtons.Controls.Add(this.btnNew, 0, 0);
            this.pnlButtons.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlButtons.Location = new System.Drawing.Point(23, 688);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(5);
            this.pnlButtons.RowCount = 1;
            this.pnlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlButtons.Size = new System.Drawing.Size(408, 80);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(308, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 64);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Location = new System.Drawing.Point(8, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 64);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(382, 553);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 80);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(103, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 64);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(8, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(89, 64);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "With Selected:";
            // 
            // pnlSelectButtons
            // 
            this.pnlSelectButtons.ColumnCount = 2;
            this.pnlSelectButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSelectButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.pnlSelectButtons.Controls.Add(this.btnUnselectAll, 1, 0);
            this.pnlSelectButtons.Controls.Add(this.btnSelectAll, 0, 0);
            this.pnlSelectButtons.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSelectButtons.Location = new System.Drawing.Point(26, 551);
            this.pnlSelectButtons.Name = "pnlSelectButtons";
            this.pnlSelectButtons.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSelectButtons.RowCount = 1;
            this.pnlSelectButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSelectButtons.Size = new System.Drawing.Size(200, 90);
            this.pnlSelectButtons.TabIndex = 7;
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnselectAll.Location = new System.Drawing.Point(103, 8);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(89, 74);
            this.btnUnselectAll.TabIndex = 4;
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectAll.Location = new System.Drawing.Point(8, 8);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(89, 74);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Supplier:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Section:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 37);
            this.label5.TabIndex = 3;
            this.label5.Text = "Category:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1115, 778);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSelectButtons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlFilter);
            this.Name = "frmProducts";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlSelectButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlFilter;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.TableLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel pnlSelectButtons;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;


    }
}