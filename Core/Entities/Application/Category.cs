using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Application
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Item
        public ICollection<Item> Items { get; set; } = new List<Item>();
        #endregion
    }
}
