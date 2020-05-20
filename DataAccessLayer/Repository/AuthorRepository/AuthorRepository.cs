using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDapperRepository<Author> _repository;

        public AuthorRepository(IDapperRepository<Author> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Author> GetAll()
        {
            return _repository.LoadData("spGetAllAuthors");
        }
    }
}
