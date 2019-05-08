namespace Bliss_POS
{
    partial class frmItems
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
            this.pnlItems = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInstructions = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlItems
            // 
            this.pnlItems.AutoSize = true;
            this.pnlItems.ColumnCount = 4;
            this.pnlItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlItems.Location = new System.Drawing.Point(20, 91);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Padding = new System.Windows.Forms.Padding(3);
            this.pnlItems.RowCount = 1;
            this.pnlItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlItems.Size = new System.Drawing.Size(512, 6);
            this.pnlItems.TabIndex = 0;
            // 
            // pnlInstructions
            // 
            this.pnlInstructions.AutoSize = true;
            this.pnlInstructions.BackColor = System.Drawing.Color.Transparent;
            this.pnlInstructions.ColumnCount = 2;
            this.pnlInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.pnlInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.pnlInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInstructions.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInstructions.Location = new System.Drawing.Point(20, 20);
            this.pnlInstructions.Name = "pnlInstructions";
            this.pnlInstructions.RowCount = 1;
            this.pnlInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlInstructions.Size = new System.Drawing.Size(512, 0);
            this.pnlInstructions.TabIndex = 1;
            // 
            // frmItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(552, 117);
            this.ControlBox = false;
            this.Controls.Add(this.pnlInstructions);
            this.Controls.Add(this.pnlItems);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmItems";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlItems;
        private System.Windows.Forms.TableLayoutPanel pnlInstructions;
    }
}