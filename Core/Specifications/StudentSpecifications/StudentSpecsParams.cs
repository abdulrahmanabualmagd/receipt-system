using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.StudentSpecifications
{
    public class StudentSpecsParams
    {
        public string? Sort { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public int pageSize { get; set; } = 5;
        public int PageIndx { get; set; } = 1;
    }
}
