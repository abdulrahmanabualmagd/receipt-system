using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency
{
    public class A
    {

    }

    public class B
    {
        // Depend on Class a (Temporarily)
        public void method(A a)
        {

        }
    }
}
