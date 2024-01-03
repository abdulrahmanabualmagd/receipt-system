using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    internal class Student
    {
        #region Properties
        public int? Id { get; set; }
        public string? Name { get; set; }
        #endregion

        #region Navigation Propeties

        #region Schools
        public int SchoolId { get; set; }
        public School? School { get; set; } 
        #endregion

        #endregion
    }
}
