using System.Security.Principal;

namespace Core.Models
{
    public class Student : Entity
    {
        public double GPA { get; set; } 

        #region Navigation Property
        public int SchoolId { get; set; }
        public virtual School? School { get; set; } 
        #endregion
    }
}
