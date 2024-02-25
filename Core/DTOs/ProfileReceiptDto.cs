using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ProfileReceiptDto
    {
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime ReleasedDate { get; set; }

    }
}
