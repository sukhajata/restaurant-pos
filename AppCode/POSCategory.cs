using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    class POSCategory
    {
        public int CategoryId { get; set; }
        public int SectionId { get; set; }
        public string CategoryName { get; set; }
        public string ForeColour { get; set; }
        public string BackColour { get; set; }
        public bool Updated { get; set; }
        public int GroupId { get; set; }

        public static string defaultBackColour = "255,255,255,0";
        public static string defaultForeColour = "255,0,0,0";

        public POSCategory(int cid, int sid, string cname, string backcol, 
            string forecol, int gid)
        {
            CategoryId = cid;
            SectionId = sid;
            CategoryName = cname;
            BackColour = backcol;
            ForeColour = forecol;
            Updated = false;
            GroupId = gid;
        }

        public POSCategory(int cid, int sid, string cname, string backcol,
            string forecol)
        {
            CategoryId = cid;
            SectionId = sid;
            CategoryName = cname;
            BackColour = backcol;
            ForeColour = forecol;
            Updated = false;
            GroupId = DataHelper.GetFirstGroupId();
        }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
