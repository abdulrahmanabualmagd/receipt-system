using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ImmutableClass     // Whose instances can't be modified
    {
        public int X { get; }
        public int Y { get; }
        public ImmutableClass(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
