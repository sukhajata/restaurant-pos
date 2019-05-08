namespace Bliss_POS
{
    partial class frmEditPriceLevels
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
            this.pnlName = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlRules = new System.Windows.Forms.Panel();
            this.dgRules = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddException = new System.Windows.Forms.Button();
            this.btnRemoveException = new System.Windows.Forms.Button();
            this.btnAddPriceLevel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboPriceLevel = new Bliss_POS.CustomControls.PriceLevelCombo();
            this.pnlName.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlName
            // 
            this.pnlName.ColumnCount = 2;
            this.pnlName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.125F));
            this.pnlName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.875F));
            this.pnlName.Controls.Add(this.label2, 0, 1);
            this.pnlName.Controls.Add(this.label1, 0, 0);
            this.pnlName.Controls.Add(this.txtRate, 1, 1);
            this.pnlName.Controls.Add(this.label3, 0, 2);
            this.pnlName.Controls.Add(this.txtDescription, 1, 2);
            this.pnlName.Controls.Add(this.cboPriceLevel, 1, 0);
            this.pnlName.Location = new System.Drawing.Point(23, 23);
            this.pnlName.Name = "pnlName";
            this.pnlName.RowCount = 3;
            this.pnlName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pnlName.Size = new System.Drawing.Size(352, 121);
            this.pnlName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Default Rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Price Level:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRate
            // 
            this.txtRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRate.Location = new System.Drawing.Point(102, 33);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(247, 23);
            this.txtRate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 61);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(102, 63);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(247, 55);
            this.txtDescription.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(267, 644);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 74);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(228, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 58);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(118, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 58);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlRules
            // 
            this.pnlRules.Controls.Add(this.dgRules);
            this.pnlRules.Location = new System.Drawing.Point(24, 294);
            this.pnlRules.Name = "pnlRules";
            this.pnlRules.Size = new System.Drawing.Size(695, 220);
            this.pnlRules.TabIndex = 3;
            // 
            // dgRules
            // 
            this.dgRules.AllowUserToAddRows = false;
            this.dgRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRules.Location = new System.Drawing.Point(0, 0);
            this.dgRules.Name = "dgRules";
            this.dgRules.ReadOnly = true;
            this.dgRules.Size = new System.Drawing.Size(695, 220);
            this.dgRules.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Exceptions";
            // 
            // btnAddException
            // 
            this.btnAddException.Location = new System.Drawing.Point(740, 294);
            this.btnAddException.Name = "btnAddException";
            this.btnAddException.Size = new System.Drawing.Size(100, 60);
            this.btnAddException.TabIndex = 5;
            this.btnAddException.Text = "New";
            this.btnAddException.UseVisualStyleBackColor = true;
            this.btnAddException.Click += new System.EventHandler(this.btnAddException_Click);
            // 
            // btnRemoveException
            // 
            this.btnRemoveException.Location = new System.Drawing.Point(740, 388);
            this.btnRemoveException.Name = "btnRemoveException";
            this.btnRemoveException.Size = new System.Drawing.Size(100, 60);
            this.btnRemoveException.TabIndex = 6;
            this.btnRemoveException.Text = "Remove";
            this.btnRemoveException.UseVisualStyleBackColor = true;
            this.btnRemoveException.Click += new System.EventHandler(this.btnRemoveException_Click);
            // 
            // btnAddPriceLevel
            // 
            this.btnAddPriceLevel.Location = new System.Drawing.Point(123, 166);
            this.btnAddPriceLevel.Name = "btnAddPriceLevel";
            this.btnAddPriceLevel.Size = new System.Drawing.Size(100, 60);
            this.btnAddPriceLevel.TabIndex = 7;
            this.btnAddPriceLevel.Text = "New";
            this.btnAddPriceLevel.UseVisualStyleBackColor = true;
            this.btnAddPriceLevel.Click += new System.EventHandler(this.btnAddPriceLevel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(244, 166);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 60);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboPriceLevel
            // 
            this.cboPriceLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriceLevel.FormattingEnabled = true;
            this.cboPriceLevel.Location = new System.Drawing.Point(102, 3);
            this.cboPriceLevel.Name = "cboPriceLevel";
            this.cboPriceLevel.Size = new System.Drawing.Size(200, 23);
            this.cboPriceLevel.TabIndex = 5;
            this.cboPriceLevel.SelectedIndexChanged += new System.EventHandler(this.cboPriceLevel_SelectedIndexChanged);
            // 
            // frmEditPriceLevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 724);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddPriceLevel);
            this.Controls.Add(this.btnRemoveException);
            this.Controls.Add(this.btnAddException);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlRules);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlName);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmEditPriceLevels";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlRules;
        private System.Windows.Forms.DataGridView dgRules;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddException;
        private Bliss_POS.CustomControls.PriceLevelCombo cboPriceLevel;
        private System.Windows.Forms.Button btnRemoveException;
        private System.Windows.Forms.Button btnAddPriceLevel;
        private System.Windows.Forms.Button btnSave;
    }
}