namespace Bliss_POS
{
    partial class frmPriceLevels
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
            this.btnStandard = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.lstScope = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStandard
            // 
            this.btnStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStandard.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandard.Location = new System.Drawing.Point(8, 86);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Padding = new System.Windows.Forms.Padding(3);
            this.btnStandard.Size = new System.Drawing.Size(94, 73);
            this.btnStandard.TabIndex = 0;
            this.btnStandard.Text = "Standard";
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.btnStandard_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStandard, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 122);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 167);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(208, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(104, 73);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btn3
            // 
            this.btn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(208, 8);
            this.btn3.Name = "btn3";
            this.btn3.Padding = new System.Windows.Forms.Padding(3);
            this.btn3.Size = new System.Drawing.Size(104, 72);
            this.btn3.TabIndex = 3;
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(108, 8);
            this.btn2.Name = "btn2";
            this.btn2.Padding = new System.Windows.Forms.Padding(3);
            this.btn2.Size = new System.Drawing.Size(94, 72);
            this.btn2.TabIndex = 2;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(8, 8);
            this.btn1.Name = "btn1";
            this.btn1.Padding = new System.Windows.Forms.Padding(3);
            this.btn1.Size = new System.Drawing.Size(94, 72);
            this.btn1.TabIndex = 1;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // lstScope
            // 
            this.lstScope.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstScope.FormattingEnabled = true;
            this.lstScope.ItemHeight = 29;
            this.lstScope.Location = new System.Drawing.Point(13, 10);
            this.lstScope.Name = "lstScope";
            this.lstScope.Size = new System.Drawing.Size(318, 91);
            this.lstScope.TabIndex = 2;
            // 
            // frmPriceLevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 303);
            this.ControlBox = false;
            this.Controls.Add(this.lstScope);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPriceLevels";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstScope;
    }
}