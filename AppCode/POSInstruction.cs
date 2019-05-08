using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSInstruction
    {
        private int _iid;
        private string _iname;
        private int _pid;
        private int _sid;
        private int _x;
        private int _y;

        [Browsable(false)]
        public enum InstructionType { product, section }
        [Browsable(false)]
        public int InstructionId
        {
            get { return _iid; }
            set { _iid = value; }
        }
        public string Instruction
        {
            get { return _iname; }
            set
            {
                if (value.Length > 100) _iname = value.Substring(0, 100);
                else _iname = value;
            }
        }
        [Browsable(false)]
        public int ProductId
        {
            get { return _pid;  }
            set { _pid = value; }
        }
        [Browsable(false)]
        public int SectionId
        {
            get { return _sid; }
            set { _sid = value; }
        }
        [Browsable(false)]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        [Browsable(false)]
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public POSInstruction(int iid, string iname)
        {
            _iid = iid;
            _iname = iname;
            _pid = 0;
            _sid = 0;
            _x = 0;
            _y = 0;
        }

        public POSInstruction(int iid, string iname, int pid)
        {
            _iid = iid;
            _iname = iname;
            _pid = pid;
            _sid = 0;
            _x = 0;
            _y = 0;
        }

        public POSInstruction(int iid, string iname, int sid, int x, int y)
        {
            _iid = iid;
            _iname = iname;
            _pid = 0;
            _sid = sid;
            _x = x;
            _y = y;
        }

    }
}
