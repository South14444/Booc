using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booc.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public ICollection<Bookstore>? Bookstore { get; set; }
        public override string ToString()
        {
            return $"{Name} {Surname} {Patronymic}";
        }
    }
}
