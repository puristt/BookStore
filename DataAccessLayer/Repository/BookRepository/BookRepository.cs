﻿using DataAccessLayer.DatabaseManager;
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

        public IEnumerable<BookListModel> GetBookList()
        {
            return _repository.LoadData<BookListModel>("spGetAllBooksForShopList");
        }

        public IEnumerable<BookListModel> GetBookListByCategoryId(int id)
        {
            var parameters = new { CategoryId = id };
            return _repository.LoadData<BookListModel>("spGetAllBooksForShopListByCategoryId", parameters);
        }

        public Book GetQuickViewById(int id)
        {
            var parameters = new { Id = id };
            return _repository.LoadData("spGetBookQuickViewById", parameters).FirstOrDefault();
            //return _repository.FindById(id);
        }
    }
}
