using Entities.AdminViewModels.Book;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAdmin.Models
{
    public class InsertBookViewModel
    {
        public InsertBookViewModel()
        {
            Book = new InsertBookModel();
            BookCategories = new List<Category>();
            Images = new List<BookImage>();
        }
        public InsertBookModel Book { get; set; }
        public SelectList PublisherList { get; set; }
        public SelectList AuthorList { get; set; }
        public MultiSelectList CategoryList { get; set; }
        public IEnumerable<BookImage> Images { get; set; }
        public IEnumerable<Category> BookCategories { get; set; }


    }
}