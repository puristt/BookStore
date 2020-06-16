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

        public Author CheckByName(string name)
        {
            var parameters = new { Name = name };
            return _repository.LoadData("spCheckAuthorExistanceByName", parameters).FirstOrDefault();
        }

        public int Delete(int id)
        {
            var parameters = new { Id = id };
            return _repository.SaveData<Author>("spDeleteAuthor", parameters);
        }

        public IEnumerable<Author> GetAll()
        {
            return _repository.LoadData("spGetAllAuthors");
        }

        public Author GetById(int id)
        {
            var parameters = new { AuthorId = id };
            return _repository.LoadData("spGetAuthor", parameters).FirstOrDefault();
        }

        public int Save(Author entity)
        {
            int result;
            if (entity.Id == default)
            {
                var parameters = new { entity.Name, entity.Description };
                result = _repository.SaveData<Author>("spInsertAuthor", parameters);
            }
            else
            {
                var parameters = new { entity.Id, entity.Name, entity.Description };
                result = _repository.SaveData<Author>("spUpdateAuthor", parameters);
            }

            return result;
        }

        public IEnumerable<Author> SearchAlphabetically(string letter)
        {
            var parameters = new { Letter = letter };
            return _repository.LoadData("spGetAuthorsWithAlphabeticSearch", parameters);
        }

        public IEnumerable<Author> SearchByName(string name)
        {
            var parameters = new { Name = name };
            return _repository.LoadData("spSearchAuthorByName", parameters);
        }
    }
}
