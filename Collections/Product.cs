using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Product
    {
        #region Private
        private int _id;
        private string _name;
        #endregion

        #region Property
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Ctor
        public Product():this(0, "N/A") { }
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }
        #endregion
    }
}
