using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booc.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public Bookstore bookstore { get; set; }
        public int BookstoreId { get; set; }
        public int? Quantity { get; set; }
        public int? Discount { get; set; }
    }
}
