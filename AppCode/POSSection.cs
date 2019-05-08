using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    public class POSSection
    {
        private int _sectionId;
        private string _sectionName;
        private string _description;
        private bool _visible;
        private int _sortOrder;

        public int SectionId
        {
            get { return _sectionId; }
        }
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        public int SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }
        
        public POSSection(int sid, string sname, string sdescription, bool visible, 
            int sortOrder)
        {
            _sectionId = sid;
            _sectionName = sname;
            _description = sdescription;
            _visible = visible;
            _sortOrder = sortOrder;
        }

        public override string ToString()
        {
            return _sectionName;
        }


    }
}
