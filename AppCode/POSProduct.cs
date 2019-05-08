using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Bliss_POS.AppCode
{
    public class POSProduct
    {
        #region Protected Properties

        protected int _productId;
        protected string _productName;
        protected string _buttonText;
        protected string _description;
        protected int _categoryId;
        protected string _categoryName;
        protected int _sectionId;
        protected string _sectionName;
        protected string _code;
        protected bool _visible;
        protected int _supplierId;
        protected string _supplierName;
        protected int _x;
        protected int _y;
        protected bool _selected;


        #endregion

        #region Public Properties
        [Browsable(false)]
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public virtual bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public virtual string Product
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [Browsable(false)]
        public string ButtonText
        {
            get
            {
                if (_buttonText == null)
                {
                    _buttonText = DataHelper.GetButtonText(_productId);

                }
                if (_buttonText.Equals(string.Empty))
                {
                    return _productName;
                }
                return _buttonText;
            }
            set { _buttonText = value; }
        }

        [Browsable(false)]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Browsable(false)]
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public virtual string Section
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        public virtual string Category
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
            set { _categoryName = value; }
        }

        [Browsable(false)]
        public string Code
        {
            get
            {
                if (_code == null)
                {
                    return string.Empty;
                }
                else
                {
                    return _code;
                }
            }
            set { _code = value; }
        }

        [Browsable(false)]
        public int SectionId
        {
            get
            {
                if (_sectionId == 0 && _productId > 0)
                {
                    //get value from database
                    return DataHelper.GetSid(_productId);
                }
                else
                {
                    return _sectionId;
                }
            }
            set { _sectionId = value; }
        }


        public virtual bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        [Browsable(false)]
        public int SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }

        [Browsable(false)]
        public virtual string Supplier
        {
            get { return _supplierName; }
            set
            {
                _supplierName = value;
                _supplierId = DataHelper.GetSuid(_supplierName);
            }
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

        #endregion

        public POSProduct()
        {
            _productId = -1;
            _productName = string.Empty;
            _buttonText = string.Empty;
            _description = string.Empty;
            _sectionId = DataHelper.GetFirstSection();
            _sectionName = DataHelper.GetSectionName(_sectionId);
            _categoryId = DataHelper.GetFirstCategory(_sectionId);
            _categoryName = DataHelper.GetCategoryName(_categoryId);
            _code = string.Empty;
            _visible = true;
            _supplierId = 0;
            _supplierName = string.Empty;
            _x = 0;
            _y = 0;
            _selected = false;
        }

        public POSProduct(
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
        {
            _productId = pid;
            _productName = pname;
            _buttonText = buttonText;
            if (_buttonText.Equals(string.Empty))
            {
                _buttonText = _productName;
            }
            _description = description;
            _categoryId = cid;
            _code = code;
            _visible = visible;
            _supplierId = suid;
            _x = x;
            _y = y;
            _selected = false;
        }

        public POSProduct(
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
        {
            _productId = pid;
            _productName = pname;
            _buttonText = buttonText;
            if (_buttonText.Equals(string.Empty))
            {
                _buttonText = _productName;
            }
            _description = description;
            _categoryId = cid;
            _categoryName = cname;
            _sectionId = sid;
            _sectionName = sname;
            _code = code;
            _visible = visible;
            _supplierId = suid;
            _supplierName = suName;
            _x = x;
            _y = y;
            _selected = false;
        }

        
    }
}
