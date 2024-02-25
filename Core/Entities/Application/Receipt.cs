using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Application
{
    public class Receipt
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public DateTime ReleasedDate { get; set; } = DateTime.Now;

        #region Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        #endregion

        #region Payment
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        #endregion

        #region Item
        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
        #endregion
    }
}
