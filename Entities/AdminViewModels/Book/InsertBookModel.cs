using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminViewModels.Book
{
    public class InsertBookModel
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
        public string[] CategoryIds { get; set; }
        
    }
}
