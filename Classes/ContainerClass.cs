using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ContainerClass     // Holds and Manages a collections of other object 
    {
        private List<int> products = new List<int>();

        public void AddProduct(int product)
        {
            products.Add(product);
        }

    }
}
