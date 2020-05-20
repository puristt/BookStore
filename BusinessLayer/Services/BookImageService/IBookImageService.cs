using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.BookImageService
{
    public interface IBookImageService
    {
        IEnumerable<BookImage> GetImagesForBook(int bookId);
    }
}
