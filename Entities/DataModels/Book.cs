using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public string ISBN13 { get; set; }
        public string Page { get; set; }
        public int Stock { get; set; }
        public DateTime InsertedAt { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public List<BookImage> BookImages { get; set; }
        public Publisher Publisher { get; set; } // Publisher Table
        public Author Author { get; set; } // Author Table
        public Category Category { get; set; } // Category Table
        public List<Review> Reviews { get; set; } // Review Table
        public List<Book> FavoriteBooks { get; set; } // UserFavoriteTable(many to many table)

    }
}
