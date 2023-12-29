using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public sealed class SingletonClass  // Sealed to avoid creating multiple objects through inheritance 
    {


        private static SingletonClass? instance;

        private SingletonClass(){}      // private constructor

        public static SingletonClass Instnance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonClass();
                }
                return instance;
            }
        }

    }
}
