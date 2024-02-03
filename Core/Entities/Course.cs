using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntity;

namespace Core.Entities
{
    public class Course : Entity
    {

        #region Departments
        //public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        #endregion

        #region Classrooms
        //public virtual ICollection<Classroom> Classrooms { get; set; } = new HashSet<Classroom>();
        #endregion

        #region Teachers
        //public virtual ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
        #endregion
    }
}
