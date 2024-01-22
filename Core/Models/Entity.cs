using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Entity       // Used as a constraint for generic types. Means that any class must contain these properties in this class
    {
        public int Id { get; set; }
    }
}
