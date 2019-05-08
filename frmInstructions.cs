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
    public partial class frmInstructions : Form
    {
        private List<POSInstruction> _instructions;

        public frmInstructions()
        {
            InitializeComponent();
            _instructions = DataHelper.GetInstructionsGeneral();
            dgInstructions.DataSource = _instructions;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            POSInstruction i = new POSInstruction(-1, string.Empty);
            _instructions.Add(i);
            dgInstructions.DataSource = null;
            dgInstructions.DataSource = _instructions;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                POSInstruction i = dgInstructions.SelectedRows[0].DataBoundItem as POSInstruction;
                if (i.InstructionId != -1)
                {
                    DataHelper.DeleteInstruction(i.InstructionId);
                }
                _instructions.Remove(i);
                dgInstructions.DataSource = null;
                dgInstructions.DataSource = _instructions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataHelper.SaveInstructions(_instructions);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
