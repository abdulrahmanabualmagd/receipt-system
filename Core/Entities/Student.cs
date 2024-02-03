using System.Security.Principal;
using Core.Entities.BaseEntity;
using Core.Entities.UserIdentity;

namespace Core.Entities
{
    public class Student : Entity
    {
        public double GPA { get; set; }
        public Guid UserIdentifier { get; set; }

        #region Department
        public int DepartmentId { get; set; }               // Foreign Key
        public virtual Department Department { get; set; }  // Navigation Property
        #endregion


    }
}
