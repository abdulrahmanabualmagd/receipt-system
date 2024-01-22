using System.Security.Principal;

namespace Core.Models
{
    public class Student : Entity
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
