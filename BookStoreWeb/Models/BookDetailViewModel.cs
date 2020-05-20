using Entities.DataModels;
using Entities.WebViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Models
{
    public class BookDetailViewModel
    {
        public BookDetailViewModel()
        {
            BookReviews = new List<Review>();
            BookImages = new List<BookImage>();
            Book = new BookDetailModel();
        }
        public BookDetailModel Book { get; set; }
        public IEnumerable<Review> BookReviews { get; set; }
        public IEnumerable<BookImage> BookImages { get; set; }
        public IEnumerable<Category> RelatedCategories { get; set; }

    }
}