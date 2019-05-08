using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSProductSearchResult : POSProduct
    {
        [Browsable(false)]
        public override bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public override string Product
        {
            get { return _productName; }
        }

        [Browsable(true)]
        public override string Supplier
        {
            get { return _supplierName; }
        }

        public override string Section
        {
            get { return _sectionName; }
        }

        public override string Category
        {
            get
            {
                if (_categoryName.Equals(string.Empty))
                {
                    return DataHelper.GetCategoryName(_categoryId);
                }
                else
                {
                    return _categoryName;
                }
            }
        }

         public override bool Visible
        {
            get { return _visible; }
        }

        public POSProductSearchResult()
            : base()
        { }

        public POSProductSearchResult(
            int pid,
            string pname,
            string buttonText,
            string description,
            int cid,
            string code,
            bool visible,
            int suid,
            int x,
            int y
            )
            : base(pid, pname, buttonText, description, cid, code, visible,
                suid, x, y) { }

        public POSProductSearchResult(
          int pid,
          string pname,
          string buttonText,
          string description,
          int cid,
          string cname,
          int sid,
          string sname,
          string code,
          bool visible,
          int suid,
          string suName,
          int x,
          int y
          )
            : base(pid, pname, buttonText, description, cid, cname, sid, sname,
            code, visible, suid, suName, x, y) { }

        public POSProduct ConvertToPOSProduct()
        {
            POSProduct prod = new POSProduct(_productId, _productName, _buttonText,
                _description, _categoryId, _categoryName, _sectionId, _sectionName,
                _code, _visible, _supplierId, _supplierName, _x, _y);
            return prod;
        }


    }
}
