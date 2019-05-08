using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS
{
    public partial class frmEditInstructionPanel : Form
    {
        private POSInstruction _instruction;
        private frmMainEdit _parent;
        private Button _instructionButton;

        public frmEditInstructionPanel(Button btn, frmMainEdit parent)
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.Location = new Point(r.Width - this.Width, 35);
            this.TopMost = true;
            _instruction = (POSInstruction)btn.Tag;
            _parent = parent;
            _instructionButton = btn;
            txtInstruction.Text = _instruction.Instruction;
        }

        private void btnUpUp_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, 0, -8 * Global.GridSpacing);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, 0, -1 * Global.GridSpacing);                
            
        }

        private void btnLeftLeft_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, -8 * Global.GridSpacing , 0);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, -1 * Global.GridSpacing, 0);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, 0, Global.GridSpacing);
        }

        private void btnDownDown_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, 0, 8 * Global.GridSpacing);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, Global.GridSpacing, 0);
        }

        private void btnRightRight_Click(object sender, EventArgs e)
        {
            _parent.MoveButton(_instructionButton, 8 * Global.GridSpacing, 0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataHelper.DeleteInstruction(_instruction.InstructionId);
            _parent.BuildSection(_parent.CurrentSection, _parent.SelectedTab);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _instruction.Instruction = txtInstruction.Text;
            DataHelper.SaveInstruction(_instruction);
            _parent.BuildSection(_parent.CurrentSection, _parent.SelectedTab);
            this.Close();
        }

    }
}
