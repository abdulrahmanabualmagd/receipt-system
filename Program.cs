using System.ComponentModel;

namespace ObserverDesignPattern
{
    class Program
    {
        static void Main(string[] arg)
        {
            #region Creat company and Supplier
            // Create an instance of the company (Publisher)
            Company company = new Company(25, "TDO");

            // Create a Listener for that company (Observer)
            Supplier supplier = new Supplier(company); 
            #endregion

            #region Add Products to the company
            // Creating Products
            Product p1 = new Product(1, "A");
            Product p2 = new Product(2, "B");
            Product p3 = new Product(3, "C");
            Product p4 = new Product(4, "D");

            // Add Created products to the company's Products
            company.products.Add(p1, 5);
            company.products.Add(p2, 5);
            company.products.Add(p3, 5);
            company.products.Add(p4, 5);
            #endregion

            #region Sell Products from the company
            company.Sell(p1, 2);
            #endregion

            // ensures that the company filled the data above 
            company.show();





        }
    }
}