using Entities.AdminViewModels.Book;
using Entities.DataModels;
using Entities.WebViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.BookService
{
    public interface IBookService
    {
        IEnumerable<BookListModel> GetBookListForShopPage();
        IEnumerable<BookListModel> GetBookListForShopPageByCategoryId(int id);
        BookListModel GetQuickViewById(int id);
        BookDetailModel GetBookDetail(int id);
        IEnumerable<FilteredBookListModel> GetFilteredBookList(SearchModel searchModel, int pageNumber, int pageSize, out int totalItemCount);
    }
}
