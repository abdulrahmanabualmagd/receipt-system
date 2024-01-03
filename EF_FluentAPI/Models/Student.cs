using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FluentAPI.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public int Id2 { get; set; }
        public string? Name { get; set; }


        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
