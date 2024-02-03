using Core.Entities.BaseEntity;
using Core.Entities.UserIdentity;

namespace Core.Entities
{
    public class School : Entity
    {
        public Guid UserIdentifier { get; set; }

        #region Department
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();      // Navigation Property 
        #endregion

    }
}
