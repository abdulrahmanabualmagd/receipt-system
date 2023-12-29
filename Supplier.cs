/*
 * Supplier (Listener)
 * Members: private (id, name) | Constructors (default, parameterized, subscribing to a company) | Methods: (Supply)
 * Subscriber: Used to subscribe to the passed company as a parameter by a multicast delegate.
 * Supply Method: Calls the Buy method of the company to refill it with a specified quantity of the needed product.
 * Supply Method: Called when the company runs out of products.
 * When the company runs out, it notifies all subscribers (multicast delegate).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    internal class Supplier
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

        #region Ctor
        // Default Constructor
        public Supplier(): this(0, "N/A") { }     

        // Parameterized Constructor
        public Supplier(int id, string name)       
        {
            this._id = id;
            this._name = name;
        }
        #endregion

        // Subscripe the Supplier on creation using this overload
        #region Subscripe
        // Subscripe to Company when we pass the company as a parameter to the Constructor
        public Supplier(Company company) : this(0, "N/A")
        {
            // Supplier Subscript to the Publisher Subscription
            company.NotifySupplier += Supply;
        }
        #endregion

        // Supply the Company on call
        #region Methods
        public void Supply(Company company, Product product, int quantity)
        {
            company.Buy(product, quantity);
        }
        #endregion



    }
}
