using DataAccessLayer.DatabaseManager;
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
    public class BookRepository : IBookRepository
    {
        private readonly IDapperRepository<Book> _repository;

        public BookRepository(IDapperRepository<Book> repository)
        {
            _repository = repository;
        }

        public int CountByAuthorId(int authorId)
        {
            var parameters = new { AuthorId = authorId };
            return _repository.Count(parameters);
        }

        public int CountByCategoryId(int categoryId)
        {
            var parameters = new { CategoryId = categoryId };
            return _repository.Count("spBookCountByCategoryId", parameters);
        }

        public int CountByPublisherId(int publisherId)
        {
            var parameters = new { PublisherId = publisherId };
            return _repository.Count(parameters);
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public InsertBookModel GetById(int id)
        {
            var parameters = new { Id = id };
            return _repository.LoadData<InsertBookModel>("spGetBook", parameters).FirstOrDefault();
        }

        public Book GetByISBN13(string isbn13)
        {
            var parameters = new { ISBN13 = isbn13 };
            return _repository.LoadData("spGetBookByISBN", parameters).FirstOrDefault();
        }

        public BookListModel GetQuickViewById(int id)
        {
            var parameters = new { Id = id };
            return _repository.LoadData<BookListModel>("spGetBookQuickViewById", parameters).FirstOrDefault();
            //return _repository.FindById(id);
        }

        public int Save(Book entity)
        {
            int result;
            var parameters = new
            {
                entity.Title,
                entity.Description,
                entity.PublicationDate,
                entity.Price,
                entity.ISBN13,
                entity.Page,
                entity.PublisherId,
                entity.AuthorId,
                entity.Stock
            };

            if (entity.Id == default)
            {
                result = _repository.SaveDataWithReturnId("spInsertBook", parameters);
            }
            else
            {
                result = 2;
            }


            return result;
        }

        public int SaveBookCategories(string categoryIds, int bookId)
        {
            var parameters = new { CategoryIds = categoryIds, BookId = bookId };
            return _repository.SaveData<int>("spInsertBookCategories",parameters);
        }
    }
}
