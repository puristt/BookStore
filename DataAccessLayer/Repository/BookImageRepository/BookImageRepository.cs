using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.BookImageRepository
{
    public class BookImageRepository : IBookImageRepository
    {
        private readonly IDapperRepository<BookImage> _repository;
        public BookImageRepository(IDapperRepository<BookImage> bookImageRepository)
        {
            _repository = bookImageRepository;
        }
        public IEnumerable<BookImage> GetBookImages(int id)
        {
            var parameters = new { BookId = id };
            return _repository.LoadData("spGetBookImages", parameters);
        }
    }
}
