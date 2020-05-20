using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public bool IsApproval { get; set; } = false; //Yorumun uygun olup olmadığını kontrol etmek için
        public DateTime CreatedAt { get; set; }

        //public Book Book { get; set; } // Book Table
        //public User Owner { get; set; } // User Table
    }
}
