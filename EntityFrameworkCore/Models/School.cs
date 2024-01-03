using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    internal class School
    {
        #region Properties
        public int? Id { get; set; }
        public string? Name { get; set; }
        #endregion

        #region Navigation Properties

        #region Student
        ICollection<Student>? Students { get; set; }
        #endregion

        #endregion
    }
}
