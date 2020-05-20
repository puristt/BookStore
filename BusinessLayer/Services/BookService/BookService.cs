using DataAccessLayer.DatabaseManager;
using DataAccessLayer.Repository.BookRepository;
using Entities.DataModels;
using Entities.WebViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDapperRepository<Book> _dapperRepository;

        public BookService(IBookRepository bookRepository, IDapperRepository<Book> dapperRepository)
        {
            _bookRepository = bookRepository;
            _dapperRepository = dapperRepository;
        }

        public BookListModel GetQuickViewById(int id)
        {
            
            return GetBookListForShopPage().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<BookListModel> GetBookListForShopPage()
        {

            return _bookRepository.GetBookList();
        }

        public IEnumerable<BookListModel> GetBookListForShopPageByCategoryId(int id)
        {
            return _bookRepository.GetBookListByCategoryId(id);
        }

        public BookDetailModel GetBookDetail(int id)
        {
            var parameters = new { Id = id };
            return _dapperRepository.LoadData<BookDetailModel>("spGetBookDetail", parameters).FirstOrDefault();
        }
    }
}
