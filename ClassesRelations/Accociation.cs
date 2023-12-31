using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accociation
{
    public class A
    {
        B b;
    }

    public class B
    {
        // bi-directional relation represents one/many-to-one/many
        List<A> a;
    }
}
