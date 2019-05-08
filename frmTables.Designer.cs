namespace Bliss_POS
{
    partial class frmTables
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbRooms = new System.Windows.Forms.TabControl();
            this.tbRooms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1276, 734);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbRooms
            // 
            this.tbRooms.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbRooms.Controls.Add(this.tabPage2);
            this.tbRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRooms.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRooms.Location = new System.Drawing.Point(0, 0);
            this.tbRooms.Name = "tbRooms";
            this.tbRooms.Padding = new System.Drawing.Point(10, 20);
            this.tbRooms.SelectedIndex = 0;
            this.tbRooms.Size = new System.Drawing.Size(1284, 804);
            this.tbRooms.TabIndex = 0;
            // 
            // frmTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 804);
            this.ControlBox = false;
            this.Controls.Add(this.tbRooms);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTables";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbRooms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tbRooms;



    }
}