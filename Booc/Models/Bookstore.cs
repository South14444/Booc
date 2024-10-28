using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booc.Models
{
    public class Bookstore
    {
        public int Id { get; set; }
        public string NameBook { get; set; } = null!;
        public Author author { get; set; } = null!;
        public int authorId { get; set; }
        public Publishers publishers { get; set; } = null!;
        public int publishersId { get; set; }
        public int Number_of_pages { get; set; }    
        public Genre genre { get; set; } = null!;
        public int genreId { get; set; }
        public DateTime DateTime { get; set; }
        public int Cost_price { get; set; }
        public int Price_for_sale { get; set; }
        public Trilogies? trilogies { get; set; }
        public int? TrilogiesId {  get; set; }

    }
}
