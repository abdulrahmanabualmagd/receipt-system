using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    public class A
    {

    }

    // Class A is involved within class B and Class B depend on Class A unlike Aggregation
    public class B 
    {
        A comp_a = new A();
    }

}
