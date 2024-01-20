using System.Security.Principal;

namespace Infrastructure.Entities
{
    public class Student
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; } 
        #endregion

        #region Navigation Property
        public int SchoolId { get; set; }
        public virtual School? School { get; set; } 
        #endregion
    }
}
