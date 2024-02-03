using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntity;
using Core.Entities.UserIdentity;

namespace Core.Entities
{
    public class Teacher : Entity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public Guid UserIdentifier { get; set; }


        #region Courses
        public int CourseId { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        #endregion

    }

}
