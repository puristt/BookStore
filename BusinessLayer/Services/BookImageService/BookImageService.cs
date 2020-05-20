using DataAccessLayer.Repository.BookImageRepository;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.BookImageService
{
    public class BookImageService : IBookImageService
    {
        private readonly IBookImageRepository _bookImageRepository;
        public BookImageService(IBookImageRepository bookImageRepository)
        {
            _bookImageRepository = bookImageRepository;
        }
        public IEnumerable<BookImage> GetImagesForBook(int bookId)
        {
            return _bookImageRepository.GetBookImages(bookId);
        }
    }
}
