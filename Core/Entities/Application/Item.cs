using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Application
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
        [NotMapped]
        public int Quantity { get; set; } = 1;

        #region Receipt
        public ICollection<Receipt> Receipts { get; set; } =new List<Receipt>();
        #endregion

        #region Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

    }
}
