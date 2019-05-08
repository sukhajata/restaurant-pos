namespace Bliss_POS
{
    partial class frmSplit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLeftToRight = new System.Windows.Forms.Button();
            this.btnRightToLeft = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAllLeftToRight = new System.Windows.Forms.Button();
            this.dgLeft = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLeftToRight
            // 
            this.btnLeftToRight.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftToRight.Location = new System.Drawing.Point(318, 84);
            this.btnLeftToRight.Name = "btnLeftToRight";
            this.btnLeftToRight.Size = new System.Drawing.Size(70, 60);
            this.btnLeftToRight.TabIndex = 5;
            this.btnLeftToRight.Text = "->";
            this.btnLeftToRight.UseVisualStyleBackColor = true;
            this.btnLeftToRight.Click += new System.EventHandler(this.btnLeftToRight_Click);
            // 
            // btnRightToLeft
            // 
            this.btnRightToLeft.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightToLeft.Location = new System.Drawing.Point(318, 253);
            this.btnRightToLeft.Name = "btnRightToLeft";
            this.btnRightToLeft.Size = new System.Drawing.Size(70, 60);
            this.btnRightToLeft.TabIndex = 6;
            this.btnRightToLeft.Text = "<-";
            this.btnRightToLeft.UseVisualStyleBackColor = true;
            this.btnRightToLeft.Click += new System.EventHandler(this.btnRightToLeft_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Arial", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(12, 484);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(275, 68);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.Text = "$0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAllLeftToRight
            // 
            this.btnAllLeftToRight.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllLeftToRight.Location = new System.Drawing.Point(318, 150);
            this.btnAllLeftToRight.Name = "btnAllLeftToRight";
            this.btnAllLeftToRight.Size = new System.Drawing.Size(70, 60);
            this.btnAllLeftToRight.TabIndex = 9;
            this.btnAllLeftToRight.Text = ">>";
            this.btnAllLeftToRight.UseVisualStyleBackColor = true;
            this.btnAllLeftToRight.Click += new System.EventHandler(this.btnAllLeftToRight_Click);
            // 
            // dgLeft
            // 
            this.dgLeft.AllowUserToAddRows = false;
            this.dgLeft.AllowUserToDeleteRows = false;
            this.dgLeft.AllowUserToResizeColumns = false;
            this.dgLeft.AllowUserToResizeRows = false;
            this.dgLeft.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLeft.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgLeft.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLeft.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgLeft.Location = new System.Drawing.Point(12, 3);
            this.dgLeft.MultiSelect = false;
            this.dgLeft.Name = "dgLeft";
            this.dgLeft.ReadOnly = true;
            this.dgLeft.RowHeadersVisible = false;
            this.dgLeft.RowTemplate.Height = 30;
            this.dgLeft.RowTemplate.ReadOnly = true;
            this.dgLeft.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLeft.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLeft.Size = new System.Drawing.Size(300, 465);
            this.dgLeft.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(318, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 60);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 557);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgLeft);
            this.Controls.Add(this.btnAllLeftToRight);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnRightToLeft);
            this.Controls.Add(this.btnLeftToRight);
            this.Location = new System.Drawing.Point(800, 100);
            this.Name = "frmSplit";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLeftToRight;
        private System.Windows.Forms.Button btnRightToLeft;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAllLeftToRight;
        private System.Windows.Forms.DataGridView dgLeft;
        private System.Windows.Forms.Button btnSave;
    }
}