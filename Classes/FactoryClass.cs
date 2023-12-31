using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class FactoryClass
    {

        public static ChildClass CreateChild(string model)
        {
            // logics to create car 
            return new ChildClass(model);
             
        }

    }
}
