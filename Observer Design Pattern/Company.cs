/*
 * Company (Publisher)
 * Members: private (id, name) | ctor (default, parameterized) | Subscription Delegate (Action<Company, Product, int>) | Methods (Buy, Sell, Show)
 * Subscription: A delegate that listeners use to subscribe to this company.
 * NotifySupplier(subscriber): Contains three parameters (company, product, int) to identify the company being listened to, the product to refill, and the quantity.
 * Sell Method: Used to sell products from this company.
 * Buy Method: Used by the supplier to fill this company with products when it runs out.
 * Show method: Displays the current quantities of products for this company.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    internal class Company
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
        public Company() : this(0, "N/A") { }

        public Company(int id, string name)
        {
            this._id = id;
            this._name = name;
        }
        #endregion

        // Caompany Products
        #region Products
        public Dictionary<Product, int> products = new Dictionary<Product, int>();
        #endregion

        // Subscription Delegate
        #region Subscription
        // Should be public to let the listener able to subscribe
        public Action<Company, Product, int> NotifySupplier;
        #endregion

        // Buy & Sell Methods
        #region Methods
        // Listener use this method to Suppply the company through the delegate subscription
        public void Buy(Product product, int quantity = 5)
        {
            //check if the product exist so we add the quantity without adding new product 
            if (products.ContainsKey(product))
            {
                products[product] += quantity;
            }
            // If the product not exist, we add new one to the company products list
            else
            {
                products.Add(product, quantity);
            }
        }

        // Sell method. Note the Suppliers when products run out
        public void Sell (Product product, int quantity)
        {
            // Check if the product exist
            if (products.ContainsKey(product))
            {
                #region Products amount check
                // Check if the products amount is enough to execute the order
                if (products[product] >= quantity)
                {
                    products[product] -= quantity;
                }
                else
                {
                    // In case the products is small than the amount needed

                    // First, call Supplier to refill
                    Console.WriteLine("Calling Supplier...");
                    Console.Beep();
                    NotifySupplier(this, product, quantity);

                    // Second, continue the selling process
                    products[product] -= quantity;
                } 
                #endregion
            }
            else
            {

                Console.WriteLine("Calling Supplier...");
                Console.Beep();
                NotifySupplier(this, product, quantity);
            }

            // Refill if the products amount become under 7 products
            if (products[product] < 7)
            {
                // We can change the quantity to put a standard amount to refill
                Console.WriteLine("Calling Supplier...");
                Console.Beep();
                NotifySupplier(this, product, 5);
            }
            
        }


        // Show the amounts of the products in the company
        public void show()
        {
            foreach (Product product in products.Keys)
            {
                Console.WriteLine($"{product.Name} => {products[product]}");
            }
        }
        #endregion



    }

}
