using Entities.DataModels;
using Entities.WebViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.BookRepository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        BookListModel GetQuickViewById(int id);
        //IEnumerable<BookListModel> GetBookList(int page, int pageSize);
        int CountByPublisherId(int publisherId);
        int CountByAuthorId(int authorId);
        int CountByCategoryId(int categoryId);
    }
}
