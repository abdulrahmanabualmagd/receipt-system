using Core.Entities.BaseEntity;

namespace Core.Entities
{
    public class Department : Entity
    {



        #region School
        public int SchoolId { get; set; }          
        public virtual School School { get; set; }
        #endregion

        #region Students
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();   
        #endregion

        #region Courses
        public int CourseId { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        #endregion

    }
}
