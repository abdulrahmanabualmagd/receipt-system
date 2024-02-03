using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ManytoMany
{
    public class Courses_Teachers
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int TeacherId { get; set;}
        public virtual Teacher Teacher { get; set; }
    }
}
