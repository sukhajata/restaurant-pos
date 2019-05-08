using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSOrderDetailInstruction
    {
        private int _id;
        private int _odid;
        private int _iid;
        private string _iname;

        private int Id
        {
            get { return _id; }
        }
        private int OrderDetailId
        {
            get { return _odid; }
            set { _odid = value; }
        }
        private int InstructionId
        {
            get { return _iid; }
            set { _iid = value; }
        }
        private string Instruction
        {
            get { return _iname; }
            set { _iname = value; }
        }

        public POSOrderDetailInstruction(int id, int odid, int iid, string iname)
        {
            _id = id;
            _odid = odid;
            _iid = iid;
            _iname = iname;
        }


    }
}
