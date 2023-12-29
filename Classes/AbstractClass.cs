using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class AbstractClass // Can't be instantiated
    {

        public int Id;
        public abstract string name { get; set; }
        public abstract void Print();
        public void Show() {}
    }
}
