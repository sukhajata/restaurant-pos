namespace Bliss_POS
{
    partial class frmAddPriceLevelException
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
            this.pnlExceptions = new System.Windows.Forms.TableLayoutPanel();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.lstSections = new System.Windows.Forms.ListBox();
            this.lstSuppliers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveSupplier = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.cboSupplier = new Bliss_POS.CustomControls.SupplierCombo();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveSection = new System.Windows.Forms.Button();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.cboSection = new Bliss_POS.CustomControls.SectionCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCategory = new System.Windows.Forms.TableLayoutPanel();
            this.cboCategory = new Bliss_POS.CustomControls.CategoryCombo();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnRemoveCategory = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlExceptions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlExceptions
            // 
            this.pnlExceptions.ColumnCount = 3;
            this.pnlExceptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.54391F));
            this.pnlExceptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.45609F));
            this.pnlExceptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 509F));
            this.pnlExceptions.Controls.Add(this.lstCategories, 1, 3);
            this.pnlExceptions.Controls.Add(this.lstSections, 1, 2);
            this.pnlExceptions.Controls.Add(this.lstSuppliers, 1, 1);
            this.pnlExceptions.Controls.Add(this.label2, 0, 1);
            this.pnlExceptions.Controls.Add(this.label1, 0, 0);
            this.pnlExceptions.Controls.Add(this.panel1, 2, 1);
            this.pnlExceptions.Controls.Add(this.txtRate, 1, 0);
            this.pnlExceptions.Controls.Add(this.label3, 0, 2);
            this.pnlExceptions.Controls.Add(this.panel2, 2, 2);
            this.pnlExceptions.Controls.Add(this.label4, 0, 3);
            this.pnlExceptions.Controls.Add(this.pnlCategory, 2, 3);
            this.pnlExceptions.Location = new System.Drawing.Point(15, 49);
            this.pnlExceptions.Name = "pnlExceptions";
            this.pnlExceptions.RowCount = 4;
            this.pnlExceptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.pnlExceptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.pnlExceptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.pnlExceptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.pnlExceptions.Size = new System.Drawing.Size(839, 448);
            this.pnlExceptions.TabIndex = 3;
            // 
            // lstCategories
            // 
            this.lstCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 15;
            this.lstCategories.Location = new System.Drawing.Point(123, 310);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(203, 124);
            this.lstCategories.TabIndex = 16;
            // 
            // lstSections
            // 
            this.lstSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSections.FormattingEnabled = true;
            this.lstSections.ItemHeight = 15;
            this.lstSections.Location = new System.Drawing.Point(123, 172);
            this.lstSections.Name = "lstSections";
            this.lstSections.Size = new System.Drawing.Size(203, 124);
            this.lstSections.TabIndex = 14;
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSuppliers.FormattingEnabled = true;
            this.lstSuppliers.ItemHeight = 15;
            this.lstSuppliers.Location = new System.Drawing.Point(123, 34);
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(203, 124);
            this.lstSuppliers.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 138);
            this.label2.TabIndex = 1;
            this.label2.Text = "Suppliers:\r\n(default is all)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rate:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemoveSupplier);
            this.panel1.Controls.Add(this.btnAddSupplier);
            this.panel1.Controls.Add(this.cboSupplier);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(332, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 132);
            this.panel1.TabIndex = 11;
            // 
            // btnRemoveSupplier
            // 
            this.btnRemoveSupplier.Location = new System.Drawing.Point(3, 46);
            this.btnRemoveSupplier.Margin = new System.Windows.Forms.Padding(3, 52, 3, 52);
            this.btnRemoveSupplier.Name = "btnRemoveSupplier";
            this.btnRemoveSupplier.Size = new System.Drawing.Size(87, 40);
            this.btnRemoveSupplier.TabIndex = 12;
            this.btnRemoveSupplier.Text = "Remove";
            this.btnRemoveSupplier.UseVisualStyleBackColor = true;
            this.btnRemoveSupplier.Click += new System.EventHandler(this.btnRemoveSupplier_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(235, 3);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(87, 40);
            this.btnAddSupplier.TabIndex = 11;
            this.btnAddSupplier.Text = "Add";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(3, 3);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(226, 23);
            this.cboSupplier.TabIndex = 9;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(123, 3);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 23);
            this.txtRate.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 138);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sections:\r\n(default is all)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemoveSection);
            this.panel2.Controls.Add(this.btnAddSection);
            this.panel2.Controls.Add(this.cboSection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(332, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 132);
            this.panel2.TabIndex = 15;
            // 
            // btnRemoveSection
            // 
            this.btnRemoveSection.Location = new System.Drawing.Point(3, 46);
            this.btnRemoveSection.Margin = new System.Windows.Forms.Padding(3, 52, 3, 52);
            this.btnRemoveSection.Name = "btnRemoveSection";
            this.btnRemoveSection.Size = new System.Drawing.Size(87, 40);
            this.btnRemoveSection.TabIndex = 13;
            this.btnRemoveSection.Text = "Remove";
            this.btnRemoveSection.UseVisualStyleBackColor = true;
            this.btnRemoveSection.Click += new System.EventHandler(this.btnRemoveSection_Click);
            // 
            // btnAddSection
            // 
            this.btnAddSection.Location = new System.Drawing.Point(235, 3);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Size = new System.Drawing.Size(87, 40);
            this.btnAddSection.TabIndex = 12;
            this.btnAddSection.Text = "Add";
            this.btnAddSection.UseVisualStyleBackColor = true;
            this.btnAddSection.Click += new System.EventHandler(this.btnAddSection_Click);
            // 
            // cboSection
            // 
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Items.AddRange(new object[] {
            "--- All ---"});
            this.cboSection.Location = new System.Drawing.Point(0, 3);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(229, 23);
            this.cboSection.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 141);
            this.label4.TabIndex = 18;
            this.label4.Text = "Categories:\r\n(default is all)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCategory
            // 
            this.pnlCategory.ColumnCount = 2;
            this.pnlCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.pnlCategory.Controls.Add(this.cboCategory, 0, 0);
            this.pnlCategory.Controls.Add(this.btnAddCategory, 1, 0);
            this.pnlCategory.Controls.Add(this.btnRemoveCategory, 0, 1);
            this.pnlCategory.Location = new System.Drawing.Point(332, 310);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.RowCount = 3;
            this.pnlCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.38095F));
            this.pnlCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.pnlCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.pnlCategory.Size = new System.Drawing.Size(322, 135);
            this.pnlCategory.TabIndex = 19;
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(3, 3);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(223, 23);
            this.cboCategory.TabIndex = 16;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(232, 3);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(87, 40);
            this.btnAddCategory.TabIndex = 14;
            this.btnAddCategory.Text = "Add";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnRemoveCategory
            // 
            this.btnRemoveCategory.Location = new System.Drawing.Point(3, 55);
            this.btnRemoveCategory.Name = "btnRemoveCategory";
            this.btnRemoveCategory.Size = new System.Drawing.Size(87, 40);
            this.btnRemoveCategory.TabIndex = 17;
            this.btnRemoveCategory.Text = "Remove";
            this.btnRemoveCategory.UseVisualStyleBackColor = true;
            this.btnRemoveCategory.Click += new System.EventHandler(this.btnRemoveCategory_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(15, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(104, 19);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Exception for ";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(139, 518);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 56);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(269, 518);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 56);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddPriceLevelException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 597);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlExceptions);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAddPriceLevelException";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.pnlExceptions.ResumeLayout(false);
            this.pnlExceptions.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bliss_POS.CustomControls.SupplierCombo cboSupplier;
        private System.Windows.Forms.TableLayoutPanel pnlExceptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListBox lstSuppliers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveSupplier;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.ListBox lstSections;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemoveSection;
        private System.Windows.Forms.Button btnAddSection;
        private Bliss_POS.CustomControls.SectionCombo cboSection;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.TableLayoutPanel pnlCategory;
        private Bliss_POS.CustomControls.CategoryCombo cboCategory;
        private System.Windows.Forms.Button btnRemoveCategory;
    }
}