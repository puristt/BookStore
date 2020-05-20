using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
    }
}
