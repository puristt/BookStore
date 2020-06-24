using Entities.AdminViewModels.Book;
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
        InsertBookModel GetById(int id);
        BookListModel GetQuickViewById(int id);
        IEnumerable<BookListModel> GetRelatedProducts(int categoryId);
        Book GetByISBN13(string ISBN);
        int Save(Book entity);
        int Delete(int id);
        int SaveBookCategories(string categoryIds, int bookId);
        int CountByPublisherId(int publisherId);
        int CountByAuthorId(int authorId);
        int CountByCategoryId(int categoryId);
    }
}
