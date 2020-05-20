using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class BookImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int BookId { get; set; }

        //public Book Book { get; set; } // Book Table (birden fazla resim olabileceği için ayrı bir table oluşturduk)
    }
}
