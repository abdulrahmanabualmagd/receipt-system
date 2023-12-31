using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield_Return
{
    public static class Yield_Return
    {
        public static IEnumerable<int> GenerateNumber()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return i;             // lazily generate a sequence
            }
        }
    }
}
