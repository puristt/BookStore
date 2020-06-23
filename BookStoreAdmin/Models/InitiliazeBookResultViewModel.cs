using BookStoreAdmin.Models.Pagination;
using Entities.AdminViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAdmin.Models
{
    public class InitiliazeBookResultViewModel
    {
        public InitiliazeBookResultViewModel()
        {
            SearchModel = new SearchModel();
            FilterValues = new BookRelatedDropDownListModel();
            PagedList = new PagedListModel<FilteredBookListModel>();
        }
        /// <summary>
        /// Seçilen filtre değerlerini tutacak ve veritabanına gönderilecek olan property
        /// </summary>
        public SearchModel SearchModel { get; set; }

        /// <summary>
        /// Filtre satırlarının içindeki verileri dolduracak property
        /// </summary>
        public BookRelatedDropDownListModel FilterValues { get; set; }

        public PagedListModel<FilteredBookListModel> PagedList { get; set; }

    }
}