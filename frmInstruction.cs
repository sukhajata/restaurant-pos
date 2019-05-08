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
    public partial class frmInstruction : Form
    {
        private POSInstruction _instruction;

        public frmInstruction(POSInstruction instruction)
        {
            InitializeComponent();
            CenterToScreen();
            _instruction = instruction;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtInstruction.Text.Equals(string.Empty))
            {
                _instruction.Instruction = txtInstruction.Text;
                DataHelper.SaveInstruction(_instruction);
            }
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_instruction.InstructionId > 0)
            {
                DataHelper.DeleteInstruction(_instruction.InstructionId);
            }
            this.Close();
        }
    }
}
