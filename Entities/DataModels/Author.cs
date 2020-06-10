using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }
        public string Description { get; set; }

        //public List<Book> Books { get; set; } // Book Table

   
    }
}
