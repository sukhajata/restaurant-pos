namespace Bliss_POS.CustomControls
{
    partial class POSKeyboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSpace = new System.Windows.Forms.Button();
            this.pnlZ = new System.Windows.Forms.TableLayoutPanel();
            this.pnlA = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQ = new System.Windows.Forms.TableLayoutPanel();
            this.pnlNumbers = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSpace
            // 
            this.btnSpace.Location = new System.Drawing.Point(205, 322);
            this.btnSpace.Name = "btnSpace";
            this.btnSpace.Size = new System.Drawing.Size(583, 75);
            this.btnSpace.TabIndex = 9;
            this.btnSpace.UseVisualStyleBackColor = true;
            this.btnSpace.Click += new System.EventHandler(this.btnSpace_Click);
            // 
            // pnlZ
            // 
            this.pnlZ.AutoSize = true;
            this.pnlZ.ColumnCount = 1;
            this.pnlZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlZ.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlZ.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlZ.Location = new System.Drawing.Point(129, 240);
            this.pnlZ.Name = "pnlZ";
            this.pnlZ.RowCount = 1;
            this.pnlZ.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlZ.Size = new System.Drawing.Size(82, 75);
            this.pnlZ.TabIndex = 8;
            // 
            // pnlA
            // 
            this.pnlA.AutoSize = true;
            this.pnlA.ColumnCount = 1;
            this.pnlA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlA.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlA.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlA.Location = new System.Drawing.Point(96, 162);
            this.pnlA.Name = "pnlA";
            this.pnlA.RowCount = 1;
            this.pnlA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlA.Size = new System.Drawing.Size(82, 75);
            this.pnlA.TabIndex = 7;
            // 
            // pnlQ
            // 
            this.pnlQ.AutoSize = true;
            this.pnlQ.ColumnCount = 1;
            this.pnlQ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlQ.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlQ.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlQ.Location = new System.Drawing.Point(62, 83);
            this.pnlQ.Name = "pnlQ";
            this.pnlQ.RowCount = 1;
            this.pnlQ.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlQ.Size = new System.Drawing.Size(82, 75);
            this.pnlQ.TabIndex = 6;
            // 
            // pnlNumbers
            // 
            this.pnlNumbers.AutoSize = true;
            this.pnlNumbers.ColumnCount = 1;
            this.pnlNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlNumbers.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNumbers.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.pnlNumbers.Location = new System.Drawing.Point(34, 5);
            this.pnlNumbers.Name = "pnlNumbers";
            this.pnlNumbers.RowCount = 1;
            this.pnlNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlNumbers.Size = new System.Drawing.Size(82, 75);
            this.pnlNumbers.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(44, 325);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 75);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // POSKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSpace);
            this.Controls.Add(this.pnlZ);
            this.Controls.Add(this.pnlA);
            this.Controls.Add(this.pnlQ);
            this.Controls.Add(this.pnlNumbers);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "POSKeyboard";
            this.Size = new System.Drawing.Size(791, 403);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpace;
        private System.Windows.Forms.TableLayoutPanel pnlZ;
        private System.Windows.Forms.TableLayoutPanel pnlA;
        private System.Windows.Forms.TableLayoutPanel pnlQ;
        private System.Windows.Forms.TableLayoutPanel pnlNumbers;
        private System.Windows.Forms.Button btnClear;
    }
}
