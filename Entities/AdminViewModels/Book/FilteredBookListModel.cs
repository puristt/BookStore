using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminViewModels.Book
{
    public class FilteredBookListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ISBN13 { get; set; }
        public string Categories { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PublicationDate { get; set; }
        public int TotalRows { get; set; }

    }
}
