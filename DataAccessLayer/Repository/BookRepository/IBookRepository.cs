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
        Book GetQuickViewById(int id);
        IEnumerable<BookListModel> GetBookList();
        IEnumerable<BookListModel> GetBookListByCategoryId(int id);
    }
}
