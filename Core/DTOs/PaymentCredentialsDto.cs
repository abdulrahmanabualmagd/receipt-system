using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PaymentCredentialsDto
    {
        public int ReceiptId { get; set; }
        public decimal Amount { get; set; }
    }
}
