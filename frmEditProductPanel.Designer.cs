namespace Bliss_POS
{
    partial class frmEditProductPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditProductPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnProductDetails = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtButtonText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLeftLeft = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnDownDown = new System.Windows.Forms.Button();
            this.btnUpUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnRightRight = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnProductDetails);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(302, 144);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 46);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(204, 90);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 46);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnProductDetails
            // 
            this.btnProductDetails.Location = new System.Drawing.Point(110, 90);
            this.btnProductDetails.Name = "btnProductDetails";
            this.btnProductDetails.Size = new System.Drawing.Size(75, 46);
            this.btnProductDetails.TabIndex = 1;
            this.btnProductDetails.Text = "Details";
            this.btnProductDetails.UseVisualStyleBackColor = true;
            this.btnProductDetails.Click += new System.EventHandler(this.btnProductDetails_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.42036F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.57964F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProductName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtButtonText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(100, 3);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(189, 26);
            this.txtProductName.TabIndex = 1;
            // 
            // txtButtonText
            // 
            this.txtButtonText.Location = new System.Drawing.Point(100, 34);
            this.txtButtonText.Name = "txtButtonText";
            this.txtButtonText.Size = new System.Drawing.Size(189, 26);
            this.txtButtonText.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Button text:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnLeftLeft, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnLeft, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnUp, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDown, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnDownDown, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnUpUp, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRight, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnRightRight, 4, 2);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 149);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(302, 289);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnLeftLeft
            // 
            this.btnLeftLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftLeft.Location = new System.Drawing.Point(3, 117);
            this.btnLeftLeft.Name = "btnLeftLeft";
            this.btnLeftLeft.Size = new System.Drawing.Size(54, 51);
            this.btnLeftLeft.TabIndex = 0;
            this.btnLeftLeft.Text = "<<";
            this.btnLeftLeft.UseVisualStyleBackColor = true;
            this.btnLeftLeft.Click += new System.EventHandler(this.btnLeftLeft_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeft.Location = new System.Drawing.Point(63, 117);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(54, 51);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(123, 60);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(54, 51);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDown.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(123, 174);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(54, 51);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDownDown
            // 
            this.btnDownDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownDown.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDownDown.Image")));
            this.btnDownDown.Location = new System.Drawing.Point(123, 231);
            this.btnDownDown.Name = "btnDownDown";
            this.btnDownDown.Size = new System.Drawing.Size(54, 55);
            this.btnDownDown.TabIndex = 4;
            this.btnDownDown.UseVisualStyleBackColor = true;
            this.btnDownDown.Click += new System.EventHandler(this.btnDownDown_Click);
            // 
            // btnUpUp
            // 
            this.btnUpUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUpUp.Image")));
            this.btnUpUp.Location = new System.Drawing.Point(123, 3);
            this.btnUpUp.Name = "btnUpUp";
            this.btnUpUp.Size = new System.Drawing.Size(54, 51);
            this.btnUpUp.TabIndex = 5;
            this.btnUpUp.UseVisualStyleBackColor = true;
            this.btnUpUp.Click += new System.EventHandler(this.btnUpUp_Click);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRight.Location = new System.Drawing.Point(183, 117);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(54, 51);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnRightRight
            // 
            this.btnRightRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightRight.Location = new System.Drawing.Point(243, 117);
            this.btnRightRight.Name = "btnRightRight";
            this.btnRightRight.Size = new System.Drawing.Size(56, 51);
            this.btnRightRight.TabIndex = 7;
            this.btnRightRight.Text = ">>";
            this.btnRightRight.UseVisualStyleBackColor = true;
            this.btnRightRight.Click += new System.EventHandler(this.btnRightRight_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(225, 443);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 46);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmEditProductPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 492);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditProductPanel";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtButtonText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProductDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnLeftLeft;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnDownDown;
        private System.Windows.Forms.Button btnUpUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnRightRight;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
    }
}