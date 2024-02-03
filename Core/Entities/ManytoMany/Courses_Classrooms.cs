using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ManytoMany
{
    public class Courses_Classrooms
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
