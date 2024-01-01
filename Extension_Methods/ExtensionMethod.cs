using Constructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods
{
    internal static class ExtensionMethod
    {
        // An Extension Method for Person Class
        internal static void Show(this Person data)
        {
            Console.WriteLine($"{data.Id} - {data.Name}");
        }
    }
}
