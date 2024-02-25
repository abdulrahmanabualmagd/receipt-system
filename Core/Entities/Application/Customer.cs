using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Application
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "N/A";
        public int Balance { get; set; } = 0;
        public string Phone { get; set; } = "N/A";
        public string UserId { get; set; } = "N/A";

        #region Receipt
        public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
        #endregion

    }
}
