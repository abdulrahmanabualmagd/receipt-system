using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FluentAPI.Models
{
    internal class School
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
