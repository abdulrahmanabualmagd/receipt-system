using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CheckDto
    {
        public decimal Value { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public bool IsValid { get; set; } = false;
    }
}
