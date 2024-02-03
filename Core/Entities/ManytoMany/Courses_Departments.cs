using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ManytoMany
{
    public class Courses_Departments
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
