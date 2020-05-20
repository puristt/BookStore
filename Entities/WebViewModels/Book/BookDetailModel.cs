using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.WebViewModels.Book
{
    public class BookDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN13 { get; set; }
        public int Page { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Stock { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int PublisherId { get; set; }
        public string Publisher { get; set; }

    }
}
