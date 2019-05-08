namespace Bliss_POS
{
    partial class frmEditTables
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
            this.tbRooms = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbRooms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRooms
            // 
            this.tbRooms.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbRooms.Controls.Add(this.tabPage2);
            this.tbRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRooms.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRooms.ItemSize = new System.Drawing.Size(150, 60);
            this.tbRooms.Location = new System.Drawing.Point(0, 0);
            this.tbRooms.Name = "tbRooms";
            this.tbRooms.Padding = new System.Drawing.Point(20, 3);
            this.tbRooms.SelectedIndex = 0;
            this.tbRooms.Size = new System.Drawing.Size(843, 758);
            this.tbRooms.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(835, 690);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmEditTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(843, 758);
            this.ControlBox = false;
            this.Controls.Add(this.tbRooms);
            this.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmEditTables";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbRooms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbRooms;
        private System.Windows.Forms.TabPage tabPage2;

    }
}