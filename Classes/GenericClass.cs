using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class GenericClass<T> // Contains non generic and generic members
    {
        public T? id;
        public T? Content { get; set; }

        public void print(){}

        public void show<Y>(Y data) { /* Do something with the passed data*/ }
    }
}
