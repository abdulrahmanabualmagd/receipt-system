using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    internal class Product
    {
        private int _id;
        private string _name;

        #region Properties
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        #endregion

        #region Constructor
        public Product() : this(0,"N/A") { }

        public Product(int id, string name)
        {
            this._id = id;
            this._name = name;
        }
        
        #endregion

        

    }
}
