using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    public class Product
    {
        #region Private
        private int _id;
        private string _name; 
        #endregion

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

        // Default Constructor 
        public Product() : this(0,"N/A") { }

        // Parameterized Constructor
        public Product(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        // Deep Copy Constructor
        public Product (Product product) : this(product._id, product._name){}

        // Shallow Copy Constructor
        public Product Shallow(Product product)
        {
            return product;
        }
       
        #endregion
    }
}
