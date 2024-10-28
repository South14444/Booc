using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booc.Models
{
    public class Trilogies
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Bookstore>? bookstores { get; set; }
        public override string ToString()
        {
            return $"{Name} ";
        }
    }
}
