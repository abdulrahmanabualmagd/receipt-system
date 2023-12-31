using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregation
{
    public class A
    {

    }

    // Class B contain Class A as a member but not depent on it, unlike Composition
    public class B
    {
        A a;    
    }
}
