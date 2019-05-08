using Bliss_POS.CustomControls;

namespace Bliss_POS
{
    partial class frmSearchProducts
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.pnlFilter.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.AutoSize = true;
            this.pnlFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFilter.ColumnCount = 2;
            this.pnlFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.pnlFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 403F));
            this.pnlFilter.Controls.Add(this.label1, 0, 0);
            this.pnlFilter.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFilter.Location = new System.Drawing.Point(27, 9);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.RowCount = 1;
            this.pnlFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlFilter.Size = new System.Drawing.Size(500, 35);
            this.pnlFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.dgProducts);
            this.pnlProducts.Location = new System.Drawing.Point(22, 482);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(811, 200);
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
            this.dgProducts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgProducts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgProducts.RowTemplate.Height = 35;
            this.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducts.Size = new System.Drawing.Size(811, 200);
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
            this.pnlButtons.Controls.Add(this.btnSelect, 0, 0);
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
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelect.Location = new System.Drawing.Point(8, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 64);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "OK";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pnlKeyboard
            // 
            this.pnlKeyboard.Location = new System.Drawing.Point(25, 63);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(1078, 413);
            this.pnlKeyboard.TabIndex = 4;
            // 
            // frmSearchProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1115, 778);
            this.ControlBox = false;
            this.Controls.Add(this.pnlKeyboard);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlFilter);
            this.Name = "frmSearchProducts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlFilter;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.TableLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Panel pnlKeyboard;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;


    }
}