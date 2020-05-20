using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.BookImageRepository
{
    public interface IBookImageRepository
    {
        IEnumerable<BookImage> GetBookImages(int id);
    }
}
