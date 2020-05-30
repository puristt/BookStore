using Entities.AdminViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAdmin.Models
{
    public class BookResultViewModel
    {
        public BookResultViewModel()
        {
            SearchModel = new SearchModel();
            Books = new List<FilteredBookListModel>();
            FilterValues = new BookFilterModel();
        }
        /// <summary>
        /// Seçilen filtre değerlerini tutacak ve veritabanına gönderilecek olan property
        /// </summary>
        public SearchModel SearchModel { get; set; }

        /// <summary>
        /// Filtre satırlarının içindeki verileri dolduracak property
        /// </summary>
        public BookFilterModel FilterValues { get; set; }
        /// <summary>
        /// Partial view içinde listelenecek kitaplar
        /// </summary>
        public IEnumerable<FilteredBookListModel> Books { get; set; }

    }
}