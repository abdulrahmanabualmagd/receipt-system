using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntity;

namespace Core.Entities
{
    public class Classroom : Entity
    {

        #region Courses
        public int CourseId { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        #endregion

    }
}
