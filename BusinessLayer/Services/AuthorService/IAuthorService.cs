using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.AuthorService
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
    }
}
