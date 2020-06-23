using BusinessLayer.ErrorHelper;
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
        #region AdminPartService
        IEnumerable<FilteredBookListModel> GetFilteredBookList(SearchModel searchModel, int pageNumber, int pageSize, out int totalItemCount);
        GenericResults<InsertBookModel> SaveModel(InsertBookModel model, List<string> imageUrls);
        InsertBookModel GetBookById(int id);
        #endregion


        #region UserPartService
        IEnumerable<BookListModel> GetBookListForShopPage(int page, int pageSize, string sortBy, out int totalItemCount);
        IEnumerable<BookListModel> GetBookListForShopPageByCategoryId(int id, int page, int pageSize,string sortBy, out int totalItemCount);
        IEnumerable<BookListModel> GetBookListForShopPageByPublisherId(int id, int page, int pageSize, string sortBy, out int totalItemCount);
        IEnumerable<BookListModel> GetBookListForShopPageByAuthorId(int id, int page, int pageSize, string sortBy, out int totalItemCount);
        BookListModel GetQuickViewById(int id);
        BookDetailModel GetBookDetail(int id);
        #endregion
    }
}
